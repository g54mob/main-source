using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BooleanKeyFrameCollection : FreezableCollection<BooleanKeyFrame>
	{
		internal new static BooleanKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BooleanKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(BooleanKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public BooleanKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
