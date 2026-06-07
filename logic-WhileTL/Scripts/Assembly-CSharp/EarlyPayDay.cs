using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class EarlyPayDay : ActiveComponent
{
	[SceneBind("Continue")]
	private Button ok;

	[SceneBind("Cancel")]
	private Button cancel;

	[SceneBind("CreditText")]
	private Text CreditText;

	private Credit cr;

	private void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Model.P.Money -= cr.MoneyBack;
		base.gameObject.SetActive(value: false);
		for (int i = 0; i < ActiveComponent.Model.P.credits.Count; i++)
		{
			if (ActiveComponent.Model.P.credits[i] == cr)
			{
				ActiveComponent.Model.P.credits.RemoveAt(i);
				break;
			}
		}
		ActiveComponent.Model.P.creditDepth = 0;
		foreach (Credit credit in ActiveComponent.Model.P.credits)
		{
			ActiveComponent.Model.P.creditDepth = Mathf.Max(ActiveComponent.Model.P.creditDepth, credit.CurDepth);
		}
		ActiveComponent._controller._resourcesView.CreditRedraw();
		ActiveComponent._controller._resourcesView.Redraw();
	}

	private void CancelClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok.onClick.AddListener(OkClick);
		cancel.onClick.AddListener(CancelClick);
	}

	public void Redraw(Credit credit)
	{
		cr = credit;
		ok.interactable = ActiveComponent.Model.P.Money >= cr.MoneyBack;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Credit_Pay");
		Debug.Log(TextResources.GetString("EARLY_PAYOUT"));
		CreditText.text = TextResources.GetString("EARLY_PAYOUT").Replace("%num", "%NUM").Replace("%NUM", Logic.ColorTransform("BAD", credit.MoneyBack + "$"));
	}
}
