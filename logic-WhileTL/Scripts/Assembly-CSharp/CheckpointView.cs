using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointView : ActiveComponent
{
	[SceneBind("ScrollView/Viewport/Content")]
	public GridLayoutGroup Content;

	[SceneBind("Close")]
	public Button Close;

	private bool deleteMode;

	private GameObject checkpointPref;

	private List<GameObject> checkPointsObj = new List<GameObject>();

	public void CloseClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		base.gameObject.transform.parent.GetComponent<NewGameView>().Redraw(startNew: false);
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Close.onClick.AddListener(CloseClick);
		checkpointPref = Resources.Load("Prefabs/CheckpointObj") as GameObject;
	}

	public void CheckpointClick(int id, int idSave, bool rewrite)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (!rewrite)
		{
			ActiveComponent.Model.globalSaves.Preview.Add(new PreviewData());
			ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview.LastItem();
		}
		else
		{
			Logic.DeleteSave(Logic.GetSaveNameTemplate(playerPostfix: false) + ActiveComponent.Model.globalSaves.Preview[idSave].saveName);
			ActiveComponent.Model.globalSaves.Preview[idSave] = new PreviewData();
			ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview[idSave];
		}
		ActiveComponent.Model.curPreview.date.Set();
		ActiveComponent.Model.globalSaves.Preview.ForEach(delegate(PreviewData i)
		{
			i.isLastRun = 0;
		});
		ActiveComponent.Model.curPreview.isLastRun = 1;
		ActiveComponent.Model.curPreview.saveName = "PLAYER" + ActiveComponent.Model.globalSaves.newGames;
		ActiveComponent.Model.globalSaves.newGames++;
		ActiveComponent.Model.curPreview.startupsNumber = 0;
		ActiveComponent.Model.curPreview.money = ActiveComponent._staticData.Checkpoints[id].StartMoney;
		ActiveComponent.Model.curPreview.startCheckpointKeyName = ActiveComponent._staticData.Checkpoints[id].KeyName;
		ActiveComponent.Model.curPreview.version = Program.GetVersionString();
		ActiveComponent._controller.Run(Logic.GetSaveNameTemplate(playerPostfix: false) + ActiveComponent.Model.curPreview.saveName);
		base.transform.parent.parent.gameObject.SetActive(value: false);
		ActiveComponent.Model.globalSaves.Preview.RemoveAll((PreviewData i) => i.autoSaved == 1 && i.isLastRun == 0 && i.showName == ActiveComponent.Model.curPreview.showName);
		Logic.UpdateGlobalSaves();
	}

	public static bool CheckpointIsUnlocked(UnlockGroup group)
	{
		int num = 0;
		foreach (string questsKeyName in group.questsKeyNames)
		{
			if (ActiveComponent.Model.globalSaves.passedTasks.ContainsKey(questsKeyName))
			{
				num++;
			}
		}
		return num >= group.numUnlock;
	}

	public static bool CheckpointIsUnlocked(List<UnlockGroup> groups)
	{
		int num = 0;
		foreach (UnlockGroup group in groups)
		{
			if (CheckpointIsUnlocked(group))
			{
				num++;
			}
		}
		return num >= groups.Count;
	}

	public void Redraw(bool rewrite, int idSave)
	{
		foreach (GameObject item in checkPointsObj)
		{
			Object.Destroy(item);
		}
		checkPointsObj.Clear();
		for (int i = 0; i < ActiveComponent._staticData.Checkpoints.Count; i++)
		{
			if (CheckpointIsUnlocked(ActiveComponent._staticData.Checkpoints[i].ReqUnlockGroups))
			{
				GameObject gameObject = Object.Instantiate(checkpointPref);
				gameObject.transform.SetParent(Content.transform);
				gameObject.transform.localScale = Vector3.one;
				checkPointsObj.Add(gameObject);
				int id = i;
				gameObject.GetComponent<Button>().onClick.AddListener(delegate
				{
					CheckpointClick(id, idSave, rewrite);
				});
				gameObject.GetComponent<CheckpointController>().Init(ActiveComponent._staticData.Checkpoints[id]);
			}
		}
		Content.transform.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
		if (checkPointsObj.Count == 0)
		{
			CheckpointClick(0, idSave, rewrite);
		}
	}
}
