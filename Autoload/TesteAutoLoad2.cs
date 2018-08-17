using System;

namespace Autoload
{
    class TesteAutoLoad2:IAutoload
    {
        public bool OnAutoLoad()
        {
            Console.WriteLine(GetType().Name + ".OnAutoLoad");
            throw new Exception("Simulação de erro");
            return true;
        }
    }
}
