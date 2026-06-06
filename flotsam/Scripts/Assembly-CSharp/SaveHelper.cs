using M4.Session;
using UnityEngine;

public class SaveHelper : MonoBehaviour
{
	[SerializeField]
	private SaveAsWindow _saveAsWindow;

	private SaveInfo _cachedSave;

	public void Save()
	{
		if (Session.Profile.ActiveRun.TryGetLastSave(out _cachedSave))
		{
			SaveDialogProperties saveDialogProperties = Object.Instantiate(GameManager.Settings.UISettings.OverwriteSaveProperties);
			saveDialogProperties.Initialize(_cachedSave);
			if (PopUpDialog.Instance.TryOpenPopUpDialog(saveDialogProperties))
			{
				PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleOverwriteDialog);
			}
		}
		else
		{
			_saveAsWindow.Open();
		}
	}

	private void HandleOverwriteDialog(bool overwrite)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleOverwriteDialog);
		if (overwrite)
		{
			Session.Profile.ActiveRun.Save(_cachedSave);
		}
	}
}
