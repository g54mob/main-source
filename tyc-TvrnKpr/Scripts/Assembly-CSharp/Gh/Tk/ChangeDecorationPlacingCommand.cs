using Unity.Mathematics;
using UnityEngine;

namespace Gh.Tk
{
	public class ChangeDecorationPlacingCommand : UndoRedoCommandWithState
	{
		private readonly float3 _destinationTranslation;

		private readonly quaternion _destinationRotation;

		private readonly float3 _destinationScale;

		private GameObjectX _destinationGox;

		private readonly RaycastHit _lastWallOrDoorHit;

		private readonly Vector3 _mousePositionForNewProp;

		private readonly (string Id, EntityObject EntityObject, Quaternion Rotation) _snappingPoint;

		private readonly bool _wallOrDoor;

		private GameObjectX _newGox;

		private readonly EntityObject _entityObject;

		private readonly float3 _sourceTranslation;

		private readonly quaternion _sourceRotation;

		private readonly float3 _sourceScale;

		private readonly GameObjectX _sourceGox;

		private readonly (string Id, EntityObject EntityObject, Quaternion Rotation) _sourceSnappingPoint;

		public ChangeDecorationPlacingCommand(float3 translation, quaternion rotation, float3 destinationScale, GameObjectX gox, RaycastHit lastWallOrDoorHit, bool wallOrDoor, Vector3 coordForNewProp, (string Id, EntityObject EntityObject, Quaternion Rotation) snappingPoint, EntityObject origEntityObject)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		protected override void UndoInternal()
		{
		}

		protected override void CleanUpWhenExecuted()
		{
		}

		protected override void CleanUpWhenUndone()
		{
		}
	}
}
