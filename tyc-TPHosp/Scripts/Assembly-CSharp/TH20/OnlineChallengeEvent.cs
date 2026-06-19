using FullSerializerSave;
using MessagePack;

namespace TH20
{
	[Union(0, typeof(OnlineChallengeEventScore))]
	[Union(1, typeof(OnlineChallengeEventInt))]
	[Union(2, typeof(OnlineChallengeEventString))]
	[Union(3, typeof(OnlineChallengeEventFloat))]
	[Union(4, typeof(OnlineChallengeEventHospitalStatus))]
	[MessagePackObject(false)]
	public class OnlineChallengeEvent
	{
		public enum Event
		{
			Score = 0,
			StaffHired = 1,
			StaffFired = 2,
			StaffQuit = 3,
			StaffPromoted = 4,
			StaffTrainingStarted = 5,
			PatientCured = 6,
			PatientCureIneffective = 7,
			PatientRageQuit = 8,
			PatientDeath = 9,
			PatientSentHome = 10,
			PatientDiagnosed = 11,
			PlotBought = 12,
			RoomBuilt = 13,
			LoanTaken = 14,
			Challenge = 15,
			ObjectiveStatus = 16
		}

		[Key(0)]
		[fsProperty("a")]
		public int Day;

		[Key(1)]
		[fsProperty("e")]
		public Event Type;

		public static OnlineChallengeEvent Create(int time, Event type)
		{
			return new OnlineChallengeEvent
			{
				Day = time,
				Type = type
			};
		}
	}
}
