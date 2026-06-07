using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FontFamily : BaseComponent
	{
		public Uri BaseUri => null;

		public string Source => null;

		internal new static FontFamily CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FontFamily(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FontFamily obj)
		{
			return default(HandleRef);
		}

		public FontFamily()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public FontFamily(string source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FontFamily(Uri baseUri, string source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public uint GetNumFonts()
		{
			return 0u;
		}

		public Uri GetFontPath(uint index)
		{
			return null;
		}

		public string GetFontName(uint index)
		{
			return null;
		}
	}
}
