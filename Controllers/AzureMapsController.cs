using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

public class AzureMapsController : Controller
{
    private readonly string _azureMapsKey = "bNg4cWQbnYL1Euk2pdb1UbxvuHDrvZHcUOwcJqR9290Rg3OSZ7rIJQQJ99AIACYeBjFTq2kWAAAgAZMPmc13";  // Store your key securely

    [HttpGet]
    public async Task<IActionResult> Geocode(string postalCode)
    {
        if (string.IsNullOrEmpty(postalCode))
        {
            return BadRequest("Postal code is required.");
        }

        // Make the request to Azure Maps API
        string azureMapsUrl = $"https://atlas.microsoft.com/search/address/json?api-version=1.0&subscription-key={_azureMapsKey}&query={postalCode}&countrySet=CA";

        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(azureMapsUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Content(result, "application/json");
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from Azure Maps");
            }
        }
    }

    // Add this new method to return the Azure Maps key
    [HttpGet]
    public IActionResult GetMapKey()
    {
        // Return the Azure Maps key securely in JSON format
        return Json(new { key = _azureMapsKey });
    }
}
