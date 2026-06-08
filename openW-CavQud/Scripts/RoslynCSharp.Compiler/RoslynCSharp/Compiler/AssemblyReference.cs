using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public struct AssemblyReference : IMetadataReferenceProvider
	{
		private IMetadataReferenceProvider reference;

		private string assemblyName;

		private AppDomain domain;

		public MetadataReference Reference => reference.Reference;

		public AssemblyReference(string assemblyName, AppDomain domain = null)
		{
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			if (domain == null)
			{
				domain = AppDomain.CurrentDomain;
			}
			reference = null;
			Assembly[] assemblies = domain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				if (assembly.GetName().Name == assemblyName)
				{
					reference = new AssemblyReferenceFromAssemblyObject(assembly);
					break;
				}
			}
			if (reference == null)
			{
				throw new ArgumentException($"Failed to resolve assembly reference '{assemblyName}'. Ensure that the assembly is loaded and that the specified name is correct");
			}
			this.assemblyName = assemblyName;
			this.domain = domain;
		}

		public static IMetadataReferenceProvider FromNameOrFile(string assemblyNameOrFilePath, AppDomain searchDomain = null)
		{
			if (!File.Exists(assemblyNameOrFilePath))
			{
				return new AssemblyReference(Path.GetFileNameWithoutExtension(assemblyNameOrFilePath), searchDomain);
			}
			return new AssemblyReferenceFromFile(assemblyNameOrFilePath);
		}

		public static IMetadataReferenceProvider FromAssembly(Assembly assembly)
		{
			return new AssemblyReferenceFromAssemblyObject(assembly);
		}

		public static IMetadataReferenceProvider FromStream(Stream assemblyStream)
		{
			return new AssemblyReferenceFromStream(assemblyStream);
		}

		public static IMetadataReferenceProvider FromImage(byte[] assemblyImage)
		{
			return new AssemblyReferenceFromImage(assemblyImage);
		}
	}
}
