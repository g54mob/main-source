using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Image : FrameworkElement
	{
		public static DependencyProperty SourceProperty => null;

		public static DependencyProperty StretchProperty => null;

		public static DependencyProperty StretchDirectionProperty => null;

		public ImageSource Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Stretch Stretch
		{
			get
			{
				return default(Stretch);
			}
			set
			{
			}
		}

		public StretchDirection StretchDirection
		{
			get
			{
				return default(StretchDirection);
			}
			set
			{
			}
		}

		internal new static Image CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Image(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Image obj)
		{
			return default(HandleRef);
		}

		public Image()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
