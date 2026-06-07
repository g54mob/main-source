using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class PS5Settings : ScriptableObject
	{
		[Serializable]
		public class AchivementToTrophy
		{
			public string achivementName;

			public eSteamAchivementId id;

			public int trophyId;

			public AchivementToTrophy(eSteamAchivementId id, int trophyId)
			{
			}

			public AchivementToTrophy(string id, string trophyId)
			{
			}
		}

		[Header("PS5本体から閲覧できるセーブデータの設定")]
		public Texture2D saveIcon688X388;

		public string saveTitle;

		public string saveSubTitle;

		public string saveDetail;

		public TextAsset trophyCsv;

		public TextAsset trophyJsonFromUDS;

		public TextAsset trophyJsonToUDS;

		public AchivementToTrophy[] trophies;

		public MstSteamAchiveData steamAchiveData;

		private byte[] iconCache;

		private Dictionary<eSteamAchivementId, int> trophiesById;

		public byte[] GetSaveIcon()
		{
			return null;
		}

		public int GetTrophyId(eSteamAchivementId id)
		{
			return 0;
		}
	}
}
