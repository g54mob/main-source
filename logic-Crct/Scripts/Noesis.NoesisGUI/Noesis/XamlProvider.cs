using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class XamlProvider : BaseComponent
	{
		public delegate void XamlChangedHandler(Uri uri);

		public event XamlChangedHandler XamlChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal new static XamlProvider CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal XamlProvider(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(XamlProvider obj)
		{
			return default(HandleRef);
		}

		protected XamlProvider()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual Stream LoadXaml(Uri uri)
		{
			return null;
		}

		public void RaiseXamlChanged(Uri uri)
		{
		}

		[PreserveSig]
		private static extern void Noesis_RaiseXamlChanged(HandleRef provider, string uri);

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
