using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Linq;
using System.Reflection;

namespace tWebConsoleAppReflection
{
    //check in http://localhost:9000/api/test/GetTestControllerMethods

    public class TestController : ApiController
    {
        //test method
        public IEnumerable<string> GetTest()
        {
            return new string[] { "One", "Two", "Three" };
        }

        //display all methods in classes within tWebConsoleAppReflection namespace
        public IEnumerable<string> GetTestControllerMethods()
        {
            /*var methodsInfo = typeof(TestController)
                .GetMethods().Where(x => x.IsFamily);*/

            var resultList = new List<string>();

            foreach (var typeInNamespace in 
                                GetTypesInNamespace(Assembly.GetExecutingAssembly(), "tWebConsoleAppReflection"))
            {
                var methodsInfo = typeInNamespace.GetMethods();
                resultList.Add($"{new string('-', 5)} {typeInNamespace.Name} {new string('-', 5)}");

                foreach (var methodInfo in methodsInfo)
                    resultList.Add(methodInfo.Name);
            }

            return resultList;
        }

        //return all types in current namespace
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
    }
}
