using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int64KeyFrameCollection : FreezableCollection<Int64KeyFrame>
	{
		internal new static Int64KeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int64KeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(Int64KeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public Int64KeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
