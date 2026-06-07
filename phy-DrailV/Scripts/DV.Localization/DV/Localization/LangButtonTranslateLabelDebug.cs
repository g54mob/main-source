using I2.Loc;
using TMPro;
using UnityEngine;

namespace DV.Localization
{
	public class LangButtonTranslateLabelDebug : MonoBehaviour
	{
		private void Start()
		{
			string language = base.transform.parent.GetComponent<SetLanguageDebug>().GetLanguage();
			string translation = LocalizationManager.GetTranslation("lang_name_native", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, language);
			GetComponent<TextMeshProUGUI>().text = translation;
		}
	}
}
