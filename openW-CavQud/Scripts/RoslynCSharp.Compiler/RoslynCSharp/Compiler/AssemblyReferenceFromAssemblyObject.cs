using System;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public struct AssemblyReferenceFromAssemblyObject : IMetadataReferenceProvider
	{
		private AssemblyReferenceFromFile reference;

		private Assembly assembly;

		public MetadataReference Reference => reference.Reference;

		public AssemblyReferenceFromAssemblyObject(Assembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			if (string.IsNullOrEmpty(assembly.Location))
			{
				throw new ArgumentException("The specified assembly is not referencable because it's 'Location' property is empty. You will need to reference the assembly explicitly by filepath, filestream or assembly image data");
			}
			this.assembly = assembly;
			reference = new AssemblyReferenceFromFile(assembly.Location);
		}
	}
}
