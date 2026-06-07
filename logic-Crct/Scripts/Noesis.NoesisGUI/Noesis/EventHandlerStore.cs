using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class EventHandlerStore
	{
		internal delegate void RaiseRoutedEventCallback(IntPtr cPtrType, IntPtr cPtr, IntPtr routedEvent, IntPtr sender, IntPtr e);

		internal delegate void RaiseEventCallback(IntPtr cPtrType, IntPtr cPtr, string eventId, IntPtr sender, IntPtr e);

		private static RaiseRoutedEventCallback _raiseRoutedEvent;

		private static RaiseEventCallback _raiseEvent;

		private static Dictionary<long, EventHandlerStore> _elements;

		private IntPtr _element;

		private Dictionary<long, Delegate> _binds;

		public UIElement Element => null;

		public static void AddHandler(UIElement element, IntPtr routedEventPtr, Delegate handler)
		{
		}

		public static void RemoveHandler(UIElement element, IntPtr routedEventPtr, Delegate handler)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseRoutedEventCallback))]
		private static void RaiseRoutedEvent(IntPtr cPtrType, IntPtr cPtr, IntPtr routedEvent, IntPtr sender, IntPtr e)
		{
		}

		public static void AddHandler(UIElement element, string eventId, Delegate handler)
		{
		}

		public static void RemoveHandler(UIElement element, string eventId, Delegate handler)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseEventCallback))]
		private static void RaiseEvent(IntPtr cPtrType, IntPtr cPtr, string eventId, IntPtr sender, IntPtr e)
		{
		}

		private EventHandlerStore(UIElement element)
		{
		}

		internal static void Clear()
		{
		}

		private static void OnElementDestroyed(IntPtr d)
		{
		}

		[PreserveSig]
		private static extern void Noesis_RoutedEvent_Bind(RaiseRoutedEventCallback callback, IntPtr element, IntPtr routedEvent);

		[PreserveSig]
		private static extern void Noesis_RoutedEvent_Unbind(RaiseRoutedEventCallback callback, IntPtr element, IntPtr routedEvent);

		[PreserveSig]
		private static extern void Noesis_Event_Bind(RaiseEventCallback callback, IntPtr element, string eventId);

		[PreserveSig]
		private static extern void Noesis_Event_Unbind(RaiseEventCallback callback, IntPtr element, string eventId);
	}
}
