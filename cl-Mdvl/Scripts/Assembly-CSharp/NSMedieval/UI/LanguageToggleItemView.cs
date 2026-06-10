using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Modding;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class LanguageToggleItemView : LayoutGroupItemView
	{
		private readonly int textIndex;

		private readonly int imageIndex = 1;

		private readonly int toggleIndex = 2;

		private readonly int modGroupIndex = 3;

		private string language;

		private ModManipulationLayout ModManipulationLayout => base.GroupItems[modGroupIndex].GetComponent<ModManipulationLayout>();

		public void SetData(string language, string localization, string imagePath, ModInstance modInstance = null)
		{
			this.language = language;
			SetText(textIndex, localization);
			if (!string.IsNullOrEmpty(imagePath))
			{
				SetImage(imageIndex, imagePath);
			}
			base.GroupItems[toggleIndex].GetComponent<CustomToggle>().SetIsOnWithoutNotify(language == MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageName());
			if (modInstance == null)
			{
				ModManipulationLayout.gameObject.SetActive(value: false);
				return;
			}
			ModManipulationLayout.gameObject.SetActive(value: true);
			ModManipulationLayout.SetData(modInstance);
		}

		private void OnToggleValueChanged(bool isOn)
		{
			if (isOn)
			{
				MonoSingleton<LocalizationController>.Instance.ChangeLanguage(language);
			}
		}

		private void Start()
		{
			base.GroupItems[toggleIndex].GetComponent<CustomToggle>().group = GetComponentInParent<ToggleGroup>();
			base.GroupItems[toggleIndex].GetComponent<CustomToggle>().onValueChanged.AddListener(OnToggleValueChanged);
		}
	}
}
