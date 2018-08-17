using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autoload
{
    /// <summary>
    /// Classe de inicialização automática de métodos.
    /// Exemplo de uso, classes que precisam registrar ou executar algum método antes de qualquer 
    /// instanciação.
    /// </summary>
    public static class Autoload
    {
        /// <summary>
        /// Interrompe a execução se encontrado algum erro
        /// </summary>
        public static bool StopOnError = true;

        /// <summary>
        /// Array com os erros que ocorreram durante o OnAutoLoad
        /// </summary>
        public static AutoloadError[] AutoloadErrors { get; private set; } = new AutoloadError[0];
        /// <summary>
        /// Executar todas os métodos OnAutoLoad das classes que implementam a interface IAutoLoad
        /// </summary>
        /// <remarks>
        /// Este método deve ser executado na inicialização da aplicação, </remarks>
        public static void LoadAll()
        {
            // Obtém uma lista de classes não abstratas, que implementam a interface IAutoload
            var l = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                            .Where(x => typeof(IAutoload).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .ToList();
            List<AutoloadError> erros = new List<AutoloadError>();

            foreach (var i in l)
            {
                try
                {
                    object autoload = Activator.CreateInstance(i);
                    MethodInfo onAutoLoadMethod = i.GetMethod("OnAutoLoad");
                    object magicValue = onAutoLoadMethod.Invoke(autoload, new object[] { });
                }
                catch (Exception e)
                {
                    erros.Add(new AutoloadError
                    {
                        Type = i,
                        ClassName = i.Name,
                        Exception = e
                    });
                    if (StopOnError)
                        break;
                }
            }
            AutoloadErrors = erros.ToArray();
            if (StopOnError && erros.Count > 0)
                throw new AutoloadException($"Ocorreu um erro ao processar o método OnAutoLoad da classe {erros[0].Type.AssemblyQualifiedName}\n",
                    erros[0].Exception);
        }

    }

    public struct AutoloadError
    {
        public Type Type;
        public string ClassName;
        public Exception Exception;
    }
}
