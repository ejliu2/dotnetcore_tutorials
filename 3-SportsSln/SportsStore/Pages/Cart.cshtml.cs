using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Pages {
    public class CartModel : PageModel {
        private IStoreRepository repository;

        public CartModel(IStoreRepository repo) {
            repository = repo;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.SessionGetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productID, string returnUrl) {
            productID product = repository.Products
                .FirstOrDefault(product => product.ProductID = productID);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}