using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class DepartureMethodDefinition
	{
		public abstract bool IsAvailable();

		public abstract DepartureMethod Create(Character character, IDepartedCallback callback);
	}
}
