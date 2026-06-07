using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteSizeKeyFrame : SizeKeyFrame
	{
		internal new static DiscreteSizeKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteSizeKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteSizeKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteSizeKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
