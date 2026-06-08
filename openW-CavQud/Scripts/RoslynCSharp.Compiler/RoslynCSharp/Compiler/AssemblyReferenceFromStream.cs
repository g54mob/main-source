using System;
using System.IO;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public struct AssemblyReferenceFromStream : IMetadataReferenceProvider
	{
		private Stream stream;

		public Stream Stream => stream;

		public MetadataReference Reference => MetadataReference.CreateFromStream(stream);

		public AssemblyReferenceFromStream(Stream assemblyStream)
		{
			if (assemblyStream == null)
			{
				throw new ArgumentNullException("assemblyStream");
			}
			if (!assemblyStream.CanRead)
			{
				throw new ArgumentException("Assembly stream must be readable");
			}
			stream = assemblyStream;
		}
	}
}
