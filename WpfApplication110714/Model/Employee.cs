
namespace WpfApplication110714.Model
{
    public class Employee
    {
        /*Important to understand that our model is not our repository. Our model represents 
         a thing (person, employee, location...). But we don't store or keep actual instances of 
         the model in the model. That is the repository's job. Just like when we set up our
         database the SQL used to create the tables is our model but the actual collections of 
         data is in a seperate place.*/
        public static Employee CreateEmployee(string firstName, string lastName)
        {
            return new Employee { FirstName = firstName, LastName = lastName };
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
