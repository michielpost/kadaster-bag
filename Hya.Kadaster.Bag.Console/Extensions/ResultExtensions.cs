using System.CommandLine;
using System.CommandLine.IO;
using Hya.Kadaster.Bag.Exceptions;
using Hya.Kadaster.Bag.Models;

namespace Hya.Kadaster.Bag.Console.Extensions;

public static class ResultExtensions
{
    public static int HandleErrorState<T>(this Result<T> result, IConsole console, Func<T, int> callback)
    {
        return result.On(callback, error =>
        {
            if (error is BagException bagEx)
            {
                console.Error.WriteLine($"Error: {bagEx.Error.Title}");
            }
            else
            {
                console.Error.WriteLine($"Error: {error.Message}");
            }

            return 1;
        });
    }
}