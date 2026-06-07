using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class DealWindow : MonoBehaviour
{
	[NonSerialized]
	public HashSet<string> BlackList = new SHashSet<string>();

	public GUIWindow Window;

	[NonSerialized]
	public Dictionary<uint, Deal> AllDeals = new Dictionary<uint, Deal>();

	private EventList<Deal> NewDeals = new EventList<Deal>();

	[SerializeField]
	private GUIListView NewDealList;

	[SerializeField]
	private GUIListView ActiveDeals;

	public Text ComboDesc;

	public Text FilterText;

	public VarValueSheet DescriptionSheet;

	public VarValueSheet AcceptedDescriptionSheet;

	public GUICombobox Combo;

	public GameObject TeamButton;

	public GameObject AcceptButton;

	public GameObject ManufacturingButton;

	[NonSerialized]
	private HashSet<string> SelectedTeams = new HashSet<string>();

	public GameObject DetailPanel;

	public GameObject ActionPanel;

	public ButtonCounter DealCounter;

	public Text TeamText;

	private int newDealsCount;

	[NonSerialized]
	private List<string> _vars = new List<string>();

	[NonSerialized]
	private List<string> _values = new List<string>();

	private List<uint> _deleteCache = new List<uint>();

	public Deal GetDeal(uint dealID)
	{
		lock (AllDeals)
		{
			return AllDeals.GetOrNull(dealID);
		}
	}

	public void OnDealDblClick(Deal d)
	{
		if (d == null)
		{
			return;
		}
		IPDeal iPDeal;
		if ((iPDeal = d as IPDeal) == null)
		{
			PrintDeal printDeal;
			if ((printDeal = d as PrintDeal) == null)
			{
				ServerDeal serverDeal;
				if ((serverDeal = d as ServerDeal) == null)
				{
					WorkDeal workDeal;
					if ((workDeal = d as WorkDeal) != null)
					{
						WorkDeal workDeal2 = workDeal;
						if (workDeal2.Product != null)
						{
							HUD.Instance.GetProductWindow(null).ShowProductDetails(workDeal2.Product);
						}
					}
				}
				else
				{
					ServerDeal serverDeal2 = serverDeal;
					if (serverDeal2.Product != null)
					{
						HUD.Instance.GetProductWindow(null).ShowProductDetails(serverDeal2.Product);
					}
				}
			}
			else
			{
				PrintDeal printDeal2 = printDeal;
				SoftwareProduct product;
				SimulatedCompany.ProductPrototype productPrototype;
				AddOnProduct product2;
				if ((product = printDeal2.Target as SoftwareProduct) != null)
				{
					HUD.Instance.GetProductWindow(null).ShowProductDetails(product);
				}
				else if ((productPrototype = printDeal2.Target as SimulatedCompany.ProductPrototype) != null && productPrototype.Final != null)
				{
					HUD.Instance.GetProductWindow(null).ShowProductDetails(productPrototype.Final);
				}
				else if ((product2 = printDeal2.Target as AddOnProduct) != null)
				{
					HUD.Instance.GetProductWindow(null).ShowAddonDetails(product2);
				}
			}
		}
		else
		{
			IPDeal iPDeal2 = iPDeal;
			if (iPDeal2._products.Length != 0)
			{
				ProductWindow productWindow = HUD.Instance.GetProductWindow("AllRelease");
				productWindow.Show(true, "Products".Loc());
				productWindow.SetFilters(false, true);
				productWindow.SetContent(iPDeal2._products);
				productWindow.Window.SetParentWindow(Window);
			}
			else if (iPDeal2.Framework != null)
			{
				HUD.Instance.docWindow.FrameworkDialog.Show(iPDeal2.Framework);
			}
		}
	}

	public void Toggle()
	{
		if (GameSettings.Instance.Difficulty.Deals < 0.5f)
		{
			Window.Close();
		}
		else if (Window.ToggleReturn())
		{
			SelectedTeams.Clear();
			Deal[] selected = NewDealList.GetSelected<Deal>();
			if (selected.Length == 1 && selected[0] is WorkDeal)
			{
				SelectedTeams.Clear();
				SelectedTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Deals" + selected[0].Title()));
			}
			else
			{
				SelectedTeams.Clear();
				SelectedTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Deals"));
			}
			UpdateTeamText();
			TeamText.text = SelectedTeams.GetListAbbrev("Team");
			newDealsCount = 0;
			UpdateDealIcon();
		}
	}

	public void SelectTeams()
	{
		string text = null;
		string saveCat = null;
		string taskType = null;
		Deal[] selected = NewDealList.GetSelected<Deal>();
		WorkDeal workDeal;
		if (selected.Length == 1 && (workDeal = selected[0] as WorkDeal) != null)
		{
			text = selected[0].Title();
			saveCat = "Deals" + text;
			taskType = workDeal.GetWorkClassType();
		}
		HUD.Instance.TeamSelectWindow.Show(false, SelectedTeams, delegate(string[] t)
		{
			SelectedTeams.Clear();
			SelectedTeams.AddRange(t);
			UpdateTeamText();
		}, text, saveCat, taskType);
	}

	private void UpdateTeamText()
	{
		TeamText.text = SelectedTeams.GetListAbbrev("Team");
	}

	public bool IsInDeal(SimulatedCompany.ProductPrototype proto, Company company)
	{
		if (!NewDeals.OfType<WorkDeal>().Any((WorkDeal x) => x.Incoming && x.Client != null && x.Client == company && proto == x.Prototype))
		{
			return ActiveDeals.Items.OfType<WorkDeal>().Any((WorkDeal x) => x.Incoming && x.Client != null && x.Client == company && proto == x.Prototype);
		}
		return true;
	}

	public void CancelDueWork(bool onlyLocal)
	{
		foreach (Deal item in NewDeals.ToList())
		{
			if (!item.StillValid(false))
			{
				CancelDeal(item, true, false);
			}
		}
		foreach (Deal item2 in ActiveDeals.Items.OfType<Deal>().ToList())
		{
			if (!item2.StillValid(true))
			{
				if (item2.Performance <= 0f)
				{
					NotificationManager.AddNotification("DealPerformanceCancel".LocColor(item2.OtherCompany, item2.Title().Loc()), "Deal", NotificationManager.NotificationType.Warning);
				}
				CancelDeal(item2, item2.Performance > 0f);
			}
		}
	}

	private void UpdateDealIcon()
	{
		DealCounter.SetNumber(newDealsCount);
	}

	public List<Deal> GetActiveDeals()
	{
		return ActiveDeals.Items.OfType<Deal>().ToList();
	}

	public List<object> GetActiveDealsPerformance()
	{
		return ActiveDeals.Items;
	}

	public static SDateTime? FindReceptionTime()
	{
		Actor randomWhere = GameSettings.Instance.sActorManager.Staff.GetRandomWhere((Actor x) => x.AItype == AI.AIType.Receptionist);
		if (randomWhere != null)
		{
			int num = randomWhere.StaffOn + UnityEngine.Random.Range(0, 3);
			num %= 24;
			SDateTime sDateTime = new SDateTime(UnityEngine.Random.Range(0, 60), num, TimeOfDay.Instance.Day, TimeOfDay.Instance.Month, TimeOfDay.Instance.Year);
			if (sDateTime < SDateTime.Now())
			{
				sDateTime += new SDateTime(1, 0, 0);
			}
			return sDateTime;
		}
		return null;
	}

	public void InsertDeal(Deal deal)
	{
		if (deal.StillValid(false))
		{
			lock (AllDeals)
			{
				AllDeals[deal.ID] = deal;
			}
			ServerDeal serverDeal;
			if ((serverDeal = deal as ServerDeal) != null)
			{
				serverDeal.Product.ExternalHosting = serverDeal.ID;
			}
			NewDeals.Add(deal);
			if (!Window.Shown && !BlackList.Contains(deal.Title()))
			{
				newDealsCount++;
			}
			UpdateDealIcon();
		}
	}

	public void AddDeal(Deal deal, bool fromNetwork = false)
	{
		if (!(GameSettings.Instance.Difficulty.Deals < 0.5f))
		{
			if (!fromNetwork && !deal.Request)
			{
				NetworkMessaging.SendAddDeal(deal, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			SDateTime? t = FindReceptionTime();
			if (t.HasValue)
			{
				AddDeal(deal, t, false);
			}
		}
	}

	public void AddDeal(Deal deal, SDateTime? t, bool toEveryone)
	{
		if (GameSettings.Instance.Difficulty.Deals < 0.5f)
		{
			return;
		}
		if (!t.HasValue)
		{
			AddDeal(deal);
			return;
		}
		if (toEveryone)
		{
			NetworkMessaging.SendAddDeal(deal, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		Actor actor = GameSettings.Instance.SpawnActor(UnityEngine.Random.value > 0.5f, false);
		actor.employee = new Employee(SDateTime.Now(), Employee.EmployeeRole.Lead, UnityEngine.Random.value > 0.5f, Employee.WageBracket.High, GameSettings.Instance.Personalities, "Business", false, null, null, 1f, 0.1f, Employee.Trait.None, Employee.Trait.None);
		actor.employee.Employ(deal.OtherCompany, t.Value, false);
		actor.employee.Salary = 2500f;
		actor.AItype = AI.AIType.Guest;
		actor.deal = deal;
		GameSettings.Instance.sActorManager.AddToAwaiting(actor, t.Value, true);
	}

	public void GenerateBid()
	{
		SDateTime? sDateTime = FindReceptionTime();
		if (!sDateTime.HasValue || GameSettings.Instance.MyCompany.Products.Count <= 0 || GameSettings.Instance.simulation.Companies.Count <= 0)
		{
			return;
		}
		SDateTime sDateTime2 = SDateTime.Now();
		SimulatedCompany simulatedCompany = GameSettings.Instance.simulation.Companies.Values.Where((SimulatedCompany x) => !x.IsSubsidiary()).MaxInstance((SimulatedCompany x) => x.Money * (double)Utilities.RandomRange(0.8f, 1f));
		if (simulatedCompany == null)
		{
			return;
		}
		double num = 0.25;
		SoftwareProduct softwareProduct = null;
		for (int num2 = 0; num2 < GameSettings.Instance.MyCompany.Products.Count; num2++)
		{
			SoftwareProduct softwareProduct2 = GameSettings.Instance.MyCompany.Products[num2];
			if (softwareProduct2.DesignerOwned)
			{
				continue;
			}
			List<float> cashflow = softwareProduct2.GetCashflow(false);
			if (cashflow.Count > 0 && cashflow.Last() > 100000f)
			{
				double marketWeightedQuality = softwareProduct2.GetMarketWeightedQuality(softwareProduct2.GetQuality(sDateTime2));
				if (marketWeightedQuality > num)
				{
					num = marketWeightedQuality;
					softwareProduct = softwareProduct2;
				}
			}
		}
		if (softwareProduct != null)
		{
			IPDeal iPDeal = BidExists(simulatedCompany, softwareProduct);
			if (iPDeal != null)
			{
				CancelDeal(iPDeal);
			}
			IPDeal iPDeal2 = new IPDeal(softwareProduct, simulatedCompany, sDateTime2);
			float num3 = iPDeal2.Worth();
			if (num3 > 5000f && (double)num3 < simulatedCompany.Money * 0.25 && UnityEngine.Random.value * 2f < (GameSettings.IgnoreBusinessRep ? 1f : GameSettings.Instance.MyCompany.BusinessReputation))
			{
				AddDeal(iPDeal2, sDateTime.Value, false);
			}
		}
	}

	private IPDeal BidExists(Company company, SoftwareProduct product)
	{
		return NewDeals.FirstOrDefaultOf((IPDeal x) => x.Request && x.Bidder == company && x._products.Contains(product));
	}

	public void CleanUpDeadPrints()
	{
		List<KeyValuePair<uint, Deal>> list = AllDeals.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			PrintDeal printDeal;
			if ((printDeal = list[i].Value as PrintDeal) != null && printDeal.Target == null)
			{
				NewDeals.Remove(printDeal);
				ActiveDeals.Items.Remove(printDeal);
				AllDeals.Remove(list[i].Key);
			}
		}
	}

	public void CleanUpAllDeals()
	{
		foreach (KeyValuePair<uint, Deal> allDeal in AllDeals)
		{
			if (!ActiveDeals.Items.Contains(allDeal.Value) && !NewDeals.Contains(allDeal.Value))
			{
				_deleteCache.Add(allDeal.Key);
			}
		}
		for (int i = 0; i < _deleteCache.Count; i++)
		{
			AllDeals.Remove(_deleteCache[i]);
		}
		_deleteCache.Clear();
	}

	public void CancelBids(SoftwareProduct product)
	{
		foreach (IPDeal item in NewDeals.OfType<IPDeal>().ToList())
		{
			if (item._products.Contains(product))
			{
				CancelDeal(item, false);
			}
		}
	}

	public void CancelWorkDeal(SimulatedCompany.ProductPrototype proto, Company company)
	{
		foreach (WorkDeal item in (from x in NewDeals.OfType<WorkDeal>()
			where x.Client == company
			select x).ToList())
		{
			if (item.Prototype == proto)
			{
				CancelDeal(item, false);
			}
		}
	}

	public static bool IsDealFor(Deal item, Company company)
	{
		if (item is IPDeal)
		{
			if (item.Request && item.Bidder == company)
			{
				return true;
			}
		}
		else if ((item is WorkDeal || item is PrintDeal || item is ServerDeal) && item.Client == company)
		{
			return true;
		}
		return false;
	}

	public static bool IsDealFor(Deal item, SoftwareProduct p)
	{
		WorkDeal workDeal;
		ServerDeal serverDeal;
		if ((workDeal = item as WorkDeal) != null)
		{
			if (workDeal.Product == p)
			{
				return true;
			}
		}
		else if ((serverDeal = item as ServerDeal) != null)
		{
			if (serverDeal.Product == p)
			{
				return true;
			}
		}
		else
		{
			PrintDeal printDeal;
			if ((printDeal = item as PrintDeal) != null && printDeal.Target == p)
			{
				return true;
			}
			IPDeal iPDeal;
			if ((iPDeal = item as IPDeal) != null && iPDeal._products != null && iPDeal._products.Contains(p))
			{
				return true;
			}
		}
		return false;
	}

	public void CancelCompanyDeals(Company company)
	{
		bool flag = false;
		foreach (Actor item in GameSettings.Instance.sActorManager.Others["Guests"])
		{
			if (item.IsAliveNotNull() && item.deal != null && IsDealFor(item.deal, company))
			{
				item.deal = null;
			}
		}
		foreach (Deal item2 in NewDeals.ToList())
		{
			if (item2 is IPDeal)
			{
				if (item2.Request && item2.Bidder == company)
				{
					CancelDeal(item2, false);
				}
			}
			else if ((item2 is WorkDeal || item2 is PrintDeal || item2 is ServerDeal) && item2.Client == company)
			{
				CancelDeal(item2, false);
			}
		}
		foreach (Deal item3 in ActiveDeals.Items.OfType<Deal>().ToList())
		{
			if (item3.Client == company)
			{
				NotificationManager.AddNotification("DealBuyOutCancelNotification".Loc(item3.Title().Loc(), company.Name), "Deal", NotificationManager.NotificationType.Warning);
				PrintDeal printDeal;
				if (item3 is WorkDeal || item3 is ServerDeal)
				{
					CancelDeal(item3, false);
				}
				else if ((printDeal = item3 as PrintDeal) != null)
				{
					GameSettings.Instance.CancelPrintOrder(printDeal.Target, false);
					flag = true;
				}
			}
		}
		if (flag)
		{
			HUD.Instance.distributionWindow.RefreshOrders();
		}
	}

	public void CancelProductDeals(SoftwareProduct p, bool includeIP)
	{
		foreach (Actor item in GameSettings.Instance.sActorManager.Others["Guests"])
		{
			if (item.IsAliveNotNull() && item.deal != null && IsDealFor(item.deal, p))
			{
				item.deal = null;
			}
		}
		foreach (Deal item2 in NewDeals.ToList())
		{
			if (IsDealFor(item2, p))
			{
				CancelDeal(item2, false);
			}
		}
		foreach (object item3 in ActiveDeals.Items.ToList())
		{
			WorkDeal workDeal;
			ServerDeal serverDeal;
			PrintDeal printDeal;
			if ((workDeal = item3 as WorkDeal) != null)
			{
				if (workDeal.Product != p)
				{
					if (!includeIP)
					{
						continue;
					}
					SimulatedCompany.ProductPrototype prototype = workDeal.Prototype;
					if (((prototype != null) ? prototype.SequelTo : null) != p)
					{
						continue;
					}
				}
				NotificationManager.AddNotification("DealIPCancelNotification".Loc(((Deal)item3).Title().Loc(), p.Name), "Deal", NotificationManager.NotificationType.Warning);
				CancelDeal(workDeal, false);
			}
			else if ((serverDeal = item3 as ServerDeal) != null)
			{
				if (serverDeal.Product == p)
				{
					NotificationManager.AddNotification("DealIPCancelNotification".Loc(((Deal)item3).Title().Loc(), p.Name), "Deal", NotificationManager.NotificationType.Warning);
					CancelDeal(serverDeal, false);
				}
			}
			else if ((printDeal = item3 as PrintDeal) != null && printDeal.Target == p)
			{
				NotificationManager.AddNotification("DealIPCancelNotification".Loc(((Deal)item3).Title().Loc(), p.Name), "Deal", NotificationManager.NotificationType.Warning);
				GameSettings.Instance.CancelPrintOrder(printDeal.Target, false);
				HUD.Instance.distributionWindow.RefreshOrders();
			}
		}
	}

	public void CancelProductDeals(AddOnProduct p)
	{
		foreach (Deal item in NewDeals.ToList())
		{
			if (!(item is WorkDeal) && item is PrintDeal && (item as PrintDeal).Target == p)
			{
				CancelDeal(item, false);
			}
		}
		foreach (object item2 in ActiveDeals.Items.ToList())
		{
			PrintDeal printDeal;
			if (!(item2 is WorkDeal) && (printDeal = item2 as PrintDeal) != null && printDeal.Target == p)
			{
				if (printDeal.Active)
				{
					NotificationManager.AddNotification("DealIPCancelNotification".Loc(((Deal)item2).Title().Loc(), p.Name), "Deal", NotificationManager.NotificationType.Warning);
					GameSettings.Instance.CancelPrintOrder(printDeal.Target, false);
					HUD.Instance.distributionWindow.RefreshOrders();
				}
				else
				{
					CancelDeal(printDeal, false);
				}
			}
		}
	}

	public void CancelDeal(uint deal, bool repercussion)
	{
		Deal value;
		if (AllDeals.TryGetValue(deal, out value))
		{
			CancelDeal(value, repercussion, false);
		}
	}

	public void CancelDeal(Deal deal, bool repercussion = true, bool forEveryone = true)
	{
		if (deal == null)
		{
			return;
		}
		if (forEveryone)
		{
			NetworkMessaging.SendCancelDeal(deal.ID, repercussion, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		if (deal.Active && repercussion)
		{
			float num = deal.Payout();
			if (num > 0f && deal.Company != null && deal.Client != null)
			{
				string bill = deal.Title();
				deal.Company.MakeTransaction(num, Company.TransactionCategory.Deals, true, bill);
				deal.Client.MakeTransaction(0f - num, Company.TransactionCategory.Deals, true, bill);
			}
			if (deal.Company != null)
			{
				deal.Company.ChangeBusinessRep(deal.ReputationEffect(true), deal.ReputationCategory());
			}
		}
		deal.Cancel();
		NewDeals.Remove(deal);
		ActiveDeals.Items.Remove(deal);
	}

	public void AcceptDeal()
	{
		Deal[] selected = NewDealList.GetSelected<Deal>();
		if (selected.Length == 0)
		{
			return;
		}
		foreach (Deal deal in selected)
		{
			NetworkMessaging.SyncedNetworkMessage(NetworkMessaging.SyncType.Deal, deal.ID, delegate(bool x)
			{
				ActuallyAcceptDeal(deal, x);
			}, delegate
			{
				NetworkMessaging.SendCancelDeal(deal.ID, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}, UpdateDesc);
		}
	}

	public void ActuallyAcceptDeal(Deal selected, bool approved)
	{
		if (!approved)
		{
			UpdateDesc();
			return;
		}
		if (!selected.StillValid(false))
		{
			CancelDeal(selected, false);
			return;
		}
		AchievementController.SetInteraction(AchievementController.Mechanics.Deals);
		selected.Accept(GameSettings.Instance.MyCompany);
		ServerDeal item;
		if ((item = selected as ServerDeal) != null && Combo.SelectedItem != null)
		{
			ServerGroup selected2 = Combo.GetSelected<ServerGroup>();
			string server = ((selected2 != null) ? selected2.Name : null);
			GameSettings.Instance.RegisterWithServer(server, item);
			GameSettings.SavePrefServer("Deal", server);
		}
		WorkDeal workDeal;
		if ((workDeal = selected as WorkDeal) != null)
		{
			workDeal.WorkItem.AddDevTeams(SelectedTeams);
			SoftwareWorkItem softwareWorkItem;
			if ((softwareWorkItem = workDeal.WorkItem as SoftwareWorkItem) != null)
			{
				softwareWorkItem.CheckCompetency();
			}
			GameSettings.Instance.TeamDefaults["Deals"] = (from x in SelectedTeams.SelectNotNull(GameSettings.GetTeam)
				select x.Name).ToHashSet();
		}
		NewDeals.Remove(selected);
		if (!selected.CancelOnAccept())
		{
			ActiveDeals.Items.Add(selected);
		}
		HUD.Instance.comingReleaseWindow.CheckRefresh();
		NetworkMeta.CheckDirty();
	}

	public void RejectDeal()
	{
		Deal[] sel = NewDealList.GetSelected<Deal>();
		if (sel.Length == 0)
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("RejectConfirmation".Loc(), true, DialogWindow.DialogType.Question, delegate
		{
			Deal[] array = sel;
			foreach (Deal deal in array)
			{
				CancelDeal(deal, false, false);
			}
		}, "Reject deal");
	}

	private void UpdateNewDeals()
	{
		NewDealList.Items = NewDeals.Where((Deal x) => !BlackList.Contains(x.Title())).Cast<object>().ToList();
		UpdateDesc();
	}

	private void InitNewDeals()
	{
		NewDeals.OnChange = UpdateNewDeals;
	}

	private void Awake()
	{
		InitNewDeals();
	}

	private void UpdateDesc()
	{
		Deal[] selected = NewDealList.GetSelected<Deal>();
		if (selected.Length == 1)
		{
			ActionPanel.SetActive(true);
			AcceptButton.SetActive(true);
			DetailPanel.SetActive(true);
			ManufacturingButton.SetActive(false);
			Deal deal = selected[0];
			Combo.gameObject.SetActive(true);
			ComboDesc.gameObject.SetActive(true);
			if (deal is ServerDeal)
			{
				ComboDesc.text = "Server".Loc() + ":";
				Combo.gameObject.SetActive(true);
				TeamButton.SetActive(false);
				ManufacturingButton.SetActive(false);
				Combo.UpdateContent(GameSettings.Instance.GetAllServerGroups());
				ServerGroup server;
				if (GameSettings.GetPrefServer("Deal", out server))
				{
					Combo.SelectedItem = server;
				}
			}
			else if (deal is WorkDeal)
			{
				ComboDesc.text = "Team".Loc() + ":";
				Combo.gameObject.SetActive(false);
				TeamButton.SetActive(true);
				ManufacturingButton.SetActive(false);
				SelectedTeams.Clear();
				SelectedTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Deals" + deal.Title()));
				UpdateTeamText();
			}
			else if (deal is PrintDeal && ((PrintDeal)deal).Hardware)
			{
				ManufacturingButton.SetActive(true);
				Combo.gameObject.SetActive(false);
				TeamButton.SetActive(false);
				ComboDesc.gameObject.SetActive(false);
			}
			else
			{
				ManufacturingButton.SetActive(false);
				Combo.gameObject.SetActive(false);
				TeamButton.SetActive(false);
				ComboDesc.gameObject.SetActive(false);
			}
			_vars.Clear();
			_values.Clear();
			deal.GetDetailedDescription(_vars, _values);
			DescriptionSheet.SetData(_vars.ToArray(), _values.ToArray());
		}
		else
		{
			ActionPanel.SetActive(selected.Length != 0);
			DetailPanel.SetActive(false);
			DescriptionSheet.SetData(new string[0], new string[0]);
			ManufacturingButton.SetActive(false);
		}
		if (selected.Any((Deal x) => NetworkMessaging.IsSyncing(NetworkMessaging.SyncType.Deal, x.ID)))
		{
			ActionPanel.SetActive(false);
		}
	}

	private void Start()
	{
		DetailPanel.SetActive(false);
		ActionPanel.SetActive(false);
		NewDealList.OnSelectChange = delegate
		{
			UpdateDesc();
		};
		ActiveDeals.OnSelectChange = delegate
		{
			Deal[] selected = ActiveDeals.GetSelected<Deal>();
			if (selected.Length == 1)
			{
				_vars.Clear();
				_values.Clear();
				selected[0].GetDetailedDescription(_vars, _values);
				AcceptedDescriptionSheet.SetData(_vars.ToArray(), _values.ToArray());
			}
			else
			{
				AcceptedDescriptionSheet.SetData(new string[0], new string[0]);
			}
		};
		ActiveDeals.OnDoubleClick = delegate
		{
			Deal firstSelected = ActiveDeals.GetFirstSelected<Deal>();
			if (firstSelected != null)
			{
				OnDealDblClick(firstSelected);
			}
		};
		NewDealList.OnDoubleClick = delegate
		{
			Deal firstSelected = NewDealList.GetFirstSelected<Deal>();
			if (firstSelected != null)
			{
				OnDealDblClick(firstSelected);
			}
		};
		UpdateFilterLabel();
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["AllDeals"] = AllDeals;
		dict["NewDeals"] = NewDeals.Select((Deal x) => x.ID).ToArray();
		dict["ActiveDeals"] = ActiveDeals.Items.Select((object x) => (x as Deal).ID).ToArray();
		dict["Blacklist"] = BlackList.ToArray();
	}

	public void Deserialize(WriteDictionary dict)
	{
		if (!dict.Contains("AllDeals"))
		{
			return;
		}
		InitNewDeals();
		AllDeals = dict.Get("AllDeals", AllDeals);
		BlackList.AddRange(dict.Get("Blacklist", Array.Empty<string>()));
		UpdateFilterLabel();
		NewDeals.AddRange(dict.Get("NewDeals", Array.Empty<uint>()).SelectNotNull((uint x) => AllDeals.GetOrNull(x)));
		ActiveDeals.Items.AddRange(((IList<uint>)dict.Get("ActiveDeals", Array.Empty<uint>())).SelectNotNull((Func<uint, object>)((uint x) => AllDeals.GetOrNull(x))));
		foreach (ServerDeal item in HUD.Instance.dealWindow.AllDeals.Values.OfType<ServerDeal>())
		{
			if (item.Incoming && item.Active)
			{
				GameSettings.Instance.RegisterWithServer(item.activeServer, item);
			}
		}
	}

	public void ChangeFilter()
	{
		string[] filters = new string[8] { "Design", "Development", "Support", "Marketing", "Hosting", "Printing", "Manufacturing", "IntellectualPropertyAbbr" };
		WindowManager.Instance.MultiWindow.ShowMulti("Filter", filters, filters.Select((string x) => !BlackList.Contains(x)).ToArray(), delegate(int[] i)
		{
			BlackList.Clear();
			BlackList.AddRange(i.Select((int x) => filters[x]));
			UpdateNewDeals();
			UpdateFilterLabel();
		}, true, true, true);
	}

	public void UpdateFilterLabel()
	{
		if (BlackList.Count == 0)
		{
			FilterText.text = "Filter".Loc();
			FilterText.transform.parent.GetComponent<Image>().color = Color.white;
			return;
		}
		if (BlackList.Count == 8)
		{
			FilterText.text = "Filter".Loc() + " (" + "Nothing".Loc() + ")";
			FilterText.transform.parent.GetComponent<Image>().color = Color.red;
			return;
		}
		HashSet<string> hashSet = new HashSet<string> { "Design", "Development", "Support", "Marketing", "Hosting", "Printing", "Manufacturing", "IntellectualPropertyAbbr" };
		foreach (string black in BlackList)
		{
			hashSet.Remove(black);
		}
		if (hashSet.Count == 1)
		{
			FilterText.text = "Filter".Loc() + " (" + hashSet.First().Loc() + ")";
			return;
		}
		FilterText.text = "Filter".Loc() + " (" + hashSet.Count + ")";
	}

	public void ShowManufacturing()
	{
		PrintDeal[] selected = NewDealList.GetSelected<PrintDeal>();
		if (selected.Length != 0)
		{
			PrintDeal printDeal = selected.FirstOrDefault((PrintDeal x) => x.Hardware);
			if (printDeal != null)
			{
				int value = (int)(printDeal.Goal / Mathf.Max(1, SDateTime.GetMonthsFlat(SDateTime.Now(), printDeal.EndDate)));
				HUD.Instance.ManufacturingWindow.Show(printDeal.Target.Manufacturing, printDeal.Target.FeaturesBases, printDeal.Target.GetFeaturesFactors(), value);
			}
		}
	}

	public void FixReferences()
	{
		List<Deal> list = ActiveDeals.Items.OfType<Deal>().ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Deal deal = list[i];
			if (deal.FixReferences() == null)
			{
				CancelDeal(deal, false, false);
			}
		}
		list = NewDeals.ToList();
		for (int j = 0; j < list.Count; j++)
		{
			Deal deal2 = list[j];
			if (deal2.FixReferences() == null)
			{
				CancelDeal(deal2, false, false);
			}
		}
	}
}
