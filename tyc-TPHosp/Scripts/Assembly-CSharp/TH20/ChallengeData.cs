using MessagePack;

namespace TH20
{
	[Union(0, typeof(OnlineChallengeData))]
	[Union(1, typeof(AIChallengeData))]
	[MessagePackObject(false)]
	public abstract class ChallengeData
	{
		[IgnoreMember]
		public abstract int ScoreCount { get; }

		[IgnoreMember]
		public abstract OnlineChallengeEventScore this[int i] { get; }

		public abstract float GetScore(int day);
	}
}
