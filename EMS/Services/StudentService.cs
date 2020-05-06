using Models;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<Student> GetAsync(int id)
        {
            return await studentRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await studentRepository.GetAllAsync();
        }

        public async Task<int> InsertAsync(Student student)
        {
            return await studentRepository.InsertAsync(student);
        }

        public async Task<int> UpdateAsync(Student student)
        {
            return await studentRepository.UpdateAsync(student);
        }
        public async Task<int> DeleteAsync(int id)
        {
            return await studentRepository.DeleteAsync(id);
        }
    }
}