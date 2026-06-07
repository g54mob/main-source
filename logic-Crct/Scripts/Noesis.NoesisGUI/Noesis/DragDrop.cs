using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public static class DragDrop
	{
		private delegate void Callback_DragDropCompleted(int callbackId, IntPtr sourcePtr, IntPtr dataPtr, IntPtr targetPtr, IntPtr dropPointPtr, int effects);

		private static Callback_DragDropCompleted _dragDropCompleted;

		private static int CallbackId;

		private static Dictionary<int, DragDropCompletedCallback> _callbacks;

		public static RoutedEvent PreviewQueryContinueDragEvent => null;

		public static RoutedEvent QueryContinueDragEvent => null;

		public static RoutedEvent PreviewGiveFeedbackEvent => null;

		public static RoutedEvent GiveFeedbackEvent => null;

		public static RoutedEvent PreviewDragEnterEvent => null;

		public static RoutedEvent DragEnterEvent => null;

		public static RoutedEvent PreviewDragOverEvent => null;

		public static RoutedEvent DragOverEvent => null;

		public static RoutedEvent PreviewDragLeaveEvent => null;

		public static RoutedEvent DragLeaveEvent => null;

		public static RoutedEvent PreviewDropEvent => null;

		public static RoutedEvent DropEvent => null;

		public static void DoDragDrop(DependencyObject dragSource, object data, DragDropEffects allowedEffects, DragDropCompletedCallback onDragDropCompleted = null)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_DragDropCompleted))]
		private static void OnDragDropCompleted(int callbackId, IntPtr sourcePtr, IntPtr dataPtr, IntPtr targetPtr, IntPtr dropPointPtr, int effects)
		{
		}

		private static void DoDragDropHelper(DependencyObject source, object data, DragDropEffects allowedEffects, int callbackId, Callback_DragDropCompleted callback)
		{
		}

		[PreserveSig]
		private static extern void DragDrop_DoDragDrop(HandleRef source, HandleRef data, int allowedEffects, int callbackId, Callback_DragDropCompleted callback);
	}
}
