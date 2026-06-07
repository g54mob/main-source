using System.Collections;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class GainMoneyWindow : ActiveComponent
{
	[SceneBind("Ok")]
	private Button ok;

	[SceneBind("RewardText")]
	private Text RewardText;

	[SceneBind("ProfitText")]
	private Text ProfitText;

	[SceneBind("Date")]
	private Text Date;

	[SceneBind("Rent")]
	private Text Rent;

	[SceneBind("FromText")]
	private Text FromText;

	public bool waitAction;

	private int rew;

	private void OkClick()
	{
		ActiveComponent.Model.P.Money += rew;
		if (rew > 0)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MoneyOutcome");
		}
		else if (rew == 0)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		else if (rew < 0)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MoneyIncome");
		}
		QuestLine.GetCurrentQuest().SetReward(rew: true);
		waitAction = true;
	}

	public IEnumerator WaitForUserAction()
	{
		while (!waitAction)
		{
			yield return new WaitForEndOfFrame();
		}
		if (base.gameObject.activeSelf)
		{
			ActiveComponent._controller.CloseGainMoneyWindow();
		}
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok.onClick.AddListener(OkClick);
	}

	public void Redraw(int reward, int profit)
	{
		rew = reward;
		RewardText.text = Logic.ColorTransform("MONEY", reward + "$");
		string keyName = "MONEY";
		if (profit <= 0)
		{
			keyName = "BAD";
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CheckWindowPopup");
		ProfitText.text = Logic.ColorTransform(keyName, profit + "$");
		Date.text = "";
		FromText.text = Logic.ColorTransform("NORMAL", TextResources.GetString(QuestLine.GetCurrentQuest().GetTexts() + "FROM"));
		Rent.text = Logic.ColorTransform("BAD", "-" + (reward - profit) + "$");
		Logic.UpdateGameSaves();
		ActiveComponent.Program.cursor.SetPosition(ok.transform.position);
		waitAction = false;
	}
}
