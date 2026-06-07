using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class ProductWindow : MonoBehaviour
{
	public static string[] TechSpecs;

	public static Dictionary<string, TechLevel> CurrentTechs;

	public GUIWindow Window;

	public GameObject ProductDetailWindow;

	public GUIListView ProductList;

	public Button OKButton;

	public Button CancelButton;

	public FlexibleGridLayout ButtonPanel;

	public GameObject ThumbnailObject;

	public RawImage Thumbnail;

	[NonSerialized]
	public List<SoftwareProduct> Content;

	[NonSerialized]
	private Action<SoftwareProduct[]> OnCloseAction;

	private string _title;

	[NonSerialized]
	public SoftwareProduct PortFilter;

	[NonSerialized]
	public bool CategoryDisabled;

	[NonSerialized]
	public bool WithMock;

	[NonSerialized]
	public bool NotMe;

	[NonSerialized]
	public bool LimitTech;

	[NonSerialized]
	private FeatureBase[] FeatureCheck;

	public ProductWindowButton[] Buttons;

	public ProductWindowButton AddonButton;

	public ProductWindowButton ExclusivityButton;

	public Toggle[] ModeToggles;

	public Toggle ArchivedToggle;

	private string SWTypeFilter;

	private uint _companyFilter;

	private HashSet<string> SWCategoryFilter;

	[NonSerialized]
	private bool _init;

	public int Mode;

	private bool _archiveAvailable;

	[NonSerialized]
	private Dictionary<int, ValueTuple<GUIColumn, bool>> _sort = new Dictionary<int, ValueTuple<GUIColumn, bool>>();

	[NonSerialized]
	private IDisplayable _lastdisplayed;

	[NonSerialized]
	private bool CanApplyFilters;

	public void SetArchiveMode(bool hide, bool active)
	{
		DoArchiveMode(ProductList["ProductArchived"], Mode == 0 && active && hide);
		DoArchiveMode(ProductList["AddOnArchived"], Mode == 1 && active && hide);
	}

	private void DoArchiveMode(GUIColumn c, bool hide)
	{
		if (!(c == null))
		{
			if (hide)
			{
				c.FilterBool = false;
				c.ForceFilter = true;
				c.ActivateFilter();
			}
			else
			{
				c.ForceFilter = false;
				c.DeactivateFilter();
			}
		}
	}

	public void ToggleArchive()
	{
		SetArchiveMode(!ArchivedToggle.isOn || !ArchivedToggle.gameObject.activeSelf, Mode == 0 || Mode == 1);
	}

	public void SwitchMode()
	{
		int num = ModeToggles.FindIndex((Toggle x) => x.isOn);
		if (num != Mode)
		{
			InitMode(num);
		}
	}

	private void OnDestroy()
	{
		if (Thumbnail.texture != null)
		{
			HardwareDesignRenderer.Release(Thumbnail.texture);
			UnityEngine.Object.Destroy(Thumbnail.texture);
			_lastdisplayed = null;
		}
	}

	public static void DevelopAddons(SoftwareProduct p)
	{
		List<SoftwareAddOn> addons = p.Type.GetValidAddons(p.Category, p.TechLevels, p.Features, SDateTime.Now()).ToList();
		if (addons.Count == 1)
		{
			HUD.Instance.addonDesignWindow.Show(addons[0], p);
		}
		else if (addons.Count > 1)
		{
			WindowManager.Instance.MultiWindow.Show("Addons".Loc(), addons.Select((SoftwareAddOn x) => x.GetPrettyName()), delegate(int x)
			{
				HUD.Instance.addonDesignWindow.Show(addons[x], p);
			}, false);
		}
	}

	public void DevelopAddon()
	{
		SoftwareProduct[] selected = ProductList.GetSelected<SoftwareProduct>();
		if (selected.Length == 1)
		{
			DevelopAddons(selected[0]);
		}
	}

	private void UpdateCustomButtons(bool archived, bool software, bool published)
	{
		if (AddonButton != null)
		{
			bool flag = AddonButton.Check(NotMe, published, archived, ProductList.Selected.Count, Mode, software);
			if (flag)
			{
				SoftwareProduct[] selected = ProductList.GetSelected<SoftwareProduct>();
				if (selected.Length != 0)
				{
					List<SoftwareAddOn> list = selected[0].Type.GetValidAddons(selected[0].Category, selected[0].TechLevels, selected[0].Features, SDateTime.Now()).ToList();
					if (list.Count == 1)
					{
						AddonButton.Label.text = list[0].GetPrettyName();
					}
					else if (list.Count > 1)
					{
						AddonButton.Label.text = "DevelopAddon".Loc();
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						AddonButton.OnLocalized();
					}
				}
				else
				{
					flag = false;
				}
			}
			AddonButton.gameObject.SetActive(flag);
		}
		ExclusivityButton.gameObject.SetActive(GameSettings.Instance.MyCompany.Distribution != null && ExclusivityButton.Check(NotMe, published, archived, ProductList.Selected.Count, Mode, software));
	}

	public void RefreshPlayerItems()
	{
		switch (Mode)
		{
		case 0:
			ApplyFilters();
			break;
		case 1:
			foreach (GUIColumn gUIColumn in ProductList.GUIColumns)
			{
				gUIColumn.ToggleActive(false, gUIColumn.name.StartsWith("AddOn"));
			}
			ProductList.Items = GameSettings.Instance.MyCompany.AddOns.Cast<object>().ToList();
			break;
		case 2:
			foreach (GUIColumn gUIColumn2 in ProductList.GUIColumns)
			{
				gUIColumn2.ToggleActive(false, gUIColumn2.name.StartsWith("Framework"));
			}
			ProductList.Items = GameSettings.Instance.MyCompany.Frameworks.Cast<object>().ToList();
			break;
		}
	}

	public void InitMode(int mode)
	{
		_sort[Mode] = ((ProductList.LastSort != null) ? new ValueTuple<GUIColumn, bool>(ProductList.LastSort, ProductList.LastSort.SortAsc) : new ValueTuple<GUIColumn, bool>(null, false));
		Mode = mode;
		ArchivedToggle.gameObject.SetActive(_archiveAvailable && (Mode == 0 || Mode == 1));
		ProductList.ClearSelected();
		ProductList.Items.Clear();
		ToggleArchive();
		Content = null;
		switch (mode)
		{
		case 0:
			foreach (GUIColumn gUIColumn in ProductList.GUIColumns)
			{
				gUIColumn.ToggleActive(false, gUIColumn.name.StartsWith("Product"));
			}
			ProductList["ProductSupport"].ToggleActive(false, false);
			ProductList["ProductTechLevel"].ToggleActive(false, false);
			ProductList["ProductCompany"].ToggleActive(false, NotMe);
			ProductList["ProductCost"].ToggleActive(false, false);
			ProductList["ProductLastMonth"].ToggleActive(false, !NotMe);
			ProductList["ProductRefunds"].ToggleActive(false, !NotMe);
			ProductList["ProductCopies"].ToggleActive(false, !NotMe);
			ProductList["ProductStorage"].ToggleActive(false, !NotMe);
			ProductList["ProductPublisher"].ToggleActive(false, !NotMe);
			ProductList["ProductArchived"].ToggleActive(false, false);
			ApplyFilters();
			break;
		case 1:
			foreach (GUIColumn gUIColumn2 in ProductList.GUIColumns)
			{
				gUIColumn2.ToggleActive(false, gUIColumn2.name.StartsWith("AddOn"));
			}
			ProductList["AddOnArchived"].ToggleActive(false, false);
			ApplyFilters();
			break;
		case 2:
			foreach (GUIColumn gUIColumn3 in ProductList.GUIColumns)
			{
				gUIColumn3.ToggleActive(false, gUIColumn3.name.StartsWith("Framework"));
			}
			ApplyFilters();
			break;
		}
		ValueTuple<GUIColumn, bool> value;
		if (_sort.TryGetValue(Mode, out value))
		{
			ProductList.LastSort = value.Item1;
			if (value.Item1 != null)
			{
				value.Item1.Sort(!value.Item2);
			}
		}
		else
		{
			ProductList.LastSort = null;
		}
		DoButtonCheck();
	}

	public void Init()
	{
		if (_init)
		{
			return;
		}
		CanApplyFilters = true;
		ProductList.OnSelectChange = delegate
		{
			DoButtonCheck();
			IDisplayable[] selected = ProductList.GetSelected<IDisplayable>();
			if (selected.Length == 1)
			{
				if (_lastdisplayed != selected[0])
				{
					_lastdisplayed = selected[0];
					ThumbnailObject.SetActive(true);
					ButtonPanel.BottomLeft = false;
					if (Thumbnail.texture != null)
					{
						HardwareDesignRenderer.Instance.RenderProduct(selected[0], (RenderTexture)Thumbnail.texture, false);
					}
					else
					{
						Thumbnail.texture = HardwareDesignRenderer.Instance.RenderProduct(selected[0], 64, false);
					}
				}
			}
			else
			{
				ThumbnailObject.SetActive(false);
				ButtonPanel.BottomLeft = true;
				if (Thumbnail.texture != null)
				{
					HardwareDesignRenderer.Release(Thumbnail.texture);
					UnityEngine.Object.Destroy(Thumbnail.texture);
					Thumbnail.texture = null;
					_lastdisplayed = null;
				}
			}
		};
		ProductList["ProductArchived"].ToggleActive(false, false);
		_init = true;
	}

	public void ShowProductDetails(SoftwareProduct product)
	{
		ProductDetailWindow productDetailWindow = WindowManager.FindWindowType<ProductDetailWindow>().FirstOrDefault((ProductDetailWindow x) => !x.IsAddon && x.product == product);
		if (productDetailWindow != null)
		{
			productDetailWindow.Window.Focus();
			return;
		}
		GameObject obj = UnityEngine.Object.Instantiate(ProductDetailWindow);
		obj.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
		ProductDetailWindow component = obj.GetComponent<ProductDetailWindow>();
		component.Window.Modal = Window.Modal || WindowManager.HasModal;
		if (Window.Modal)
		{
			component.Window.SetParentWindow(Window);
		}
		component.Init(product);
	}

	public void ShowAddonDetails(AddOnProduct product)
	{
		ProductDetailWindow productDetailWindow = WindowManager.FindWindowType<ProductDetailWindow>().FirstOrDefault((ProductDetailWindow x) => x.IsAddon && x.Addon == product);
		if (productDetailWindow != null)
		{
			productDetailWindow.Window.Focus();
			return;
		}
		GameObject obj = UnityEngine.Object.Instantiate(ProductDetailWindow);
		obj.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
		ProductDetailWindow component = obj.GetComponent<ProductDetailWindow>();
		component.Window.Modal = Window.Modal || WindowManager.HasModal;
		if (Window.Modal)
		{
			component.Window.SetParentWindow(Window);
		}
		component.Init(product);
	}

	public void CheckSupport(Dictionary<string, TechLevel> tech, string[] specs, FeatureBase[] features = null)
	{
		CurrentTechs = tech;
		TechSpecs = specs;
		FeatureCheck = features;
		ProductList["ProductSupport"].ToggleActive(false, true);
		ProductList["ProductTechLevel"].ToggleActive(false, specs != null);
	}

	public void UpdateTitle()
	{
		Window.NonLocTitle = _title + " (" + ProductList.ActualItems.Count + ")";
	}

	public ValueTuple<bool, bool, bool> AnySelectedArchivedOrSoftwareOrPublished()
	{
		if (Mode == 0)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			SoftwareProduct[] selected = ProductList.GetSelected<SoftwareProduct>();
			foreach (SoftwareProduct softwareProduct in selected)
			{
				flag |= softwareProduct.Archived;
				flag2 |= !softwareProduct.Category.Hardware;
				flag3 |= softwareProduct.Publishing != null;
				if (flag && flag2 && flag3)
				{
					break;
				}
			}
			return new ValueTuple<bool, bool, bool>(flag, flag2, flag3);
		}
		if (Mode == 1)
		{
			bool flag4 = false;
			bool flag5 = false;
			AddOnProduct[] selected2 = ProductList.GetSelected<AddOnProduct>();
			foreach (AddOnProduct addOnProduct in selected2)
			{
				flag4 |= addOnProduct.Parent.Archived;
				flag5 |= !addOnProduct.Type.Hardware;
				if (flag4 && flag5)
				{
					break;
				}
			}
			return new ValueTuple<bool, bool, bool>(flag4, flag5, false);
		}
		return new ValueTuple<bool, bool, bool>(false, false, false);
	}

	private void DoButtonCheck()
	{
		ValueTuple<bool, bool, bool> valueTuple = AnySelectedArchivedOrSoftwareOrPublished();
		bool item = valueTuple.Item1;
		bool item2 = valueTuple.Item2;
		bool item3 = valueTuple.Item3;
		for (int i = 0; i < Buttons.Length; i++)
		{
			Buttons[i].gameObject.SetActive(Buttons[i].Check(NotMe, item3, item, ProductList.Selected.Count, Mode, item2));
		}
		UpdateCustomButtons(item, item2, item3);
		SortButtons();
	}

	public void ShowPlayer()
	{
		NotMe = false;
		WithMock = false;
		CategoryDisabled = false;
		Content = null;
		PortFilter = null;
		LimitTech = false;
		ProductList.MultiSelect = true;
		ProductList.Selected.Clear();
		ProductList.ResetScroll();
		_companyFilter = GameSettings.Instance.MyCompany.ID;
		ProductList["ProductCost"].ToggleActive(false, false);
		_archiveAvailable = true;
		InitMode(Mode);
		DoButtonCheck();
		_title = "PlayerReleases".Loc();
		UpdateTitle();
		OKButton.gameObject.SetActive(false);
		CancelButton.gameObject.SetActive(false);
		Window.Modal = false;
		Window.Show(true);
	}

	public void Show(bool NotMe, string title, Action<SoftwareProduct[]> close, bool multi = false, bool OS = false, bool license = false, bool forceModal = false)
	{
		this.NotMe = NotMe;
		WithMock = false;
		CategoryDisabled = false;
		Content = null;
		PortFilter = null;
		LimitTech = false;
		_archiveAvailable = Content == null && close == null;
		ArchivedToggle.gameObject.SetActive(_archiveAvailable);
		ToggleArchive();
		ProductList.MultiSelect = multi;
		ProductList.Selected.Clear();
		ProductList.ResetScroll();
		ResetFilters();
		OnCloseAction = close;
		ProductList["ProductSupport"].ToggleActive(false, false);
		ProductList["ProductTechLevel"].ToggleActive(false, false);
		ProductList["ProductCompany"].ToggleActive(false, NotMe);
		ProductList["ProductCost"].ToggleActive(false, license);
		ProductList["ProductLastMonth"].ToggleActive(false, !NotMe);
		ProductList["ProductRefunds"].ToggleActive(false, !NotMe);
		ProductList["ProductCopies"].ToggleActive(false, !NotMe);
		ProductList["ProductStorage"].ToggleActive(false, !NotMe);
		ProductList["ProductPublisher"].ToggleActive(false, !NotMe);
		foreach (GUIColumn gUIColumn in ProductList.GUIColumns)
		{
			if (!gUIColumn.name.StartsWith("Product"))
			{
				gUIColumn.ToggleActive(false, false);
			}
		}
		DoButtonCheck();
		_title = title;
		UpdateTitle();
		if (OnCloseAction != null)
		{
			OKButton.gameObject.SetActive(true);
			CancelButton.gameObject.SetActive(true);
			Window.Modal = true;
		}
		else
		{
			OKButton.gameObject.SetActive(false);
			CancelButton.gameObject.SetActive(false);
			Window.Modal = false;
		}
		Window.Modal |= forceModal;
		Window.Show(true);
	}

	public void Show(bool NotMe, string title, bool multi = false, bool forceModal = false)
	{
		ProductList.Selected.Clear();
		ProductList.ResetScroll();
		Show(NotMe, title, null, multi, false, false, forceModal);
	}

	public void SetCompany(uint company)
	{
		_companyFilter = company;
		ApplyFilters();
	}

	public void SetContent(IEnumerable<SoftwareProduct> items)
	{
		Content = items.ToList();
		_archiveAvailable = false;
		ArchivedToggle.gameObject.SetActive(_archiveAvailable);
		ToggleArchive();
		ArchivedToggle.gameObject.SetActive(false);
		ApplyFilters();
	}

	public void SetType(string type)
	{
		SWTypeFilter = type;
		ApplyFilters();
	}

	public void SetCategory(HashSet<string> category)
	{
		SWCategoryFilter = category;
		ApplyFilters();
	}

	public void SetFilters(bool company, bool type, bool category = true)
	{
		if (!type)
		{
			GUIColumn gUIColumn = ProductList["ProductNeedType"];
			if (gUIColumn.FilterActive)
			{
				gUIColumn.ToggleFilter();
			}
		}
		if (!category || !type)
		{
			GUIColumn gUIColumn2 = ProductList["ProductType"];
			if (gUIColumn2.FilterActive)
			{
				gUIColumn2.ToggleFilter();
			}
		}
		CategoryDisabled = !category;
	}

	public void ApplyFilters()
	{
		if (!CanApplyFilters)
		{
			return;
		}
		switch (Mode)
		{
		case 0:
		{
			List<SoftwareProduct> l = Content ?? (WithMock ? GameSettings.Instance.simulation.GetProductsWithMock(true).ToList() : GameSettings.Instance.simulation.GetAllProducts(true).ToList());
			bool ignoreType3 = SWTypeFilter == null;
			bool ignoreCat3 = SWCategoryFilter == null;
			ProductList.Items = l.Where(delegate(SoftwareProduct x)
			{
				if (_companyFilter != 0 && x.DevCompany.ID != _companyFilter)
				{
					return false;
				}
				if (!ignoreType3 && !x.Type.Name.Equals(SWTypeFilter))
				{
					return false;
				}
				if (!ignoreCat3 && !SWCategoryFilter.Contains(x.Category.Name))
				{
					return false;
				}
				if (FeatureCheck != null && !SoftwareType.OSDependenciesMet(x, FeatureCheck))
				{
					return false;
				}
				if (PortFilter != null)
				{
					if (PortFilter.HasOS(x))
					{
						return false;
					}
					if (!SoftwareType.OSDependenciesMet(x, PortFilter.Features))
					{
						return false;
					}
					SoftwarePort softwarePort = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwarePort>().FirstOrDefault((SoftwarePort z) => z.Product == PortFilter);
					if (softwarePort != null && softwarePort.OSs.Any((SoftwarePort.PortProgress z) => z.Product == x || z.Product.MockSucceeded == x))
					{
						return false;
					}
				}
				if (LimitTech && CurrentTechs != null && TechSpecs != null)
				{
					for (int num = 0; num < TechSpecs.Length; num++)
					{
						string key = TechSpecs[num];
						TechLevel orNull = x.TechLevels.GetOrNull(key);
						TechLevel value;
						if (orNull != null && CurrentTechs.TryGetValue(key, out value) && orNull.Year < value.Year)
						{
							return false;
						}
					}
				}
				return true;
			}).Cast<object>().ToList();
			break;
		}
		case 1:
		{
			List<AddOnProduct> addOnProducts = MarketSimulation.Active.AddOnProducts;
			bool ignoreType2 = SWTypeFilter == null;
			bool ignoreCat2 = SWCategoryFilter == null;
			ProductList.Items = addOnProducts.Where(delegate(AddOnProduct x)
			{
				if (_companyFilter != 0 && x.Owner.ID != _companyFilter)
				{
					return false;
				}
				if (!ignoreType2 && !x.Parent.Type.Name.Equals(SWTypeFilter))
				{
					return false;
				}
				if (!ignoreCat2 && !SWCategoryFilter.Contains(x.Parent.Category.Name))
				{
					return false;
				}
				if (LimitTech && CurrentTechs != null && TechSpecs != null)
				{
					for (int i = 0; i < TechSpecs.Length; i++)
					{
						string key = TechSpecs[i];
						TechLevel orNull = x.Parent.TechLevels.GetOrNull(key);
						TechLevel value;
						if (orNull != null && CurrentTechs.TryGetValue(key, out value) && orNull.Year < value.Year)
						{
							return false;
						}
					}
				}
				return true;
			}).Cast<object>().ToList();
			break;
		}
		case 2:
		{
			List<SoftwareFramework> frameworks = GameSettings.Instance.simulation.Frameworks;
			bool ignoreType = SWTypeFilter == null;
			bool ignoreCat = SWCategoryFilter == null;
			ProductList.Items = frameworks.Where(delegate(SoftwareFramework x)
			{
				if (_companyFilter != 0 && (x.Owner == null || x.Owner.ID != _companyFilter))
				{
					return false;
				}
				if (!ignoreType && !x.Type.Name.Equals(SWTypeFilter))
				{
					return false;
				}
				if (!ignoreCat && !SWCategoryFilter.Contains(x.Category.Name))
				{
					return false;
				}
				if (LimitTech && CurrentTechs != null && TechSpecs != null)
				{
					for (int i = 0; i < TechSpecs.Length; i++)
					{
						string key = TechSpecs[i];
						TechLevel orNull = x.TechLevels.GetOrNull(key);
						TechLevel value;
						if (orNull != null && CurrentTechs.TryGetValue(key, out value) && orNull.Year < value.Year)
						{
							return false;
						}
					}
				}
				return true;
			}).Cast<object>().ToList();
			break;
		}
		}
	}

	public void ResetFilters()
	{
		_companyFilter = 0u;
		SWCategoryFilter = null;
		SWTypeFilter = null;
		PortFilter = null;
		FeatureCheck = null;
		LimitTech = false;
	}

	public void PressOK()
	{
		OnCloseAction(ProductList.GetSelected<SoftwareProduct>());
		Window.Close();
	}

	public static void StartMarketing(params IMarketable[] sw)
	{
		if (sw.Any((IMarketable x) => x.IsMarketable()))
		{
			HUD.Instance.marketingWindow.Show(sw.Where((IMarketable x) => x.IsMarketable()).ToArray());
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("InHouseMarketing".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	public void MarketClick()
	{
		IMarketable[] selected = ProductList.GetSelected<IMarketable>();
		if (selected.Length != 0)
		{
			StartMarketing(selected);
		}
	}

	public void DetailClick()
	{
		switch (Mode)
		{
		case 0:
		{
			SoftwareProduct softwareProduct = ProductList.GetSelected<SoftwareProduct>().FirstOrDefault();
			if (softwareProduct != null)
			{
				if (softwareProduct.IsMock)
				{
					WindowManager.Instance.ShowMessageBox("ProductInDevError".Loc(), true, DialogWindow.DialogType.Error);
				}
				else
				{
					ShowProductDetails(softwareProduct);
				}
			}
			break;
		}
		case 1:
		{
			AddOnProduct addOnProduct = ProductList.GetSelected<AddOnProduct>().FirstOrDefault();
			if (addOnProduct != null)
			{
				ShowAddonDetails(addOnProduct);
			}
			break;
		}
		case 2:
		{
			SoftwareFramework softwareFramework = ProductList.GetSelected<SoftwareFramework>().FirstOrDefault();
			if (softwareFramework != null)
			{
				HUD.Instance.docWindow.FrameworkDialog.Show(softwareFramework);
			}
			break;
		}
		}
	}

	private static List<Company> GetElligebleIPTakers(IPDeal deal)
	{
		List<Company> list = new List<Company>();
		string sWType = deal.GetSWType();
		string sWCategory = deal.GetSWCategory();
		foreach (uint subsidiary in GameSettings.Instance.MyCompany.Subsidiaries)
		{
			SimulatedCompany simulatedCompany = GameSettings.Instance.simulation.GetCompany(subsidiary) as SimulatedCompany;
			if (simulatedCompany != null && simulatedCompany.CompatibleSoftware(sWType, sWCategory))
			{
				list.Add(simulatedCompany);
			}
		}
		return list;
	}

	private static string GetLeadAdd(string s, HashSet<Employee> leads, double designerCut, double total)
	{
		if (leads.Count > 0)
		{
			return s + "\n" + "IPOwnerSellWarning".LocColor(leads.ToList(), (designerCut >= total) ? 1.0.ToPercent() : designerCut.Currency());
		}
		return s;
	}

	private static ValueTuple<NetworkMessaging.SyncType, uint> GetNetworkDealTypeAndID(IPDeal deal)
	{
		if (deal.Framework != null)
		{
			return new ValueTuple<NetworkMessaging.SyncType, uint>(NetworkMessaging.SyncType.FrameworkIP, deal.Framework.ID);
		}
		if (deal._products.Length != 0)
		{
			return new ValueTuple<NetworkMessaging.SyncType, uint>(NetworkMessaging.SyncType.ProductIP, deal._products[0].ID);
		}
		return new ValueTuple<NetworkMessaging.SyncType, uint>(NetworkMessaging.SyncType.AddonIP, deal.AddOns[0].ID);
	}

	private static void AcceptDeals(IList<IPDeal> deals, Company target)
	{
		for (int i = 0; i < deals.Count; i++)
		{
			IPDeal deal = deals[i];
			ValueTuple<NetworkMessaging.SyncType, uint> networkDealTypeAndID = GetNetworkDealTypeAndID(deal);
			NetworkMessaging.SyncType item = networkDealTypeAndID.Item1;
			uint item2 = networkDealTypeAndID.Item2;
			NetworkMessaging.SyncedNetworkMessage(item, item2, delegate(bool x)
			{
				if (x)
				{
					deal.Accept(target);
				}
			}, null, null);
		}
	}

	private static void AcceptDeals(Dictionary<IPDeal, Company> deals)
	{
		foreach (KeyValuePair<IPDeal, Company> deal in deals)
		{
			ValueTuple<NetworkMessaging.SyncType, uint> networkDealTypeAndID = GetNetworkDealTypeAndID(deal.Key);
			NetworkMessaging.SyncType item = networkDealTypeAndID.Item1;
			uint item2 = networkDealTypeAndID.Item2;
			NetworkMessaging.SyncedNetworkMessage(item, item2, delegate(bool x)
			{
				if (x)
				{
					deal.Key.Accept(deal.Value);
				}
			}, null, null);
		}
	}

	public void TradeClick()
	{
		List<SoftwareProduct> products = (from x in ProductList.GetSelected<SoftwareProduct>()
			where !x.IsMock && x.DevCompany != MarketSimulation.Active.PublicDomain
			select x).ToList();
		List<AddOnProduct> addons = (from x in ProductList.GetSelected<AddOnProduct>()
			where (x.Competitive && !x.Forced) || !x.Owner.IsLocalPlayer
			select x).ToList();
		List<SoftwareFramework> frameworks = ProductList.GetSelected<SoftwareFramework>().ToList();
		TradeIP(products, addons, frameworks);
	}

	public static void TradeIP(List<SoftwareProduct> products, List<AddOnProduct> addons, List<SoftwareFramework> frameworks, Action onComplete = null)
	{
		if (products.Any((SoftwareProduct x) => x.DevCompany.Player && !x.DevCompany.LocalPlayer))
		{
			SoftwareProduct p = (from x in products
				where x.DevCompany.Player && !x.DevCompany.LocalPlayer
				select x.GetFirstRelease()).First();
			NetworkPlayer pl = NetworkManager.GetPlayer(p.DevCompany.NetworkPlayerID);
			if (pl != null)
			{
				NetworkManager.Instance.TradeController.CreateOffer(pl, IPDeal.GetWorth(p), (uint id, float offer) => new IPTrade(id, NetworkManager.Self, pl, p, offer), p);
			}
		}
		else
		{
			if (products.Count <= 0 && addons.Count <= 0 && frameworks.Count <= 0)
			{
				return;
			}
			if (products.All((SoftwareProduct x) => x.DevCompany.IsLocalPlayer) && addons.All((AddOnProduct x) => x.Owner.IsLocalPlayer) && frameworks.All((SoftwareFramework x) => x.Owner.IsLocalPlayer))
			{
				Dictionary<IPDeal, Company> doneDeals = new Dictionary<IPDeal, Company>();
				List<IPDeal> allDeals = new List<IPDeal>();
				Dictionary<Company, double> dictionary = new Dictionary<Company, double>();
				HashSet<SoftwareProduct> hashSet = new HashSet<SoftwareProduct>();
				HashSet<Employee> hashSet2 = new HashSet<Employee>();
				double num = 0.0;
				double num2 = 0.0;
				List<Company> subs = null;
				foreach (SoftwareProduct product in products)
				{
					if (hashSet.Contains(product))
					{
						continue;
					}
					IPDeal iPDeal = new IPDeal(product);
					allDeals.Add(iPDeal);
					Company company = GameSettings.Instance.simulation.FindBuyer(iPDeal, dictionary);
					if (subs == null)
					{
						subs = GetElligebleIPTakers(iPDeal);
					}
					else
					{
						for (int num3 = 0; num3 < subs.Count; num3++)
						{
							if (!((SimulatedCompany)subs[num3]).CompatibleSoftware(product.Type.Name, product.Category.Name))
							{
								subs.RemoveAt(num3);
								num3--;
							}
						}
					}
					if (company != null)
					{
						doneDeals[iPDeal] = company;
						dictionary.AddUp(company, iPDeal.Worth());
					}
					Employee iPOwner = iPDeal.GetIPOwner();
					if (iPOwner != null)
					{
						hashSet2.Add(iPOwner);
						num += (double)iPDeal.Worth();
					}
					num2 += (double)iPDeal.Worth();
					hashSet.AddRange(iPDeal._products);
				}
				foreach (AddOnProduct addon in addons)
				{
					IPDeal iPDeal2 = new IPDeal(addon);
					allDeals.Add(iPDeal2);
					Company company2 = GameSettings.Instance.simulation.FindBuyer(iPDeal2, dictionary);
					if (subs == null)
					{
						subs = GetElligebleIPTakers(iPDeal2);
					}
					else
					{
						for (int num4 = 0; num4 < subs.Count; num4++)
						{
							if (!((SimulatedCompany)subs[num4]).CompatibleSoftware(addon.SWType.Name, addon.SWCat.Name))
							{
								subs.RemoveAt(num4);
								num4--;
							}
						}
					}
					if (company2 != null)
					{
						doneDeals[iPDeal2] = company2;
						dictionary.AddUp(company2, iPDeal2.Worth());
					}
					hashSet.AddRange(iPDeal2._products);
				}
				foreach (SoftwareFramework framework in frameworks)
				{
					IPDeal iPDeal3 = new IPDeal(framework);
					allDeals.Add(iPDeal3);
					Company company3 = GameSettings.Instance.simulation.FindBuyer(iPDeal3, dictionary);
					if (subs == null)
					{
						subs = GetElligebleIPTakers(iPDeal3);
					}
					else
					{
						for (int num5 = 0; num5 < subs.Count; num5++)
						{
							if (!((SimulatedCompany)subs[num5]).CompatibleSoftware(framework.Type.Name, framework.Category.Name))
							{
								subs.RemoveAt(num5);
								num5--;
							}
						}
					}
					if (company3 != null)
					{
						doneDeals[iPDeal3] = company3;
						dictionary.AddUp(company3, iPDeal3.Worth());
					}
					hashSet.AddRange(iPDeal3._products);
				}
				if (subs != null && subs.Count == 0)
				{
					subs = null;
				}
				if (doneDeals.Count > 0)
				{
					if (subs != null)
					{
						WindowManager.Instance.ShowMessageBox(GetLeadAdd("MultiIPDealActionSellOrSub".LocColor(doneDeals.Count, doneDeals.Values.Distinct().ToList(), dictionary.Values.Sum().Currency()), hashSet2, num, num2), true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Sell", delegate
						{
							AcceptDeals(doneDeals);
							Action action3 = onComplete;
							if (action3 != null)
							{
								action3();
							}
						}), new KeyValuePair<string, Action>("Transfer", delegate
						{
							if (subs.Count == 1)
							{
								AcceptDeals(allDeals, subs[0]);
								Action action3 = onComplete;
								if (action3 != null)
								{
									action3();
								}
							}
							else
							{
								WindowManager.Instance.MultiWindow.Show("Transfer IP", subs.Select((Company x) => x.Name), delegate(int i)
								{
									AcceptDeals(allDeals, subs[i]);
									Action action4 = onComplete;
									if (action4 != null)
									{
										action4();
									}
								}, false);
							}
						}), new KeyValuePair<string, Action>("Cancel", delegate
						{
						}));
						return;
					}
					WindowManager.Instance.ShowMessageBox(GetLeadAdd("MultiIPDealActionSell".Loc(doneDeals.Count, doneDeals.Values.Distinct().ToList(), dictionary.Values.Sum().Currency()), hashSet2, num, num2), true, DialogWindow.DialogType.Question, delegate
					{
						AcceptDeals(doneDeals);
						Action action3 = onComplete;
						if (action3 != null)
						{
							action3();
						}
					});
				}
				else if (subs != null)
				{
					WindowManager.Instance.ShowMessageBox("IPDealActionSub".Loc(), true, DialogWindow.DialogType.Question, delegate
					{
						if (subs.Count == 1)
						{
							AcceptDeals(allDeals, subs[0]);
							Action action3 = onComplete;
							if (action3 != null)
							{
								action3();
							}
						}
						else
						{
							WindowManager.Instance.MultiWindow.Show("Transfer IP", subs.Select((Company x) => x.Name), delegate(int i)
							{
								AcceptDeals(allDeals, subs[i]);
								Action action4 = onComplete;
								if (action4 != null)
								{
									action4();
								}
							}, false);
						}
					});
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("IPDealActionFail".Loc(), false, DialogWindow.DialogType.Information);
				}
				return;
			}
			SoftwareProduct softwareProduct = products.FirstOrDefault((SoftwareProduct x) => !x.DevCompany.IsLocalPlayer);
			if (softwareProduct == null)
			{
				AddOnProduct addOnProduct = addons.FirstOrDefault((AddOnProduct x) => !x.Owner.IsLocalPlayer);
				if (addOnProduct != null)
				{
					if (!addOnProduct.Forced && addOnProduct.Competitive)
					{
						IPDeal deal = new IPDeal(addOnProduct);
						if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - deal.Worth()))
						{
							if (deal.Worth() == 0f)
							{
								AcceptDeals(new IPDeal[1] { deal }, GameSettings.Instance.MyCompany);
								Action action = onComplete;
								if (action != null)
								{
									action();
								}
							}
							else
							{
								WindowManager.Instance.ShowMessageBox("IPDealActionBuy".Loc(deal.Worth().Currency()), true, DialogWindow.DialogType.Question, delegate
								{
									AcceptDeals(new IPDeal[1] { deal }, GameSettings.Instance.MyCompany);
									Action action3 = onComplete;
									if (action3 != null)
									{
										action3();
									}
								});
							}
						}
						else
						{
							WindowManager.Instance.ShowMessageBox("IPDealActionBuyFail".LocColor(softwareProduct.DevCompany, deal.Worth().Currency()), false, DialogWindow.DialogType.Information);
						}
					}
					else
					{
						softwareProduct = addOnProduct.Parent;
					}
				}
			}
			if (softwareProduct == null)
			{
				return;
			}
			IPDeal deal2 = new IPDeal(softwareProduct);
			bool flag = false;
			if (softwareProduct.DevCompany.IsPlayerOwned())
			{
				flag = true;
			}
			else
			{
				HashSet<SoftwareProduct> hashSet3 = deal2._products.ToHashSet();
				for (int num6 = 0; num6 < softwareProduct.DevCompany.Products.Count; num6++)
				{
					SoftwareProduct softwareProduct2 = softwareProduct.DevCompany.Products[num6];
					if (!hashSet3.Contains(softwareProduct2) && !softwareProduct2.Traded)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				WindowManager.Instance.ShowMessageBox("IPAIBadDeal".LocColor(softwareProduct.DevCompany), false, DialogWindow.DialogType.Information);
			}
			else if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - deal2.Worth()))
			{
				if (deal2.Worth() == 0f)
				{
					AcceptDeals(new IPDeal[1] { deal2 }, GameSettings.Instance.MyCompany);
					Action action2 = onComplete;
					if (action2 != null)
					{
						action2();
					}
					return;
				}
				WindowManager.Instance.ShowMessageBox("IPDealActionBuy".Loc(deal2.Worth().Currency()), true, DialogWindow.DialogType.Question, delegate
				{
					AcceptDeals(new IPDeal[1] { deal2 }, GameSettings.Instance.MyCompany);
					Action action3 = onComplete;
					if (action3 != null)
					{
						action3();
					}
				});
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("IPDealActionBuyFail".LocColor(softwareProduct.DevCompany, deal2.Worth().Currency()), false, DialogWindow.DialogType.Information);
			}
		}
	}

	public void PortClick()
	{
		SoftwareProduct softwareProduct = ProductList.GetSelected<SoftwareProduct>().FirstOrDefault();
		if (softwareProduct != null)
		{
			StartPort(softwareProduct);
		}
	}

	public static void StartPort(SoftwareProduct p)
	{
		if (p.Type.OSSpecific)
		{
			SoftwarePort softwarePort = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwarePort>().FirstOrDefault((SoftwarePort z) => z.Product == p);
			if (softwarePort != null)
			{
				softwarePort.AddOSs();
				return;
			}
			HUD.Instance.TeamSelectWindow.Show(GameSettings.Instance.GetDefaultTeams("Porting"), null, delegate(string[] ts, SimulatedCompany c)
			{
				ShowPortWindow(p, delegate(SoftwareProduct[] xs)
				{
					if (xs.Length != 0)
					{
						SoftwarePort softwarePort2 = new SoftwarePort(p, xs);
						GameSettings.Instance.MyCompany.AddWorkItem(softwarePort2);
						if (c != null)
						{
							softwarePort2.CompanyWorker = c;
						}
						else
						{
							softwarePort2.AddDevTeams(ts);
						}
					}
				});
			}, "Porting", "Porting", "SoftwarePort");
		}
		else if (!p.Type.OSSpecific)
		{
			WindowManager.Instance.ShowMessageBox("PortNonOSError".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	public static void ShowPortWindow(SoftwareProduct p, Action<SoftwareProduct[]> onAccept)
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("Port");
		productWindow.Show(true, "Port".Loc(), onAccept, true, true);
		productWindow.WithMock = true;
		productWindow.SetFilters(true, false, p.Type.HasOSLimits());
		productWindow.PortFilter = p;
		productWindow.CheckSupport(p.TechLevels, null, p.Features);
		productWindow.SetType("Operating System");
		if (p.Type.HasOSLimits())
		{
			productWindow.SetCategory(p.Type.GetOSLimits().ToHashSet());
		}
		if (PublisherDeal.HasDeal(p, "OSExclusivity"))
		{
			productWindow.SetCompany(p.Publishing.Publisher.ID);
		}
	}

	public void OrderCopies()
	{
		IStockable[] selected = ProductList.GetSelected<IStockable>();
		if (selected.Length != 0)
		{
			HUD.Instance.copyOrderWindow.Show(selected);
		}
	}

	private void SortButtons()
	{
		int num = 0;
		foreach (ProductWindowButton item in from x in ButtonPanel.GetComponentsInChildren<ProductWindowButton>(true)
			orderby x.Index
			select x)
		{
			item.transform.SetSiblingIndex(num);
			num++;
		}
	}

	public static void ChangeSoftwarePrice(SoftwareProduct p, Action onComplete = null)
	{
		if (p.Price < 1f)
		{
			WindowManager.Instance.ShowMessageBox("ChangePriceFreeError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		double x = Math.Min(p.LowestPrice, (double)MarketSimulation.Active.GetIdealMarketPrice(p.Category, p.SubscriptionBased) * p.PerceivedValue(SDateTime.Now()));
		WindowManager.SpawnInputDialog("Changeprice".Loc() + ". " + "SuggestedPrefix".Loc(x.Currency()), p.Name, p.Price.Currency(false), delegate(string pr)
		{
			float newPrice = pr.ConvertToFloatDef(0f).FromCurrency();
			if (!p.ChangePrice(newPrice))
			{
				WindowManager.Instance.ShowMessageBox("InvalidAmount".Loc(), false, DialogWindow.DialogType.Error);
			}
			Action action = onComplete;
			if (action != null)
			{
				action();
			}
		});
	}

	public static void ChangeAddonPrice(AddOnProduct p, Action onComplete = null)
	{
		if (p.Price < 1f)
		{
			WindowManager.Instance.ShowMessageBox("ChangePriceFreeError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		WindowManager.SpawnInputDialog("Change price", p.Name, p.Price.Currency(false), delegate(string pr)
		{
			float newPrice = pr.ConvertToFloatDef(0f).FromCurrency();
			if (!p.ChangePrice(newPrice))
			{
				WindowManager.Instance.ShowMessageBox("InvalidAmount".Loc(), false, DialogWindow.DialogType.Error);
			}
			Action action = onComplete;
			if (action != null)
			{
				action();
			}
		});
	}

	public void ChangePrice()
	{
		if (Mode == 0)
		{
			SoftwareProduct[] selected = ProductList.GetSelected<SoftwareProduct>();
			if (selected.Length != 0)
			{
				ChangeSoftwarePrice(selected[0], delegate
				{
					ProductList.UpdateElements();
				});
			}
			return;
		}
		AddOnProduct[] selected2 = ProductList.GetSelected<AddOnProduct>();
		if (selected2.Length != 0)
		{
			ChangeAddonPrice(selected2[0], delegate
			{
				ProductList.UpdateElements();
			});
		}
	}

	public static void CreateSupportJobs(List<SoftwareProduct> ps)
	{
		HUD.Instance.TeamSelectWindow.Show(GameSettings.Instance.GetDefaultTeams("Support"), null, delegate(string[] ts, SimulatedCompany c)
		{
			for (int i = 0; i < ps.Count; i++)
			{
				SoftwareProduct p = ps[i];
				SupportWork supportWork = GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>().FirstOrDefault((SupportWork x) => x.TargetProduct == p);
				SupportWork supportWork2 = null;
				if (supportWork != null)
				{
					foreach (AutoDevWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
					{
						if (item.TakeOverTask(supportWork))
						{
							supportWork2 = supportWork;
							break;
						}
					}
				}
				else
				{
					SupportWork supportWork3 = new SupportWork(p, -1);
					if (!supportWork3.Done)
					{
						GameSettings.Instance.MyCompany.AddWorkItem(supportWork3);
						supportWork2 = supportWork3;
					}
				}
				if (supportWork2 != null)
				{
					if (c != null)
					{
						supportWork2.CompanyWorker = c;
					}
					else
					{
						supportWork2.SetDevTeams(ts);
					}
				}
			}
		}, "Support", "Support", "SupportWork");
	}

	public void StartSupport()
	{
		HashSet<SoftwareProduct> exSupport = (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>()
			where !x.AutoDev
			select x.TargetProduct).ToHashSet();
		List<SoftwareProduct> list = (from x in ProductList.GetSelected<SoftwareProduct>()
			where !exSupport.Contains(x)
			select x).ToList();
		if (list.Count > 0)
		{
			CreateSupportJobs(list);
		}
	}

	public static void CreateSequel(SoftwareProduct p)
	{
		if (p.DesignerOwned && p.LeadDesigner.MyActor == null)
		{
			Utilities.LeadDesignerIP(p, delegate
			{
				HUD.Instance.docWindow.ShowSequel(p);
			});
		}
		else
		{
			HUD.Instance.docWindow.ShowSequel(p);
		}
	}

	public void MakeSequel()
	{
		SoftwareProduct softwareProduct = ProductList.GetSelected<SoftwareProduct>().FirstOrDefault();
		if (softwareProduct != null)
		{
			CreateSequel(softwareProduct);
		}
	}

	public void CreatePrintJob()
	{
		IStockable[] ps = ProductList.GetSelected<IStockable>();
		if (ps.Length == 0)
		{
			return;
		}
		if (ps.Any((IStockable x) => !x.Manufacturing.IsHardware()) && GameSettings.Instance.ProductPrinters.Count == 0)
		{
			WindowManager.Instance.ShowMessageBox("NoPrintersWarning".Loc(MarketSimulation.PhysicalCopyPrice.Currency()), false, DialogWindow.DialogType.Question, delegate
			{
				MakeJobs(ps);
			});
		}
		else
		{
			MakeJobs(ps);
		}
	}

	private void MakeJobs(IStockable[] ps)
	{
		WindowManager.SpawnInputDialog("PlayerPrintPrompt".Loc(), "Startprinting".Loc(), "-1", delegate(string x)
		{
			uint? maximum = null;
			try
			{
				maximum = Convert.ToUInt32(x);
			}
			catch (Exception)
			{
			}
			PrintJob printJob = null;
			List<IStockable> list = ps.Where((IStockable z) => GameSettings.Instance.GetPrintJob(z) == null).ToList();
			bool flag = list.Count((IStockable z) => z.Manufacturing.IsHardware()) > 1;
			for (int num = 0; num < list.Count; num++)
			{
				printJob = new PrintJob(list[num])
				{
					Maximum = maximum
				};
				GameSettings.Instance.AddPrintOrder(printJob, flag);
			}
			if (printJob != null)
			{
				if (!flag && printJob.Hardware)
				{
					GameSettings.Instance.PromptPrintAssignment(printJob);
				}
				HUD.Instance.distributionWindow.Show(printJob);
			}
		});
	}

	public void CreateUpdate()
	{
		SoftwareProduct firstSelected = ProductList.GetFirstSelected<SoftwareProduct>();
		if (firstSelected != null)
		{
			HUD.Instance.updateWindow.Show(firstSelected);
			return;
		}
		SoftwareFramework firstSelected2 = ProductList.GetFirstSelected<SoftwareFramework>();
		if (firstSelected2 != null)
		{
			HUD.Instance.updateWindow.Show(firstSelected2);
		}
	}

	public void ExclusivityAction()
	{
		if (GameSettings.Instance.MyCompany.Distribution == null)
		{
			return;
		}
		List<SoftwareProduct> list = (from x in ProductList.GetSelected<SoftwareProduct>()
			where !x.Category.Hardware && !x.IsMock && x.CanMakeExclusive()
			select x).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		if (list.Any((SoftwareProduct x) => x.DevCompany.Player && !x.DevCompany.LocalPlayer))
		{
			SoftwareProduct p = (from x in list
				where x.DevCompany.Player && !x.DevCompany.LocalPlayer
				select x.GetFirstRelease()).First();
			NetworkPlayer pl = NetworkManager.GetPlayer(p.DevCompany.NetworkPlayerID);
			if (pl == null)
			{
				return;
			}
			HUD.Instance.dateRangeWindow.Show(SDateTime.Now() + 3, delegate(SDateTime x)
			{
				NetworkManager.Instance.TradeController.CreateOffer(pl, (float)ExclusivityDealWindow.GetExpectedPriceForExclusive(p, GameSettings.Instance.MyCompany.Distribution, SDateTime.GetMonthsFlat(SDateTime.Now(), x)), (uint id, float offer) => new ExclusivityTrade(id, NetworkManager.Self, pl, p, offer, x), p);
			});
		}
		else
		{
			HUD.Instance.ExclusivityWindow.Show(list);
		}
	}

	public void FindPublisher()
	{
		if (GameSettings.Instance.Difficulty.Publisher < 0.5f)
		{
			return;
		}
		SoftwareProduct p = ProductList.GetSelected<SoftwareProduct>().FirstOrDefault((SoftwareProduct x) => x.DevCompany.IsLocalPlayer && x.Publishing == null);
		if (p != null)
		{
			float devtime = p.Type.DevTime(p.Features, p.Category, p.DevCompany, p.TechLevels, p.OSCount, p.Framework, false, p.SequelTo);
			float artRatio = SoftwareType.CodeArtRatio(p.Features);
			HUD.Instance.docWindow.PubDealWindow.Show(p.Category, devtime, artRatio, false, false, SDateTime.Now(), delegate(PublisherDeal x)
			{
				x.Affect(p);
				x.SendNetwork();
				DoButtonCheck();
			});
		}
	}
}
