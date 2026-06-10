using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Modding;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	public class VillageSaveMeta
	{
		[SerializeField]
		private List<string> mods;

		[SerializeField]
		private bool autosave;

		[SerializeField]
		private string createdOnVersion;

		[SerializeField]
		private string modifiedOnVersion;

		[SerializeField]
		private long timestamp;

		[SerializeField]
		private Vec3Int mapSize;

		[SerializeField]
		private string mapSizeId;

		[SerializeField]
		private string mapTypeId;

		[SerializeField]
		private int settlersCount;

		[SerializeField]
		private int animalsCount;

		[SerializeField]
		private int npcCount;

		[SerializeField]
		private bool isSecondMap;

		[SerializeField]
		private string seed;

		public List<string> Mods => mods;

		public bool Autosave => autosave;

		public string CreatedOnVersion => createdOnVersion;

		public string ModifiedOnVersion => modifiedOnVersion;

		public long Timestamp => timestamp;

		public Vec3Int MapSize => mapSize;

		public string MapSizeId => mapSizeId;

		public string MapTypeId => mapTypeId;

		public int SettlersCount => settlersCount;

		public int AnimalsCount => animalsCount;

		public int NpcCount => npcCount;

		public bool IsSecondMap => isSecondMap;

		public string Seed => seed;

		public VillageSaveMeta()
		{
		}

		public VillageSaveMeta(VillageSaveData data)
		{
			mods = new List<string>(MonoSingleton<ModManager>.Instance.EnabledMods.Keys);
			createdOnVersion = data.CreatedOnGameVersion;
			modifiedOnVersion = Application.version;
			timestamp = DateTime.Now.ToUnixTimeSeconds();
			mapSize = data.MapSize;
			mapSizeId = data.MapSizeID;
			mapTypeId = data.MapTypeID;
			settlersCount = data.Workers.Count;
			animalsCount = data.AnimalsCount;
			npcCount = data.NPCs.Count;
			isSecondMap = data.IsSecondMap;
			seed = data.MapSeed;
		}
	}
}
