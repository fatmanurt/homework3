using cethw1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cethw1.Views.Shared.components.depMenu
{
    public class depMenuViewComponent : ViewComponent
    {
        private readonly stcontext dbContext;


        public depMenuViewComponent(stcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await dbContext.departments.ToListAsync();
            return View(categories);
        }
    }
}
