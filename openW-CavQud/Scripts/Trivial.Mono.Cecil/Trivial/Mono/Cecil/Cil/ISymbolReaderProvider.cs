using System.IO;

namespace Trivial.Mono.Cecil.Cil
{
	public interface ISymbolReaderProvider
	{
		ISymbolReader GetSymbolReader(ModuleDefinition module, string fileName);

		ISymbolReader GetSymbolReader(ModuleDefinition module, Stream symbolStream);
	}
}
