using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Grid : Panel
	{
		public static DependencyProperty ColumnProperty => null;

		public static DependencyProperty ColumnSpanProperty => null;

		public static DependencyProperty IsSharedSizeScopeProperty => null;

		public static DependencyProperty RowProperty => null;

		public static DependencyProperty RowSpanProperty => null;

		public ColumnDefinitionCollection ColumnDefinitions => null;

		public RowDefinitionCollection RowDefinitions => null;

		internal new static Grid CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Grid(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Grid obj)
		{
			return default(HandleRef);
		}

		public Grid()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static int GetColumn(DependencyObject element)
		{
			return 0;
		}

		public static void SetColumn(DependencyObject element, int column)
		{
		}

		public static int GetColumnSpan(DependencyObject element)
		{
			return 0;
		}

		public static void SetColumnSpan(DependencyObject element, int columnSpan)
		{
		}

		public static bool GetIsSharedSizeScope(DependencyObject element)
		{
			return false;
		}

		public static void SetIsSharedSizeScope(DependencyObject element, bool value)
		{
		}

		public static int GetRow(DependencyObject element)
		{
			return 0;
		}

		public static void SetRow(DependencyObject element, int row)
		{
		}

		public static int GetRowSpan(DependencyObject element)
		{
			return 0;
		}

		public static void SetRowSpan(DependencyObject element, int rowSpan)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
