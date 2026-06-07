using System.Linq;
using UnityEngine.UI;

public class MoneyPanel : DropDownPanel
{
	public Text[] MoneyText;

	protected override float GetHeight()
	{
		return 174f;
	}

	protected override void Refresh()
	{
		double money = GameSettings.Instance.Insurance.Money;
		double num = 0.0 - GameSettings.Instance.Loans.Sum((Loan x) => (double)x.Months * x.Monthly);
		double num2 = GameSettings.Instance.MyCompany.Subsidiaries.SumSafe(delegate(uint x)
		{
			Company company = MarketSimulation.Active.GetCompany(x);
			return (company == null) ? 0.0 : company.GetMoneyWithInsurance(false);
		});
		double num3 = (double)GameSettings.Instance.Investments.SumSafe((Investment x) => x.CurrentValue) + GameSettings.Instance.MyCompany.NewOwnedStock.Sum((NewStock x) => x.TotalWorth);
		float num4 = (GameSettings.Instance.RentMode ? 0f : GameSettings.Instance.PlayerPlots.SumSafe((PlotArea x) => x.Price - x.Monthly * (float)x.MonthsLeft));
		MoneyText[0].text = money.Currency();
		MoneyText[1].text = num3.Currency();
		MoneyText[2].text = num.Currency();
		MoneyText[3].text = num2.Currency();
		MoneyText[4].text = num4.Currency();
		MoneyText[5].text = (GameSettings.Instance.MyCompany.Money + money + num + num3 + num2 + (double)num4).Currency();
	}
}
