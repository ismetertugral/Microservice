using AccountService.API.Dtos;
using AccountService.Data.Entites;
using AccountService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PlayerRepository _playerRepository;

        public AccountsController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _playerRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto dto)
        {
            var result = await _playerRepository.Create(new Player
            {
                Firstname = dto.FirstName,
                Lastname = dto.Lastname,
                Username = dto.Username
            });
            return Created("", result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _playerRepository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _playerRepository.Remove(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PlayerUpdateDto dto)
        {
            await _playerRepository.Update(new Player
            {
                Firstname = dto.FirstName,
                Id = dto.id,
                Lastname = dto.Lastname,
                Username = dto.Username
            });
            return NoContent();
        }
    }
}
