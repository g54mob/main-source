using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Button : ButtonBase
	{
		public static DependencyProperty IsCancelProperty => null;

		public static DependencyProperty IsDefaultProperty => null;

		public static DependencyProperty IsDefaultedProperty => null;

		public bool IsCancel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsDefault
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsDefaulted => false;

		internal new static Button CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Button(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Button obj)
		{
			return default(HandleRef);
		}

		public Button()
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
