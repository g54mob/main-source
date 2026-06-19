using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WeightedIllnessList
	{
		public List<WeightedIllness> Illnesses;

		public bool IsValid()
		{
			foreach (WeightedIllness illness in Illnesses)
			{
				if (illness.Definition.NotNull() && illness.Definition.Instance.DLCIsValid())
				{
					return true;
				}
			}
			return false;
		}
	}
}
