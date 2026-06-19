using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisite_MaximumCurrentStarRating : IChallengePrerequisite
	{
		[SerializeField]
		private int _maximum;

		public bool CheckConditions(Level level)
		{
			MetagameHospitalRecord hospitalRecord = level.Metagame.GetHospitalRecord(level.Config);
			if (hospitalRecord != null)
			{
				return hospitalRecord.TotalLevelStars() <= _maximum;
			}
			return true;
		}
	}
}
