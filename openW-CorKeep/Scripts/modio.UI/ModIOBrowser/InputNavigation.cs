using System.Collections.Generic;
using ModIO.Util;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class InputNavigation : SelfInstancingMonoSingleton<InputNavigation>
	{
		[SerializeField]
		private List<GameObject> ControllerButtonIcons = new List<GameObject>();

		[SerializeField]
		private List<GameObject> MouseButtonIcons = new List<GameObject>();

		public bool mouseNavigation;

		public void SetToController()
		{
			mouseNavigation = false;
			Cursor.lockState = CursorLockMode.Locked;
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectMostRecentStillActivatedUiItem();
			ShowControllerButtonIconsAndHideMouseButtonIcons();
		}

		public void SetToMouse()
		{
			Cursor.lockState = CursorLockMode.None;
			HideControllerButtonIconsAndShowMouseButtonIcons();
			mouseNavigation = true;
		}

		private void ShowControllerButtonIconsAndHideMouseButtonIcons()
		{
			foreach (GameObject controllerButtonIcon in ControllerButtonIcons)
			{
				controllerButtonIcon?.SetActive(value: true);
			}
			foreach (GameObject mouseButtonIcon in MouseButtonIcons)
			{
				mouseButtonIcon?.SetActive(value: false);
			}
		}

		private void HideControllerButtonIconsAndShowMouseButtonIcons()
		{
			foreach (GameObject controllerButtonIcon in ControllerButtonIcons)
			{
				controllerButtonIcon?.SetActive(value: false);
			}
			foreach (GameObject mouseButtonIcon in MouseButtonIcons)
			{
				mouseButtonIcon?.SetActive(value: true);
			}
		}

		public void DeselectUiGameObject()
		{
			if (!mouseNavigation)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
		}

		public void SelectGameObject(GameObject go)
		{
			if (MonoSingleton<Browser>.Instance.BrowserCanvas.activeSelf && !mouseNavigation)
			{
				EventSystem.current.SetSelectedGameObject(go);
			}
		}

		public void Select(Selectable s, bool selectEvenWhenUsingMouse = false)
		{
			if (MonoSingleton<Browser>.Instance.BrowserCanvas.activeSelf && !(s == null) && (!mouseNavigation || selectEvenWhenUsingMouse))
			{
				EventSystem.current.SetSelectedGameObject(null, null);
				EventSystem.current.SetSelectedGameObject(s.gameObject, null);
			}
		}
	}
}
