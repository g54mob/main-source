using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IllnessList
	{
		public List<SharedInstance<IllnessDefinition>> Illnesses;
	}
}
