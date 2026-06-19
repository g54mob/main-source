using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RandomLocationWithin : CharacterAction
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Room to search in")]
		public SharedRoomRef _room;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Radius to search")]
		public float _radius;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Random Location")]
		public SharedVector3 _retLocation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Random Rotation")]
		public SharedFloat _retRotation;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && !_room.Get.HasBeenDestroyed())
			{
				NavMesh navMesh = base.Character.Level.WorldState.NavMesh;
				int areaIDAtPosition = navMesh.GetAreaIDAtPosition(base.Character.Position);
				if (RoomAlgorithms.GetRandomFreeTileWithinRadius(_room.Get.FloorPlan, base.Character.Position, _radius, out var worldPositionOut, navMesh, areaIDAtPosition))
				{
					_retLocation.Value = worldPositionOut;
					_retRotation.Value = Random.Range(0, 360);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
