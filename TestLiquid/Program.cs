using System;
using System.IO;
using System.Collections.Generic;
using DotLiquid;

namespace TestLiquid
{
    class Program
    {
        static void Main(string[] args)
        {
            // lower case or upper case is all OK
            string strTemplate = 
@"<p>{{ user.name }} has to do:</p>
{% for item in user.tasks %}{{ item.name }}
{% endfor %}";
            Console.WriteLine(strTemplate);

            Console.WriteLine("\n-----------------------------------------\n");

            // variables are all upper case
            var userObj = new User
            {
                Name = "Tim Jones",
                Tasks = new List<Task>
                {
                    new Task { Name = "Documentation" },
                    new Task { Name = "Code comments" }
                }
            };

            Template template = Template.Parse(strTemplate);  // Parses and compiles the template
            string str = template.Render(Hash.FromAnonymousObject(new { user = userObj })); // Renders the output => "hi tobi"
            Console.WriteLine(str);
        }
    }

    public class User : Drop
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }

    public class Task : Drop
    {
        public string Name { get; set; }
    }
}
