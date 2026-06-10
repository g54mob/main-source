using System;
using System.Collections.Generic;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Modding;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ModLoaderView : ClosableUIView
	{
		private const ModTag AllowedTags = ModTag.General;

		[SerializeField]
		private SoundButton[] closeButtons;

		[SerializeField]
		private LayoutGroupView modsGroup;

		[SerializeField]
		private GameObject previewParent;

		[SerializeField]
		private Image previewImage;

		[SerializeField]
		private TMP_Text previewTitle;

		[SerializeField]
		private TMP_Text previewDescription;

		[SerializeField]
		private ModManipulationLayout modManipulationLayout;

		[SerializeField]
		private SoundButton getWorkshopModsButton;

		[SerializeField]
		private SoundButton createEmptyModButton;

		private readonly List<ModItemView> modItemViews = new List<ModItemView>();

		private string selectedMod;

		private void Awake()
		{
			SoundButton[] array = closeButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].onClick.AddListener(OnClose);
			}
			OnAwakeWorkshop();
		}

		private void OnEnable()
		{
			MonoSingleton<ModManager>.Instance.ModsChangedEvent += ModsChangedEvent;
		}

		private void OnDisable()
		{
			if (MonoSingleton<ModManager>.IsInstantiated())
			{
				MonoSingleton<ModManager>.Instance.ModsChangedEvent -= ModsChangedEvent;
			}
		}

		public override void Show()
		{
			base.Show();
			ShowPreview(string.Empty, show: false);
			Refresh();
		}

		private void Refresh()
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			pooledList.AddRange(MonoSingleton<ModManager>.Instance.EnabledMods.Keys);
			pooledList.AddRange(MonoSingleton<ModManager>.Instance.DisabledMods.Keys);
			if (pooledList.Count <= 0)
			{
				ShowPreview(string.Empty, show: false);
				modItemViews.SetAllActive(active: false);
				return;
			}
			int num = 0;
			foreach (string item in pooledList)
			{
				if (MonoSingleton<ModManager>.Instance.GetModInstance(item).Tag.HasFlag(ModTag.General))
				{
					ModItemView at = modItemViews.GetAt(modsGroup, num);
					at.SetData(item, ShowPreview);
					if (selectedMod == item)
					{
						at.Select(isOn: true);
					}
					num++;
				}
			}
			modItemViews.SetActiveFromIndex(num, active: false);
		}

		public void ShowPreview(string modName, bool show)
		{
			if (string.IsNullOrEmpty(modName) || !show)
			{
				selectedMod = string.Empty;
				previewParent.SetActive(value: false);
				return;
			}
			selectedMod = modName;
			previewParent.SetActive(value: true);
			ModInstance modInstance = MonoSingleton<ModManager>.Instance.GetModInstance(modName);
			ModdingUtils.OnWorkshopShowPreview(modInstance, modManipulationLayout);
			previewImage.sprite = modInstance.PreviewSprite;
			previewTitle.SetText(modInstance.ModModel.Name);
			previewDescription.SetText(GetPreviewDescription(modInstance));
		}

		private string GetPreviewDescription(ModInstance modInstance)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mod_id") + ": " + modInstance.ModModel.Id);
			stringBuilder.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mod_author") + ": " + modInstance.ModModel.Author);
			stringBuilder.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mod_version") + ": " + modInstance.ModModel.ModVersion);
			stringBuilder.AppendLine(GetGameVersion(modInstance) ?? "");
			stringBuilder.AppendLine(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("mod_tags"), modInstance.Tag));
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine(modInstance.ModModel.Description);
			return stringBuilder.ToString();
		}

		private static string GetGameVersion(ModInstance modInstance)
		{
			if (modInstance.Source != ModSource.Workshop)
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("mod_game_version") + ": " + modInstance.ModModel.GameVersion;
			}
			string styleName = (MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersion.HasValidVersion(modInstance.WorkshopPublishedFileId) ? TooltipStyles.TooltipDefault : TooltipStyles.DefaultOrange);
			return GetWorkshopVersion(modInstance).ToStyled(styleName);
		}

		private static string GetWorkshopVersion(ModInstance modInstance)
		{
			var (text, text2) = MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersion.GetMinMaxVersion(modInstance.WorkshopPublishedFileId);
			if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(text2))
			{
				return "workshop_version_not_set".ToLocalized();
			}
			if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
			{
				return "workshop_version_max_older".ToLocalized().Replace("{max}", text2);
			}
			if (!string.IsNullOrEmpty(text) && string.IsNullOrEmpty(text2))
			{
				return "workshop_version_min_newer".ToLocalized().Replace("{min}", text);
			}
			if (text == text2)
			{
				return "workshop_version_single".ToLocalized().Replace("{min}", text).Replace("{max}", text2);
			}
			return "workshop_version_range".ToLocalized().Replace("{min}", text).Replace("{max}", text2);
		}

		private void ModsChangedEvent()
		{
			Refresh();
		}

		private void OnClose()
		{
			MonoSingleton<ModManager>.Instance.OnEditComplete();
			CloseSelf();
		}

		private void OnCreateNew()
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), OnCreateDefaultTemplate),
				new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("create_new_mod_template", buttonActions));
		}

		private void OnCreateDefaultTemplate()
		{
			ModdingUtils.CreateDefaultTemplate();
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
			{
				string folderPath = ModdingUtils.GetDefaultTemplateModPath();
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

		private void OnAwakeWorkshop()
		{
			createEmptyModButton.onClick.AddListener(OnCreateNew);
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				getWorkshopModsButton.gameObject.SetActive(value: false);
				modManipulationLayout.gameObject.SetActive(value: false);
				return;
			}
			modManipulationLayout.gameObject.SetActive(value: true);
			getWorkshopModsButton.gameObject.SetActive(value: true);
			getWorkshopModsButton.onClick.AddListener(delegate
			{
				MonoSingleton<SteamWorkshopManager>.Instance.GetMods(new string[1] { ModTag.General.ToString() });
			});
		}
	}
}
