

using System.ComponentModel.DataAnnotations;

public class VendorRequestDTO
{
    [Required]
    public string Code { get; set; } = null!; 

    [Required]
    public string Name { get; set; } = null!;

    public List<CreateVendorProductRequestDTO> Products { get; set; } = new();

}