using System;

namespace SaveData
{
	public class ProfileSummaryData
	{
		private const string SAVE_KEY = "ProfileSummary";

		private const string Version000 = "0.0.0";

		private const string Version001 = "0.0.1";

		public static readonly Version SaveSummaryVersion;

		public string summaryVersion;

		public PlayAuthorData authorData;

		public PlayArchiveData archiveData;

		public PlayOutGameShopData outGameShopData;

		public string lastUpdate;

		public bool isNewGame;

		public string profileName;

		public static string SaveKey => null;

		public Version SummaryVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void SetData(bool withSave = false)
		{
		}

		public void GetData()
		{
		}

		public void SetSummary(OutGameData outGameData)
		{
		}

		public void SetNewGame(bool isNewGame, bool withSave = false)
		{
		}

		public void SetProfileName(string name)
		{
		}
	}
}
