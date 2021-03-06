﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcSolution.Infrastructure.Mvc.Extensions
{
    public static class ControllerExtensions
    {
        public static string RenderHtml<T>(this ControllerContext context, string viewPath, T viewModel, TempDataDictionary viewBag)
        {
            var view = new RazorView(context, viewPath, null, false, null);
            viewBag = viewBag ?? new TempDataDictionary();
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                var data = new ViewDataDictionary<T>(viewModel);
                var viewContext = new ViewContext(context, view, data, viewBag, writer);
                view.Render(viewContext, writer);
                writer.Flush();
            }
            return sb.ToString();
        }
    }
}
