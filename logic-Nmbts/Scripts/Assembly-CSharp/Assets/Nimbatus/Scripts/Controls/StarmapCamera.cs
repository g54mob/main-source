using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class StarmapCamera : SerializedMonoBehaviour
	{
		public BoxCollider2D Bounds;

		public float Speed = 20f;

		public float DragSpeed = 20f;

		public float StartZoom;

		public float MaxZoom;

		public float MinZoom;

		public AnimationCurve ZoomCurve;

		public float ZoomSpeed;

		[HideInInspector]
		public float CurrentZoom;

		private Camera _camera;

		private static StarmapCamera _instance;

		[HideInInspector]
		public Vector3 TargetPosition;

		private Vector3 _origin;

		private Vector3 _difference;

		private float _targetZoom;

		[HideInInspector]
		public bool Blocked;

		internal float Zoom { get; private set; }

		public float ZoomLevel
		{
			get
			{
				return Zoom / (MaxZoom - MinZoom);
			}
		}

		public static StarmapCamera Instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				_instance = Object.FindObjectOfType<StarmapCamera>();
				return _instance;
			}
		}

		protected void Awake()
		{
			_instance = this;
			_camera = GetComponent<Camera>();
			RuntimeGlobals.MainCamera = _camera;
			TargetPosition = base.transform.position;
			_targetZoom = StartZoom;
			_camera.orthographicSize = StartZoom;
		}

		internal void LateUpdate()
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			float num = Speed;
			if (!Blocked)
			{
				if (Input.GetMouseButtonDown(0))
				{
					_origin = MousePos();
				}
				if (Input.GetMouseButton(0))
				{
					_difference = MousePos() - base.transform.position;
					TargetPosition = _origin - _difference;
					num = DragSpeed;
				}
				_targetZoom -= axis * ZoomSpeed;
				_targetZoom = Mathf.Min(_targetZoom, MaxZoom);
				_targetZoom = Mathf.Max(_targetZoom, MinZoom);
				CurrentZoom = _targetZoom;
			}
			Zoom = ZoomCurve.Evaluate(_targetZoom / (MaxZoom - MinZoom)) * (MaxZoom - MinZoom) + MinZoom;
			_camera.orthographicSize = Zoom;
			base.transform.position = Vector3.Lerp(base.transform.position, TargetPosition, Time.smoothDeltaTime * num);
			float orthographicSize = _camera.orthographicSize;
			float orthographicSize2 = _camera.orthographicSize;
			Vector3 position = _camera.transform.position;
			Bounds bounds = Bounds.bounds;
			_camera.transform.position = new Vector3(Mathf.Clamp(position.x, bounds.min.x + orthographicSize2, bounds.max.x - orthographicSize2), Mathf.Clamp(position.y, bounds.min.y + orthographicSize, bounds.max.y - orthographicSize), position.z);
		}

		private Vector3 MousePos()
		{
			return _camera.ScreenToWorldPoint(Input.mousePosition);
		}

		public void MoveToLocation(Transform loc, bool immediate = false)
		{
			Vector3 position = loc.position;
			MoveToLocation(position, immediate);
		}

		public void MoveToLocation(Vector3 pos, bool immediate = false)
		{
			pos.z = base.transform.position.z;
			TargetPosition = pos;
			if (immediate)
			{
				_camera.transform.position = TargetPosition;
			}
		}

		public IEnumerator LerpZoom(float targetZoom)
		{
			float startZoom = _targetZoom;
			float t = 0f;
			while (t < 1f && Blocked)
			{
				t += Time.deltaTime / 0.6f;
				_targetZoom = Mathf.Lerp(startZoom, targetZoom, t);
				yield return null;
			}
			_targetZoom = targetZoom;
		}
	}
}
