
public class VendorResponceDTO
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!; 
    public List<ProductResponceDTO> Products { get; set; } = new();

} 