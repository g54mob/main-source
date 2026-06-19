using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Interaction")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IsInteractionDifferent : CharacterConditional
	{
		public SharedObjectInteractionRef _interaction1;

		public SharedObjectInteractionRef _interaction2;

		public SharedObjectInteractionRef _result;

		public override TaskStatus OnUpdate()
		{
			if (_interaction1.IsValid() && _interaction2.IsValid() && _interaction1.Get != _interaction2.Get)
			{
				_result.Value = new ObjectInteractionRef(_interaction2.Get);
				return TaskStatus.Success;
			}
			if (_interaction1.IsValid())
			{
				Character character = base.Character;
				ObjectInteraction get = _interaction1.Get;
				if (character.Interaction != get && character.ReservedInteraction != get && character.WaitingForInteraction != get)
				{
					_result.Value = new ObjectInteractionRef(_interaction1.Get);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
