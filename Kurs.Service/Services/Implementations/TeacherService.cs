using Kurs.Core.Models;
using Kurs.Data.Repositories.Implementations;
using Kurs.Data.Repositories.Interfaces;
using Kurs.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Service.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly TeacherRepository _teacherRepository;
        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();

        }
        public async Task AddAsync()
        {
            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Surname:");
            string surname = Console.ReadLine();

            Console.Write("Father name:");
            string fathername = Console.ReadLine();

            Console.Write("Pin:");
            string pin = Console.ReadLine();

            await _teacherRepository.AddAsync(new()
            {
                Name = name,
                Surname = surname,
                Fathername = fathername,
                Fincode = pin,
                CreatedDate = DateTime.Now,
            });
        }

        public async Task DeleteAsync()
        {
            Console.Write("Enter Teacher Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            if (id != 0)
                await _teacherRepository.DeleteAsync(id);
        }

        public async Task GetAllAsync()
        {
            ICollection<Teacher> teachers = await _teacherRepository.GetAllAsync();
            foreach (Teacher teacher in teachers)
                Console.WriteLine(teacher);
        }

        public async Task GetAsync()
        {
            Console.Write("Enter Teacher Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            Teacher teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher != null)
                Console.WriteLine(teacher);
        }

        public async Task UpdateAsync()
        {
            Console.Write("Enter Teacher Id: ");
            int.TryParse(Console.ReadLine(), out int id);

            Teacher updatedTeacher = await _teacherRepository.GetByIdAsync(id);
            if (updatedTeacher != null)
            {
                Console.Write("Enter Name:");
                string name = Console.ReadLine();

                Console.Write("Surname:");
                string surname = Console.ReadLine();

                Console.Write("Address:");
                string fathername = Console.ReadLine();

                Console.Write("Phone:");
                string pin = Console.ReadLine();

                



                updatedTeacher.Name = name;
                updatedTeacher.Surname = surname;
                updatedTeacher.Fathername = fathername;
                updatedTeacher.Fincode = pin;
                updatedTeacher.UpdatedDate = DateTime.Now;
                await _teacherRepository.UpdateAsync(updatedTeacher);
            }
        }
    }
}
