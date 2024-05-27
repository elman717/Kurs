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
    public class GroupService : IGroupService
    {
        private readonly GroupRepository _groupRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public async Task AddAsync()
        {
            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Description:");
            string description = Console.ReadLine();

            await _groupRepository.AddAsync(new()
            {
                Name = name,
                Description =description,
               
            });
        }

        public async Task DeleteAsync()
        {
            Console.Write("Enter Group Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            if (id != 0)
                await _groupRepository.DeleteAsync(id);
        }

        public async Task GetAllAsync()
        {
            ICollection<Group> groups = await _groupRepository.GetAllAsync();
            foreach (Group group in groups)
                Console.WriteLine(group);
        }

        public async Task GetAsync()
        {
            Console.Write("Enter Group Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            Group group = await _groupRepository.GetByIdAsync(id);

            if (group != null)
                Console.WriteLine(group);
        }

        public async Task UpdateAsync()
        {
            Console.Write("Enter Group Id: ");
            int.TryParse(Console.ReadLine(), out int id);

            Group updatedGroup = await _groupRepository.GetByIdAsync(id);
            if (updatedGroup != null)
            {
                Console.Write("Enter Name:");
                string name = Console.ReadLine();

                Console.Write("Enter Description:");
                string description = Console.ReadLine();
                updatedGroup.Name = name;
                updatedGroup.Description = description;
                await _groupRepository.UpdateAsync(updatedGroup);

            }
        }
    }
}
