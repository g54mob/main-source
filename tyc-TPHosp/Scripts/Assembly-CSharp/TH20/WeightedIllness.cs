using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WeightedIllness
	{
		public bool Deprecated;

		public bool Unlocked = true;

		public int MinWeight = 20;

		public int MaxWeight = 100;

		public int MinStarRating;

		public int MinPatientsSpawned;

		public SharedInstance<IllnessDefinition> Definition;
	}
}
