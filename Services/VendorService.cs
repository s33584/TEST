

public class VendorService : IVendorService
{
    private readonly IVendorRepository _vendorRepository;
    public VendorService(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;
    }


    public Task AddVendorAsync(VendorRequestDTO request)
    {
        return _vendorRepository.AddVendorAsync(request);
    }

    public Task<VendorResponceDTO?> GetVendorAsync(string vendorCode)
    {
        return _vendorRepository.GetVendorAsync(vendorCode);   
    }
}