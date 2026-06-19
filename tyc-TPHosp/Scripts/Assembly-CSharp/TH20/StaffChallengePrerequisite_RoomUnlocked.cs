using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_RoomUnlocked : StaffChallengePrerequisite
	{
		[SerializeField]
		private SharedInstance<RoomDefinition> _definition;

		public bool IsValid(Level level, Staff staff)
		{
			return level.WorldState.AvailableRooms.Contains(_definition.Instance);
		}
	}
}
