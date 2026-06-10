using System.Collections.Generic;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class InputNavigation : SelfInstancingMonoSingleton<InputNavigation>
	{
		[SerializeField]
		private List<GameObject> ControllerButtonIcons;

		[SerializeField]
		private List<GameObject> MouseButtonIcons;

		public bool mouseNavigation;

		public void SetToController()
		{
		}

		public void SetToMouse()
		{
		}

		private void ShowControllerButtonIconsAndHideMouseButtonIcons()
		{
		}

		private void HideControllerButtonIconsAndShowMouseButtonIcons()
		{
		}

		public void DeselectUiGameObject()
		{
		}

		public void SelectGameObject(GameObject go)
		{
		}

		public void Select(Selectable s, bool selectEvenWhenUsingMouse = false)
		{
		}
	}
}
