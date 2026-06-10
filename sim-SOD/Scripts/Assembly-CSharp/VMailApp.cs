using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VMailApp : CruncherAppContent
{
	public class VmailParsingData
	{
		public StateSaveData.MessageThreadSave thread;

		public int messageIndex;
	}

	public ComputerOSMultiSelect vmailList;

	public ComputerOSMultiSelectElement selectedVmailElement;

	private StateSaveData.MessageThreadSave selectedThread;

	public TextMeshProUGUI vmailHeaderText;

	public TextMeshProUGUI vmailBodyText;

	public Button nextPageButton;

	public Button prevPageButton;

	public Human emailSender;

	public Human emailReciever;

	public string emailTextContent;

	private DDSSaveClasses.DDSTreeSave tree;

	private StateSaveData.MessageThreadSave thread;

	private int msgIndex;

	public Sprite sentIcon;

	public Sprite receivedIcon;

	public override void OnSetup()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpdatedSelection()
	{
	}

	public void SetSelectedVmail(ComputerOSMultiSelectElement newSelection)
	{
	}

	public void NextButton()
	{
	}

	public void PrevButton()
	{
	}

	public void ExitButton()
	{
	}

	public override void PrintButton()
	{
	}
}
