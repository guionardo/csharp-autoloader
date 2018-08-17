namespace Autoload
{
    /// <summary>
    /// Interface para definir classes que contém o método Load
    /// </summary>
    interface IAutoload
    {
        /// <summary>
        /// Função de classe que será executada uma vez, chamada pelo método AutoLoad.LoadAll()
        /// </summary>
        /// <returns></returns>
        bool OnAutoLoad();

    }
}
