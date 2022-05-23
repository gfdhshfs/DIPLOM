using Library.Service.Models;
using Library.DB;
using Library.DB.EntityModels;

namespace Library.Service
{
    public class LibrarianService
    {
        private readonly DataBaseContext _dataBaseContext = DataBaseContextService.GetContext();

        public bool CheckInputData(UserDto userDto)
        {
            foreach (var librarian in _dataBaseContext.Librarians)
            {
                var status = Equals(userDto, librarian);

                if (!status) continue;

                return true;
            }

            return false;
        }

        private static bool Equals(UserDto inputData, Librarian librarian)
        {
            return inputData.Email == librarian.Email &&
                   inputData.Phone == librarian.Phone &&
                   inputData.Password == librarian.Password;
        }
    }
}