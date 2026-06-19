using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HasModularMask : CharacterConditional
	{
		[Tooltip("Modular Mask")]
		public SharedInstance_TH20TH20_CharModule_Mask _mask;

		public override TaskStatus OnUpdate()
		{
			CharModule.Mask mask = ((_mask != null) ? _mask.Instance : null);
			if (base.Character.Visual.Mask != mask)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}
	}
}
