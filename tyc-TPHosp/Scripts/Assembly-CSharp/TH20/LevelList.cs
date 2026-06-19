using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelList
	{
		public List<SharedInstance<LevelConfig>> Levels;

		public LevelConfig GetLevelConfigByDisplayName(string displayName)
		{
			if (string.IsNullOrEmpty(displayName))
			{
				return null;
			}
			foreach (SharedInstance<LevelConfig> level in Levels)
			{
				if (level.Instance.GetDisplayName() == displayName)
				{
					return level.Instance;
				}
			}
			return null;
		}

		public SharedInstance<LevelConfig> GetSharedInstance(LevelConfig config)
		{
			foreach (SharedInstance<LevelConfig> level in Levels)
			{
				if (level.Instance == config)
				{
					return level;
				}
			}
			return null;
		}

		public LevelConfig GetLevelConfigByID(string levelID)
		{
			SharedInstance<LevelConfig> sharedInstance = Levels.Find((SharedInstance<LevelConfig> l) => l.Instance.UniqueId == levelID);
			if (sharedInstance == null)
			{
				return null;
			}
			return sharedInstance.Instance;
		}
	}
}
