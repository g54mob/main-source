using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PathSegmentCollection : FreezableCollection<PathSegment>
	{
		internal new static PathSegmentCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PathSegmentCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(PathSegmentCollection obj)
		{
			return default(HandleRef);
		}

		public PathSegmentCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
