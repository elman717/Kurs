using Kurs.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.Service.Services.Interfaces;
using Kurs.Core.Models;
using Kurs.Data.Repositories.Interfaces;
using Kurs.Data.Repositories.Implementations;

namespace Kurs.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly GroupRepository _groupRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository= new GroupRepository();
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

            Console.WriteLine("Group id");
            int.TryParse(Console.ReadLine(), out int id);


            await _studentRepository.AddAsync(new()
            {
                Name = name,
                Surname = surname,
                Fathername = fathername,
                Fincode = pin,
                CreatedDate = DateTime.Now,
                Group = await _groupRepository.GetByIdAsync(id),
            });
        }

        public async Task DeleteAsync()
        {
            Console.Write("Enter Student Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            if (id != 0)
                await _studentRepository.DeleteAsync(id);
        }

        public async Task GetAllAsync()
        {
            ICollection<Student> students = await _studentRepository.GetAllAsync();
            foreach (Student student in students)
                Console.WriteLine(student);
        }

        public async Task GetAsync()
        {
            Console.Write("Enter Student Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            Student student = await _studentRepository.GetByIdAsync(id);

            if (student != null)
                Console.WriteLine(student);
        }

        public async Task UpdateAsync()
        {
            Console.Write("Enter Student Id: ");
            int.TryParse(Console.ReadLine(), out int id);

            Student updatedStudent = await _studentRepository.GetByIdAsync(id);
            if (updatedStudent != null)
            {
                Console.Write("Enter Name:");
                string name = Console.ReadLine();

                Console.Write("Surname:");
                string surname = Console.ReadLine();

                Console.Write("Address:");
                string fathername = Console.ReadLine();

                Console.Write("Phone:");
                string pin = Console.ReadLine();

                Console.WriteLine("Group id");
                int.TryParse(Console.ReadLine(), out int ld);



                updatedStudent.Name = name;
                updatedStudent.Surname = surname;
                updatedStudent.Fathername = fathername;
                updatedStudent.Fincode = pin;
                updatedStudent.UpdatedDate = DateTime.Now;
                updatedStudent.Group =await _groupRepository.GetByIdAsync(ld);
                await _studentRepository.UpdateAsync(updatedStudent);
            }
        }
    }
}
