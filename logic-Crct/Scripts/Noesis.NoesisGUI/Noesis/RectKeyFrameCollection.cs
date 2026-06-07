using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RectKeyFrameCollection : FreezableCollection<RectKeyFrame>
	{
		internal new static RectKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RectKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(RectKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public RectKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
