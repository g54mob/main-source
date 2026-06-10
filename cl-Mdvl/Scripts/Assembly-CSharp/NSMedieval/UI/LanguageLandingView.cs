using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class LanguageLandingView : MonoBehaviour
	{
		[SerializeField]
		private GameObject landingScreen;

		[SerializeField]
		private ToggleGroup flagsGroup;

		[SerializeField]
		private Toggle[] flags;

		[SerializeField]
		private SoundButton continueButton;

		private void Start()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.LanguageName != "None" || ArgumentParser.GetArg("-autoplay") != null)
			{
				return;
			}
			landingScreen.SetActive(value: true);
			continueButton.gameObject.SetActive(value: false);
			continueButton.onClick.AddListener(OnContinue);
			flagsGroup.SetAllTogglesOff();
			int num = 0;
			Toggle[] array = flags;
			foreach (Toggle obj in array)
			{
				int index;
				num = (index = num + 1);
				obj.onValueChanged.AddListener(delegate(bool value)
				{
					OnToggleValueChange(value, index);
				});
			}
		}

		private void OnToggleValueChange(bool value, int index)
		{
			if (value && index != 0)
			{
				continueButton.gameObject.SetActive(value: false);
				LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
				Language language = (Language)index;
				instance.ChangeLanguage(language.ToString());
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					continueButton.gameObject.SetActive(value: true);
				});
			}
		}

		private void OnContinue()
		{
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
			landingScreen.SetActive(value: false);
		}
	}
}
