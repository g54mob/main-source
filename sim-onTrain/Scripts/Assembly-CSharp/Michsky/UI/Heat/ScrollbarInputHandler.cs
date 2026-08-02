using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Scrollbar))]
	public class ScrollbarInputHandler : MonoBehaviour
	{
		public enum ScrollbarDirection
		{
			Horizontal = 0,
			Vertical = 1
		}

		[Header("Resources")]
		[SerializeField]
		private Scrollbar scrollbarObject;

		[SerializeField]
		private GameObject indicator;

		[Header("Settings")]
		[SerializeField]
		private ScrollbarDirection direction = ScrollbarDirection.Vertical;

		[Range(0.1f, 50f)]
		public float scrollSpeed = 3f;

		[SerializeField]
		[Range(0.01f, 1f)]
		private float deadzone = 0.1f;

		[SerializeField]
		private bool optimizeUpdates = true;

		public bool allowInputs = true;

		[SerializeField]
		private bool reversePosition;

		private float divideValue = 1000f;

		private void OnEnable()
		{
			if (scrollbarObject == null)
			{
				scrollbarObject = base.gameObject.GetComponent<Scrollbar>();
			}
			if (ControllerManager.instance == null)
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
		}

		private void Update()
		{
			if (Gamepad.current == null || ControllerManager.instance == null || !allowInputs)
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
			if (direction == ScrollbarDirection.Vertical)
			{
				if (reversePosition && ControllerManager.instance.vAxis >= 0.1f)
				{
					scrollbarObject.value -= scrollSpeed / divideValue * ControllerManager.instance.vAxis;
				}
				else if (!reversePosition && ControllerManager.instance.vAxis >= 0.1f)
				{
					scrollbarObject.value += scrollSpeed / divideValue * ControllerManager.instance.vAxis;
				}
				else if (reversePosition && ControllerManager.instance.vAxis <= -0.1f)
				{
					scrollbarObject.value += scrollSpeed / divideValue * Mathf.Abs(ControllerManager.instance.vAxis);
				}
				else if (!reversePosition && ControllerManager.instance.vAxis <= -0.1f)
				{
					scrollbarObject.value -= scrollSpeed / divideValue * Mathf.Abs(ControllerManager.instance.vAxis);
				}
			}
			else if (direction == ScrollbarDirection.Horizontal)
			{
				if (reversePosition && ControllerManager.instance.hAxis >= deadzone)
				{
					scrollbarObject.value -= scrollSpeed / divideValue * ControllerManager.instance.hAxis;
				}
				else if (!reversePosition && ControllerManager.instance.hAxis >= deadzone)
				{
					scrollbarObject.value += scrollSpeed / divideValue * ControllerManager.instance.hAxis;
				}
				else if (reversePosition && ControllerManager.instance.hAxis <= 0f - deadzone)
				{
					scrollbarObject.value += scrollSpeed / divideValue * Mathf.Abs(ControllerManager.instance.hAxis);
				}
				else if (!reversePosition && ControllerManager.instance.hAxis <= 0f - deadzone)
				{
					scrollbarObject.value -= scrollSpeed / divideValue * Mathf.Abs(ControllerManager.instance.hAxis);
				}
			}
		}
	}
}
