using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PointCollection : BoxedFreezableCollection<Point>
	{
		internal new static PointCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PointCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(PointCollection obj)
		{
			return default(HandleRef);
		}

		public PointCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
