using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UIThemeAttractedHuman : MonoBehaviour
	{
		[SerializeField]
		private List<TMP_Text> _peopleAttractedText;

		[SerializeField]
		private LocalizedString _blockText;

		private List<LocalizedString> _currentListAttractedHuman;

		private void Awake()
		{
			if (MonoSingleton<ThemeManager>.Instance != null)
			{
				HumanAttracted(MonoSingleton<ThemeManager>.Instance.CurrentHumanAttracted, MonoSingleton<ThemeManager>.Instance.CurrentSelectedTheme.IsLocked);
			}
			ThemeManager.OnStyleHumanAttractedChange += HumanAttracted;
		}

		private void HumanAttracted(List<LocalizedString> obj, bool obj2)
		{
			if (obj == null || obj.Count <= 0)
			{
				return;
			}
			if (obj2)
			{
				foreach (TMP_Text item in _peopleAttractedText)
				{
					item.text = "";
				}
				_peopleAttractedText[1].text = _blockText.GetLocalizedString();
				return;
			}
			if (_currentListAttractedHuman != obj)
			{
				_currentListAttractedHuman = obj;
			}
			for (int i = 0; i < _peopleAttractedText.Count; i++)
			{
				string text = "";
				if (obj[i] != null)
				{
					text = obj[i].GetLocalizedString();
				}
				if (text.StartsWith("No translation"))
				{
					text = "";
				}
				_peopleAttractedText[i].text = text;
			}
		}

		private void OnDestroy()
		{
			ThemeManager.OnStyleHumanAttractedChange -= HumanAttracted;
		}
	}
}
