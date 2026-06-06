using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/mobile/mobile-joystick")]
	[AddComponentMenu("Malbers/Input/Mobile Joystick")]
	public class MobileJoystick : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		[Tooltip("What mouse button to use for the joystick ")]
		public PointerEventData.InputButton Button;

		[Tooltip("Inverts the Horizontal value of the joystick")]
		public bool invertX;

		[Tooltip("Inverts the Vertical value of the joystick")]
		public bool invertY;

		[Tooltip("If the Axis Magnitude is lower than this value then the Axis will zero out")]
		public FloatReference deathpoint = new FloatReference(0.1f);

		public FloatReference sensitivityX = new FloatReference(0.05f);

		public FloatReference sensitivityY = new FloatReference(0.05f);

		[Tooltip("The Joystick Start position will be First click on the Area")]
		public bool Dynamic;

		[Tooltip("If the Joystick is not Moving it will stop moving the Axis ")]
		public BoolReference StopJoyStick = new BoolReference(value: false);

		public BoolReference pressed;

		public Vector2Reference axisValue;

		private Vector2 DeltaDrag;

		public UnityEvent OnJoystickDown = new UnityEvent();

		public UnityEvent OnJoystickUp = new UnityEvent();

		public Vector2Event OnAxisChange = new Vector2Event();

		public FloatEvent OnXAxisChange = new FloatEvent();

		public FloatEvent OnYAxisChange = new FloatEvent();

		public BoolEvent OnJoystickPressed = new BoolEvent();

		private float BgXSize;

		private float BgYSize;

		public bool AxisEditor = true;

		public bool EventsEditor = true;

		public bool ReferencesEditor = true;

		[Tooltip("If true, then the joystick will not use the starting position as guide for calculating the movement axis")]
		public bool m_Drag;

		private int DragRegistered;

		public Graphic bg;

		public Graphic DragRect;

		public Graphic Jbutton;

		private const float mult = 3f;

		public bool Pressed
		{
			get
			{
				return pressed;
			}
			set
			{
				BoolEvent onJoystickPressed = OnJoystickPressed;
				bool arg = (pressed.Value = value);
				onJoystickPressed.Invoke(arg);
			}
		}

		public Vector2 AxisValue
		{
			get
			{
				return axisValue;
			}
			set
			{
				if (invertX)
				{
					value.x *= -1f;
				}
				if (invertY)
				{
					value.y *= -1f;
				}
				axisValue.Value = value;
			}
		}

		public float XAxis => AxisValue.x;

		public float YAxis => AxisValue.y;

		private void Start()
		{
			if (bg == null)
			{
				bg = GetComponent<Graphic>();
			}
			if (Jbutton == null)
			{
				Jbutton = base.transform.GetChild(0).GetComponent<Graphic>();
			}
			if (DragRect == null)
			{
				DragRect = GetComponent<Graphic>();
			}
			BgXSize = bg.rectTransform.sizeDelta.x;
			BgYSize = bg.rectTransform.sizeDelta.y;
		}

		private void Update()
		{
			if (Pressed)
			{
				OnAxisChange.Invoke(axisValue);
				OnXAxisChange.Invoke(axisValue.Value.x);
				OnYAxisChange.Invoke(axisValue.Value.y);
				DragRegistered++;
			}
			if (StopJoyStick.Value && DragRegistered > 1 && AxisValue != Vector2.zero)
			{
				AxisValue = Vector3.zero;
				DragRegistered = 0;
			}
		}

		private void OnDisable()
		{
			PointerUP();
		}

		public virtual void OnDrag(PointerEventData Point)
		{
			if (Point.button != Button)
			{
				return;
			}
			Vector2 vector = Vector2.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bg.rectTransform, Point.position, Point.pressEventCamera, out var localPoint))
			{
				if (!m_Drag || Dynamic)
				{
					localPoint.x /= BgXSize;
					localPoint.y /= BgYSize;
					vector = new Vector3(localPoint.x * 3f * (float)sensitivityX, localPoint.y * 3f * (float)sensitivityY);
					vector = ((vector.magnitude > 1f) ? vector.normalized : vector);
					Vector2 anchoredPosition = new Vector2(vector.x * (BgXSize / 3f), vector.y * (BgYSize / 3f));
					Jbutton.rectTransform.anchoredPosition = anchoredPosition;
				}
				else
				{
					Jbutton.rectTransform.anchoredPosition = localPoint;
					Vector2 vector2 = localPoint - DeltaDrag;
					vector = new Vector3(vector2.x * (float)sensitivityX * (float)Screen.width * 0.001f, vector2.y * (float)sensitivityY * 0.001f * (float)Screen.height);
					DeltaDrag = localPoint;
				}
			}
			DragRegistered = 0;
			if (vector.magnitude <= (float)deathpoint)
			{
				AxisValue = Vector2.zero;
			}
			else
			{
				AxisValue = vector;
			}
		}

		public virtual void OnPointerDown(PointerEventData Point)
		{
			if (Point.button != Button)
			{
				return;
			}
			OnJoystickDown.Invoke();
			Pressed = true;
			DeltaDrag = Vector2.zero;
			if (Dynamic && !m_Drag)
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(DragRect.rectTransform, Point.position, Point.pressEventCamera, out var localPoint))
				{
					localPoint.x -= DragRect.rectTransform.sizeDelta.x;
					localPoint.y -= DragRect.rectTransform.sizeDelta.y;
					bg.rectTransform.anchoredPosition = localPoint;
				}
			}
			else
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(bg.rectTransform, Point.position, Point.pressEventCamera, out DeltaDrag);
			}
			OnDrag(Point);
		}

		public virtual void OnPointerUp(PointerEventData Point)
		{
			if (Point.button == Button)
			{
				PointerUP();
			}
		}

		private void PointerUP()
		{
			OnJoystickUp.Invoke();
			Pressed = false;
			AxisValue = Vector2.zero;
			Jbutton.rectTransform.anchoredPosition = Vector3.zero;
			DeltaDrag = Vector2.zero;
			OnAxisChange.Invoke(axisValue);
			OnXAxisChange.Invoke(axisValue.Value.x);
			OnYAxisChange.Invoke(axisValue.Value.y);
		}
	}
}
