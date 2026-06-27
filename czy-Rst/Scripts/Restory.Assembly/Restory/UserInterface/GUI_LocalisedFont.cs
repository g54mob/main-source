using Restory.Gameplay.GameSettings.Observers;
using Restory.UserInterface.TextSizeModifiers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[DisallowMultipleComponent]
	public class GUI_LocalisedFont : MonoBehaviour
	{
		private static class Style
		{
			public const string TextComponentsGroup = "Text Components";
		}

		[SerializeField]
		private string sizeDebugString;

		[SerializeField]
		private Text targetText;

		[SerializeField]
		private TMP_Text textMeshProText;

		[SerializeField]
		private LocalisedFontData localisedFontData;

		[SerializeField]
		private bool isEnabled = true;

		private TMP_FontAsset defaultTMPFont;

		private Material defaultTMPFontMaterial;

		private GameSettingsLanguageChangeObserver gameSettingsManager;

		private TextSizeModifier.Factory textSizeModifiersFactory;

		private TextSizeModifier textSizeModifier;

		private LocalisedFontsMaterialsTable localisedFontsMaterialsTable;

		private void Awake()
		{
			if ((bool)textMeshProText)
			{
				defaultTMPFont = textMeshProText.font;
				defaultTMPFontMaterial = textMeshProText.fontSharedMaterial;
			}
			_ = (bool)localisedFontData;
		}

		[Inject]
		private void Construct(GameSettingsLanguageChangeObserver gameSettingsManager, TextSizeModifier.Factory textSizeModifiersFactory, LocalisedFontsMaterialsTable localisedFontsMaterialsTable)
		{
			this.gameSettingsManager = gameSettingsManager;
			this.textSizeModifiersFactory = textSizeModifiersFactory;
			this.localisedFontsMaterialsTable = localisedFontsMaterialsTable;
			CreateModifier();
			if (base.isActiveAndEnabled)
			{
				OnEnable();
			}
		}

		private void OnEnable()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.AddSubscriber(this, OnLocalisationChanged);
				OnLocalisationChanged(gameSettingsManager.Localization);
			}
			if (textSizeModifier != null)
			{
				textSizeModifier.OnEnable();
				textSizeModifier.OnUpdated -= UpdateDebugString;
				textSizeModifier.OnUpdated += UpdateDebugString;
			}
		}

		private void OnDisable()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.RemoveSubscriber(this);
			}
			if (textSizeModifier != null)
			{
				textSizeModifier.OnDisable();
				textSizeModifier.OnUpdated -= UpdateDebugString;
			}
		}

		private void OnDestroy()
		{
			textSizeModifier?.Dispose();
			textSizeModifier = null;
		}

		private void OnLocalisationChanged(SystemLanguage newLanguage)
		{
			if (!isEnabled)
			{
				return;
			}
			if (localisedFontData.FontsTMP.TryGetValue(newLanguage, out var value))
			{
				textMeshProText.font = value;
				if (localisedFontsMaterialsTable.TryGetMaterialByNewFontAndInitialSettings(defaultTMPFont, defaultTMPFontMaterial, value, out var targetMaterial))
				{
					textMeshProText.fontSharedMaterial = targetMaterial;
				}
			}
			else
			{
				textMeshProText.font = defaultTMPFont;
				textMeshProText.fontSharedMaterial = defaultTMPFontMaterial;
			}
		}

		private void CreateModifier()
		{
			if (!TryGetComponent<GUI_TextSizeModifier>(out var _))
			{
				if (textSizeModifier != null)
				{
					textSizeModifier.Dispose();
					textSizeModifier = null;
				}
				textSizeModifier = textSizeModifiersFactory.Create();
				textSizeModifier.Setup(textMeshProText, targetText);
			}
		}

		private void UpdateDebugString()
		{
		}
	}
}
