using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class EpochGoalController : ActiveComponent
{
	[SceneBind("LocalProgress")]
	private Text localProgress;

	[SceneBind("LocalScore")]
	private Text localScore;

	[SceneBind("GlobalScore")]
	private Text GlobalScore;

	[SceneBind("StudySlider")]
	private Slider studySlider;

	[SceneBind("ExpertSlider")]
	private BoundedSlider expertSlider;

	private List<Color> colors = new List<Color>();

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		colors = Logic.Colors;
	}

	public void RedrawEpoch(Epoch epoch)
	{
		localProgress.text = TextResources.GetString(epoch.KeyName + "_TASKT");
		int num = 0;
		int num2 = 0;
		Comics comicsByKeyName = Logic.GetComicsByKeyName(epoch.Comics);
		string[] parsedReqScoreList = comicsByKeyName.ParsedReqScoreList;
		foreach (string text in parsedReqScoreList)
		{
			if (Logic.GetBaseQuestByKeyName(text).Main == 1)
			{
				if (Logic.GetModel().curPreview.IsQuestDone(text))
				{
					num++;
				}
				num2++;
			}
		}
		List<string> listCompleted = QuestLine.GetListCompleted();
		int num3 = 0;
		foreach (string item in listCompleted)
		{
			if (QuestLine.IsLoadedInMemory(item) && QuestLine.GetQuest(item).GetBaseQuest().Main == 1)
			{
				num3++;
			}
		}
		_ = comicsByKeyName.ScoresBorderFloat;
		localScore.text = Mathf.Min(100, (int)(100f * (float)num / (float)num2)) + "%";
		GlobalScore.text = Mathf.Min(100, (int)(100f * (float)num3 / (float)ActiveComponent._staticData.Settings.MaxTreeScore)) + "%";
	}

	public void Redraw()
	{
		foreach (Epoch epoch in ActiveComponent._staticData.Epochs)
		{
			if (!ActiveComponent.Model.curPreview.IsQuestDone(epoch.End))
			{
				RedrawEpoch(epoch);
				return;
			}
		}
		localProgress.text = TextResources.GetString(ActiveComponent._staticData.Epochs.LastItem().KeyName + "_TASKT");
		localScore.text = 100 + "%";
	}
}
