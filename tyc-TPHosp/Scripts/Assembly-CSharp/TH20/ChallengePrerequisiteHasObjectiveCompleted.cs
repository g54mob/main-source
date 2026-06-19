using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteHasObjectiveCompleted : IChallengePrerequisite
	{
		[SerializeField]
		private string _objectiveUniqueReference;

		public bool CheckConditions(Level level)
		{
			bool success;
			return level.LevelScriptManager.HasObjectiveExpired(_objectiveUniqueReference, out success) && success;
		}
	}
}
