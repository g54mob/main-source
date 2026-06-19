using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class SuperBugRewardDeveloperPromise : SuperBugReward
	{
		[Key(0)]
		public string Promise;
	}
}
