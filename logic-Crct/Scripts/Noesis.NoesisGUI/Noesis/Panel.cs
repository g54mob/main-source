using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Panel : FrameworkElement
	{
		public static DependencyProperty BackgroundProperty => null;

		public static DependencyProperty IsItemsHostProperty => null;

		public static DependencyProperty ZIndexProperty => null;

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

		public bool IsItemsHost
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UIElementCollection Children => null;

		internal new static Panel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Panel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Panel obj)
		{
			return default(HandleRef);
		}

		protected Panel()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static int GetZIndex(DependencyObject element)
		{
			return 0;
		}

		public static void SetZIndex(DependencyObject element, int value)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
