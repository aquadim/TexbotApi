namespace TexbotApi.Models;

public class Group
{
    public long Id { get; set; }
    public byte? Course { get; set; } // Курс
    public string Specialty { get; set; } // Специальность
}