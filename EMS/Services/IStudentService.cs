using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IStudentService
    {
        Task<Student> GetAsync(int id);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<int> InsertAsync(Student student);

        Task<int> UpdateAsync(Student student);

        Task<int> DeleteAsync(int id);
    }
}