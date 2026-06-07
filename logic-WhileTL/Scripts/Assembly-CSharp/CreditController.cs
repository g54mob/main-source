using System.Collections;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : ActiveComponent
{
	[SceneBind("Continue")]
	private Button ok;

	[SceneBind("Cancel")]
	private Button Cancel;

	[SceneBind("CreditText")]
	private Text CreditText;

	private bool waitAction;

	private Credit cr;

	private void OkClick()
	{
		Steam.UnlockAchievement("ACHIEVEMENT_21");
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		base.gameObject.SetActive(value: false);
		waitAction = true;
	}

	public IEnumerator WaitForUserAction()
	{
		while (!waitAction)
		{
			yield return new WaitForEndOfFrame();
		}
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok.onClick.AddListener(OkClick);
		Cancel.onClick.AddListener(OkClick);
	}

	public void Redraw(Credit credit)
	{
		waitAction = false;
		cr = credit;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Credit");
		string text = TextResources.GetString(credit.KeyName).Replace("%NUM1", Logic.ColorTransform("MONEY", credit.Money + "$"));
		text = text.Replace("%num1", Logic.ColorTransform("MONEY", credit.Money + "$"));
		text = text.Replace("%NUM2", Logic.ColorTransform("BAD", credit.MoneyBack + "$"));
		text.Replace("%num2", Logic.ColorTransform("BAD", credit.MoneyBack + "$"));
		text.Replace("%day", credit.DaysBack.ToString());
		CreditText.text = text.Replace("%DAY", credit.DaysBack.ToString());
	}
}
