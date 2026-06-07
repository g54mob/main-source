using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridView : ViewBase
	{
		public static DependencyProperty AllowsColumnReorderProperty => null;

		public static DependencyProperty ColumnHeaderContainerStyleProperty => null;

		public static DependencyProperty ColumnHeaderContextMenuProperty => null;

		public static DependencyProperty ColumnHeaderStringFormatProperty => null;

		public static DependencyProperty ColumnHeaderTemplateProperty => null;

		public static DependencyProperty ColumnHeaderTemplateSelectorProperty => null;

		public static DependencyProperty ColumnHeaderToolTipProperty => null;

		public static DependencyProperty ColumnCollectionProperty => null;

		public bool AllowsColumnReorder
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Style ColumnHeaderContainerStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ContextMenu ColumnHeaderContextMenu
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ColumnHeaderStringFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplate ColumnHeaderTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector ColumnHeaderTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object ColumnHeaderToolTip
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GridViewColumnCollection Columns => null;

		internal new static GridView CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridView(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridView obj)
		{
			return default(HandleRef);
		}

		public GridView()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static GridViewColumnCollection GetColumnCollection(DependencyObject element)
		{
			return null;
		}

		public static void SetColumnCollection(DependencyObject element, GridViewColumnCollection value)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
