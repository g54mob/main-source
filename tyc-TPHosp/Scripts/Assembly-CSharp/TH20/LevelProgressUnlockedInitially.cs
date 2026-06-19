using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelProgressUnlockedInitially : LevelProgressPrerequisite
	{
		public override bool IsComplete(Metagame metagame)
		{
			return true;
		}

		public override string RequiredDescription()
		{
			return "";
		}
	}
}
