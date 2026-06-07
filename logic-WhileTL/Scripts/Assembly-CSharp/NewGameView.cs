using UnityEngine;
using UnityEngine.UI;

public class NewGameView : GameView
{
	[SceneBind("Layer")]
	private RectTransform Layer;

	[SceneBind("Delete")]
	private Button Delete;

	[SceneBind("CheckpointsMenu")]
	public CheckpointView checkpointView;

	[SceneBind("AttentionRewrite")]
	public RectTransform AttentionRewrite;

	[SceneBind("AttentionRewrite/Accept")]
	private Button AttentionRewriteAccept;

	[SceneBind("AttentionRewrite/Cancel")]
	private Button AttentionRewriteCancel;

	[SceneBind("AttentionDelete")]
	private Image AttentionDelete;

	[SceneBind("AttentionDelete/Accept")]
	private Button AttentionDeleteAccept;

	[SceneBind("AttentionDelete/Cancel")]
	private Button AttentionDeleteCancel;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("Scroll View/Scrollbar Vertical")]
	public RectTransform Vertical;

	private bool deleteMode;

	protected override void OnInit()
	{
		base.OnInit();
		checkpointView.Init();
		AttentionRewriteCancel.onClick.AddListener(CancelRewrite);
		Delete.onClick.AddListener(DeleteClick);
		AttentionDeleteAccept.onClick.AddListener(AcceptDeleteClick);
		AttentionDeleteCancel.onClick.AddListener(CancelDeleteClick);
		CloseButton.onClick.RemoveAllListeners();
		CloseButton.onClick.AddListener(CloseClickJoyCon);
	}

	protected void CloseClickJoyCon()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Program.mainMenu.MoveCursorToBtn();
		base.gameObject.SetActive(value: false);
	}

	private void SetDeleteMode()
	{
		foreach (SaveObjController saveObj in saveObjs)
		{
			saveObj.GetComponent<SaveObjController>().SetDeleteMode(deleteMode);
		}
	}

	public void SetBacklayer(bool state)
	{
		Layer.gameObject.SetActive(state);
		Delete.gameObject.SetActive(state);
		dateTimeButton.gameObject.SetActive(state);
		infoButton.gameObject.SetActive(state);
		moneyButton.gameObject.SetActive(state);
		scoreButton.gameObject.SetActive(state);
	}

	private void AcceptRewrite(int id)
	{
		deleteMode = false;
		SetDeleteMode();
		AttentionDelete.gameObject.SetActive(value: false);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		checkpointView.gameObject.SetActive(value: true);
		SetBacklayer(state: false);
		checkpointView.Redraw(rewrite: true, id);
		Content.gameObject.SetActive(value: false);
		AttentionRewrite.gameObject.SetActive(value: false);
	}

	private void CancelRewrite()
	{
		AttentionRewrite.gameObject.SetActive(value: false);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	private void DeleteClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (!deleteMode)
		{
			saveObjs.ForEach(delegate(SaveObjController i)
			{
				i.GetComponent<SaveObjController>().SetDeleteMode(flag: false);
			});
			saveObjs.ForEach(delegate(SaveObjController i)
			{
				i.GetComponent<SaveObjController>().Delete.isOn = false;
			});
		}
		deleteMode = !deleteMode;
		if (deleteMode)
		{
			SetDeleteMode();
			return;
		}
		bool flag = false;
		foreach (SaveObjController saveObj in saveObjs)
		{
			if (saveObj.GetComponent<SaveObjController>().selected)
			{
				flag = true;
			}
		}
		if (flag)
		{
			AttentionDelete.gameObject.SetActive(value: true);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
			ActiveComponent.Program.cursor.SetPosition(AttentionDeleteCancel.transform.position);
		}
		else
		{
			Redraw(startNew: false);
		}
	}

	private void CancelDeleteClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Redraw(startNew: false);
		AttentionDelete.gameObject.SetActive(value: false);
	}

	private void AcceptDeleteClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		int i;
		for (i = 0; i < ActiveComponent.Model.globalSaves.Preview.Count; i++)
		{
			int index = saveObjs.FindIndex((SaveObjController save) => save.name == ActiveComponent.Model.globalSaves.Preview[i].saveName);
			if (saveObjs[index].GetComponent<SaveObjController>().selected)
			{
				Object.Destroy(saveObjs[index].gameObject);
				PreviewData previewData = ActiveComponent.Model.globalSaves.Preview[i];
				Steam.DeleteCloudSave(Logic.GetSaveNameTemplate(playerPostfix: false) + previewData.saveName, resolveName: true);
				saveObjs.RemoveAt(index);
				ActiveComponent.Model.globalSaves.Preview.RemoveAt(i);
				i--;
			}
			else
			{
				saveObjs[index].GetComponent<SaveObjController>().SetDeleteMode(flag: false);
			}
		}
		Redraw(startNew: false);
		Logic.UpdateGlobalSaves();
		AttentionDelete.gameObject.SetActive(value: false);
	}

	protected override void SaveClick(int saveId)
	{
		base.SaveClick(saveId);
		deleteMode = false;
		SetDeleteMode();
		AttentionRewriteAccept.onClick.RemoveAllListeners();
		AttentionRewriteAccept.onClick.AddListener(delegate
		{
			AcceptRewrite(saveId);
		});
		AttentionRewrite.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetPosition(AttentionRewriteCancel.transform.position);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
	}

	private void StartNewGameClick()
	{
		deleteMode = false;
		SetDeleteMode();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		checkpointView.gameObject.SetActive(value: true);
		SetBacklayer(state: false);
		checkpointView.Redraw(rewrite: false, 0);
		Content.gameObject.SetActive(value: false);
		AttentionRewrite.gameObject.SetActive(value: false);
	}

	public void Redraw(bool startNew)
	{
		base.Redraw();
		ScrollRect.enabled = true;
		deleteMode = false;
		AttentionRewrite.gameObject.SetActive(value: false);
		AttentionDelete.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.globalSaves.Preview.Count == 0 && startNew)
		{
			StartNewGameClick();
			return;
		}
		if (ActiveComponent.Model.globalSaves.Preview.Count < ActiveComponent._staticData.Settings.SavesNumber)
		{
			InstantiateSave(ActiveComponent.Model.globalSaves.Preview.Count, StartNewGameClick);
		}
		checkpointView.gameObject.SetActive(value: false);
		SetBacklayer(state: true);
		base.transform.parent.GetComponent<MainMenu>().Redraw();
	}

	private void Update()
	{
		if (base.IsInited)
		{
			ScrollRect.enabled = Vertical.gameObject.activeSelf;
			if (Input.GetKeyDown(KeyCode.Escape) && checkpointView.gameObject.activeSelf)
			{
				checkpointView.CloseClick();
			}
			if (ActiveComponent.Program.joyInput.bUp && ActiveComponent.Model.KeyBoardTicks <= 0 && checkpointView.gameObject.activeSelf)
			{
				checkpointView.CloseClick();
			}
		}
	}
}
