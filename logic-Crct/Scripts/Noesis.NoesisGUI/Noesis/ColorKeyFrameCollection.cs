using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ColorKeyFrameCollection : FreezableCollection<ColorKeyFrame>
	{
		internal new static ColorKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ColorKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ColorKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public ColorKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
