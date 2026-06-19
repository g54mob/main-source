using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class InfoMessageSource
	{
		[SerializeField]
		protected LocalisedString _localisedString;

		public abstract string GetMessage(Level level);
	}
}
