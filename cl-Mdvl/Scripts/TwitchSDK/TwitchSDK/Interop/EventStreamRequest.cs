using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class EventStreamRequest : IMarshallable
	{
		internal readonly int TypeCode = 973764268;

		public EventStreamKind Kind;

		public override int GetHashCode()
		{
			return 13 * 7 + Kind.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			EventStreamRequest eventStreamRequest = obj as EventStreamRequest;
			if (eventStreamRequest == null)
			{
				return false;
			}
			return Kind == eventStreamRequest.Kind;
		}

		public static bool operator ==(EventStreamRequest a, EventStreamRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(EventStreamRequest a, EventStreamRequest b)
		{
			return !(a == b);
		}
	}
}
