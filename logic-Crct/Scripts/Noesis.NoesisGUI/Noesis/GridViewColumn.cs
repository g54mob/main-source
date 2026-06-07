using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridViewColumn : Animatable
	{
		public static DependencyProperty CellTemplateProperty => null;

		public static DependencyProperty CellTemplateSelectorProperty => null;

		public static DependencyProperty HeaderProperty => null;

		public static DependencyProperty HeaderContainerStyleProperty => null;

		public static DependencyProperty HeaderStringFormatProperty => null;

		public static DependencyProperty HeaderTemplateProperty => null;

		public static DependencyProperty HeaderTemplateSelectorProperty => null;

		public static DependencyProperty WidthProperty => null;

		public float ActualWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public DataTemplate CellTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector CellTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BindingExpressionBase DisplayMemberBinding
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Header
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Style HeaderContainerStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string HeaderStringFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplate HeaderTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataTemplateSelector HeaderTemplateSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static GridViewColumn CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridViewColumn(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridViewColumn obj)
		{
			return default(HandleRef);
		}

		public GridViewColumn()
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
