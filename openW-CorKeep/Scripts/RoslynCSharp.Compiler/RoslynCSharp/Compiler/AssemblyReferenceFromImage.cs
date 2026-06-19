using System;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public struct AssemblyReferenceFromImage : IMetadataReferenceProvider
	{
		private byte[] image;

		public byte[] Image => image;

		public MetadataReference CompilerReference => MetadataReference.CreateFromImage(image);

		public AssemblyReferenceFromImage(byte[] assemblyImage)
		{
			if (assemblyImage == null)
			{
				throw new ArgumentNullException("assemblyImage");
			}
			image = assemblyImage;
		}
	}
}
