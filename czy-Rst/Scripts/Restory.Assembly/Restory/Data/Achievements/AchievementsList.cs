using System.Collections.Generic;
using Restory.Achievements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.Achievements
{
	[CreateAssetMenu(fileName = "AchievementsList", menuName = "Restory/Achievements/AchievementsList")]
	public sealed class AchievementsList : SerializedScriptableObject
	{
		[SerializeField]
		private List<Achievement> achievements = new List<Achievement>();

		private Dictionary<AchievementId, Achievement> achievementsTable;

		public IReadOnlyList<Achievement> Achievements => achievements;

		private void OnEnable()
		{
			TryCache();
		}

		private void TryCache()
		{
			if (achievementsTable != null)
			{
				return;
			}
			achievementsTable = new Dictionary<AchievementId, Achievement>();
			foreach (Achievement achievement in achievements)
			{
				achievementsTable[achievement.Id] = achievement;
			}
		}

		public Achievement GetAchievementInfo(AchievementId id)
		{
			TryCache();
			return achievementsTable[id];
		}

		public bool TryGetAchievementInfo(AchievementId id, out Achievement achievementInfo)
		{
			TryCache();
			return achievementsTable.TryGetValue(id, out achievementInfo);
		}
	}
}
