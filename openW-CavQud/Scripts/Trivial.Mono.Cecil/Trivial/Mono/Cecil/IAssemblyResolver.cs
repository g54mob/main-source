using System;

namespace Trivial.Mono.Cecil
{
	public interface IAssemblyResolver : IDisposable
	{
		AssemblyDefinition Resolve(AssemblyNameReference name);

		AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters);
	}
}
