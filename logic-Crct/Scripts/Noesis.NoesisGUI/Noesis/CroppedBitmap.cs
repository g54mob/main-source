using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CroppedBitmap : BitmapSource
	{
		public static DependencyProperty SourceProperty => null;

		public static DependencyProperty SourceRectProperty => null;

		public BitmapSource Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Int32Rect SourceRect
		{
			get
			{
				return default(Int32Rect);
			}
			set
			{
			}
		}

		internal new static CroppedBitmap CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CroppedBitmap(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CroppedBitmap obj)
		{
			return default(HandleRef);
		}

		public CroppedBitmap()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public CroppedBitmap(BitmapSource source, Int32Rect sourceRect)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
