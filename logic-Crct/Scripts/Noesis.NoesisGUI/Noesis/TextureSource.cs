using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Noesis
{
	public class TextureSource : BitmapSource
	{
		public Texture Texture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static TextureSource CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TextureSource(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextureSource obj)
		{
			return default(HandleRef);
		}

		public TextureSource()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public TextureSource(Texture texture)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		public TextureSource(UnityEngine.Texture texture)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public TextureSource(Texture2D texture)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static void SetTexture(IntPtr cPtr, UnityEngine.Texture tex)
		{
		}

		[PreserveSig]
		private static extern void Noesis_TextureSource_SetTexture(IntPtr cPtr, IntPtr texture, int width, int height, int numLevels);
	}
}
