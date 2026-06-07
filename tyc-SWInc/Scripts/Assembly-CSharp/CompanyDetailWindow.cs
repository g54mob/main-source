using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class CompanyDetailWindow : MonoBehaviour
{
	public static Company LastShownCompany;

	public StockButton StockButtonPrefab;

	public GUIWindow window;

	[NonSerialized]
	public Company company;

	public RectTransform StockPanel;

	public Text CompanyInfo;

	public Text TakeoverText;

	public GUIListView ShareList;

	public GUIListView PatentList;

	public GUIPieChart chart;

	public Text DistributionDealLabel;

	public Text SellStockText;

	public Text SellStockTitle;

	public Text SellStockButton;

	public Slider MoneySlider;

	public Slider SellStockSlider;

	public InputField DepositValue;

	public InputField WithdrawValue;

	public InputField SellPercent;

	public GameObject StocksPanel;

	public GameObject SubsidiaryPanel;

	public GameObject Subsidiary2Panel;

	public GameObject PiePanel;

	public GameObject PatentSharePanel;

	public GameObject PlayerSellPanel;

	public GameObject NotPublicWarning;

	public GameObject TakeoverButton;

	public GameObject PoachButton;

	public GameObject LogoEditButton;

	public GameObject LeftPanel;

	public GameObject RightPanel;

	public Image PoachIcon;

	public GUIToolTipper PoachTip;

	public Sprite PoachSprite;

	public Sprite TransferSprite;

	public RawImage Logo;

	public Toggle AutonomyToggle;

	public GUIListView Projects;

	public LeadDesignControl LeadControl;

	private List<StockButton> _stockButtons = new List<StockButton>();

	public bool Round = true;

	private bool _initializing;

	private StringBuilder _sb = new StringBuilder();

	[NonSerialized]
	private bool _hasAskedLeadTut;

	private bool _sellStockTextInit;

	[NonSerialized]
	private bool _updateSellChange = true;

	public void GainedFocus()
	{
		if (LeadControl.CurrentEmployee == null)
		{
			return;
		}
		foreach (CompanyDetailWindow item in WindowManager.FindWindowTypeEnum<CompanyDetailWindow>())
		{
			item.LeadControl.ControlThumbnail(item != this);
		}
	}

	public void EditLogo()
	{
		HUD.Instance.logoManagerWindow.Show(company);
	}

	public void Withdraw()
	{
		Company c = GameSettings.Instance.MyCompany;
		try
		{
			double value = Convert.ToDouble(WithdrawValue.text).FromCurrency();
			value = value.Clamp(0.0, company.Money);
			if (!(value > 0.0))
			{
				return;
			}
			if (value >= company.Money - 2.0)
			{
				WindowManager.Instance.ShowMessageBox("SubsidiaryCloseWarning".LocColor(company), true, DialogWindow.DialogType.Warning, delegate
				{
					c.MakeTransaction(company.Money, Company.TransactionCategory.Intercompany, false);
					company.MakeTransaction(0.0 - company.Money, Company.TransactionCategory.Intercompany, false);
					company.MakeTransaction(-3.0, Company.TransactionCategory.NA, false);
					Round = false;
					MoneySlider.value = 0f;
					Round = false;
					UpdateTexts();
				}, "Close subsidiary");
			}
			else
			{
				c.MakeTransaction(value, Company.TransactionCategory.Intercompany, false);
				company.MakeTransaction(0.0 - value, Company.TransactionCategory.Intercompany, false);
				Round = false;
				MoneySlider.value = 0f;
				Round = false;
				UpdateTexts();
			}
		}
		catch (Exception)
		{
		}
	}

	public void Deposit()
	{
		Company myCompany = GameSettings.Instance.MyCompany;
		try
		{
			double value = Convert.ToDouble(DepositValue.text).FromCurrency();
			value = value.Clamp(0.0, myCompany.Money - 100.0);
			if (value > 0.0)
			{
				myCompany.MakeTransaction(0.0 - value, Company.TransactionCategory.Intercompany, false);
				company.MakeTransaction(value, Company.TransactionCategory.Intercompany, false);
				Round = false;
				MoneySlider.value = 0f;
				Round = false;
				UpdateTexts();
			}
		}
		catch (Exception)
		{
		}
	}

	public void UpdateTexts()
	{
		Company myCompany = GameSettings.Instance.MyCompany;
		double num = MoneySlider.value.ToDouble().MapRange(0.0, 1.0, 0.0, Math.Max(0.0, myCompany.Money - 100.0));
		double num2 = MoneySlider.value.ToDouble().MapRange(0.0, 1.0, 0.0, Math.Max(0.0, company.Money));
		if (Round && MoneySlider.value != 1f)
		{
			double num3 = Math.Max(1.0, Math.Pow(10.0, Math.Floor(Math.Log10(myCompany.Money - 100.0))) / 10.0);
			num = (Math.Round(num / num3) * num3).Clamp(0.0, myCompany.Money - 100.0);
			double num4 = Math.Max(1.0, Math.Pow(10.0, Math.Floor(Math.Log10(company.Money))) / 10.0);
			num2 = (Math.Round(num2 / num4) * num4).Clamp(0.0, company.Money);
		}
		if (!num2.IsValidDouble())
		{
			num2 = 0.0;
		}
		if (!num.IsValidDouble())
		{
			num = 0.0;
		}
		DepositValue.text = num.CurrencyMul().ToString("N0");
		WithdrawValue.text = num2.CurrencyMul().ToString("N0");
		Round = true;
	}

	public void FixInputfields(int type)
	{
		if (type == 0)
		{
			try
			{
				double x = Convert.ToDouble(DepositValue.text);
				x = x.FromCurrency();
				double num = GameSettings.Instance.MyCompany.Money - 100.0;
				if (num > 0.0)
				{
					x = x.Clamp(0.0, num);
					Round = false;
					MoneySlider.value = (float)(x / num);
					Round = false;
					UpdateTexts();
				}
				else
				{
					Round = false;
					MoneySlider.value = 0f;
					Round = false;
					UpdateTexts();
				}
			}
			catch (Exception)
			{
				Round = false;
				MoneySlider.value = 0f;
				Round = false;
				UpdateTexts();
			}
		}
		if (type != 1)
		{
			return;
		}
		try
		{
			double x2 = Convert.ToDouble(WithdrawValue.text);
			x2 = x2.FromCurrency();
			double money = company.Money;
			if (money > 0.0)
			{
				x2 = x2.Clamp(0.0, money);
				Round = false;
				MoneySlider.value = (float)(x2 / money);
				Round = false;
				UpdateTexts();
			}
			else
			{
				Round = false;
				MoneySlider.value = 0f;
				Round = false;
				UpdateTexts();
			}
		}
		catch (Exception)
		{
			Round = false;
			MoneySlider.value = 0f;
			Round = false;
			UpdateTexts();
		}
	}

	private void Start()
	{
		LastShownCompany = company;
		_initializing = true;
		company.CleanStock();
		chart.Colors = HUD.GetThemeColors().ToList();
		ShareList["StockSell"].ToggleActive(false, company.IsLocalPlayer);
		window.OnClose = delegate
		{
			company.NewOwnedStock.OnChange = null;
		};
		window.NonLocTitle = company.Name;
		ShareList.Items.AddRange(company.NewOwnedStock.Cast<object>());
		company.NewOwnedStock.OnChange = delegate
		{
			company.NewOwnedStock.Update(ShareList.Items);
		};
		LogoEditButton.SetActive(company.IsLocalPlayer || company.IsPlayerOwned());
		PatentList.Items = company.Patents.Cast<object>().ToList();
		UpdateStocks();
		UpdatePlayerStockSlider();
		TutorialSystem.Instance.StartTutorial("Stocks");
		SimulatedCompany simulatedCompany = company as SimulatedCompany;
		AutonomyToggle.isOn = simulatedCompany != null && simulatedCompany.Autonomous;
		if (simulatedCompany != null)
		{
			LeadControl.Init(simulatedCompany.LeadDesigner);
			LeadControl.gameObject.SetActive(true);
		}
		else
		{
			LeadControl.gameObject.SetActive(false);
		}
		SellStockTitle.text = ((company.Player && !company.LocalPlayer) ? "BuyShares".Loc() : "SellShares".Loc()) + ":";
		SellStockButton.text = ((company.Player && !company.LocalPlayer) ? "Buy".Loc() : "Sell".Loc());
		_initializing = false;
		ShareList.OnDoubleClick = delegate
		{
			NewStock firstSelected = ShareList.GetFirstSelected<NewStock>();
			if (firstSelected != null && !firstSelected.Seller.Bankrupt)
			{
				HUD.Instance.companyWindow.ShowCompanyDetails(firstSelected.Seller);
			}
		};
		RightPanel.SetActive(GameSettings.HasCompletedOrInMission("Mission14"));
	}

	public void ToggleAutonomy(bool value)
	{
		SimulatedCompany simulatedCompany;
		if (!_initializing && (simulatedCompany = company as SimulatedCompany) != null && company.OwnerCompany == GameSettings.Instance.MyCompany)
		{
			simulatedCompany.SetAutonomy(value, true);
		}
	}

	public void UpdateStocks()
	{
		bool flag = company.IsSubsidiary();
		bool active = company.IsPlayerOwned();
		StocksPanel.SetActive(!flag);
		PiePanel.SetActive(!flag);
		PatentSharePanel.SetActive(!flag);
		SubsidiaryPanel.SetActive(active);
		Subsidiary2Panel.SetActive(active);
		PlayerSellPanel.SetActive(company.Player && (company.LocalPlayer || GameSettings.Instance.YearlyNetworkIPO.HasValue));
		TakeoverButton.SetActive(IsTakingOver() || (!flag && !company.IsLocalPlayer && company.CanBuyOut(GameSettings.Instance.MyCompany)));
		MoneySlider.value = 0f;
		UpdateChart();
		for (int i = 0; i < _stockButtons.Count; i++)
		{
			_stockButtons[i].SliderChange();
		}
	}

	public bool IsTakingOver()
	{
		if (company.TakeOver.HasValue)
		{
			return company.IsSoleStock(GameSettings.Instance.MyCompany);
		}
		return false;
	}

	public void SellStocks()
	{
		if (company.Shares != 0)
		{
			double shareWorth = company.GetShareWorth();
			uint num = (uint)SellStockSlider.value;
			if (num == 0)
			{
				return;
			}
			if (!company.IsLocalPlayer)
			{
				if (!company.CanOwnStock(GameSettings.Instance.MyCompany))
				{
					WindowManager.Instance.ShowMessageBox("CrossHoldingError".Loc(company.Name), true, DialogWindow.DialogType.Error);
				}
				else if (GameSettings.Instance.MyCompany.CanMakeTransaction((0.0 - shareWorth) * (double)num))
				{
					company.TradeStock(GameSettings.Instance.MyCompany, num, SDateTime.Now(), shareWorth * (double)num);
					UpdateStocks();
					NotificationManager.SendNotification(new ProductListNotification.MultiplayerStockNotification(GameSettings.Instance.MyCompany, num, (float)company.NewStock.First((NewStock x) => x.Buyer == GameSettings.Instance.MyCompany).Percentage), company.NetworkPlayerID);
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
				}
			}
			else
			{
				MarketSimulation.Active.FindBuyers(company, num, shareWorth, SDateTime.Now());
			}
			return;
		}
		float value = SellStockSlider.value;
		if (!(value >= 500f))
		{
			return;
		}
		KeyValuePair<uint, double> sharesAndPrice = company.GetSharesAndPrice(value);
		if (sharesAndPrice.Key == 0)
		{
			return;
		}
		if (!company.IsLocalPlayer)
		{
			if (!company.CanOwnStock(GameSettings.Instance.MyCompany))
			{
				WindowManager.Instance.ShowMessageBox("CrossHoldingError".Loc(company.Name), true, DialogWindow.DialogType.Error);
			}
			else if (GameSettings.Instance.MyCompany.CanMakeTransaction((0.0 - sharesAndPrice.Value) * (double)sharesAndPrice.Key))
			{
				company.Shares = (uint)Utilities.FloorToInt(company.GetMoneyWithInsurance() / sharesAndPrice.Value);
				company.TradeStock(GameSettings.Instance.MyCompany, sharesAndPrice.Key, SDateTime.Now(), sharesAndPrice.Value * (double)sharesAndPrice.Key);
				UpdateStocks();
				NotificationManager.SendNotification(new ProductListNotification.MultiplayerStockNotification(GameSettings.Instance.MyCompany, sharesAndPrice.Key, (float)company.NewStock.First((NewStock x) => x.Buyer == GameSettings.Instance.MyCompany).Percentage), company.NetworkPlayerID);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
			}
		}
		else
		{
			MarketSimulation.Active.FindBuyers(company, sharesAndPrice.Key, sharesAndPrice.Value, SDateTime.Now());
		}
	}

	public void TakeOver()
	{
		if (IsTakingOver())
		{
			NetworkMessaging.SendBeginTakeover(company.ID, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			UpdateStocks();
			return;
		}
		Company myCompany = GameSettings.Instance.MyCompany;
		if (!company.CanBuyOut(myCompany))
		{
			return;
		}
		if (company.NewStock.Count == 1)
		{
			double buyOutPrice = company.GetBuyOutPrice(myCompany);
			if (myCompany.CanMakeTransaction(0.0 - buyOutPrice))
			{
				TakeOverSub();
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
			}
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("StockBuyOutError".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	private void TakeOverSub()
	{
		Company cmp = company;
		if (cmp is SimulatedCompany && SDateTime.GetMonthsFlat(cmp.Founded, SDateTime.Now()) <= 12)
		{
			WindowManager.Instance.ShowMessageBox("CompanyBuyoutRestriction".Loc(), false, DialogWindow.DialogType.Error);
			return;
		}
		if (GameSettings.Instance.MyCompany.WorkItems.OfType<LegalWork>().Any((LegalWork x) => x.GetNetworkDealState() != WorkItem.NetworkDealState.Receiver && x.Plaintiff == cmp))
		{
			WindowManager.Instance.ShowMessageBox("LawsuitTakeover".Loc(), false, DialogWindow.DialogType.Error);
			return;
		}
		if (cmp.Player)
		{
			cmp.BeginTakeover(GameSettings.Instance.MyCompany);
			AchievementController.SetAchievement("BUYPLAYER");
			UpdateStocks();
			return;
		}
		WindowManager.Instance.ShowMessageBox("SubsidiaryPrompt".LocColor(cmp), true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Takeover", delegate
		{
			cmp.BuyOut(new Company[1] { GameSettings.Instance.MyCompany }, false, SDateTime.Now());
			GameSettings.Instance.ClearBuyouts();
			GameSettings.Instance.RegisterStat("Takeover", 1f);
			if (!AchievementController.HasAchievement("BUYOUTSTREAK"))
			{
				List<float> list = GameSettings.Instance.MiscStats["Takeover"];
				float num = 0f;
				for (int i = 0; i < 12; i++)
				{
					int num2 = list.Count - 1 - i;
					if (num2 >= 0)
					{
						num += list[num2];
					}
				}
				if (num >= 5f)
				{
					AchievementController.SetAchievement("BUYOUTSTREAK");
				}
			}
		}), new KeyValuePair<string, Action>("Subsidiary", delegate
		{
			int num = Mathf.FloorToInt((GameSettings.IgnoreBusinessRep ? 1f : GameSettings.Instance.MyCompany.BusinessReputation) * 6f);
			if (!Cheats.InfiniteSubs && GameSettings.Instance.simulation.GetAllCompanies().Count((Company x) => x.IsPlayerOwned()) >= num)
			{
				WindowManager.Instance.ShowMessageBox("SubsidiaryRepError".Loc(num), true, DialogWindow.DialogType.Error);
			}
			else
			{
				WindowManager.SpawnInputDialog("SubsidiaryDeposit".Loc(), "Subsidiary".Loc(), (GameSettings.Instance.MyCompany.Money * 0.10000000149011612).CurrencyMul().ToString("N0"), delegate(string x)
				{
					try
					{
						float num2 = ((float)Convert.ToDouble(x)).FromCurrency();
						double buyOutPrice = company.GetBuyOutPrice(GameSettings.Instance.MyCompany);
						if (num2 < 1f)
						{
							WindowManager.Instance.ShowMessageBox("SubsidiaryDepositError".Loc(), true, DialogWindow.DialogType.Error);
						}
						else if (!GameSettings.Instance.MyCompany.CanMakeTransaction(0.0 - buyOutPrice - (double)num2 - 100.0))
						{
							WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
						}
						else
						{
							AchievementController.SetInteraction(AchievementController.Mechanics.Subsidiaries);
							GameSettings.Instance.MyCompany.MakeTransaction(0.0 - buyOutPrice - (double)num2, Company.TransactionCategory.Stocks, false);
							double money = cmp.Money;
							cmp.MakeTransaction(num2, Company.TransactionCategory.Intercompany, false);
							cmp.MakeTransaction(0.0 - money, Company.TransactionCategory.Dividends, false);
							cmp.MakeSubsidiary(GameSettings.Instance.MyCompany, SDateTime.Now());
							LogoEditButton.SetActive(true);
							UpdateStocks();
						}
					}
					catch (Exception)
					{
					}
				});
			}
		}), new KeyValuePair<string, Action>("Cancel", delegate
		{
		}));
	}

	private void UpdateChart()
	{
		if (PiePanel.activeSelf)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			dictionary[company.Name] = (float)company.GetShare();
			for (int i = 0; i < company.NewStock.Count; i++)
			{
				NewStock newStock = company.NewStock[i];
				dictionary[newStock.BuyerName] = (float)newStock.Percentage;
			}
			chart.Values = dictionary.Values.ToList();
			chart.SetLabels(dictionary.Keys);
			chart.UpdateCachedPie();
		}
	}

	private void UpdateStockButtons()
	{
		bool flag = false;
		List<NewStock> list = company.NewStock.OrderByDescending((NewStock x) => x.Shares).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			if (num >= _stockButtons.Count)
			{
				flag = true;
				StockButton stockButton = UnityEngine.Object.Instantiate(StockButtonPrefab);
				stockButton.Init(list[num]);
				stockButton.transform.SetParent(StockPanel, false);
				_stockButtons.Add(stockButton);
			}
			else if (!_stockButtons[num].gameObject.activeSelf || _stockButtons[num].ActiveStock != list[num])
			{
				flag = true;
				_stockButtons[num].Init(list[num]);
				_stockButtons[num].gameObject.SetActive(true);
			}
		}
		for (int num2 = list.Count; num2 < _stockButtons.Count; num2++)
		{
			if (_stockButtons[num2].gameObject.activeSelf)
			{
				_stockButtons[num2].gameObject.SetActive(false);
				flag = true;
			}
		}
		NotPublicWarning.SetActive(company.NewStock.Count == 0);
		if (flag)
		{
			UpdateStocks();
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		Logo.uvRect = LogoController.Instance.GetLogoRect(company);
		if (company.Bankrupt)
		{
			window.Close();
		}
		SimulatedCompany simulatedCompany;
		if (company.IsPlayerOwned() && (simulatedCompany = company as SimulatedCompany) != null)
		{
			Projects.Items.SyncContent<SimulatedCompany.ProductPrototype>(simulatedCompany.Releases, simulatedCompany.ProjectQueue);
			if (simulatedCompany.CurrentAddonProject != null && !Projects.Items.Contains(simulatedCompany.CurrentAddonProject))
			{
				Projects.Items.Add(simulatedCompany.CurrentAddonProject);
			}
		}
		if (IsTakingOver())
		{
			TakeoverText.text = "TakeoverCancel".Loc();
		}
		else if (TakeoverButton.activeSelf)
		{
			TakeoverText.text = "Takeover".Loc() + ": " + company.GetBuyOutPrice(GameSettings.Instance.MyCompany).Currency();
		}
		UpdateStockButtons();
		_sb.Clear();
		AppendString("Worth", company.GetMoneyWithInsurance(true, true).Currency());
		if (company.NewStock.Count > 0)
		{
			AppendString("Share", "CompanySharesDetail".Loc(company.GetShare().ToPercent(), company.Shares.ToString("N0"), company.GetShareWorth().Currency()));
		}
		UpdatePlayerStockSlider();
		AppendString("Founded", company.Founded.ToCompactString());
		AppendString("Products", company.Products.Count.ToString());
		AppendString("OriginalIPs", company.Products.Count((SoftwareProduct x) => !x.Traded).ToString());
		AppendString("CompaniesBought", company.CompaniesBought.ToString());
		AppendString("Specialization", GetSpecialization());
		bool flag = company is SimulatedCompany;
		UpdatePoachButton();
		CompanyInfo.text = _sb.ToString().TrimEnd();
	}

	public void UpdatePoachButton()
	{
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = company as SimulatedCompany) != null && !simulatedCompany.CampaignProtected && (!simulatedCompany.IsSubsidiary() || simulatedCompany.IsPlayerOwned()))
		{
			GUIToolTipper component = PoachButton.GetComponent<GUIToolTipper>();
			component.TooltipDescription = "";
			Button component2 = PoachButton.GetComponent<Button>();
			component2.interactable = true;
			if (simulatedCompany.LeadDesigner != LeadControl.CurrentEmployee)
			{
				LeadControl.Init(simulatedCompany.LeadDesigner);
			}
			if (simulatedCompany.IsPlayerOwned())
			{
				PoachButton.SetActive(true);
				PoachIcon.sprite = TransferSprite;
				PoachTip.ToolTipValue = "TransferEmployee";
				return;
			}
			PoachIcon.sprite = PoachSprite;
			PoachTip.ToolTipValue = "PoachEmployee";
			if (simulatedCompany.LeadDesigner != null)
			{
				SDateTime sDateTime = simulatedCompany.LeadDesigner.Hired + 6;
				if (simulatedCompany.LeadDesigner.PlayerQuarantine.HasValue && simulatedCompany.LeadDesigner.PlayerQuarantine.Value > sDateTime)
				{
					sDateTime = simulatedCompany.LeadDesigner.PlayerQuarantine.Value;
				}
				if (SDateTime.Now() > sDateTime)
				{
					PoachButton.SetActive(true);
					if (!_hasAskedLeadTut)
					{
						_hasAskedLeadTut = true;
						TutorialSystem.Instance.StartTutorial("Lead Designers");
					}
				}
				else
				{
					PoachButton.SetActive(true);
					component2.interactable = false;
					component.TooltipDescription = "PoachWait".Loc(SDateTime.DateDiff(SDateTime.Now(), sDateTime));
				}
			}
			else
			{
				PoachButton.SetActive(false);
			}
		}
		else
		{
			PoachButton.SetActive(false);
		}
	}

	public void PoachLead()
	{
		SimulatedCompany sc = company as SimulatedCompany;
		if (sc.IsPlayerOwned() && sc.LeadDesigner == null)
		{
			List<Employee> list = (from x in GameSettings.Instance.sActorManager.Actors
				where !x.employee.Founder && x.employee.IsRole(Employee.EmployeeRole.Designer, true) && !x.employee.Dismissed
				select x.employee).ToList();
			if (list.Count <= 0)
			{
				return;
			}
			HUD.Instance.leadDesignWindow.Show(list, null, null, delegate(Employee x)
			{
				if (x.MyActor != null)
				{
					x.MyActor.Dismiss(true);
					x.RefreshUpfrontDemand(true);
					x.Employ(sc, SDateTime.Now(), true);
					sc.LeadDesigner = x;
					NetworkMessaging.MoveLeadDesigner(x, sc, false, false);
				}
			});
		}
		else if (sc.LeadDesigner.MyActor == null)
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.LeadDesigner);
			sc.LeadDesigner.MyEmployer = sc;
			sc.LeadDesigner.RefreshUpfrontDemand(sc.IsPlayerOwned());
			HUD.Instance.hireWindow.HireWin.ShowSpecific(new List<Employee> { sc.LeadDesigner });
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("MoveLeadDesignerOnPremises".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private void UpdatePlayerStockSlider()
	{
		if (!company.Player)
		{
			return;
		}
		if (company.IsLocalPlayer)
		{
			double possibleStockWorth = company.GetPossibleStockWorth();
			if (company.GetMoneyWithInsurance() <= 0.0 || possibleStockWorth < 500.0 || company.StockQuarantine > 0)
			{
				if (SellStockSlider.interactable)
				{
					SellStockSlider.value = 0f;
					SellStockSlider.maxValue = 0f;
					SellStockSlider.interactable = false;
					_updateSellChange = false;
					SellPercent.text = "0";
					_updateSellChange = true;
					SellPercent.interactable = false;
				}
				if (company.StockQuarantine > 0)
				{
					SellStockText.text = "Quarantined".Loc() + ": " + SDateTime.DateDiff(company.StockQuarantine);
				}
				else
				{
					SellStockText.text = "NoInterest".Loc();
				}
				return;
			}
			if (company.Shares != 0)
			{
				uint num = (uint)(possibleStockWorth / company.GetShareWorth());
				if (!Mathf.Approximately(SellStockSlider.maxValue, num) || !SellStockSlider.interactable)
				{
					SellStockSlider.maxValue = num;
					SellStockSlider.wholeNumbers = true;
					SellStockSlider.interactable = true;
					SellPercent.interactable = true;
					SellStockSlider.value = num;
					StockSliderChanged();
				}
				else if (!_sellStockTextInit)
				{
					StockSliderChanged();
				}
			}
			else
			{
				float num2 = (float)possibleStockWorth;
				if (!Mathf.Approximately(SellStockSlider.maxValue, num2) || !SellStockSlider.interactable)
				{
					SellStockSlider.maxValue = num2;
					SellStockSlider.wholeNumbers = false;
					SellStockSlider.interactable = true;
					SellPercent.interactable = true;
					SellStockSlider.value = num2;
					StockSliderChanged();
					_sellStockTextInit = true;
				}
				else if (!_sellStockTextInit)
				{
					StockSliderChanged();
				}
			}
			_sellStockTextInit = true;
			return;
		}
		double num3 = 0.0;
		if (GameSettings.Instance.YearlyNetworkIPO.HasValue)
		{
			int num4 = Mathf.Min(SDateTime.GetMonthsFlat(company.Founded, SDateTime.Now()), SDateTime.GetMonthsFlat(GameSettings.Instance.MyCompany.Founded, SDateTime.Now()));
			num3 = GameSettings.Instance.YearlyNetworkIPO.Value * (float)(num4 / 12);
		}
		num3 = (num3 - (1.0 - company.GetShare())).Clamp(0.0, 0.75);
		if (num3 < 0.0 || num3.Appx(0.0) || company.GetMoneyWithInsurance() <= 0.0 || company.StockQuarantine > 0)
		{
			if (SellStockSlider.interactable)
			{
				SellStockSlider.value = 0f;
				SellStockSlider.maxValue = 0f;
				SellStockSlider.interactable = false;
				_updateSellChange = false;
				SellPercent.text = "0";
				_updateSellChange = true;
				SellPercent.interactable = false;
			}
			if (company.TakeOver.HasValue)
			{
				SellStockText.text = "Takeover".Loc() + ": " + SDateTime.DateDiff(SDateTime.Now(), company.TakeOver.Value + SDateTime.GetHour(1));
			}
			else if (company.StockQuarantine > 0)
			{
				SellStockText.text = "Quarantined".Loc() + ": " + SDateTime.DateDiff(company.StockQuarantine);
			}
			else
			{
				SellStockText.text = "NotSellingShares".Loc();
			}
			return;
		}
		double d;
		if (company.Shares != 0)
		{
			NewStock newStock = GameSettings.Instance.MyCompany.NewOwnedStock.FirstOrDefault((NewStock x) => x.Seller == company);
			float num5 = ((float?)((newStock != null) ? new uint?(newStock.Shares) : ((uint?)null))) ?? 0f;
			d = (0.0 - num3 * (double)company.Shares * (double)company.Shares) / (num3 * (double)company.Shares + (double)num5 - (double)company.Shares);
			d = Math.Floor(d);
		}
		else
		{
			d = num3 * company.GetMoneyWithInsurance() / (1.0 - num3);
		}
		if ((double)SellStockSlider.maxValue != d || !SellStockSlider.interactable)
		{
			SellStockSlider.maxValue = (float)d;
			SellStockSlider.wholeNumbers = true;
			SellStockSlider.interactable = true;
			SellPercent.interactable = true;
			SellStockSlider.value = (float)d;
			StockSliderChanged();
		}
		else if (!_sellStockTextInit)
		{
			StockSliderChanged();
		}
		_sellStockTextInit = true;
	}

	public void SellPercentChange()
	{
		if (_updateSellChange)
		{
			float num = Mathf.Clamp01(SellPercent.text.ConvertToFloatDef(0f) / 100f);
			if (company.Shares != 0)
			{
				float value = num * (float)company.Shares * (float)company.Shares / (company.GetOwnShares() - num * (float)company.Shares);
				SellStockSlider.value = Mathf.Clamp(value, SellStockSlider.minValue, SellStockSlider.maxValue);
			}
			else
			{
				double num2 = (double)num * company.GetMoneyWithInsurance() / (double)(1f - num);
				SellStockSlider.value = Mathf.Clamp((float)num2, SellStockSlider.minValue, SellStockSlider.maxValue);
			}
		}
	}

	public void StockSliderChanged()
	{
		if (company.Shares != 0)
		{
			double shareWorth = company.GetShareWorth();
			uint num = (uint)SellStockSlider.value;
			SellStockText.text = "Share".LocPlural(num, true) + " = " + (shareWorth * (double)num).Currency();
			_updateSellChange = false;
			float num2;
			if (company.LocalPlayer)
			{
				float ownShares = company.GetOwnShares();
				num2 = ownShares / (float)company.Shares - ownShares / (float)(company.Shares + num);
			}
			else
			{
				NewStock newStock = GameSettings.Instance.MyCompany.NewOwnedStock.FirstOrDefault((NewStock x) => x.Seller == company);
				float num3 = ((float?)((newStock != null) ? new uint?(newStock.Shares) : ((uint?)null))) ?? 0f;
				num2 = (num3 + (float)num) / (float)(company.Shares + num) - num3 / (float)company.Shares;
			}
			SellPercent.text = (num2 * 100f).ToString("0.#");
			_updateSellChange = true;
		}
		else
		{
			double moneyWithInsurance = company.GetMoneyWithInsurance();
			moneyWithInsurance = (double)SellStockSlider.value / ((double)SellStockSlider.value + moneyWithInsurance);
			SellStockText.text = SellStockSlider.value.Currency();
			_updateSellChange = false;
			SellPercent.text = (moneyWithInsurance * 100.0).ToString("0.#");
			_updateSellChange = true;
		}
	}

	private void AppendString(string name, string value)
	{
		if (value != null)
		{
			_sb.Append(name.Loc().FontBold());
			_sb.Append(": ");
			_sb.AppendLine(value);
		}
	}

	public string GetSpecialization()
	{
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = company as SimulatedCompany) != null)
		{
			List<string> list = new List<string>();
			foreach (IGrouping<string, KeyValuePair<string, string>> item in from x in simulatedCompany.Categories
				group x by x.Key)
			{
				if (item.Count() > 1 || item.First().Value == null)
				{
					list.Add(item.Key.LocSW());
					continue;
				}
				foreach (KeyValuePair<string, string> item2 in item)
				{
					list.Add(item.Key.LocSWFull(item2.Value));
				}
			}
			return Newspaper.MakeList(list);
		}
		return null;
	}

	public void ShowChart()
	{
		HUD.Instance.companyChart.Show(company, window.Modal ? window : null);
	}

	public void ShowProducts()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("AllRelease");
		productWindow.Show(true, "CompanyReleases".Loc(company.Name), false, window.Modal);
		productWindow.SetFilters(false, true);
		productWindow.SetCompany(company.ID);
		if (window.Modal)
		{
			productWindow.Window.SetParentWindow(window);
		}
	}

	public void ShowAddOns()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("Addons");
		productWindow.Show(true, "CompanyReleases".Loc(company.Name), false, window.Modal);
		productWindow.InitMode(1);
		productWindow.SetFilters(false, true);
		productWindow.SetCompany(company.ID);
		if (window.Modal)
		{
			productWindow.Window.SetParentWindow(window);
		}
	}

	public void ShowTimeLine()
	{
		HUD.Instance.TimeLineWindow.Show(company, window.Modal, window);
	}

	public void SelectSubSimTypes()
	{
		SimulatedCompany cs;
		if ((cs = company as SimulatedCompany) == null || !cs.IsPlayerOwned())
		{
			return;
		}
		Dictionary<string, string[]> types = cs.Type.GetTypes();
		List<KeyValuePair<SoftwareType, IManufacturable>> actualTypes = new List<KeyValuePair<SoftwareType, IManufacturable>>();
		foreach (KeyValuePair<string, string[]> item in types)
		{
			SoftwareType value;
			if (!MarketSimulation.Active.SoftwareTypes.TryGetValue(item.Key, out value))
			{
				continue;
			}
			if (item.Value == null || item.Value.Any((string x) => x == null))
			{
				foreach (SoftwareCategory value6 in value.Categories.Values)
				{
					actualTypes.Add(new KeyValuePair<SoftwareType, IManufacturable>(value, value6));
				}
				continue;
			}
			string[] value2 = item.Value;
			foreach (string key in value2)
			{
				SoftwareCategory value3;
				if (value.Categories.TryGetValue(key, out value3))
				{
					actualTypes.Add(new KeyValuePair<SoftwareType, IManufacturable>(value, value3));
				}
			}
		}
		if (cs.Type.Addons != null)
		{
			foreach (KeyValuePair<string, string> key2 in cs.Type.Addons.Keys)
			{
				SoftwareType value4;
				SoftwareAddOn value5;
				if (MarketSimulation.Active.SoftwareTypes.TryGetValue(key2.Key, out value4) && value4.AddOns.TryGetValue(key2.Value, out value5))
				{
					actualTypes.Add(new KeyValuePair<SoftwareType, IManufacturable>(value4, value5));
				}
			}
		}
		bool[] array = new bool[actualTypes.Count];
		foreach (KeyValuePair<string, string> type in cs.Categories)
		{
			if (type.Value == null)
			{
				for (int num2 = 0; num2 < actualTypes.Count; num2++)
				{
					if (actualTypes[num2].Key.Name.Equals(type.Key))
					{
						array[num2] = true;
					}
				}
			}
			else
			{
				int num3 = actualTypes.FindIndex((KeyValuePair<SoftwareType, IManufacturable> x) => x.Key.Name.Equals(type.Key) && x.Value.GetActualName().Equals(type.Value));
				if (num3 >= 0)
				{
					array[num3] = true;
				}
			}
		}
		foreach (KeyValuePair<string, string> type2 in cs.AddonDev)
		{
			int num4 = actualTypes.FindIndex((KeyValuePair<SoftwareType, IManufacturable> x) => x.Key.Name.Equals(type2.Key) && x.Value.GetActualName().Equals(type2.Value));
			if (num4 >= 0)
			{
				array[num4] = true;
			}
		}
		WindowManager.Instance.MultiWindow.ShowMulti("Specialization", actualTypes.Select((KeyValuePair<SoftwareType, IManufacturable> x) => x.Value.GetPrettyName()), array, delegate(int[] xs)
		{
			cs.Categories.Clear();
			cs.AddonDev.Clear();
			for (int i = 0; i < xs.Length; i++)
			{
				KeyValuePair<SoftwareType, IManufacturable> keyValuePair = actualTypes[xs[i]];
				SoftwareCategory softwareCategory;
				SoftwareAddOn softwareAddOn;
				if ((softwareCategory = keyValuePair.Value as SoftwareCategory) != null)
				{
					cs.Categories.Add(new KeyValuePair<string, string>(keyValuePair.Key.Name, softwareCategory.Name));
				}
				else if ((softwareAddOn = keyValuePair.Value as SoftwareAddOn) != null)
				{
					cs.AddonDev.Add(new KeyValuePair<string, string>(keyValuePair.Key.Name, softwareAddOn.Name));
				}
			}
		});
	}
}
