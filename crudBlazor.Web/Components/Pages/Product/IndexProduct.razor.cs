using Blazored.Toast.Services;
using crudBlazor.Model.Entities;
using crudBlazor.Model.Models;
using crudBlazor.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace crudBlazor.Web.Components.Pages.Product;
public partial class IndexProduct
{
    [Inject]
    public ApiClient? ApiClient { get; set; }
    public List<ProductModel>? ProductModels { get; set; }
    public AppModal? Modal { get; set; }
    public int DeleteID { get; set; }
    [Inject]
    private IToastService? ToastService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadProduct();
    }

    protected async Task LoadProduct()
    {
        var result = await ApiClient!.GetFromJsonAsync<BaseResponseModel>("/api/Product");
        if (result != null && result.Success)
        {
            ProductModels = JsonConvert.DeserializeObject<List<ProductModel>>(result.Data?.ToString()!);
        }
    }

    protected async Task HandleDelete()
    {
        var res = await ApiClient!.DeleteAsync<BaseResponseModel>($"/api/Product/{DeleteID}");
        if (res != null && res.Success)
        {
            ToastService?.ShowSuccess("Delete product successfully");
            await LoadProduct();
            Modal?.Close();
        }
    }
}