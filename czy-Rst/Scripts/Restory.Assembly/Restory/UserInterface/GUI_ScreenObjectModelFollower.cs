using System;
using Helpers.Extensions;
using Restory.ObjectPools;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_ScreenObjectModelFollower : UIBehaviour, ICleanableComponent, ILayoutController
	{
		private static readonly Vector3 SCREEN_POSITION_FOR_BEHIND_CAMERA = new Vector3(-10000f, -10000f, 0f);

		private RectTransform rectTransform;

		private RectTransform parentRectTransform;

		[SerializeField]
		private bool followTargetInWorldPosition;

		[SerializeField]
		private float offsetWorldPositionY = 1.5f;

		[SerializeField]
		private float offsetCameraYAxis = 0.5f;

		[SerializeField]
		private bool updateModalEveryFrame;

		[SerializeField]
		private Vector3 offsetScreenPosition;

		[SerializeField]
		private bool alwaysKeepInsideScreenBorders;

		[SerializeField]
		private Vector2 paddingInsideScreenBorders;

		[SerializeField]
		private bool autoCleanOnDisable = true;

		protected IModelProperty followable;

		private Camera camera;

		private Transform cameraTransform;

		private Vector3? heldWorldPosition;

		public Transform FollowTransform { get; set; }

		public RectTransform RectTransform
		{
			get
			{
				if (rectTransform == null)
				{
					rectTransform = base.transform as RectTransform;
				}
				return rectTransform;
			}
		}

		public RectTransform ParentRectTransform
		{
			get
			{
				if (parentRectTransform == null)
				{
					parentRectTransform = base.transform as RectTransform;
				}
				return parentRectTransform;
			}
		}

		public Vector3 AdditionalOffsetPosition { get; set; }

		public virtual bool IsInParentRect => RectTransformUtility.RectangleContainsScreenPoint(ParentRectTransform, RectTransform.position);

		public Vector3 OffsetScreenPosition
		{
			get
			{
				return offsetScreenPosition;
			}
			set
			{
				offsetScreenPosition = value;
			}
		}

		[Inject]
		private void Construct([Inject(Id = "GameCamera")] Camera camera)
		{
			this.camera = camera;
			cameraTransform = camera.transform;
		}

		protected override void Awake()
		{
			base.Awake();
			TryGetComponent<IModelProperty>(out followable);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			CinemachineCore.CameraUpdatedEvent.AddListener(OnCameraUpdatedEvent);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCameraUpdatedEvent);
			if (autoCleanOnDisable)
			{
				Clean();
			}
			StopHoldingWorldPosition();
		}

		private void OnCameraUpdatedEvent(CinemachineBrain brain)
		{
			UpdatePosition();
		}

		protected virtual Transform GetModelToFollow()
		{
			if (followable != null)
			{
				return followable.Model;
			}
			return null;
		}

		public virtual void UpdatePosition()
		{
			if (!FollowTransform || updateModalEveryFrame)
			{
				FollowTransform = GetModelToFollow();
			}
			if (!FollowTransform)
			{
				return;
			}
			if (!followTargetInWorldPosition && FollowTransform.gameObject.activeSelf && FollowTransform is RectTransform rectTransform)
			{
				FinalizeScreenPosition(rectTransform.position);
				return;
			}
			Vector3 position = (heldWorldPosition ?? FollowTransform.position) + Vector3.up * offsetWorldPositionY + cameraTransform.up * offsetCameraYAxis;
			Vector3 vector = camera.WorldToScreenPoint(position);
			if (vector.z < 0f)
			{
				RectTransform.position = SCREEN_POSITION_FOR_BEHIND_CAMERA;
			}
			else
			{
				FinalizeScreenPosition(new Vector3(vector.x, vector.y, 0f));
			}
		}

		public void HoldCurrentWorldPosition()
		{
			if (FollowTransform != null)
			{
				heldWorldPosition = FollowTransform.position;
			}
		}

		public void StopHoldingWorldPosition()
		{
			heldWorldPosition = null;
		}

		private void FinalizeScreenPosition(Vector3 initialPositionOnScreen)
		{
			try
			{
				Vector3 vector = OffsetScreenPosition + AdditionalOffsetPosition;
				Vector2 screenResolutionDifference = new Vector2((float)Screen.width / 1920f, (float)Screen.height / 1080f);
				Vector3 vector2 = new Vector3(vector.x * screenResolutionDifference.x, vector.y * screenResolutionDifference.y, vector.z);
				RectTransform.position = initialPositionOnScreen + vector2;
				ClampPositionInParentRect();
				if (alwaysKeepInsideScreenBorders)
				{
					ClampRectInsideScreenBorders(screenResolutionDifference);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("FinalizeScreenPosition Error " + ex);
			}
		}

		public virtual void ClampPositionInParentRect()
		{
			if (!IsInParentRect)
			{
				Rect worldRect = ParentRectTransform.GetWorldRect();
				RectTransform.position = worldRect.ProjectPointToEdge(RectTransform.position);
			}
		}

		private void ClampRectInsideScreenBorders(Vector2 screenResolutionDifference)
		{
			float num = paddingInsideScreenBorders.x * screenResolutionDifference.x;
			float num2 = paddingInsideScreenBorders.y * screenResolutionDifference.y;
			Rect rect = new Rect(num, num2, (float)Screen.width - num * 2f, (float)Screen.height - num2 * 2f);
			Rect worldRect = RectTransform.GetWorldRect();
			bool flag = worldRect.xMin < rect.xMin;
			bool flag2 = worldRect.xMax > rect.xMax;
			bool flag3 = worldRect.yMin < rect.yMin;
			bool flag4 = worldRect.yMax > rect.yMax;
			if ((flag4 && flag3) || (flag && flag2))
			{
				Debug.LogWarning($"[GUI_ScreenObjectModelFollower] at [{base.gameObject.name}] tried to position the GUI inside screen, but the GUI is too large and doesn't fit. Screen with padding's size is [{rect.size}], GUI object's size is [{worldRect.size}].", base.gameObject);
				return;
			}
			float num3 = worldRect.width / 2f;
			float num4 = worldRect.height / 2f;
			Vector2 pivot = RectTransform.pivot;
			Vector2 vector = new Vector2(pivot.x * worldRect.width - num3, pivot.y * worldRect.height - num4);
			Vector3 position = RectTransform.position;
			float x = position.x;
			float y = position.y;
			if (flag)
			{
				x = rect.xMin + num3 + vector.x;
			}
			else if (flag2)
			{
				x = rect.xMax - num3 + vector.x;
			}
			if (flag3)
			{
				y = rect.yMin + num4 + vector.y;
			}
			else if (flag4)
			{
				y = rect.yMax - num4 + vector.y;
			}
			RectTransform.position = new Vector3(x, y);
		}

		public void Clean()
		{
			FollowTransform = null;
		}

		public void SetLayoutHorizontal()
		{
			UpdatePosition();
		}

		public void SetLayoutVertical()
		{
			UpdatePosition();
		}
	}
}
