using ListaCursos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllAsync();

        Task<ICollection<Course>> SearchAsync(string busqueda);
        Task<Course> GetAsync(int id);

        Task<bool> UpdateAsync(int id, Course course);

        Task<(bool isSuccess, int? id)> AddAsync(Course course);
    }
}
