using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SetModularMask : CharacterAction
	{
		[Tooltip("Modular Mask")]
		public SharedInstance_TH20TH20_CharModule_Mask _mask;

		public override TaskStatus OnUpdate()
		{
			base.Character.Visual.SetModularMask((_mask != null) ? _mask.Instance : null);
			return TaskStatus.Success;
		}
	}
}
