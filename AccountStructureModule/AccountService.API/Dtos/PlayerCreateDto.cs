namespace AccountService.API.Dtos
{
   public record PlayerCreateDto(string FirstName, string Lastname, string Username);
   public record PlayerUpdateDto(string id, string FirstName, string Lastname, string Username);
}
