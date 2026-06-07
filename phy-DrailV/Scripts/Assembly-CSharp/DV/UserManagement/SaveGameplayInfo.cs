using System;
using System.Linq;
using DV.Common;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement
{
	public class SaveGameplayInfo : ISaveGameplayInfo
	{
		public int DataVersion { get; private set; }

		public DateTime InGameDate { get; private set; }

		public TimeSpan InGameTimePassed { get; private set; }

		public float PlayerMoney { get; private set; }

		public float FeeDebt { get; private set; }

		public int LicensesUnlocked { get; private set; }

		public int OrdersActive { get; private set; }

		public bool IsCorrupt { get; private set; }

		public SaveGameplayInfo(ISaveGame save)
		{
			SaveGameData saveGameData = null;
			try
			{
				save.LoadData();
				saveGameData = SaveGameData.LoadFromJson(save.Data, save.CustomChunkData);
				int? num = saveGameData.GetInt("DataVersion");
				DataVersion = (num.HasValue ? num.Value : 0);
				JToken jObject = saveGameData.GetJObject("Time_and_date");
				InGameDate = ((jObject != null) ? DateTime.FromOADate(jObject.Value<double>("OADate")) : DateTime.MinValue);
				double? num2 = saveGameData.GetDouble("Starting_time_and_date");
				DateTime dateTime = (num2.HasValue ? DateTime.FromOADate(num2.Value) : AStartGameData.BaseTimeAndDate);
				InGameTimePassed = InGameDate - dateTime;
				float? num3 = saveGameData.GetFloat("Player_money");
				PlayerMoney = (num3.HasValue ? num3.Value : 0f);
				float? num4 = saveGameData.GetFloat("Debt_total");
				FeeDebt = (num4.HasValue ? num4.Value : (-1f));
				string[] stringArray = saveGameData.GetStringArray("Licenses_General");
				string[] stringArray2 = saveGameData.GetStringArray("Licenses_Jobs");
				LicensesUnlocked = ((stringArray != null) ? stringArray.Length : 0) + ((stringArray2 != null) ? stringArray2.Length : 0);
				try
				{
					JobsSaveGameData jobsSaveGameData = saveGameData.GetObject<JobsSaveGameData>(SaveGameKeys.GetJobsSaveKeyForDesiredTracksHash(saveGameData.GetString("Last_Tracks_Hash")), JobSaveManager.serializeSettings);
					OrdersActive = ((jobsSaveGameData != null && jobsSaveGameData.jobChains != null) ? jobsSaveGameData.jobChains.Count((JobChainSaveData jc) => jc.jobTaken) : 0);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					OrdersActive = 0;
				}
			}
			catch (Exception ex)
			{
				IsCorrupt = true;
				Debug.LogError("Error while parsing save " + save.Name + ": " + ex.Message);
				Debug.LogException(ex);
			}
		}
	}
}
