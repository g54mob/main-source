using TMPro;
using UnityEngine;

public class CommunitySaveGroupOverviewSlot : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _saveName;

	[SerializeField]
	private TextMeshProUGUI _versionName;

	[SerializeField]
	private TextMeshProUGUI _date;

	[SerializeField]
	private TextMeshProUGUI _drifterCount;

	[SerializeField]
	private TextMeshProUGUI _dayCount;

	[SerializeField]
	private GameObject _autoSaveIndicator;

	[SerializeField]
	private GameObject _incompatibleVersion;

	[SerializeField]
	private DialogProperties _incompatibleSaveDialog;

	[SerializeField]
	private DialogProperties _removeConfirmationDialog;

	private PlayerRun _run;

	public SaveInfo Save { get; private set; }

	public void Activate(PlayerRun run, SaveInfo saveInfo)
	{
		base.gameObject.SetActive(value: true);
		Save = saveInfo;
		_run = run;
		if (saveInfo.Type == SaveType.Autosave && Application.isEditor)
		{
			_saveName.text = saveInfo.Name + " (" + run.CommunityName + ")";
		}
		else
		{
			_saveName.text = saveInfo.Name;
		}
		_versionName.text = saveInfo.GameVersion.ToString();
		_date.text = saveInfo.TimeStamp.ToString();
		_drifterCount.text = saveInfo.DrifterCount.ToString();
		_dayCount.text = saveInfo.Day.ToString();
		_autoSaveIndicator.SetActive(saveInfo.Type == SaveType.Autosave);
		_incompatibleVersion.SetActive(GameManager.Settings.Version.Save != saveInfo.GameVersion.Save);
	}

	public void Load()
	{
		if (GameManager.Settings.Version.Save == Save.GameVersion.Save)
		{
			LoadCurrentSave();
		}
		else if (PopUpDialog.Instance.TryOpenPopUpDialog(_incompatibleSaveDialog))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleIncompatibleSaveDialog);
		}
	}

	public void Remove()
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(_removeConfirmationDialog))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleRemoveConfirmationDialog);
		}
	}

	private void HandleIncompatibleSaveDialog(bool result)
	{
		if (result)
		{
			LoadCurrentSave();
		}
	}

	private void HandleRemoveConfirmationDialog(bool result)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleRemoveConfirmationDialog);
		if (result)
		{
			_run.RemoveSave(Save);
		}
	}

	private void LoadCurrentSave()
	{
		_run.Continue(Save);
	}
}
