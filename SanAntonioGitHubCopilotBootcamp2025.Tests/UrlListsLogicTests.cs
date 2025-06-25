using Xunit;
using UrlListApp.Pages.UrlLists;
using UrlListApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

public class UrlListsLogicTests
{
    [Fact]
    public void IndexModel_UrlLists_ReturnsStore()
    {
        IndexModel.UrlListsStore.Clear();
        IndexModel.UrlListsStore.Add(new UrlList { Title = "Test List" });
        var model = new IndexModel();
        Assert.Single(model.UrlLists);
    }

    [Fact]
    public void CreateModel_OnPost_ValidModel_AddsToStoreAndRedirects()
    {
        IndexModel.UrlListsStore.Clear();
        var model = new CreateModel { UrlList = new UrlList { Title = "Test List" } };
        var result = model.OnPost();
        Assert.IsType<RedirectToPageResult>(result);
        Assert.Single(IndexModel.UrlListsStore);
    }

    [Fact]
    public void CreateModel_OnPost_InvalidModel_ReturnsPage()
    {
        var model = new CreateModel();
        model.ModelState.AddModelError("Title", "Required");
        var result = model.OnPost();
        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public void EditModel_OnGet_FindsAndReturnsPage()
    {
        IndexModel.UrlListsStore.Clear();
        var urlList = new UrlList { Title = "Edit List" };
        IndexModel.UrlListsStore.Add(urlList);
        var model = new EditModel();
        var result = model.OnGet(urlList.Id);
        Assert.IsType<PageResult>(result);
        Assert.NotNull(model.UrlList);
        Assert.Equal(urlList.Id, model.UrlList.Id);
    }

    [Fact]
    public void EditModel_OnGet_NotFound_Redirects()
    {
        IndexModel.UrlListsStore.Clear();
        var model = new EditModel();
        var result = model.OnGet(Guid.NewGuid());
        Assert.IsType<RedirectToPageResult>(result);
    }

    [Fact]
    public void EditModel_OnPost_ValidModel_UpdatesAndRedirects()
    {
        IndexModel.UrlListsStore.Clear();
        var urlList = new UrlList { Title = "Old Title" };
        IndexModel.UrlListsStore.Add(urlList);
        var model = new EditModel { UrlList = new UrlList { Title = "New Title", CustomUrl = "custom" } };
        var result = model.OnPost(urlList.Id);
        Assert.IsType<RedirectToPageResult>(result);
        Assert.Equal("New Title", urlList.Title);
        Assert.Equal("custom", urlList.CustomUrl);
    }

    [Fact]
    public void EditModel_OnPost_InvalidModel_ReturnsPage()
    {
        var model = new EditModel();
        model.ModelState.AddModelError("Title", "Required");
        var result = model.OnPost(Guid.NewGuid());
        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public void EditModel_OnPost_NotFound_Redirects()
    {
        IndexModel.UrlListsStore.Clear();
        var model = new EditModel { UrlList = new UrlList { Title = "Test" } };
        var result = model.OnPost(Guid.NewGuid());
        Assert.IsType<RedirectToPageResult>(result);
    }

    [Fact]
    public void DeleteModel_OnGet_FindsAndReturnsPage()
    {
        IndexModel.UrlListsStore.Clear();
        var urlList = new UrlList { Title = "Delete List" };
        IndexModel.UrlListsStore.Add(urlList);
        var model = new DeleteModel();
        var result = model.OnGet(urlList.Id);
        Assert.IsType<PageResult>(result);
        Assert.NotNull(model.UrlList);
        Assert.Equal(urlList.Id, model.UrlList.Id);
    }

    [Fact]
    public void DeleteModel_OnGet_NotFound_Redirects()
    {
        IndexModel.UrlListsStore.Clear();
        var model = new DeleteModel();
        var result = model.OnGet(Guid.NewGuid());
        Assert.IsType<RedirectToPageResult>(result);
    }

    [Fact]
    public void DeleteModel_OnPost_RemovesAndRedirects()
    {
        IndexModel.UrlListsStore.Clear();
        var urlList = new UrlList { Title = "Delete List" };
        IndexModel.UrlListsStore.Add(urlList);
        var model = new DeleteModel();
        var result = model.OnPost(urlList.Id);
        Assert.IsType<RedirectToPageResult>(result);
        Assert.Empty(IndexModel.UrlListsStore);
    }

    [Fact]
    public void DetailsModel_OnGet_FindsAndReturnsPage()
    {
        IndexModel.UrlListsStore.Clear();
        var urlList = new UrlList { Title = "Details List" };
        IndexModel.UrlListsStore.Add(urlList);
        var model = new DetailsModel();
        var result = model.OnGet(urlList.Id);
        Assert.IsType<PageResult>(result);
        Assert.NotNull(model.UrlList);
        Assert.Equal(urlList.Id, model.UrlList.Id);
    }

    [Fact]
    public void DetailsModel_OnGet_NotFound_Redirects()
    {
        IndexModel.UrlListsStore.Clear();
        var model = new DetailsModel();
        var result = model.OnGet(Guid.NewGuid());
        Assert.IsType<RedirectToPageResult>(result);
    }
}
