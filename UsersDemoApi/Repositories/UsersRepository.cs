using UsersDemoApi.Models;

namespace UsersDemoApi.Repositories
{
    public class UsersRepository
    {
        private List<User> users;
       
        //--Make Id Forward By 1 for each Add
        private static int countIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        public UsersRepository()
        {
            users= new List<User>();
            Add(new User { Name = "Stephen Carry", Phone = "5645656", Email = "stcarr@gmail.com", CompaniesId = "1" });
            Add(new User { Name = "Lavron James", Phone = "67867878", Email = "lvJames@gmail.com", CompaniesId = "2" });
            Add(new User { Name = "Kevin durnet", Phone = "454565456", Email = "kevdu@hotmail.com", CompaniesId = "2" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return users; //.OrderBy(u=>u.Id).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {           
            User user = this.users.FirstOrDefault(u => u.Id == id);
            return user;  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public int Add(User newUser)
        {
            int returnIndex = -1;
            int indexFound = this.users.FindIndex(u => u.Id == newUser.Id);
            //If this user is not exsist in list according ID
            //Allow Add
            if (indexFound < 0)
            {
                UsersRepository.countIndex++;
                newUser.Id = countIndex;
                users.Add(newUser);
                returnIndex = newUser.Id;
            }
            return returnIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        public int Remove(int idToRemove)
        {
            int indexFound = this.users.FindIndex(u => u.Id == idToRemove);
            if (indexFound > 0)
            {
                this.users.RemoveAt(indexFound);
                
            }
            return indexFound;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <returns></returns>
        public bool Update(User userToUpdate)
        {
            int indexFound = this.users.FindIndex(u => u.Id == userToUpdate.Id);
            if (indexFound > 0)
            {
                //Update Current User
                this.users[indexFound] = userToUpdate;
                return true;
            }
            return false;
        }
    }




}
