using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class SuperBugRewardKudosh : SuperBugReward
	{
		[Key(0)]
		public int KudoshAmount;
	}
}
