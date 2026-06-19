using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetGameObject : CharacterAction
	{
		[Tooltip("GameObject")]
		public SharedGameObject _gameObject;

		public override TaskStatus OnUpdate()
		{
			if (_gameObject == null)
			{
				return TaskStatus.Failure;
			}
			_gameObject.Value = base.Character.GameObject;
			return TaskStatus.Success;
		}
	}
}
