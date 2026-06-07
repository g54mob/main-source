using Coherence.Brook;

namespace Coherence.Transport
{
	public struct SessionID
	{
		public static readonly SessionID None;

		public const int Size = 2;

		public readonly ushort Value;

		public SessionID(ushort value)
		{
			Value = 0;
		}

		public static SessionID Read(IInOctetStream stream)
		{
			return default(SessionID);
		}

		public static void Write(in SessionID sessionID, IOutOctetStream stream)
		{
		}

		public static bool operator ==(SessionID l, SessionID r)
		{
			return false;
		}

		public static bool operator !=(SessionID l, SessionID r)
		{
			return false;
		}

		public static implicit operator ushort(SessionID id)
		{
			return 0;
		}

		public static implicit operator SessionID(ushort value)
		{
			return default(SessionID);
		}

		public bool Equals(SessionID other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
