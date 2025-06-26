namespace MIniAccountSystem.Models.Dtos
{
    public class AccountTreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccountTreeDto> Children { get; set; } = new();
    }
}
