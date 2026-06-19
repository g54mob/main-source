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

		private const bool AddTextIfItDoesntExist = false;

		public string reference;

		public TextMeshProUGUI text;

		public TranslatedLanguageFontPairings translatedLanguageFontPairingOverrides;

		private SimpleMessageUnsubscribeToken subToken;

		public string Identifier => base.gameObject.name;

		public string TransformPath => base.transform.FullPath();

		public string GetReference()
		{
			return reference;
		}

		public void SetTranslation(string s)
		{
			text.text = s;
		}

		public void MarkAsUntranslated()
		{
			text.text = "<color=\"red\">" + text.text + "</color>";
		}

		private void Awake()
		{
			subToken = SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Subscribe<MessageUpdateTranslations>(delegate
			{
				ApplyTranslation();
			});
			text.OnPreRenderText += delegate
			{
				ApplyTranslation();
			};
		}

		public void Start()
		{
			ApplyTranslation();
		}

		private void ApplyTranslation()
		{
			if (!SelfInstancingMonoSingleton<TranslationManager>.SingletonIsInstantiated())
			{
				return;
			}
			if (!string.IsNullOrEmpty(reference))
			{
				SelfInstancingMonoSingleton<TranslationManager>.Instance.Translate(this);
			}
			TranslatedLanguages selectedLanguage = SelfInstancingMonoSingleton<TranslationManager>.Instance.SelectedLanguage;
			if (translatedLanguageFontPairingOverrides != null)
			{
				TMP_FontAsset fontAsset = translatedLanguageFontPairingOverrides.GetFontAsset(selectedLanguage);
				if ((object)fontAsset != null)
				{
					text.font = fontAsset;
					return;
				}
			}
			TMP_FontAsset fontAsset2 = SelfInstancingMonoSingleton<TranslationManager>.Instance.defaultTranslatedLanguageFontPairings.GetFontAsset(selectedLanguage);
			if ((object)fontAsset2 != null)
			{
				text.font = fontAsset2;
			}
		}

		private void OnDestroy()
		{
			subToken.Unsubscribe();
		}
	}
}
