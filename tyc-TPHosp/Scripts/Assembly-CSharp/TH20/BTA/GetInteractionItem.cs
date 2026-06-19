using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetInteractionItem : CharacterAction
	{
		[SerializeField]
		private SharedItemRef _item;

		public override TaskStatus OnUpdate()
		{
			if (base.Character.Interaction != null)
			{
				RoomItem parentRoomItem = base.Character.Interaction.ParentRoomItem;
				if (parentRoomItem != null)
				{
					_item.Value = new ItemRef(parentRoomItem);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
