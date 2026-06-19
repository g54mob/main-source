using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC_Room
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IsItemInState : Conditional
	{
		[Tooltip("Item")]
		public SharedItemRef _item;

		[Tooltip("State")]
		public SharedInstance_TH20TH20_RoomItemState _state;

		public override TaskStatus OnUpdate()
		{
			if (_item.IsValid() && _state != null && _state.Instance != null)
			{
				RoomItem get = _item.Get;
				if (get != null)
				{
					RoomItemStateComponent component = get.GetComponent<RoomItemStateComponent>();
					if (component != null && component.IsInState(_state.Instance))
					{
						return TaskStatus.Success;
					}
				}
			}
			return TaskStatus.Failure;
		}
	}
}
