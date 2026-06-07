using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.FactoryFloor.MapEditor
{
	public class CameraPanMapEditor : MonoBehaviour
	{
		[SerializeField]
		private Vector2 _limit = new Vector2(100f, 100f);

		[Header("Panning")]
		[SerializeField]
		private InputActionReference _panAction;

		[SerializeField]
		private InputActionReference _panGrabAction;

		[SerializeField]
		private float _panSpeed = 5f;

		[SerializeField]
		private float _panDragSpeed = 5f;

		[Header("Zoom")]
		[SerializeField]
		private CameraZoomMapEditor _cameraZoom;

		[SerializeField]
		private float _zoomScalar = 0.001f;

		private void Update()
		{
			Vector3 vector = Vector3.zero;
			if (_panGrabAction.action.IsPressed())
			{
				vector = -Input.mousePositionDelta;
			}
			Vector2 vector2 = _panAction.action.ReadValue<Vector2>();
			Vector3 vector3 = new Vector3(vector2.x, 0f, vector2.y) * (_panSpeed * Time.deltaTime);
			vector3 += new Vector3(vector.x, 0f, vector.y) * _panDragSpeed;
			vector3 *= _cameraZoom.TargetZoom * _zoomScalar + 1f;
			Vector3 position = base.transform.position + vector3;
			position.x = Mathf.Clamp(position.x, 0f - _limit.x, _limit.x);
			position.z = Mathf.Clamp(position.z, 0f - _limit.y, _limit.y);
			base.transform.position = position;
		}
	}
}
