using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class ButtonGroup : MonoBehaviour
	{
		private static readonly int Normal = Animator.StringToHash("Normal");

		private static readonly int Highlighted = Animator.StringToHash("Highlighted");

		private static readonly int Lowlight = Animator.StringToHash("Lowlight");

		private static readonly int Selected = Animator.StringToHash("Selected");

		public bool keepHighlightedOnDeselectForTouchInput = true;

		public List<TouchButton> buttons = new List<TouchButton>();

		public bool isToggleButtonGroup;

		[ShowIf("isToggleButtonGroup")]
		public TouchButton activeButton;

		private bool _isInitialized;

		[Button("Assign all buttons")]
		private void GetAllButtons()
		{
			buttons.Clear();
			TouchButton[] componentsInChildren = GetComponentsInChildren<TouchButton>();
			foreach (TouchButton item in componentsInChildren)
			{
				buttons.Add(item);
			}
		}

		private void Start()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (_isInitialized)
			{
				return;
			}
			foreach (TouchButton button in buttons)
			{
				button.AddOnClickedEvent(delegate
				{
					OnButtonClicked(button);
				});
				button.AddOnSelectedEvent(delegate
				{
					OnButtonSelected(button);
				});
				button.AddOnDeselectedEvent(delegate
				{
					OnButtonDeselected(button);
				});
			}
			_isInitialized = true;
		}

		private void OnEnable()
		{
			if (isToggleButtonGroup && activeButton != null)
			{
				OnButtonClicked(activeButton);
			}
		}

		public void OnButtonClicked(TouchButton clickedButton)
		{
			if (!isToggleButtonGroup)
			{
				return;
			}
			activeButton = clickedButton;
			activeButton.GetComponent<Animator>().SetTrigger(Selected);
			activeButton.GetComponent<Animator>().ResetTrigger(Normal);
			foreach (TouchButton button in buttons)
			{
				if (button != clickedButton)
				{
					button?.GetComponent<Animator>()?.ResetTrigger(Normal);
					button?.GetComponent<Animator>()?.SetTrigger(Lowlight);
				}
			}
		}

		public void OnButtonSelected(TouchButton selectedButton)
		{
			foreach (TouchButton button in buttons)
			{
				if (button != selectedButton && (!isToggleButtonGroup || button != activeButton))
				{
					button?.GetComponent<Animator>()?.ResetTrigger(Normal);
					button?.GetComponent<Animator>()?.SetTrigger(Lowlight);
				}
			}
			if (isToggleButtonGroup && activeButton == selectedButton && activeButton != null)
			{
				activeButton?.GetComponent<Animator>()?.ResetTrigger(Lowlight);
				activeButton?.GetComponent<Animator>()?.ResetTrigger(Selected);
				activeButton?.GetComponent<Animator>()?.SetTrigger(Highlighted);
			}
		}

		public void OnButtonDeselected(VariableDeviceSelectable deselectedButton)
		{
			if (isToggleButtonGroup)
			{
				if (activeButton != null)
				{
					activeButton.GetComponent<Animator>()?.ResetTrigger(Normal);
					if (keepHighlightedOnDeselectForTouchInput && activeButton.DeviceInputType == DeviceInputType.Touch)
					{
						activeButton.GetComponent<Animator>()?.SetTrigger(Highlighted);
					}
					else
					{
						activeButton.GetComponent<Animator>()?.SetTrigger(Selected);
					}
				}
				if (deselectedButton != activeButton)
				{
					deselectedButton?.GetComponent<Animator>()?.ResetTrigger(Normal);
					deselectedButton?.GetComponent<Animator>()?.SetTrigger(Lowlight);
				}
				return;
			}
			foreach (TouchButton button in buttons)
			{
				if (!(button == null))
				{
					button.GetComponent<Animator>()?.SetTrigger(Normal);
				}
			}
		}
	}
}
