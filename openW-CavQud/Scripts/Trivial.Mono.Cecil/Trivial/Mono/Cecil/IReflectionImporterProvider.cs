namespace Trivial.Mono.Cecil
{
	public interface IReflectionImporterProvider
	{
		IReflectionImporter GetReflectionImporter(ModuleDefinition module);
	}
}
