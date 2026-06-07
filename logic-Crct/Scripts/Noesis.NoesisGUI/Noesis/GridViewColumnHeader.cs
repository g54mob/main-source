using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridViewColumnHeader : ButtonBase
	{
		public static DependencyProperty RoleProperty => null;

		public GridViewColumn Column => null;

		public GridViewColumnHeaderRole Role => default(GridViewColumnHeaderRole);

		internal new static GridViewColumnHeader CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridViewColumnHeader(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridViewColumnHeader obj)
		{
			return default(HandleRef);
		}

		public GridViewColumnHeader()
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
