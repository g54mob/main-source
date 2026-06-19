using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteIllnessTreatmentRoom : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<RoomDefinition> _room;

		public bool IsValid(Level level)
		{
			if (level.CharacterManager != null)
			{
				return level.CharacterManager.IllnessWithTreatmentRoomExists(_room.Instance);
			}
			return false;
		}

		public string Description()
		{
			return null;
		}
	}
}
