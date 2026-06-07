using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FIMSpace.Basics
{
	public class Fimp_JoystickInput : MonoBehaviour
	{
		private class JoyHandler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
		{
			private Fimp_JoystickInput Parent;

			public JoyHandler Initialize(Fimp_JoystickInput parent)
			{
				Parent = parent;
				return this;
			}

			public void OnPointerDown(PointerEventData eventData)
			{
				Parent.OnClick();
			}
		}

		public Image JoystickButton;

		public Image OptionalJoyBackStick;

		[Space(5f)]
		public float DragDistanceLimit = 75f;

		[Space(5f)]
		public float ValuePower = 1f;

		[FPD_FixedCurveWindow(0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f)]
		public AnimationCurve Sensitivity = AnimationCurve.Linear(0.1f, 0f, 0.9f, 1f);

		public Vector2 ScaleOutput = Vector2.one;

		private Vector2 joyPos = Vector2.zero;

		private Vector2 sd_joyPos = Vector2.zero;

		private bool isDragging;

		private Vector3 startDragMousePosition = Vector3.zero;

		private JoyHandler joyHandler;

		public Vector2 OutputValue { get; private set; }

		private void Start()
		{
			if (!(JoystickButton == null))
			{
				joyHandler = JoystickButton.gameObject.AddComponent<JoyHandler>().Initialize(this);
			}
		}

		private void Update()
		{
			if (JoystickButton == null)
			{
				return;
			}
			Vector2 target = Vector2.zero;
			if (isDragging)
			{
				target = Input.mousePosition - startDragMousePosition;
				target /= JoystickButton.transform.lossyScale.x;
				if (target.magnitude > DragDistanceLimit)
				{
					target = target.normalized * DragDistanceLimit;
				}
				OutputValue = new Vector2(Mathf.Clamp(target.x / DragDistanceLimit, -1f, 1f), Mathf.Clamp(target.y / DragDistanceLimit, -1f, 1f));
				Vector2 outputValue = OutputValue;
				outputValue.x = Sensitivity.Evaluate(Mathf.Abs(outputValue.x));
				if (OutputValue.x < 0f)
				{
					outputValue.x *= -1f;
				}
				outputValue.y = Sensitivity.Evaluate(Mathf.Abs(outputValue.y));
				if (OutputValue.y < 0f)
				{
					outputValue.y *= -1f;
				}
				outputValue.x *= ScaleOutput.x;
				outputValue.y *= ScaleOutput.y;
				OutputValue = outputValue * ValuePower;
			}
			else
			{
				OutputValue = Vector2.zero;
			}
			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
			{
				isDragging = false;
			}
			joyPos = Vector2.SmoothDamp(joyPos, target, ref sd_joyPos, isDragging ? 0.005f : 0.03f, float.MaxValue, Time.unscaledDeltaTime);
			JoystickButton.rectTransform.anchoredPosition = joyPos;
			if ((bool)OptionalJoyBackStick)
			{
				if (joyPos != Vector2.zero)
				{
					Quaternion quaternion = Quaternion.LookRotation(new Vector3(joyPos.x, 0f, joyPos.y));
					OptionalJoyBackStick.rectTransform.rotation = Quaternion.Euler(0f, 0f, 0f - quaternion.eulerAngles.y);
				}
				float y = Vector2.Distance(JoystickButton.rectTransform.anchoredPosition, Vector3.zero);
				Vector2 sizeDelta = OptionalJoyBackStick.rectTransform.sizeDelta;
				sizeDelta.y = y;
				OptionalJoyBackStick.rectTransform.sizeDelta = sizeDelta;
				Vector3 vector = JoystickButton.rectTransform.anchoredPosition.normalized * -14f;
				OptionalJoyBackStick.rectTransform.anchoredPosition = vector;
			}
		}

		private void OnClick()
		{
			if (!isDragging)
			{
				isDragging = true;
				startDragMousePosition = Input.mousePosition;
			}
		}
	}
}
