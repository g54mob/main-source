using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualStateManager : DependencyObject
	{
		public static DependencyProperty CustomVisualStateManagerProperty => null;

		public static DependencyProperty VisualStateGroupsProperty => null;

		internal new static VisualStateManager CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualStateManager(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VisualStateManager obj)
		{
			return default(HandleRef);
		}

		public VisualStateManager()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static VisualStateManager GetCustomVisualStateManager(DependencyObject obj)
		{
			return null;
		}

		public static void SetCustomVisualStateManager(DependencyObject obj, VisualStateManager value)
		{
		}

		public static VisualStateGroupCollection GetVisualStateGroups(DependencyObject obj)
		{
			return null;
		}

		public static void SetVisualStateGroups(DependencyObject obj, VisualStateGroupCollection groups)
		{
		}

		public static bool GoToState(FrameworkElement control, string stateName, bool useTransitions)
		{
			return false;
		}

		public static bool GoToElementState(FrameworkElement root, string stateName, bool useTransitions)
		{
			return false;
		}
	}
}
