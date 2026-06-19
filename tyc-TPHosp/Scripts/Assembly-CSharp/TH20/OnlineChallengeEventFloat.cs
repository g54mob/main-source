using FullSerializerSave;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class OnlineChallengeEventFloat : OnlineChallengeEvent
	{
		[Key(2)]
		[fsProperty("d")]
		public float Data;

		public static OnlineChallengeEventFloat Create(int time, Event type, float value)
		{
			return new OnlineChallengeEventFloat
			{
				Day = time,
				Type = type,
				Data = value
			};
		}
	}
}
