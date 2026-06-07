using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Storyboard : ParallelTimeline
	{
		public static DependencyProperty TargetNameProperty => null;

		public static DependencyProperty TargetProperty => null;

		public static DependencyProperty TargetPropertyProperty => null;

		internal new static Storyboard CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Storyboard(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Storyboard obj)
		{
			return default(HandleRef);
		}

		public Storyboard()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static string GetTargetName(DependencyObject element)
		{
			return null;
		}

		public static void SetTargetName(DependencyObject element, string name)
		{
		}

		public static PropertyPath GetTargetProperty(DependencyObject element)
		{
			return null;
		}

		public static void SetTargetProperty(DependencyObject element, PropertyPath path)
		{
		}

		public static DependencyObject GetTarget(DependencyObject element)
		{
			return null;
		}

		public static void SetTarget(DependencyObject element, DependencyObject target)
		{
		}

		public void Begin()
		{
		}

		public void Begin(FrameworkElement target)
		{
		}

		public void Begin(FrameworkElement target, bool isControllable)
		{
		}

		public void Begin(FrameworkElement target, HandoffBehavior handoffBehavior)
		{
		}

		public void Begin(FrameworkElement target, HandoffBehavior handoffBehavior, bool isControllable)
		{
		}

		public void Begin(FrameworkElement target, FrameworkElement nameScope)
		{
		}

		public void Begin(FrameworkElement target, FrameworkElement nameScope, bool isControllable)
		{
		}

		public void Begin(FrameworkElement target, FrameworkElement nameScope, HandoffBehavior handoffBehavior)
		{
		}

		public void Begin(FrameworkElement target, FrameworkElement nameScope, HandoffBehavior handoffBehavior, bool isControllable)
		{
		}

		public void Seek(TimeSpan offset)
		{
		}

		public void Seek(TimeSpan offset, TimeSeekOrigin origin)
		{
		}

		public void Seek(FrameworkElement target, TimeSpan offset, TimeSeekOrigin origin)
		{
		}

		public void Pause()
		{
		}

		public void Pause(FrameworkElement target)
		{
		}

		public void Resume()
		{
		}

		public void Resume(FrameworkElement target)
		{
		}

		public void Stop()
		{
		}

		public void Stop(FrameworkElement target)
		{
		}

		public void Remove()
		{
		}

		public void Remove(FrameworkElement target)
		{
		}

		public bool IsPlaying()
		{
			return false;
		}

		public bool IsPlaying(FrameworkElement target)
		{
			return false;
		}

		public bool IsPaused()
		{
			return false;
		}

		public bool IsPaused(FrameworkElement target)
		{
			return false;
		}
	}
}
