using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class AccountingWindow : MonoBehaviour
{
	public OffshoreActionButton ActionPrefab;

	public GUIWindow Window;

	public InputField FunnelingField;

	public Text TaxState;

	public Text TeamLabel;

	public Text PriorityLabel;

	public Text OffShoreAccountAmount;

	public Text HeatLabel;

	public Text[] MetalTips;

	public Slider Priority;

	public Slider MetalLevelSlider;

	public GUILineChart ProChart;

	public RectTransform ActionPanel;

	public Button FunnelButton;

	[NonSerialized]
	private SDateTime _lastUpdate;

	private static string[] _metals = new string[3] { "Gold", "Silver", "Copper" };

	private bool _disableFunnelUpdate;

	public int MetalLevel
	{
		get
		{
			return Mathf.Clamp(Mathf.RoundToInt(MetalLevelSlider.value), 0, 2);
		}
	}

	public void FunnelingChange()
	{
		if (!_disableFunnelUpdate)
		{
			_disableFunnelUpdate = true;
			FunnelingField.text = GetFunnelAmount().ToString("#,0.##");
			_disableFunnelUpdate = false;
		}
	}

	public double GetFunnelAmount()
	{
		return Math.Min(GameSettings.Instance.OffshoreAccount, FunnelingField.text.ConvertToDoubleDef(0.0).FromCurrency());
	}

	public void FunnelMoney()
	{
		double amount = GetFunnelAmount();
		if (amount > 0.0 && GameSettings.Instance.Heat < 10000000f)
		{
			HUD.Instance.TeamSelectWindow.Show(false, GameSettings.Instance.GetDefaultTeams("Accounting"), delegate(string[] xs)
			{
				AccountingWork accountingWork = new AccountingWork(amount);
				GameSettings.Instance.MyCompany.AddWorkItem(accountingWork);
				accountingWork.SetDevTeams(xs);
				GameSettings.Instance.OffshoreAccount -= amount;
				FunnelingField.text = GameSettings.Instance.OffshoreAccount.ToString("#,0.##");
			}, "Accounting", "Accounting", "AccountingWork");
		}
	}

	public void MetalLevelChanged()
	{
		UpdateTips();
	}

	private void Start()
	{
		ProChart.Values = new List<List<float>>
		{
			new List<float>(),
			new List<float>(),
			new List<float>()
		};
		ProChart.ToolTipFunc = (int j, int i, float x) => _metals[j].Loc() + ": " + (x * GameSettings.GetMetalPriceFactor(MetalLevel)).Currency();
		AddAction("DDoS", "DDoSDesc", 5000000f, 0.5f, 0.8f, delegate(Action callBack)
		{
			List<SoftwareProduct> list = (from x in MarketSimulation.Active.GetAllProducts(false)
				where GameSettings.Instance.DDoS.None((KeyValuePair<SoftwareProduct, int> z) => z.Key == x) && !x.DevCompany.Player && !x.DevCompany.IsPlayerOwned() && x.ServerReq > 0f && !x.ExternalHostingActive
				select x).ToList();
			if (list.Count > 0)
			{
				ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
				productWindow.Show(true, "DDoS".Loc(), delegate(SoftwareProduct[] xs)
				{
					if (xs.Length != 0)
					{
						GameSettings.Instance.DDoS.Add(new KeyValuePair<SoftwareProduct, int>(xs[0], 12));
						callBack();
					}
				}, false, false, false, true);
				productWindow.SetContent(list);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("NoDDoSTargets".Loc(), true, DialogWindow.DialogType.Information);
			}
		});
		AddAction("CorporateEspionage", "CorporateEspionageDesc", 500000f, 0.4f, 0.6f, delegate(Action callback)
		{
			List<TechLevel> research = new List<TechLevel>();
			foreach (KeyValuePair<string, List<TechLevel>> techLevel2 in MarketSimulation.Active.TechLevels)
			{
				TechLevel latestTech = MarketSimulation.Active.GetLatestTech(techLevel2.Key, SDateTime.Now(), null, GameSettings.Instance.MyCompany);
				TechLevel techLevel = techLevel2.Value.Last();
				if (latestTech.Year < techLevel.Year)
				{
					research.Add(techLevel);
				}
			}
			if (research.Count > 0)
			{
				WindowManager.Instance.MultiWindow.Show("CorporateEspionage", research.Select((TechLevel x) => x.GetActualString() + " (" + x.ActualYear + ")"), delegate(int x)
				{
					GameSettings.Instance.MyCompany.AddResearch(research[x].Spec, research[x].Year);
					callback();
				}, false);
			}
		});
		AddAction("PayOffEmployee", "PayOffEmployeeDesc", 200000f, 0.25f, 0.3f, delegate(Action callback)
		{
			List<Actor> emps = GameSettings.Instance.sActorManager.Actors.Where((Actor x) => x.IsAliveNotNull() && !x.employee.Founder && !x.employee.Dismissed).ToList();
			WindowManager.Instance.MultiWindow.Show("PayOffEmployee", emps.Select((Actor x) => x.employee.FullName), delegate(int x)
			{
				Actor actor = emps[x];
				actor.QuitAmicably = true;
				actor.Fire(true);
				callback();
			}, false);
		});
		AddAction("BlackMarket", "BlackMarketDesc", 50000f, 0.1f, 0.3f, delegate(Action callback)
		{
			List<Furniture> list = (from x in ObjectDatabase.Instance.GetAllFurnitureComponents()
				where string.IsNullOrEmpty(x.Unlockable) && !x.IsConstructionFurniture() && x.Queryable() && x.IsUnlocked() && x.IsPurchasable() && x.GetCost() <= 100000f
				select x).ToList();
			float num = list.Average((Furniture x) => x.GetSellPrice() * 0.35f);
			int num2 = Mathf.FloorToInt(50000f / num);
			List<InventoryItem> added = new List<InventoryItem>();
			float num3 = 0f;
			float num4 = 0f;
			for (int num5 = 0; num5 < num2; num5++)
			{
				Furniture random = list.GetRandom();
				InventoryItem inventoryItem = InventoryItem.FromPrefab(random, UnityEngine.Random.Range(0f, 0.75f), true);
				added.Add(inventoryItem);
				num3 += inventoryItem.GetCost(random);
				num4 += inventoryItem.SellPrice(random);
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (IGrouping<string, InventoryItem> item in from x in added
				group x by x.GetPrettyName() into x
				orderby x.Key
				select x)
			{
				stringBuilder.AppendLine(item.Count() + " x " + item.Key.FontBold());
			}
			stringBuilder.AppendLine(("Worth".Loc() + ": " + num3.Currency()).FontSize(20f));
			callback();
			WindowManager.Instance.ShowMessageBox(stringBuilder.ToString().TrimEnd(), true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("ActionPutInventory", delegate
			{
				foreach (InventoryItem item2 in added)
				{
					GameSettings.AddToInventory(item2);
				}
			}), new KeyValuePair<string, Action>("SellFor".Loc(num4.Currency()), delegate
			{
				GameSettings.Instance.OffshoreAccount += added.SumSafe((InventoryItem x) => x.SellPrice());
				UISoundFX.PlaySFX("Kaching");
			}));
		});
	}

	public void AddAction(string name, string desc, float money, float minHeat, float maxHeat, Action<Action> action)
	{
		OffshoreActionButton b = UnityEngine.Object.Instantiate(ActionPrefab);
		b.Init(name, desc, money, minHeat, maxHeat, delegate
		{
			action(delegate
			{
				UISoundFX.PlaySFX("Kaching");
				b.Apply();
				AchievementController.SetInteraction(AchievementController.Mechanics.OffshoreAccount);
			});
		});
		b.transform.SetParent(ActionPanel, false);
	}

	public void Toggle()
	{
		if (Window.ToggleReturn())
		{
			TutorialSystem.Instance.StartTutorial("Accounting and taxes");
			AccountingWork backgroundAccounting = GameSettings.Instance.BackgroundAccounting;
			Priority.value = backgroundAccounting.Priority;
			FunnelingField.text = GameSettings.Instance.OffshoreAccount.ToString("#,0.##");
			UpdateTeamLabel();
		}
	}

	private void UpdateTeamLabel()
	{
		TeamLabel.text = GameSettings.Instance.BackgroundAccounting.GetTeam(TeamLabel) ?? "None".Loc();
	}

	public void ChangeTeam()
	{
		GameSettings.Instance.BackgroundAccounting.Assign("Accounting", UpdateTeamLabel);
	}

	public void PriorityChange()
	{
		int priority = Mathf.RoundToInt(Priority.value);
		GameSettings.Instance.BackgroundAccounting.Priority = priority;
		PriorityLabel.text = priority.ToString();
	}

	public void Procure(string metal)
	{
		if (!(GameSettings.Instance.Heat < 10000000f))
		{
			return;
		}
		HUD.Instance.TeamSelectWindow.Show(false, GameSettings.Instance.GetDefaultTeams("Accounting"), delegate(string[] xs)
		{
			AccountingWork accountingWork = new AccountingWork(metal + MetalLevel, GameSettings.Instance.MetalMarkets.First((StockMarket x) => x.Name.Equals(metal)).Value * GameSettings.GetMetalPriceFactor(MetalLevel));
			GameSettings.Instance.MyCompany.AddWorkItem(accountingWork);
			accountingWork.SetDevTeams(xs);
		}, "Accounting", "Accounting", "AccountingWork");
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		float num = GameSettings.Instance.Heat / 10000000f;
		HeatLabel.text = "LawHeat".Loc() + ": " + num.ToPercent().FontColor(Color.Lerp(new Color32(50, 50, 50, byte.MaxValue), new Color32(200, 0, 0, byte.MaxValue), num));
		OffShoreAccountAmount.text = GameSettings.Instance.OffshoreAccount.Currency();
		TaxReport lastTaxReport = GameSettings.Instance.MyCompany.LastTaxReport;
		TaxState.text = "TaxReport".Loc() + ": " + ((lastTaxReport == null) ? "NotApplicableAbbr".Loc() : lastTaxReport.ReportProgress.ToPercent()) + "\n" + "TaxOptimization".Loc() + ": " + GameSettings.Instance.MyCompany.CurrentTaxReport.GetOptimization().Currency();
		InputField funnelingField = FunnelingField;
		bool interactable = (FunnelButton.interactable = GameSettings.Instance.OffshoreAccount > 0.0);
		funnelingField.interactable = interactable;
		SDateTime sDateTime = SDateTime.Now();
		if (!_lastUpdate.Equals(sDateTime, true))
		{
			_lastUpdate = sDateTime;
			for (int i = 0; i < GameSettings.Instance.MetalMarkets.Count; i++)
			{
				GameSettings.Instance.MetalMarkets[i].SetData(ProChart.Values[i]);
			}
			UpdateTips();
			ProChart.UpdateCachedLines();
		}
	}

	private void UpdateTips()
	{
		for (int i = 0; i < GameSettings.Instance.MetalMarkets.Count; i++)
		{
			MetalTips[i].text = (GameSettings.Instance.MetalMarkets[i].Value * GameSettings.GetMetalPriceFactor(MetalLevel)).Currency();
		}
	}
}
