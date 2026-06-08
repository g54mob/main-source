using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class OrbitCameraController : MonoBehaviour
	{
		public bool locked;

		public bool lockedZoom;

		public WorldDragRect dragRect;

		public Transform anchor;

		public Transform cameraAnchor;

		public LayerMask layerMask;

		public float margin;

		public float zoomValue;

		public float roamValue;

		public Camera cam;

		public UhCamera uhCam;

		public Camera overlayCam;

		public float minRoam;

		public float minZoom;

		public float zoomSpeed;

		public float roamSpeed;

		public float dragSpeed;

		public float rotationSpeed;

		public float moveSpeed;

		public float smooth;

		public AnimationCurve goCurve;

		private Quaternion targetRotation;

		private float startTime;

		private bool isGo;

		private bool isGoRotation;

		private bool isGoZoom;

		private Vector3 startPosition;

		private Quaternion startRotation;

		private float startZoom;

		private Vector3 startAttachedPosition;

		private Transform startAttachedTo;

		private bool fps;

		private bool isAttached;

		private Vector3 input;

		private bool fpsGuide;

		public Vector3 targetPosition { get; set; }

		public float targetZoom { get; set; }

		public Transform attachedTo { get; private set; }

		public Vector3 attachedPosition { get; private set; }

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		public float GetZoomDistance()
		{
			return 0f;
		}

		public void GoTo(Vector3 position)
		{
		}

		public void GoTo(Vector3 position, Quaternion rotation)
		{
		}

		public void GoTo(Vector3 position, float zoom)
		{
		}

		public void AttachTo(Transform target, Vector3 position)
		{
		}

		public void SaveTo(OrbitCameraViewable viewable)
		{
		}

		public void LoadFrom(OrbitCameraViewable viewable)
		{
		}
	}
}
