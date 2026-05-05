

public interface IVendorService
{
    Task<VendorResponceDTO?> GetVendorAsync(string vendorCode);
    Task AddVendorAsync(VendorRequestDTO request);

}