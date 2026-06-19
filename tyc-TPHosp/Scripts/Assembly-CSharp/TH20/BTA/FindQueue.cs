using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FindQueue : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Queue Location")]
		public SharedVector3 _retLocation;

		[Tooltip("Queue Rotation")]
		public SharedFloat _retRotation;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && RoomAlgorithms.GetQueueTransform(base.Character, _room.Get, out var position, out var rotation))
			{
				_retLocation.Value = position;
				_retRotation.Value = rotation;
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
