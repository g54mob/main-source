using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IsPlayingInteraction : CharacterConditional
	{
		[Tooltip("Interaction")]
		public SharedObjectInteractionRef _interaction;

		public bool _checkReservation;

		public override TaskStatus OnUpdate()
		{
			if (_interaction.IsValid())
			{
				ObjectInteraction get = _interaction.Get;
				if (get.IsInteracting(base.Character))
				{
					return TaskStatus.Success;
				}
				if (_checkReservation && get.Reserved == base.Character)
				{
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
