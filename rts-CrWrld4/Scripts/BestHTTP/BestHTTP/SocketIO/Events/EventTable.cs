using System.Collections.Generic;

namespace BestHTTP.SocketIO.Events
{
	internal sealed class EventTable
	{
		private Dictionary<string, List<EventDescriptor>> Table;

		private Socket Socket { get; set; }

		public EventTable(Socket socket)
		{
		}

		public void Register(string eventName, SocketIOCallback callback, bool onlyOnce, bool autoDecodePayload)
		{
		}

		public void Unregister(string eventName)
		{
		}

		public void Unregister(string eventName, SocketIOCallback callback)
		{
		}

		public void Call(string eventName, Packet packet, params object[] args)
		{
		}

		public void Call(Packet packet)
		{
		}

		public void Clear()
		{
		}

		private bool ShouldDecodePayload(string eventName)
		{
			return false;
		}

		private bool HasSubsciber(string eventName)
		{
			return false;
		}
	}
}
