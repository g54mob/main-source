using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ImageBrush : TileBrush
	{
		public static DependencyProperty ImageSourceProperty => null;

		public static DependencyProperty ShaderProperty => null;

		public ImageSource ImageSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BrushShader Shader
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ImageBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ImageBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ImageBrush obj)
		{
			return default(HandleRef);
		}

		public ImageBrush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public ImageBrush(ImageSource imageSource)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
