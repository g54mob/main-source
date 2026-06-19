using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class ArrivalMethodDefinition
	{
		public abstract ArrivalMethod Create(Level level, IArrivedCallback callback);

		public virtual bool IsAvailable()
		{
			return true;
		}

		public virtual bool IsSpawnPointFree()
		{
			return true;
		}
	}
}
