using FullSerializerSave;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class OnlineChallengeEventHospitalStatus : OnlineChallengeEvent
	{
		[Key(2)]
		[fsProperty("dc")]
		public int DoctorCount;

		[Key(3)]
		[fsProperty("nc")]
		public int NurseCount;

		[Key(4)]
		[fsProperty("jc")]
		public int JanitorCount;

		[Key(5)]
		[fsProperty("ac")]
		public int AssistantCount;

		[Key(6)]
		[fsProperty("pc")]
		public int PatientCount;

		[Key(7)]
		[fsProperty("b")]
		public int Balance;

		[Key(8)]
		[fsProperty("r")]
		public float Reputation;

		[Key(9)]
		[fsProperty("pl")]
		public int PrestigeLevel;

		[Key(10)]
		[fsProperty("pp")]
		public float PrestigeProgress;

		[Key(11)]
		[fsProperty("fv")]
		public int FoundationValue;

		[Key(12)]
		[fsProperty("fsv")]
		public int FoundationShareValue;

		[Key(13)]
		[fsProperty("fs")]
		public int FoundationStars;

		[Key(14)]
		[fsProperty("fk")]
		public int FoundationSilver;

		public static OnlineChallengeEventHospitalStatus Create(int time, int doctorCount, int nurseCount, int janitorCount, int assistantCount, int patientCount, int balance, float reputation, int prestigeLevel, float prestigeProgress, int foundationValue, int foundationShareValue, int foundationStars, int foundationSilver)
		{
			return new OnlineChallengeEventHospitalStatus
			{
				Day = time,
				Type = Event.ObjectiveStatus,
				DoctorCount = doctorCount,
				NurseCount = nurseCount,
				JanitorCount = janitorCount,
				AssistantCount = assistantCount,
				PatientCount = patientCount,
				Balance = balance,
				Reputation = reputation,
				PrestigeLevel = prestigeLevel,
				PrestigeProgress = prestigeProgress,
				FoundationValue = foundationValue,
				FoundationShareValue = foundationShareValue,
				FoundationStars = foundationStars,
				FoundationSilver = foundationSilver
			};
		}
	}
}
