using System.IO;

namespace Trivial.Mono.Cecil.Cil
{
	public interface ISymbolWriterProvider
	{
		ISymbolWriter GetSymbolWriter(ModuleDefinition module, string fileName);

		ISymbolWriter GetSymbolWriter(ModuleDefinition module, Stream symbolStream);
	}
}
