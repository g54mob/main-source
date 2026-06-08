using System.IO;
using Trivial.Mono.Cecil.Cil;

namespace Trivial.Mono.Cecil.Pdb
{
	public sealed class NativePdbReaderProvider : ISymbolReaderProvider
	{
		public ISymbolReader GetSymbolReader(ModuleDefinition module, string fileName)
		{
			Mixin.CheckModule(module);
			Mixin.CheckFileName(fileName);
			return new NativePdbReader(Disposable.Owned((Stream)File.OpenRead(Mixin.GetPdbFileName(fileName))));
		}

		public ISymbolReader GetSymbolReader(ModuleDefinition module, Stream symbolStream)
		{
			Mixin.CheckModule(module);
			Mixin.CheckStream(symbolStream);
			return new NativePdbReader(Disposable.NotOwned(symbolStream));
		}
	}
}
