using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int16KeyFrameCollection : FreezableCollection<Int16KeyFrame>
	{
		internal new static Int16KeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int16KeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(Int16KeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public Int16KeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
