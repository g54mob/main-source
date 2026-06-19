using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetRoomEntranceLocation : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public SharedVector3 _outLocation;

		public SharedFloat _outRotation;

		public override TaskStatus OnUpdate()
		{
			if (_room == null || !_room.IsValid())
			{
				return TaskStatus.Failure;
			}
			Room get = _room.Get;
			if (get.QueuePath == null || !get.QueuePath.GetPoint(0, out var position, out var rotation))
			{
				return TaskStatus.Failure;
			}
			_outLocation.Value = position;
			_outRotation.Value = rotation;
			return TaskStatus.Success;
		}
	}
}
