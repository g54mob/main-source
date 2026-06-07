using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ControllableStoryboardAction : TriggerAction
	{
		public string BeginStoryboardName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ControllableStoryboardAction CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ControllableStoryboardAction(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ControllableStoryboardAction obj)
		{
			return default(HandleRef);
		}

		protected ControllableStoryboardAction()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
