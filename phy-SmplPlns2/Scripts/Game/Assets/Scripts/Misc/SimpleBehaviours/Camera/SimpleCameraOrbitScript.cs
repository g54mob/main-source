using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Misc.SimpleBehaviours.Camera
{
	public class SimpleCameraOrbitScript : MonoBehaviour
	{
		[SerializeField]
		private UnityEngine.Camera _camera;

		[SerializeField]
		private Transform _focalPoint;

		[SerializeField]
		private Vector3 _focalPointOffset = Vector3.zero;

		private Vector3 _mouseLastPosition;

		public UnityEngine.Camera Camera => _camera;

		public float CameraToFocalPointDistance
		{
			get
			{
				Vector3 vector = _focalPoint.transform.position + _focalPointOffset;
				return (_camera.transform.position - vector).magnitude;
			}
			set
			{
				Vector3 vector = _focalPoint.transform.position + _focalPointOffset;
				Vector3 vector2 = _camera.transform.position - vector;
				_camera.transform.position = vector + vector2.normalized * Mathf.Max(1f, value);
			}
		}

		public Transform FocalPoint => _focalPoint;

		public Vector3 FocalPointOffset => _focalPointOffset;

		public Vector3 FocalPosition => _focalPoint.transform.position + _focalPointOffset;

		protected virtual void Update()
		{
			if (!(_camera == null) && !(_focalPoint == null))
			{
				Vector3 vector = _focalPoint.transform.position + _focalPointOffset;
				Transform transform = _camera.transform;
				Vector3 vector2 = transform.position - vector;
				transform.LookAt(vector, Vector3.up);
				Vector3 mousePosition = UnityEngine.Input.mousePosition;
				Vector3 vector3 = mousePosition - _mouseLastPosition;
				_mouseLastPosition = mousePosition;
				if (UnityEngine.Input.mouseScrollDelta.y != 0f)
				{
					float magnitude = vector2.magnitude;
					float num = Mathf.Max(0.25f, Mathf.Log10(magnitude)) * (0f - UnityEngine.Input.mouseScrollDelta.y);
					num *= Mathf.Max(1f, Mathf.Pow(5f, Mathf.Log10(magnitude) - 1f));
					_camera.transform.position = vector + vector2.normalized * Mathf.Max(1f, magnitude + num);
				}
				bool num2 = EventSystem.current.currentSelectedGameObject != null;
				if (!num2 && UnityEngine.Input.GetMouseButton(0) && vector3 != Vector3.zero)
				{
					transform.RotateAround(vector, Vector3.up, vector3.x * 1f);
					transform.RotateAround(vector, Vector3.Cross(vector2.normalized, Vector3.up), (0f - vector3.y) * 1f);
				}
				if (!num2 && UnityEngine.Input.GetMouseButton(1) && vector3 != Vector3.zero)
				{
					Vector3 vector4 = transform.right * (vector3.x * 0.1f) + transform.up * (vector3.y * 0.1f);
					_focalPointOffset += vector4;
					transform.position += vector4;
				}
				if (!num2 && UnityEngine.Input.GetMouseButtonDown(2))
				{
					_focalPointOffset = Vector3.zero;
				}
			}
		}
	}
}
