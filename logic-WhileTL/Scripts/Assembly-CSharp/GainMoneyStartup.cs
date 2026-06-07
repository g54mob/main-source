using System.Collections;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class GainMoneyStartup : ActiveComponent
{
	[SceneBind("Ok")]
	private Button ok;

	[SceneBind("Cancel")]
	private Button cancel;

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

	[SceneBind("AttentionDelete/Hide")]
	public Toggle HideAcceptBankrupt;

	[SceneBind("AttentionDelete/Accept")]
	private Button AcceptStartupDelete;

	[SceneBind("AttentionDelete/Cancel")]
	private Button CancelStartupdelete;

	[SceneBind("AttentionDelete")]
	private Image AttentionDelete;

	[SceneBind("StartupIncomeTutorial")]
	private TutorialList StartupIncomeTutorial;

	[SceneBind("InDev")]
	private Image InDev;

	private bool waitAction;

	public bool denied;

	private int rew;

	private int profit;

	private StartupScheme sch;

	private void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		sch.baseStartup.BaseMoney += profit;
		Logic.UpdateGameSaves();
		waitAction = true;
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
	}

	private void BankruptStartupClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		denied = true;
		waitAction = true;
		ActiveComponent._controller._startupView.Redraw();
		AttentionDelete.gameObject.SetActive(value: false);
	}

	private void BankruptStartupCancel()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionDelete.gameObject.SetActive(value: false);
	}

	private void CancelClick()
	{
		if (ActiveComponent.Model.P.HideBankrupt == 1)
		{
			BankruptStartupClick();
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionDelete.gameObject.SetActive(value: true);
		HideAcceptBankrupt.gameObject.SetActive(value: false);
		HideAcceptBankrupt.isOn = ActiveComponent.Model.P.HideBankrupt == 1;
	}

	private void HideBankruptClick(bool click)
	{
		if (click)
		{
			ActiveComponent.Model.P.HideBankrupt = 1;
		}
		else
		{
			ActiveComponent.Model.P.HideBankrupt = 0;
		}
		Logic.UpdateGameSaves();
	}

	public IEnumerator WaitForUserAction()
	{
		StartupIncomeTutorial.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.startupWeekTutorial = 1;
		}
		if (ActiveComponent.Model.P.startupWeekTutorial == 0)
		{
			ActiveComponent.Model.P.startupWeekTutorial = 1;
			Logic.UpdateGameSaves();
		}
		while (!waitAction)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok.onClick.AddListener(OkClick);
		StartupIncomeTutorial.Init();
		HideAcceptBankrupt.onValueChanged.AddListener(HideBankruptClick);
		AcceptStartupDelete.onClick.AddListener(BankruptStartupClick);
		CancelStartupdelete.onClick.AddListener(BankruptStartupCancel);
	}

	public void Redraw(StartupScheme scheme)
	{
		sch = scheme;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CheckStartupPopup");
		waitAction = false;
		AttentionDelete.gameObject.SetActive(value: false);
		denied = false;
		rew = scheme.GetWeekIncome();
		RewardText.text = Logic.ColorTransform("MONEY", rew + "$");
		string keyName = "GOOD";
		profit = scheme.GetWeekIncome() - scheme.GetWeekServersCost();
		if (profit <= 0)
		{
			keyName = "BAD";
		}
		_ = scheme.released;
		_ = 1;
		ProfitText.gameObject.SetActive(scheme.released == 1);
		Rent.gameObject.SetActive(scheme.released == 1);
		RewardText.gameObject.SetActive(scheme.released == 1);
		InDev.gameObject.SetActive(scheme.released == 0);
		ProfitText.text = Logic.ColorTransform(keyName, profit + "$");
		Date.text = "";
		FromText.text = Logic.ColorTransform("WARNING", TextResources.GetString(scheme.baseStartup.Texts + "T"));
		Rent.text = Logic.ColorTransform("BAD", "-" + (rew - profit) + "$");
		ActiveComponent.Program.cursor.SetPosition(ok.transform.position);
		Logic.UpdateGameSaves();
	}
}
