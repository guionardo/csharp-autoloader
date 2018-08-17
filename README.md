# csharp-autoloader
Autoload classes on .net

Exemplo de execução automática de métodos de instância.

Esta classe veio atender uma necessidade onde várias classes de um projeto tem um método comum, que é registrar uma operação antes de ser instanciada.
Por exemplo, em uma estrutura MVC, o form (View) de alteração de uma entidade (Model) precisa apontar para o sistema que ele está disponível para ser chamado quando for necessário editar a entidade de determinado tipo.
Assim, de forma genérica, reduzimos o acoplamento entre os models e as views, pois isso será determinado dinamicamente, durante a execução do programa.
