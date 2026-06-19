using FullSerializerSave;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class OnlineChallengeEventString : OnlineChallengeEvent
	{
		[Key(2)]
		[fsProperty("d")]
		public string Data;

		public static OnlineChallengeEventString Create(int time, Event type, string value)
		{
			return new OnlineChallengeEventString
			{
				Day = time,
				Type = type,
				Data = value.Truncate(64)
			};
		}
	}
}
