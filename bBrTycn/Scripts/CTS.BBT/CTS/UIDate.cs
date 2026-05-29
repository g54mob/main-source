using CTS.BBT;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class UIDate : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _textMesh;

		private void Awake()
		{
			_textMesh = GetComponent<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
			SceneReset.Reset += UpdateText;
			CalendarHandlers.NewDay += UpdateText;
			LocalizationSettings.SelectedLocaleChanged += UpdateText;
			CalendarHandlers.CalendarLoaded += CalendarHandlers_CalendarLoaded;
		}

		private void OnDisable()
		{
			SceneReset.Reset -= UpdateText;
			CalendarHandlers.NewDay -= UpdateText;
			LocalizationSettings.SelectedLocaleChanged -= UpdateText;
			CalendarHandlers.CalendarLoaded -= CalendarHandlers_CalendarLoaded;
		}

		private void CalendarHandlers_CalendarLoaded()
		{
			UpdateText();
		}

		private void UpdateText()
		{
			if ((bool)MonoSingleton<CalendarHandlers>.Instance)
			{
				_textMesh.text = MonoSingleton<CalendarHandlers>.Instance.GetFullDateString();
			}
		}

		private void UpdateText(Locale value)
		{
			if ((bool)MonoSingleton<CalendarHandlers>.Instance)
			{
				_textMesh.text = MonoSingleton<CalendarHandlers>.Instance.GetFullDateString();
			}
		}
	}
}
