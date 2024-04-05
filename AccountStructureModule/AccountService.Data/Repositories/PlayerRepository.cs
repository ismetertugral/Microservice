using AccountService.Data.Entites;
using MongoDB.Driver;

namespace AccountService.Data.Repositories
{
    public class PlayerRepository
    {
        private readonly IMongoCollection<Player> _playersCollection;
        public PlayerRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("AccountStructureDb");

            _playersCollection = database.GetCollection<Player>("players");
        }

        public async Task<Player> Create(Player player)
        {
            await _playersCollection.InsertOneAsync(player);
            return player;
        }

        public async Task<List<Player>?> GetAll()
        {
            var filter = Builders<Player>.Filter.Empty;
            var result = await _playersCollection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<Player?> GetById(string id)
        {
            var filter = Builders<Player>.Filter.Eq(x => x.Id, id);
            var result = await _playersCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task Update(Player updatedPlayer)
        {
            var filter = Builders<Player>.Filter.Eq(x => x.Id, updatedPlayer.Id);
            //var updated = Builders<Player>.Update.Set(x=>x.Username,updatedPlayer.Username);

            //await _playersCollection.UpdateOneAsync(filter,updated);
            await _playersCollection.FindOneAndReplaceAsync(filter, updatedPlayer);
        }

        public async Task Remove(string id)
        {
            var filter = Builders<Player>.Filter.Eq(x => x.Id, id);

            await _playersCollection.DeleteOneAsync(filter);
        }
    }
}
