using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Clock : BaseComponent
	{
		public delegate void CompletedHandler(object sender, EventArgs e);

		internal delegate void RaiseCompletedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		private static RaiseCompletedCallback _raiseCompleted;

		internal static Dictionary<long, CompletedHandler> _Completed;

		public int CurrentIteration => 0;

		public float CurrentProgress => 0f;

		public double CurrentTime => 0.0;

		public ClockState CurrentState => default(ClockState);

		public bool HasControllableRoot => false;

		public ClockGroup Parent => null;

		public Timeline Timeline => null;

		public event CompletedHandler Completed
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Clock CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Clock(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Clock obj)
		{
			return default(HandleRef);
		}

		protected Clock()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseCompletedCallback))]
		private static void RaiseCompleted(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}
	}
}
