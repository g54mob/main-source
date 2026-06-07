using App.Data;
using Localization;
using UnityEngine.UI;

public class ResultBlockResult : ActiveComponent
{
	[SceneBind("Occupancy")]
	private Text acc;

	[SceneBind("Accuracy")]
	private Text occ;

	[SceneBind("Time")]
	private Text timeText;

	public override void Init()
	{
		SceneBindContainer.BindObjects(this, base.transform);
	}

	public void OnInit(Result res, App.Data.Result r)
	{
		if (res == null)
		{
			acc.text = "";
			occ.text = "";
			return;
		}
		string keyName = "BAD";
		if (res.accuracy >= res.result.Accuracy)
		{
			keyName = "GOOD";
		}
		acc.text = Logic.ColorTransform("NORMAL", TextResources.GetString("ACC.") + " ") + Logic.ColorTransform(keyName, res.accuracy + "%") + Logic.ColorTransform("NORMAL", " / " + r.Accuracy + "%");
		keyName = "BAD";
		if ((float)res.curElems >= res.need)
		{
			keyName = "GOOD";
		}
		QuestLine.Quest quest = QuestLine.GetCurrentQuest();
		if (ActiveComponent.Model.construction.constrState == ConstructionState.Forum)
		{
			quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
		}
		if (quest.GetTableQuest().OnlyAcc == 1)
		{
			occ.text = "";
		}
		else
		{
			occ.text = Logic.ColorTransform("NORMAL", TextResources.GetString("OCCUPANCY") + " ") + Logic.ColorTransform(keyName, res.curElems.ToString()) + Logic.ColorTransform("NORMAL", " / " + res.need);
		}
	}
}
