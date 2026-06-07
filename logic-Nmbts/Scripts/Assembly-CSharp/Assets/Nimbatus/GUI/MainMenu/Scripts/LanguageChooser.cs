using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LanguageChooser : MonoBehaviour
	{
		public UILabel Label;

		internal string LanguageCode;

		internal List<string> Options;

		public void Start()
		{
			Options = LocalizationManager.GetAllLanguagesCode();
			LanguageCode = LocalizationManager.CurrentLanguageCode;
		}

		public void Update()
		{
			Label.text = LocalizationManager.GetLanguageFromCode(LanguageCode);
		}

		public void ToggleNextOption(bool right)
		{
			int num = 0;
			int num2 = Options.Count - 1;
			int num3 = Options.IndexOf(LanguageCode);
			num3 = ((!right) ? (num3 - 1) : (num3 + 1));
			if (num3 < num)
			{
				num3 = num2;
			}
			if (num3 > num2)
			{
				num3 = num;
			}
			LanguageCode = Options[num3];
			RuntimeGlobals.Settings.SelectedLanguage = LanguageCode;
			LocalizationManager.SetLanguageAndCode(LocalizationManager.GetLanguageFromCode(LanguageCode), LanguageCode);
		}
	}
}
