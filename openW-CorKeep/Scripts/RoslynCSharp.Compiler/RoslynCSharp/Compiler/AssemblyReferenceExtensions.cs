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
			if (provider == null)
			{
				return false;
			}
			try
			{
				reference = provider.CompilerReference;
				return true;
			}
			catch (Exception inner)
			{
				string arg = ((reference != null) ? reference.ToString() : ((provider != null) ? provider.ToString() : "Unknown"));
				error = new TargetException($"Failed to resolve assembly reference '{arg}'", inner);
				return false;
			}
		}
	}
}
