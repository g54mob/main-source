using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GeometryCollection : FreezableCollection<Geometry>
	{
		internal new static GeometryCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GeometryCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(GeometryCollection obj)
		{
			return default(HandleRef);
		}

		public GeometryCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
