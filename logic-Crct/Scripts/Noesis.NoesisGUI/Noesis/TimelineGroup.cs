using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TimelineGroup : Timeline
	{
		public static DependencyProperty ChildrenProperty => null;

		public TimelineCollection Children
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static TimelineGroup CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TimelineGroup(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TimelineGroup obj)
		{
			return default(HandleRef);
		}

		protected TimelineGroup()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
