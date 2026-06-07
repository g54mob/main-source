using UnityEngine;

namespace NewGameplayScripts
{
	public class HideUIScript : MonoBehaviour
	{
		public KeyCode toggleKey = KeyCode.H;

		public GameObject[] uiElements;

		private bool isVisible = true;

		private void Update()
		{
			if (Input.GetKeyDown(toggleKey))
			{
				ToggleVisibility();
			}
		}

		private void ToggleVisibility()
		{
			isVisible = !isVisible;
			GameObject[] array = uiElements;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(isVisible);
			}
		}
	}
}
