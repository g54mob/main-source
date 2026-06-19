using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_MinimumStarRating : StaffChallengePrerequisite
	{
		[SerializeField]
		private int _minimum;

		public bool IsValid(Level level, Staff staff)
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
