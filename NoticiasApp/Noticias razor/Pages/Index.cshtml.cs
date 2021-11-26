using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassNoticias.Data;
using ClassNoticias.Models;

namespace Noticias_razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NoticiasContext context1;

        public IndexModel(ILogger<IndexModel> logger, NoticiasContext context)
        {
            _logger = logger;
            context1 = context;
        }
        public List<Noticiass>Not{get;set;}

        public void OnGet()
        {
            Not = context1.Noticiasses.ToList();

        }
    }
}
