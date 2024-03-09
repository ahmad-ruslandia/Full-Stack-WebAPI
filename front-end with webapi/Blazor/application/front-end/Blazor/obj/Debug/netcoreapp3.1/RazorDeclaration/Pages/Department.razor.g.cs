// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Blazor.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\Pages\Department.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\Pages\Department.razor"
using System.Text.Json.Serialization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/department")]
    public partial class Department : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 126 "D:\Project\Full-Stack-WebAPI\WebAPI-NBS\application\front-end\Blazor\Pages\Department.razor"
       
    public class DepartmentClass
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    private IEnumerable<DepartmentClass> departments = Array.Empty<DepartmentClass>();

    private string DepartmentIdFilter = "";
    private string DepartmentNameFilter = "";

    private IEnumerable<DepartmentClass> departmentsWithoutFilter = Array.Empty<DepartmentClass>();

    private string modalTitle;
    private int DepartmentId;
    private string DepartmentName;


    protected override async Task OnInitializedAsync()
    {
        await refreshList();
    }


    private async Task refreshList()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            config["API_URL"] + "department");

        var client = ClientFactory.CreateClient();

        var response = await client.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        departmentsWithoutFilter =  departments = await JsonSerializer.DeserializeAsync<IEnumerable<DepartmentClass>>(responseStream);
    }

    private void FilterFn()
    {
        departments = departmentsWithoutFilter.Where(
            c => c.DepartmentId.ToString().Contains(DepartmentIdFilter) &&
            c.DepartmentName.ToLower().Contains(DepartmentNameFilter.ToLower()));
    }

    private void SortFn(string property, string asc_desc)
    {
        if (property == "DepartmentId")
        {
            if (asc_desc == "asc")
            {
                departments = departmentsWithoutFilter.OrderBy(c => c.DepartmentId);
            }
            else
            {
                departments = departmentsWithoutFilter.OrderByDescending(c => c.DepartmentId);
            }
        }
        else
        {
            if (asc_desc == "asc")
            {
                departments = departmentsWithoutFilter.OrderBy(c => c.DepartmentName);
            }
            else
            {
                departments = departmentsWithoutFilter.OrderByDescending(c => c.DepartmentName);
            }
        }
    }


    private async Task createClick()
    {
        var depObj = new DepartmentClass() { DepartmentName = DepartmentName };

        var request = new HttpRequestMessage(HttpMethod.Post,
            config["API_URL"] + "department");
        request.Content = new StringContent(JsonSerializer.Serialize(depObj), null, "application/json");

        var client = ClientFactory.CreateClient();

        var response = await client.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        string res = await JsonSerializer.DeserializeAsync<string>(responseStream);

        await JS.InvokeVoidAsync("alert", res);

        await refreshList();
    }

    private async Task updateClick()
    {
        var depObj = new DepartmentClass() {
            DepartmentId = DepartmentId,
            DepartmentName = DepartmentName };

        var request = new HttpRequestMessage(HttpMethod.Put,
            config["API_URL"] + "department");
        request.Content = new StringContent(JsonSerializer.Serialize(depObj), null, "application/json");

        var client = ClientFactory.CreateClient();

        var response = await client.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        string res = await JsonSerializer.DeserializeAsync<string>(responseStream);

        await JS.InvokeVoidAsync("alert", res);

        await refreshList();
    }


    private async Task deleteClick(int id)
    {
        if(!await JS.InvokeAsync<bool>("confirm","Are you sure"))
        {
            return;
        }

        var request = new HttpRequestMessage(HttpMethod.Delete,
            config["API_URL"] + "department/"+id.ToString());

        var client = ClientFactory.CreateClient();

        var response = await client.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        string res = await JsonSerializer.DeserializeAsync<string>(responseStream);

        await JS.InvokeVoidAsync("alert", res);

        await refreshList();
    }

    private void addClick()
    {
        modalTitle = "Add Department";
        DepartmentId = 0;
        DepartmentName = "";
    }

    private void editClick(DepartmentClass dep)
    {
        modalTitle = "Edit Department";
        DepartmentId = dep.DepartmentId;
        DepartmentName = dep.DepartmentName;
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Configuration.IConfiguration config { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
    }
}
#pragma warning restore 1591
