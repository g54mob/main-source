using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TextureProvider : BaseComponent
	{
		public delegate void TextureChangedHandler(Uri uri);

		public event TextureChangedHandler TextureChanged
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

		internal new static TextureProvider CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TextureProvider(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextureProvider obj)
		{
			return default(HandleRef);
		}

		protected TextureProvider()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual void GetTextureInfo(Uri uri, out uint width, out uint height)
		{
			width = default(uint);
			height = default(uint);
		}

		public virtual Texture LoadTexture(Uri uri)
		{
			return null;
		}

		public void RaiseTextureChanged(Uri uri)
		{
		}

		[PreserveSig]
		private static extern void Noesis_RaiseTextureChanged(HandleRef provider, string uri);

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
