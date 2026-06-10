using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.UI.ScenarioEditor
{
	public class PresetLoadPopupView : CharacterEditPopupView
	{
		[SerializeField]
		private LayoutGroupView presetsListGroup;

		[SerializeField]
		private GameObject saveFooterGroup;

		[SerializeField]
		private GameObject loadFooterGroup;

		[SerializeField]
		private SafeTMP_InputField saveNameInput;

		[SerializeField]
		private SoundButton saveButton;

		[SerializeField]
		private SoundButton loadButton;

		[NonSerialized]
		private readonly List<CharacterPresetLoadItemView> presetItemViews = new List<CharacterPresetLoadItemView>();

		[NonSerialized]
		private WorkerInstancePreset currentPreset;

		private bool isSavePopup;

		private bool versionWarningShown;

		private List<WorkerInstancePreset> Presets
		{
			get
			{
				List<WorkerInstancePreset> list = new List<WorkerInstancePreset>();
				foreach (WorkerInstancePreset userPreset in Repository<CharacterPresetRepository, WorkerInstancePreset>.Instance.UserPresets)
				{
					if (!ApplicationVersionUtils.IsValidCharacterPresetVersion(userPreset.ModifiedOnVersion) || userPreset.Instance == null || userPreset.Instance.Info == null)
					{
						if (!versionWarningShown)
						{
							string messageText = MonoSingleton<LocalizationController>.Instance.GetText("obsolete_character_preset_message").Replace("<preset_name>", userPreset.Name);
							MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
							versionWarningShown = true;
						}
					}
					else
					{
						list.Add(userPreset);
					}
				}
				return list;
			}
		}

		protected override void Start()
		{
			base.Start();
			CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
			instance.ShowLoadPresetPopupAction = (Action)Delegate.Combine(instance.ShowLoadPresetPopupAction, new Action(ShowLoadPopup));
			CharacterEditController instance2 = MonoSingleton<CharacterEditController>.Instance;
			instance2.ShowSavePresetPopupAction = (Action)Delegate.Combine(instance2.ShowSavePresetPopupAction, new Action(ShowSavePopup));
			CharacterEditController instance3 = MonoSingleton<CharacterEditController>.Instance;
			instance3.HidePopupListAction = (Action)Delegate.Combine(instance3.HidePopupListAction, new Action(Hide));
			saveNameInput.onValueChanged.AddListener(delegate
			{
				RefreshButtons();
			});
			saveButton.onClick.AddListener(OnSaveButtonClick);
			loadButton.onClick.AddListener(OnLoadButtonClick);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
				instance.ShowLoadPresetPopupAction = (Action)Delegate.Remove(instance.ShowLoadPresetPopupAction, new Action(ShowLoadPopup));
				CharacterEditController instance2 = MonoSingleton<CharacterEditController>.Instance;
				instance2.ShowSavePresetPopupAction = (Action)Delegate.Remove(instance2.ShowSavePresetPopupAction, new Action(ShowSavePopup));
				CharacterEditController instance3 = MonoSingleton<CharacterEditController>.Instance;
				instance3.HidePopupListAction = (Action)Delegate.Remove(instance3.HidePopupListAction, new Action(Hide));
			}
		}

		private void RefreshButtons()
		{
			saveButton.interactable = saveNameInput.text.Length > 0;
			loadButton.interactable = Presets.Count > 0 && currentPreset != null;
		}

		private void ReloadList()
		{
			presetItemViews.SetAllActive(active: false);
			foreach (WorkerInstancePreset preset in Presets)
			{
				if (!(preset == null))
				{
					presetItemViews.GetNext(presetsListGroup).SetData(preset, DeleteEntryCallback(preset), OverwriteCallback(preset));
				}
			}
		}

		private UnityAction DeleteEntryCallback(WorkerInstancePreset item)
		{
			return delegate
			{
				Repository<CharacterPresetRepository, WorkerInstancePreset>.Instance.DeleteUserPreset(item);
				RefreshButtons();
				ReloadList();
				MonoSingleton<CharacterEditController>.Instance.NotifyCharacterUpdated();
			};
		}

		private UnityAction OverwriteCallback(WorkerInstancePreset preset)
		{
			return delegate
			{
				currentPreset = preset;
				RefreshButtons();
			};
		}

		private void OnLoadButtonClick()
		{
			Hide();
			MonoSingleton<CharacterEditController>.Instance.ApplyPreset(currentPreset);
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				currentPreset = null;
			});
		}

		private void OnSaveButtonClick()
		{
			HumanoidInstance selectedHumanoid = MonoSingleton<CharacterEditController>.Instance.SelectedHumanoid;
			Repository<CharacterPresetRepository, WorkerInstancePreset>.Instance.UpdateUserPreset(new WorkerInstancePreset(Guid.NewGuid().ToString(), saveNameInput.text, selectedHumanoid));
			saveNameInput.text = string.Empty;
			ReloadList();
			RefreshButtons();
			MonoSingleton<CharacterEditController>.Instance.NotifyCharacterUpdated();
		}

		private void ShowSavePopup()
		{
			isSavePopup = true;
			SetTitle(MonoSingleton<LocalizationController>.Instance.GetText("save_preset"));
			ShowPopup();
		}

		private void ShowLoadPopup()
		{
			isSavePopup = false;
			SetTitle(MonoSingleton<LocalizationController>.Instance.GetText("load_preset"));
			ShowPopup();
		}

		private void ShowPopup()
		{
			Show();
			loadFooterGroup.SetActive(!isSavePopup);
			saveFooterGroup.SetActive(isSavePopup);
			RefreshButtons();
			ReloadList();
		}
	}
}
