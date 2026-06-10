using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PollChoiceInfo : IMarshallable
	{
		internal readonly int TypeCode = 1335005312;

		public string Id;

		public string Title;

		public long Votes;

		public long ChannelPointsVotes;

		public override int GetHashCode()
		{
			return (((13 * 7 + Id.GetHashCode()) * 7 + Title.GetHashCode()) * 7 + Votes.GetHashCode()) * 7 + ChannelPointsVotes.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PollChoiceInfo pollChoiceInfo = obj as PollChoiceInfo;
			if (pollChoiceInfo == null)
			{
				return false;
			}
			if (Id == pollChoiceInfo.Id && Title == pollChoiceInfo.Title && Votes == pollChoiceInfo.Votes)
			{
				return ChannelPointsVotes == pollChoiceInfo.ChannelPointsVotes;
			}
			return false;
		}

		public static bool operator ==(PollChoiceInfo a, PollChoiceInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PollChoiceInfo a, PollChoiceInfo b)
		{
			return !(a == b);
		}
	}
}
