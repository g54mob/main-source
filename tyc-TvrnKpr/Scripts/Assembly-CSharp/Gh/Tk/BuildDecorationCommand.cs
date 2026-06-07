using Unity.Mathematics;
using UnityEngine;

namespace Gh.Tk
{
	public class BuildDecorationCommand : UndoRedoCommandWithState
	{
		private readonly string _selectedBuildItemId;

		private readonly float3 _translation;

		private readonly quaternion _rotation;

		private readonly float3 _scale;

		private readonly GameObjectX _gox;

		private readonly RaycastHit _lastWallOrDoorHit;

		private readonly Vector3 _coordForNewProp;

		private readonly (string Id, EntityObject EntityObject, Quaternion Rotation) _snappingPoint;

		private readonly string _style;

		private readonly bool _wallOrDoor;

		private GameObjectX _newGox;

		private EntityObject _newEntityObject;

		public BuildDecorationCommand(string selectedBuildItemId, float3 translation, quaternion rotation, float3 scale, GameObjectX gox, RaycastHit lastWallOrDoorHit, bool wallOrDoor, Vector3 coordForNewProp, (string Id, EntityObject EntityObject, Quaternion Rotation) snappingPoint, string style)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		protected override void UndoInternal()
		{
		}

		protected override void CleanUpWhenUndone()
		{
		}
	}
}
