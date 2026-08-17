using I2.Loc;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI;

public class ErrorPopup : BasePopup
{
	private TextMeshProUGUI _Description;

	private PopupManager _manager;

	public void Initialize(PopupManager manager, string id, string error, bool textIsLocalizationTerm = true)
	{
		_manager = manager;
		_ID = id;
		object obj = default(object);
		bool flag = obj == null;
		string text = error;
		if (!flag)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(error, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text = translation;
		}
		_Description.text = text;
	}
}
