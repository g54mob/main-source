using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public interface IMetadataReferenceProvider
	{
		MetadataReference Reference { get; }
	}
}
