using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class TranslateGizmoWrapper : MovementGizmoWrapper<TranslateGizmo, TranslateGizmoAxisScript>
	{
		public TranslateGizmoWrapper(Camera camera, GameObject visualizationObject)
			: base(camera, visualizationObject)
		{
		}
	}
}
