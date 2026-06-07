using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridViewRowPresenterBase : FrameworkElement
	{
		public static DependencyProperty ColumnsProperty => null;

		public GridViewColumnCollection Columns
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static GridViewRowPresenterBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridViewRowPresenterBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridViewRowPresenterBase obj)
		{
			return default(HandleRef);
		}

		public GridViewRowPresenterBase()
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
