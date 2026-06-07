using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ToolBar : HeaderedItemsControl
	{
		public static DependencyProperty BandIndexProperty => null;

		public static DependencyProperty BandProperty => null;

		public static DependencyProperty HasOverflowItemsProperty => null;

		public static DependencyProperty IsOverflowItemProperty => null;

		public static DependencyProperty IsOverflowOpenProperty => null;

		public static DependencyProperty OrientationProperty => null;

		public static DependencyProperty OverflowModeProperty => null;

		public static DependencyProperty ButtonStyleKey => null;

		public static DependencyProperty ToggleButtonStyleKey => null;

		public static DependencyProperty CheckBoxStyleKey => null;

		public static DependencyProperty RadioButtonStyleKey => null;

		public static DependencyProperty TextBoxStyleKey => null;

		public static DependencyProperty ComboBoxStyleKey => null;

		public static DependencyProperty SeparatorStyleKey => null;

		public static DependencyProperty MenuStyleKey => null;

		public int Band
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int BandIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool HasOverflowItems => false;

		public bool IsOverflowOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Orientation Orientation => default(Orientation);

		internal new static ToolBar CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ToolBar(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ToolBar obj)
		{
			return default(HandleRef);
		}

		public ToolBar()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static OverflowMode GetOverflowMode(DependencyObject element)
		{
			return default(OverflowMode);
		}

		public static void SetOverflowMode(DependencyObject element, OverflowMode mode)
		{
		}

		public static bool GetIsOverflowItem(DependencyObject element)
		{
			return false;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
