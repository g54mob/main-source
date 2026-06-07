using Unity.Mathematics;

namespace Gh.Tk
{
	public class ChangeRotationScaleCommand : IUndoRedoCommand
	{
		private readonly EntityObject _eo;

		private readonly quaternion _oldRotation;

		private readonly quaternion _newRotation;

		private readonly float3 _oldScale;

		private readonly float3 _newScale;

		public ChangeRotationScaleCommand(EntityObject eo, quaternion oldRotation, quaternion newRotation, float3 oldScale, float3 newScale)
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
