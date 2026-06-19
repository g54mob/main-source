using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteHasRoom : IChallengePrerequisite
	{
		[SerializeField]
		private RoomDefinition.Type _room;

		[SerializeField]
		private int _numRooms = 1;

		public bool CheckConditions(Level level)
		{
			return level.WorldState.CountRoomsOfType(_room, includeClosed: true) >= _numRooms;
		}
	}
}
