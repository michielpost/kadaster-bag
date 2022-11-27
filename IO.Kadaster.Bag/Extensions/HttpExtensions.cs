using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using IO.Kadaster.Bag.Exceptions;
using IO.Kadaster.Bag.Models;
using IO.Kadaster.Bag.Models.Generated;

namespace IO.Kadaster.Bag.Extensions;

internal static class HttpExtensions
{
    public static async Task<Result<T>> ToResultAsync<T>(this HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
        {
            var success = await responseMessage.Content.ReadFromJsonAsync<T>();
            if (success != null) return success;

            return new NotSupportedException("Success response is null");
        }

        var error = await responseMessage.Content.ReadFromJsonAsync<Error>();

        return error == null
            ? new NotSupportedException("Error response is null")
            : new BagException(error);
    }

    public static StringContent ToJsonRequest<T>(this T request)
    {
        var json = JsonSerializer.Serialize(request);
        return new StringContent(json)
        {
            Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
        };
    }
}