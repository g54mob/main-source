using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ReceptionAvailable : CharacterConditional
	{
		[Tooltip("Check In Interaction")]
		public SharedObjectInteractionRef _interaction;

		public override TaskStatus OnUpdate()
		{
			CharacterCheckInComponent orAddComponent = base.Character.GetOrAddComponent<CharacterCheckInComponent>();
			if (base.Character.Level.ReceptionManager.GetBestReception(base.Character, out var bestItem))
			{
				if (bestItem != null && _interaction != null)
				{
					_interaction.Value = new ObjectInteractionRef(bestItem);
					RoomItemReceptionComponent component = bestItem.ParentRoomItem.GetComponent<RoomItemReceptionComponent>();
					if (component != null)
					{
						orAddComponent.StartCheckIn(component);
					}
				}
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
