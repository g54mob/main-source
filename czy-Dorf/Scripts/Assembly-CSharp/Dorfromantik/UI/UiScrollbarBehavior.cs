using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiScrollbarBehavior : MonoBehaviour
	{
		[SerializeField]
		private float initialScrollbarSize = 0.5f;

		[SerializeField]
		private bool hasSeparators;

		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		private Scrollbar scrollBar;

		[SerializeField]
		private List<GameObject> separators = new List<GameObject>();

		[SerializeField]
		private InputActionReference scrollInputAction;

		[SerializeField]
		private bool noInputWhileOnConfirmationScreen;

		private float scrollSpeed = 1500f;

		private AxisEventData axisEventData = new AxisEventData(EventSystem.current);

		private void Awake()
		{
			Validate();
		}

		private void OnValidate()
		{
			Validate();
		}

		private void OnEnable()
		{
			scrollRect.movementType = ScrollRect.MovementType.Elastic;
			if (hasSeparators)
			{
				foreach (GameObject separator in separators)
				{
					separator.SetActive(value: true);
				}
			}
			if ((bool)Singleton<InputManager>.Instance)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged += OnInputDeviceUpdated;
				OnInputDeviceUpdated(Singleton<InputManager>.Instance.CurrentInputDevice);
			}
		}

		private void OnInputDeviceUpdated(InputDevice currentInputDevice)
		{
			scrollBar.interactable = Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard;
		}

		private void OnDisable()
		{
			scrollRect.movementType = ScrollRect.MovementType.Clamped;
			if (hasSeparators)
			{
				foreach (GameObject separator in separators)
				{
					separator.SetActive(value: false);
				}
			}
			if ((bool)Singleton<InputManager>.Instance)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged -= OnInputDeviceUpdated;
			}
		}

		private void Validate()
		{
			if (scrollRect == null)
			{
				scrollRect = GetComponentInParent<ScrollRect>();
			}
			if (scrollBar == null)
			{
				scrollBar = GetComponent<Scrollbar>();
			}
			scrollBar.size = initialScrollbarSize;
		}

		private void Update()
		{
			if ((bool)scrollRect && (!noInputWhileOnConfirmationScreen || !Singleton<MainMenuUi>.Instance.ActiveConfirmationScreen))
			{
				Vector2 vector = scrollInputAction.action.ReadValue<Vector2>();
				if (Mathf.Abs(vector.y) > 0.01f)
				{
					ScrollViewFocusFunctions.ScrollBy(scrollRect, vector * Time.deltaTime * scrollSpeed);
				}
			}
		}
	}
}
