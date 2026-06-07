using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace I2.Loc
{
	public class LocalizeFontSize : MonoBehaviour
	{
		[Serializable]
		internal struct Override
		{
			[SerializeField]
			internal string languageCode;

			[SerializeField]
			internal int fontSize;

			[SerializeField]
			internal int fontSizeMin;

			[SerializeField]
			internal int fontSizeMax;
		}

		[SerializeField]
		private List<Override> _overrides;

		private bool _initialized;

		private ILocalizeFontSizeBehaviour _behaviour;

		private bool Initialize()
		{
			if (_initialized)
			{
				return true;
			}
			_behaviour = ReturnBehaviour();
			if (_behaviour == null)
			{
				return false;
			}
			_initialized = true;
			return true;
		}

		private void OnEnable()
		{
			if (Initialize())
			{
				ApplyOverride();
				LocalizationManager.OnLocalizeEvent += ApplyOverride;
			}
			else
			{
				Debug.LogWarning("LocalizeFontSize could not be initialized (missing Text or TextMeshProUGUI?)! Destroying it.");
				UnityEngine.Object.Destroy(this);
			}
		}

		private void OnDisable()
		{
			LocalizationManager.OnLocalizeEvent -= ApplyOverride;
		}

		public void ApplyOverride()
		{
			if (_behaviour == null)
			{
				return;
			}
			string currentLanguageCode = LocalizationManager.CurrentLanguageCode;
			foreach (Override @override in _overrides)
			{
				if (@override.languageCode == currentLanguageCode)
				{
					_behaviour.ApplyOverride(@override);
					break;
				}
			}
		}

		private ILocalizeFontSizeBehaviour ReturnBehaviour()
		{
			Text component = GetComponent<Text>();
			if ((bool)component)
			{
				return new LocalizeTextFontSize(component);
			}
			TMP_Text component2 = GetComponent<TMP_Text>();
			if ((bool)component2)
			{
				return new LocalizeTextMeshProFontSize(component2);
			}
			return null;
		}
	}
}
