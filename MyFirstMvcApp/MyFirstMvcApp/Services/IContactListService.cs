using MyFirstMvcApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Services
{
    public interface IContactListService
    {
        Task<IEnumerable<ContactListEntry>> GetEntriesAsync();

        Task<ContactListEntry> GetByIdAsync(int id);

        Task<bool> CreateEntryAsync(ContactListEntry entry);

        Task<bool> UpdateEntryAsync(ContactListEntry entry);

        Task<bool> DeleteEntryAsync(int id);

    }
}
