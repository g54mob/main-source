using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetRandomLocation : CharacterAction
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Room")]
		public SharedRoomRef _room;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Location")]
		public SharedVector3 _retLocation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Rotation")]
		public SharedFloat _retRotation;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				NavMesh navMesh = base.Character.Level.WorldState.NavMesh;
				int areaIDAtPosition = navMesh.GetAreaIDAtPosition(base.Character.Position);
				if (RoomAlgorithms.GetRandomFreeTile(_room.Get.FloorPlan, out var worldPosition, navMesh, areaIDAtPosition) || RoomAlgorithms.GetRandomFreeTile(_room.Get.FloorPlan, out worldPosition))
				{
					_retLocation.Value = worldPosition;
					_retRotation.Value = Random.Range(0, 360);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
