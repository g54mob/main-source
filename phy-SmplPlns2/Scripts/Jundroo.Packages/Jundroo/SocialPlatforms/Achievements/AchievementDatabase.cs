using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Jundroo.SocialPlatforms.Achievements
{
	[CreateAssetMenu(fileName = "Assets/Resources/Achievements/AchievementDatabase", menuName = "Jundroo/Social Platforms/Create Achievement Database")]
	public class AchievementDatabase : ScriptableObject
	{
		private class AchievementKeyComparer : IEqualityComparer<AchievementKey>
		{
			public bool Equals(AchievementKey x, AchievementKey y)
			{
				return x == y;
			}

			public int GetHashCode(AchievementKey obj)
			{
				return (int)obj;
			}
		}

		private Dictionary<AchievementKey, AchievementInfo> _achievementLookup;

		[SerializeField]
		private bool _achievementsEnabled;

		[SerializeField]
		private List<AchievementInfo> _achievements;

		public List<AchievementInfo> Achievements => _achievements;

		public bool AchievementsEnabled => _achievementsEnabled;

		public AchievementInfo FindById(string id)
		{
			foreach (AchievementInfo achievement in Achievements)
			{
				if (id == achievement.Id)
				{
					return achievement;
				}
			}
			return null;
		}

		public AchievementInfo FindByKey(AchievementKey key, bool logErrorIfNotFound = true)
		{
			AchievementInfo value = null;
			if (!_achievementLookup.TryGetValue(key, out value) && logErrorIfNotFound)
			{
				UnityEngine.Debug.LogErrorFormat("The achievement with key '{0}' could not be found in the achievement database.", key);
			}
			return value;
		}

		protected virtual void OnEnable()
		{
			if (_achievements == null)
			{
				_achievements = new List<AchievementInfo>();
			}
			_achievementLookup = new Dictionary<AchievementKey, AchievementInfo>(_achievements.Count, new AchievementKeyComparer());
			for (int i = 0; i < _achievements.Count; i++)
			{
				AchievementInfo achievementInfo = _achievements[i];
				if (!_achievementLookup.ContainsKey(achievementInfo.Key))
				{
					_achievementLookup.Add(achievementInfo.Key, achievementInfo);
					continue;
				}
				UnityEngine.Debug.LogErrorFormat("Two or more achievements share the achievement key '{0}'", achievementInfo.Key);
			}
			_ = Application.isPlaying;
		}

		[Conditional("UNITY_EDITOR")]
		private void VerifyAchievementKeysInDatabase()
		{
			foreach (AchievementKey value in Enum.GetValues(typeof(AchievementKey)))
			{
				if (!_achievementLookup.ContainsKey(value))
				{
					UnityEngine.Debug.LogErrorFormat("Achievement key '{0}' missing from achievement database", value);
				}
			}
		}
	}
}
