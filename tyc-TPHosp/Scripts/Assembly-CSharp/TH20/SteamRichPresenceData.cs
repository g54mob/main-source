using FullSerializerSave;

namespace TH20
{
	public class SteamRichPresenceData : OnlineManager.IOnlineSerializable
	{
		[fsProperty("id")]
		public string CurrentLevelID;

		[fsProperty("m")]
		public int CurrentMoneyInLevel;

		[fsProperty("r")]
		public float CurrentReputationInLevel;

		[fsProperty("sm")]
		public float CurrentStaffMoraleInLevel;

		public void PrepareForUpload()
		{
		}

		public void RestoreAfterDownload()
		{
		}
	}
}
