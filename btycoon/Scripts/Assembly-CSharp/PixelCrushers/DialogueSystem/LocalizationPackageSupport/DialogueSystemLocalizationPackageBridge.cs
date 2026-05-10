using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace PixelCrushers.DialogueSystem.LocalizationPackageSupport
{
	[AddComponentMenu("Pixel Crushers/Dialogue System/UI/Misc/Dialogue System Localization Package Bridge")]
	public class DialogueSystemLocalizationPackageBridge : MonoBehaviour
	{
		[Tooltip("Assign string tables that contain dialogue translations to this list.")]
		public List<LocalizedStringTable> localizedStringTables;

		[Tooltip("Default locale that game starts in.")]
		public Locale defaultLocale;

		[Tooltip("Title of dialogue entry field that corresponds to key in string table.")]
		public string uniqueFieldTitle = "Guid";

		[Tooltip("When Dialogue System attempts to localize non-dialogue text, use localized string tables instead of Dialogue System's default behavior of using Text Table assets.")]
		public bool replaceGetLocalizedText;

		[Tooltip("Update onscreen dialogue UI as soon as locale changes, not on next line. Limitation: Works with standard dialogue UI in single conversations (not simultaneous conversations). Override UpdateDialogueUI add different behavior.")]
		public bool updateDialogueUIImmediately = true;

		protected List<StringTable> tables = new List<StringTable>();

		protected virtual IEnumerator Start()
		{
			yield return LocalizationSettings.InitializationOperation;
			yield return new WaitForEndOfFrame();
			CacheStringTables();
			UpdateActorDisplayNames();
			Localization.language = LocalizationSettings.SelectedLocale.Identifier.Code;
			LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;
			if (replaceGetLocalizedText && DialogueManager.instance.overrideGetLocalizedText == null)
			{
				DialogueManager.instance.overrideGetLocalizedText = GetLocalizedTextFromStringTables;
			}
		}

		protected virtual void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnSelectedLocaleChanged;
		}

		public virtual void CacheStringTables()
		{
			tables.Clear();
			foreach (LocalizedStringTable localizedStringTable in localizedStringTables)
			{
				if (localizedStringTable != null)
				{
					tables.Add(localizedStringTable.GetTable());
				}
			}
		}

		protected virtual void OnSelectedLocaleChanged(Locale locale)
		{
			if (Application.isPlaying)
			{
				CacheStringTables();
				UpdateActorDisplayNames();
				if (updateDialogueUIImmediately)
				{
					UpdateDialogueUI();
				}
				Localization.language = LocalizationSettings.SelectedLocale.Identifier.Code;
			}
		}

		public virtual void UpdateActorDisplayNames()
		{
			Locale selectedLocale = LocalizationSettings.SelectedLocale;
			Localization.language = selectedLocale.Identifier.Code;
			foreach (Actor actor in DialogueManager.masterDatabase.actors)
			{
				string text = actor.LookupValue(uniqueFieldTitle);
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				foreach (StringTable table in tables)
				{
					StringTableEntry stringTableEntry = table[text];
					if (stringTableEntry != null)
					{
						string field = ((selectedLocale == defaultLocale) ? "Display Name" : ("Display Name " + selectedLocale.Identifier.Code));
						DialogueLua.SetActorField(actor.Name, field, stringTableEntry.LocalizedValue);
						break;
					}
				}
			}
		}

		public virtual void OnBarkLine(Subtitle subtitle)
		{
			LocalizeSubtitle(subtitle);
		}

		public virtual void OnConversationLine(Subtitle subtitle)
		{
			LocalizeSubtitle(subtitle);
		}

		public virtual void LocalizeSubtitle(Subtitle subtitle)
		{
			if (string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				return;
			}
			string text = Field.LookupValue(subtitle.dialogueEntry.fields, uniqueFieldTitle);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			foreach (StringTable table in tables)
			{
				StringTableEntry stringTableEntry = table[text];
				if (stringTableEntry != null)
				{
					string localizedValue = stringTableEntry.LocalizedValue;
					subtitle.formattedText = FormattedText.Parse(localizedValue);
					break;
				}
			}
		}

		public virtual void OnConversationResponseMenu(Response[] responses)
		{
			foreach (Response response in responses)
			{
				string text = Field.LookupValue(response.destinationEntry.fields, uniqueFieldTitle);
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				foreach (StringTable table in tables)
				{
					StringTableEntry stringTableEntry = table[text + "_MenuText"];
					if (stringTableEntry != null)
					{
						response.formattedText = FormattedText.Parse(stringTableEntry.LocalizedValue);
						break;
					}
					stringTableEntry = table[text];
					if (stringTableEntry != null)
					{
						response.formattedText = FormattedText.Parse(stringTableEntry.LocalizedValue);
						break;
					}
				}
			}
		}

		protected virtual void UpdateDialogueUI()
		{
			if (!DialogueManager.IsConversationActive)
			{
				return;
			}
			StandardUIDialogueControls conversationUIElements = DialogueManager.standardDialogueUI.conversationUIElements;
			ConversationState currentConversationState = DialogueManager.currentConversationState;
			LocalizeSubtitle(currentConversationState.subtitle);
			DialogueActor dialogueActor;
			StandardUISubtitlePanel panel = conversationUIElements.standardSubtitleControls.GetPanel(currentConversationState.subtitle, out dialogueActor);
			panel.subtitleText.text = currentConversationState.subtitle.formattedText.text;
			if (panel.portraitName != null)
			{
				Actor actor = DialogueManager.masterDatabase.GetActor(currentConversationState.subtitle.speakerInfo.id);
				if (actor != null)
				{
					panel.portraitName.text = DialogueLua.GetLocalizedActorField(actor.Name, "Display Name").asString;
				}
			}
			if (conversationUIElements.defaultMenuPanel.isOpen)
			{
				OnConversationResponseMenu(currentConversationState.pcResponses);
				Transform target = ((conversationUIElements.defaultMenuPanel.instantiatedButtons.Count > 0) ? conversationUIElements.defaultMenuPanel.instantiatedButtons[0].GetComponent<StandardUIResponseButton>().target : conversationUIElements.defaultMenuPanel.buttons[0].target);
				conversationUIElements.defaultMenuPanel.ShowResponses(currentConversationState.subtitle, currentConversationState.pcResponses, target);
			}
		}

		protected virtual string GetLocalizedTextFromStringTables(string s)
		{
			foreach (StringTable table in tables)
			{
				StringTableEntry stringTableEntry = table[s];
				if (stringTableEntry != null)
				{
					return stringTableEntry.LocalizedValue;
				}
			}
			return s;
		}
	}
}
