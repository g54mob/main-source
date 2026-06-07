using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RoutedEvent : BaseComponent
	{
		public string Name => null;

		public Type OwnerType => null;

		public RoutingStrategy RoutingStrategy => default(RoutingStrategy);

		internal new static RoutedEvent CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RoutedEvent(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RoutedEvent obj)
		{
			return default(HandleRef);
		}

		protected RoutedEvent()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RoutedEvent(string name, Type ownerType, RoutingStrategy routingStrategy)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
