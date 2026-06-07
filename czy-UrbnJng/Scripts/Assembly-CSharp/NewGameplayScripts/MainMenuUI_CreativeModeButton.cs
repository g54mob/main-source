using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace NewGameplayScripts
{
	public class MainMenuUI_CreativeModeButton : MonoBehaviour
	{
		[SerializeField]
		private int levelNumber;

		[SerializeField]
		private Button button;

		[SerializeField]
		private Image lockImage;

		private void Start()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.OpenedLevels.Contains(levelNumber))
			{
				lockImage.gameObject.SetActive(value: false);
				button.onClick.AddListener(ClickButton);
			}
			HoverColorUI component = button.GetComponent<HoverColorUI>();
			if (component != null)
			{
				component.StartHover();
			}
		}

		private void ClickButton()
		{
			MainMenuUI.Instance.CreativeModeButton(levelNumber);
		}
	}
}
