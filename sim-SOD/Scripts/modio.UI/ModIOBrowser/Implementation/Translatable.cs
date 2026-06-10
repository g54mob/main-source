using ModIO.Util;
using Plugins.mod.io.UI.Translations;
using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	internal class Translatable : MonoBehaviour, ITranslatable
	{
		private const TranslatedLanguages EditorLanguage = TranslatedLanguages.English;

		private const bool AddTextIfItDoesntExist = true;

		public string reference;

		public TextMeshProUGUI text;

		public TranslatedLanguageFontPairings translatedLanguageFontPairingOverrides;

		private SimpleMessageUnsubscribeToken subToken;

		public string Identifier => null;

		public string TransformPath => null;

		public string GetReference()
		{
			return null;
		}

		public void SetTranslation(string s)
		{
		}

		public void MarkAsUntranslated()
		{
		}

		private void Awake()
		{
		}

		public void Start()
		{
		}

		private void ApplyTranslation()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
