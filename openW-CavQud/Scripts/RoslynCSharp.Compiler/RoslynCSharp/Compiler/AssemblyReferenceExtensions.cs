using System;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public static class AssemblyReferenceExtensions
	{
		public static bool TryResolveReference(this IMetadataReferenceProvider provider)
		{
			MetadataReference reference;
			Exception error;
			return provider.TryResolveReference(out reference, out error);
		}

		public static bool TryResolveReference(this IMetadataReferenceProvider provider, out MetadataReference reference, out Exception error)
		{
			reference = null;
			error = null;
			try
			{
				reference = provider.Reference;
				return true;
			}
			catch (Exception inner)
			{
				error = new TargetException($"Failed to resolve assembly reference '{reference.ToString()}'", inner);
				return false;
			}
		}
	}
}
