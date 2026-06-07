using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EventTrigger : TriggerBase
	{
		public TriggerActionCollection Actions => null;

		public RoutedEvent RoutedEvent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SourceName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static EventTrigger CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EventTrigger(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EventTrigger obj)
		{
			return default(HandleRef);
		}

		public EventTrigger()
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
