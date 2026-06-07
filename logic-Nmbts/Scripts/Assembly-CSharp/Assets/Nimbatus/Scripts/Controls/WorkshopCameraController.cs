using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class WorkshopCameraController : MonoBehaviour
	{
		public float DefaultZoom;

		public float ZoomSpeed;

		public float MaxZoom;

		public float MinZoom;

		internal Camera Camera;

		private bool _zoomCamera;

		private bool _scrollCamera;

		private float _targetZoom;

		protected void Awake()
		{
			Camera = GetComponent<Camera>();
			RuntimeGlobals.MainCamera = Camera;
			_targetZoom = DefaultZoom;
		}

		public void Start()
		{
			_zoomCamera = RunningModeSpecifics.Can(ERunningModeSpecific.ZoomCamera);
			_scrollCamera = RunningModeSpecifics.Can(ERunningModeSpecific.ScrollCamera);
		}

		internal void LateUpdate()
		{
			if (RuntimeGlobals.BlockUInteraction)
			{
				return;
			}
			if (_zoomCamera)
			{
				if (!ItemSelector.HasSelectedItems() && DragAndDropHelper.DraggedItem == null)
				{
					float axis = Input.GetAxis("Mouse ScrollWheel");
					float a = Mathf.Min(Camera.orthographicSize - axis * ZoomSpeed, MaxZoom);
					a = Mathf.Max(a, MinZoom);
					_targetZoom = a;
				}
				Camera.orthographicSize = Mathf.Lerp(Camera.orthographicSize, _targetZoom, Time.smoothDeltaTime * 10f);
			}
			if (_scrollCamera)
			{
				Vector2 vector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
				base.transform.Translate(vector / 10f);
			}
		}
	}
}
