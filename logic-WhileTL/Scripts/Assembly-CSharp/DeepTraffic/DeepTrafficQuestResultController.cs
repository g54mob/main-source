using System;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class DeepTrafficQuestResultController : ActiveComponent
	{
		[SceneBind("Header")]
		private Image headerImage;

		[SceneBind("Header/Text")]
		private Text headerText;

		[SceneBind("MainBlock/MedalResult/Image")]
		private Image medalImage;

		[SceneBind("MainBlock/MedalResult/Text")]
		private Text medalText;

		[SceneBind("MainBlock/AverageSpeedField/ValueText")]
		private Text averageSpeedText;

		[SceneBind("MainBlock/AICostField/ValueText")]
		private Text aiCostText;

		[SceneBind("MainBlock/MoneySpendField/ValueText")]
		private Text moneySpendText;

		[SceneBind("OkBtn")]
		private Button okButton;

		[SceneBind("NextQuestBtn")]
		private Button nextQuestButton;

		[SceneBind("SaveAndExit")]
		private Button saveAndExit;

		[SceneBind("NextQuestBtn/Text")]
		private Text nextQuestText;

		[SceneBind("OkReleased")]
		private Button OkReleased;

		[SceneBind("GetCreditBtn")]
		private Button GetCreditBtn;

		[SceneBind("Bankrupt")]
		private Button Bankrupt;

		private Sprite[] medalSprites = new Sprite[4];

		private Color successColor;

		private Color failedColor;

		private bool creditGained;

		private int moneySpend;

		private void GetCredit()
		{
			Credit randomCredit = Logic.GetRandomCredit();
			if (randomCredit != null)
			{
				ActiveComponent.Model.P.creditDepth++;
				randomCredit = new Credit(randomCredit, moneySpend);
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
				nextQuestButton.onClick.Invoke();
			}
		}

		public void Init(float averageSpeed, int aiCost, int moneySpend, int medalNumber, DeepTrafficRunMode runMode, Action nextQuestCallback = null)
		{
			base.Init();
			averageSpeedText.text = Logic.ColorTransform("SPEED", averageSpeed.ToString("f1") + " / " + QuestLine.GetCurrentCarQuest().GetCarCondition(Mathf.Max(medalNumber, 0)).CarMedalCondition.averageSpeed);
			aiCostText.text = Logic.ColorTransform("MONEY", aiCost + QuestLine.GetCurrentQuest().GetRewardFromMedal(medalNumber) + "$");
			moneySpendText.text = Logic.ColorTransform("BAD", moneySpend + "$");
			medalImage.sprite = medalSprites[medalNumber + 1];
			this.moneySpend = moneySpend;
			if (runMode == DeepTrafficRunMode.Test)
			{
				bool flag = QuestLine.GetCurrentQuest().IsCompleted();
				nextQuestButton.gameObject.SetActive(value: true);
				nextQuestButton.interactable = medalNumber > -1 && !flag;
				if (medalNumber == 2)
				{
					ActiveComponent.Program.cursor.SetPosition(nextQuestButton.transform.position);
				}
				else
				{
					ActiveComponent.Program.cursor.SetPosition(okButton.transform.position);
				}
				saveAndExit.gameObject.SetActive(flag);
				okButton.gameObject.SetActive(!flag);
				OkReleased.gameObject.SetActive(flag);
				headerText.text = TextResources.GetString("RUN :");
				medalText.text = TextResources.GetString("POSSIBLE_RESULT_TASK");
				if (QuestLine.GetCurrentQuest().IsCompleted())
				{
					nextQuestText.text = TextResources.GetString("SAVE_EXIT");
				}
				else
				{
					nextQuestText.text = TextResources.GetString("RELEASE AND CHECK");
				}
			}
			if (medalNumber == -1)
			{
				headerImage.color = failedColor;
				Text text = headerText;
				text.text = text.text + " " + TextResources.GetString("FAILED");
			}
			else
			{
				headerImage.color = successColor;
				Text text2 = headerText;
				text2.text = text2.text + " " + TextResources.GetString("COMPLETE");
			}
			if (runMode == DeepTrafficRunMode.Test && medalNumber > -1 && QuestLine.GetCurrentQuest().IsCompleted())
			{
				QuestLine.GetCurrentQuest().SetScore(medalNumber + 1);
			}
			if (medalNumber > -1)
			{
				nextQuestButton.onClick.RemoveAllListeners();
				nextQuestButton.onClick.AddListener(delegate
				{
					if (QuestLine.GetCurrentQuest().IsCompleted())
					{
						ActiveComponent.Model.construction.ExitClick();
					}
					else
					{
						QuestLine.GetCurrentQuest().moneySpent = moneySpend;
						base.gameObject.SetActive(value: false);
						nextQuestCallback();
						nextQuestButton.onClick.RemoveAllListeners();
						nextQuestButton.onClick.AddListener(delegate
						{
							base.gameObject.SetActive(value: false);
						});
					}
				});
			}
			GetCreditBtn.gameObject.SetActive(nextQuestButton.gameObject.activeSelf);
			if (ActiveComponent.Model.P.Money > moneySpend)
			{
				GetCreditBtn.gameObject.SetActive(value: false);
			}
			GetCreditBtn.interactable = ActiveComponent.Model.P.creditDepth < ActiveComponent._staticData.Settings.MaxCreditDepth;
			Bankrupt.gameObject.SetActive(GetCreditBtn.gameObject.activeSelf && ActiveComponent.Model.P.creditDepth == ActiveComponent._staticData.Settings.MaxCreditDepth);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			medalSprites[0] = Logic.LoadSprite("EMPTY_MEDAL");
			medalSprites[1] = Logic.LoadSprite("BRONZE");
			medalSprites[2] = Logic.LoadSprite("SILVER");
			medalSprites[3] = Logic.LoadSprite("GOLD");
			successColor = Logic.GetColor("SUCCESS_DEPLOY");
			failedColor = Logic.GetColor("FAILED_DEPLOY");
			okButton.onClick.AddListener(delegate
			{
				base.gameObject.SetActive(value: false);
			});
			OkReleased.onClick.AddListener(delegate
			{
				base.gameObject.SetActive(value: false);
			});
			nextQuestButton.onClick.AddListener(delegate
			{
				base.gameObject.SetActive(value: false);
			});
			saveAndExit.onClick.AddListener(delegate
			{
				base.gameObject.SetActive(value: false);
				nextQuestButton.onClick.Invoke();
				ActiveComponent._controller.construction.deepTrafficQuestController.gameObject.SetActive(value: false);
			});
			GetCreditBtn.onClick.AddListener(GetCredit);
			Bankrupt.onClick.AddListener(delegate
			{
				ActiveComponent.Model.construction.ExitClick();
				ActiveComponent.Model.P.Money = -1L;
				ActiveComponent._controller.EndGame();
			});
		}
	}
}
