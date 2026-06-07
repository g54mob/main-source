using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DoubleKeyFrameCollection : FreezableCollection<DoubleKeyFrame>
	{
		internal new static DoubleKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DoubleKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(DoubleKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public DoubleKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
