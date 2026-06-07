using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridViewHeaderRowPresenter : GridViewRowPresenterBase
	{
		public static DependencyProperty AllowsColumnReorderProperty => null;

		public static DependencyProperty ColumnHeaderContainerStyleProperty => null;

		public static DependencyProperty ColumnHeaderContextMenuProperty => null;

		public static DependencyProperty ColumnHeaderStringFormatProperty => null;

		public static DependencyProperty ColumnHeaderTemplateProperty => null;

		public static DependencyProperty ColumnHeaderTemplateSelectorProperty => null;

		public static DependencyProperty ColumnHeaderToolTipProperty => null;

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

		internal new static GridViewHeaderRowPresenter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridViewHeaderRowPresenter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridViewHeaderRowPresenter obj)
		{
			return default(HandleRef);
		}

		public GridViewHeaderRowPresenter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
