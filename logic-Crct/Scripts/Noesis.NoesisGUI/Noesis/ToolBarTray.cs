using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ToolBarTray : FrameworkElement
	{
		public static DependencyProperty BackgroundProperty => null;

		public static DependencyProperty IsLockedProperty => null;

		public static DependencyProperty OrientationProperty => null;

		public Brush Background
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Orientation Orientation
		{
			get
			{
				return default(Orientation);
			}
			set
			{
			}
		}

		internal new static ToolBarTray CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ToolBarTray(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ToolBarTray obj)
		{
			return default(HandleRef);
		}

		public ToolBarTray()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static bool GetIsLocked(DependencyObject element)
		{
			return false;
		}

		public static void SetIsLocked(DependencyObject element, bool isLocked)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
