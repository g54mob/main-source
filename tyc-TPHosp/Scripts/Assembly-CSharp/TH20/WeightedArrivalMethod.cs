using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WeightedArrivalMethod
	{
		public int Weight = 100;

		public SharedInstance<ArrivalMethodDefinition> Definition;
	}
}
