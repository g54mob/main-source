using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteHasRoomUnlocked : IChallengePrerequisite
	{
		[SerializeField]
		private SharedInstance<RoomDefinition> _room;

		public bool CheckConditions(Level level)
		{
			if (_room.NotNull())
			{
				return level.Metagame.HasUnlocked(_room.Instance);
			}
			return false;
		}
	}
}
