using System;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteGoldStars : ResearchPrerequisite
	{
		[SerializeField]
		private int _total;

		public bool IsValid(Level level)
		{
			return level.Metagame.TotalStars() >= _total;
		}

		public string Description()
		{
			string text = ScriptLocalization.Research.Prerequisite_GoldStars_CS;
			LocalisationParams.Set("STARS", _total);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
