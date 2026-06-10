using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class EventStreamDesc : IMarshallable
	{
		internal readonly int TypeCode = 853853815;

		public EventStreamKind Kind;

		public int Token;

		public override int GetHashCode()
		{
			return (13 * 7 + Kind.GetHashCode()) * 7 + Token.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			EventStreamDesc eventStreamDesc = obj as EventStreamDesc;
			if (eventStreamDesc == null)
			{
				return false;
			}
			if (Kind == eventStreamDesc.Kind)
			{
				return Token == eventStreamDesc.Token;
			}
			return false;
		}

		public static bool operator ==(EventStreamDesc a, EventStreamDesc b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(EventStreamDesc a, EventStreamDesc b)
		{
			return !(a == b);
		}
	}
}
