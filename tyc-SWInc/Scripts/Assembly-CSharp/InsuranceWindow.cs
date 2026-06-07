using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class InsuranceWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Slider valueSlider;

	public Toggle ContentsToggle;

	public Text FundsText;

	public Text TheftText;

	public Text[] InterestText;

	public InputField DepositInput;

	public InputField WithdrawInput;

	public InputField StockAmount;

	public GUIListView Terminations;

	public GUIListView Investments;

	public ButtonCounter RetireCounter;

	public Toggle Bonds;

	public Toggle Stocks;

	public GameObject BondsPanel;

	public GameObject StocksPanel;

	public GUILineChart StockChart;

	public GUILegend StockLegend;

	private List<List<float>> _chartValues = new List<List<float>>();

	public GUICombobox StockCombo;

	public GameObject CallInspector;

	public bool Round = true;

	[NonSerialized]
	private int _newRetires;

	public void AddTermination(EmployeeTermination term, Actor ac, bool addMsg = true)
	{
		if (ac.employee.IsRole(Employee.RoleBit.Lead) && ac.Team != null && ac.GetTeam().HR.AnyActiveFunctions && ac.employee.GetSpecialization(Employee.EmployeeRole.Lead, "HR") > 0)
		{
			ac.GetTeam().Leader = null;
			NotificationManager.AddNotification(new HRMissing(ac.GetTeam()));
		}
		Terminations.Items.Add(term);
		string text = null;
		string icon = "Employee";
		switch (term.Termination)
		{
		case EmployeeTermination.TerminationType.Dead:
			text = "DiedNotify".LocColor(ac);
			icon = "Death";
			AddRetire();
			GameSettings.Instance.RegisterStat("Retired", 1f);
			break;
		case EmployeeTermination.TerminationType.Hospitalized:
			text = "HospitalizedNotify".LocColor(ac);
			icon = "Health";
			AddRetire();
			GameSettings.Instance.RegisterStat("Retired", 1f);
			break;
		case EmployeeTermination.TerminationType.Retired:
			text = "RetireNotify".LocColor(ac);
			AddRetire();
			GameSettings.Instance.RegisterStat("Retired", 1f);
			break;
		case EmployeeTermination.TerminationType.Quit:
			text = ((ac.ComplaintLevel > 0f) ? "EmployeeIgnoredComplaints".LocColor(ac) : "EmployeeImmediateQuit".LocColor(ac));
			GameSettings.Instance.RegisterStat("Quit", 1f);
			break;
		}
		if (addMsg && text != null)
		{
			NotificationManager.AddNotification(new EmployeeGoneNotification(text, icon, term));
		}
	}

	public void Invest()
	{
		try
		{
			float x = (float)Convert.ToDouble(StockAmount.text);
			x = x.FromCurrency();
			if (x > 0f && GameSettings.Instance.MyCompany.CanMakeTransaction(0f - x))
			{
				string stockName = StockCombo.SelectedItem.ToString();
				StockMarket stockMarket = GameSettings.Instance.StockMarkets.FirstOrDefault((StockMarket stockMarket2) => stockMarket2.Name.Equals(stockName));
				if (stockMarket != null)
				{
					AchievementController.SetInteraction(AchievementController.Mechanics.Bonds);
					GameSettings.Instance.Investments.Add(new Investment(stockMarket, x));
					GameSettings.Instance.MyCompany.MakeTransaction(0f - x, Company.TransactionCategory.Stocks, false, stockMarket.Name);
					UpdateInvestments();
					GameSettings.Instance.TransmitExtraWorth();
				}
			}
		}
		catch (Exception)
		{
			StockAmount.text = 0f.Currency(false);
		}
	}

	public void EndAmountEdit()
	{
		try
		{
			float num = (float)Convert.ToDouble(StockAmount.text);
			StockAmount.text = num.ToString("N0");
		}
		catch (Exception)
		{
			StockAmount.text = 0f.Currency(false);
		}
	}

	public void ToggleInvestmentPanel()
	{
		StocksPanel.SetActive(Stocks.isOn);
		BondsPanel.SetActive(Bonds.isOn);
		if (Stocks.isOn)
		{
			UpdateStocks();
		}
	}

	public void UpdateStocks()
	{
		if (_chartValues.Count != GameSettings.Instance.StockMarkets.Count)
		{
			for (int i = _chartValues.Count; i < GameSettings.Instance.StockMarkets.Count; i++)
			{
				_chartValues.Add(new List<float>());
			}
			int count = _chartValues.Count;
			for (int j = GameSettings.Instance.StockMarkets.Count; j < count; j++)
			{
				_chartValues.RemoveAt(0);
			}
		}
		bool flag = false;
		for (int k = 0; k < GameSettings.Instance.StockMarkets.Count; k++)
		{
			StockMarket stockMarket = GameSettings.Instance.StockMarkets[k];
			stockMarket.SetData(_chartValues[k]);
			if (!StockLegend.Items.Contains(stockMarket.Name))
			{
				StockLegend.Items.Add(stockMarket.Name);
				flag = true;
			}
		}
		int l;
		for (l = 0; l < StockLegend.Items.Count; l++)
		{
			if (!GameSettings.Instance.StockMarkets.Exists((StockMarket x) => x.Name.Equals(StockLegend.Items[l])))
			{
				StockLegend.Items.RemoveAt(l);
				flag = true;
				l--;
			}
		}
		if (flag)
		{
			StockLegend.UpdateItems();
		}
		StockCombo.UpdateContent(GameSettings.Instance.StockMarkets.Select((StockMarket x) => x.Name));
		UpdateStockChart();
	}

	public void UpdateInvestments()
	{
		Investments.Items = GameSettings.Instance.Investments.Cast<object>().ToList();
	}

	public void UpdateStockChart()
	{
		StockChart.Values.Clear();
		StockChart.Colors.Clear();
		int num = Mathf.Min(StockLegend.Items.Count, _chartValues.Count);
		for (int i = 0; i < num; i++)
		{
			if (StockLegend.IsOn(i))
			{
				StockChart.Colors.Add(StockLegend.Colors[i % StockLegend.Colors.Count]);
				StockChart.Values.Add(_chartValues[i]);
			}
		}
		StockChart.UpdateCachedLines();
	}

	private void Start()
	{
		StockLegend.Colors = HUD.GetThemeColors().ToList();
		StockLegend.OnToggle = UpdateStockChart;
		StockChart.ToolTipFunc = (int j, int i, float x) => x.ToString("N3");
		StockChart.HighlightCallback = delegate(int i)
		{
			StockLegend.Highlight(i);
		};
		StockLegend.HighlightCallback = delegate(int i)
		{
			StockChart.Highlighted = i;
		};
		StockAmount.text = 0f.Currency(false);
	}

	public void Show(bool toggle = true)
	{
		bool flag;
		if (toggle)
		{
			flag = Window.ToggleReturn();
		}
		else
		{
			flag = true;
			Window.Show();
		}
		if (flag)
		{
			_newRetires = 0;
			RetireCounter.SetNumber(0);
			UpdateTexts();
			Window.Show();
			ContentsToggle.isOn = GameSettings.Instance.Insurance.ContentInsurance > 0;
			if (Stocks.isOn)
			{
				UpdateStocks();
			}
			TutorialSystem.Instance.StartTutorial("Investments");
		}
	}

	public void TheftUpdate()
	{
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		insurance.ContentInsurance = (ContentsToggle.isOn ? 1 : 0);
		CallInspector.SetActive(!GameSettings.Instance.PassedFireInspection && GameSettings.Instance.sActorManager.Others["FireInspector"].Count == 0);
		TheftText.text = (GameSettings.Instance.PassedFireInspection ? "ContentInsuranceDesc".Loc(insurance.GetContentCoverage(false).ToPercent(), insurance.GetContentBill(false).Currency()) : "FireInspectionInsurance".Loc());
	}

	public void CallFireInspector()
	{
		GameSettings.Instance.SpawnFireInspectors(false);
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			TheftUpdate();
			ContentsToggle.interactable = GameSettings.Instance.PassedFireInspection && !GameSettings.Instance.HasDanger();
			InsuranceAccount insAcc = GameSettings.Instance.Insurance;
			double num = insAcc.Deposits.Where((KeyValuePair<double, SDateTime> x) => SDateTime.GetMonthsFlat(x.Value, SDateTime.Now()) > 0).SumSafe((KeyValuePair<double, SDateTime> x) => x.Key + insAcc.GetDepositInterest(x));
			if (num > 0.0)
			{
				FundsText.text = "BondsInvest".Loc() + ": " + insAcc.Money.Currency() + " - " + "Freetowithdraw".Loc() + ": " + (insAcc.Money - num).Currency();
			}
			else
			{
				FundsText.text = "BondsInvest".Loc() + ": " + insAcc.Money.Currency();
			}
			insAcc.GetDeposits(InterestText[0], InterestText[1], InterestText[2]);
		}
	}

	public void UpdateTexts()
	{
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		Company myCompany = GameSettings.Instance.MyCompany;
		double maxWithdraw = insurance.GetMaxWithdraw();
		double num = valueSlider.value.ToDouble().MapRange(0.0, 1.0, 0.0, Math.Max(0.0, myCompany.Money - 100.0));
		double num2 = valueSlider.value.ToDouble().MapRange(0.0, 1.0, 0.0, Math.Max(0.0, maxWithdraw));
		if (Round && valueSlider.value != 1f)
		{
			double num3 = Math.Max(1.0, Math.Pow(10.0, Math.Floor(Math.Log10(myCompany.Money - 100.0))) / 10.0);
			num = (Math.Round(num / num3) * num3).Clamp(0.0, myCompany.Money - 100.0);
			double num4 = Math.Max(1.0, Math.Pow(10.0, Math.Floor(Math.Log10(maxWithdraw))) / 10.0);
			num2 = (Math.Round(num2 / num4) * num4).Clamp(0.0, maxWithdraw);
		}
		if (!num2.IsValidDouble())
		{
			num2 = 0.0;
		}
		if (!num.IsValidDouble())
		{
			num = 0.0;
		}
		DepositInput.text = num.CurrencyMul().ToString("N0");
		WithdrawInput.text = num2.CurrencyMul().ToString("N0");
		Round = true;
	}

	public void AddRetire()
	{
		_newRetires++;
		RetireCounter.SetNumber(_newRetires);
	}

	public void FixInputfields(int type)
	{
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		Company myCompany = GameSettings.Instance.MyCompany;
		if (type == 0)
		{
			try
			{
				double x = Convert.ToDouble(DepositInput.text);
				x = x.FromCurrency();
				double num = myCompany.Money - 100.0;
				if (num > 0.0)
				{
					x = x.Clamp(0.0, num);
					ResetTexts(x / num);
				}
				else
				{
					ResetTexts();
				}
			}
			catch (Exception)
			{
				ResetTexts();
			}
		}
		if (type != 1)
		{
			return;
		}
		try
		{
			double x2 = Convert.ToDouble(WithdrawInput.text);
			x2 = x2.FromCurrency();
			double maxWithdraw = insurance.GetMaxWithdraw();
			if (maxWithdraw > 0.0)
			{
				x2 = x2.Clamp(0.0, maxWithdraw);
				ResetTexts(x2 / maxWithdraw);
			}
			else
			{
				ResetTexts();
			}
		}
		catch (Exception)
		{
			ResetTexts();
		}
	}

	public void Deposit()
	{
		Company myCompany = GameSettings.Instance.MyCompany;
		try
		{
			double value = Convert.ToDouble(DepositInput.text).FromCurrency();
			value = value.Clamp(0.0, myCompany.Money - 100.0);
			if (value > 0.0)
			{
				AchievementController.SetInteraction(AchievementController.Mechanics.Bonds);
				GameSettings.Instance.Insurance.Deposit(value);
				GameSettings.Instance.Insurance.ChangeAmount(value);
				ResetTexts();
			}
		}
		catch (Exception)
		{
		}
	}

	public void ResetTexts(double val = 0.0)
	{
		Round = false;
		valueSlider.value = (float)val;
		Round = false;
		UpdateTexts();
	}

	public void Withdraw()
	{
		InsuranceAccount insAcc = GameSettings.Instance.Insurance;
		try
		{
			double with = Convert.ToDouble(WithdrawInput.text).FromCurrency();
			with = with.Clamp(0.0, insAcc.GetMaxWithdraw());
			if (!(with > 0.0))
			{
				return;
			}
			double withdrawCost = insAcc.GetWithdrawCost(with);
			if (withdrawCost > 0.0)
			{
				WindowManager.Instance.ShowMessageBox("WithdrawCost".Loc(with.Currency(), withdrawCost.Currency()), true, DialogWindow.DialogType.Question, delegate
				{
					insAcc.Withdraw(with);
					GameSettings.Instance.Insurance.ChangeAmount(0.0 - with);
					ResetTexts();
				});
			}
			else
			{
				insAcc.Withdraw(with);
				GameSettings.Instance.Insurance.ChangeAmount(0.0 - with);
				ResetTexts();
			}
		}
		catch (Exception)
		{
		}
	}
}
