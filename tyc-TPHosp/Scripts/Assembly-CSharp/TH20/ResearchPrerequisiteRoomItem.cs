using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteRoomItem : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<RoomItemDefinition> _definition;

		public bool IsValid(Level level)
		{
			if (level.WorldState != null)
			{
				return level.WorldState.AvailableRoomItems.Contains(_definition.Instance);
			}
			return false;
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_RoomItem_CS.Replace("{[ITEM]}", _definition.Instance.GetLocalisedName());
		}
	}
}
