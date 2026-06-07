using M4.Session;
using TMPro;
using UnityEngine;

public class SaveAsSlot : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private TextMeshProUGUI _date;

	[SerializeField]
	private TextMeshProUGUI _version;

	[SerializeField]
	private TextMeshProUGUI _drifterCount;

	[SerializeField]
	private TextMeshProUGUI _dayCount;

	[SerializeField]
	private GameObject _autoSaveIndicator;

	[SerializeField]
	private GameObject _incompatibleVersion;

	private SaveInfo _save;

	public void Initialize(SaveInfo save)
	{
		base.gameObject.SetActive(value: true);
		_save = save;
		UpdateInfo(_save);
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.SaveOverwritten, OnSaveOverwrite);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.SaveOverwritten, OnSaveOverwrite);
	}

	private void OnSaveOverwrite(GameEvent gameEvent)
	{
		if (gameEvent is SaveEvent saveEvent)
		{
			UpdateInfo(saveEvent.Save);
		}
	}

	private void UpdateInfo(SaveInfo save)
	{
		if (_save != null && _save == save)
		{
			_name.text = _save.Name;
			_date.text = _save.TimeStamp.ToString();
			_version.text = _save.GameVersion.ToString();
			_drifterCount.text = _save.DrifterCount.ToString();
			_dayCount.text = _save.Day.ToString();
			_autoSaveIndicator.SetActive(_save.Type == SaveType.Autosave);
			_incompatibleVersion.SetActive(GameManager.Settings.Version.Save != _save.GameVersion.Save);
		}
	}

	public void Overwrite()
	{
		SaveDialogProperties saveDialogProperties = Object.Instantiate(GameManager.Settings.UISettings.OverwriteSaveProperties);
		saveDialogProperties.Initialize(_save);
		if (PopUpDialog.Instance.TryOpenPopUpDialog(saveDialogProperties))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleOverwriteDialog);
		}
	}

	private void HandleOverwriteDialog(bool overwrite)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleOverwriteDialog);
		Session.Profile.ActiveRun.Save(_save);
	}
}
