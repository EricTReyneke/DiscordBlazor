using Data.BlazorDatabaseApis.Base;
using Data.BlazorDatabaseApis.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.BlazorDatabaseApis.DataOperations.EFDataOperations
{
    public class EFUserDataOperations : EFDataOperationsBase, IUserDataOperations
    {
        #region Public Methods
        public List<User> RetrieveAllUsers()
        {
            try
            {
                return
                _discordEntities
                    .Users
                    .ToList();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}