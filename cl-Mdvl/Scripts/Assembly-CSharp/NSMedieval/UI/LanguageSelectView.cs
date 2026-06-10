using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Modding;
using UnityEngine;

namespace NSMedieval.UI
{
	public class LanguageSelectView : ClosableUIView
	{
		[SerializeField]
		private SoundButton acceptButton;

		[SerializeField]
		private LayoutGroupView languageGroup;

		[SerializeField]
		private GameObject communityLanguagesBanner;

		[SerializeField]
		private SoundButton getModsButton;

		[SerializeField]
		private SoundButton createNewButton;

		private readonly List<LanguageToggleItemView> languageSelectViews = new List<LanguageToggleItemView>();

		private const ModTag AllowedTags = ModTag.Localization;

		private void UpdateLanguageList()
		{
			int num = 0;
			string[] names = Enum.GetNames(typeof(Language));
			foreach (string text in names)
			{
				if (!(text == "None"))
				{
					languageSelectViews.GetAt(languageGroup, num).SetData(text, base.Localize.GetText("menu_language_" + text), "");
					num++;
				}
			}
			communityLanguagesBanner.SetActive(value: false);
			if (!MonoSingleton<EulaManager>.Instance.EulaAccepted)
			{
				languageSelectViews.SetActiveFromIndex(num, active: false);
				return;
			}
			if (GetModLocalizations(out var languageMods))
			{
				communityLanguagesBanner.SetActive(value: true);
				communityLanguagesBanner.transform.SetSiblingIndex(Enum.GetNames(typeof(Language)).Length);
				foreach (LocalizationModInstance item in languageMods)
				{
					languageSelectViews.GetAt(languageGroup, num).SetData(item.LanguageName, item.LanguageName, "", item);
					num++;
				}
			}
			languageSelectViews.SetActiveFromIndex(num, active: false);
		}

		private bool GetModLocalizations(out List<LocalizationModInstance> languageMods)
		{
			languageMods = new List<LocalizationModInstance>();
			if (MonoSingleton<ModManager>.Instance.LocalizationMods.Count > 0)
			{
				languageMods.AddRange(MonoSingleton<ModManager>.Instance.LocalizationMods.Values);
				return true;
			}
			return false;
		}

		public override void Show()
		{
			base.Show();
			UpdateLanguageList();
		}

		private void OnAccept()
		{
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
			CloseSelf();
		}

		private void OnCreateNew()
		{
			if (ModdingUtils.RootFolderAccessible())
			{
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), ExportDefault),
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
					{
					})
				};
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("create_new_mod_loc_template", buttonActions));
			}
		}

		private void ExportDefault()
		{
			DefaultLocToCsv.Export();
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
			{
				string folderPath = ModdingUtils.GetLocalizationModPath("English Localization Mod");
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_ok"), delegate
					{
					}),
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_show"), delegate
					{
						ModdingUtils.OpenFolderInExplorer(folderPath);
					})
				};
				string promptText = MonoSingleton<LocalizationController>.Instance.GetText("new_mod_created").Replace("<path>", folderPath);
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(promptText, buttonActions));
			});
		}

		private void Start()
		{
			acceptButton.onClick.AddListener(OnAccept);
			createNewButton.onClick.AddListener(OnCreateNew);
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				getModsButton.gameObject.SetActive(value: false);
			}
		}

		private void OnWorkshopClick()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.GetMods(new string[1] { ModTag.Localization.ToString() });
		}

		private void OnEulaStatusChanged(bool accepted)
		{
			if (accepted)
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent -= OnEulaStatusChanged;
				getModsButton.AddCleanListener(OnWorkshopClick);
				OnWorkshopClick();
				Show();
			}
		}

		private void OnEnable()
		{
			MonoSingleton<ModManager>.Instance.ModsChangedEvent += Show;
			if (MonoSingleton<EulaManager>.Instance.EulaAccepted)
			{
				getModsButton.gameObject.SetActive(value: true);
				getModsButton.AddCleanListener(OnWorkshopClick);
			}
			else
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent += OnEulaStatusChanged;
				getModsButton.AddCleanListener(MonoSingleton<EulaManager>.Instance.ShowPrompt);
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<ModManager>.IsInstantiated())
			{
				MonoSingleton<ModManager>.Instance.ModsChangedEvent -= Show;
			}
			if (MonoSingleton<EulaManager>.IsInstantiated())
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent -= OnEulaStatusChanged;
			}
		}
	}
}
