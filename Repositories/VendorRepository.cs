

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

public class VendorRepository : IVendorRepository
{
    private readonly string _connectionString;

    public VendorRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Missing 'Default' connection string.");
    }

    public async Task AddVendorAsync(VendorRequestDTO request)
     {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new SqlCommand(
            "INSERT INTO Vendors (Code, Name) VALUES (@code, @name);",
            connection);
        command.Parameters.AddWithValue("@code", request.Code);
        command.Parameters.AddWithValue("@name", request.Name);

        await command.ExecuteNonQueryAsync();
    }
    
    public async Task<VendorResponceDTO?> GetVendorAsync(string vendorCode)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        VendorResponceDTO vendor;

        await using (var vendorCommand = new SqlCommand(
            @"SELECT Code, Name from Vendors WHERE Code = @vendorCode",
            connection))
        {
            vendorCommand.Parameters.AddWithValue("@vendorCode", vendorCode);

            await using var vendorReader = await vendorCommand.ExecuteReaderAsync();
            if (!await vendorReader.ReadAsync())
            {
                return null;
            }

            vendor = new VendorResponceDTO
            {
                Code = vendorReader.GetString(0), 
                Name = vendorReader.GetString(1),  
            };
        }

        await using (var productsCommand = new SqlCommand(
            @"SELECT Id, Name, Description, StickerPrice, ProductTypeId, MakerId FROM Products JOIN VendorProducts on Products.Id = VendorProducts.ProductId WHERE VendorProducts.VendorCode = @code",
            connection))
        {
            productsCommand.Parameters.AddWithValue("@code", vendorCode);

            await using var reader = await productsCommand.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
            {
                return null;
            }
            vendor.Products.Add(new ProductResponceDTO
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                StickerPrice = reader.GetString(3),
                ProductTypeId = reader.GetInt32(4),
                MakerId = reader.GetInt32(5)
            });
 
        }



        return vendor;
    }
}