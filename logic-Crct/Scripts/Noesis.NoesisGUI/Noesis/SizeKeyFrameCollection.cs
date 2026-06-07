using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SizeKeyFrameCollection : FreezableCollection<SizeKeyFrame>
	{
		internal new static SizeKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SizeKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(SizeKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public SizeKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
