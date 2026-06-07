using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridViewColumnCollection : FreezableCollection<GridViewColumn>
	{
		internal new static GridViewColumnCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridViewColumnCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(GridViewColumnCollection obj)
		{
			return default(HandleRef);
		}

		public GridViewColumnCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
