using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ThicknessKeyFrameCollection : FreezableCollection<ThicknessKeyFrame>
	{
		internal new static ThicknessKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ThicknessKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ThicknessKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public ThicknessKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
