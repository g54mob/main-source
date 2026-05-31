using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "WorkerLevelsData", menuName = "Worker/WorkerLevelsData")]
	public class WorkerLevelsData : ScriptableObject
	{
		[field: SerializeField]
		public SerializableDictionary<int, Level> Levels { get; private set; } = new SerializableDictionary<int, Level>();

		[field: SerializeField]
		public SerializableDictionary<EWorkerExperienceSource, int> WorkerExperienceSources { get; private set; }

		public bool HasLevel(int level)
		{
			return Levels.ContainsKey(level);
		}

		public bool GetLevelCharacteristicsMaximum(int level, out int characteristicMaximum)
		{
			characteristicMaximum = 0;
			if (!HasLevel(level))
			{
				return false;
			}
			characteristicMaximum = Levels[level].CharacteristicsMaximum;
			return true;
		}

		public bool GetLevelRequiredExperience(int level, out float requiredExperience)
		{
			requiredExperience = 0f;
			if (!HasLevel(level))
			{
				return false;
			}
			requiredExperience = Levels[level].RequiredExperience;
			return true;
		}

		public bool CanLevelUp(int currentLevel, float experience)
		{
			int num = currentLevel + 1;
			if (!HasLevel(num))
			{
				return false;
			}
			return Levels[num].RequiredExperience <= experience;
		}
	}
}
