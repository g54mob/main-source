using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamgam.UGUIComponentsForSettings
{
	public class TabManagerUGUI : MonoBehaviour
	{
		public int currentIndexID;

		public List<TabButtonUGUI> tabs;

		public InputActionReference nextInput;

		public InputActionReference previousInput;

		public bool inputActive;

		private void OnEnable()
		{
			inputActive = true;
			Debug.Log("[TabManagerUGUI] OnEnable called - inputActive set to true", this);
			nextInput.action.performed += OnNext;
			previousInput.action.performed += OnPrevious;
			nextInput.action.Enable();
			previousInput.action.Enable();
		}

		private void OnDisable()
		{
			inputActive = false;
			nextInput.action.performed -= OnNext;
			previousInput.action.performed -= OnPrevious;
			nextInput.action.Disable();
			previousInput.action.Disable();
		}

		private void OnNext(InputAction.CallbackContext context)
		{
			if (inputActive)
			{
				if (currentIndexID >= tabs.Count - 1)
				{
					currentIndexID = 0;
				}
				else
				{
					currentIndexID++;
				}
				tabs[currentIndexID].SetActive(active: true);
				tabs[currentIndexID].UpdateSiblings();
			}
		}

		private void OnPrevious(InputAction.CallbackContext context)
		{
			if (inputActive)
			{
				if (currentIndexID == 0)
				{
					currentIndexID = tabs.Count - 1;
				}
				else
				{
					currentIndexID--;
				}
				tabs[currentIndexID].SetActive(active: true);
				tabs[currentIndexID].UpdateSiblings();
			}
		}

		public void TryNext()
		{
			if (inputActive)
			{
				if (currentIndexID >= tabs.Count - 1)
				{
					currentIndexID = 0;
				}
				else
				{
					currentIndexID++;
				}
				tabs[currentIndexID].SetActive(active: true);
				tabs[currentIndexID].UpdateSiblings();
			}
		}
	}
}
