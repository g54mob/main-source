using System;

namespace Trivial.Mono.Cecil.Cil
{
	public interface ISymbolReader : IDisposable
	{
		ISymbolWriterProvider GetWriterProvider();

		bool ProcessDebugHeader(ImageDebugHeader header);

		MethodDebugInformation Read(MethodDefinition method);
	}
}
