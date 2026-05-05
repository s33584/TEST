
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/vendors")]
public class VendorController : ControllerBase
{
    private readonly IVendorService _vendorService;
    public VendorController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }


    [HttpGet("{code}")]
    public async Task<IActionResult> GetVendor(string code)
    {
        var vendor = await _vendorService.GetVendorAsync(code);
        if (vendor is null)
        {
            return NotFound($"Vendor with code {code} was not found.");
        }
        return Ok(vendor);
    } 


    [HttpPost]
    public async Task<IActionResult> AddVendor([FromBody] VendorRequestDTO vendor)
    {
        await _vendorService.AddVendorAsync(vendor);
        return Created();
    }
}