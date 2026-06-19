using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StartBehaviour : CharacterAction
	{
		[Tooltip("Behaviour")]
		public SharedBehaviour _behaviour;

		[Tooltip("Variables")]
		public SharedNamedVariable[] _variables;

		public override TaskStatus OnUpdate()
		{
			if (_behaviour.Value != null)
			{
				base.Character.SetBehaviour(_behaviour.Value);
				SharedNamedVariable[] variables = _variables;
				foreach (SharedNamedVariable sharedNamedVariable in variables)
				{
					base.Character.BehaviorTree.SetVariableValue(sharedNamedVariable.Value.name, sharedNamedVariable.Value.value);
				}
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
