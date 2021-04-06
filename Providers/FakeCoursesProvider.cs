using ListaCursos.Interfaces;
using ListaCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Providers
{
    public class FakeCoursesProvider : ICoursesProvider
    {
        private readonly List<Course> repo = new List<Course>();

        public FakeCoursesProvider()
        {
            repo.Add(new Course()
            {
                id = 1,
                Name = "Cálculo Diferencial",
                Author = "Gustavo Ortiz",
                Description = "Curso de Calculo sencillo",
                Url = "https/djgndirjgnañskjdvnc"
            });

            repo.Add(new Course()
            {
                id = 2,
                Name = "Cálculo Vectorial",
                Author = "Bayron Ortiz",
                Description = "Curso de Calculo Avanzado",
                Url = "https/djgndirjgnañskjdvnckujyhtgfvf"
            });

            repo.Add(new Course()
            {
                id = 3,
                Name = "Cálculo Integral",
                Author = "Gustavo Villalba",
                Description = "Curso de Calculo imposible de pasar",
                Url = "https/djgndirjgnañskjdvnc234567"
            });
        }

        public Task<(bool isSuccess, int? id)> AddAsync(Course course)
        {
            course.id = repo.Max(c => c.id) + 1;
            repo.Add(course);
            return Task.FromResult((true, (int?)course.id));
        }

        public Task<ICollection<Course>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Course>)repo.ToList());
        }

        public Task<Course> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(c => c.id == id));
        }

        public Task<ICollection<Course>> SearchAsync(string busqueda)
        {
            return Task.FromResult((ICollection<Course>)repo.Where(c => c.Name.ToLowerInvariant().Contains(busqueda.ToLowerInvariant())).ToList());
        }

        public Task<bool> UpdateAsync(int id, Course course)
        {
            var courseToUpdate = repo.FirstOrDefault(c => c.id == id);

            if (courseToUpdate != null)
            {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Author = course.Author;
                courseToUpdate.Url = course.Url;

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }

        }
    }
}
