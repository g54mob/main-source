using MessagePack;

namespace TH20
{
	[Union(0, typeof(SuperBugRewardKudosh))]
	[Union(1, typeof(SuperBugRewardRoomItem))]
	[Union(2, typeof(SuperBugRewardDeveloperPromise))]
	[MessagePackObject(false)]
	public abstract class SuperBugReward
	{
	}
}
