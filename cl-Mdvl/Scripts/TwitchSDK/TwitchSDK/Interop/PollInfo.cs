using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PollInfo : IMarshallable
	{
		internal readonly int TypeCode = 41019527;

		public string Id;

		public string BroadcasterId;

		public string Title;

		public PollChoiceInfo[] Choices;

		public bool ChannelPointsVotingEnabled;

		public int ChannelPointsPerVote;

		public PollStatus Status;

		public string StartedAt;

		public string EndedAt;

		public override int GetHashCode()
		{
			return ((((((((13 * 7 + Id.GetHashCode()) * 7 + BroadcasterId.GetHashCode()) * 7 + Title.GetHashCode()) * 7 + Choices.GetHashCode()) * 7 + ChannelPointsVotingEnabled.GetHashCode()) * 7 + ChannelPointsPerVote.GetHashCode()) * 7 + Status.GetHashCode()) * 7 + StartedAt.GetHashCode()) * 7 + EndedAt.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PollInfo pollInfo = obj as PollInfo;
			if (pollInfo == null)
			{
				return false;
			}
			if (Id == pollInfo.Id && BroadcasterId == pollInfo.BroadcasterId && Title == pollInfo.Title && Choices == pollInfo.Choices && ChannelPointsVotingEnabled == pollInfo.ChannelPointsVotingEnabled && ChannelPointsPerVote == pollInfo.ChannelPointsPerVote && Status == pollInfo.Status && StartedAt == pollInfo.StartedAt)
			{
				return EndedAt == pollInfo.EndedAt;
			}
			return false;
		}

		public static bool operator ==(PollInfo a, PollInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PollInfo a, PollInfo b)
		{
			return !(a == b);
		}
	}
}
