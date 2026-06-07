using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridViewRowPresenter : GridViewRowPresenterBase
	{
		public static DependencyProperty ContentProperty => null;

		public object Content
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static GridViewRowPresenter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridViewRowPresenter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridViewRowPresenter obj)
		{
			return default(HandleRef);
		}

		public GridViewRowPresenter()
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
