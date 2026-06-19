using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalMethodRandomHospitalLocationDefinition : ArrivalMethodDefinition
	{
		public override ArrivalMethod Create(Level level, IArrivedCallback callback)
		{
			return new ArrivalMethodRandomHospitalLocation(level, callback);
		}
	}
}
