using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteBooleanKeyFrame : BooleanKeyFrame
	{
		internal new static DiscreteBooleanKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteBooleanKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteBooleanKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteBooleanKeyFrame()
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
