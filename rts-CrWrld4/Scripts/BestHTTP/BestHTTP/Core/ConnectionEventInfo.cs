using BestHTTP.Connections;

namespace BestHTTP.Core
{
	public readonly struct ConnectionEventInfo
	{
		public readonly ConnectionBase Source;

		public readonly ConnectionEvents Event;

		public readonly HTTPConnectionStates State;

		public readonly HostProtocolSupport ProtocolSupport;

		public readonly HTTPRequest Request;

		public ConnectionEventInfo(ConnectionBase sourceConn, ConnectionEvents @event)
		{
			Source = null;
			Event = default(ConnectionEvents);
			State = default(HTTPConnectionStates);
			ProtocolSupport = default(HostProtocolSupport);
			Request = null;
		}

		public ConnectionEventInfo(ConnectionBase sourceConn, HTTPConnectionStates newState)
		{
			Source = null;
			Event = default(ConnectionEvents);
			State = default(HTTPConnectionStates);
			ProtocolSupport = default(HostProtocolSupport);
			Request = null;
		}

		public ConnectionEventInfo(ConnectionBase sourceConn, HostProtocolSupport protocolSupport)
		{
			Source = null;
			Event = default(ConnectionEvents);
			State = default(HTTPConnectionStates);
			ProtocolSupport = default(HostProtocolSupport);
			Request = null;
		}

		public ConnectionEventInfo(ConnectionBase sourceConn, HTTPRequest request)
		{
			Source = null;
			Event = default(ConnectionEvents);
			State = default(HTTPConnectionStates);
			ProtocolSupport = default(HostProtocolSupport);
			Request = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
