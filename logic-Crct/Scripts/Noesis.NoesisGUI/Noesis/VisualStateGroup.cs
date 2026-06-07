using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualStateGroup : DependencyObject
	{
		public delegate void CurrentStateChangingHandler(object sender, VisualStateChangedEventArgs e);

		internal delegate void RaiseCurrentStateChangingCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		public delegate void CurrentStateChangedHandler(object sender, VisualStateChangedEventArgs e);

		internal delegate void RaiseCurrentStateChangedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		private static RaiseCurrentStateChangingCallback _raiseCurrentStateChanging;

		internal static Dictionary<long, CurrentStateChangingHandler> _CurrentStateChanging;

		private static RaiseCurrentStateChangedCallback _raiseCurrentStateChanged;

		internal static Dictionary<long, CurrentStateChangedHandler> _CurrentStateChanged;

		public string Name => null;

		public VisualStateCollection States => null;

		public VisualTransitionCollection Transitions => null;

		public event CurrentStateChangingHandler CurrentStateChanging
		{
			add
			{
			}
			remove
			{
			}
		}

		public event CurrentStateChangedHandler CurrentStateChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static VisualStateGroup CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualStateGroup(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VisualStateGroup obj)
		{
			return default(HandleRef);
		}

		[MonoPInvokeCallback(typeof(RaiseCurrentStateChangingCallback))]
		private static void RaiseCurrentStateChanging(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseCurrentStateChangedCallback))]
		private static void RaiseCurrentStateChanged(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		public VisualStateGroup()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public VisualState GetCurrentState(FrameworkElement fe)
		{
			return null;
		}

		public void SetCurrentState(FrameworkElement fe, VisualState state)
		{
		}

		public VisualState FindState(string name)
		{
			return null;
		}

		public VisualTransition FindTransition(VisualState from, VisualState to)
		{
			return null;
		}

		public void UpdateAnimations(FrameworkElement fe, Storyboard storyboard1, Storyboard storyboard2)
		{
		}

		public void UpdateAnimations(FrameworkElement fe, Storyboard storyboard1)
		{
		}
	}
}
