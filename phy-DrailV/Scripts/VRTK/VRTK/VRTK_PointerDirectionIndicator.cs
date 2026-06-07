using UnityEngine;

namespace VRTK
{
	public class VRTK_PointerDirectionIndicator : MonoBehaviour
	{
		public enum VisibilityState
		{
			OnWhenPointerActive = 0,
			AlwaysOnWithPointerCursor = 1
		}

		[Header("Control Settings")]
		[Tooltip("The touchpad axis needs to be above this deadzone for it to register as a valid touchpad angle.")]
		public Vector2 touchpadDeadzone = Vector2.zero;

		[Tooltip("The axis to use for the direction coordinates.")]
		public VRTK_ControllerEvents.Vector2AxisAlias coordinateAxis = VRTK_ControllerEvents.Vector2AxisAlias.Touchpad;

		[Header("Appearance Settings")]
		[Tooltip("If this is checked then the reported rotation will include the offset of the headset rotation in relation to the play area.")]
		public bool includeHeadsetOffset = true;

		[Tooltip("If this is checked then the direction indicator will be displayed when the location is invalid.")]
		public bool displayOnInvalidLocation = true;

		[Tooltip("If this is checked then the pointer valid/invalid colours will also be used to change the colour of the direction indicator.")]
		public bool usePointerColor;

		[Tooltip("Determines when the direction indicator will be visible.")]
		public VisibilityState indicatorVisibility;

		[HideInInspector]
		public bool isActive = true;

		protected VRTK_ControllerEvents controllerEvents;

		protected Transform playArea;

		protected Transform headset;

		protected GameObject validLocation;

		protected GameObject invalidLocation;

		public event PointerDirectionIndicatorEventHandler PointerDirectionIndicatorPositionSet;

		public virtual void OnPointerDirectionIndicatorPositionSet()
		{
			if (this.PointerDirectionIndicatorPositionSet != null)
			{
				this.PointerDirectionIndicatorPositionSet(this);
			}
		}

		public virtual void Initialize(VRTK_ControllerEvents events)
		{
			controllerEvents = events;
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			headset = VRTK_DeviceFinder.HeadsetTransform();
		}

		public virtual void SetPosition(bool active, Vector3 position)
		{
			base.transform.position = position;
			base.gameObject.SetActive(isActive && active);
			OnPointerDirectionIndicatorPositionSet();
		}

		public virtual Quaternion GetRotation()
		{
			float num = (includeHeadsetOffset ? (playArea.eulerAngles.y - headset.eulerAngles.y) : 0f);
			return Quaternion.Euler(0f, base.transform.localEulerAngles.y + num, 0f);
		}

		public virtual void SetMaterialColor(Color color, bool validity)
		{
			if (validLocation != null)
			{
				validLocation.SetActive(validity);
			}
			if (invalidLocation != null)
			{
				invalidLocation.SetActive(displayOnInvalidLocation ? (!validity) : validity);
			}
			if (usePointerColor)
			{
				Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].material.color = color;
				}
			}
		}

		public virtual VRTK_ControllerEvents GetControllerEvents()
		{
			return controllerEvents;
		}

		protected virtual void Awake()
		{
			validLocation = base.transform.Find("ValidLocation").gameObject;
			invalidLocation = base.transform.Find("InvalidLocation").gameObject;
			base.gameObject.SetActive(value: false);
		}

		protected virtual void Update()
		{
			if (controllerEvents != null && controllerEvents.GetAxisState(coordinateAxis, SDK_BaseController.ButtonPressTypes.Touch) && !InsideDeadzone(controllerEvents.GetAxis(coordinateAxis)))
			{
				float axisAngle = controllerEvents.GetAxisAngle(coordinateAxis);
				float y = ((!(axisAngle > 180f)) ? axisAngle : (axisAngle -= 360f)) + headset.eulerAngles.y;
				base.transform.localEulerAngles = new Vector3(0f, y, 0f);
			}
		}

		protected virtual bool InsideDeadzone(Vector2 currentAxis)
		{
			if (!(currentAxis == Vector2.zero))
			{
				if (Mathf.Abs(currentAxis.x) <= touchpadDeadzone.x)
				{
					return Mathf.Abs(currentAxis.y) <= touchpadDeadzone.y;
				}
				return false;
			}
			return true;
		}
	}
}
