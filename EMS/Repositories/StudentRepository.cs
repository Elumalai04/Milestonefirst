using DataContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EMSDataContext _dbContext;

        public StudentRepository(EMSDataContext context)
        {
            _dbContext = context;
        }

        public async Task<Student> GetAsync(int id)
        {
            //If the value is a simple get from a single table
            //return await _dbContext.Student.FirstOrDefaultAsync(e => e.Id == id);

            //If the there is a foriegn key value
            return await (
                         from student in _dbContext.Student
                         join school in _dbContext.School on student.SchoolId equals school.Id into temp
                         from m in temp
                         where student.Id == id

                         select new Student
                         {
                             Id = student.Id,
                             Name = student.Name,
                             Gender = student.Gender,
                             DateOfBirth = student.DateOfBirth,
                             Email = student.Email,
                             Address = student.Address,
                             PhoneNumber = student.PhoneNumber,
                             SchoolId = student.SchoolId,
                             SchoolName = m.Name
                         }
                                 ).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await (from student in _dbContext.Student
                          join school in _dbContext.School on student.SchoolId equals school.Id into temp
                          from m in temp

                          select new Student
                          {
                              Id = student.Id,
                              Name = student.Name,
                              Gender = student.Gender,
                              DateOfBirth = student.DateOfBirth,
                              Email = student.Email,
                              Address = student.Address,
                              PhoneNumber = student.PhoneNumber,
                              SchoolId = student.SchoolId,
                              SchoolName = m.Name
                          }
                                 ).ToListAsync();

            //For selectig all from single table
            //return await _dbContext.Student.ToListAsync();
        }

        public async Task<int> InsertAsync(Student student)
        {
            _dbContext.Student.Add(student);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Student student)
        {
            _dbContext.Update(student);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var student = _dbContext.Student.FirstOrDefault(e => e.Id == id);
            _dbContext.Student.Remove(student);
            return await _dbContext.SaveChangesAsync();
        }
    }
}