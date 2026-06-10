using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Modding;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ModManipulationLayout : MonoBehaviour
	{
		[SerializeField]
		private SoundButton deleteButton;

		[SerializeField]
		private SoundButton editButton;

		[SerializeField]
		private SoundButton localFolderButton;

		[SerializeField]
		private SoundButton workshopOpenButton;

		[SerializeField]
		private SoundButton uploadButton;

		[SerializeField]
		private SoundButton updateButton;

		private ModInstance modInstance;

		public void SetData(ModInstance modInstance, Action onEditCallback = null)
		{
			this.modInstance = modInstance;
			if (onEditCallback != null && this.modInstance.Source == ModSource.Local)
			{
				editButton.AddCleanListener(onEditCallback.Invoke);
				editButton.gameObject.SetActive(value: true);
			}
			else
			{
				editButton.gameObject.SetActive(value: false);
			}
			localFolderButton.gameObject.SetActive(value: true);
			deleteButton.gameObject.SetActive(value: true);
			uploadButton.gameObject.SetActive(value: false);
			updateButton.gameObject.SetActive(value: false);
			workshopOpenButton.gameObject.SetActive(value: false);
			if (!MonoSingleton<EulaManager>.Instance.EulaAccepted)
			{
				return;
			}
			switch (modInstance.Source)
			{
			case ModSource.Workshop:
				if (MonoSingleton<SteamSdkManager>.IsInstantiated() && SteamSdkManager.IsSteamInitialised)
				{
					workshopOpenButton.gameObject.SetActive(value: true);
				}
				break;
			case ModSource.Local:
				OnWorkshopItemAuthorEvent(modInstance.WorkshopPublishedFileId, MonoSingleton<SteamWorkshopManager>.Instance.IsWorkshopItemAuthor(modInstance));
				break;
			}
		}

		private void OnWorkshopItemAuthorEvent(ulong publishedFileId, bool isAuthor)
		{
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised || publishedFileId != modInstance.WorkshopPublishedFileId)
			{
				return;
			}
			if (isAuthor)
			{
				updateButton.interactable = true;
				updateButton.gameObject.SetActive(value: true);
				workshopOpenButton.gameObject.SetActive(value: true);
				workshopOpenButton.AddCleanListener(delegate
				{
					MonoSingleton<SteamWorkshopManager>.Instance.OpenWorkshopPage(publishedFileId);
				});
				uploadButton.gameObject.SetActive(value: false);
			}
			else
			{
				uploadButton.interactable = true;
				uploadButton.gameObject.SetActive(value: true);
				updateButton.gameObject.SetActive(value: false);
				workshopOpenButton.gameObject.SetActive(value: false);
			}
		}

		private void OnItemDeleteEvent()
		{
			string key = ((modInstance.Source == ModSource.Local) ? "delete_local_mod_prompt" : "delete_remote_mod_prompt");
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(MonoSingleton<LocalizationController>.Instance.GetText(key), new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", OnItemDelete),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			}));
		}

		private void OnWorkshopItemUnsubscribeEvent()
		{
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(MonoSingleton<LocalizationController>.Instance.GetText("steam_workshop_unsubscribe_prompt"), new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					MonoSingleton<SteamWorkshopManager>.Instance.UnsubscribeFromWorkshopItem(modInstance.WorkshopPublishedFileId);
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			}));
		}

		private void OnWorkshopUpdateModButtonClick()
		{
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(MonoSingleton<LocalizationController>.Instance.GetText("steam_workshop_upload_prompt"), new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					MonoSingleton<SteamWorkshopManager>.Instance.UpdateMod(modInstance);
					updateButton.interactable = false;
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			}));
		}

		private void OnWorkshopUploadModButtonClick()
		{
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(MonoSingleton<LocalizationController>.Instance.GetText("steam_workshop_upload_prompt"), new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", delegate
				{
					MonoSingleton<SteamWorkshopManager>.Instance.CreateWorkshopItem(modInstance);
					uploadButton.interactable = false;
				}),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			}));
		}

		private void Start()
		{
			deleteButton.onClick.AddListener(OnItemDeleteEvent);
			localFolderButton.onClick.AddListener(OnOpenLocalFolderClick);
			updateButton.onClick.AddListener(OnWorkshopUpdateModButtonClick);
			uploadButton.onClick.AddListener(OnWorkshopUploadModButtonClick);
			workshopOpenButton.onClick.AddListener(OnOpenWorkshopItemClick);
		}

		private void OnOpenLocalFolderClick()
		{
			ModdingUtils.OpenFolderInExplorer(modInstance.RootFolderPath);
		}

		private void OnOpenWorkshopItemClick()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.OpenWorkshopPage(modInstance.WorkshopPublishedFileId);
		}

		private void OnItemDelete()
		{
			if (modInstance.Source == ModSource.Workshop)
			{
				OnWorkshopItemUnsubscribeEvent();
			}
			MonoSingleton<ModManager>.Instance.DeleteMod(modInstance.SystemId);
		}

		private void OnEnable()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemAuthorEvent += OnWorkshopItemAuthorEvent;
		}

		private void OnDisable()
		{
			if (MonoSingleton<SteamWorkshopManager>.IsInstantiated())
			{
				MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemAuthorEvent -= OnWorkshopItemAuthorEvent;
			}
		}
	}
}
