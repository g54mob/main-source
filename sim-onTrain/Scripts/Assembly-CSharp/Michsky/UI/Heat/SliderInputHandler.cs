using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	public class SliderInputHandler : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private Slider sliderObject;

		[SerializeField]
		private GameObject indicator;

		[Header("Settings")]
		[Range(0.1f, 50f)]
		public float valueMultiplier = 1f;

		[SerializeField]
		[Range(0.01f, 1f)]
		private float deadzone = 0.1f;

		[SerializeField]
		private bool optimizeUpdates = true;

		public bool requireSelecting = true;

		[SerializeField]
		private bool reversePosition;

		[SerializeField]
		private bool divideByMaxValue;

		private float divideValue = 1000f;

		private void OnEnable()
		{
			if (ControllerManager.instance == null || sliderObject == null)
			{
				Object.Destroy(this);
			}
			if (indicator == null)
			{
				indicator = new GameObject();
				indicator.name = "[Generated Indicator]";
				indicator.transform.SetParent(base.transform);
			}
			indicator.SetActive(value: false);
			if (divideByMaxValue)
			{
				divideValue = sliderObject.maxValue;
			}
		}

		private void Update()
		{
			if (Gamepad.current == null || ControllerManager.instance == null)
			{
				indicator.SetActive(value: false);
				return;
			}
			if (requireSelecting && EventSystem.current.currentSelectedGameObject != base.gameObject)
			{
				indicator.SetActive(value: false);
				return;
			}
			if (optimizeUpdates && ControllerManager.instance != null && !ControllerManager.instance.gamepadEnabled)
			{
				indicator.SetActive(value: false);
				return;
			}
			indicator.SetActive(value: true);
			if (reversePosition && ControllerManager.instance.hAxis >= deadzone)
			{
				sliderObject.value -= valueMultiplier / divideValue * ControllerManager.instance.hAxis;
			}
			else if (!reversePosition && ControllerManager.instance.hAxis >= deadzone)
			{
				sliderObject.value += valueMultiplier / divideValue * ControllerManager.instance.hAxis;
			}
			else if (reversePosition && ControllerManager.instance.hAxis <= 0f - deadzone)
			{
				sliderObject.value += valueMultiplier / divideValue * Mathf.Abs(ControllerManager.instance.hAxis);
			}
			else if (!reversePosition && ControllerManager.instance.hAxis <= 0f - deadzone)
			{
				sliderObject.value -= valueMultiplier / divideValue * Mathf.Abs(ControllerManager.instance.hAxis);
			}
		}
	}
}
