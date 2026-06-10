using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class StreamQueryResult : IMarshallable
	{
		internal readonly int TypeCode = 1775991607;

		public StreamInfo[] Streams;

		public string PaginationCursor;

		public override int GetHashCode()
		{
			return (13 * 7 + Streams.GetHashCode()) * 7 + PaginationCursor.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			StreamQueryResult streamQueryResult = obj as StreamQueryResult;
			if (streamQueryResult == null)
			{
				return false;
			}
			if (Streams == streamQueryResult.Streams)
			{
				return PaginationCursor == streamQueryResult.PaginationCursor;
			}
			return false;
		}

		public static bool operator ==(StreamQueryResult a, StreamQueryResult b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(StreamQueryResult a, StreamQueryResult b)
		{
			return !(a == b);
		}
	}
}
