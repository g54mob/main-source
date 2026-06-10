using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class EndPollRequest : IMarshallable
	{
		internal readonly int TypeCode = -1225210291;

		public string BroadcasterId;

		public string PollId;

		public bool ShowResults;

		public override int GetHashCode()
		{
			return ((13 * 7 + BroadcasterId.GetHashCode()) * 7 + PollId.GetHashCode()) * 7 + ShowResults.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			EndPollRequest endPollRequest = obj as EndPollRequest;
			if (endPollRequest == null)
			{
				return false;
			}
			if (BroadcasterId == endPollRequest.BroadcasterId && PollId == endPollRequest.PollId)
			{
				return ShowResults == endPollRequest.ShowResults;
			}
			return false;
		}

		public static bool operator ==(EndPollRequest a, EndPollRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(EndPollRequest a, EndPollRequest b)
		{
			return !(a == b);
		}
	}
}
