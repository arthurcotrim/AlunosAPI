using AlunosAPI.Interfaces;
using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;
using AlunosAPI.Context;

namespace AlunosAPI.Services.StudentServices
{
    public class Students : IStudent
    {
        private readonly AppDbContext context;

        public Students(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var student = await context.Student.ToListAsync();
            return student;
        }

        public async Task<Student?> PostStudent(Student? newStudent)
        {
            if (newStudent == null) return null;

            var student = await context.Student.AddAsync(newStudent);

            if (student == null) return null;

            await context.SaveChangesAsync();

            return student.Entity;
        }
    }
}