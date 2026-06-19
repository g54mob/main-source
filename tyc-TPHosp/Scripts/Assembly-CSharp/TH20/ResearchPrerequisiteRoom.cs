using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteRoom : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<RoomDefinition> _definition;

		public bool IsValid(Level level)
		{
			if (level.WorldState != null)
			{
				return level.WorldState.AvailableRooms.Contains(_definition.Instance);
			}
			return false;
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_Room_CS.Replace("{[ROOM]}", _definition.Instance.GetLocalisedName());
		}
	}
}
