

using System.ComponentModel.DataAnnotations;

public class CreateVendorProductRequestDTO
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;

    [Required]
    public int Amount { get; set; }
    [Required]
    public float PricePerUnit { get; set; }
    
}