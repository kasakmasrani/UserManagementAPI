using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private static List<User> users = new List<User>();

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User AddUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return user;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return false;

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return false;

            users.Remove(user);
            return true;
        }
    }
}