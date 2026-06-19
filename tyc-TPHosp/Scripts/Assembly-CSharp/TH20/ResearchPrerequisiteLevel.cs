using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteLevel : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<LevelConfig> _level;

		public bool IsValid(Level level)
		{
			return level.Config == _level.Instance;
		}

		public string Description()
		{
			return null;
		}
	}
}
