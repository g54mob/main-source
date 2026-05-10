using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public class CareerProfile : Profile, IEquatable<CareerProfile>
	{
		[Serializable]
		public struct LevelSave
		{
			public bool Unlocked;

			public int Score;

			public float PlayTime;

			public bool PlayedOnce;

			public bool AnimPlayed;

			public int Money;

			[ES3NonSerializable]
			public Sprite Screenshot;
		}

		private static readonly Addressable<LevelLoader> _selectionMap = "Assets/Scriptables/Levels/SelectionMap.asset";

		private static readonly Addressable<MapInfoSO> _firstMap = "Assets/Scriptables/Levels/Level_01.asset";

		private static IList<MapInfoSO> _levels;

		private readonly Dictionary<MapInfoSO, LevelSave> _levelProgress = new Dictionary<MapInfoSO, LevelSave>();

		public bool PlayedOnce { get; set; }

		public int ProfileIndex { get; set; } = -1;

		public ReadOnlyDictionary<MapInfoSO, LevelSave> LevelProgress => _levelProgress;

		public static event Action<CareerProfile, MapInfoSO> LevelUnlocked;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			_levels = Addressables.LoadAssetsAsync<MapInfoSO>("Levels").WaitForCompletion();
		}

		public int GetTotalScore()
		{
			int num = 0;
			foreach (LevelSave value in _levelProgress.Values)
			{
				num += value.Score;
			}
			return num;
		}

		public CareerProfile()
		{
			foreach (MapInfoSO level in _levels)
			{
				_levelProgress[level] = default(LevelSave);
			}
		}

		public void SetScore(MapInfoSO level, int score)
		{
			LevelSave value = _levelProgress[level];
			value.Score = score;
			_levelProgress[level] = value;
		}

		public void SetScreenshot(MapInfoSO map, Texture2D image)
		{
			LevelSave value = _levelProgress[map];
			value.Screenshot = Sprite.Create(image, image.GetRect(), Vector2.one);
			_levelProgress[map] = value;
		}

		public void SetMoney(MapInfoSO level, int money)
		{
			LevelSave value = _levelProgress[level];
			value.Money = money;
			_levelProgress[level] = value;
		}

		public void AddPlayTime(MapInfoSO level, float playTime)
		{
			LevelSave value = _levelProgress[level];
			value.PlayTime += playTime;
			_levelProgress[level] = value;
		}

		public void Unlock(string levelName)
		{
			foreach (var (mapInfoSO2, _) in _levelProgress)
			{
				if (mapInfoSO2.name.Equals(levelName, StringComparison.InvariantCulture))
				{
					Unlock(mapInfoSO2);
					break;
				}
			}
		}

		public void Unlock(MapInfoSO level)
		{
			if (IsLevelLocked(level))
			{
				LevelSave value = _levelProgress[level];
				value.Unlocked = true;
				_levelProgress[level] = value;
				CareerProfile.LevelUnlocked?.Invoke(this, level);
			}
		}

		public void UnlockAll()
		{
			foreach (MapInfoSO level in _levels)
			{
				Unlock(level);
			}
		}

		public void TimePlayed(MapInfoSO level, float time)
		{
			LevelSave value = _levelProgress[level];
			value.PlayTime += time;
			_levelProgress[level] = value;
		}

		public float GetTimePlayed(MapInfoSO level)
		{
			return _levelProgress[level].PlayTime;
		}

		public void SetAnimPlayed(MapInfoSO level, bool animPlayed)
		{
			LevelSave value = _levelProgress[level];
			value.AnimPlayed = animPlayed;
			_levelProgress[level] = value;
		}

		public void SetPlayedOnce(MapInfoSO level)
		{
			LevelSave value = _levelProgress[level];
			value.PlayedOnce = PlayedOnce;
			_levelProgress[level] = value;
		}

		public bool IsLevelLocked(MapInfoSO level)
		{
			if (_levelProgress.TryGetValue(level, out var value))
			{
				return !value.Unlocked;
			}
			return true;
		}

		public override string GetName()
		{
			return GetProfileName(ProfileIndex);
		}

		public static string GetProfileName(int profileIndex)
		{
			if (profileIndex < 0)
			{
				profileIndex = 0;
			}
			return "Story_" + profileIndex.ToString("000");
		}

		public override bool DoesLevelHaveSave(MapInfoSO level)
		{
			return ES3.FileExists(SaveSettings.GetGlobalFolderSettings(GetName() + "/" + level.name));
		}

		public bool HasLevelBeenPlayedOnce(MapInfoSO level)
		{
			if (!_levelProgress.TryGetValue(level, out var value))
			{
				return false;
			}
			return value.PlayedOnce;
		}

		public bool HasAnimLevelPlayed(MapInfoSO level)
		{
			if (!_levelProgress.TryGetValue(level, out var value))
			{
				return false;
			}
			return value.AnimPlayed;
		}

		public override void PlayProfile()
		{
			if (PlayedOnce)
			{
				_selectionMap.Value.LoadScene(unloadActive: false);
				return;
			}
			PlayedOnce = true;
			if (CTSSingleton<ProfileManager>.InstanceExists() && CTSSingleton<ProfileManager>.Instance.CurrentProfile == this)
			{
				CTSSingleton<ProfileManager>.Instance.SaveProfile();
			}
			PlayMap(_firstMap);
		}

		public void PlayMap(MapInfoSO map)
		{
			if (map == null || !_levelProgress.TryGetValue(map, out var value))
			{
				return;
			}
			if (value.PlayedOnce)
			{
				if (HasLevelBeenPlayedOnce(map) && DoesLevelHaveSave(map))
				{
					CTSSingleton<ProfileManager>.Instance.LoadScene(map, EGameMode.Story);
				}
				else
				{
					CTSSingleton<ProfileManager>.Instance.RestartScene(map, EGameMode.Story);
				}
			}
			else
			{
				value.PlayedOnce = true;
				_levelProgress[map] = value;
				CTSSingleton<ProfileManager>.Instance.SaveProfile();
				CTSSingleton<ProfileManager>.Instance.RestartScene(map, EGameMode.Story);
			}
		}

		public bool Equals(CareerProfile other)
		{
			if (other == null)
			{
				return false;
			}
			return GetName() == other.GetName();
		}
	}
}
