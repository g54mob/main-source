using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelProgressSilverUnlock : LevelProgressPrerequisite
	{
		[SerializeField]
		private SharedInstance<LevelConfig> _level;

		public override bool IsComplete(Metagame metagame)
		{
			return metagame.HasUnlocked(_level.Instance);
		}

		public override string RequiredDescription()
		{
			return ScriptLocalization.Tooltip.LevelPrerequisite_SilverUnlock_CS.Replace("{[LEVEL]}", _level.Instance.GetLocalisedDisplayName()).Replace("{[COUNT]}", _level.Instance.SilverCost().ToString());
		}
	}
}
