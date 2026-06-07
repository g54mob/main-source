using System.Collections.Generic;
using App.Data;
using UnityEngine.UI;

public class MedalController : ActiveComponent
{
	private Image selfImg;

	[SceneBind("Medal0")]
	private MedalSystem Medal0;

	[SceneBind("Medal1")]
	private MedalSystem Medal1;

	[SceneBind("Medal2")]
	private MedalSystem Medal2;

	[SceneBind("LockImage")]
	private Image lockImage;

	private List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

	private List<int> complexityId = new List<int>();

	private List<MedalSystem> medals = new List<MedalSystem>();

	public bool Locked
	{
		get
		{
			return lockImage.gameObject.activeSelf;
		}
		set
		{
			lockImage.gameObject.SetActive(value);
		}
	}

	public void ChooseComplexity(int val, bool auto = true)
	{
		QuestLine.GetCurrentQuest().SetCurrentCondition(val);
		ActiveComponent.Model.construction.ResetConditions();
		Init(QuestLine.GetCurrentQuest().GetName(), auto);
	}

	protected override void OnInit()
	{
		selfImg = base.transform.GetComponent<Image>();
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		medals.Clear();
		medals.Add(Medal0);
		medals.Add(Medal1);
		medals.Add(Medal2);
		for (int i = 0; i < medals.Count; i++)
		{
			medals[i].Init();
			int newI = i;
			medals[i].transform.GetComponent<Button>().onClick.AddListener(delegate
			{
				ChooseComplexity(newI, auto: false);
			});
		}
	}

	public void SetLocked(int id)
	{
		medals[id].SetLocked(locked: true);
	}

	public void Init(string keyName, bool auto = true)
	{
		QuestLine.Quest quest = QuestLine.GetQuest(keyName);
		QuestLine.Quest quest2 = quest;
		if (ActiveComponent.Model.construction.constrState == ConstructionState.Forum)
		{
			quest2 = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
		}
		List<bool> listValidConditions = quest2.GetListValidConditions();
		int num = 0;
		foreach (bool item in listValidConditions)
		{
			medals[num].gameObject.SetActive(item);
			medals[num].SetState(chosen: false, locked: false);
			medals[num].SetLocked(ActiveComponent.Model.construction.testMode && !Logic.CheckConditions((QuestCondition)quest2.GetCondition(num), ActiveComponent.Model.construction));
			num++;
		}
		if (!auto || Logic.GetScoreFromCurConstructuion() > 0)
		{
			medals[quest.GetCurCondition()].SetChosen(chosen: true);
		}
	}
}
