using System;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class StockButton : MonoBehaviour
{
	[NonSerialized]
	private NewStock _stock;

	public Button ActionButton;

	public Image ButtonImage;

	public RawImage Logo;

	public Text ButtonText;

	public Text CompanyText;

	public Text ChangeText;

	public Text PayoutText;

	public Text SliderText;

	public InputField CustomAmount;

	public Slider StockSlider;

	private uint _shares;

	private float _lastWorth;

	public NewStock ActiveStock
	{
		get
		{
			return _stock;
		}
	}

	public void Init(NewStock stock)
	{
		_stock = stock;
		CompanyText.text = _stock.BuyerName;
		Rect res;
		if (LogoController.Instance.TryGetLogoRect(_stock.Buyer, out res))
		{
			Logo.uvRect = res;
			Logo.gameObject.SetActive(true);
		}
		else
		{
			Logo.gameObject.SetActive(false);
		}
		UpdateSliderValues();
		ButtonText.text = (_stock.Buyer.IsLocalPlayer ? "Sell".Loc() : "Buy".Loc());
	}

	private void UpdateSliderValues()
	{
		_shares = _stock.Shares;
		StockSlider.maxValue = _stock.Shares;
		StockSlider.value = _stock.Shares;
		SliderChange();
	}

	public void SliderChange()
	{
		uint num = (uint)StockSlider.value;
		double shareWorth = _stock.ShareWorth;
		_lastWorth = (float)shareWorth;
		SliderText.text = "Share".LocPlural(num, true) + " = " + ((double)num * shareWorth).Currency() + " (" + ((float)num / (float)_stock.Seller.Shares).ToPercent() + ")";
	}

	public void FinishCustomAmount()
	{
		StockSlider.value = Mathf.Clamp(Utilities.RoundToInt((double)CustomAmount.text.Trim().Replace(",", "").ConvertToFloatDef(0f)
			.FromCurrency() / _stock.ShareWorth), StockSlider.minValue, StockSlider.maxValue);
		CustomAmount.gameObject.SetActive(false);
		ActionButton.gameObject.SetActive(true);
	}

	public void ShowCustomAmount()
	{
		uint num = (uint)StockSlider.value;
		double shareWorth = _stock.ShareWorth;
		CustomAmount.gameObject.SetActive(true);
		CustomAmount.Select();
		CustomAmount.text = ((double)num * shareWorth).ToString("#,0.##");
		ActionButton.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			if (_stock.Shares != _shares)
			{
				UpdateSliderValues();
			}
			if ((double)_lastWorth != _stock.ShareWorth)
			{
				SliderChange();
			}
			ButtonImage.color = HUD.GetThemeColor(_stock.Seller.NewStock.IndexOf(_stock) + 1).Alpha(0.75f);
			ChangeText.enabled = true;
			double change = _stock.Change;
			ChangeText.text = ((change >= 0.0) ? "▲" : "▼") + Math.Abs(change).ToPercent();
			ChangeText.color = ((change >= 0.0) ? new Color(0f, 0.25f, 0f) : new Color(0.25f, 0f, 0f));
			PayoutText.text = "Dividends".Loc() + ": " + _stock.Payout.Currency();
		}
	}

	private static void BuyShares(NewStock stock, Company player, uint shares, double sharePrice)
	{
		double cost = (double)shares * sharePrice;
		if (player.CanMakeTransaction(0.0 - cost))
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.Stocks);
			double num = GameSettings.Instance.Loans.SumSafe((Loan x) => (double)x.Months * x.Monthly);
			if (player.CanMakeTransaction(0.0 - cost - num))
			{
				FounderShareHolder founderShareHolder;
				if ((founderShareHolder = stock.Buyer as FounderShareHolder) != null && shares == stock.Shares && !founderShareHolder.Founder.Retired && founderShareHolder.Founder.MyEmployer == GameSettings.Instance.MyCompany && founderShareHolder.Founder.MyActor != null)
				{
					founderShareHolder.Founder.MyActor.Fire(false);
					stock.Seller.TradeStock(player, shares, SDateTime.Now(), cost, stock);
					UpdateParentWindowStocks(stock);
					return;
				}
				NetworkMessaging.SyncedNetworkMessage(NetworkMessaging.SyncType.Stock, stock.Seller.ID ^ ~stock.Buyer.ID, delegate(bool approved)
				{
					if (approved)
					{
						stock.Seller.TradeStock(player, shares, SDateTime.Now(), cost, stock);
						if (stock.Seller.TakeOver.HasValue && stock.Seller.GetShare() >= 0.75)
						{
							NetworkMessaging.SendBeginTakeover(stock.Seller.ID, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
						}
					}
					UpdateParentWindowStocks(stock);
				}, null, null);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("StockLoanError".Loc(), true, DialogWindow.DialogType.Error);
			}
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private static void UpdateParentWindowStocks(NewStock stock)
	{
		CompanyDetailWindow companyDetailWindow = WindowManager.FindWindowType<CompanyDetailWindow>().FirstOrDefault((CompanyDetailWindow x) => x.company == stock.Seller);
		if (companyDetailWindow != null)
		{
			companyDetailWindow.UpdateStocks();
		}
	}

	public void Action()
	{
		BuySharesUI(_stock, (uint)StockSlider.value);
	}

	public static void BuySharesUI(NewStock stock, uint shares)
	{
		if (stock.Seller.TakeOver.HasValue && !stock.Seller.IsLocalPlayer)
		{
			return;
		}
		Company player = GameSettings.Instance.MyCompany;
		if (shares == 0)
		{
			return;
		}
		FounderShareHolder founderShareHolder;
		if ((founderShareHolder = stock.Buyer as FounderShareHolder) != null && !founderShareHolder.Founder.Retired && SDateTime.Now() < founderShareHolder.Expiration)
		{
			WindowManager.Instance.ShowMessageBox("FounderShareBuy".LocColor(founderShareHolder.Founder, founderShareHolder.Expiration.ToCompactString()), true, DialogWindow.DialogType.Error);
		}
		else if (stock.Buyer.IsLocalPlayer)
		{
			MarketSimulation.Active.FindBuyer(stock, shares, SDateTime.Now());
			UpdateParentWindowStocks(stock);
		}
		else if (stock.Buyer.Player)
		{
			if (stock.Seller.CanOwnStock(player))
			{
				NetworkPlayer pl = NetworkManager.GetPlayer(stock.Buyer.NetworkPlayerID);
				if (pl != null)
				{
					NetworkManager.Instance.TradeController.CreateOffer(pl, (float)((double)shares * stock.ShareWorth), (uint id, float offer) => new StockTrade(id, NetworkManager.Self, pl, stock, offer, shares), stock);
				}
				else if (stock.Seller.IsLocalPlayer && stock.Seller.TakeOver.HasValue)
				{
					double nP = Math.Max(stock.InitialWorth, stock.ShareWorth) * 2.0;
					WindowManager.Instance.ShowMessageBox("RaiseShareOffer".Loc(stock.BuyerName, nP.Currency(), (nP * (double)shares).Currency()), true, DialogWindow.DialogType.Question, delegate
					{
						BuyShares(stock, player, shares, nP);
					});
				}
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("CrossHoldingError".Loc(stock.Seller.Name), true, DialogWindow.DialogType.Error);
			}
		}
		else if (stock.Seller.IsLocalPlayer)
		{
			if (stock.Seller.TakeOver.HasValue)
			{
				double nP2 = Math.Max(stock.InitialWorth, stock.ShareWorth) * 2.0;
				WindowManager.Instance.ShowMessageBox("RaiseShareOffer".Loc(stock.BuyerName, nP2.Currency(), (nP2 * (double)shares).Currency()), true, DialogWindow.DialogType.Question, delegate
				{
					BuyShares(stock, player, shares, nP2);
				});
			}
			else if (stock.Change < -0.05000000074505806)
			{
				WindowManager.Instance.ShowMessageBox("RaiseShareOffer".Loc(stock.BuyerName, stock.InitialWorth.Currency(), (stock.InitialWorth * (double)shares).Currency()), true, DialogWindow.DialogType.Question, delegate
				{
					BuyShares(stock, player, shares, stock.InitialWorth);
				});
			}
			else
			{
				BuyShares(stock, player, shares, stock.ShareWorth);
			}
		}
		else if (stock.Seller.CanOwnStock(player))
		{
			BuyShares(stock, player, shares, stock.ShareWorth);
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("CrossHoldingError".Loc(stock.Seller.Name), true, DialogWindow.DialogType.Error);
		}
	}
}
