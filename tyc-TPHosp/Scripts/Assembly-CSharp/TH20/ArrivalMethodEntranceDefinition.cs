using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalMethodEntranceDefinition : ArrivalMethodDefinition
	{
		public override ArrivalMethod Create(Level level, IArrivedCallback callback)
		{
			return new ArrivalMethodEntrance(level, callback);
		}
	}
}
