using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FontProvider : BaseComponent
	{
		public struct FontSource
		{
			public Stream file;

			public uint faceIndex;
		}

		public delegate void FontChangedHandler(Uri baseUri, string familyName, FontWeight weight, FontStretch stretch, FontStyle style);

		public event FontChangedHandler FontChanged
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

		internal new static FontProvider CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FontProvider(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FontProvider obj)
		{
			return default(HandleRef);
		}

		protected FontProvider()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual FontSource MatchFont(Uri baseUri, string familyName, ref FontWeight weight, ref FontStretch stretch, ref FontStyle style)
		{
			return default(FontSource);
		}

		public virtual bool FamilyExists(Uri baseUri, string familyName)
		{
			return false;
		}

		public virtual void ScanFolder(Uri folder)
		{
		}

		public virtual Stream OpenFont(Uri folder, string filename)
		{
			return null;
		}

		protected void RegisterFont(Uri folder, string filename)
		{
		}

		public void RaiseFontChanged(Uri baseUri, string familyName, FontWeight weight, FontStretch stretch, FontStyle style)
		{
		}

		[PreserveSig]
		private static extern void Noesis_RaiseFontChanged(HandleRef provider, string baseUri, string familyName, int weight, int stretch, int style);

		private void RegisterFontHelper(string folder, string id)
		{
		}

		private IntPtr MatchFontHelper(string baseUri, string familyName, ref int weight, ref int stretch, ref int style, ref uint index)
		{
			return (IntPtr)0;
		}

		private bool FamilyExistsHelper(string baseUri, string familyName)
		{
			return false;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
