using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class MarkupExtensionProvider : IServiceProvider, IProvideValueTarget, IUriContext, IXamlTypeResolver, IXamlNamespaceResolver, IXamlNameResolver
	{
		private HandleRef _provider;

		object IProvideValueTarget.TargetObject => null;

		object IProvideValueTarget.TargetProperty => null;

		Uri IUriContext.BaseUri => null;

		object IServiceProvider.GetService(Type serviceType)
		{
			return null;
		}

		Type IXamlTypeResolver.Resolve(string qualifiedTypeName)
		{
			return null;
		}

		string IXamlNamespaceResolver.GetNamespace(string prefix)
		{
			return null;
		}

		object IXamlNameResolver.Resolve(string name)
		{
			return null;
		}

		internal MarkupExtensionProvider(IntPtr cPtr)
		{
		}

		[PreserveSig]
		private static extern IntPtr MarkupExtensionProvider_TargetObject(HandleRef provider);

		[PreserveSig]
		private static extern IntPtr MarkupExtensionProvider_TargetProperty(HandleRef provider);

		[PreserveSig]
		private static extern IntPtr MarkupExtensionProvider_BaseUri(HandleRef provider);

		[PreserveSig]
		private static extern IntPtr MarkupExtensionProvider_ResolveType(HandleRef provider, string name);

		[PreserveSig]
		private static extern IntPtr MarkupExtensionProvider_GetNamespace(HandleRef provider, string name);

		[PreserveSig]
		private static extern IntPtr MarkupExtensionProvider_ResolveName(HandleRef provider, string name);
	}
}
