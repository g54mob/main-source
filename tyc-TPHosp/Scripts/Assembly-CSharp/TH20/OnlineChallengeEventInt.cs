using FullSerializerSave;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class OnlineChallengeEventInt : OnlineChallengeEvent
	{
		public static readonly Event[] EventsWithIntData = new Event[8]
		{
			Event.StaffHired,
			Event.StaffFired,
			Event.StaffPromoted,
			Event.PatientDeath,
			Event.PatientCured,
			Event.PatientCureIneffective,
			Event.PatientDiagnosed,
			Event.LoanTaken
		};

		[Key(2)]
		[fsProperty("d")]
		public int Data;

		public static OnlineChallengeEventInt Create(int time, Event type, int value)
		{
			return new OnlineChallengeEventInt
			{
				Day = time,
				Type = type,
				Data = value
			};
		}
	}
}
