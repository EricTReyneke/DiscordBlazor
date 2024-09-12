using Data.BlazorDatabaseApis.Base;
using System.Collections.Generic;

namespace Data.BlazorDatabaseApis.Interfaces
{
    public interface IUserDataOperations
    {
        /// <summary>
        /// Retrieves all Users in the database.
        /// </summary>
        /// <returns>List Of Users in the database.</returns>
        List<User> RetrieveAllUsers();
    }
}