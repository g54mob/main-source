using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/VIP")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InspectIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetNextRoomOnTour : Action
	{
		[Tooltip("Visitor")]
		public SharedVisitorRef _visitor;

		[Tooltip("Output Room we are leaving")]
		public SharedRoomRef _outOldRoom;

		[Tooltip("Output Next Room")]
		public SharedRoomRef _outRoom;

		public override TaskStatus OnUpdate()
		{
			if (!_visitor.IsValid())
			{
				return TaskStatus.Failure;
			}
			Visitor get = _visitor.Get;
			VIPComponent component = get.GetComponent<VIPComponent>();
			if (component == null)
			{
				return TaskStatus.Failure;
			}
			Room nextRoomInTour = component.GetNextRoomInTour();
			if (nextRoomInTour == null)
			{
				return TaskStatus.Failure;
			}
			_outOldRoom.Value = new RoomRef(get.RoomUsing);
			_outRoom.Value = new RoomRef(nextRoomInTour);
			return TaskStatus.Success;
		}
	}
}
