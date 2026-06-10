using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class VillageNameRepository : DynamicJsonRepository<VillageNameRepository, VillageNames>
	{
		private VillageNames VillageNames
		{
			get
			{
				string currentLanguageName = MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageName();
				return GetByID(currentLanguageName) ?? GetByID("English");
			}
		}

		public IReadOnlyList<string> Names => VillageNames.Names;

		public IReadOnlyList<string> OldNames => VillageNames.OldNames;

		public string GetRandomName(System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			using PooledList<string> pooledList = ListPool<string>.GetJanitor(VillageNames.Names);
			pooledList.ShuffleInPlace(rnd);
			foreach (string item in pooledList)
			{
				if (!MonoSingleton<GlobalSaveController>.Instance.AnyVillageInfoByName(item))
				{
					return item;
				}
			}
			return null;
		}

		public string GetRandomOldName(System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			using PooledList<string> pooledList = ListPool<string>.GetJanitor(VillageNames.OldNames);
			pooledList.ShuffleInPlace(rnd);
			foreach (string item in pooledList)
			{
				if (!MonoSingleton<GlobalSaveController>.Instance.AnyVillageInfoByName(item))
				{
					return item;
				}
			}
			return null;
		}

		public string GetRandomOldName()
		{
			return VillageNames.OldNames[UnityEngine.Random.Range(0, VillageNames.OldNames.Count)];
		}

		protected override string JsonFile()
		{
			return "Data/VillageName.json";
		}
	}
}
