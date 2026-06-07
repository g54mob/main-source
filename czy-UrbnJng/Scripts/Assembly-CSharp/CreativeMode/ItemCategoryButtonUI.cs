using NewGameplayScripts;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class ItemCategoryButtonUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject buttons;

		[SerializeField]
		private CreativeModeButtonsUI creativeModeButtons;

		private Button button;

		private void Awake()
		{
			button = base.transform.GetComponent<Button>();
			button.onClick.AddListener(ToggleButtons);
		}

		private void OnDestroy()
		{
			button.onClick.RemoveAllListeners();
		}

		public void HideButtons()
		{
			buttons.SetActive(value: false);
		}

		private void ToggleButtons()
		{
			if (!MovementSystem.Instance.IsMoving())
			{
				if (buttons.activeSelf)
				{
					HideButtons();
					return;
				}
				creativeModeButtons.HideAllButtons();
				buttons.SetActive(value: true);
			}
		}
	}
}
