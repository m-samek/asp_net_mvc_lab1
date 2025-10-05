using asp_net_mvc_lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_lab1.Controllers;

public class BlogController : Controller
{
    private readonly ILogger<BlogController> _logger;

    private static readonly List<BlogArticleViewModel> _articles = new()
    {
        new BlogArticleViewModel {Title = "Welcome to My Blog", Description = "Intro post about the blog."},
        new BlogArticleViewModel {Title = "Learning ASP .NET MVC", Description = "Basics of ASP .NET MVC."},
        new BlogArticleViewModel {Title = "Understanding Routing", Description = "How routing works."}
    };

    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_articles);

    }

    public IActionResult Article(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return NotFound();
        var post = _articles.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return View(post);
    }
}