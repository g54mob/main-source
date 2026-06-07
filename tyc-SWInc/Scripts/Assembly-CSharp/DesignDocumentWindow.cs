using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DesignDocumentWindow : MonoBehaviour
{
	[Serializable]
	public class RectSetup
	{
		public string Name;

		public Rect Position;

		public Rect Anchors;

		public RectSetup(RectTransform t)
		{
			Name = t.name;
			Position = Rect.MinMaxRect(t.offsetMin.x, t.offsetMin.y, t.offsetMax.x, t.offsetMax.y);
			Anchors = Rect.MinMaxRect(t.anchorMin.x, t.anchorMin.y, t.anchorMax.x, t.anchorMax.y);
		}

		public void Load(RectTransform t)
		{
			t.anchorMin = Anchors.min;
			t.anchorMax = Anchors.max;
			t.offsetMin = Position.min;
			t.offsetMax = Position.max;
		}
	}

	[Serializable]
	public class RectSetups
	{
		public RectSetup[] Setups;

		public RectSetups(RectSetup[] s)
		{
			Setups = s;
		}
	}

	public int CurrentPage;

	[SerializeField]
	public List<RectSetups> Pages = new List<RectSetups>();

	public int MaxDefaultPages = 5;

	public string[] PageNames;

	public bool PageChanged;

	public RectTransform PageContent;

	public FeatureCard FeatureCardPrefab;

	public GUIWindow Window;

	public InputField ProductName;

	public InputField PriceText;

	public InputField NewFramework;

	public GUICombobox TypeCombo;

	public GUICombobox ServerCombo;

	public GUICombobox SCMCombo;

	public GUICombobox CategoryCombo;

	public GUICombobox SubsidiaryCombo;

	public GUIPieChart[] Pies;

	public Text[] Submarkets;

	public GUIProgressBar[] SubmarketSats;

	public TriangleSlider SubmarketSlider;

	public Color[] SubMarketColors;

	public Button NameButton;

	public Button IPButton;

	public Button PrevPage;

	public Button NextPage;

	public GameObject ProjManButton;

	public GameObject NewFrameworkNameLabel;

	public Toggle HouseToggle;

	public Toggle NewFrameworkToggle;

	public Toggle UseFrameworkToggle;

	public Toggle SkipGeneration;

	public Toggle SubscriptionToggle;

	public Toggle SequelMarketToggle;

	public Toggle CompetitionMarketToggle;

	public Text IPButtonText;

	public Text DesignTeamText;

	public Text DevelopTeamText;

	public Text TeamIssueText;

	public Text PageTitle;

	public Text ExistingFramework;

	public Text PageNumLabel;

	public VarValueSheet DescriptionSh;

	public VarValueSheet LimitSheet;

	public GUIListView OSList;

	public RectTransform NeedsRect;

	public RectTransform ForcedAddRect;

	public ScrollRect FeatureScroll;

	public GameObject ButtonPrefab;

	public GameObject LabelPrefab;

	public GameObject FeaturePrefab;

	public FrameworkWindow FrameworkDialog;

	public GameObject AdvancedButton;

	public GameObject PagePanel;

	public LeadDesignControl LeadDesigner;

	public Text PrevPageLabel;

	[NonSerialized]
	public Dictionary<Button, KeyValuePair<string, SoftwareProduct>> NeedsList = new Dictionary<Button, KeyValuePair<string, SoftwareProduct>>();

	[NonSerialized]
	public Dictionary<Button, KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>> ForcedAddList = new Dictionary<Button, KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>>();

	[NonSerialized]
	public List<FeatureCard> FeatureCards = new List<FeatureCard>();

	[NonSerialized]
	public Dictionary<Button, GameObject> NeedLabels = new Dictionary<Button, GameObject>();

	[NonSerialized]
	public Dictionary<Button, GameObject> ForcedAddLabels = new Dictionary<Button, GameObject>();

	[NonSerialized]
	private SoftwareFramework _framework;

	public GameObject NeedsSubPanel;

	public GameObject OSPanel;

	public GameObject OSLabel;

	public GameObject NeedsLabel;

	public GameObject ForcedAddLabel;

	public GameObject ExistingFrameworkButton;

	public GameObject ManufactureButton;

	public GameObject ManufactureView;

	public GameObject HardwareDesignButton;

	public ManufacturingPanel Manufacturing;

	public Gradient InterestGradient;

	public RectTransform FeaturePanel;

	public GameObject[] DistributionDisable;

	public string DefaultName = "StandardProductName";

	public static string[] BalanceNames = new string[5] { "BalanceAmount1", "BalanceAmount2", "BalanceAmount3", "BalanceAmount4", "BalanceAmount5" };

	[NonSerialized]
	public HashSet<string> DesignTeams = new HashSet<string>();

	[NonSerialized]
	public HashSet<string> DevelopmentTeams = new HashSet<string>();

	[NonSerialized]
	private PublisherDeal _publisher;

	[NonSerialized]
	private byte[] _hardwareDesign;

	[NonSerialized]
	private SoftwareProduct _sequelTo;

	[NonSerialized]
	private SoftwareType _swOverride;

	[NonSerialized]
	private SoftwareCategory _swCatOverride;

	[NonSerialized]
	private bool priceHasBeenEdited;

	[NonSerialized]
	public bool DisableFeatureUpdate;

	private bool _noSubUpdate;

	private string _lastSWType;

	private string _lastSWCat;

	private bool _changeSWType = true;

	private bool _checkingWithPublisher;

	private List<string> _varList = new List<string>();

	private List<string> _valueList = new List<string>();

	private List<string> _tipList = new List<string>();

	[NonSerialized]
	private Dictionary<Employee.EmployeeRole, Dictionary<string, int>> _teamSpecs = new Dictionary<Employee.EmployeeRole, Dictionary<string, int>>();

	public bool AutoDev;

	public PublisherDealWindow PubDealWindow;

	public Text PublisherText;

	public SimulatedCompany Subsidiairy
	{
		get
		{
			if (!SubsidiaryCombo.gameObject.activeSelf)
			{
				return null;
			}
			return (SimulatedCompany)SubsidiaryCombo.SelectedItem;
		}
	}

	public SoftwareProduct SequelTo
	{
		get
		{
			return _sequelTo;
		}
		set
		{
			_sequelTo = value;
			for (int i = 0; i < FeatureCards.Count; i++)
			{
				FeatureCards[i].RefreshSpeedBoost(_sequelTo, Framework, _teamSpecs);
			}
			IPButtonText.text = ((_sequelTo == null) ? "SelectIPButton".Loc() : _sequelTo.Name);
			UpdateDescription();
			if (CurrentPage == 0)
			{
				AutoBalanceSubmarkets();
			}
			bool flag = false;
			SoftwareCategory category = GetCategory(SelectedType);
			foreach (FeatureCard featureCard in FeatureCards)
			{
				if (!featureCard.Feature.IsForced(category.Name) && featureCard.MainToggle.isOn)
				{
					flag = true;
					break;
				}
				foreach (Toggle value2 in featureCard.SubFeatures.Values)
				{
					if (value2.isOn)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				SelectSequelFeatures();
			}
		}
	}

	public SoftwareType SelectedType
	{
		get
		{
			return _swOverride ?? MarketSimulation.Active.SoftwareTypes[TypeCombo.SelectedItemString];
		}
	}

	public float Price
	{
		get
		{
			float b = 0f;
			try
			{
				b = (float)Convert.ToDouble(PriceText.text);
			}
			catch (Exception)
			{
			}
			return Mathf.Max(0f, b).FromCurrency();
		}
	}

	public SoftwareFramework Framework
	{
		get
		{
			return _framework;
		}
		set
		{
			_framework = value;
			ExistingFramework.text = ((_framework == null) ? "None".Loc() : _framework.Name);
			for (int i = 0; i < FeatureCards.Count; i++)
			{
				FeatureCard featureCard = FeatureCards[i];
				featureCard.RefreshSpeedBoost(SequelTo, _framework, _teamSpecs);
				TechLevel value2;
				if (_framework != null && _framework.TechLevels.TryGetValue(featureCard.Feature.Spec, out value2) && featureCard.Tech.Year > value2.Year)
				{
					featureCard.ChangeTech(value2);
				}
			}
			FixFeatures();
		}
	}

	public Dictionary<Employee.EmployeeRole, Dictionary<string, int>> TeamSpecs
	{
		get
		{
			return _teamSpecs;
		}
	}

	public void SaveCurrentPageSetup(int page)
	{
		List<RectSetup> list = new List<RectSetup>();
		for (int i = 0; i < PageContent.childCount; i++)
		{
			RectTransform component = PageContent.GetChild(i).GetComponent<RectTransform>();
			if (component.gameObject.activeSelf)
			{
				list.Add(new RectSetup(component));
			}
		}
		if (page < Pages.Count)
		{
			Pages[page] = new RectSetups(list.ToArray());
		}
		else
		{
			Pages.Add(new RectSetups(list.ToArray()));
		}
	}

	public void LoadPage(int id)
	{
		if (id < 0 || id >= Pages.Count)
		{
			return;
		}
		PrevPage.interactable = id > 0;
		NextPage.interactable = id < MaxDefaultPages;
		CurrentPage = id;
		RectSetups rectSetups = Pages[CurrentPage];
		for (int i = 0; i < PageContent.childCount; i++)
		{
			RectTransform child = PageContent.GetChild(i).GetComponent<RectTransform>();
			RectSetup rectSetup = rectSetups.Setups.FirstOrDefault((RectSetup x) => x.Name.Equals(child.name));
			if (rectSetup != null)
			{
				rectSetup.Load(child);
				child.gameObject.SetActive(true);
			}
			else
			{
				child.gameObject.SetActive(false);
			}
		}
	}

	public void ChangePage(int offset)
	{
		PageChanged = true;
		LoadPage(CurrentPage + offset);
		UpdatePageTitle();
		if (CurrentPage == 1)
		{
			if ("Simple design document".Equals(TutorialSystem.Instance.CurrentTutorialName) || GameSettings.Instance.DisabledTutorials.Contains("Simple design document"))
			{
				TutorialSystem.Instance.StartTutorial("Advanced design document");
			}
			else
			{
				TutorialSystem.Instance.StartTutorial("Design document");
			}
		}
	}

	public void UpdatePageTitle()
	{
		PageTitle.text = ((CurrentPage == 0 || IsDistribution()) ? "" : ("<b>" + PageNames[CurrentPage].Loc() + "</b> - " + TypeCombo.SelectedItemString.LocSWFull(CategoryCombo.SelectedItemString)));
		PrevPageLabel.text = ((CurrentPage > 1) ? "Previouspage".Loc() : "Simple".Loc());
		PagePanel.SetActive(CurrentPage > 0 && !IsDistribution());
		AdvancedButton.SetActive(CurrentPage == 0);
		PageContent.offsetMax = ((CurrentPage == 0 || IsDistribution()) ? new Vector2(PageContent.offsetMax.x, -2f) : new Vector2(PageContent.offsetMax.x, -27f));
		PageNumLabel.text = CurrentPage + "/" + MaxDefaultPages;
	}

	public void UpdateMarketExtraPoints()
	{
		if (CompetitionMarketToggle.isOn || SequelMarketToggle.isOn)
		{
			SubmarketSlider.ExtraPoints.Clear();
			SoftwareProduct sequelTo = SequelTo;
			HashSet<SoftwareProduct> hashSet = ((sequelTo != null) ? (from x in sequelTo.GetEntireIP()
				orderby x.Release.ToInt()
				select x).ToHashSet() : null);
			if (CompetitionMarketToggle.isOn)
			{
				SoftwareCategory category = GetCategory();
				SDateTime sDateTime = SDateTime.Now() - 120;
				foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
				{
					if (allProduct.Category == category && (allProduct.LastUpdated ?? allProduct.Release) > sDateTime && (hashSet == null || !hashSet.Contains(allProduct)))
					{
						SubmarketSlider.ExtraPoints.Add(new ValueTuple<Vector2, Color, SoftwareProduct>(TriangleSlider.RatioToVector((float)allProduct.Submarkets[0], (float)allProduct.Submarkets[1], (float)allProduct.Submarkets[2]), HUD.GetThemeColor(2), allProduct));
					}
				}
			}
			if (SequelMarketToggle.isOn && hashSet != null)
			{
				foreach (SoftwareProduct item in hashSet)
				{
					SubmarketSlider.ExtraPoints.Add(new ValueTuple<Vector2, Color, SoftwareProduct>(TriangleSlider.RatioToVector((float)item.Submarkets[0], (float)item.Submarkets[1], (float)item.Submarkets[2]), HUD.GetThemeColor(0), item));
				}
			}
			SubmarketSlider.UpdateGraphics();
		}
		else if (SubmarketSlider.ExtraPoints.Count > 0)
		{
			SubmarketSlider.ExtraPoints.Clear();
			SubmarketSlider.UpdateGraphics();
		}
	}

	public SoftwareCategory GetCategory(SoftwareType type = null)
	{
		SoftwareCategory softwareCategory = _swCatOverride;
		if (softwareCategory == null)
		{
			if (type != null)
			{
				return type.Categories[CategoryCombo.SelectedItemString];
			}
			softwareCategory = SelectedType.Categories[CategoryCombo.SelectedItemString];
		}
		return softwareCategory;
	}

	public bool IsDistribution()
	{
		return _swOverride == MarketSimulation.Active.DigitalDistSoft;
	}

	public void MarketAnalysis()
	{
		HUD.Instance.marketAnalysisWindow.Show(GetCategory());
	}

	private float GetDefaultPrice()
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		return (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(category, SubscriptionToggle.isOn) * category.PerceivedValue(GetFeatures(), GetTechLevelDict(false)));
	}

	public void SelectDefaultPrice()
	{
		PriceText.text = GetDefaultPrice().CurrencyMul().ToString("N");
		priceHasBeenEdited = false;
		UpdateDescription();
	}

	public void PriceEndEdit()
	{
		float num = 0f;
		try
		{
			num = Mathf.Max(0f, (float)Convert.ToDouble(PriceText.text));
			if (float.IsInfinity(num) || float.IsNaN(num))
			{
				num = 0f;
			}
			if (num < 0.05f && SubscriptionToggle.isOn)
			{
				num = GetDefaultPrice().CurrencyMul();
			}
			PriceText.text = num.ToString("N");
			priceHasBeenEdited = true;
			if (Price < 1f)
			{
				SetPublishingDeal(null);
			}
			UpdateDescription();
		}
		catch (Exception)
		{
			SelectDefaultPrice();
		}
	}

	public void PickBestLead(bool force)
	{
		Employee currentEmployee = LeadDesigner.CurrentEmployee;
		SoftwareType selectedType = SelectedType;
		if (force || currentEmployee == null || !currentEmployee.IsRole(Employee.RoleBit.Designer) || !DesignTeams.Contains(currentEmployee.MyActor.Team))
		{
			Actor actor = null;
			if (SequelTo != null && SequelTo.DesignerOwned)
			{
				if (SequelTo.LeadDesigner.MyActor != null && DesignTeams.Contains(SequelTo.LeadDesigner.MyActor.Team))
				{
					actor = SequelTo.LeadDesigner.MyActor;
				}
			}
			else
			{
				float num = -0.5f;
				foreach (Team item in DesignTeams.SelectNotNull(GameSettings.GetTeam))
				{
					float score;
					Actor bestLeadDesigner = item.GetBestLeadDesigner(out score, selectedType, null);
					if (score > num)
					{
						num = score;
						actor = bestLeadDesigner;
					}
				}
			}
			if (actor != null)
			{
				LeadDesigner.Init(actor.employee, selectedType.Name);
			}
			else
			{
				LeadDesigner.Init(null);
			}
			UpdateDescription();
		}
		else
		{
			LeadDesigner.Init(currentEmployee, selectedType.Name);
		}
	}

	public void UpdateForcedAddonFeatures()
	{
		List<FeatureBase> list = null;
		foreach (KeyValuePair<Button, KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>> forcedAdd in ForcedAddList)
		{
			if (forcedAdd.Value.Value == null)
			{
				continue;
			}
			if (list == null)
			{
				list = GetFeatures();
			}
			AddonDesignWindow.AddonDesign value = forcedAdd.Value.Value;
			List<AddOnFeature> list2 = null;
			List<uint> list3 = null;
			for (int i = 0; i < value.Features.Length; i++)
			{
				AddOnFeature f = value.Features[i];
				if (f.FeatureDependency != null && !list.Any((FeatureBase x) => x.Name.Equals(f.FeatureDependency)))
				{
					if (list2 == null)
					{
						list2 = value.Features.ToList();
						list3 = value.FeatureFactors.ToList();
					}
					int index = list2.IndexOf(f);
					list2.RemoveAt(index);
					list3.RemoveAt(index);
				}
			}
			if (list2 == null)
			{
				continue;
			}
			value.Features = list2.ToArray();
			value.FeatureFactors = list3.ToArray();
			HashSet<string> tools = value.Type.GetTools(value.Features);
			foreach (string item in value.Tools.Keys.ToList())
			{
				if (!tools.Contains(item))
				{
					value.Tools.Remove(item);
				}
			}
		}
	}

	public void ChangeDevTeam(bool design)
	{
		HashSet<string> teams = (design ? DesignTeams : DevelopmentTeams);
		HUD.Instance.TeamSelectWindow.Show(false, teams, delegate(string[] t)
		{
			teams.Clear();
			teams.AddRange(t);
			RefreshTeamSpecs();
			for (int i = 0; i < FeatureCards.Count; i++)
			{
				FeatureCards[i].RefreshSpeedBoost(SequelTo, Framework, _teamSpecs);
			}
			UpdateDescription();
			if (design)
			{
				PickBestLead(false);
			}
		}, design ? "Design" : "Development", null, design ? "DesignDocument" : "SoftwareAlpha");
	}

	public void UpdateTeamText()
	{
		DesignTeams = DesignTeams.Where((string x) => GameSettings.Instance.sActorManager.Teams.ContainsKey(x)).ToHashSet();
		DesignTeamText.text = DesignTeams.GetListAbbrev("Team");
		DevelopmentTeams = DevelopmentTeams.Where((string x) => GameSettings.Instance.sActorManager.Teams.ContainsKey(x)).ToHashSet();
		DevelopTeamText.text = DevelopmentTeams.GetListAbbrev("Team");
		string text = CheckCompetency();
		if (text == null)
		{
			TeamIssueText.enabled = false;
			return;
		}
		TeamIssueText.enabled = true;
		TeamIssueText.text = "MissingThing".Loc(text);
	}

	public string GetBalanceScore(float score)
	{
		if (score == 0f)
		{
			return "None";
		}
		int num = Mathf.Clamp(Mathf.FloorToInt((1f - Mathf.Pow(1f - score, 2f)) * (float)BalanceNames.Length), 0, BalanceNames.Length - 1);
		return BalanceNames[num];
	}

	public static string GetTimeString(float months, float actual, float optimal)
	{
		string input = ((months < 12f) ? "DevTime1".Loc() : ((!(months >= 18f)) ? "DevTime2".Loc() : "DevTime3".Loc(Mathf.RoundToInt(months / 12f))));
		return input.FontColor(Color.Lerp(new Color32(50, 50, 50, byte.MaxValue), Color.red, optimal.MapRange(1f, 1.5f, 0f, 1f, true)));
	}

	public static string GetArtistString(float devart)
	{
		return (int)(devart * 100f) + "%";
	}

	private void Start()
	{
		Pies[0].Colors = (Pies[1].Colors = HUD.GetThemeColors().ToList());
		GameSettings instance = GameSettings.Instance;
		instance.OnServersChanged = (EventHandler)Delegate.Combine(instance.OnServersChanged, (EventHandler)delegate
		{
			if (Window.Shown)
			{
				UpdateServerCombos();
			}
		});
	}

	private string NameWithStars(string name, float stars)
	{
		if (stars > 0f)
		{
			if (stars > 2f)
			{
				return name.LocTry() + " ★★★";
			}
			if (stars > 1f)
			{
				return name.LocTry() + " ★★";
			}
			return name.LocTry() + " ★";
		}
		return name.LocTry();
	}

	public void UpdatePieChart()
	{
		SoftwareType selectedType = SelectedType;
		Dictionary<string, float[]> specializationMonthsCodeArt = selectedType.GetSpecializationMonthsCodeArt(GetFeatures(), GetCategory(selectedType), GameSettings.Instance.MyCompany, GetTechLevelDict(false), GetOSs(), Framework, NewFrameworkToggle.isOn, SequelTo, true);
		bool flag = specializationMonthsCodeArt.SumSafe((KeyValuePair<string, float[]> x) => x.Value[0]) > 0f;
		bool num = specializationMonthsCodeArt.SumSafe((KeyValuePair<string, float[]> x) => x.Value[1]) > 0f;
		if (flag)
		{
			Pies[0].gameObject.SetActive(true);
			IEnumerable<KeyValuePair<string, float[]>> source = specializationMonthsCodeArt.Where((KeyValuePair<string, float[]> x) => x.Value[0] > 0f);
			Pies[0].Values = source.Select((KeyValuePair<string, float[]> x) => x.Value[0]).ToList();
			Pies[0].SetLabels(source.Select((KeyValuePair<string, float[]> x) => NameWithStars(x.Key, x.Value[2])));
			Pies[0].UpdateCachedPie();
		}
		else
		{
			Pies[0].gameObject.SetActive(false);
		}
		if (num)
		{
			Pies[1].gameObject.SetActive(true);
			IEnumerable<KeyValuePair<string, float[]>> source2 = specializationMonthsCodeArt.Where((KeyValuePair<string, float[]> x) => x.Value[1] > 0f);
			Pies[1].Values = source2.Select((KeyValuePair<string, float[]> x) => x.Value[1]).ToList();
			Pies[1].SetLabels(source2.Select((KeyValuePair<string, float[]> x) => NameWithStars(x.Key, x.Value[3])));
			Pies[1].UpdateCachedPie();
		}
		else
		{
			Pies[1].gameObject.SetActive(false);
		}
	}

	public void ToggleVisible()
	{
		if (Window.ToggleReturn())
		{
			OSList.Awake();
			UpdateOnShow();
			if (CurrentPage == 0)
			{
				TutorialSystem.Instance.StartTutorial("Simple design document");
			}
		}
	}

	public void PickLeadDesigner()
	{
		HUD.Instance.leadDesignWindow.Show(from x in DesignTeams.SelectNotNull(GameSettings.GetTeam).SelectMany((Team x) => from z in x.GetEmployeesDirect()
				select z.employee)
			where x.IsRole(Employee.RoleBit.Designer)
			select x, LeadDesigner.CurrentEmployee, SelectedType, delegate(Employee x)
		{
			if (x != null)
			{
				LeadDesigner.Init(x, SelectedType.Name);
				UpdateDescription();
			}
		});
	}

	public void ShowOverride(SoftwareType t, SoftwareCategory c)
	{
		OSList.Awake();
		Window.Show();
		UpdateOnShow();
		_swOverride = t;
		_swCatOverride = c;
		UpdateTypeRelatedCombos(false);
		LoadPage(5);
		UpdatePageTitle();
		PageChanged = true;
		PickBestLead(true);
	}

	public void ShowWith(string t, string c)
	{
		OSList.Awake();
		Window.Show();
		UpdateOnShow();
		TypeCombo.SelectedItem = t;
		CategoryCombo.SelectedItem = c;
	}

	public void ShowSequel(SoftwareProduct product)
	{
		while (product.HasSequel)
		{
			product = product.Sequel;
		}
		if (GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().Any((SoftwareWorkItem x) => x.SequelTo == product))
		{
			return;
		}
		OSList.Awake();
		Window.Show();
		UpdateOnShow();
		TypeCombo.SelectedItem = product.Type.Name;
		CategoryCombo.SelectedItem = product.Category.Name;
		ProductName.text = GameSettings.Instance.simulation.GenerateProductSequalName(product.Name);
		if (product.DesignerOwned && product.LeadDesigner.MyActor != null)
		{
			string team = product.LeadDesigner.MyActor.Team;
			if (team != null)
			{
				DesignTeams.Add(team);
				LeadDesigner.Init(product.LeadDesigner, product.Type.Name);
			}
		}
		SequelTo = product;
		SubscriptionToggle.isOn = product.SubscriptionBased;
		if (product.ForcedAddons != null)
		{
			AddOnProduct[] forcedAddons = product.ForcedAddons;
			foreach (AddOnProduct addon in forcedAddons)
			{
				SetAddon(addon);
			}
		}
	}

	private void SelectSequelFeatures()
	{
		if (SequelTo == null)
		{
			return;
		}
		HashSet<FeatureBase> hashSet = SequelTo.Features.ToHashSet();
		foreach (FeatureCard featureCard in FeatureCards)
		{
			if (!hashSet.Contains(featureCard.Feature))
			{
				continue;
			}
			if (!featureCard.Feature.Forced)
			{
				featureCard.MainToggle.isOn = true;
			}
			foreach (KeyValuePair<SubFeature, Toggle> subFeature in featureCard.SubFeatures)
			{
				if (hashSet.Contains(subFeature.Key))
				{
					subFeature.Value.isOn = true;
				}
			}
		}
	}

	private void ClearFeatures()
	{
		for (int i = 0; i < FeatureCards.Count; i++)
		{
			UnityEngine.Object.Destroy(FeatureCards[i].gameObject);
		}
		FeatureCards.Clear();
	}

	public Dictionary<string, TechLevel> GetTechLevelDict(bool all)
	{
		if (!all)
		{
			return FeatureCards.Where((FeatureCard x) => x.MainToggle.isOn).ToDictionary((FeatureCard x) => x.Feature.Spec, (FeatureCard x) => x.Tech);
		}
		return FeatureCards.ToDictionary((FeatureCard x) => x.Feature.Spec, (FeatureCard x) => x.Tech);
	}

	public List<FeatureBase> GetFeatures()
	{
		List<FeatureBase> list = new List<FeatureBase>();
		for (int i = 0; i < FeatureCards.Count; i++)
		{
			FeatureCard featureCard = FeatureCards[i];
			if (!featureCard.MainToggle.isOn)
			{
				continue;
			}
			list.Add(featureCard.Feature);
			foreach (KeyValuePair<SubFeature, Toggle> subFeature in featureCard.SubFeatures)
			{
				if (subFeature.Value.isOn)
				{
					list.Add(subFeature.Key);
				}
			}
		}
		return list;
	}

	public void FeatureToggle()
	{
		if (DisableFeatureUpdate)
		{
			return;
		}
		if (CurrentPage == 0)
		{
			AutoBalanceSubmarkets();
			PickNeedsAndOS();
		}
		UpdateSubmarketSatisfaction();
		UpdatePieChart();
		bool flag = false;
		HashSet<string> hashSet = new HashSet<string>();
		for (int i = 0; i < FeatureCards.Count; i++)
		{
			FeatureCard featureCard = FeatureCards[i];
			if (featureCard.MainToggle.isOn)
			{
				hashSet.AddRange(featureCard.Feature.Dependencies);
				if (featureCard.Feature.ServerRequirement > 0f)
				{
					flag = true;
				}
			}
			if (flag)
			{
				continue;
			}
			foreach (KeyValuePair<SubFeature, Toggle> subFeature in featureCard.SubFeatures)
			{
				if (subFeature.Key.ServerRequirement > 0f && subFeature.Value.isOn)
				{
					flag = true;
					break;
				}
			}
		}
		foreach (KeyValuePair<Button, GameObject> needLabel in NeedLabels)
		{
			if (hashSet.Contains(NeedsList[needLabel.Key].Key))
			{
				needLabel.Key.gameObject.SetActive(true);
				needLabel.Value.SetActive(true);
			}
			else
			{
				needLabel.Key.gameObject.SetActive(false);
				needLabel.Value.SetActive(false);
			}
		}
		UpdateNeeds();
		if (!priceHasBeenEdited)
		{
			SelectDefaultPrice();
		}
		ServerCombo.interactable = flag || IsDistribution();
	}

	private void UpdateNeeds()
	{
		bool active = NeedLabels.Any((KeyValuePair<Button, GameObject> x) => x.Value.activeSelf);
		NeedsRect.gameObject.SetActive(active);
		NeedsLabel.SetActive(active);
	}

	public void FixFeatures()
	{
		SoftwareType type = SelectedType;
		SoftwareCategory category = GetCategory(type);
		Dictionary<string, SoftwareProduct> needs = GetNeeds(true);
		SoftwareProduct[] oSs = GetOSs();
		Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(true);
		for (int i = 0; i < FeatureCards.Count; i++)
		{
			FeatureCard featureCard = FeatureCards[i];
			SpecFeature feat = featureCard.Feature;
			featureCard.UpdateTech(category, needs, oSs);
			bool flag = true;
			string dep = null;
			bool direct = false;
			if (!feat.IsUnlocked(techLevelDict, category))
			{
				flag = false;
				featureCard.MainTipper.Warning = "FeatureLimitYear".Loc(featureCard.Feature.GetUnlock(category));
			}
			else if (CurrentPage > 0 && type.OSSpecific && oSs.Length != 0 && MarketSimulation.Active.IsOSBacked(feat.Spec) && !oSs.All((SoftwareProduct x) => x.TechLevels.ContainsKey(feat.Spec)))
			{
				flag = false;
				featureCard.MainTipper.Warning = "FeatureLimitOS".Loc();
			}
			else if (type.OSSpecific && MarketSimulation.Active.IsOSBacked(feat.Spec) && MarketSimulation.Active.GetProductsWithMock(false).None((SoftwareProduct x) => x.Type.Name.Equals("Operating System") && type.SupportsOS(x.Category.Name) && x.TechLevels.ContainsKey(feat.Spec)))
			{
				flag = false;
				featureCard.MainTipper.Warning = "FeatureLimitMarketOS".Loc();
			}
			else if (!featureCard.CheckDeps(out dep, out direct, needs))
			{
				flag = false;
				featureCard.MainTipper.Warning = (direct ? "FeatureLimitDirectDependency".Loc(dep) : "FeatureLimitDependency".Loc(dep));
			}
			else
			{
				featureCard.MainTipper.Warning = null;
			}
			featureCard.MainToggle.interactable = !feat.IsForced(category.Name) && flag;
			if (featureCard.MainToggle.isOn && !flag)
			{
				featureCard.MainToggle.isOn = false;
			}
		}
		if (category.Hardware)
		{
			Manufacturing.Initialize(category, GetFeatures(), null, null, null);
		}
		FeatureToggle();
		UpdateForcedAddonFeatures();
	}

	public void AutoBalanceSubmarkets(bool withSequel = true)
	{
		if (withSequel && SequelTo != null)
		{
			SubmarketSlider.ApplyRatio((float)SequelTo.Submarkets[0], (float)SequelTo.Submarkets[1], (float)SequelTo.Submarkets[2]);
			return;
		}
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(false);
		List<FeatureBase> features = GetFeatures();
		double[] array = new double[3];
		for (int i = 0; i < features.Count; i++)
		{
			features[i].GetSubAdd(category, techLevelDict[features[i].Spec], array, true);
		}
		if (array[0] + array[1] + array[2] == 0.0)
		{
			SubmarketSlider.ApplyRatio(1f, 1f, 1f);
		}
		else
		{
			SubmarketSlider.ApplyRatio((float)array[0], (float)array[1], (float)array[2]);
		}
	}

	public void UpdateSubmarketSatisfaction()
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(false);
		List<FeatureBase> features = GetFeatures();
		double[] array = new double[3];
		float num = (float)SoftwareType.BigProjectEffect(selectedType.GetOptimalDevTime(category), 1.0, 1.0, selectedType.SimpleDevTime(features, category, techLevelDict));
		if (num <= 0f)
		{
			num = 1f;
		}
		for (int i = 0; i < features.Count; i++)
		{
			features[i].GetSubAdd(category, techLevelDict[features[i].Spec], array, true);
		}
		for (int j = 0; j < 3; j++)
		{
			float value = SubmarketSlider.GetValue(j);
			SubmarketSats[j].IndValue = Mathf.Clamp01(value / num);
			SubmarketSats[j].Value = (float)array[j];
		}
		UpdateDescription();
	}

	public double[] GetSubmarkets()
	{
		return new double[3] { SubmarketSlider.A, SubmarketSlider.B, SubmarketSlider.C };
	}

	public void ChangeInHouse()
	{
		if (HouseToggle.isOn)
		{
			CheckWithPublisher(HouseToggle);
		}
	}

	public void ChangeSoftwareOrCategory(bool updateCat)
	{
		if (_changeSWType)
		{
			CheckWithPublisher(delegate
			{
				UpdateTypeRelatedCombos(updateCat);
			}, delegate
			{
				_changeSWType = false;
				TypeCombo.SelectedItem = _lastSWType;
				CategoryCombo.SelectedItem = _lastSWCat;
				_changeSWType = true;
			});
		}
	}

	public void EditHardwareDesign()
	{
		SoftwareCategory category = GetCategory();
		HardwareDesign bestDesign = category.Manufacturing.GetBestDesign(SDateTime.Now().Year);
		if (bestDesign != null)
		{
			HUD.Instance.hardwareEditorWindow.Show(bestDesign, _sequelTo, null, delegate(byte[] x)
			{
				_hardwareDesign = x;
			}, _hardwareDesign, category, Window, GetFeatures());
		}
	}

	public void UpdateTypeRelatedCombos(bool updateCat)
	{
		for (int i = 0; i < DistributionDisable.Length; i++)
		{
			DistributionDisable[i].SetActive(!IsDistribution());
		}
		_noSubUpdate = true;
		SubsidiaryCombo.Selected = 0;
		_noSubUpdate = false;
		SoftwareType swType = SelectedType;
		_lastSWType = swType.Name;
		if (updateCat)
		{
			UnityEvent onSelectedChanged = CategoryCombo.OnSelectedChanged;
			CategoryCombo.OnSelectedChanged = null;
			CategoryCombo.Software = swType.Name;
			Dictionary<string, string> dictionary = swType.Categories.Where((KeyValuePair<string, SoftwareCategory> x) => !x.Value.Hidden && x.Value.IsUnlocked(TimeOfDay.Instance.Year)).ToDictionary((KeyValuePair<string, SoftwareCategory> x) => x.Key, (KeyValuePair<string, SoftwareCategory> x) => x.Value.Description);
			CategoryCombo.UpdateContent(dictionary.Keys, dictionary.Values);
			CategoryCombo.Selected = 0;
			CategoryCombo.OnSelectedChanged = onSelectedChanged;
			HouseToggle.isOn = false;
			SubmarketSlider.ApplyRatio(1f, 1f, 1f);
		}
		_lastSWCat = CategoryCombo.SelectedItemString;
		SubscriptionToggle.gameObject.SetActive(!IsDistribution() && !GetCategory(swType).Hardware);
		SubscriptionToggle.isOn = false;
		HouseToggle.gameObject.SetActive(swType.InHouse);
		ManufactureView.SetActive(false);
		UpdatePageTitle();
		if (updateCat)
		{
			foreach (KeyValuePair<Button, GameObject> needLabel in NeedLabels)
			{
				UnityEngine.Object.Destroy(needLabel.Key.gameObject);
				UnityEngine.Object.Destroy(needLabel.Value);
			}
			NeedsList.Clear();
			NeedLabels.Clear();
			string[] needs = swType.GetNeeds(null);
			foreach (string text in needs)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(LabelPrefab);
				gameObject.GetComponent<Text>().text = text.LocSW();
				gameObject.transform.SetParent(NeedsSubPanel.transform, false);
				GameObject button = UnityEngine.Object.Instantiate(ButtonPrefab);
				button.GetComponentInChildren<Text>().text = "ToolNotChosen".Loc();
				button.transform.SetParent(NeedsSubPanel.transform, false);
				Button guiButton = button.GetComponent<Button>();
				NeedLabels.Add(guiButton, gameObject);
				NeedsList.Add(guiButton, new KeyValuePair<string, SoftwareProduct>(text, null));
				string localType = text;
				guiButton.onClick.AddListener(delegate
				{
					GameObject gameObject2 = button;
					Text localText = gameObject2.GetComponentInChildren<Text>();
					NeedsList[guiButton] = new KeyValuePair<string, SoftwareProduct>(localType, null);
					localText.text = "ToolNotChosen".Loc();
					FixFeatures();
					UpdateDescription();
					UpdateOSList();
					ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
					productWindow.SetFilters(true, false);
					productWindow.Show(true, "ProductChooseGeneric".Loc(localType), delegate(SoftwareProduct[] x)
					{
						if (x.Length != 0)
						{
							NeedsList[guiButton] = new KeyValuePair<string, SoftwareProduct>(localType, x[0]);
							localText.text = x[0].Name;
							FixFeatures();
							UpdateDescription();
							UpdateOSList();
						}
					}, false, false, true);
					productWindow.CheckSupport(GetTechLevelDict(false), swType.GetSpecsFromNeed(localType, GetFeatures()));
					productWindow.WithMock = Subsidiairy == null;
					productWindow.SetType(localType);
				});
			}
			UpdateNeeds();
		}
		if (updateCat)
		{
			OSPanel.SetActive(swType.OSSpecific);
			OSLabel.SetActive(swType.OSSpecific);
			OSList.Items.Clear();
		}
		SoftwareCategory category = GetCategory(swType);
		ManufactureButton.SetActive(category.Hardware);
		HardwareDesignButton.SetActive(category.Hardware && category.Manufacturing.GetValidDesigns(SDateTime.Now().Year).Any());
		GenerateFeatures();
		UpdateForcedAddons(swType, category);
		UpdateDescription();
		NewFrameworkToggle.isOn = false;
		UseFrameworkToggle.isOn = false;
		_hardwareDesign = null;
		SequelTo = null;
		if (!priceHasBeenEdited || updateCat)
		{
			SelectDefaultPrice();
		}
		for (int num2 = 0; num2 < Submarkets.Length; num2++)
		{
			Submarkets[num2].text = swType.SubMarkets[num2 % 3].LocTry();
		}
		List<SimulatedCompany> list = new List<SimulatedCompany> { null };
		if (!IsDistribution())
		{
			foreach (uint subsidiary in GameSettings.Instance.MyCompany.Subsidiaries)
			{
				SimulatedCompany simulatedCompany = GameSettings.Instance.simulation.GetCompany(subsidiary) as SimulatedCompany;
				if (simulatedCompany != null && simulatedCompany.CompatibleSoftware(TypeCombo.SelectedItemString, CategoryCombo.SelectedItemString))
				{
					list.Add(simulatedCompany);
				}
			}
		}
		SubsidiaryCombo.UpdateContent(list);
		SubsidiaryCombo.Selected = 0;
		bool active = list.Count > 1;
		SubsidiaryCombo.gameObject.SetActive(active);
		PickBestLead(true);
		if (updateCat)
		{
			return;
		}
		SoftwareProduct[] oSs = GetOSs();
		List<FeatureBase> features = GetFeatures();
		foreach (SoftwareProduct softwareProduct in oSs)
		{
			if (!SoftwareType.OSDependenciesMet(softwareProduct, features))
			{
				OSList.Items.Remove(softwareProduct);
			}
		}
	}

	private void UpdateForcedAddons(SoftwareType swType, SoftwareCategory cat)
	{
		foreach (KeyValuePair<Button, GameObject> forcedAddLabel in ForcedAddLabels)
		{
			UnityEngine.Object.Destroy(forcedAddLabel.Key.gameObject);
			UnityEngine.Object.Destroy(forcedAddLabel.Value);
		}
		ForcedAddList.Clear();
		ForcedAddLabels.Clear();
		foreach (SoftwareAddOn item in from x in swType.GetValidAddons(cat, GetTechLevelDict(false), GetFeatures(), SDateTime.Now())
			where x.Forced.HasValue
			select x)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(LabelPrefab);
			gameObject.GetComponent<Text>().text = item.GetPrettyName();
			gameObject.transform.SetParent(ForcedAddRect, false);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(ButtonPrefab);
			gameObject2.GetComponentInChildren<Text>().text = "None".Loc();
			gameObject2.transform.SetParent(ForcedAddRect.transform, false);
			Button guiButton = gameObject2.GetComponent<Button>();
			ForcedAddLabels.Add(guiButton, gameObject);
			ForcedAddList.Add(guiButton, new KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>(item, null));
			SoftwareAddOn localType = item;
			Text localText = gameObject2.GetComponentInChildren<Text>();
			guiButton.onClick.AddListener(delegate
			{
				float publisher = ((_publisher != null) ? _publisher.Royalty : 0f);
				HUD.Instance.addonDesignWindow.Show(ProductName.text, localType, cat, SequelTo, GetFeatures().ToArray(), GetTechLevelDict(false), GetNeeds(), GetSubmarkets(), ForcedAddList[guiButton].Value, publisher, delegate(AddonDesignWindow.AddonDesign x)
				{
					ForcedAddList[guiButton] = new KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>(null, x);
					localText.text = x.Name;
				});
			});
		}
		bool active = ForcedAddList.Count > 0;
		ForcedAddRect.gameObject.SetActive(active);
		ForcedAddLabel.SetActive(active);
	}

	public void SetAddon(AddOnProduct p)
	{
		Button button = ForcedAddList.FirstOrDefaultOf((KeyValuePair<Button, KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>> x) => x.Value.Key == p.Type, (KeyValuePair<Button, KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>> x) => x.Key);
		if (button != null)
		{
			Text componentInChildren = button.GetComponentInChildren<Text>();
			string text = MarketSimulation.Active.GenerateAddonName(null, _sequelTo, p.Type, p.Forced, Utilities.RNG);
			SoftwareAddOn type = p.Type;
			float price = p.Price;
			AddOnFeature[] features = p.Features.ToArray();
			uint[] featureFactors = p.FeatureFactors.ToArray();
			Dictionary<string, SoftwareProduct> tools = new Dictionary<string, SoftwareProduct>();
			HashSet<string> designTeams = DesignTeams.ToHashSet();
			HashSet<string> devTeams = DevelopmentTeams.ToHashSet();
			object scm;
			if (SCMCombo.Selected <= 0)
			{
				scm = null;
			}
			else
			{
				ServerGroup selected = SCMCombo.GetSelected<ServerGroup>();
				scm = ((selected != null) ? selected.Name : null);
			}
			AddonDesignWindow.AddonDesign addonDesign = new AddonDesignWindow.AddonDesign(text, type, price, features, featureFactors, tools, designTeams, devTeams, null, (string)scm);
			componentInChildren.text = addonDesign.Name;
			ForcedAddList[button] = new KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>(p.Type, addonDesign);
		}
	}

	private void GenerateFeatures()
	{
		ClearFeatures();
		SoftwareType selectedType = SelectedType;
		SoftwareCategory cat = GetCategory(selectedType);
		foreach (SpecFeature item in from x in selectedType.Features.Values.OfType<SpecFeature>()
			where x.IsCompatible(cat.Name)
			select x)
		{
			SpecFeature spec1 = item;
			FeatureCard featureCard = UnityEngine.Object.Instantiate(FeatureCardPrefab);
			featureCard.transform.SetParent(FeaturePanel, false);
			FeatureCards.Add(featureCard);
			featureCard.Init(item, from x in selectedType.Features.Values.OfType<SubFeature>()
				where x.IsCompatible(cat.Name) && x.Spec.Equals(spec1.Spec)
				select x, cat, this);
		}
		FeatureScroll.normalizedPosition = Vector2.up;
		LayoutRebuilder.ForceRebuildLayoutImmediate(FeatureScroll.GetComponent<RectTransform>());
		FixFeatures();
	}

	public void CheckWithPublisher(Toggle t, Action yes = null)
	{
		CheckWithPublisher(yes, delegate
		{
			t.SetIsOnNoEvents(!t.isOn);
		});
	}

	public void CheckWithPublisher(Action yes = null, Action no = null)
	{
		if (_checkingWithPublisher)
		{
			return;
		}
		if (_publisher != null)
		{
			_checkingWithPublisher = true;
			WindowManager.Instance.ShowMessageBox("CancelPublishingWarning".Loc(), true, DialogWindow.DialogType.Warning, delegate
			{
				SetPublishingDeal(null);
				if (yes != null)
				{
					yes();
				}
				_checkingWithPublisher = false;
			}, null, delegate
			{
				if (no != null)
				{
					no();
				}
				_checkingWithPublisher = false;
			});
		}
		else if (yes != null)
		{
			yes();
		}
	}

	public void SubsidiaryChange()
	{
		if (_noSubUpdate)
		{
			return;
		}
		if (Subsidiairy != null)
		{
			CheckWithPublisher(ContinueSubChange, delegate
			{
				_noSubUpdate = true;
				SubsidiaryCombo.Selected = 0;
				_noSubUpdate = false;
			});
		}
		else
		{
			ContinueSubChange();
		}
	}

	private void ContinueSubChange()
	{
		Company company = Subsidiairy ?? GameSettings.Instance.MyCompany;
		if (_sequelTo != null && !company.CanMakeSequel(_sequelTo))
		{
			SequelTo = null;
		}
		if (Subsidiairy != null)
		{
			bool flag = false;
			foreach (object item in OSList.Items.ToList())
			{
				SoftwareProduct softwareProduct = item as SoftwareProduct;
				if (softwareProduct != null && softwareProduct.IsMock)
				{
					OSList.Items.Remove(item);
					flag = true;
				}
			}
			foreach (KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> item2 in NeedsList.Where((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Key != null && x.Key.gameObject != null).ToList())
			{
				SoftwareProduct value = item2.Value.Value;
				if (value == null || value.IsMock)
				{
					NeedsList[item2.Key] = new KeyValuePair<string, SoftwareProduct>(item2.Value.Key, null);
					item2.Key.GetComponentInChildren<Text>().text = "ToolNotChosen".Loc();
					flag = true;
				}
			}
			if (flag)
			{
				FixFeatures();
				UpdateDescription();
				UpdateOSList();
			}
		}
		ProjManButton.SetActive(Subsidiairy == null && !IsDistribution());
		UpdateDescription();
	}

	private void UpdateOSList()
	{
	}

	private float GetLicenseCost(IList<FeatureBase> features, int devEmps)
	{
		Company c = Subsidiairy ?? GameSettings.Instance.MyCompany;
		float num = 0f;
		foreach (KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> needs in NeedsList)
		{
			SoftwareProduct value = needs.Value.Value;
			if (needs.Key != null && needs.Key.gameObject.activeSelf && value != null && value.HasToPay(c))
			{
				num += value.GetLicenseCost(true) * (float)devEmps;
			}
		}
		return num;
	}

	private float GetOSCost()
	{
		Company c = Subsidiairy ?? GameSettings.Instance.MyCompany;
		float num = 0f;
		SoftwareProduct[] oSs = GetOSs();
		int num2 = DevelopmentTeams.SelectNotNull(GameSettings.GetTeam).SumSafe((Team x) => x.GetEmployeesDirect().Count((Actor z) => z.employee.IsRole(Employee.RoleBit.Programmer | Employee.RoleBit.Artist)));
		foreach (SoftwareProduct softwareProduct in oSs)
		{
			if (softwareProduct.HasToPay(c))
			{
				num += softwareProduct.Price * (float)num2;
			}
		}
		return num;
	}

	private string EmpDiffColor(int amount, int recommended)
	{
		if (recommended > 0 && Mathf.Abs(amount - recommended) > 3 && Mathf.Abs((float)amount / (float)recommended - 1f) >= 0.5f)
		{
			return amount.ToString().FontColor(Color.red) + "/" + recommended;
		}
		return amount + "/" + recommended;
	}

	private void UpdateDescription()
	{
		UpdateTeamText();
		_valueList.Clear();
		_varList.Clear();
		_tipList.Clear();
		SoftwareType selectedType = SelectedType;
		SDateTime time = SDateTime.Now();
		List<FeatureBase> features = GetFeatures();
		SoftwareCategory catt = GetCategory(selectedType);
		SoftwareProduct[] oSs = GetOSs();
		double num = (IsDistribution() ? ((double)MarketSimulation.Population * (1.0 - MarketSimulation.GetPhysicalVsDigital(time)) * 0.30000001192092896) : ((double)selectedType.GetReach(catt, oSs)));
		Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(false);
		float num2 = selectedType.DevTime(features, catt, GameSettings.Instance.MyCompany, techLevelDict, oSs, Framework, NewFrameworkToggle.isOn, SequelTo);
		float num3 = num2;
		float num4 = SoftwareType.CodeArtRatio(features);
		float num5 = num3 * num4;
		if (selectedType.OSSpecific)
		{
			int num6 = Mathf.Max(0, oSs.Length - 1);
			num2 += (float)num6;
			num5 += (float)num6;
		}
		int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(num2);
		int num7 = optimalEmployeeCount[1];
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		if ((DesignTeams.Count == 0 && DevelopmentTeams.Count == 0) || Subsidiairy != null)
		{
			num2 = GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], num2, num4);
		}
		else
		{
			foreach (string designTeam in DesignTeams)
			{
				Team team = GameSettings.GetTeam(designTeam);
				if (team != null)
				{
					num8 += team.GetEmployeesDirect().Count((Actor x) => !x.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && x.employee.IsRole(Employee.RoleBit.Designer));
				}
			}
			foreach (string developmentTeam in DevelopmentTeams)
			{
				Team team2 = GameSettings.GetTeam(developmentTeam);
				if (team2 != null)
				{
					num9 += team2.GetEmployeesDirect().Count((Actor x) => !x.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && x.employee.IsRole(Employee.RoleBit.Programmer));
					num10 += team2.GetEmployeesDirect().Count((Actor x) => !x.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && x.employee.IsRole(Employee.RoleBit.Artist));
				}
			}
			num7 = num9 + num10;
			num2 = GameData.ProjectDevTime((num8 == 0) ? optimalEmployeeCount[0] : num8, (num7 == 0) ? optimalEmployeeCount[1] : num7, num2, num4);
		}
		float optimal = features.SumSafe((FeatureBase x) => x.GetDevTime(catt, GameSettings.Instance.MyCompany, null, null, null, false)) / selectedType.GetOptimalDevTime(catt);
		_varList.Add("ETA".Loc());
		_valueList.Add(GetTimeString(num2, num3, optimal));
		_tipList.Add(null);
		if (techLevelDict.Values.Any((TechLevel x) => GameSettings.Instance.MyCompany.GetLatestResearch(x.Spec, -1) >= x.Year) || SequelTo != null || Framework != null)
		{
			float num11 = 0f;
			float num12 = 0f;
			for (int num13 = 0; num13 < features.Count; num13++)
			{
				FeatureBase featureBase = features[num13];
				num11 += featureBase.GetDevTime(catt, GameSettings.Instance.MyCompany, techLevelDict, SequelTo, Framework, false);
				num12 += featureBase.GetDevTime(catt, null, techLevelDict, null, null, false);
			}
			num11 = (num12 - num11) / num12;
			_varList.Add("SpeedBoost".Loc());
			_valueList.Add(num11.ToPercent());
			_tipList.Add("SpeedBoostTip");
		}
		_varList.Add("Recommendeddesigners".Loc());
		_valueList.Add(EmpDiffColor(num8, Mathf.CeilToInt(optimalEmployeeCount[0])));
		_tipList.Add("EmployeeCountHint");
		_varList.Add("Recommendedprogrammers".Loc());
		_valueList.Add(EmpDiffColor(num9, Mathf.CeilToInt((float)optimalEmployeeCount[1] * num4)));
		_tipList.Add("EmployeeCountHint");
		_varList.Add("Recommendedartists".Loc());
		_valueList.Add(EmpDiffColor(num10, Mathf.CeilToInt((float)optimalEmployeeCount[1] * (1f - num4))));
		_tipList.Add("EmployeeCountHint");
		if (LeadDesigner.CurrentEmployee != null)
		{
			_varList.Add("EstCreativity".Loc());
			Employee currentEmployee = LeadDesigner.CurrentEmployee;
			float[] creativityRange = currentEmployee.GetCreativityRange();
			float num14 = currentEmployee.GetWeightedLeadSpecFactor(selectedType) * Mathf.Min(1f, currentEmployee.Inspiration);
			if (creativityRange[0] == creativityRange[1])
			{
				_valueList.Add((creativityRange[0] * num14).ToPercent(false));
			}
			else
			{
				_valueList.Add((creativityRange[0] * num14).ToPercent(false) + " - " + (creativityRange[1] * num14).ToPercent(false));
			}
			_tipList.Add("CreativityProductTip");
		}
		if (catt.Hardware)
		{
			float price;
			int mask;
			int inputMask;
			catt.Manufacturing.GetProcessInfo(features, null, out price, out mask, out inputMask);
			_varList.Add("ManufacturingCost".Loc());
			_valueList.Add(price.Currency());
			_tipList.Add("ManufacturingCostTip");
		}
		if (NeedsList.Any((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Key != null && x.Key.gameObject.activeSelf))
		{
			_varList.Add("Licensecosts".Loc());
			_valueList.Add(GetLicenseCost(features, num7).Currency());
			_tipList.Add("LicenseCostTip");
		}
		if (selectedType.OSSpecific)
		{
			_varList.Add("OSSeats".Loc());
			_valueList.Add(GetOSCost().Currency());
			_tipList.Add("OSSeatTip");
		}
		if (!IsDistribution())
		{
			_varList.Add("Royalties".Loc());
			_valueList.Add((techLevelDict.Values.Where((TechLevel x) => x.HasToPay(GameSettings.Instance.MyCompany)).SumSafe((TechLevel x) => x.Royalty) + Framework.Royalty(GameSettings.Instance.MyCompany) + ((_publisher != null) ? _publisher.Royalty : 0f) + ((LeadDesigner.CurrentEmployee != null && LeadDesigner.CurrentEmployee.HasDemanded(LeadDesignDemands.Demand.Royalties)) ? 0.05f : 0f)).ToPercent());
			_tipList.Add("RoyaltyTip");
			_varList.Add("Physicalstorecut".Loc());
			_valueList.Add(((SubscriptionToggle.isOn ? (Price * MarketSimulation.PhysicalSubscriptionCutFactor) : Price) * MarketSimulation.DistributionStandardCut).Currency());
			_tipList.Add("PhysicalstorecutDesc");
		}
		float serverRequirement = SoftwareType.GetServerRequirement(features, IsDistribution() ? 0.05f : 0f);
		if (serverRequirement > 0f)
		{
			_varList.Add("Appxbandwidth".Loc());
			_valueList.Add(((float)((double)serverRequirement * num * catt.GetRetentionFact() * 0.5)).BandwidthFactor(time).Bandwidth());
			_tipList.Add("AppxBandwidthTip");
		}
		if (!IsDistribution())
		{
			_varList.Add("Expectedinterest".Loc());
			double bigProjectFactor = SoftwareType.BigProjectEffect(selectedType.GetOptimalDevTime(catt), 1.0, 1.0, selectedType.SimpleDevTime(features, catt, techLevelDict));
			double num15 = catt.PerceivedMarketValue(features, techLevelDict, GetSubmarkets(), bigProjectFactor);
			_valueList.Add((Utilities.RoundToInt(num15 * 100.0) + "%").FontColor(InterestGradient.Evaluate((float)num15)));
			_tipList.Add("ProductInterestTip");
			_varList.Add("WastedInterest".Loc());
			num15 = catt.PerceivedMarketValue(features, techLevelDict, GetSubmarkets(), bigProjectFactor, true);
			_valueList.Add((Utilities.RoundToInt(num15 * 100.0) + "%").FontColor(Color.Lerp(new Color32(50, 50, 50, byte.MaxValue), Color.red, (float)num15.MapRange(0.10000000149011612, 0.5, 0.0, 1.0, true))));
			_tipList.Add("WastedInterestTip");
			_varList.Add("Consumerreach".Loc());
			_valueList.Add(num.ToString("N0"));
			_tipList.Add("ConsumerReachTip");
		}
		else
		{
			_varList.Add("Expectedinterest".Loc());
			double num16 = (double)Mathf.Clamp01(features.SumSafe((FeatureBase x) => x.DevTime) / MarketSimulation.Active.GetDistributionMaxDevTime()) * SoftwareType.CalculateRelevancy(features, techLevelDict, catt, null);
			_valueList.Add((Utilities.RoundToInt(num16 * 100.0) + "%").FontColor(InterestGradient.Evaluate((float)num16)));
			_tipList.Add("ProductInterestTip");
		}
		if (_publisher != null)
		{
			_varList.Add("Deadline".Loc());
			_valueList.Add((SDateTime.Now() + _publisher.Months).ToCompactString());
			_tipList.Add(null);
		}
		foreach (SoftwareAddOn validAddon in selectedType.GetValidAddons(catt, techLevelDict, features, time))
		{
			_varList.Add("AddonTargeting".Loc(validAddon.GetPrettyName()));
			double targeting = validAddon.GetTargeting(catt, features, GetSubmarkets(), techLevelDict);
			_valueList.Add((Utilities.RoundToInt(targeting * 100.0) + "%").FontColor(Color.Lerp(Color.red, new Color32(50, 50, 50, byte.MaxValue), (float)targeting)));
			_tipList.Add("AddonTargetingHint");
		}
		DescriptionSh.SetData(_varList.ToArray(), _valueList.ToArray(), false);
		DescriptionSh.ToolTips = _tipList.ToArray();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.Add("Specialization".Loc().FontBold());
		list2.Add("Limitedby".Loc().FontBold());
		Dictionary<string, SoftwareProduct> needs = GetNeeds();
		if (needs.Count > 0)
		{
			for (int num17 = 0; num17 < FeatureCards.Count; num17++)
			{
				FeatureCard featureCard = FeatureCards[num17];
				if (featureCard.MainToggle.isOn)
				{
					string lim = null;
					TechLevel latestTech = GameSettings.Instance.simulation.GetLatestTech(featureCard.Feature.Spec, SDateTime.Now(), catt, GameSettings.Instance.MyCompany);
					TechLevel techLimit = catt.GetTechLimit(featureCard.Feature, needs, null, ref lim, latestTech);
					if (techLimit != null && techLimit.Year < latestTech.Year)
					{
						list.Add(featureCard.Feature.Spec.LocTry() + " (" + techLimit.ActualYear + ")");
						list2.Add(lim);
					}
				}
			}
		}
		LimitSheet.SetData(list.ToArray(), list2.ToArray());
		UpdateMarketExtraPoints();
	}

	private void OnEnable()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			UpdateServerCombos();
		}
	}

	private void UpdateOnShow()
	{
		_swOverride = null;
		_swCatOverride = null;
		SetPublishingDeal(null);
		ProductName.text = DefaultName.Loc();
		SkipGeneration.isOn = GameSettings.Instance.SkipDesignGeneration;
		LoadPage(SkipGeneration.isOn ? 1 : 0);
		UpdatePageTitle();
		PageChanged = SkipGeneration.isOn;
		Dictionary<string, string> dictionary = MarketSimulation.Active.SoftwareTypes.Where((KeyValuePair<string, SoftwareType> x) => !x.Value.OneClient && x.Value.IsUnlocked(TimeOfDay.Instance.Year)).ToDictionary((KeyValuePair<string, SoftwareType> x) => x.Key, (KeyValuePair<string, SoftwareType> x) => x.Value.Description);
		TypeCombo.UpdateContent(dictionary.Keys, dictionary.Values);
		TypeCombo.UpdateSelection(0);
		TypeCombo.UpdateSelection(0);
		OSList.Items.Clear();
		DesignTeams.Clear();
		DesignTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Design"));
		PickBestLead(true);
		DevelopmentTeams.Clear();
		DevelopmentTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Development"));
		RefreshTeamSpecs();
		UpdateTeamText();
		UpdateTypeRelatedCombos(true);
		UpdatePieChart();
		HouseToggle.isOn = false;
		SequelTo = null;
		UpdateServerCombos();
		ServerCombo.Selected = 0;
		Framework = null;
		NewFramework.text = "";
		NewFrameworkToggle.isOn = false;
		UseFrameworkToggle.isOn = false;
		_hardwareDesign = null;
	}

	private void UpdateServerCombos()
	{
		ServerCombo.UpdateContent(GameSettings.Instance.GetAllServerGroups());
		ServerGroup server;
		if (GameSettings.GetPrefServer("DesignResult", out server))
		{
			ServerCombo.SelectedItem = server;
		}
		SCMCombo.UpdateContent(GameSettings.Instance.GetAllServerGroups(true));
		if (GameSettings.GetPrefServer("DesignSCM", out server))
		{
			SCMCombo.SelectedItem = server;
		}
	}

	public void UpdateGenerationSkip(bool value)
	{
		GameSettings.Instance.SkipDesignGeneration = value;
	}

	private bool CheckValid()
	{
		if ((from x in GameSettings.Instance.simulation.GetAllProducts(true)
			select x.Name).Contains(ProductName.text) || (from x in GameSettings.Instance.simulation.Companies.Values.SelectMany((SimulatedCompany x) => x.Releases)
			select x.Name).Contains(ProductName.text) || (from x in GameSettings.Instance.simulation.Companies.Values.SelectMany((SimulatedCompany x) => x.ProjectQueue)
			select x.Name).Contains(ProductName.text) || GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().Any((SoftwareWorkItem x) => !x.AddOn && x.SoftwareName.Equals(ProductName.text)))
		{
			WindowManager.Instance.ShowMessageBox("DesignProductNameError".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
			{
				TutorialSystem.Instance.AddRing(ProductName.GetComponent<RectTransform>().ToScreenSpace().center, 256, true);
			}));
			if (CurrentPage > 1)
			{
				PageChanged = true;
				LoadPage(1);
				UpdatePageTitle();
			}
			return false;
		}
		string fName = NewFramework.text;
		if (NewFrameworkToggle.isOn && (string.IsNullOrEmpty(fName.Trim()) || GameSettings.Instance.simulation.Frameworks.Any((SoftwareFramework y) => y.Name.Equals(fName))))
		{
			WindowManager.Instance.ShowMessageBox("FrameworkNameIssue".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
			{
				TutorialSystem.Instance.AddRing(NewFramework.GetComponent<RectTransform>().ToScreenSpace().center, 256, true);
			}));
			if (CurrentPage != 1)
			{
				PageChanged = true;
				LoadPage(1);
				UpdatePageTitle();
			}
			return false;
		}
		if (SelectedType.OSSpecific && OSList.Items.Count == 0)
		{
			WindowManager.Instance.ShowMessageBox("ProductOSError".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
			{
				TutorialSystem.Instance.AddRing(OSList.rectTransform.ToScreenSpace().center, 256, true);
			}));
			if (CurrentPage != 2)
			{
				PageChanged = true;
				LoadPage(2);
				UpdatePageTitle();
			}
			return false;
		}
		foreach (SoftwareProduct item in from x in NeedsList
			where x.Key.gameObject.activeSelf
			select x.Value.Value)
		{
			if (item == null)
			{
				WindowManager.Instance.ShowMessageBox("ProductNeedError".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
				{
					TutorialSystem.Instance.AddRing(NeedsRect.ToScreenSpace().center, 256, true);
				}));
				if (CurrentPage != 2)
				{
					PageChanged = true;
					LoadPage(2);
					UpdatePageTitle();
				}
				return false;
			}
		}
		foreach (KeyValuePair<Button, KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign>> forcedAdd in ForcedAddList)
		{
			if (forcedAdd.Value.Value == null || !CheckAddonValid(forcedAdd.Value.Value))
			{
				WindowManager.Instance.ShowMessageBox("ForcedAddonError".LocColor(forcedAdd.Value.Key), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
				{
					TutorialSystem.Instance.AddRing(ForcedAddRect.ToScreenSpace().center, 256, true);
				}));
				if (CurrentPage != 2)
				{
					PageChanged = true;
					LoadPage(2);
					UpdatePageTitle();
				}
				return false;
			}
		}
		if (SequelTo != null && SequelTo.DesignerOwned && (SequelTo.LeadDesigner.MyActor == null || LeadDesigner.CurrentEmployee != SequelTo.LeadDesigner))
		{
			Utilities.LeadDesignerIP(SequelTo);
			return false;
		}
		return true;
	}

	private bool CheckAddonValid(AddonDesignWindow.AddonDesign add)
	{
		if (add.Features.Length == 0)
		{
			return false;
		}
		if (add.Type.GetTools(add.Features).Any((string x) => !add.Tools.ContainsKey(x)))
		{
			return false;
		}
		return true;
	}

	public Dictionary<string, SoftwareProduct> GetNeeds(bool all = false)
	{
		return NeedsList.Where((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Key != null && x.Key.gameObject != null && (all || x.Key.gameObject.activeSelf)).ToDictionary((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Key, (KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Value);
	}

	public Dictionary<string, SoftwareProduct> GetNeedProducts()
	{
		return NeedsList.Where((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Value != null && x.Key != null && x.Key.gameObject != null && x.Key.gameObject.activeSelf).ToDictionary((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Key, (KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Value);
	}

	public void RefreshTeamSpecs()
	{
		List<Team> teams = DesignTeams.SelectNotNull(GameSettings.GetTeam).ToList();
		List<Team> teams2 = DevelopmentTeams.SelectNotNull(GameSettings.GetTeam).ToList();
		Dictionary<string, int> orAdd = _teamSpecs.GetOrAdd(Employee.EmployeeRole.Designer, (Employee.EmployeeRole x) => new Dictionary<string, int>());
		orAdd.Clear();
		AddSpecs(teams, Employee.EmployeeRole.Designer, orAdd);
		orAdd = _teamSpecs.GetOrAdd(Employee.EmployeeRole.Programmer, (Employee.EmployeeRole x) => new Dictionary<string, int>());
		orAdd.Clear();
		AddSpecs(teams2, Employee.EmployeeRole.Programmer, orAdd);
		orAdd = _teamSpecs.GetOrAdd(Employee.EmployeeRole.Artist, (Employee.EmployeeRole x) => new Dictionary<string, int>());
		orAdd.Clear();
		AddSpecs(teams2, Employee.EmployeeRole.Artist, orAdd);
	}

	private static void AddSpecs(List<Team> teams, Employee.EmployeeRole role, Dictionary<string, int> specs)
	{
		for (int i = 0; i < teams.Count; i++)
		{
			List<Actor> employeesDirect = teams[i].GetEmployeesDirect();
			for (int j = 0; j < employeesDirect.Count; j++)
			{
				Actor actor = employeesDirect[j];
				if (actor.employee.IsRole(role, true) && !actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
				{
					string[] allSpecializations = GameSettings.Instance.GetAllSpecializations(role);
					foreach (string text in allSpecializations)
					{
						specs.AddTo(text, actor.employee.GetSpecialization(role, text), Mathf.Max);
					}
				}
			}
		}
	}

	public SoftwareProduct[] GetOSs()
	{
		return OSList.Items.OfType<SoftwareProduct>().ToArray();
	}

	public void ToggleFramework(bool create)
	{
		CheckWithPublisher(create ? NewFrameworkToggle : UseFrameworkToggle, delegate
		{
			Framework = null;
			if (NewFrameworkToggle.isOn)
			{
				ExistingFrameworkButton.gameObject.SetActive(false);
				NewFramework.gameObject.SetActive(true);
				NewFrameworkNameLabel.SetActive(true);
				NewFramework.text = GameSettings.Instance.simulation.GenerateFrameworkName(Utilities.RNG);
			}
			else if (UseFrameworkToggle.isOn)
			{
				ExistingFrameworkButton.gameObject.SetActive(true);
				NewFrameworkNameLabel.SetActive(false);
				NewFramework.gameObject.SetActive(false);
			}
			else
			{
				ExistingFrameworkButton.gameObject.SetActive(false);
				NewFrameworkNameLabel.SetActive(false);
				NewFramework.gameObject.SetActive(false);
			}
		});
	}

	public void SelectFramework()
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		FrameworkDialog.Show(category, delegate(SoftwareFramework x)
		{
			Framework = x;
		}, GetFeatures().ToHashSet());
	}

	private DesignDocument Create(bool tut, out List<DesignDocument> addons)
	{
		object obj;
		if (SCMCombo.Selected >= 1)
		{
			ServerGroup selected = SCMCombo.GetSelected<ServerGroup>();
			obj = ((selected != null) ? selected.Name : null);
		}
		else
		{
			obj = null;
		}
		string server = (string)obj;
		SoftwareType selectedType = SelectedType;
		List<FeatureBase> features = GetFeatures();
		Dictionary<string, SoftwareProduct> needs = GetNeeds();
		SoftwareCategory category = GetCategory(selectedType);
		SoftwareProduct[] oSs = GetOSs();
		Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(false);
		string text = ProductName.text;
		float price = Price;
		bool isOn = SubscriptionToggle.isOn;
		double[] submarkets = GetSubmarkets();
		SDateTime start = SDateTime.Now();
		Company myCompany = GameSettings.Instance.MyCompany;
		SoftwareProduct sequelTo = SequelTo;
		bool isOn2 = HouseToggle.isOn;
		ServerGroup selected2 = ServerCombo.GetSelected<ServerGroup>();
		DesignDocument designDocument = DesignDocument.CreateWork(text, selectedType, category, needs, oSs, price, isOn, submarkets, start, myCompany, sequelTo, isOn2, 0.0, features, techLevelDict, null, (selected2 != null) ? selected2.Name : null, server, Framework, NewFrameworkToggle.isOn ? NewFramework.text : null, needs.Values.ToList(), tut);
		designDocument.HardwareDesign = GetFinalHardwareDesign(category, features);
		addons = null;
		foreach (KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign> value2 in ForcedAddList.Values)
		{
			if (addons == null)
			{
				addons = new List<DesignDocument>();
			}
			AddonDesignWindow.AddonDesign value = value2.Value;
			DesignDocument designDocument2 = new DesignDocument(value.Name, value.Type, category, value.Tools, value.Price, SDateTime.Now(), GameSettings.Instance.MyCompany, null, designDocument, 0.0, value.Features, value.FeatureFactors, value.SCM, value.Tools.Select((KeyValuePair<string, SoftwareProduct> x) => x.Value).ToList(), false);
			designDocument2.HardwareDesign = value.HardwareDesign;
			GameSettings.Instance.MyCompany.AddWorkItem(designDocument2);
			addons.Add(designDocument2);
		}
		if (GameSettings.Instance.CurrentMissions.Contains("Mission08") && SequelTo != null)
		{
			SHashSet<string> deals = new SHashSet<string> { "Marketing" };
			float royalty = PublisherDeal.GetRoyalty(deals, category, GameSettings.Instance.MyCompany);
			SimulatedCompany simulatedCompany = GameSettings.Instance.simulation.FindPublisher(GameSettings.Instance.MyCompany, category, 0f, false);
			simulatedCompany.CampaignProtected = true;
			int num = 16;
			(designDocument.Publishing = new PublisherDeal(simulatedCompany, royalty, 0f, 0f, 0f, num, deals)).Affect(designDocument);
		}
		return designDocument;
	}

	private string CheckCompetency()
	{
		if (Subsidiairy != null)
		{
			return null;
		}
		return CheckCompetency(GetFeatures(), DesignTeams.SelectNotNull(GameSettings.GetTeam), DevelopmentTeams.SelectNotNull(GameSettings.GetTeam));
	}

	public static string CheckCompetency(IList<FeatureBase> feats, IEnumerable<Team> designTeams, IEnumerable<Team> devTeams)
	{
		List<Actor> list = ((designTeams != null) ? (from x in designTeams.SelectMany((Team x) => x.GetEmployeesDirect())
			where x.employee.IsRole(Employee.RoleBit.Designer, true)
			select x).ToList() : null);
		List<Actor> source = devTeams.SelectMany((Team x) => x.GetEmployeesDirect()).ToList();
		for (int num = 0; num < feats.Count; num++)
		{
			FeatureBase f = feats[num];
			if (f.CodeArtRatio > 0f)
			{
				if (list != null && list.None((Actor x) => x.employee.GetSpecialization(Employee.EmployeeRole.Designer, f.Spec) >= f.Level))
				{
					if (f.Level == 0)
					{
						return f.Spec.LocTry() + " " + "Designer".Loc().ToLower();
					}
					return "SpecSkillRole".Loc(f.Level, f.Spec.LocTry(), "Designer".Loc());
				}
				if (source.None((Actor x) => x.employee.IsRole(Employee.RoleBit.Programmer, true) && x.employee.GetSpecialization(Employee.EmployeeRole.Programmer, f.Spec) >= f.Level))
				{
					if (f.Level == 0)
					{
						return f.Spec.LocTry() + " " + "Programmer".Loc().ToLower();
					}
					return "SpecSkillRole".Loc(f.Level, f.Spec.LocTry(), "Programmer".Loc());
				}
			}
			if (f.CodeArtRatio < 1f && source.None((Actor x) => x.employee.IsRole(Employee.RoleBit.Artist, true) && x.employee.GetSpecialization(Employee.EmployeeRole.Artist, f.Spec) >= f.Level))
			{
				if (f.Level == 0)
				{
					return f.Spec.LocTry() + " " + "Artist".Loc().ToLower();
				}
				return "SpecSkillRole".Loc(f.Level, f.Spec.LocTry(), "Artist".Loc());
			}
		}
		return null;
	}

	private void CheckComplexity(bool instaDevelop)
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		if (selectedType.DevTime(GetFeatures(), category, GameSettings.Instance.MyCompany, GetTechLevelDict(false), GetOSs(), Framework, NewFrameworkToggle.isOn, SequelTo) / selectedType.GetOptimalDevTime(category) > 1.25f)
		{
			WindowManager.Instance.ShowMessageBox("SoftwareComplexityWarning".Loc(), false, DialogWindow.DialogType.Question, delegate
			{
				CheckInHouse(instaDevelop);
			}, "DocPageComplexityPrompt");
		}
		else
		{
			CheckInHouse(instaDevelop);
		}
	}

	private void CheckPage(bool instaDevelop)
	{
		if (PageChanged || GameSettings.Instance.MyCompany.Products.Count == 0)
		{
			CheckName(instaDevelop);
			return;
		}
		WindowManager.Instance.ShowMessageBox("DesignDocPageTip".Loc(), false, DialogWindow.DialogType.Question, delegate
		{
			CheckName(instaDevelop);
		}, "DocPageChangePrompt");
	}

	private void CheckName(bool instaDevelop)
	{
		if (GameSettings.Instance.IsNetworkMode && (!NetworkManager.Instance.Layer.FilterName(ProductName.text) || (NewFrameworkToggle.isOn && !NetworkManager.Instance.Layer.FilterName(NewFramework.text))))
		{
			WindowManager.Instance.ShowMessageBox("SteamFilterWarning".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if (ProductName.text.Equals(DefaultName.Loc()))
		{
			WindowManager.Instance.ShowMessageBox("DesignProductNameHint".Loc(), false, DialogWindow.DialogType.Question, delegate
			{
				CheckComplexity(instaDevelop);
			});
		}
		else
		{
			CheckComplexity(instaDevelop);
		}
	}

	private void CheckServer(bool instaDevelop)
	{
		if (ServerCombo.Selected == 0 && GetFeatures().Any((FeatureBase x) => x.ServerRequirement > 0f))
		{
			WindowManager.Instance.ShowMessageBox("ServerDesignWindowHint".Loc(), false, DialogWindow.DialogType.Question, delegate
			{
				CheckInHouse(instaDevelop);
			});
		}
		else
		{
			CheckInHouse(instaDevelop);
		}
	}

	private void CheckInHouse(bool instaDevelop)
	{
		SimulatedCompany subsidiairy = Subsidiairy;
		if (subsidiairy != null)
		{
			SoftwareType selectedType = SelectedType;
			SoftwareCategory category = GetCategory(selectedType);
			List<FeatureBase> features = GetFeatures();
			Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(false);
			float devTime = selectedType.DevTime(features, category, GameSettings.Instance.MyCompany, techLevelDict, GetOSs(), Framework, NewFrameworkToggle.isOn, SequelTo);
			KeyValuePair<double, double> keyValuePair = subsidiairy.Premarket(devTime);
			SimulatedCompany.ProductPrototype productPrototype = new SimulatedCompany.ProductPrototype(ProductName.text, selectedType, category, GetNeeds(), GetOSs(), subsidiairy.PickQuality(false, true), subsidiairy.PickQuality(true, true), subsidiairy.PickQuality(false, false), subsidiairy.PickQuality(true, false), Price, SubscriptionToggle.isOn, GetSubmarkets(), subsidiairy, HouseToggle.isOn, (float)keyValuePair.Key, SequelTo, features.ToArray(), techLevelDict, keyValuePair.Value, Framework, NewFrameworkToggle.isOn ? NewFramework.text : null);
			subsidiairy.ProjectQueue.Add(productPrototype);
			productPrototype.SendNetwork();
			WindowManager.Instance.ShowMessageBox("SubsidiaryDelegationConfirm".LocColor(productPrototype, subsidiairy), false, DialogWindow.DialogType.Information);
			ToggleVisible();
		}
		else if (HouseToggle.isOn)
		{
			WindowManager.Instance.ShowMessageBox("InHouseWarning".Loc(), false, DialogWindow.DialogType.Question, delegate
			{
				CheckMockOS(instaDevelop);
			});
		}
		else
		{
			CheckMockOS(instaDevelop);
		}
	}

	private void CheckMockOS(bool instaDevelop)
	{
		if (GetOSs().Any((SoftwareProduct x) => x.IsMock) | GetNeedProducts().Any((KeyValuePair<string, SoftwareProduct> x) => x.Value.IsMock))
		{
			WindowManager.Instance.ShowMessageBox("ProductMockConfirm".Loc(), false, DialogWindow.DialogType.Question, delegate
			{
				CheckSize(instaDevelop);
			});
		}
		else
		{
			CheckSize(instaDevelop);
		}
	}

	private void CheckSize(bool instaDevelop)
	{
		if ((DesignTeams.Count > 0 || DevelopmentTeams.Count > 0) && !AutoDev && Subsidiairy == null)
		{
			int num = 0;
			int num2 = 0;
			foreach (string designTeam in DesignTeams)
			{
				Team team = GameSettings.GetTeam(designTeam);
				if (team != null)
				{
					num += team.GetEmployeesDirect().Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Designer));
				}
			}
			foreach (string developmentTeam in DevelopmentTeams)
			{
				Team team2 = GameSettings.GetTeam(developmentTeam);
				if (team2 != null)
				{
					num2 += team2.GetEmployeesDirect().Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Programmer | Employee.RoleBit.Artist));
				}
			}
			SoftwareType selectedType = SelectedType;
			SoftwareCategory category = GetCategory(selectedType);
			List<FeatureBase> features = GetFeatures();
			float artRatio = SoftwareType.CodeArtRatio(features);
			SoftwareProduct sequelTo = ((SequelTo != null && !SequelTo.Traded) ? SequelTo : null);
			float devTime = selectedType.DevTime(features, category, GameSettings.Instance.MyCompany, GetTechLevelDict(false), GetOSs(), Framework, NewFrameworkToggle.isOn, sequelTo);
			int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(devTime);
			float num3 = GameData.ProjectDevTime(num, num2, devTime, artRatio);
			devTime = GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], devTime, artRatio);
			if (num3 / devTime > 2f)
			{
				string msg = ((num < optimalEmployeeCount[0]) ? "DesignProductTeamSizeHint".Loc() : "DesignProductTeamSizeHintLarge".Loc());
				WindowManager.Instance.ShowMessageBox(msg, false, DialogWindow.DialogType.Question, delegate
				{
					HardDesignTest(instaDevelop);
				});
				return;
			}
			if (num > optimalEmployeeCount[0])
			{
				HintController.Show(HintController.Hints.HintTeamSizeEffectiveness);
			}
			HardDesignTest(instaDevelop);
		}
		else
		{
			HardDesignTest(instaDevelop);
		}
	}

	public void HardDesignTest(bool instaDevelop)
	{
		SoftwareCategory category = GetCategory();
		if (category.Hardware && category.Manufacturing.Designs.Values.Any((int x) => x <= SDateTime.Now().RealYear) && _hardwareDesign == null)
		{
			WindowManager.Instance.ShowMessageBox("HardwareDesignMissWarning".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				AutoDevTest(instaDevelop);
			}, "HardDesignMiss", delegate
			{
				if (CurrentPage > 1)
				{
					PageChanged = true;
					LoadPage(1);
					UpdatePageTitle();
				}
				TutorialSystem.Instance.AddRing(HardwareDesignButton.GetComponent<RectTransform>().ToScreenSpace().center, 256, true);
			});
		}
		else
		{
			AutoDevTest(instaDevelop);
		}
	}

	public void AutoDevTest(bool instaDevelop)
	{
		if (AutoDev)
		{
			List<AutoDevWorkItem> projs = GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().ToList();
			if (projs.Count > 0)
			{
				WindowManager.Instance.MultiWindow.Show("Projectmanagement".Loc(), projs.Select((AutoDevWorkItem x) => x.Name), delegate(int i)
				{
					DevelopNow(projs[i], instaDevelop);
				}, false);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("DesignDocumentAutoDevWarning".Loc(), false, DialogWindow.DialogType.Error);
			}
		}
		else
		{
			DevelopNow(null, instaDevelop);
		}
	}

	public void DevelopClick(bool instaDevelop)
	{
		AutoDev = false;
		UpdateTeamText();
		if (!CheckValid())
		{
			return;
		}
		string text = CheckCompetency();
		if (text == null)
		{
			CheckPage(instaDevelop);
			return;
		}
		WindowManager.Instance.ShowMessageBox("DesignProductFeatureHint".Loc(text), false, DialogWindow.DialogType.Question, delegate
		{
			CheckPage(instaDevelop);
		});
	}

	public void AutoDevClick()
	{
		CheckWithPublisher(delegate
		{
			AutoDev = true;
			if (CheckValid())
			{
				CheckPage(false);
			}
		});
	}

	public void PickPublishingDeal()
	{
		if (GameSettings.Instance.Difficulty.Publisher < 0.5f)
		{
			return;
		}
		if (HouseToggle.isOn)
		{
			WindowManager.Instance.ShowMessageBox("PublishingInHouse".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		if (!GameSettings.HasCompletedMission("Mission08"))
		{
			WindowManager.Instance.ShowMessageBox("CampaignLockError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		CheckWithPublisher(delegate
		{
			SoftwareType selectedType = SelectedType;
			SoftwareCategory category = GetCategory(selectedType);
			List<FeatureBase> features = GetFeatures();
			PubDealWindow.Show(category, selectedType.DevTime(features, category, GameSettings.Instance.MyCompany, GetTechLevelDict(false), GetOSs(), Framework, NewFrameworkToggle.isOn, SequelTo), SoftwareType.CodeArtRatio(features), true, true, SDateTime.Now(), delegate(PublisherDeal x)
			{
				SDateTime sDateTime = SDateTime.Now() + x.Months;
				WindowManager.Instance.ShowMessageBox("PublisherReleasePrompt".Loc(sDateTime.ToCompactString()), true, DialogWindow.DialogType.Question, delegate
				{
					SetPublishingDeal(x);
				}, "PublisherReleasePrompt");
			});
		});
	}

	public void SetPublishingDeal(PublisherDeal deal)
	{
		_publisher = deal;
		if (_publisher != null)
		{
			SubsidiaryCombo.Selected = 0;
			if (Price < 1f)
			{
				SelectDefaultPrice();
			}
			if (_publisher.Deals.Contains("OSExclusivity"))
			{
				bool flag = false;
				foreach (object item in OSList.Items.ToList())
				{
					SoftwareProduct softwareProduct = item as SoftwareProduct;
					if (softwareProduct != null && softwareProduct.DevCompany != _publisher.Publisher)
					{
						OSList.Items.Remove(item);
						flag = true;
					}
				}
				if (flag)
				{
					FixFeatures();
					UpdateDescription();
					UpdateOSList();
				}
			}
			PublisherText.text = _publisher.Publisher.Name;
		}
		else
		{
			PublisherText.text = "None".Loc();
		}
	}

	public void GenerateDesign()
	{
		CheckWithPublisher(ActuallyGenerateDesign);
	}

	private void PickNeedsAndOS()
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		List<FeatureBase> features = GetFeatures();
		foreach (SpecFeature item in from x in selectedType.Features.Values.OfType<SpecFeature>()
			where x.IsForced(category.Name)
			select x)
		{
			if (!features.Contains(item))
			{
				features.Add(item);
			}
		}
		if (selectedType.OSSpecific)
		{
			List<SoftwareProduct> list = GenerateOS(selectedType, features);
			OSList.Items.Clear();
			if (list != null)
			{
				OSList.Items.AddRange(list.Cast<object>());
			}
		}
		Dictionary<string, SoftwareProduct> needs = GenerateNeeds(selectedType, category);
		string[] needs2 = selectedType.GetNeeds(features, category.Name);
		needs = needs2.ToDictionary((string x) => x, (string x) => needs.GetOrDefault(x));
		Dictionary<string, Button> dictionary = NeedsList.ToDictionary((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Key, (KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Key);
		bool flag = false;
		foreach (KeyValuePair<string, SoftwareProduct> item2 in needs)
		{
			if (item2.Value != null)
			{
				Button button = dictionary[item2.Key];
				if (NeedsList[dictionary[item2.Key]].Value == null)
				{
					NeedsList[dictionary[item2.Key]] = new KeyValuePair<string, SoftwareProduct>(item2.Key, item2.Value);
					button.GetComponentInChildren<Text>().text = item2.Value.Name;
					flag = true;
				}
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (FeatureCard featureCard in FeatureCards)
		{
			featureCard.UpdateTech(category, GetNeeds(true), GetOSs());
		}
	}

	public void ActuallyGenerateDesign()
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory category = GetCategory(selectedType);
		Dictionary<string, SoftwareProduct> needs = GenerateNeeds(selectedType, category);
		List<SoftwareProduct> list = GenerateOS(selectedType, null);
		if (list == null && selectedType.OSSpecific)
		{
			return;
		}
		Dictionary<string, TechLevel> dictionary = SimulatedCompany.PickTechs(category, SDateTime.Now(), needs, null, GameSettings.Instance.MyCompany);
		if (dictionary == null)
		{
			return;
		}
		List<Actor> list2 = new List<Actor>();
		List<Actor> list3 = new List<Actor>();
		foreach (string designTeam in DesignTeams)
		{
			Team team = GameSettings.GetTeam(designTeam);
			if (team != null)
			{
				list2.AddRange(team.GetEmployeesDirect());
			}
		}
		foreach (string developmentTeam in DevelopmentTeams)
		{
			Team team2 = GameSettings.GetTeam(developmentTeam);
			if (team2 != null)
			{
				list3.AddRange(team2.GetEmployeesDirect());
			}
		}
		List<FeatureBase> feats = selectedType.GenerateFeatures(list2, list3, category, GameSettings.Instance.MyCompany, needs, dictionary, GetSubmarkets(), SequelTo);
		foreach (SpecFeature item in from x in selectedType.Features.Values.OfType<SpecFeature>()
			where x.IsForced(category.Name)
			select x)
		{
			if (!feats.Contains(item))
			{
				feats.Add(item);
			}
		}
		string[] needs2 = selectedType.GetNeeds(feats, category.Name);
		needs = needs2.ToDictionary((string x) => x, (string x) => needs[x]);
		TechLevel.CleanTechLevels(dictionary, feats);
		OSList.Items.Clear();
		if (list != null)
		{
			list.RemoveAll((SoftwareProduct x) => !SoftwareType.OSDependenciesMet(x, feats));
			OSList.Items.AddRange(list.Cast<object>());
		}
		Dictionary<string, Button> dictionary2 = NeedsList.ToDictionary((KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Value.Key, (KeyValuePair<Button, KeyValuePair<string, SoftwareProduct>> x) => x.Key);
		foreach (KeyValuePair<string, SoftwareProduct> item2 in needs)
		{
			Button button = dictionary2[item2.Key];
			NeedsList[dictionary2[item2.Key]] = new KeyValuePair<string, SoftwareProduct>(item2.Key, item2.Value);
			button.GetComponentInChildren<Text>().text = item2.Value.Name;
		}
		HashSet<FeatureBase> hashSet = feats.ToHashSet();
		foreach (FeatureCard featureCard in FeatureCards)
		{
			TechLevel value;
			if (dictionary.TryGetValue(featureCard.Feature.Spec, out value))
			{
				featureCard.ChangeTech(value);
			}
			featureCard.UpdateTech(category, needs, list);
			featureCard.MainToggle.isOn = hashSet.Contains(featureCard.Feature);
			if (!featureCard.MainToggle.isOn)
			{
				continue;
			}
			foreach (KeyValuePair<SubFeature, Toggle> subFeature in featureCard.SubFeatures)
			{
				subFeature.Value.isOn = hashSet.Contains(subFeature.Key);
			}
		}
		float num = selectedType.DevTime(feats, category, GameSettings.Instance.MyCompany, dictionary, list, null, false, SequelTo);
		if (SoftwareType.GetMaxDevTime(list2.Count, list3.Count) < num)
		{
			WindowManager.Instance.ShowMessageBox("AutoDesignProductTeamSizeHint".Loc(), true, DialogWindow.DialogType.Warning);
		}
	}

	public static List<SoftwareProduct> GenerateOS(SoftwareType type, IList<FeatureBase> feats)
	{
		if (!type.OSSpecific)
		{
			return null;
		}
		IEnumerable<SoftwareProduct> source = from x in GameSettings.Instance.simulation.GetAllProducts(false)
			where "Operating System".Equals(x.Type.Name) && type.SupportsOS(x.Category.Name)
			select x;
		SDateTime time = SDateTime.Now();
		List<SoftwareProduct> list = source.ToList();
		List<SoftwareProduct> list2 = list.Where((SoftwareProduct x) => (time - x.Release).Year < 5).ToList();
		if (list2.Count > 0)
		{
			list = list2;
		}
		List<SoftwareProduct> list3 = new List<SoftwareProduct>();
		float num = 0f;
		foreach (SoftwareProduct item in list.OrderByDescending((SoftwareProduct x) => x.Userbase))
		{
			if (SoftwareType.OSDependenciesMet(item, feats))
			{
				num = Mathf.Max(num, item.Userbase);
				if (!((float)item.Userbase / num > 0.5f))
				{
					break;
				}
				list3.Add(item);
				if (list3.Count == 4)
				{
					break;
				}
			}
		}
		if (list3.Count != 0)
		{
			return list3;
		}
		return null;
	}

	public static Dictionary<string, SoftwareProduct> GenerateNeeds(SoftwareType type, SoftwareCategory category)
	{
		Dictionary<string, List<string>> needsWithSpecs = type.GetNeedsWithSpecs(category.Name);
		Dictionary<string, SoftwareProduct> dictionary = new Dictionary<string, SoftwareProduct>();
		SDateTime time = SDateTime.Now();
		foreach (KeyValuePair<string, List<string>> item in needsWithSpecs)
		{
			SoftwareProduct res = null;
			double comp = 0.0;
			SoftwareProduct res2 = null;
			double comp2 = 0.0;
			List<string> value = item.Value;
			foreach (SoftwareProduct allProduct in GameSettings.Instance.simulation.GetAllProducts(false))
			{
				if (!allProduct.Type.Name.Equals(item.Key))
				{
					continue;
				}
				double num = (double)(allProduct.DevCompany.Player ? 1.5f : 1f) * allProduct.RelativeFeatureScore(GameSettings.Instance.simulation, time);
				for (int i = 0; i < value.Count; i++)
				{
					num += (double)allProduct.TechLevels.GetOrDefault(value[i], (TechLevel x) => x.Year, 0);
				}
				if (SDateTime.GetMonths(allProduct.Release, SDateTime.Now()) < 60f)
				{
					num.IfLargerSet(allProduct, ref comp, ref res);
				}
				else
				{
					num.IfLargerSet(allProduct, ref comp2, ref res2);
				}
			}
			if (res != null)
			{
				dictionary.Add(item.Key, res);
			}
			else if (res2 != null)
			{
				dictionary.Add(item.Key, res2);
			}
		}
		return dictionary;
	}

	public void AddOS()
	{
		if (_publisher == null || _publisher.Deals.Contains("OSExclusivity"))
		{
			ActuallyAddOS();
		}
		else
		{
			CheckWithPublisher(ActuallyAddOS);
		}
	}

	public void ActuallyAddOS()
	{
		SoftwareType selectedType = SelectedType;
		SoftwareCategory cat = GetCategory(selectedType);
		ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
		productWindow.Show(true, "ProductChooseOS".Loc(), delegate(SoftwareProduct[] xs)
		{
			if (xs.Length != 0)
			{
				foreach (SoftwareProduct softwareProduct in xs)
				{
					if (softwareProduct != null && !OSList.Items.Contains(softwareProduct))
					{
						OSList.Items.Add(softwareProduct);
					}
				}
				FixFeatures();
				UpdateDescription();
				UpdatePieChart();
			}
		}, true, true);
		productWindow.WithMock = Subsidiairy == null;
		productWindow.SetFilters(true, false, selectedType.HasOSLimits());
		productWindow.CheckSupport(GetTechLevelDict(false), null, ((IList<FeatureCard>)FeatureCards).WhereSelect((Func<FeatureCard, bool>)((FeatureCard x) => x.Feature.IsForced(cat.Name)), (Func<FeatureCard, FeatureBase>)((FeatureCard x) => x.Feature)).ToArray());
		productWindow.SetType("Operating System");
		if (_publisher != null && _publisher.Deals.Contains("OSExclusivity"))
		{
			productWindow.SetCompany(_publisher.Publisher.ID);
		}
		if (selectedType.HasOSLimits())
		{
			productWindow.SetCategory(selectedType.GetOSLimits().ToHashSet());
		}
	}

	public void RemoveOS()
	{
		if (OSList.Selected.Count <= 0)
		{
			return;
		}
		CheckWithPublisher(delegate
		{
			List<int> source = OSList.Selected.ToList();
			OSList.Selected.Clear();
			foreach (int item in source.OrderByDescending((int x) => x))
			{
				if (item < OSList.Items.Count)
				{
					OSList.Items.RemoveAt(item);
				}
			}
			FixFeatures();
			UpdateDescription();
			UpdatePieChart();
		});
	}

	public void SelectIP()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
		productWindow.SetFilters(false, false);
		productWindow.Show(true, "ProductChooseSequel".Loc(), delegate(SoftwareProduct[] x)
		{
			if (x.Length == 0)
			{
				SequelTo = null;
			}
			else if (x[0].DesignerOwned)
			{
				if (x[0].LeadDesigner.MyActor != null && DesignTeams.Contains(x[0].LeadDesigner.MyActor.Team))
				{
					LeadDesigner.Init(x[0].LeadDesigner, SelectedType.Name);
					SequelTo = x[0];
				}
				else
				{
					Utilities.LeadDesignerIP(x[0], delegate
					{
						SequelTo = x[0];
					});
				}
			}
			else
			{
				SequelTo = x[0];
			}
		});
		Company c = Subsidiairy ?? GameSettings.Instance.MyCompany;
		SoftwareType type = SelectedType;
		SoftwareCategory cat = GetCategory(type);
		List<SoftwareProduct> content = c.Products.Where((SoftwareProduct x) => x.Type.Equals(type) && x.Category.Equals(cat) && c.CanMakeSequel(x)).ToList();
		productWindow.SetContent(content);
	}

	public void OnToggleSubscription()
	{
		CheckWithPublisher(SubscriptionToggle, SelectDefaultPrice);
	}

	public void RandomName()
	{
		if (IsDistribution())
		{
			DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
			ProductName.text = ((distribution != null) ? MarketSimulation.Active.GenerateProductSequalName(distribution.Software.Name, true) : MarketSimulation.Active.GeneratePlatformName(Utilities.RNG));
		}
		else
		{
			ProductName.text = ((SequelTo == null) ? MarketSimulation.Active.GenerateProductName(GetCategory(), Utilities.RNG) : MarketSimulation.Active.GenerateProductSequalName(SequelTo.Name));
		}
	}

	public byte[] GetFinalHardwareDesign(SoftwareCategory cat, IList<FeatureBase> features)
	{
		if (_hardwareDesign != null)
		{
			return _hardwareDesign;
		}
		if (!cat.Hardware)
		{
			return null;
		}
		return HardwareDesignInstance.GenerateRandomDesign(cat.Manufacturing, _sequelTo, null, null, features, null);
	}

	public void DevelopNow(AutoDevWorkItem autoDev, bool instaDevelop)
	{
		if (SCMCombo.Selected > 0)
		{
			ServerGroup selected = SCMCombo.GetSelected<ServerGroup>();
			GameSettings.SavePrefServer("DesignSCM", (selected != null) ? selected.Name : null);
		}
		ServerGroup selected2 = ServerCombo.GetSelected<ServerGroup>();
		GameSettings.SavePrefServer("DesignResult", (selected2 != null) ? selected2.Name : null);
		if (autoDev == null && instaDevelop && SelectedType.Modded)
		{
			WindowManager.SpawnInputDialog("Quality/Bugs/Followers/Copies", "Debug", "1.0/100/1,000,000/100,000,000", delegate(string x)
			{
				string[] array = x.Split('/');
				double num = Math.Sqrt(Convert.ToDouble(array[0]));
				int bugs = Convert.ToInt32(array[1].Replace(",", ""));
				uint followers = Convert.ToUInt32(array[2].Replace(",", ""));
				SoftwareType selectedType = SelectedType;
				SoftwareCategory category = GetCategory(selectedType);
				List<FeatureBase> features = GetFeatures();
				Dictionary<string, TechLevel> techLevelDict = GetTechLevelDict(false);
				SoftwareFramework framework = Framework;
				if (NewFrameworkToggle.isOn)
				{
					SoftwareWorkItem.FeatureProgress[] array2 = SoftwareWorkItem.GenerateProgress(selectedType, category, GameSettings.Instance.MyCompany, features, techLevelDict, null, SequelTo, false, null);
					SoftwareWorkItem.FeatureProgress[] array3 = array2;
					foreach (SoftwareWorkItem.FeatureProgress obj in array3)
					{
						obj.ArtProgress = obj.ADevTime;
						obj.Progress = obj.CDevTime;
					}
					framework = GameSettings.Instance.simulation.CreateFramework(NewFramework.text, GameSettings.Instance.MyCompany, selectedType, category, array2, techLevelDict, SDateTime.Now());
				}
				uint? num2 = null;
				if (IsDistribution() && GameSettings.Instance.MyCompany.Distribution != null)
				{
					num2 = GameSettings.Instance.MyCompany.Distribution.Software.ID;
				}
				string text = ProductName.text;
				SoftwareProduct[] oSs = GetOSs();
				double[] marketQuality = new double[3] { num, num, num };
				Employee currentEmployee = LeadDesigner.CurrentEmployee;
				double creativityScore = ((currentEmployee != null) ? currentEmployee.Creativity : 1f);
				float price = Price;
				bool isOn = SubscriptionToggle.isOn;
				double[] submarkets = GetSubmarkets();
				SDateTime start = SDateTime.Now();
				SDateTime release = SDateTime.Now();
				bool isOn2 = HouseToggle.isOn;
				Company myCompany = GameSettings.Instance.MyCompany;
				SoftwareProduct sequelTo = SequelTo;
				uint id = num2 ?? GameSettings.Instance.simulation.GetID();
				FeatureBase[] features2 = features.ToArray();
				ServerGroup selected3 = ServerCombo.GetSelected<ServerGroup>();
				SoftwareProduct softwareProduct = new SoftwareProduct(text, selectedType, category, oSs, num, num, num, num, marketQuality, creativityScore, price, isOn, submarkets, start, release, bugs, isOn2, myCompany, sequelTo, id, 0.0, features2, techLevelDict, (selected3 != null) ? selected3.Name : null, followers, framework, framework.Royalty(), GetNeeds().Values.ToDictionary((SoftwareProduct z) => z, (SoftwareProduct z) => 0f), null, GetFinalHardwareDesign(category, features));
				if (!IsDistribution())
				{
					softwareProduct.SendNetwork();
					softwareProduct.PhysicalCopies = Convert.ToUInt32(array[3].Replace(",", ""));
					if (_publisher != null)
					{
						softwareProduct.Publishing = _publisher;
						_publisher.Affect(softwareProduct);
						_publisher.SendNetwork();
					}
				}
				SupportWork supportWork = new SupportWork(softwareProduct, -1);
				GameSettings.Instance.MyCompany.AddWorkItem(supportWork);
				GameSettings.Instance.ApplyDefaultTeams(supportWork, "Support");
				if (IsDistribution())
				{
					if (GameSettings.Instance.MyCompany.Distribution == null)
					{
						DistributionPlatform distributionPlatform = MarketSimulation.Active.CreatePlatform(GameSettings.Instance.MyCompany, softwareProduct, DigitalDistributionWindow.GetCut());
						GameSettings.Instance.MyCompany.Distribution = distributionPlatform;
						GameSettings instance = GameSettings.Instance;
						ServerGroup selected4 = ServerCombo.GetSelected<ServerGroup>();
						instance.RegisterWithServer((selected4 != null) ? selected4.Name : null, distributionPlatform);
					}
					else
					{
						DigitalDistributionWindow.CancelAllJobs();
						MarketSimulation.Active.UpdatePlatform(GameSettings.Instance.MyCompany.Distribution, softwareProduct);
					}
					HUD.Instance.digitalDistributionWindow.UpdateStoreButton();
					HUD.Instance.digitalDistributionWindow.UpdateInfo();
				}
				else
				{
					GameSettings.Instance.MyCompany.Products.Add(softwareProduct);
					GameSettings.Instance.simulation.AddProduct(softwareProduct, false);
					List<AddOnProduct> list = new List<AddOnProduct>();
					foreach (KeyValuePair<SoftwareAddOn, AddonDesignWindow.AddonDesign> value2 in ForcedAddList.Values)
					{
						AddonDesignWindow.AddonDesign value = value2.Value;
						AddOnProduct addOnProduct = new AddOnProduct(value.Name, value.Type, softwareProduct, value.Features, value.FeatureFactors, SDateTime.Now(), SDateTime.Now(), value.Price, 0.0, new double[3] { num, num, num }, GameSettings.Instance.MyCompany, softwareProduct.PhysicalCopies, 0f, softwareProduct.Followers, num, num, num, num, true, value.HardwareDesign);
						list.Add(addOnProduct);
						addOnProduct.SendNetwork();
						GameSettings.Instance.MyCompany.AddOns.Add(addOnProduct);
						GameSettings.Instance.simulation.AddAddOn(addOnProduct);
						AddOnProduct.HandleNews(addOnProduct, true);
					}
					if (list.Count > 0)
					{
						softwareProduct.ForcedAddons = list.ToArray();
						softwareProduct.UpdateForcedAddonQualityEffect();
					}
					Employee currentEmployee2 = LeadDesigner.CurrentEmployee;
					if (currentEmployee2 != null)
					{
						currentEmployee2.FinishLeadProject(softwareProduct, (float)num, true, Utilities.RNG.Next());
					}
					SoftwareProduct.HandleNews(softwareProduct, true);
				}
				softwareProduct.RunReleaseScripts();
			});
			Window.Close();
			return;
		}
		GameSettings.Instance.TeamDefaults["Design"] = DesignTeams.ToHashSet();
		GameSettings.Instance.TeamDefaults["Development"] = DevelopmentTeams.ToHashSet();
		List<DesignDocument> addons;
		DesignDocument designDocument = Create(autoDev == null, out addons);
		if (_publisher != null)
		{
			if (!_publisher.Publisher.Bankrupt)
			{
				designDocument.Publishing = _publisher;
				_publisher.Affect(designDocument);
				SetPublishingDeal(null);
			}
			else
			{
				NotificationManager.AddNotification(new NotificationMessage("PublisherAbandon".Loc(_publisher.Publisher.Name, designDocument.SoftwareName), "Deal", NotificationManager.NotificationType.Warning));
			}
		}
		GameSettings.Instance.MyCompany.AddWorkItem(designDocument);
		if (autoDev != null)
		{
			autoDev.AssignProject(designDocument, (addons != null) ? addons.Cast<SoftwareWorkItem>().ToList() : null);
		}
		else
		{
			designDocument.AddDevTeams(DesignTeams);
			designDocument.SetLeadDesigner(LeadDesigner.CurrentEmployee);
			designDocument.NextPhaseTeam = DevelopmentTeams.ToSHashSet();
			designDocument.CheckCompetency();
			if (addons != null)
			{
				foreach (DesignDocument item in addons)
				{
					item.AddDevTeams(DesignTeams);
					item.NextPhaseTeam = DevelopmentTeams.ToSHashSet();
					item.CheckCompetency();
				}
			}
		}
		Window.Close();
	}
}
