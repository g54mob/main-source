using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public static class VisualTreeHelper
	{
		private delegate HitTestFilterBehavior Callback_HitTestFilter(int callbacksId, IntPtr targetPtr);

		private delegate HitTestResultBehavior Callback_HitTestResult(int callbacksId, IntPtr hitPtr);

		private struct HitTestCallbackInfo
		{
			public HitTestFilterCallback Filter { get; set; }

			public HitTestResultCallback Result { get; set; }
		}

		private static Callback_HitTestFilter _hitTestFilter;

		private static Callback_HitTestResult _hitTestResult;

		private static Dictionary<int, HitTestCallbackInfo> _hitTestCallbacks;

		public static DependencyObject GetRoot(DependencyObject reference)
		{
			return null;
		}

		public static DependencyObject GetParent(DependencyObject reference)
		{
			return null;
		}

		public static int GetChildrenCount(DependencyObject reference)
		{
			return 0;
		}

		public static DependencyObject GetChild(DependencyObject reference, int childIndex)
		{
			return null;
		}

		public static HitTestResult HitTest(Visual reference, Point point)
		{
			return null;
		}

		public static void HitTest(Visual reference, HitTestFilterCallback filterCallback, HitTestResultCallback resultCallback, HitTestParameters hitTestParameters)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_HitTestFilter))]
		private static HitTestFilterBehavior OnHitTestFilter(int callbacksId, IntPtr targetPtr)
		{
			return default(HitTestFilterBehavior);
		}

		[MonoPInvokeCallback(typeof(Callback_HitTestResult))]
		private static HitTestResultBehavior OnHitTestResult(int callbacksId, IntPtr hitPtr)
		{
			return default(HitTestResultBehavior);
		}

		private static void HitTestCallbackHelper(Visual reference, Point point, int callbacksId, Callback_HitTestFilter filter, Callback_HitTestResult result)
		{
		}

		[PreserveSig]
		private static extern void VisualTreeHelper_HitTestCallback(HandleRef reference, ref Point point, int callbacksId, Callback_HitTestFilter filter, Callback_HitTestResult result);

		public static Rect GetContentBounds(Visual visual)
		{
			return default(Rect);
		}

		public static Rect GetDescendantBounds(Visual visual)
		{
			return default(Rect);
		}

		public static float GetDescendantBoundsMinZ(Visual visual)
		{
			return 0f;
		}

		public static float GetDescendantBoundsMaxZ(Visual visual)
		{
			return 0f;
		}

		public static Point GetOffset(Visual visual)
		{
			return default(Point);
		}

		public static Size GetSize(Visual visual)
		{
			return default(Size);
		}

		public static Geometry GetClip(Visual visual)
		{
			return null;
		}

		private static DependencyObject GetRootHelper(DependencyObject reference)
		{
			return null;
		}

		private static DependencyObject GetParentHelper(DependencyObject reference)
		{
			return null;
		}

		private static int GetChildrenCountHelper(DependencyObject reference)
		{
			return 0;
		}

		private static DependencyObject GetChildHelper(DependencyObject reference, int childIndex)
		{
			return null;
		}

		private static HitTestResult HitTestHelper(Visual reference, Point point)
		{
			return null;
		}
	}
}
