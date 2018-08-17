using System;

namespace Autoload
{
    class TesteAutoLoad1 : IAutoload
    {
        public bool OnAutoLoad()
        {
            Console.WriteLine(GetType().Name + ".OnAutoLoad");
            return true;
        }
    }
}
