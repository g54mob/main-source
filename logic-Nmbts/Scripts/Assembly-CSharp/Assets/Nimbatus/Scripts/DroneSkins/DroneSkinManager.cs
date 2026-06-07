using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.DroneSkins
{
	public class DroneSkinManager : BaseSingleton<DroneSkinManager>
	{
		private Dictionary<string, DroneSkin> _skins;

		protected override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(base.gameObject);
			LoadSkins();
		}

		private void LoadSkins()
		{
			_skins = new Dictionary<string, DroneSkin>();
			DroneSkin[] array = Resources.LoadAll<DroneSkin>("Items/Skins");
			foreach (DroneSkin droneSkin in array)
			{
				_skins.Add(droneSkin.UniqueId, droneSkin);
			}
		}

		public List<DroneSkin> GetDroneSkins(EDroneSkinSet set)
		{
			return _skins.Values.Where((DroneSkin s) => s.Set == set).ToList();
		}

		public DroneSkin GetDroneSkin(string id)
		{
			return _skins[id];
		}

		public bool IsSetUnlocked(EDroneSkinSet set)
		{
			switch (set)
			{
			case EDroneSkinSet.Nimbatus:
				return true;
			case EDroneSkinSet.Pirates:
				return BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(EAchievement.BrawlTournamentWon);
			case EDroneSkinSet.Corp:
				return BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(EAchievement.Survivor);
			case EDroneSkinSet.Sumo:
				return BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(EAchievement.SumoTournamentWon);
			case EDroneSkinSet.Race:
				return BaseSingleton<AchievementManager>.Instance.IsAchievementUnlocked(EAchievement.SpeedDemon);
			default:
				return true;
			}
		}

		public List<EDroneSkinSet> GetUnlockedSets()
		{
			return EnumHelper.GetValues<EDroneSkinSet>().Where(IsSetUnlocked).ToList();
		}
	}
}
