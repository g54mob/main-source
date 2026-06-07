using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProductDetailWindow : MonoBehaviour
{
	public class ActionButton<T>
	{
		public string Label;

		public Action<T> DoAction;

		public Func<T, bool> CustomCheck;

		public bool OwnedBy;

		public bool AllowArchived;

		public ActionButton(string label, Action<T> doAction, bool ownedBy, bool allowArchived = false, Func<T, bool> customCheck = null)
		{
			Label = label;
			DoAction = doAction;
			OwnedBy = ownedBy;
			AllowArchived = allowArchived;
			CustomCheck = customCheck;
		}

		public bool Valid(bool playerOwned, bool archived, T item)
		{
			if ((!OwnedBy || playerOwned) && (AllowArchived || !archived))
			{
				if (CustomCheck != null)
				{
					return CustomCheck(item);
				}
				return true;
			}
			return false;
		}

		public void Execute(bool playerOwned, bool archived, T item)
		{
			if (Valid(playerOwned, archived, item))
			{
				DoAction(item);
			}
		}
	}

	public static List<ProductDetailWindow> OpenProductWindows = new List<ProductDetailWindow>();

	public static SoftwareProduct LastShownProduct;

	public ToggleGroup AddonGroup;

	public Toggle TogglePrefab;

	public RectTransform AddonPanel;

	public GUIWindow Window;

	public Text ToggleMarketText;

	public VarValueSheet LeftSh;

	public VarValueSheet RightSh;

	public VarValueSheet PublisherData;

	public GameObject MarketButton;

	public GameObject BarChartPanel;

	public GameObject SubMarketPanel;

	public GameObject ChartPanel;

	public GameObject FranchiseButton;

	public GameObject AddonButton;

	public GameObject AddonDevButton;

	public GameObject AddonPreview;

	public GameObject ChartSelectorPanel;

	public GameObject PublisherButton;

	public GameObject PublisherPanel;

	public GameObject ReviewButton;

	public GameObject[] DisableForAddonChart;

	public Toggle StockNotificationToggle;

	public Toggle RelativeReviewScore;

	public Text OSLabel;

	public Text AddonLabel;

	public Text PublisherName;

	public GUILegend legend2;

	public GUIListView MainList;

	public GUIBarChart barChart;

	public GUIPieChart ExtraChart;

	private int IncomeData;

	private int lastOption;

	public bool Licensable;

	public GameObject OSSaleWarning;

	public GameObject LicensedFor;

	public GameObject Tools;

	public GameObject CostBreakdown;

	public Toggle ArchiveButton;

	public TriangleSlider MarketSlider;

	public Text[] SubmarketLabels;

	public RawImage Thumbnail;

	public RawImage AddonPreviewImage;

	public RawImage PublisherImage;

	public RawImage CompanyLogo;

	public TimelineDotBar TimeLine;

	public GUICombobox ActionCombo;

	[NonSerialized]
	private Dictionary<SoftwareAddOn, Toggle> _addonToggles;

	[NonSerialized]
	public SoftwareProduct product;

	[NonSerialized]
	public AddOnProduct Addon;

	[NonSerialized]
	public bool IsAddon;

	private static List<ActionButton<SoftwareProduct>> _softwareButtons = new List<ActionButton<SoftwareProduct>>
	{
		new ActionButton<SoftwareProduct>("PlaceInOffice", delegate(SoftwareProduct s)
		{
			CreateDisplay(s);
		}, true, false, (SoftwareProduct x) => x.HardwareDesign != null),
		new ActionButton<SoftwareProduct>("Findowner", delegate(SoftwareProduct s)
		{
			HUD.Instance.companyWindow.FocusCompany(s.DevCompany);
		}, false, true),
		new ActionButton<SoftwareProduct>("LeadDesigner", DesignerDetails, false, true, (SoftwareProduct s) => s.LeadDesigner != null),
		new ActionButton<SoftwareProduct>("Update", delegate(SoftwareProduct s)
		{
			HUD.Instance.updateWindow.Show(s);
		}, true),
		new ActionButton<SoftwareProduct>("Port", delegate(SoftwareProduct s)
		{
			ProductWindow.StartPort(s);
		}, true, false, (SoftwareProduct s) => s.Type.OSSpecific),
		new ActionButton<SoftwareProduct>("Startprinting", delegate(SoftwareProduct s)
		{
			HandleDistribution(s, true);
		}, true),
		new ActionButton<SoftwareProduct>("Ordercopies", delegate(SoftwareProduct s)
		{
			HandleDistribution(s, false);
		}, true),
		new ActionButton<SoftwareProduct>("Market", delegate(SoftwareProduct s)
		{
			ProductWindow.StartMarketing(s);
		}, true, false, (SoftwareProduct s) => !s.InHouse),
		new ActionButton<SoftwareProduct>("Changeprice", delegate(SoftwareProduct s)
		{
			ProductWindow.ChangeSoftwarePrice(s, delegate
			{
				UpdateWindowFor(s);
			});
		}, true, false, (SoftwareProduct s) => s.Price >= 1f),
		new ActionButton<SoftwareProduct>("DevelopAddon", delegate(SoftwareProduct s)
		{
			ProductWindow.DevelopAddons(s);
		}, true, false, (SoftwareProduct s) => s.Type.GetValidAddons(s.Category, s.TechLevels, s.Features, SDateTime.Now()).Any()),
		new ActionButton<SoftwareProduct>("Support", delegate(SoftwareProduct s)
		{
			ProductWindow.CreateSupportJobs(new List<SoftwareProduct> { s });
		}, true),
		new ActionButton<SoftwareProduct>("Makesequel", delegate(SoftwareProduct s)
		{
			ProductWindow.CreateSequel(s);
		}, true),
		new ActionButton<SoftwareProduct>("TradeIP", delegate(SoftwareProduct s)
		{
			ProductWindow.TradeIP(new List<SoftwareProduct> { s }, new List<AddOnProduct>(), new List<SoftwareFramework>(), delegate
			{
				UpdateWindowFor(s);
			});
		}, false),
		new ActionButton<SoftwareProduct>("Competition", delegate(SoftwareProduct s)
		{
			HUD.Instance.compAnalysisWindow.Show(s);
		}, true, true)
	};

	private static List<ActionButton<AddOnProduct>> _addonButtons = new List<ActionButton<AddOnProduct>>
	{
		new ActionButton<AddOnProduct>("PlaceInOffice", delegate(AddOnProduct s)
		{
			CreateDisplay(s);
		}, true, false, (AddOnProduct x) => x.HardwareDesign != null),
		new ActionButton<AddOnProduct>("Findowner", delegate(AddOnProduct a)
		{
			HUD.Instance.companyWindow.FocusCompany(a.Owner);
		}, false, true),
		new ActionButton<AddOnProduct>("Product", delegate(AddOnProduct a)
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(a.Parent);
		}, false, true),
		new ActionButton<AddOnProduct>("Startprinting", delegate(AddOnProduct a)
		{
			HandleDistribution(a, true);
		}, true),
		new ActionButton<AddOnProduct>("Ordercopies", delegate(AddOnProduct a)
		{
			HandleDistribution(a, false);
		}, true),
		new ActionButton<AddOnProduct>("Market", delegate(AddOnProduct a)
		{
			ProductWindow.StartMarketing(a);
		}, true),
		new ActionButton<AddOnProduct>("Changeprice", delegate(AddOnProduct a)
		{
			ProductWindow.ChangeAddonPrice(a);
		}, true, false, (AddOnProduct a) => a.Price >= 1f)
	};

	[NonSerialized]
	private string[] _rightData;

	private bool _previewMode;

	public static void CreateDisplay(IDisplayable product)
	{
		HUD.Instance.BuildMode = true;
		if (HUD.Instance.BuildMode)
		{
			GameObject f = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetFurniture("Hardware Display"));
			f.GetComponent<Furniture>().isTemporary = true;
			f.name = "Hardware Display";
			f.GetComponent<HardwareDesignFurn>().Init(product);
			FurnitureBuilder component = UnityEngine.Object.Instantiate(BuildController.Instance.FurnitureBuilderPrefab).GetComponent<FurnitureBuilder>();
			BuildController.Instance.CurrentFurnitureBuilder = component;
			component.FurnPrefab = f;
			component.IsProto = true;
			component.CopyProto = true;
			component.OnDestroyed = delegate
			{
				UnityEngine.Object.Destroy(f);
			};
		}
	}

	private void OnDestroy()
	{
		OpenProductWindows.Remove(this);
		if (Thumbnail.texture != null)
		{
			HardwareDesignRenderer.Release(Thumbnail.texture);
			UnityEngine.Object.Destroy(Thumbnail.texture);
		}
		if (AddonPreviewImage.texture != null)
		{
			HardwareDesignRenderer.Release(AddonPreviewImage.texture);
			UnityEngine.Object.Destroy(AddonPreviewImage.texture);
		}
	}

	public static void UpdateWindowFor(IStockable product)
	{
		foreach (ProductDetailWindow item in WindowManager.FindWindowTypeEnum<ProductDetailWindow>())
		{
			if (item.IsRelated(product))
			{
				item.UpdateMe();
			}
		}
	}

	private bool IsRelated(IStockable p)
	{
		if (p is AddOnProduct)
		{
			if (IsAddon)
			{
				return p == Addon;
			}
			return false;
		}
		SoftwareProduct p2;
		if ((p2 = p as SoftwareProduct) != null)
		{
			if (!IsAddon)
			{
				return product.IsSameIP(p2);
			}
			return Addon.Parent == p;
		}
		return false;
	}

	public void RefreshThumbnail()
	{
		if (Thumbnail.texture != null)
		{
			HardwareDesignRenderer instance = HardwareDesignRenderer.Instance;
			IDisplayable p;
			if (!IsAddon)
			{
				IDisplayable displayable = product;
				p = displayable;
			}
			else
			{
				IDisplayable displayable = Addon;
				p = displayable;
			}
			instance.RenderProduct(p, (RenderTexture)Thumbnail.texture, true);
			return;
		}
		RawImage thumbnail = Thumbnail;
		HardwareDesignRenderer instance2 = HardwareDesignRenderer.Instance;
		IDisplayable p2;
		if (!IsAddon)
		{
			IDisplayable displayable = product;
			p2 = displayable;
		}
		else
		{
			IDisplayable displayable = Addon;
			p2 = displayable;
		}
		thumbnail.texture = instance2.RenderProduct(p2, 128, true);
	}

	private static void DesignerDetails(SoftwareProduct sw)
	{
		if (sw.LeadDesigner != null)
		{
			if (sw.LeadDesigner.MyActor != null)
			{
				HUD.Instance.DetailWindow.Show(sw.LeadDesigner.MyActor);
			}
			else if (MarketSimulation.Active.FreeLeads.Contains(sw.LeadDesigner))
			{
				HUD.Instance.hireWindow.HireWin.ShowSpecific(new List<Employee> { sw.LeadDesigner });
			}
			else if (sw.LeadDesigner.MyEmployer != null && !sw.LeadDesigner.MyEmployer.Bankrupt)
			{
				HUD.Instance.companyWindow.ShowCompanyDetails(sw.LeadDesigner.MyEmployer);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("LeadDesignerRetired".LocColor(sw.LeadDesigner, sw), true, DialogWindow.DialogType.Information);
			}
		}
	}

	public void Init(AddOnProduct addon)
	{
		MainList.SpecialID = "AddOn";
		TutorialSystem.Instance.StartTutorial("Addons");
		TimeLine.gameObject.SetActive(false);
		IsAddon = true;
		OSLabel.text = addon.Type.GetPrettyName();
		OpenProductWindows.Add(this);
		if (OpenProductWindows.Count > 10)
		{
			UnityEngine.Object.Destroy(OpenProductWindows[0].gameObject);
		}
		Addon = addon;
		Licensable = false;
		Window.NonLocTitle = "ProductDetailTitle".Loc(Addon.Name);
		UpdateLeftInfo();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.AddRange(new string[4]
		{
			"ReviewScore".Loc(),
			"Marketing".Loc(),
			"Instock".Loc(),
			"Units".Loc()
		});
		list2.AddRange(new string[4]);
		if (addon.Forced)
		{
			list.Add("IncludedUnitsWithMain".Loc(addon.Parent.Name));
			list2.Add(null);
		}
		list.AddRange(new string[3]
		{
			"Refunds".Loc(),
			"Gross".Loc(),
			"Expenses".Loc()
		});
		list2.AddRange(new string[3] { null, null, "DevLossTip" });
		_rightData = list.SelectInPlace((string x) => "");
		RightSh.SetData(list.ToArray(), _rightData);
		RightSh.ToolTips = list2.ToArray();
		UpdateMainRightText();
		UpdateActionCombo();
		Tools.SetActive(false);
		LicensedFor.SetActive(Licensable);
		CostBreakdown.SetActive(false);
		StockNotificationToggle.gameObject.SetActive(Addon.Owner.IsLocalPlayer && !Addon.Parent.Archived && !Addon.Traded && !PublisherDeal.HasDeal(Addon, "Printing"));
		if (StockNotificationToggle.gameObject.activeSelf)
		{
			StockNotificationToggle.isOn = Addon.ActualStockNotifications;
		}
		ShowUnitSales();
		FranchiseButton.SetActive(false);
		AddonButton.SetActive(false);
		ArchiveButton.gameObject.SetActive(false);
		InitPublishing();
		if (Addon.PositiveReviewList != null)
		{
			DisableForAddonChart.ForEachEnum(delegate(GameObject x)
			{
				x.SetActive(false);
			});
		}
		else
		{
			ChartSelectorPanel.SetActive(false);
		}
	}

	public void ChangeStockNotification()
	{
		if (IsAddon)
		{
			Addon.StockNotifications = StockNotificationToggle.isOn;
		}
		else
		{
			product.StockNotifications = StockNotificationToggle.isOn;
		}
	}

	public void Init(SoftwareProduct p)
	{
		LastShownProduct = p;
		IsAddon = false;
		OSLabel.text = (p.Type.OSSpecific ? "Operatingsystems".Loc() : "Supportedby".Loc());
		OpenProductWindows.Add(this);
		if (OpenProductWindows.Count > 10)
		{
			UnityEngine.Object.Destroy(OpenProductWindows[0].gameObject);
		}
		product = p;
		Licensable = !product.InHouse && (product.Type.Name.Equals("Operating System") || product.Type.Licensable());
		Window.NonLocTitle = "ProductDetailTitle".Loc(product.Name);
		UpdateLeftInfo();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.AddRange(new string[3]
		{
			"Activeusers".Loc(),
			"ReviewScore".Loc(),
			"Marketing".Loc()
		});
		list2.AddRange(new string[3]);
		if (Licensable)
		{
			list.Add("Licensecost".Loc());
			list2.Add(null);
		}
		list.Add("Instock".Loc());
		list2.Add(null);
		if (product.Type.Name.Equals("Operating System"))
		{
			list.Add("OSSalesBoost".Loc());
			list2.Add("OSSalesBoostTip");
		}
		list.AddRange(new string[4]
		{
			"Units".Loc(),
			"Refunds".Loc(),
			"Consumerreach".Loc(),
			"Gross".Loc()
		});
		list2.AddRange(new string[4] { null, null, "ConsumerReachTip", null });
		if (Licensable)
		{
			list.Add("Licenses".Loc());
			list2.Add("LicensesTip");
			list.Add("LicensesCount".Loc());
			list2.Add("LicensesCountTip");
		}
		list.AddRange(new string[1] { "Expenses".Loc() });
		list2.AddRange(new string[1] { "DevLossTip" });
		_rightData = list.SelectInPlace((string x) => "");
		RightSh.SetData(list.ToArray(), _rightData);
		RightSh.ToolTips = list2.ToArray();
		UpdateMainRightText();
		ShowIncomeData();
		UpdateActionCombo();
		Tools.SetActive(product.ToolCount > 0 || product.Framework != null);
		LicensedFor.SetActive(Licensable);
		CostBreakdown.SetActive(p.DevCompany.IsLocalPlayer && !p.Traded && p.LossBreakdown != null);
		StockNotificationToggle.gameObject.SetActive(p.DevCompany.IsLocalPlayer && !p.Archived && !p.Traded && !PublisherDeal.HasDeal(p, "Printing"));
		if (StockNotificationToggle.gameObject.activeSelf)
		{
			StockNotificationToggle.isOn = p.ActualStockNotifications;
		}
		List<SoftwareAddOn> list3 = product.Type.GetValidAddons(product.Category, product.TechLevels, product.Features, SDateTime.Now()).ToList();
		if (list3.Count > 0)
		{
			if (list3.Count > 1)
			{
				AddonLabel.text = "Addons".Loc();
				_addonToggles = new Dictionary<SoftwareAddOn, Toggle>();
				bool isOn = true;
				foreach (SoftwareAddOn item in list3)
				{
					Toggle toggle = UnityEngine.Object.Instantiate(TogglePrefab);
					toggle.GetComponentInChildren<Text>().text = item.GetPrettyName();
					toggle.isOn = isOn;
					isOn = false;
					toggle.group = AddonGroup;
					_addonToggles[item] = toggle;
					toggle.onValueChanged.AddListener(AddonPanelToggle);
					toggle.transform.SetParent(AddonPanel, false);
				}
			}
			else
			{
				AddonLabel.text = list3[0].GetPrettyName();
			}
		}
		else
		{
			AddonButton.SetActive(false);
		}
		ArchiveButton.gameObject.SetActive(p.DevCompany.IsLocalPlayer);
		ArchiveButton.isOn = product.PlayerArchived;
		InitPublishing();
		UpdateTimeline();
		ReviewButton.SetActive(product.PositiveReviewList != null);
	}

	private void UpdateLeftInfo()
	{
		if (IsAddon)
		{
			LeftSh.SetData(new string[9]
			{
				"Name".Loc(),
				"Product".Loc(),
				"Owner".Loc(),
				"Creator".Loc(),
				"Addon".Loc(),
				"Type".Loc(),
				"Category".Loc(),
				"Price".Loc(),
				"Releasedate".Loc()
			}, new string[9]
			{
				Addon.Name,
				Addon.Parent.Name,
				Addon.Owner.Name,
				Addon.Inventor,
				Addon.Type.GetPrettyName(),
				Addon.SWType.Name.LocSW(),
				Addon.SWCat.Name.LocSWC(Addon.SWType.Name),
				Addon.Price.Currency(),
				Addon.Release.ToCompactString()
			}, false);
			return;
		}
		List<string> list = new List<string>(new string[3]
		{
			"Name".Loc(),
			"Version".Loc(),
			"Owner".Loc()
		});
		List<string> list2 = new List<string>(new string[3]
		{
			product.Name,
			product.Version,
			(product.LeadDesigner != null && product.DesignerOwned) ? product.LeadDesigner.FullName : product.DevCompany.Name
		});
		if (product.DesignerOwned || product.DevCompany.ID != product.InventorID)
		{
			list.Add("Creator");
			list2.Add(product.Inventor);
		}
		if (product.Publishing != null)
		{
			list.Add("Publisher".Loc());
			list2.Add(product.Publishing.Publisher.Name);
		}
		if (product.ExclusiveStore != null)
		{
			list.Add("Exclusivity".Loc());
			list2.Add(product.ExclusiveStore.Software.Name);
		}
		list.AddRange(new string[7]
		{
			"Designer".Loc(),
			"Type".Loc(),
			"Category".Loc(),
			"Price".Loc(),
			"Framework".Loc(),
			"In-house".Loc(),
			"Releasedate".Loc()
		});
		list2.AddRange(new string[7]
		{
			(product.LeadDesigner != null) ? product.LeadDesigner.FullName : "Unknown".Loc(),
			product.Type.Name.LocSW(),
			product.Category.Name.LocSWC(product.Type.Name),
			product.Price.Currency(),
			(product.Framework != null) ? product.Framework.Name : "None".Loc(),
			(product.InHouse ? "Yes" : "No").Loc(),
			product.Release.ToCompactString()
		});
		LeftSh.SetData(list.ToArray(), list2.ToArray(), false);
	}

	private void UpdateTimeline()
	{
		if (IsAddon)
		{
			return;
		}
		int num = 0;
		num = ((IncomeData == 0) ? product.GetCashflow(false).Count : ((IncomeData == 1) ? product.Rep.Count : ((IncomeData != 3) ? product.GetUnitSales(false).Count : ((product.PositiveReviewList != null) ? product.PositiveReviewList.Count : 0))));
		SDateTime end = product.Release + (num + 1);
		List<MarketEvent> list = new List<MarketEvent>();
		list.Add(new MarketEvent(MarketEvent.EventType.ProductRelease, product.Release, product.ID));
		List<MarketEvent> list2 = list;
		foreach (SoftwareProduct item in from x in MarketSimulation.Active.GetAllProducts(true)
			where x != product && x.Type == product.Type && x.Category == product.Category && x.Release >= product.Release && x.Release <= end
			select x)
		{
			list2.Add(new MarketEvent(MarketEvent.EventType.ProductRelease, item.Release, item.ID));
		}
		list2.AddRange(MarketSimulation.Active.GetRelevantTechEvents(product.TechLevels, product.Release, end));
		TimeLine.SetEvents(product.MarketEvents.Concat(list2), product.Release, end);
	}

	public void InitPublishing()
	{
		PublisherDeal publishing = GetPublishing();
		if (publishing != null)
		{
			PublisherButton.SetActive(true);
			PublisherName.text = publishing.Publisher.Name;
			PublisherImage.uvRect = LogoController.Instance.GetLogoRect(publishing.Publisher);
			RefreshPublishing();
		}
		else
		{
			PublisherButton.SetActive(false);
		}
	}

	public void RefreshPublishing()
	{
		PublisherDeal publishing = GetPublishing();
		if (publishing != null)
		{
			List<string> list = new List<string>
			{
				"Deal".Loc(),
				"Royalty".Loc()
			};
			List<string> list2 = new List<string>
			{
				string.Join(", ", publishing.Deals.Select((string x) => x.Loc())),
				publishing.Royalty.ToPercent()
			};
			if (publishing.Recoup > 0f)
			{
				list.Add("Recoup".Loc());
				list.Add(" >" + "Royalty".Loc());
				float num = (float)(publishing.Cut / publishing.Invested);
				list2.Add(num.XTimes() + " / " + publishing.Recoup.XTimes());
				string text = publishing.PostRoyalty.ToPercent();
				list2.Add((num >= publishing.Recoup) ? text.FontColor(new Color(0f, 0.5f, 0f)) : text);
			}
			SimulatedCompany simulatedCompany;
			if ((simulatedCompany = publishing.Publisher as SimulatedCompany) != null && publishing.ProductTarget.DevCompany.IsLocalPlayer)
			{
				list.Add("Relationship".Loc());
				list2.Add(simulatedCompany.PlayerRelationship.ToPercent());
			}
			list.Add("Investment".Loc());
			list.Add("Cut".Loc());
			list2.Add(publishing.Invested.Currency());
			list2.Add(publishing.Cut.Currency());
			PublisherData.SetData(list.ToArray(), list2.ToArray(), false);
		}
		else if (PublisherPanel.gameObject.activeSelf)
		{
			PublisherButton.gameObject.SetActive(false);
			ShowIncomeData();
		}
	}

	public void ArchiveChange(bool on)
	{
		product.PlayerArchived = on;
	}

	private void AddonPanelToggle(bool t)
	{
		if (lastOption == 8)
		{
			UpdateList(lastOption);
		}
	}

	private IEnumerable<SoftwareProduct> GetFranchise()
	{
		SoftwareProduct p = product;
		for (SoftwareProduct sequelTo = p.SequelTo; sequelTo != null; sequelTo = p.SequelTo)
		{
			p = sequelTo;
		}
		while (p != null)
		{
			if (p != product)
			{
				yield return p;
			}
			p = p.Sequel;
		}
	}

	public void ShowIncomeData()
	{
		SubMarketPanel.SetActive(false);
		PublisherPanel.SetActive(false);
		BarChartPanel.SetActive(true);
		RelativeReviewScore.gameObject.SetActive(false);
		legend2.Colors = (barChart.Colors = HUD.GetThemeColors().ToList());
		legend2.Items.Clear();
		legend2.Items.Add("Sales".Loc());
		legend2.Items.Add("Licenses".Loc());
		legend2.UpdateItems();
		legend2.gameObject.SetActive(product.LicenseSum > 0.0);
		barChart.Values = new List<List<float>>();
		barChart.Log = false;
		barChart.AbsoluteScale = false;
		legend2.OnToggle = delegate
		{
			barChart.Values.Clear();
			UpdateMe();
		};
		barChart.UpdateCachedBars();
		barChart.ToolTipFunc = (int i, float x, float y) => FixDate(product.Release, i).ToVeryCompactString() + ": " + x.Currency();
		IncomeData = 0;
		UpdateMe();
	}

	public void ShowPublisherData()
	{
		SubMarketPanel.SetActive(false);
		PublisherPanel.SetActive(true);
		BarChartPanel.SetActive(false);
		legend2.gameObject.SetActive(false);
		RelativeReviewScore.gameObject.SetActive(false);
	}

	public PublisherDeal GetPublishing()
	{
		if (Addon != null)
		{
			if (!Addon.Forced)
			{
				return null;
			}
			return Addon.Parent.Publishing;
		}
		return product.Publishing;
	}

	public void ShowPublisherInfo()
	{
		if (GetPublishing() != null)
		{
			UISoundFX.PlaySFX("ButtonClick");
			HUD.Instance.companyWindow.ShowCompanyDetails(GetPublishing().Publisher);
		}
	}

	public void ShowRepData()
	{
		SubMarketPanel.SetActive(false);
		PublisherPanel.SetActive(false);
		BarChartPanel.SetActive(true);
		barChart.Log = false;
		barChart.AbsoluteScale = false;
		RelativeReviewScore.gameObject.SetActive(false);
		legend2.gameObject.SetActive(false);
		legend2.OnToggle = null;
		barChart.Values = new List<List<float>>
		{
			new List<float>()
		};
		barChart.UpdateCachedBars();
		barChart.ToolTipFunc = (int i, float x, float y) => FixDate(product.Release, i).ToVeryCompactString() + ": " + x.ToString("N0") + " " + "Fans".Loc().ToLower();
		IncomeData = 1;
		legend2.Colors = (barChart.Colors = HUD.GetThemeColors().ToList());
		UpdateMe();
	}

	public void ShowReviewData()
	{
		SubMarketPanel.SetActive(false);
		PublisherPanel.SetActive(false);
		BarChartPanel.SetActive(true);
		legend2.gameObject.SetActive(false);
		barChart.Log = !RelativeReviewScore.isOn;
		barChart.AbsoluteScale = !RelativeReviewScore.isOn;
		RelativeReviewScore.gameObject.SetActive(true);
		legend2.OnToggle = null;
		SDateTime release = (IsAddon ? Addon.Release : product.Release);
		if (RelativeReviewScore.isOn)
		{
			barChart.Values = new List<List<float>>
			{
				new List<float>()
			};
			barChart.ToolTipFunc = (int i, float x, float y) => FixDate(release, i).ToVeryCompactString() + ": " + "PositiveReviews".Loc(x.ToPercent());
		}
		else
		{
			barChart.Values = new List<List<float>>
			{
				new List<float>(),
				new List<float>()
			};
			barChart.ToolTipFunc = (int i, float x, float y) => FixDate(release, i).ToVeryCompactString() + ": " + Mathf.Abs(x).ToString("N0") + " " + "Reviews".Loc().ToLower();
		}
		barChart.UpdateCachedBars();
		IncomeData = 3;
		legend2.Colors = (barChart.Colors = new List<Color>
		{
			HUD.GetPosNeg(true),
			HUD.GetPosNeg(false)
		});
		UpdateMe();
	}

	public void ShowUnitSales()
	{
		SoftwareProduct softwareProduct = product;
		bool flag = softwareProduct != null && softwareProduct.SubscriptionBased;
		SubMarketPanel.SetActive(false);
		PublisherPanel.SetActive(false);
		barChart.Log = false;
		barChart.AbsoluteScale = false;
		RelativeReviewScore.gameObject.SetActive(false);
		BarChartPanel.SetActive(true);
		legend2.Colors = (barChart.Colors = HUD.GetThemeColors().ToList());
		if (flag)
		{
			legend2.Colors[0] = legend2.Colors[4];
			legend2.Colors[1] = legend2.Colors[3];
		}
		legend2.Items.Clear();
		legend2.Items.Add(flag ? "Activeusers".Loc() : "Physicalunits".Loc());
		legend2.Items.Add(flag ? "GainedUsers".Loc() : "Digitalunits".Loc());
		if (product == null || product.RefundSum != 0)
		{
			legend2.Items.Add("Refunds".Loc());
		}
		legend2.UpdateItems();
		legend2.gameObject.SetActive(legend2.Items.Count > 1);
		barChart.Values = new List<List<float>>();
		legend2.OnToggle = delegate
		{
			barChart.Values.Clear();
			UpdateMe();
		};
		barChart.UpdateCachedBars();
		SDateTime release = ((product == null) ? Addon.Release : product.Release);
		barChart.ToolTipFunc = (int i, float x, float y) => FixDate(release, i).ToVeryCompactString() + ": " + x.ToString("N0") + " " + "Units".Loc().ToLower() + " (" + (x / Mathf.Max(1f, y)).ToPercent() + ")";
		IncomeData = 2;
		UpdateMe();
	}

	public void ShowMarket()
	{
		SubMarketPanel.SetActive(true);
		PublisherPanel.SetActive(false);
		BarChartPanel.SetActive(false);
		legend2.gameObject.SetActive(false);
		RelativeReviewScore.gameObject.SetActive(false);
	}

	private SDateTime FixDate(SDateTime d, int m)
	{
		if (GameSettings.DaysPerMonth > 1 && d.Day == GameSettings.DaysPerMonth - 1)
		{
			return d + new SDateTime(1, m, 0);
		}
		return d + new SDateTime(m, 0);
	}

	public void ToggleMarket()
	{
	}

	public void DevelopAddon()
	{
		SoftwareAddOn softwareAddOn = ((_addonToggles != null) ? _addonToggles.FirstOrDefaultOf((KeyValuePair<SoftwareAddOn, Toggle> x) => x.Value.isOn, (KeyValuePair<SoftwareAddOn, Toggle> x) => x.Key) : product.Type.GetValidAddons(product.Category, product.TechLevels, product.Features, SDateTime.Now()).FirstOrDefault());
		if (softwareAddOn != null)
		{
			HUD.Instance.addonDesignWindow.Show(softwareAddOn, product);
		}
	}

	public void UpdateList(int option)
	{
		_previewMode = false;
		AddonPreview.SetActive(false);
		if (AddonPreviewImage.texture != null)
		{
			UnityEngine.Object.Destroy(AddonPreviewImage.texture);
			AddonPreviewImage.texture = null;
		}
		MainList.Items.Clear();
		MainList.LastSort = null;
		MainList["ProductNeedType"].ToggleActive(false, !IsAddon && ((option == 0 && !product.Type.OSSpecific) || option == 3));
		MainList["ProductName"].ToggleActive(false, !IsAddon && (option == 0 || option == 2));
		MainList["ProductCompany"].ToggleActive(false, !IsAddon && (option == 0 || option == 2));
		MainList["ProductRelease"].ToggleActive(false, !IsAddon && (option == 0 || option == 2));
		MainList["ProductDetail"].ToggleActive(false, !IsAddon && (option == 0 || option == 2));
		MainList["AddOnName"].ToggleActive(false, (IsAddon && option == 0) || option == 8);
		MainList["AddOnRelease"].ToggleActive(false, (IsAddon && option == 0) || option == 8);
		MainList["AddOnCompany"].ToggleActive(false, (IsAddon && option == 0) || option == 8);
		MainList["AddOnIncome"].ToggleActive(false, (IsAddon && option == 0) || option == 8);
		MainList["AddOnLastMonth"].ToggleActive(false, (IsAddon && option == 0) || option == 8);
		MainList["AddOnDetail"].ToggleActive(false, (IsAddon && option == 0) || option == 8);
		MainList["SoftwareFeatureName"].ToggleActive(false, !IsAddon && option == 4);
		MainList["AddonFeatureName"].ToggleActive(false, IsAddon && option == 4);
		MainList["AddonFeatureFactor"].ToggleActive(false, IsAddon && option == 4);
		MainList["PatentName"].ToggleActive(false, option == 1);
		MainList["PatentResearched"].ToggleActive(false, option == 1);
		MainList["PatentOwner"].ToggleActive(false, option == 1);
		MainList["LicenseName"].ToggleActive(false, option == 5 || option == 6);
		MainList["LicensePaid"].ToggleActive(false, option == 5);
		MainList["LicenseReversePaid"].ToggleActive(false, option == 6);
		MainList["LicenseDetails"].ToggleActive(false, option == 5 || option == 6);
		switch (option)
		{
		case 0:
			_previewMode = true;
			ExtraChart.gameObject.SetActive(false);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			if (IsAddon)
			{
				MainList.Items.AddRange(Addon.Parent.Addons[Addon.Type].Where((AddOnProduct x) => x != Addon).Cast<object>());
			}
			else if (product.Type.OSSpecific)
			{
				if (product.OSCount > 0)
				{
					MainList.Items.AddRange(product.GetOSs().Cast<object>());
				}
			}
			else
			{
				MainList.Items.AddRange((from x in GameSettings.Instance.simulation.GetAllProducts(true)
					where x.Type.OSSpecific && x.HasOS(product)
					select x).Cast<object>());
			}
			break;
		case 1:
			ExtraChart.gameObject.SetActive(false);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			MainList.Items.AddRange((IsAddon ? Addon.Parent : product).TechLevels.Values.Cast<object>());
			break;
		case 2:
			_previewMode = true;
			ExtraChart.gameObject.SetActive(false);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			MainList.Items.AddRange(GetFranchise().Cast<object>());
			break;
		case 4:
			ExtraChart.gameObject.SetActive(false);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			if (IsAddon)
			{
				MainList.Items.AddRange(Addon.Features.Where((AddOnFeature x) => !x.IsBase).Select((AddOnFeature x, int i) => new KeyValuePair<AddOnFeature, uint>(x, Addon.FeatureFactors[i])).Cast<object>());
			}
			else
			{
				string swName = product.Type.Name;
				MainList.Items.AddRange(product.Features.Select((FeatureBase x) => new KeyValuePair<string, string>(swName, x.Name)).Cast<object>());
			}
			break;
		case 5:
		{
			ExtraChart.gameObject.SetActive(false);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			IEnumerable<LicenseData> source = from x in product.GetTools()
				select new LicenseData(product, x.Item1);
			if (product.Framework != null)
			{
				source = source.Append(new LicenseData(product, product.Framework));
			}
			MainList.Items.AddRange(source.Cast<object>());
			break;
		}
		case 6:
		{
			ExtraChart.gameObject.SetActive(false);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			List<object> list3 = new List<object>();
			foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(true))
			{
				if (allProduct.HasTool(product))
				{
					list3.Add(new LicenseData(product, allProduct));
				}
			}
			MainList.Items.AddRange(list3);
			break;
		}
		case 7:
		{
			ExtraChart.gameObject.SetActive(true);
			MainList.gameObject.SetActive(false);
			AddonPanel.gameObject.SetActive(false);
			AddonDevButton.SetActive(false);
			bool flag2 = false;
			ExtraChart.Values.Clear();
			List<string> list4 = new List<string>();
			if (product.LossBreakdown != null)
			{
				for (int num2 = 0; num2 < product.LossBreakdown.Length; num2++)
				{
					double num3 = product.LossBreakdown[num2];
					if (num3 > 0.0)
					{
						ExtraChart.Values.Add((float)num3);
						SoftwareProduct.LossType lossType = (SoftwareProduct.LossType)num2;
						list4.Add(lossType.ToString().Loc() + "\n(" + num3.Currency() + ")");
						flag2 = true;
					}
				}
			}
			if (!flag2)
			{
				ExtraChart.Values.Add(0f);
				list4.Add("Nodataavailable".Loc());
			}
			ExtraChart.SetLabels(list4);
			if (base.gameObject.activeSelf)
			{
				StartCoroutine(FixChart());
			}
			break;
		}
		case 8:
		{
			TutorialSystem.Instance.StartTutorial("Addons");
			_previewMode = true;
			ExtraChart.gameObject.SetActive(true);
			MainList.gameObject.SetActive(true);
			AddonPanel.gameObject.SetActive(_addonToggles != null);
			AddonDevButton.SetActive(!product.Archived && (product.DevCompany.IsLocalPlayer || product.Category.Hardware));
			List<AddOnProduct> list = ((_addonToggles != null) ? product.Addons.GetOrNull(_addonToggles.FirstOrDefaultOf((KeyValuePair<SoftwareAddOn, Toggle> x) => x.Value.isOn, (KeyValuePair<SoftwareAddOn, Toggle> x) => x.Key)) : product.Addons.Values.FirstOrDefault());
			if (list != null)
			{
				MainList.Items.AddRange(list.Cast<object>());
			}
			bool flag = false;
			ExtraChart.Values.Clear();
			List<string> list2 = new List<string>();
			if (list != null)
			{
				for (int num = 0; num < list.Count; num++)
				{
					uint sales = list[num].Sales;
					if (sales != 0)
					{
						ExtraChart.Values.Add(sales);
						list2.Add(list[num].Name + "\n(" + sales.ToString("N0") + ")");
						flag = true;
					}
				}
			}
			if (!flag)
			{
				ExtraChart.Values.Add(0f);
				list2.Add("Nodataavailable".Loc());
			}
			ExtraChart.SetLabels(list2);
			if (base.gameObject.activeSelf)
			{
				StartCoroutine(FixChart());
			}
			break;
		}
		}
		lastOption = option;
	}

	private IEnumerator FixChart()
	{
		yield return new WaitForEndOfFrame();
		ExtraChart.UpdateCachedPie();
	}

	private float GetScore(List<int> pos, List<int> neg, int count, SDateTime release)
	{
		if (SDateTime.GetMonths(release + pos.Count, SDateTime.Now()) >= 6f)
		{
			return -1f;
		}
		float num = 0f;
		float num2 = 0f;
		for (int i = pos.Count - count; i < pos.Count; i++)
		{
			num += (float)pos[i];
			num2 += (float)neg[i];
		}
		if (num + num2 < 50f)
		{
			return -1f;
		}
		if (num != 0f)
		{
			return num / (num + num2);
		}
		return 0f;
	}

	private string GetReviewLabel(out string recent)
	{
		recent = null;
		uint num = (IsAddon ? Addon.PositiveReviews : product.PositiveReviews);
		uint num2 = (IsAddon ? Addon.NegativeReviews : product.NegativeReviews);
		if (num + num2 == 0)
		{
			return "NotApplicableAbbr".Loc();
		}
		List<int> list = (IsAddon ? Addon.PositiveReviewList : product.PositiveReviewList);
		List<int> neg = (IsAddon ? Addon.NegativeReviewList : product.NegativeReviewList);
		string text = ((num == 0) ? 0f : ((float)num / (float)(num + num2))).ToPercent();
		if (list != null && list.Count > 3)
		{
			float score = GetScore(list, neg, 3, IsAddon ? Addon.Release : product.Release);
			if (score >= 0f)
			{
				recent = "*" + "RecentReviews".Loc() + ": " + score.ToPercent();
			}
		}
		return text + " " + "BasedOnReviews".Loc((num + num2).ToString("N0"));
	}

	private void UpdateMainRightText()
	{
		int i = 0;
		if (IsAddon)
		{
			string recent;
			SetLabel(_rightData, GetReviewLabel(out recent), ref i);
			RightSh.ToolTips[i - 1] = recent;
			SetLabel(_rightData, SoftwareType.GetAwarenessLabel(Addon.GetAwareness()), ref i);
			SetLabel(_rightData, Addon.PhysicalCopies.ToString("N0"), ref i);
			SetLabel(_rightData, Addon.Sales.ToString("N0"), ref i);
			if (Addon.Forced)
			{
				SetLabel(_rightData, Addon.Parent.UnitSum.ToString("N0"), ref i);
			}
			SetLabel(_rightData, Addon.Refunds.ToString("N0"), ref i);
			SetLabel(_rightData, Addon.Gross.Currency(), ref i);
			SetLabel(_rightData, Addon.Loss.Currency(), ref i);
			RightSh.UpdateValues(_rightData);
			return;
		}
		SetLabel(_rightData, product.Userbase.ToString("N0"), ref i);
		string recent2;
		SetLabel(_rightData, GetReviewLabel(out recent2), ref i);
		RightSh.ToolTips[i - 1] = recent2;
		SetLabel(_rightData, SoftwareType.GetAwarenessLabel(product.GetAwareness()), ref i);
		if (Licensable)
		{
			SetLabel(_rightData, product.GetLicenseCost(true).Currency(), ref i);
		}
		string value = product.PhysicalCopies.ToString("N0");
		SetLabel(_rightData, value, ref i);
		if (product.Type.Name.Equals("Operating System"))
		{
			SetLabel(_rightData, product.OSSalesBoost.ToPercent(), ref i);
		}
		SetLabel(_rightData, product.UnitSum.ToString("N0"), ref i);
		SetLabel(_rightData, product.RefundSum.ToString("N0"), ref i);
		SetLabel(_rightData, product.Type.GetReach(product.Category, product.GetOSs()).ToString("N0"), ref i);
		SetLabel(_rightData, product.Sum.Currency(), ref i);
		if (Licensable)
		{
			SetLabel(_rightData, product.LicenseSum.Currency(), ref i);
			SetLabel(_rightData, MarketSimulation.Active.GetAllCompanies().SumSafe((Company x) => x.LicenseCount(product)).ToString(), ref i);
		}
		SetLabel(_rightData, product.Loss.Currency(), ref i);
		RightSh.UpdateValues(_rightData);
	}

	private void SetLabel(string[] arr, string value, ref int i)
	{
		arr[i] = value;
		i++;
	}

	private IEnumerator Start()
	{
		ExtraChart.Colors = HUD.GetThemeColors().ToList();
		MainList.OnSelectChange = delegate
		{
			if (_previewMode)
			{
				if (AddonPreviewImage.texture == null)
				{
					AddonPreviewImage.texture = new RenderTexture(128, 128, 0);
				}
				IDisplayable[] selected = MainList.GetSelected<IDisplayable>();
				if (selected.Length != 0)
				{
					HardwareDesignRenderer.Instance.RenderProduct(selected[0], (RenderTexture)AddonPreviewImage.texture, false);
					AddonPreview.SetActive(true);
					ExtraChart.gameObject.SetActive(false);
					RefreshThumbnail();
				}
			}
		};
		UpdateList(0);
		if (!IsAddon)
		{
			MarketSlider.ApplyRatio((float)product.Submarkets[0], (float)product.Submarkets[1], (float)product.Submarkets[2]);
			SubmarketLabels[0].text = product.Type.SubMarkets[0].LocTry();
			SubmarketLabels[1].text = product.Type.SubMarkets[1].LocTry();
			SubmarketLabels[2].text = product.Type.SubMarkets[2].LocTry();
		}
		UpdateMe();
		yield return new WaitForEndOfFrame();
		barChart.UpdateCachedBars();
	}

	private void Update()
	{
		CompanyLogo.uvRect = LogoController.Instance.GetLogoRect(IsAddon ? Addon.Owner : product.DevCompany);
	}

	public void UpdateActionCombo()
	{
		if (IsAddon)
		{
			ActionCombo.UpdateContent(from x in _addonButtons
				where x.Valid(Addon.Owner.IsLocalPlayer, Addon.Parent.Archived, Addon)
				select new GUICombobox.ComboAction(x.Label.Loc(), delegate
				{
					x.Execute(Addon.Owner.IsLocalPlayer, Addon.Parent.Archived, Addon);
				}));
		}
		else
		{
			ActionCombo.UpdateContent(from x in _softwareButtons
				where x.Valid(product.DevCompany.IsLocalPlayer, product.Archived, product)
				select new GUICombobox.ComboAction(x.Label.Loc(), delegate
				{
					x.Execute(product.DevCompany.IsLocalPlayer, product.Archived, product);
				}));
		}
		ActionCombo.gameObject.SetActive(ActionCombo.Items.Count > 0);
	}

	public void UpdateMe()
	{
		UpdateMainRightText();
		UpdateLeftInfo();
		UpdateActionCombo();
		if (!IsAddon)
		{
			ReviewButton.SetActive(product.PositiveReviewList != null);
			uint num = (product.SubscriptionBased ? ((uint)product.Userbase) : product.UnitSum);
			OSSaleWarning.SetActive(!product.Archived && num >= product.Type.GetReach(product.Category, product.GetOSs()));
			if (IncomeData == 0 || IncomeData == 2)
			{
				int num2 = 0;
				for (int num3 = legend2.Items.Count - 1; num3 >= 0; num3--)
				{
					if (legend2.IsOn(num3))
					{
						num2 = num3 + 1;
						break;
					}
				}
				for (int i = barChart.Values.Count; i < num2; i++)
				{
					barChart.Values.Add(new List<float>());
				}
			}
			else if (IncomeData != 3)
			{
				while (barChart.Values.Count > 1)
				{
					barChart.Values.RemoveAt(1);
				}
			}
			if (IncomeData == 0)
			{
				UpdateBar(0, product.GetCashflow(false), legend2.IsOn(0), (float x, int _) => x, product.GetCashflow(true));
				UpdateBar(1, product.GetCashflow(true), legend2.IsOn(1), (float x, int _) => x);
			}
			else if (IncomeData == 1)
			{
				UpdateValues(0, product.Rep);
			}
			else if (IncomeData == 2)
			{
				UpdateBar(0, product.GetUnitSales(false), legend2.IsOn(0), (int x, int _) => x);
				UpdateBar(1, product.GetUnitSales(true), legend2.IsOn(1), (int x, int _) => x);
				UpdateBar(2, product.GetRefunds(), legend2.IsOn(2), (int x, int _) => x);
			}
			else if (IncomeData == 3 && product.PositiveReviewList != null)
			{
				if (RelativeReviewScore.isOn)
				{
					UpdateBar(0, product.PositiveReviewList, true, (int x, int index) => (x != 0) ? ((float)x / (float)(x + product.NegativeReviewList[index])) : 0f);
				}
				else
				{
					UpdateBar(0, product.PositiveReviewList, true, (int x, int _) => x);
					UpdateBar(1, product.NegativeReviewList, true, (int x, int _) => -x);
				}
			}
			UpdateTimeline();
		}
		else if (IncomeData == 3)
		{
			if (Addon.PositiveReviewList != null)
			{
				if (RelativeReviewScore.isOn)
				{
					UpdateBar(0, Addon.PositiveReviewList, true, (int x, int index) => (x != 0) ? ((float)x / (float)(x + Addon.NegativeReviewList[index])) : 0f);
				}
				else
				{
					UpdateBar(0, Addon.PositiveReviewList, true, (int x, int _) => x);
					UpdateBar(1, Addon.NegativeReviewList, true, (int x, int _) => -x);
				}
			}
		}
		else
		{
			int num4 = 0;
			for (int num5 = legend2.Items.Count - 1; num5 >= 0; num5--)
			{
				if (legend2.IsOn(num5))
				{
					num4 = num5 + 1;
					break;
				}
			}
			for (int num6 = barChart.Values.Count; num6 < num4; num6++)
			{
				barChart.Values.Add(new List<float>());
			}
			List<int> data = Addon.UnitOfflineSales ?? SoftwareProduct.EmptyUnit;
			List<int> data2 = Addon.UnitOnlineSales ?? SoftwareProduct.EmptyUnit;
			List<int> data3 = Addon.RefundsSales ?? SoftwareProduct.EmptyUnit;
			UpdateBar(0, data, legend2.IsOn(0), (int x, int _) => x);
			UpdateBar(1, data2, legend2.IsOn(1), (int x, int _) => x);
			UpdateBar(2, data3, legend2.IsOn(2), (int x, int _) => x);
		}
		barChart.UpdateCachedBars();
		UpdateList(lastOption);
		RefreshPublishing();
	}

	private void UpdateValues(int idx, List<float> values)
	{
		if (barChart.Values[idx].Count > 0)
		{
			barChart.Values[idx][barChart.Values[idx].Count - 1] = values[barChart.Values[idx].Count - 1];
		}
		if (barChart.Values[idx].Count != values.Count)
		{
			for (int i = barChart.Values[idx].Count; i < values.Count; i++)
			{
				barChart.Values[idx].Add(values[i]);
			}
			barChart.UpdateCachedBars();
		}
	}

	private void UpdateBar<T>(int bar, List<T> data, bool getData, Func<T, int, float> conv, List<T> sub = null)
	{
		if (bar >= barChart.Values.Count)
		{
			return;
		}
		List<float> list = barChart.Values[bar];
		if (list.Count > 0)
		{
			int num = list.Count - 1;
			if (num < data.Count)
			{
				list[num] = (getData ? (conv(data[num], num) - ((sub == null || num >= sub.Count) ? 0f : conv(sub[num], num))) : 0f);
			}
		}
		if (list.Count != data.Count)
		{
			for (int i = list.Count; i < data.Count; i++)
			{
				list.Add(getData ? (conv(data[i], i) - ((sub == null || i >= sub.Count) ? 0f : conv(sub[i], i))) : 0f);
			}
			barChart.UpdateCachedBars();
		}
	}

	private static void HandleDistribution(IStockable p, bool print)
	{
		if (print)
		{
			if (GameSettings.Instance.GetPrintJob(p) != null)
			{
				return;
			}
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
				PrintJob printJob = new PrintJob(p)
				{
					Maximum = maximum
				};
				GameSettings.Instance.AddPrintOrder(printJob, false);
				if (printJob.Hardware)
				{
					GameSettings.Instance.PromptPrintAssignment(printJob);
				}
				HUD.Instance.distributionWindow.Show(printJob);
			});
		}
		else
		{
			HUD.Instance.copyOrderWindow.Show(p);
		}
	}
}
