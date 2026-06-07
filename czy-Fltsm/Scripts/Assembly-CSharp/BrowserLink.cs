using UnityEngine;

public class BrowserLink : MonoBehaviour
{
	[SerializeField]
	private string _url = "";

	[SerializeField]
	private UIEvent.Type _uiEvent;

	public void OpenLinkDialog()
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(GameManager.Settings.UISettings.ExternalLinkDialogProperties))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(OnDialogClosed);
		}
	}

	private void OnDialogClosed(bool feedback)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(OnDialogClosed);
		if (feedback)
		{
			UIEvent.Dispatch(_uiEvent);
			Application.OpenURL(_url);
		}
	}
}
