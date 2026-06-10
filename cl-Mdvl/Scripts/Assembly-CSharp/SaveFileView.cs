using System;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval;
using NSMedieval.Controllers;
using NSMedieval.Modding;
using NSMedieval.State;
using NSMedieval.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveFileView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text saveFileName;

	[SerializeField]
	private TMP_Text lastPlayed;

	[SerializeField]
	private SoundButton deleteFileButton;

	[SerializeField]
	private SoundButton overwriteFileButton;

	[SerializeField]
	private SoundButton profileClickButton;

	[SerializeField]
	private BasicLayoutItemView warningIcon;

	[SerializeField]
	private BasicLayoutItemView modWarningIcon;

	[SerializeField]
	private Image selectedImage;

	[SerializeField]
	private TooltipViewNew tooltip;

	private VillageSaveInfo saveInfo;

	private bool listenersDone;

	private bool selected;

	private bool tooltipDone;

	private Action<VillageSaveInfo> overwriteProfileAction;

	private Action<VillageSaveInfo> deleteProfileAction;

	private Action<VillageSaveInfo> selectProfileAction;

	private Action<VillageSaveInfo> loadProfileAction;

	private float timeAfterFirstclick;

	private const float timeForDoubleClick = 1f;

	private static StringBuilder stringBuilder = new StringBuilder();

	public VillageSaveInfo Profile => saveInfo;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnDomainReload()
	{
		if (stringBuilder == null)
		{
			stringBuilder = new StringBuilder();
		}
	}

	public void Hide()
	{
		saveInfo = null;
		tooltip.ExecuteOnShow = null;
		if (MonoSingleton<SceneController>.IsInstantiated())
		{
			MonoSingleton<SceneController>.Instance.Tick -= OnTick;
		}
	}

	private void OnDestroy()
	{
		saveInfo = null;
		if (tooltip != null)
		{
			tooltip.ExecuteOnShow = null;
		}
		if (MonoSingleton<SceneController>.IsInstantiated())
		{
			MonoSingleton<SceneController>.Instance.Tick -= OnTick;
		}
		overwriteProfileAction = null;
		deleteProfileAction = null;
		selectProfileAction = null;
		loadProfileAction = null;
	}

	public void Setup(VillageSaveInfo saveInfo, Action<VillageSaveInfo> overwriteProfileAction, Action<VillageSaveInfo> deleteProfileAction, Action<VillageSaveInfo> selectProfileAction, Action<VillageSaveInfo> loadProfileAction)
	{
		this.overwriteProfileAction = overwriteProfileAction;
		this.deleteProfileAction = deleteProfileAction;
		this.selectProfileAction = selectProfileAction;
		this.loadProfileAction = loadProfileAction;
		TryInitListeners();
		this.saveInfo = saveInfo;
		tooltipDone = false;
		warningIcon.gameObject.SetActive(saveInfo.IsObsolete);
		CheckEnabledMods();
		string text = saveInfo.FileName;
		if (saveInfo.IsObsolete)
		{
			text = "<style=DefaultRed>" + text + "</style>";
		}
		saveFileName.SetText(text);
		string text2 = saveInfo.LastPlayedLocalizedString + " (v" + saveInfo.ModifiedVersion + ")";
		if (saveInfo.IsObsolete)
		{
			text2 = "<style=DefaultRed>" + text2 + "</style>";
		}
		lastPlayed.SetText(text2);
		overwriteFileButton.gameObject.SetActive(overwriteProfileAction != null);
		MonoSingleton<SceneController>.Instance.Tick += OnTick;
		if ((bool)tooltip)
		{
			tooltip.ExecuteOnShow = OnShowTooltip;
		}
	}

	private void CheckEnabledMods()
	{
		VillageSaveMeta meta = saveInfo.Meta;
		if (meta == null || meta.Mods == null || meta.Mods.Count == 0)
		{
			if (modWarningIcon.gameObject.activeSelf)
			{
				modWarningIcon.gameObject.SetActive(value: false);
			}
			return;
		}
		bool flag = false;
		foreach (string mod in meta.Mods)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(23, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\SaveFileView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Checking mod ");
				messageBuilder.AppendFormatted(mod);
				messageBuilder.AppendLiteral(" enabled: ");
				messageBuilder.AppendFormatted(MonoSingleton<ModManager>.Instance.IsModEnabled(mod));
			}
			Log.Trace(messageBuilder);
			if (!MonoSingleton<ModManager>.Instance.IsModEnabled(mod))
			{
				flag = true;
				break;
			}
		}
		modWarningIcon.gameObject.SetActive(value: true);
		if (flag)
		{
			modWarningIcon.Icon.color = Color.yellow;
		}
		else
		{
			modWarningIcon.Icon.color = Color.white;
		}
	}

	private void TryInitListeners()
	{
		if (overwriteFileButton != null && overwriteProfileAction != null)
		{
			overwriteFileButton.onClick.RemoveAllListeners();
			overwriteFileButton.onClick.AddListener(delegate
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\SaveFileView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Overwrite file clicked ");
					messageBuilder.AppendFormatted(saveInfo.FolderName);
					messageBuilder.AppendLiteral("/");
					messageBuilder.AppendFormatted(saveInfo.FileName);
				}
				Log.Info(messageBuilder);
				overwriteProfileAction(saveInfo);
			});
		}
		if (deleteFileButton != null && deleteProfileAction != null)
		{
			deleteFileButton.onClick.RemoveAllListeners();
			deleteFileButton.onClick.AddListener(delegate
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\SaveFileView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Delete file clicked ");
					messageBuilder.AppendFormatted(saveInfo.FolderName);
					messageBuilder.AppendLiteral("/");
					messageBuilder.AppendFormatted(saveInfo.FileName);
				}
				Log.Info(messageBuilder);
				deleteProfileAction(saveInfo);
			});
		}
		if (profileClickButton != null && selectProfileAction != null)
		{
			profileClickButton.onClick.RemoveAllListeners();
			profileClickButton.onClick.AddListener(OnProfileClick);
		}
	}

	private void OnProfileClick()
	{
		bool isEnabled;
		FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\SaveFileView.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("Select profile clicked ");
			messageBuilder.AppendFormatted(saveInfo.FolderName);
			messageBuilder.AppendLiteral("/");
			messageBuilder.AppendFormatted(saveInfo.FileName);
		}
		Log.Info(messageBuilder);
		if (loadProfileAction == null)
		{
			selectProfileAction(saveInfo);
		}
		else if (timeAfterFirstclick <= 0f)
		{
			timeAfterFirstclick = 1f;
			selectProfileAction(saveInfo);
		}
		else if (selected && timeAfterFirstclick > 0f)
		{
			loadProfileAction(saveInfo);
		}
	}

	private void OnTick(float deltaTime)
	{
		if (!(timeAfterFirstclick <= 0f))
		{
			timeAfterFirstclick -= ((deltaTime == 0f) ? 0.02f : deltaTime);
		}
	}

	public void SetSelected(bool selected)
	{
		this.selected = selected;
		selectedImage.enabled = selected;
	}

	public void SetProfile(VillageSaveInfo newSave)
	{
		saveInfo = newSave;
		tooltipDone = false;
		saveFileName.SetText(newSave.FileName);
		lastPlayed.SetText(newSave.LastPlayedLocalizedString);
	}

	private void OnShowTooltip()
	{
		if (tooltipDone)
		{
			return;
		}
		tooltipDone = true;
		tooltip.ClearLines();
		VillageSaveMeta villageSaveMeta = saveInfo?.Meta;
		if (villageSaveMeta == null)
		{
			return;
		}
		stringBuilder.Clear();
		if (villageSaveMeta.Mods != null && villageSaveMeta.Mods.Count > 0)
		{
			modWarningIcon.gameObject.SetActive(value: true);
			bool flag = false;
			foreach (string mod in villageSaveMeta.Mods)
			{
				if (!MonoSingleton<ModManager>.Instance.IsModEnabled(mod))
				{
					flag = true;
					break;
				}
			}
			tooltip.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mods_present"), TooltipStyles.TooltipTitle);
			if (flag)
			{
				tooltip.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mods_in_save_warning"), TooltipStyles.TooltipDescriptionLine);
			}
			tooltip.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mods_currently_enabled"), TooltipStyles.TooltipSubtitleLineStyle);
			if (MonoSingleton<ModManager>.Instance.EnabledMods.Count > 0)
			{
				foreach (string key in MonoSingleton<ModManager>.Instance.EnabledMods.Keys)
				{
					tooltip.AppendLine(key);
				}
			}
			else
			{
				tooltip.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("general_none"));
			}
			tooltip.AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("mods_from_save"), TooltipStyles.TooltipSubtitleLineStyle);
			foreach (string mod2 in villageSaveMeta.Mods)
			{
				string lineStyle = TooltipStyles.DefaultGreen;
				if (!MonoSingleton<ModManager>.Instance.IsModEnabled(mod2))
				{
					lineStyle = TooltipStyles.DefaultRed;
				}
				tooltip.AppendLine(mod2, lineStyle);
			}
			if (flag)
			{
				modWarningIcon.Icon.color = Color.yellow;
			}
			else
			{
				modWarningIcon.Icon.color = Color.white;
			}
		}
		else
		{
			modWarningIcon.gameObject.SetActive(value: false);
		}
		if (stringBuilder.Length > 0)
		{
			tooltip.AppendLine(stringBuilder.ToString());
		}
	}
}
