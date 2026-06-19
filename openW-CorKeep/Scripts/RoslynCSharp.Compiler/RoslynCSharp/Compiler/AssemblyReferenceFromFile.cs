using System;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public struct AssemblyReferenceFromFile : IMetadataReferenceProvider
	{
		private string filePath;

		public string FilePath => filePath;

		public MetadataReference CompilerReference => MetadataReference.CreateFromFile(filePath);

		public AssemblyReferenceFromFile(string assemblyFile)
		{
			if (assemblyFile == null)
			{
				throw new ArgumentNullException("assemblyFile");
			}
			filePath = assemblyFile;
		}
	}
}
