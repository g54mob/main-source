using App.Data;
using UnityEngine.UI;

public class CreditObjController : ActiveComponent
{
	[SceneBind("DayText")]
	public Text DayText;

	[SceneBind("MoneyText")]
	public Text MoneyText;

	[SceneBind("Normal")]
	public Image Normal;

	[SceneBind("Death")]
	public Image Death;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}

	public void Redraw(Credit credit)
	{
		DayText.text = Logic.ColorTransform("RED", credit.DaysBack.ToString());
		MoneyText.text = Logic.ColorTransform("RED", credit.MoneyBack + "$");
		if (credit.CurDepth == ActiveComponent._staticData.Settings.MaxCreditDepth)
		{
			Normal.gameObject.SetActive(value: false);
		}
		else
		{
			Death.gameObject.SetActive(value: false);
		}
	}
}
