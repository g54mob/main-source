using System.Collections.Generic;
using Unity.Mathematics;

namespace Gh.Tk
{
	public class ChangePositionRotationScaleCommand : IUndoRedoCommand
	{
		private readonly List<(EntityObject eo, float3 oldPosition, float3 newPosition, quaternion oldRotation, quaternion newRotation, float3 oldScale, float3 newScale)> _changes;

		public ChangePositionRotationScaleCommand(List<(EntityObject eo, float3 oldPosition, float3 newPosition, quaternion oldRotation, quaternion newRotation, float3 oldScale, float3 newScale)> changes)
		{
		}

		public void Execute()
		{
		}

		public void Undo()
		{
		}
	}
}
