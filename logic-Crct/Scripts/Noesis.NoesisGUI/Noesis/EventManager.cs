using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public static class EventManager
	{
		private delegate void ClassHandlerCallback(IntPtr cPtrType, IntPtr cPtr, IntPtr sender, IntPtr args);

		private class ClassHandlerInfo
		{
			public IntPtr RoutedEvent;

			public Delegate Handler;
		}

		private delegate void InvokeHandlerDelegate(Delegate handler, IntPtr sender, IntPtr args);

		private struct HandlerInfo
		{
			public Type Type { get; set; }

			public InvokeHandlerDelegate Invoker { get; set; }
		}

		private static ClassHandlerCallback _classHandler;

		private static List<ClassHandlerInfo> _classHandlers;

		private static Dictionary<long, HandlerInfo> _handlerTypes;

		public static RoutedEvent RegisterRoutedEvent(string name, RoutingStrategy routingStrategy, Type handlerType, Type ownerType)
		{
			return null;
		}

		public static void RegisterClassHandler(Type classType, RoutedEvent routedEvent, Delegate handler)
		{
		}

		public static void RegisterClassHandler(Type classType, RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
		{
		}

		internal static bool IsLegalHandler(IntPtr routedEventPtr, Delegate handler)
		{
			return false;
		}

		internal static void InvokeHandler(IntPtr routedEventPtr, Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		[MonoPInvokeCallback(typeof(ClassHandlerCallback))]
		private static void OnClassHandler(IntPtr cPtrType, IntPtr cPtr, IntPtr sender, IntPtr args)
		{
		}

		private static ClassHandlerInfo AddClassHandler(IntPtr routedEventPtr, Delegate handler)
		{
			return null;
		}

		internal static bool IsLegalHandler(string eventId, Delegate handler)
		{
			return false;
		}

		internal static void InvokeHandler(string eventId, Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		static EventManager()
		{
		}

		private static RoutedEvent AddRoutedEvent(string name, RoutingStrategy routingStrategy, Type handlerType, Type ownerType)
		{
			return null;
		}

		private static InvokeHandlerDelegate GetInvoker(Type handlerType)
		{
			return null;
		}

		private static void RegisterRoutedEvent(RoutedEvent routedEvent, Type handlerType, InvokeHandlerDelegate invoker)
		{
		}

		private static void RegisterCLREvent(string eventId, Type handlerType, InvokeHandlerDelegate invoker)
		{
		}

		private static long Key(RoutedEvent routedEvent)
		{
			return 0L;
		}

		private static long Key(IntPtr routedEvent)
		{
			return 0L;
		}

		private static long Key(string eventId)
		{
			return 0L;
		}

		[PreserveSig]
		private static extern IntPtr Noesis_EventManager_RegisterRoutedEvent(string name, int routingStrategy, IntPtr ownerType);

		[PreserveSig]
		private static extern void Noesis_EventManager_RegisterClassHandler(IntPtr classType, IntPtr routedEvent, bool handledEventsToo, IntPtr info, ClassHandlerCallback callback);
	}
}
