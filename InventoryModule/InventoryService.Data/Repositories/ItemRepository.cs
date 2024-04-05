using InventoryService.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Repositories
{
    public class ItemRepository
    {
        private readonly IMongoCollection<Item> _mongoCollection;
        public ItemRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("InventoryDb");

            _mongoCollection = database.GetCollection<Item>("items");
        }

        public async Task<List<Item>?> GetAll()
        {
            var filter = Builders<Item>.Filter.Empty;

            var result = await _mongoCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<Item?> GetById(string id)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);

            var result = await _mongoCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Item?> Create(Item item)
        {
            await _mongoCollection.InsertOneAsync(item);

            return item;
        }

        public async Task Update(Item item)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, item.Id);

            await _mongoCollection.FindOneAndReplaceAsync(filter, item);
        }

        public async Task Remove(string id)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);

            await _mongoCollection.DeleteOneAsync(filter);
        }
    }
}
