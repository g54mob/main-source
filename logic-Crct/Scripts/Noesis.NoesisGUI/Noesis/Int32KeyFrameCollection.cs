using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int32KeyFrameCollection : FreezableCollection<Int32KeyFrame>
	{
		internal new static Int32KeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int32KeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(Int32KeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public Int32KeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
