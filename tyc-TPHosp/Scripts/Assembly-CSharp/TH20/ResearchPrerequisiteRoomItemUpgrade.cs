using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteRoomItemUpgrade : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<RoomItemUpgradeDefinition> _definition;

		public bool IsValid(Level level)
		{
			return level.Metagame.HasUnlocked(_definition.Instance);
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_RoomItemUpgrade_CS.Replace("{[UPGRADE]}", _definition.Instance.LocalisedName.Translation);
		}
	}
}
