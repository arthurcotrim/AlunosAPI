using AlunosAPI.Models;

namespace AlunosAPI.Interfaces
{
    public interface IStudent
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<Student> PostStudent(Student? newStudent);
    }
}
