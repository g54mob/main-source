using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class RotateGizmoWrapper : MovementGizmoWrapper<RotateGizmo, RotateGizmoAxisScript>
	{
		public RotateGizmoWrapper(Camera camera, GameObject visualizationObject)
			: base(camera, visualizationObject)
		{
		}
	}
}
