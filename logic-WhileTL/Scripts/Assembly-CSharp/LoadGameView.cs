using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameView : GameView
{
	[SceneBind("Delete")]
	private Button Delete;

	[SceneBind("AttentionRewrite")]
	public Transform attentionRewrite;

	[SceneBind("AttentionRewrite/Accept")]
	private Button attentionRewriteAccept;

	[SceneBind("AttentionRewrite/Cancel")]
	private Button attentionRewriteCancel;

	private bool deleteMode;

	private int currentSave = -1;

	private MessageBox.Result MessageBoxSaveDelete = new MessageBox.Result();

	private MessageBox.Result MessageBoxSaveAttention = new MessageBox.Result();

	[SceneBind("AttentionDelete")]
	public Image AttentionDelete;

	[SceneBind("AttentionDelete/Accept")]
	private Button AttentionDeleteAccept;

	[SceneBind("AttentionDelete/Cancel")]
	private Button AttentionDeleteCancel;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("Scroll View/Scrollbar Vertical")]
	public RectTransform Vertical;

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	private string loadPath = "";

	protected override void OnInit()
	{
		base.OnInit();
		Delete.onClick.AddListener(DeleteClick);
		sizeFilter = Content.GetComponent<ContentSizeFitter>();
		layoutGroup = Content.GetComponent<GridLayoutGroup>();
		attentionRewriteCancel.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			attentionRewrite.gameObject.SetActive(value: false);
		});
		AttentionDelete.gameObject.SetActive(value: false);
		AttentionDeleteAccept.onClick.AddListener(AcceptDeleteClick);
		AttentionDeleteCancel.onClick.AddListener(CancelDeleteClick);
		ScrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		CloseButton.onClick.RemoveAllListeners();
		CloseButton.onClick.AddListener(CloseClickJoyCon);
	}

	private void UpdateVisibilityOnScreen()
	{
		sizeFilter.enabled = false;
		layoutGroup.enabled = false;
	}

	private void CancelDeleteClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Redraw();
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
		Redraw();
		Logic.UpdateGlobalSaves();
		AttentionDelete.gameObject.SetActive(value: false);
	}

	protected void CloseClickJoyCon()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Program.mainMenu.MoveCursorToBtn();
		base.gameObject.SetActive(value: false);
	}

	private bool IsAnySelectedForDelete()
	{
		return saveObjs.Find((SaveObjController i) => i.GetComponent<SaveObjController>().selected);
	}

	private IEnumerator AttentionAcknowledged()
	{
		int index = currentSave;
		string saveNameTemplate = Logic.GetSaveNameTemplate(playerPostfix: false);
		ActiveComponent.Model.globalSaves.Preview.ForEach(delegate(PreviewData i)
		{
			i.isLastRun = 0;
		});
		ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview[index];
		int num = ActiveComponent.Model.globalSaves.Preview.FindIndex((PreviewData x) => x.autoSaved == 1 && x.showName == ActiveComponent.Model.curPreview.showName);
		PreviewData previewData = ((num == -1) ? null : ActiveComponent.Model.globalSaves.Preview[num]);
		if (previewData == null)
		{
			previewData = new PreviewData();
			previewData.saveName = "PLAYER" + ActiveComponent.Model.globalSaves.newGames;
			ActiveComponent.Model.globalSaves.newGames++;
			previewData.autoSaved = 1;
			ActiveComponent.Model.globalSaves.Preview.Add(previewData);
			num = ActiveComponent.Model.globalSaves.Preview.Count - 1;
		}
		string text = Logic.LoadSaveGame(saveNameTemplate + ActiveComponent.Model.curPreview.saveName);
		if (text.Length != 0)
		{
			Logic.WriteSaveGame(saveNameTemplate + previewData.saveName, text);
			string saveName = previewData.saveName;
			previewData = Logic.DeserializeObject<PreviewData>(Logic.SerializeObject(ActiveComponent.Model.curPreview));
			previewData.saveName = saveName;
			previewData.autoSaved = 1;
			ActiveComponent.Model.globalSaves.Preview[num] = previewData;
			ActiveComponent.Model.curPreview = previewData;
			ActiveComponent.Program.mainMenu.loading.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetActive(state: false);
			Logic.UpdateGlobalSaves();
			loadPath = saveNameTemplate + saveName;
			StartCoroutine(WaitOneFrame());
			yield return null;
		}
	}

	public IEnumerator WaitOneFrame()
	{
		ActiveComponent.Program.cursor.SetActive(state: false);
		ActiveComponent.Model.LoadingSave = true;
		int i = 0;
		while (i < 30)
		{
			yield return new WaitForEndOfFrame();
			int num = i + 1;
			i = num;
		}
		ActiveComponent._controller.Run(loadPath);
		base.transform.parent.gameObject.SetActive(value: false);
	}

	private void SetDeleteMode()
	{
		foreach (SaveObjController saveObj in saveObjs)
		{
			saveObj.GetComponent<SaveObjController>().SetDeleteMode(deleteMode);
		}
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
			Redraw();
		}
	}

	protected override void SaveClick(int saveId)
	{
		base.SaveClick(saveId);
		AttentionDelete.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.globalSaves.Preview[saveId].autoSaved != 1 && ActiveComponent.Model.globalSaves.Preview.Find((PreviewData x) => x.showName == ActiveComponent.Model.globalSaves.Preview[saveId].showName && x.autoSaved == 1) != null)
		{
			ActiveComponent.Program.cursor.SetPosition(attentionRewriteCancel.transform.position);
			attentionRewriteAccept.onClick.RemoveAllListeners();
			attentionRewriteAccept.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				attentionRewrite.gameObject.SetActive(value: false);
				currentSave = saveId;
				deleteMode = false;
				StartCoroutine(AttentionAcknowledged());
			});
			attentionRewrite.gameObject.SetActive(value: true);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		}
		else
		{
			currentSave = saveId;
			deleteMode = false;
			StartCoroutine(AttentionAcknowledged());
		}
	}

	public override void Redraw()
	{
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		base.Redraw();
		ScrollRect.enabled = true;
		attentionRewrite.gameObject.SetActive(value: false);
		saveObjs.ForEach(delegate(SaveObjController i)
		{
			i.GetComponent<SaveObjController>().SetDeleteMode(flag: false);
		});
		deleteMode = false;
		base.transform.parent.GetComponent<MainMenu>().Redraw();
	}

	private void Update()
	{
		if (base.IsInited)
		{
			ScrollRect.enabled = Vertical.gameObject.activeSelf;
		}
	}
}
