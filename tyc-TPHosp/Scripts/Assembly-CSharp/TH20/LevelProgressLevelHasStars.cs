using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelProgressLevelHasStars : LevelProgressPrerequisite
	{
		[SerializeField]
		private SharedInstance<LevelConfig>[] _levels;

		public SharedInstance<LevelConfig>[] Levels => _levels;

		public bool IsLevelComplete(Metagame metagame, SharedInstance<LevelConfig> levelConfig)
		{
			if (metagame != null && levelConfig.NotNull())
			{
				MetagameHospitalRecord hospitalRecord = metagame.GetHospitalRecord(levelConfig.Instance, canBeNull: true);
				if (hospitalRecord != null && hospitalRecord.TotalStars() != 0)
				{
					return true;
				}
			}
			return false;
		}

		public override bool IsComplete(Metagame metagame)
		{
			SharedInstance<LevelConfig>[] levels = _levels;
			foreach (SharedInstance<LevelConfig> sharedInstance in levels)
			{
				if (metagame != null && sharedInstance.NotNull() && IsLevelComplete(metagame, sharedInstance))
				{
					return true;
				}
			}
			return false;
		}

		public override string RequiredDescription()
		{
			if (_levels.Length == 1)
			{
				return ScriptLocalization.Tooltip.LevelPrerequisite_LevelHasStars1_CS.Replace("{[LEVEL1]}", _levels[0].Instance.GetLocalisedDisplayName());
			}
			if (_levels.Length == 2)
			{
				return ScriptLocalization.Tooltip.LevelPrerequisite_LevelHasStars2_CS.Replace("{[LEVEL1]}", _levels[0].Instance.GetLocalisedDisplayName()).Replace("{[LEVEL2]}", _levels[1].Instance.GetLocalisedDisplayName());
			}
			if (_levels.Length == 3)
			{
				return ScriptLocalization.Tooltip.LevelPrerequisite_LevelHasStars3_CS.Replace("{[LEVEL1]}", _levels[0].Instance.GetLocalisedDisplayName()).Replace("{[LEVEL2]}", _levels[1].Instance.GetLocalisedDisplayName()).Replace("{[LEVEL3]}", _levels[2].Instance.GetLocalisedDisplayName());
			}
			return null;
		}
	}
}
