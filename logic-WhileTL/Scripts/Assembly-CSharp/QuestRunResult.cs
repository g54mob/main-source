using System;
using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class QuestRunResult : ActiveComponent
{
	[SceneBind("ResultHeader")]
	private Text header;

	[SceneBind("Result")]
	private Text result;

	[SceneBind("OkBtn")]
	public Button OkBtn;

	[SceneBind("OkSingle")]
	public Button OkSingle;

	[SceneBind("OkBtnForum")]
	public Button OkBtnForum;

	[SceneBind("NextQuestBtn/Text")]
	private Text NextQuestText;

	[SceneBind("InformValue")]
	private Text InformValue;

	[SceneBind("InformText")]
	private Text InformText;

	[SceneBind("NextQuestBtn")]
	public Button NextQuestBtn;

	[SceneBind("GetCreditBtn")]
	public Button GetCreditBtn;

	[SceneBind("Bankrupt")]
	public Button Bankrupt;

	[SceneBind("NextQuestBtnForum")]
	public Button NextQuestBtnForum;

	[SceneBind("PossibleResult")]
	private Text PossibleResult;

	[SceneBind("MedalResult")]
	public Image MedalResult;

	[SceneBind("FailedLayer")]
	public Image FailedLayer;

	[SceneBind("OutputsCanvas")]
	public RectTransform OutputsCanvas;

	private List<ResultBlockResult> showResult = new List<ResultBlockResult>();

	private bool creditGained;

	public Action disableCallback;

	private List<Sprite> medalSprites = new List<Sprite>();

	private Construction construction;

	private int score;

	private int predictMoneyInDeploy;

	private float rememberedTimer;

	private void OpenCreditWindowClick()
	{
		Credit randomCredit = Logic.GetRandomCredit();
		if (randomCredit != null)
		{
			ActiveComponent.Model.P.creditDepth++;
			randomCredit = new Credit(randomCredit, predictMoneyInDeploy);
			ActiveComponent.Model.P.credits.Add(randomCredit);
			randomCredit.CurDepth = ActiveComponent.Model.P.creditDepth;
			ActiveComponent._controller.credit.Redraw(randomCredit);
			ActiveComponent._controller.credit.gameObject.SetActive(value: true);
			StartCoroutine(ActiveComponent._controller.credit.WaitForUserAction());
			ActiveComponent.Model.P.Money += randomCredit.Money;
			Logic.UpdateGameSaves();
		}
		GetCreditBtn.gameObject.SetActive(value: false);
		creditGained = true;
	}

	private void Update()
	{
		if (creditGained && !ActiveComponent._controller.credit.gameObject.activeInHierarchy)
		{
			creditGained = false;
			NextQuestClick();
		}
	}

	private void NextQuestClick()
	{
		if (QuestLine.GetCurrentQuest().IsCompleted())
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent.Model.construction.ExitClick();
			return;
		}
		ActiveComponent.Model.construction.firstNonForumQuestTutorialWindow.gameObject.SetActive(value: false);
		ActiveComponent.Model.P.firstNonForumQuestTutorial = 1;
		ActiveComponent.Model.P.passedFirstQuest = 1;
		QuestLine.Quest currentQuest = QuestLine.GetCurrentQuest();
		ActiveComponent.Model.globalSaves.passedTasksCou[QuestLine.GetCurrentQuestName()]++;
		ActiveComponent.Model.P.daysStartTask.Add(DateTime.Now.ToString());
		currentQuest.SetScore(score);
		int num = currentQuest.GetScore();
		num = currentQuest.GetRewardFromMedal(currentQuest.GetCurCondition());
		ActiveComponent.Model.P.Money -= predictMoneyInDeploy;
		currentQuest.moneySpent += predictMoneyInDeploy;
		ActiveComponent._controller.InitGainMoneyWindow(num, num - (int)currentQuest.moneySpent);
		Steam.UnlockAchievement("ACHIEVEMENT_3");
		if (currentQuest.testRunsOnQuest >= 10)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_22");
		}
		foreach (Construction.BlockInScheme item in ActiveComponent.Model.construction.blocksInScheme)
		{
			if (!item.go.GetComponent<BaseBlock>().IsTrained())
			{
				Steam.UnlockAchievement("ACHIEVEMENT_34");
				break;
			}
		}
		if (Logic.GetCurrentTableQuest().UnlockedBlocks.Contains("REMOVE"))
		{
			bool flag = false;
			foreach (Construction.BlockInScheme item2 in ActiveComponent.Model.construction.blocksInScheme)
			{
				if (Logic.IsBaseBlock(item2.go.name))
				{
					if (item2.go.name == "REMOVE")
					{
						flag = true;
						break;
					}
				}
				else if (item2.go.GetComponent<CustomBlock>().scheme.containsBlock("REMOVE"))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Steam.UnlockAchievement("ACHIEVEMENT_33");
			}
		}
		Logic.SendAnalytics("CONSTRUCTION_TASK_RELEASED", new Dictionary<string, object>
		{
			{
				"keyName",
				QuestLine.GetCurrentQuestName()
			},
			{ "time spend", rememberedTimer },
			{
				"money spend",
				(int)currentQuest.moneySpent
			},
			{
				"blocks used",
				ActiveComponent.Model.construction.GetBlocksCou()
			},
			{
				"servers used",
				ActiveComponent.Model.construction.GetServersCouInSheme()
			},
			{ "test runs", currentQuest.testRunsOnQuest },
			{ "time in quest", currentQuest.timeInQuest },
			{
				"custom blocks",
				ActiveComponent.Model.construction.GetCustomBlocksInScheme()
			},
			{
				"catHubs",
				ActiveComponent.Model.construction.GetNumValidCatHubs()
			},
			{ "score", score },
			{
				"global release num",
				ActiveComponent.Model.globalSaves.passedTasksCou[QuestLine.GetCurrentQuestName()]
			}
		});
		int num2 = 4;
		foreach (Epoch epoch in ActiveComponent._staticData.Epochs)
		{
			if (epoch.End == currentQuest.GetName())
			{
				Steam.UnlockAchievement("ACHIEVEMENT_" + num2);
				break;
			}
			num2++;
		}
		if (ActiveComponent._staticData.Settings.ShowSteamRateTrigger.Contains(currentQuest.GetName()))
		{
			ActiveComponent.Model.showSteamWindow = true;
		}
		switch (score)
		{
		case 0:
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Release_Bad");
			break;
		case 1:
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Release_Good_Bronze");
			break;
		case 2:
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Release_Good_Silver");
			break;
		case 3:
			if (QuestLine.GetCurrentQuest().GetBaseQuest().KeyName == "ONLY R PARALLEL2")
			{
				Steam.UnlockAchievement("ACHIEVEMENT_32");
			}
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Release_Good_Gold");
			break;
		}
		ActiveComponent.Model.construction.ExitClick();
		QuestLine.GetCurrentQuest().GetBaseQuest().End();
	}

	private void OkClick()
	{
		construction.ClearEnds();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		if (disableCallback != null)
		{
			disableCallback();
		}
	}

	public override void Init()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		GetCreditBtn.onClick.AddListener(OpenCreditWindowClick);
		OkBtn.onClick.AddListener(OkClick);
		OkSingle.onClick.AddListener(OkClick);
		NextQuestBtn.onClick.AddListener(NextQuestClick);
		OkBtnForum.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			construction.ClearEnds();
			base.gameObject.SetActive(value: false);
		});
		NextQuestBtnForum.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			QuestLine.GetCurrentQuest().SetScore(score);
			foreach (Construction.BlockInScheme item in ActiveComponent.Model.construction.blocksInScheme)
			{
				if (!item.go.GetComponent<BaseBlock>().IsTrained())
				{
					Steam.UnlockAchievement("ACHIEVEMENT_34");
					break;
				}
			}
			base.gameObject.SetActive(value: false);
			ActiveComponent.Model.construction.ExitClick();
		});
		medalSprites.Add(Logic.LoadSprite("EMPTY_MEDAL"));
		medalSprites.Add(Logic.LoadSprite("BRONZE"));
		medalSprites.Add(Logic.LoadSprite("SILVER"));
		medalSprites.Add(Logic.LoadSprite("GOLD"));
		for (int num = 0; num < 5; num++)
		{
			showResult.Add(base.transform.Find("Output" + num).GetComponent<ResultBlockResult>());
			showResult[num].Init();
		}
		Bankrupt.onClick.AddListener(delegate
		{
			ActiveComponent.Model.construction.ExitClick();
			ActiveComponent.Model.P.Money = -1L;
			ActiveComponent._controller.EndGame();
		});
	}

	private bool HasLowAccuracy()
	{
		foreach (Result result in construction.results)
		{
			if (result.gameObject.activeSelf && result.accuracy < result.result.Accuracy)
			{
				return true;
			}
		}
		return false;
	}

	public void InitQuestResult(Construction constr, float timer, int score = 0, int predictMoneyInDeploy = 0)
	{
		OkSingle.gameObject.SetActive(value: false);
		this.score = score;
		this.predictMoneyInDeploy = predictMoneyInDeploy;
		construction = constr;
		timer = Mathf.Min(timer, constr.curCondition.Time);
		bool flag = constr.constrState == ConstructionState.Forum;
		MedalResult.sprite = medalSprites[score];
		QuestLine.GetCurrentQuest().IsCompleted();
		if (constr.Complete && QuestLine.GetCurrentQuest().IsCompleted())
		{
			QuestLine.GetCurrentQuest().SetScore(score);
		}
		Logic.UpdateCurGlobalScore(QuestLine.GetCurrentQuest());
		if (QuestLine.GetCurrentQuest().IsCompleted())
		{
			NextQuestText.text = TextResources.GetString("SAVE_EXIT");
		}
		else
		{
			NextQuestText.text = TextResources.GetString("RELEASE AND CHECK");
		}
		NextQuestBtn.gameObject.SetActive(!flag);
		NextQuestBtn.interactable = score > 0;
		OkBtn.gameObject.SetActive(!flag);
		if (!flag)
		{
			if (score == 3)
			{
				ActiveComponent.Program.cursor.SetPosition(NextQuestBtn.transform.position);
			}
			else
			{
				ActiveComponent.Program.cursor.SetPosition(OkBtn.transform.position);
			}
		}
		NextQuestBtnForum.gameObject.SetActive(flag);
		OkBtnForum.gameObject.SetActive(flag);
		GetCreditBtn.gameObject.SetActive(NextQuestBtn.gameObject.activeSelf);
		if (ActiveComponent.Model.P.Money > predictMoneyInDeploy)
		{
			GetCreditBtn.gameObject.SetActive(value: false);
		}
		GetCreditBtn.interactable = ActiveComponent.Model.P.creditDepth < ActiveComponent._staticData.Settings.MaxCreditDepth;
		Bankrupt.gameObject.SetActive(GetCreditBtn.gameObject.activeSelf && ActiveComponent.Model.P.creditDepth == ActiveComponent._staticData.Settings.MaxCreditDepth);
		if (constr.Deploy || flag)
		{
			PossibleResult.text = TextResources.GetString("RESULT_TASK");
		}
		else
		{
			PossibleResult.text = TextResources.GetString("POSSIBLE_RESULT_TASK");
			header.text = Logic.ColorTransform("NORMAL", TextResources.GetString("RUN :") + " ");
		}
		if (flag)
		{
			header.text = Logic.ColorTransform("NORMAL", TextResources.GetString("RUN :") + " ");
			if (constr.Complete)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Test_Good");
			}
			else
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Test_Bad");
			}
		}
		if (!flag && score == 3 && constr.GetBlocksCou() < Logic.GetConditionByKeyName(QuestLine.GetCurrentQuest().GetTableQuest().ConditionGold).Blocks)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_30");
		}
		if (flag)
		{
			header.text = Logic.ColorTransform("NORMAL", TextResources.GetString("FORUM_RUN_:") + " ");
		}
		FailedLayer.gameObject.SetActive(!constr.Complete);
		if (constr.Complete)
		{
			header.text += Logic.ColorTransform("GOOD", TextResources.GetString("COMPLETE"));
		}
		else
		{
			header.text += Logic.ColorTransform("BAD", TextResources.GetString("FAILED"));
			NextQuestBtn.gameObject.SetActive(value: false);
		}
		if (flag)
		{
			if (constr.Complete)
			{
				if (!QuestLine.GetCurrentQuest().IsCompleted())
				{
					NextQuestBtnForum.gameObject.SetActive(value: true);
					ActiveComponent.Program.cursor.SetPosition(NextQuestBtnForum.transform.position);
					OkBtnForum.gameObject.SetActive(value: false);
				}
				else
				{
					NextQuestBtnForum.gameObject.SetActive(value: false);
					OkBtnForum.gameObject.SetActive(value: true);
					ActiveComponent.Program.cursor.SetPosition(OkBtnForum.transform.position);
				}
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Test_Good");
			}
			else
			{
				ActiveComponent.Program.cursor.SetPosition(OkSingle.transform.position);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Test_Bad");
			}
		}
		InformValue.text = "";
		rememberedTimer = constr.timer;
		if ((float)Mathf.FloorToInt(constr.timer * 10f) > 10f * constr.curCondition.Time && !constr.Complete)
		{
			result.text = Logic.ColorTransform("BAD", TextResources.GetString("TIME IS OVER"));
			if (HasLowAccuracy())
			{
				Text text = result;
				text.text = text.text + "\n" + Logic.ColorTransform("BAD", TextResources.GetString("LOWACC"));
			}
		}
		else
		{
			result.text = Logic.ColorTransform("GOOD", TextResources.GetString("SUCCESS"));
		}
		InformText.text = "";
		OutputsCanvas.gameObject.SetActive(!flag);
		string text2 = Logic.ColorTransform("TIME", (int)(10f * constr.timer) / 10 + "." + Mathf.FloorToInt(10f * timer) % 10);
		if (!flag)
		{
			InformText.text += Logic.ColorTransform("NORMAL", TextResources.GetString("MONEY SPEND"));
			string text3 = Logic.ColorTransform("RED", constr.GetMoneyPerSecond() + "$");
			Text informValue = InformValue;
			informValue.text = informValue.text + text2 + " * " + text3 + " = " + Logic.ColorTransform("BAD", (int)constr.predictMoneyInDeploy + "$");
		}
		Text informText = InformText;
		informText.text = informText.text + "\n" + Logic.ColorTransform("NORMAL", TextResources.GetString("TIME SPEND"));
		Text informValue2 = InformValue;
		informValue2.text = informValue2.text + "\n" + text2 + Logic.ColorTransform("NORMAL", " / " + constr.curCondition.Time + ".0");
		Text informText2 = InformText;
		informText2.text = informText2.text + "\n" + Logic.ColorTransform("NORMAL", TextResources.GetString("BLOCKS USED"));
		Text informValue3 = InformValue;
		informValue3.text = informValue3.text + "\n" + Logic.ColorTransform("WARNING", constr.GetBlocksCou() + " / " + constr.curCondition.Blocks);
		for (int i = 0; i < constr.results.Count; i++)
		{
			showResult[i].gameObject.SetActive(constr.results[i].gameObject.activeSelf && !flag);
			if (constr.results[i].gameObject.activeSelf)
			{
				showResult[i].OnInit(constr.results[i], constr.results[i].result);
			}
		}
		if (OkBtn.gameObject.activeSelf && score == 0)
		{
			OkBtn.gameObject.SetActive(value: false);
			OkSingle.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(OkSingle.transform.position);
		}
		constr.SleepEnds();
	}
}
