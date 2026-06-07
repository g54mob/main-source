using UnityEngine;

namespace Assets.Scripts.Design
{
	public class StickToCameraScript : MonoBehaviour
	{
		private Camera _camera;

		protected virtual void Update()
		{
			if (_camera == null && Camera.main != null)
			{
				_camera = Camera.main;
				base.transform.parent = _camera.transform;
				base.transform.localPosition = Vector3.zero;
				Object.Destroy(this);
			}
		}
	}
}
