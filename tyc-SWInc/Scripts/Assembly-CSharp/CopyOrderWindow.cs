using System;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class CopyOrderWindow : MonoBehaviour
{
	public GUIWindow Window;

	public VarValueSheet InfoSheet;

	public Text PriceLabel;

	public InputField AmountField;

	public InputField CompletionField;

	public InputField PenaltyField;

	public DatePicker DeadlineField;

	public Toggle DeadlineToggle;

	public Toggle Ongoing;

	public Image MarketTab;

	public Image OutsourceTab;

	public GameObject OutsourcePanel;

	public GameObject TabPanel;

	public GameObject NotOngoingPanel;

	private bool _outsourceMode;

	public Toggle[] OutsourceToggles;

	[NonSerialized]
	private Company[] _outsources = new Company[3];

	[NonSerialized]
	public IStockable[] Products;

	public Company GetOutsource()
	{
		for (int i = 0; i < OutsourceToggles.Length; i++)
		{
			if (OutsourceToggles[i].isOn)
			{
				return _outsources[i];
			}
		}
		return null;
	}

	public void SetTab(bool outsource)
	{
		_outsourceMode = outsource;
		OutsourcePanel.SetActive(outsource);
		MarketTab.color = (outsource ? Color.white : HUD.GetThemeColor(0));
		OutsourceTab.color = (outsource ? HUD.GetThemeColor(0) : Color.white);
		AmountChange();
	}

	public void EnableTab(bool outsource, bool enable)
	{
		if (outsource)
		{
			OutsourceTab.gameObject.SetActive(enable);
			if (!enable)
			{
				SetTab(false);
			}
		}
		else
		{
			MarketTab.gameObject.SetActive(enable);
			if (!enable)
			{
				SetTab(true);
			}
		}
		TabPanel.gameObject.SetActive(MarketTab.gameObject.activeSelf && OutsourceTab.gameObject.activeSelf);
	}

	public void OutsourceChange()
	{
		AmountChange();
	}

	public void Show(params IStockable[] products)
	{
		Show(false, products);
	}

	public void DeadlineChange(bool on)
	{
		DeadlineField.Interactable = on;
		PenaltyField.text = "0";
		PenaltyField.interactable = on;
	}

	public void OngoingChange(bool on)
	{
		NotOngoingPanel.SetActive(!on);
	}

	public void Show(bool onlyOutsource, params IStockable[] products)
	{
		Products = products;
		_outsources[0] = (_outsources[1] = (_outsources[2] = null));
		CompletionField.text = "0";
		PenaltyField.text = "0";
		Ongoing.isOn = false;
		DeadlineToggle.isOn = false;
		DeadlineField.CurrentDate = SDateTime.Now();
		if (Products.Length == 1)
		{
			IStockable stockable = Products[0];
			InfoSheet.SetData(new string[4]
			{
				"Consumerreach".Loc(),
				"Physicalmarketshare".Loc(),
				"Physicalcopiessold".Loc(),
				"Instock".Loc()
			}, new string[4]
			{
				stockable.GetReach().ToString("N0"),
				MarketSimulation.GetPhysicalVsDigital(SDateTime.Now()).ToPercent(),
				stockable.GetTotalPhysicalSales().ToString("N0"),
				stockable.PhysicalCopies.ToString("N0")
			});
			Window.NonLocTitle = "CopiesOf".Loc(stockable.GetName());
			if (GameSettings.Instance.CanOutsourcePrint(products[0].Manufacturing))
			{
				int num = 0;
				foreach (Company item in GameSettings.Instance.GetOutsourcePrint(products[0].Manufacturing))
				{
					_outsources[num] = item;
					num++;
				}
				EnableTab(true, true);
				SetTab(false);
			}
			else
			{
				EnableTab(true, false);
			}
			for (int i = 0; i < _outsources.Length; i++)
			{
				OutsourceToggles[i].gameObject.SetActive(_outsources[i] != null);
				if (_outsources[i] != null)
				{
					OutsourceToggles[i].GetComponentInChildren<Text>().text = _outsources[i].Name + ": " + _outsources[i].GetPrintPrice(products[0]).Currency();
				}
				OutsourceToggles[i].isOn = i == 0;
			}
			EnableTab(false, !onlyOutsource);
		}
		else
		{
			InfoSheet.SetData(new string[2]
			{
				"Products".Loc(),
				"Physicalmarketshare".Loc()
			}, new string[2]
			{
				Products.Length.ToString(),
				MarketSimulation.GetPhysicalVsDigital(SDateTime.Now()).ToPercent()
			});
			Window.NonLocTitle = "CopiesOf".Loc("Product".LocPlural(products.Length));
			EnableTab(false, true);
			EnableTab(true, false);
		}
		AmountField.text = ((Products.Length == 1) ? ApproximateOrderSizeGuess(SimulatedCompany.SimulateProductDistribution(Products[0], GameSettings.Instance.MyCompany.Money * 0.20000000298023224, false)).ToString("N0") : "0");
		if (Products.Length == 1 && Products[0] is AddOnProduct)
		{
			AddOnProduct addOnProduct = (AddOnProduct)Products[0];
			if (addOnProduct.Forced)
			{
				int num2 = AmountField.text.Replace(",", "").ConvertToIntDef(0);
				if (addOnProduct.Parent.PhysicalCopies > num2 + addOnProduct.PhysicalCopies)
				{
					AmountField.text = (addOnProduct.Parent.PhysicalCopies - addOnProduct.PhysicalCopies).ToString("N0");
				}
			}
		}
		Window.Show();
		AmountField.Select();
		TutorialSystem.Instance.StartTutorial("Physical distribution");
	}

	public static int ApproximateOrderSizeGuess(int guess)
	{
		if (guess > 1000000)
		{
			return Mathf.CeilToInt((float)guess / 100000f) * 100000;
		}
		if (guess > 100000)
		{
			return Mathf.CeilToInt((float)guess / 10000f) * 10000;
		}
		if (guess > 10000)
		{
			return Mathf.CeilToInt((float)guess / 1000f) * 1000;
		}
		Mathf.CeilToInt((float)guess / 100f);
		return 0;
	}

	public void AmountChange()
	{
		try
		{
			uint amount = Convert.ToUInt32(AmountField.text.Replace(",", ""));
			PriceLabel.text = Products.SumSafe((IStockable x) => (float)amount * (_outsourceMode ? GetOutsource().GetPrintPrice(x) : x.GetPrintPrice())).Currency();
		}
		catch (Exception)
		{
		}
	}

	public void OKClick()
	{
		try
		{
			uint amount = Convert.ToUInt32(AmountField.text.Replace(",", ""));
			if (amount == 0)
			{
				return;
			}
			if (_outsourceMode)
			{
				Company outsource = GetOutsource();
				float markup = outsource.GetPrintMarkup(Products[0]);
				NetworkPlayer other = NetworkManager.GetPlayer(outsource.NetworkPlayerID);
				uint max = 0u;
				uint perDay = 0u;
				float completion = 0f;
				float penalty = 0f;
				SDateTime? deadline = null;
				if (Ongoing.isOn)
				{
					perDay = amount;
				}
				else
				{
					max = amount;
					completion = CompletionField.text.Replace(",", "").ConvertToFloatDef(0f).FromCurrency();
					penalty = PenaltyField.text.Replace(",", "").ConvertToFloatDef(0f).FromCurrency();
					if (DeadlineToggle.isOn)
					{
						deadline = DeadlineField.CurrentDate;
					}
				}
				IStockable product = Products[0];
				NetworkManager.Instance.TradeController.CreateOffer((uint x) => new PrintTrade(x, NetworkManager.Self, other, new NetworkPrintDeal(x, product, other, markup, completion, penalty, max, perDay, deadline), markup));
				Window.Close();
				return;
			}
			float num = Products.SumSafe((IStockable x) => (float)amount * x.GetPrintPrice());
			if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num))
			{
				GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Distribution, true, "Copy order");
				for (int num2 = 0; num2 < Products.Length; num2++)
				{
					IStockable stockable = Products[num2];
					stockable.PhysicalCopies += amount;
					stockable.AddLoss((float)amount * stockable.GetPrintPrice(), SoftwareProduct.LossType.Copies, true);
				}
				Window.Close();
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), false, DialogWindow.DialogType.Error);
			}
		}
		catch (Exception)
		{
			WindowManager.Instance.ShowMessageBox("InvalidAmount".Loc(), false, DialogWindow.DialogType.Error);
		}
	}
}
