
public interface IVendorRepository
{
    Task<VendorResponceDTO?> GetVendorAsync(string vendorCode);
    Task AddVendorAsync(VendorRequestDTO request);

}