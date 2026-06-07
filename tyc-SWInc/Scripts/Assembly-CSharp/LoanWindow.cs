using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class LoanWindow : MonoBehaviour
{
	public const float Factor = 10000f;

	public const int MinQuickLoan = 1;

	public const int MaxQuickLoan = 100;

	public const int MinBankLoan = 100;

	public const int MaxBankLoan = 1000;

	public float InterestFactor = 0.01f;

	public GUIWindow Window;

	public GUIListView LoanList;

	public Slider AmountSlider;

	public Slider PeriodSlider;

	public Slider InterestSlider;

	public InputField AmountInput;

	public Text AmountText;

	public Text PeriodText;

	public Text SummaryText;

	public Text LoanButtonLabel;

	public Text InterestCaption;

	public GameObject MultiplayerButton;

	public int Mode;

	public double GetAmountInput()
	{
		return AmountInput.text.Replace(",", "").ConvertToDoubleDef(0.0).FromCurrency()
			.Clamp(0.0, 100000000.0);
	}

	public void SwitchMode(int mode)
	{
		Mode = mode;
		AmountSlider.gameObject.SetActive(mode != 2);
		AmountText.gameObject.SetActive(mode != 2);
		AmountInput.gameObject.SetActive(mode == 2);
		InterestSlider.gameObject.SetActive(mode == 2);
		InterestCaption.gameObject.SetActive(mode == 2);
		switch (Mode)
		{
		case 0:
			LoanButtonLabel.text = "Takeloan".Loc();
			break;
		case 1:
			LoanButtonLabel.text = "ApplyForLoan".Loc();
			break;
		case 2:
			LoanButtonLabel.text = "Request".Loc();
			break;
		}
		UpdateText();
	}

	public void UpdateLoans()
	{
		LoanList.Items = GameSettings.Instance.Loans.Cast<object>().ToList();
	}

	public void Show()
	{
		if (GameSettings.Instance.Difficulty.Loans < 0.5f)
		{
			Window.Close();
		}
		else if (Window.ToggleReturn())
		{
			AmountSlider.value = 0f;
			PeriodSlider.value = 1f;
			InterestSlider.value = 1f;
			AmountInput.text = "0";
			SwitchMode(Mode);
			UpdateLoans();
			UpdateText();
			MultiplayerButton.SetActive(GameSettings.Instance.IsNetworkMode);
		}
	}

	public void UpdateAmountInput()
	{
		double num = GetAmountInput().CurrencyMul();
		AmountInput.text = num.ToString("#,0.##");
		UpdateText();
	}

	public void LoanClick()
	{
		if (Mode == 2)
		{
			double amount = GetAmountInput();
			if (!(amount > 0.0))
			{
				return;
			}
			List<NetworkPlayer> pl = NetworkManager.Instance.Players.Where((NetworkPlayer x) => !x.Self).ToList();
			for (int num = 0; num < pl.Count; num++)
			{
				NetworkPlayer networkPlayer = pl[num];
				Company p = networkPlayer.GetPlayerCompany();
				if (p == null || networkPlayer.Name == null || !networkPlayer.InGame || GameSettings.Instance.Loans.Any((Loan x) => x.Payee == p))
				{
					pl.RemoveAt(num);
					num--;
				}
			}
			if (pl.Count <= 0)
			{
				return;
			}
			WindowManager.Instance.MultiWindow.Show("Loan".Loc(), pl.Select((NetworkPlayer x) => x.Name), delegate(int i)
			{
				NetworkPlayer p2 = pl[i];
				LoanRequest loanRequest = NetworkManager.Instance.TradeController.Trades.Values.OfType<LoanRequest>().FirstOrDefault((LoanRequest x) => x.Receiver == p2);
				if (loanRequest == null || loanRequest.State != NetworkTrade.Status.Waiting)
				{
					Company playerCompany = p2.GetPlayerCompany();
					if (playerCompany != null)
					{
						if (playerCompany.CanMakeTransaction(0.0 - amount))
						{
							NetworkManager.Instance.TradeController.CreateOffer((uint id) => new LoanRequest(id, NetworkManager.Self, p2, (float)amount, InterestSlider.value * InterestFactor, (int)PeriodSlider.value));
						}
						else
						{
							WindowManager.Instance.ShowMessageBox("LoanTooHigh".Loc(p2.Name, amount.Currency()), true, DialogWindow.DialogType.Error);
						}
					}
				}
			}, false);
		}
		else
		{
			if (!(AmountSlider.value > 0f))
			{
				return;
			}
			int months = (int)PeriodSlider.value;
			if (Mode == 0)
			{
				TakeLoan(months, (int)AmountSlider.value, 0);
				PeriodSlider.value = 1f;
				AmountSlider.value = 0f;
				UpdateText();
			}
			else if (Mode == 1)
			{
				HUD.Instance.TeamSelectWindow.Show(false, GameSettings.Instance.GetDefaultTeams("Accounting"), delegate(string[] xs)
				{
					AccountingWork accountingWork = new AccountingWork(AmountSlider.value * 10000f, CalculateInterest(months, (int)AmountSlider.value, 1), months);
					GameSettings.Instance.MyCompany.AddWorkItem(accountingWork);
					accountingWork.SetDevTeams(xs);
				}, "Accounting", "Accounting", "AccountingWork");
			}
		}
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			if (Mode == 2)
			{
				PeriodSlider.maxValue = 240f;
				return;
			}
			int num = MinLoan(Mode);
			int num2 = MaxLoan(Mode);
			AmountSlider.minValue = num;
			AmountSlider.maxValue = num2;
			AmountSlider.interactable = num2 > 0;
			PeriodSlider.maxValue = GetMaxPeriod((int)AmountSlider.value);
		}
	}

	public static int GetMaxPeriod(int amount)
	{
		return 24 + Mathf.Clamp(Mathf.FloorToInt((float)(amount - 1) / 10f), 0, 54) * 4;
	}

	public static void TakeLoan(int months, int amount, int mode)
	{
		if (amount != 0)
		{
			float num = (float)amount * 10000f;
			float num2 = CalculateInterest(months, amount, mode);
			float num3 = (num2 * num + num) / (float)months;
			float monthlyInterest = num2 * num / (float)months;
			GameSettings.Instance.Loans.Add(new Loan(months, num3, num2, monthlyInterest));
			GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Loan, false);
			GameSettings.Instance.TransmitExtraWorth();
			if (HUD.Instance != null && HUD.Instance.loanWindow != null)
			{
				HUD.Instance.loanWindow.UpdateLoans();
			}
		}
	}

	public int GetLoaned()
	{
		return Utilities.CeilToInt(GameSettings.Instance.Loans.Sum((Loan x) => (double)x.Months * x.Monthly / 10000.0) + (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<AccountingWork>()
			where x.Type == AccountingWork.WorkType.LoanApplication
			select x).SumSafe((AccountingWork x) => x.Cost));
	}

	public int MinLoan(int mode)
	{
		int num = ((mode == 0) ? 1 : 100);
		num -= GetLoaned();
		return Mathf.Max(0, num);
	}

	public int MaxLoan(int mode)
	{
		if (GameSettings.Instance.Difficulty.Loans < 0.5f)
		{
			return 0;
		}
		int num = ((mode == 0) ? 100 : 1000);
		num -= GetLoaned();
		return Mathf.Max(0, num);
	}

	public static float CalculateInterest(int months, int amount, int mode)
	{
		return 0.25f + ((float)months / ((mode == 0) ? 24f : 48f) / 6f + (1f - (float)amount / (float)((mode == 0) ? 100 : 1000)) / ((mode == 0) ? 40f : 360f));
	}

	public void UpdateText()
	{
		double num = ((Mode == 2) ? GetAmountInput() : ((double)(AmountSlider.value * 10000f)));
		AmountText.text = num.Currency();
		PeriodText.text = SDateTime.DateDiff((int)PeriodSlider.value * GameSettings.DaysPerMonth);
		float num2 = ((Mode == 2) ? (InterestSlider.value * InterestFactor) : CalculateInterest((int)PeriodSlider.value, (int)AmountSlider.value, Mode));
		double num3 = ((double)num2 * num + num) / (double)PeriodSlider.value;
		double x = num3 * (double)PeriodSlider.value;
		SummaryText.text = string.Format("{0}: {1} - {2}: {3}\n{4}: {5}", "Cost".Loc(), (num * (double)num2).Currency(), "Monthly".Loc(), num3.Currency(), "Total".Loc(), x.Currency(), num2.ToPercent());
	}
}
