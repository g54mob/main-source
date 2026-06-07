using System.Collections;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class PayDay : ActiveComponent
{
	[SceneBind("Continue")]
	private Button ok;

	[SceneBind("CreditText")]
	private Text CreditText;

	private bool waitAction;

	private Credit cr;

	private void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		waitAction = true;
		base.gameObject.SetActive(value: false);
	}

	public IEnumerator WaitForUserAction()
	{
		while (!waitAction)
		{
			yield return new WaitForEndOfFrame();
		}
		ActiveComponent._controller.Redraw();
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok.onClick.AddListener(OkClick);
	}

	public void Redraw(Credit credit)
	{
		waitAction = false;
		cr = credit;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Credit_Pay");
		string text = ActiveComponent.Model.P.playerUnit.name;
		if (text.Length > 9)
		{
			text = text.Substring(0, ActiveComponent.Model.P.playerUnit.name.Length - 9);
		}
		string text2 = TextResources.GetString("payout timebody").Replace("%USERNAME", Logic.ColorTransform("MONEY", text));
		text2.Replace("%num", Logic.ColorTransform("BAD", credit.MoneyBack + "$"));
		text2 = text2.Replace("%USERNAME".ToLower(), Logic.ColorTransform("MONEY", ActiveComponent.Model.P.playerUnit.name.Substring(0, ActiveComponent.Model.P.playerUnit.name.Length - 9)));
		CreditText.text = text2.Replace("%NUM", Logic.ColorTransform("BAD", credit.MoneyBack + "$"));
	}
}
