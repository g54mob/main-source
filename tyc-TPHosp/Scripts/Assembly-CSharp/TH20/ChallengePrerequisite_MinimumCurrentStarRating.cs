using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisite_MinimumCurrentStarRating : IChallengePrerequisite
	{
		[SerializeField]
		private int _minimum;

		public bool CheckConditions(Level level)
		{
			MetagameHospitalRecord hospitalRecord = level.Metagame.GetHospitalRecord(level.Config);
			if (hospitalRecord != null)
			{
				return hospitalRecord.TotalLevelStars() >= _minimum;
			}
			return true;
		}
	}
}
