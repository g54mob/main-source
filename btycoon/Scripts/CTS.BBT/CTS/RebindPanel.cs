using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class RebindPanel : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _nameAction;

		[SerializeField]
		private List<TextMeshProUGUI> _listOfTextToChange;

		private LocalizeStringEvent _nameEvent;

		private void Awake()
		{
			_nameEvent = _nameAction.GetComponent<LocalizeStringEvent>();
			foreach (TextMeshProUGUI item in _listOfTextToChange)
			{
				item.text = _nameEvent.StringReference.GetLocalizedString();
			}
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			foreach (TextMeshProUGUI item in _listOfTextToChange)
			{
				item.text = _nameEvent.StringReference.GetLocalizedString();
			}
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
		}
	}
}
