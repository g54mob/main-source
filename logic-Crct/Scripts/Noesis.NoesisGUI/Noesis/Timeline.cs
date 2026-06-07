using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Timeline : Animatable
	{
		public delegate void CompletedHandler(object sender, EventArgs e);

		internal delegate void RaiseCompletedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		private static RaiseCompletedCallback _raiseCompleted;

		internal static Dictionary<long, CompletedHandler> _Completed;

		public static DependencyProperty AccelerationRatioProperty => null;

		public static DependencyProperty AutoReverseProperty => null;

		public static DependencyProperty BeginTimeProperty => null;

		public static DependencyProperty DecelerationRatioProperty => null;

		public static DependencyProperty DesiredFrameRateProperty => null;

		public static DependencyProperty DurationProperty => null;

		public static DependencyProperty FillBehaviorProperty => null;

		public static DependencyProperty NameProperty => null;

		public static DependencyProperty RepeatBehaviorProperty => null;

		public static DependencyProperty SpeedRatioProperty => null;

		public float AccelerationRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool AutoReverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TimeSpan? BeginTime
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float DecelerationRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Duration Duration
		{
			get
			{
				return default(Duration);
			}
			set
			{
			}
		}

		public FillBehavior FillBehavior
		{
			get
			{
				return default(FillBehavior);
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RepeatBehavior RepeatBehavior
		{
			get
			{
				return default(RepeatBehavior);
			}
			set
			{
			}
		}

		public float SpeedRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event CompletedHandler Completed
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Timeline CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Timeline(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Timeline obj)
		{
			return default(HandleRef);
		}

		protected Timeline()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseCompletedCallback))]
		private static void RaiseCompleted(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		public static int GetDesiredFrameRate(DependencyObject timeline)
		{
			return 0;
		}

		public static void SetDesiredFrameRate(DependencyObject timeline, int rate)
		{
		}
	}
}
