using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaCursos.Interfaces;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class EditModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        [BindProperty]
        public Course course { get; set; }

        public EditModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                course = new Course();
            }
            else
            {
                var curso = await coursesProvider.GetAsync(id.Value);
                if (curso != null)
                {
                    course = curso;
                }
            }
            

            return Page();
        }

        public async Task<IActionResult> OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (course.id == 0)
            {
                var result = await coursesProvider.AddAsync(course);

                if (result.isSuccess)  
                {
                    return RedirectToPage("Courses");
                }

                return Page();
            }
            else
            {
                var result = await coursesProvider.UpdateAsync(course.id, course);
                if (result)
                {
                    return RedirectToPage("Courses");
                }
            }
            

            return Page();
        }
    }
}
