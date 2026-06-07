using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

namespace SaveData
{
	public class InGameData
	{
		private const string SAVE_KEY = "InGame";

		private const string Version000 = "0.0.0";

		private const string Version010 = "0.1.0";

		private const string Version011 = "0.1.1";

		private const string Version012 = "0.1.2";

		private const string Version013 = "0.1.3";

		private const string Version014 = "0.1.4";

		private const string Version100 = "1.0.0";

		private const string Version200 = "2.0.0";

		private const string Version210 = "2.1.0";

		private const string Version220 = "2.2.0";

		private const string Version300 = "3.0.0";

		private const string Version301 = "3.0.1";

		private const string Version302 = "3.0.2";

		private const string Version303 = "3.0.3";

		private const string Version304 = "3.0.4";

		private const string Version305 = "3.0.5";

		private const string Version306 = "3.0.6";

		private const string Version307 = "3.0.7";

		private const string Version308 = "3.0.8";

		private const string Version309 = "3.0.9";

		private const string Version3010 = "3.0.10";

		private const string Version3011 = "3.0.11";

		private const string Version3012 = "3.0.12";

		private const string Version3013 = "3.0.13";

		private const string Version3014 = "3.0.14";

		private const string Version3015 = "3.0.15";

		private const string Version3016 = "3.0.16";

		private const string Version3017 = "3.0.17";

		private const string Version3018 = "3.0.18";

		private const string Version3019 = "3.0.19";

		private const string Version3020 = "3.0.20";

		public static readonly Version SaveInGameVersion;

		public static readonly string SaveDateFormat;

		[NonSerialized]
		public static string openVersion;

		public string inGameVersion;

		public string applicationVersion;

		public bool debugMode;

		public string playBeginDate;

		public string playEndDate;

		public bool isInterruption;

		public eClearState clearState;

		public PlayBattleData playBattleData;

		public int removeMachineCount;

		public eChallengeId challengeId;

		public List<eSteamAchivementId> playAchivementIds;

		public List<MstResearchTreeDataEntities> convertResearches;

		public static string SaveKey => null;

		public Version InGameVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsBroken => false;

		public bool _isBroken { get; set; }

		public bool CheckExistRemoveMachine => false;

		public void SetInGame(bool withSave = false)
		{
		}

		public bool RecordInGame(Texture2D screenShot = null)
		{
			return false;
		}

		public void GetInGame()
		{
		}

		public void AddRemoveMachineCount(int addNum)
		{
		}

		public void PlayInGame()
		{
		}

		public void SetPlayAchievement(eSteamAchivementId achievementId)
		{
		}
	}
}
