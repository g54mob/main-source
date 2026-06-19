using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteStarsOnLevel : ResearchPrerequisite
	{
		[SerializeField]
		private int _numStars;

		[SerializeField]
		private SharedInstance<LevelConfig> _level;

		public bool IsValid(Level level)
		{
			MetagameHospitalRecord metagameHospitalRecord = (_level.NotNull() ? level.Metagame.GetHospitalRecord(_level.Instance) : null);
			if (metagameHospitalRecord != null)
			{
				return metagameHospitalRecord.TotalLevelStars() >= _numStars;
			}
			return false;
		}

		public string Description()
		{
			return null;
		}
	}
}
