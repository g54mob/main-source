using FullSerializerSave;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class OnlineChallengeEventScore : OnlineChallengeEvent
	{
		[Key(2)]
		[fsProperty("s")]
		public int Score;

		public static OnlineChallengeEventScore Create(int time, int score)
		{
			return new OnlineChallengeEventScore
			{
				Day = time,
				Type = Event.Score,
				Score = score
			};
		}
	}
}
