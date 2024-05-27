using Kurs.Core.Models;
using Kurs.Data.Repositories.Implementations;
using Kurs.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Service.Services.Implementations
{
    public class TeacherGroupService : ITeacherGroupService
    {
        private readonly TeacherGroupRepository _teacherGroupRepository;
        private readonly TeacherRepository _teacherRepository;
        private readonly GroupRepository _groupRepository;
        public TeacherGroupService()
        {
            _teacherGroupRepository = new TeacherGroupRepository();
            _teacherRepository = new TeacherRepository();
            _groupRepository = new GroupRepository();
        }
        public async Task AddAsync()
        {
            Console.WriteLine("Enter Subject Name");
            string subjectName=Console.ReadLine();

            Console.WriteLine("Enter Group Id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("Enter Teacher Id");
            int.TryParse(Console.ReadLine(), out int id1);

            await _teacherGroupRepository.AddAsync(new()
            {
                SubjectName = subjectName,
                
                Group = await _groupRepository.GetByIdAsync(id),
                Teacher=await _teacherRepository.GetByIdAsync(id1),
            });


        }

        public async Task DeleteAsync()
        {
            Console.Write("Enter TeacherGroup Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            if (id != 0)
                await _teacherGroupRepository.DeleteAsync(id);
        }

        public async Task GetAllAsync()
        {
            ICollection<TeacherGroup> teacherGroups = await _teacherGroupRepository.GetAllAsync();
            foreach (TeacherGroup teachergroup in teacherGroups)
                Console.WriteLine(teachergroup);
        }

        public async Task GetAsync()
        {
            Console.Write("Enter TeacherGroup Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            TeacherGroup teachergroup = await _teacherGroupRepository.GetByIdAsync(id);

            if (teachergroup != null)
                Console.WriteLine(teachergroup);
        }

        public async Task UpdateAsync()
        {
            Console.Write("Enter TeacherGroup Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            TeacherGroup updatedTeacherGroup = await _teacherGroupRepository.GetByIdAsync(id);
            if (updatedTeacherGroup != null)
            {
                Console.Write("Enter Subject Name:");
                string subjectname = Console.ReadLine();
                Console.WriteLine("Enter Group Id");
                int.TryParse(Console.ReadLine(), out int id1);
                Console.WriteLine("Enter Teacher Id");
                int.TryParse(Console.ReadLine(), out int id2);

                updatedTeacherGroup.SubjectName=subjectname;
                updatedTeacherGroup.Group = await _groupRepository.GetByIdAsync(id1);
                updatedTeacherGroup.Teacher=await _teacherRepository.GetByIdAsync(id2);
                await _teacherGroupRepository.UpdateAsync(updatedTeacherGroup);

            }
        }
    }
}
