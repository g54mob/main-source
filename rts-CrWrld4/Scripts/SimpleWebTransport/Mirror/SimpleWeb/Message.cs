using System;

namespace Mirror.SimpleWeb
{
	public struct Message
	{
		public readonly int connId;

		public readonly EventType type;

		public readonly ArrayBuffer data;

		public readonly Exception exception;

		public Message(EventType type)
		{
			connId = 0;
			this.type = default(EventType);
			data = null;
			exception = null;
		}

		public Message(ArrayBuffer data)
		{
			connId = 0;
			type = default(EventType);
			this.data = null;
			exception = null;
		}

		public Message(Exception exception)
		{
			connId = 0;
			type = default(EventType);
			data = null;
			this.exception = null;
		}

		public Message(int connId, EventType type)
		{
			this.connId = 0;
			this.type = default(EventType);
			data = null;
			exception = null;
		}

		public Message(int connId, ArrayBuffer data)
		{
			this.connId = 0;
			type = default(EventType);
			this.data = null;
			exception = null;
		}

		public Message(int connId, Exception exception)
		{
			this.connId = 0;
			type = default(EventType);
			data = null;
			this.exception = null;
		}
	}
}
