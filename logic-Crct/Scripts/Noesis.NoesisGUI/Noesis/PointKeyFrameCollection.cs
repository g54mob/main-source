using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PointKeyFrameCollection : FreezableCollection<PointKeyFrame>
	{
		internal new static PointKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PointKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(PointKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public PointKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
