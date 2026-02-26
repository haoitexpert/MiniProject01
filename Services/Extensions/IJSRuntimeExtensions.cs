using Microsoft.JSInterop;

namespace MiniProject01.Services.Extensions
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async Task ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async Task<bool> ToastrConfirmDelete(this IJSRuntime jsRuntime, string message)
        {
            return await jsRuntime.InvokeAsync<bool>("ShowDeleteConfirm", message);
        }
    }
}