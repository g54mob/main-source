using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TimelineCollection : FreezableCollection<Timeline>
	{
		internal new static TimelineCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TimelineCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(TimelineCollection obj)
		{
			return default(HandleRef);
		}

		public TimelineCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
