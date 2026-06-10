using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PollDefinition : IMarshallable
	{
		internal readonly int TypeCode = -1429450289;

		public string Title;

		public string[] Choices;

		public long Duration;

		public bool BitsVotingEnabled;

		public int BitsPerVote;

		public bool ChannelPointsVotingEnabled;

		public int ChannelPointsPerVote;

		public override int GetHashCode()
		{
			return ((((((13 * 7 + Title.GetHashCode()) * 7 + Choices.GetHashCode()) * 7 + Duration.GetHashCode()) * 7 + BitsVotingEnabled.GetHashCode()) * 7 + BitsPerVote.GetHashCode()) * 7 + ChannelPointsVotingEnabled.GetHashCode()) * 7 + ChannelPointsPerVote.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PollDefinition pollDefinition = obj as PollDefinition;
			if (pollDefinition == null)
			{
				return false;
			}
			if (Title == pollDefinition.Title && Choices == pollDefinition.Choices && Duration == pollDefinition.Duration && BitsVotingEnabled == pollDefinition.BitsVotingEnabled && BitsPerVote == pollDefinition.BitsPerVote && ChannelPointsVotingEnabled == pollDefinition.ChannelPointsVotingEnabled)
			{
				return ChannelPointsPerVote == pollDefinition.ChannelPointsPerVote;
			}
			return false;
		}

		public static bool operator ==(PollDefinition a, PollDefinition b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PollDefinition a, PollDefinition b)
		{
			return !(a == b);
		}
	}
}
