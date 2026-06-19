using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public interface IMetadataReferenceProvider
	{
		MetadataReference CompilerReference { get; }
	}
}
