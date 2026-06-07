using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class AddonDesignWindow : MonoBehaviour
{
	public class AddonDesign
	{
		public string Name;

		public SoftwareAddOn Type;

		public float Price;

		public AddOnFeature[] Features;

		public uint[] FeatureFactors;

		public Dictionary<string, SoftwareProduct> Tools;

		public HashSet<string> DesignTeams;

		public HashSet<string> DevTeams;

		public byte[] HardwareDesign;

		public string SCM;

		public AddonDesign(string name, SoftwareAddOn type, float price, AddOnFeature[] features, uint[] featureFactors, Dictionary<string, SoftwareProduct> tools, HashSet<string> designTeams, HashSet<string> devTeams, byte[] hardwareDesign, string scm)
		{
			Name = name;
			Type = type;
			Price = price;
			Features = features;
			FeatureFactors = featureFactors;
			Tools = tools;
			DesignTeams = designTeams;
			DevTeams = devTeams;
			HardwareDesign = hardwareDesign;
			SCM = scm;
		}
	}

	public AddonFeatureCard FeatureCardPrefab;

	public SWToolPanel ToolPrefab;

	public GUIWindow Window;

	public GUICombobox SCM;

	public RectTransform FeaturePanel;

	public InputField Name;

	public InputField Price;

	public GUIProgressBar[] MarketBars;

	public Text[] MarketLabals;

	public Text DesignTeamText;

	public Text DevelopTeamText;

	public Text TeamIssueText;

	public VarValueSheet DataPanel;

	public GameObject ManufactureButtonPanel;

	public GameObject ManufactureView;

	public GameObject HardwareDesignButton;

	public ManufacturingPanel ManufacturePanel;

	public Transform ToolPanel;

	private bool _forced;

	[NonSerialized]
	private SoftwareAddOn _category;

	[NonSerialized]
	private float _publishingRoyalties;

	[NonSerialized]
	private FeatureBase[] _parentFeatures;

	[NonSerialized]
	private SoftwareCategory _parentCategory;

	[NonSerialized]
	private SoftwareProduct _parentProduct;

	[NonSerialized]
	private Dictionary<string, TechLevel> _parentTech;

	[NonSerialized]
	private List<AddonFeatureCard> _activeFeatures = new List<AddonFeatureCard>();

	[NonSerialized]
	private double[] _targetMarket = new double[3];

	[NonSerialized]
	private HashSet<string> DesignTeams = new HashSet<string>();

	[NonSerialized]
	private HashSet<string> DevelopmentTeams = new HashSet<string>();

	[NonSerialized]
	private Company Subsidiary;

	[NonSerialized]
	private bool priceHasBeenEdited;

	[NonSerialized]
	private byte[] _hardwareDesign;

	[NonSerialized]
	public List<SWToolPanel> _tools = new List<SWToolPanel>();

	[NonSerialized]
	public Dictionary<string, SWToolPanel> _activeTools = new Dictionary<string, SWToolPanel>();

	[NonSerialized]
	private Action<AddonDesign> _onFinish;

	[NonSerialized]
	private SoftwareProduct _sequelTo;

	[NonSerialized]
	private List<string> _valueList = new List<string>();

	[NonSerialized]
	private List<string> _varList = new List<string>();

	[NonSerialized]
	private List<string> _tipList = new List<string>();

	public SoftwareProduct ParentProduct
	{
		get
		{
			return _parentProduct;
		}
	}

	public List<KeyValuePair<AddOnFeature, uint>> GetFeatures()
	{
		IEnumerable<KeyValuePair<AddOnFeature, uint>> enumerable = from x in _activeFeatures
			where x.MainToggle.isOn
			select new KeyValuePair<AddOnFeature, uint>(x.Feature, x.Amount);
		if (_category.BaseFeature != null)
		{
			enumerable = enumerable.Concate(new KeyValuePair<AddOnFeature, uint>(_category.BaseFeature, 1u));
		}
		return enumerable.ToList();
	}

	public List<FeatureBase> GetFeatureBases()
	{
		IEnumerable<FeatureBase> enumerable = _activeFeatures.Where((AddonFeatureCard x) => x.MainToggle.isOn).Select((Func<AddonFeatureCard, FeatureBase>)((AddonFeatureCard x) => x.Feature));
		if (_category.BaseFeature != null)
		{
			enumerable = enumerable.Concate(_category.BaseFeature);
		}
		return enumerable.ToList();
	}

	public void GetFeatures(List<AddOnFeature> features, List<uint> factors)
	{
		if (_category.BaseFeature != null)
		{
			features.Add(_category.BaseFeature);
			factors.Add(1u);
		}
		for (int i = 0; i < _activeFeatures.Count; i++)
		{
			AddonFeatureCard addonFeatureCard = _activeFeatures[i];
			if (addonFeatureCard.MainToggle.isOn)
			{
				features.Add(addonFeatureCard.Feature);
				factors.Add(addonFeatureCard.Amount);
			}
		}
	}

	public void EditHardwareDesign()
	{
		HardwareDesign bestDesign = _category.Manufacturing.GetBestDesign(SDateTime.Now().Year);
		if (bestDesign != null)
		{
			HUD.Instance.hardwareEditorWindow.Show(bestDesign, _sequelTo, _category, delegate(byte[] x)
			{
				_hardwareDesign = x;
			}, _hardwareDesign, _category, Window, GetFeatureBases());
		}
	}

	public void GetValidFeatures()
	{
		foreach (AddonFeatureCard activeFeature in _activeFeatures)
		{
			UnityEngine.Object.Destroy(activeFeature.gameObject);
		}
		_activeFeatures.Clear();
		foreach (AddOnFeature f in from x in _category.Features.Values
			orderby x.Level, x.Spec
			select x)
		{
			if (f.IsUnlocked(_parentTech, _parentCategory) && (f.FeatureDependency == null || _parentFeatures.Any((FeatureBase x) => x.Name.Equals(f.FeatureDependency))))
			{
				AddonFeatureCard addonFeatureCard = UnityEngine.Object.Instantiate(FeatureCardPrefab);
				addonFeatureCard.Init(f, this);
				addonFeatureCard.transform.SetParent(FeaturePanel, false);
				_activeFeatures.Add(addonFeatureCard);
			}
		}
	}

	private float GetDefaultPrice()
	{
		List<AddOnFeature> features = new List<AddOnFeature>();
		List<uint> factors = new List<uint>();
		GetFeatures(features, factors);
		return (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(_category) * _category.PerceivedValue(features, factors, _parentCategory, _parentTech));
	}

	public void SelectDefaultPrice()
	{
		Price.text = GetDefaultPrice().CurrencyMul().ToString("N");
		priceHasBeenEdited = false;
	}

	public float GetPrice()
	{
		float num = Mathf.Max(0f, (float)Convert.ToDouble(Price.text));
		if (float.IsInfinity(num) || float.IsNaN(num))
		{
			num = GetDefaultPrice();
		}
		return num.FromCurrency();
	}

	public void PriceEndEdit()
	{
		float num = 0f;
		try
		{
			num = Mathf.Max(0f, (float)Convert.ToDouble(Price.text));
			if (float.IsInfinity(num) || float.IsNaN(num))
			{
				num = 0f;
			}
			Price.text = num.ToString("N");
			priceHasBeenEdited = true;
		}
		catch (Exception)
		{
			SelectDefaultPrice();
		}
	}

	public void Show(string swName, SoftwareAddOn category, SoftwareCategory cat, SoftwareProduct sequelTo, FeatureBase[] features, Dictionary<string, TechLevel> tech, Dictionary<string, SoftwareProduct> tools, double[] targetMarket, AddonDesign prev, float publisher, Action<AddonDesign> onFinish)
	{
		_forced = category.Forced.HasValue;
		_category = category;
		_parentCategory = cat;
		_sequelTo = sequelTo;
		_parentProduct = null;
		_parentFeatures = features;
		_parentTech = tech;
		_targetMarket = targetMarket;
		_hardwareDesign = ((prev != null) ? prev.HardwareDesign : null);
		_onFinish = onFinish;
		_publishingRoyalties = publisher;
		FinishInit(new FormatColorString(swName), (prev != null) ? prev.Tools : tools, prev);
	}

	public void Show(SoftwareAddOn category, SoftwareProduct p)
	{
		_forced = false;
		_category = category;
		_parentCategory = p.Category;
		_sequelTo = p.SequelTo;
		_parentProduct = p;
		_parentFeatures = p.Features;
		_parentTech = p.TechLevels;
		_targetMarket = p.Submarkets;
		_hardwareDesign = null;
		_publishingRoyalties = 0f;
		_onFinish = null;
		Dictionary<string, SoftwareProduct> dictionary = new Dictionary<string, SoftwareProduct>();
		foreach (var tool in p.GetTools())
		{
			dictionary[tool.Item1.Type.Name] = tool.Item1;
		}
		FinishInit(p, dictionary, null);
	}

	private void InitTools(Dictionary<string, SoftwareProduct> needs, SoftwareType type, Dictionary<string, TechLevel> techs)
	{
		int num = 0;
		_activeTools.Clear();
		foreach (SpecFeature item in _parentFeatures.OfType<SpecFeature>())
		{
			string[] dependencies = item.Dependencies;
			foreach (string text in dependencies)
			{
				if (!_activeTools.ContainsKey(text))
				{
					SWToolPanel sWToolPanel;
					if (num < _tools.Count)
					{
						sWToolPanel = _tools[num];
					}
					else
					{
						sWToolPanel = UnityEngine.Object.Instantiate(ToolPrefab);
						sWToolPanel.transform.SetParent(ToolPanel, false);
						_tools.Add(sWToolPanel);
					}
					_activeTools[text] = sWToolPanel;
					sWToolPanel.Init(text, _parentCategory.Parent, _parentFeatures, _parentTech, null);
					SoftwareProduct p;
					if (needs.TryGetValue(text, out p) && p != null && type.GetSpecsFromNeed(text).All((string x) => p.TechLevels.ContainsKey(x) && techs.ContainsKey(x) && p.TechLevels[x].Year >= techs[x].Year))
					{
						sWToolPanel.SetProduct(p);
					}
					num++;
				}
			}
		}
		for (int num2 = num; num2 < _tools.Count; num2++)
		{
			_tools[num2].gameObject.SetActive(false);
		}
		RefreshTools();
	}

	public void RefreshTools()
	{
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		List<FeatureBase> featureBases = GetFeatureBases();
		for (int i = 0; i < featureBases.Count; i++)
		{
			hashSet2.Add(featureBases[i].Spec);
		}
		for (int j = 0; j < _parentFeatures.Length; j++)
		{
			SpecFeature specFeature = _parentFeatures[j] as SpecFeature;
			if (specFeature != null && hashSet2.Contains(specFeature.Spec))
			{
				hashSet.AddRange(specFeature.Dependencies);
			}
		}
		foreach (KeyValuePair<string, SWToolPanel> activeTool in _activeTools)
		{
			activeTool.Value.gameObject.SetActive(hashSet.Contains(activeTool.Key));
		}
		ToolPanel.gameObject.SetActive(hashSet.Count > 0);
		LayoutRebuilder.MarkLayoutForRebuild(ToolPanel.parent.GetComponent<RectTransform>());
	}

	public byte[] GetFinalHardwareDesign(IList<AddOnFeature> features)
	{
		if (_hardwareDesign != null)
		{
			return _hardwareDesign;
		}
		if (_category.Hardware)
		{
			return HardwareDesignInstance.GenerateRandomDesign(_category.Manufacturing, _sequelTo, _parentProduct, _category, features.SelectInPlace((Func<AddOnFeature, FeatureBase>)((AddOnFeature x) => x)), GameSettings.Instance.MyCompany);
		}
		return null;
	}

	private void FinishInit(IFormatColorObject p, Dictionary<string, SoftwareProduct> needs, AddonDesign prev)
	{
		TutorialSystem.Instance.StartTutorial("Addons");
		ManufactureView.gameObject.SetActive(false);
		GetValidFeatures();
		if (_activeFeatures.Count == 0 && _category.BaseFeature == null)
		{
			WindowManager.Instance.ShowMessageBox("NoAddonFeatures".LocColor(p, _category), true, DialogWindow.DialogType.Error);
			return;
		}
		if (prev != null)
		{
			foreach (AddonFeatureCard activeFeature in _activeFeatures)
			{
				int num = Array.IndexOf(prev.Features, activeFeature.Feature);
				if (num >= 0)
				{
					activeFeature.MainToggle.isOn = true;
					activeFeature.Slider.Value = prev.FeatureFactors[num];
				}
			}
		}
		for (int i = 0; i < MarketLabals.Length; i++)
		{
			MarketLabals[i].text = _category.Parent.SubMarkets[i].Loc();
		}
		DesignTeams.Clear();
		DesignTeams.AddRange((prev != null) ? prev.DesignTeams : GameSettings.Instance.GetDefaultTeams("Design"));
		DevelopmentTeams.Clear();
		DevelopmentTeams.AddRange((prev != null) ? prev.DevTeams : GameSettings.Instance.GetDefaultTeams("Development"));
		if (prev != null)
		{
			Name.text = prev.Name;
			Price.text = prev.Price.CurrencyMul().ToString("N");
		}
		else
		{
			GenerateName();
		}
		RefreshData();
		ManufactureButtonPanel.SetActive(_category.Hardware);
		HardwareDesignButton.SetActive(_category.Hardware && _category.Manufacturing.GetValidDesigns(SDateTime.Now().Year).Any());
		InitTools(needs, _category.Parent, _parentTech);
		Window.NonLocTitle = "AddonForProduct".Loc(_category.GetPrettyName(), p);
		Window.Show();
	}

	public void RefreshData()
	{
		if (!priceHasBeenEdited)
		{
			SelectDefaultPrice();
		}
		UpdateMarketSatisfaction();
		UpdateSheet();
		UpdateTeamText();
	}

	private float GetLicenseCost(int devEmps)
	{
		Company myCompany = GameSettings.Instance.MyCompany;
		float num = 0f;
		foreach (SWToolPanel item in _activeTools.Values.Where((SWToolPanel x) => x.gameObject.activeSelf && x.PickedProduct != null))
		{
			SoftwareProduct pickedProduct = item.PickedProduct;
			if (pickedProduct.HasToPay(myCompany))
			{
				num += pickedProduct.GetLicenseCost(true) * (float)devEmps;
			}
		}
		return num;
	}

	public void UpdateSheet()
	{
		_valueList.Clear();
		_varList.Clear();
		_tipList.Clear();
		List<AddOnFeature> list = new List<AddOnFeature>();
		List<uint> list2 = new List<uint>();
		GetFeatures(list, list2);
		FeatureBase[] features = list.Cast<FeatureBase>().ToArray();
		if (_category.Hardware)
		{
			ManufacturePanel.Initialize(_category, features, list2, null, null, false);
		}
		string item = ((_parentProduct == null) ? "NotApplicableAbbr".Loc() : (_parentProduct.Userbase * _category.PerUser).ToString("N0"));
		float num = _category.DevTime(list, list2, _parentCategory, GameSettings.Instance.MyCompany, _parentTech);
		float actual = num;
		float num2 = SoftwareType.CodeArtRatio(features);
		int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(num);
		int devEmps = optimalEmployeeCount[1];
		if ((DesignTeams.Count == 0 && DevelopmentTeams.Count == 0) || Subsidiary != null)
		{
			num = GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], num, num2);
		}
		else
		{
			int num3 = 0;
			int num4 = 0;
			foreach (string designTeam in DesignTeams)
			{
				Team team = GameSettings.GetTeam(designTeam);
				if (team != null)
				{
					num3 += team.GetEmployeesDirect().Count((Actor x) => !x.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && x.employee.IsRole(Employee.RoleBit.Designer));
				}
			}
			foreach (string developmentTeam in DevelopmentTeams)
			{
				Team team2 = GameSettings.GetTeam(developmentTeam);
				if (team2 != null)
				{
					num4 += team2.GetEmployeesDirect().Count((Actor x) => !x.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && x.employee.IsRole(Employee.RoleBit.Programmer | Employee.RoleBit.Artist));
				}
			}
			num = GameData.ProjectDevTime((num3 == 0) ? optimalEmployeeCount[0] : num3, (num4 == 0) ? optimalEmployeeCount[1] : num4, num, num2);
			if (num4 > 0)
			{
				devEmps = num4;
			}
		}
		float num5 = 0f;
		for (int num6 = 0; num6 < list.Count; num6++)
		{
			AddOnFeature addOnFeature = list[num6];
			num5 += addOnFeature.GetDevTime(_parentCategory, GameSettings.Instance.MyCompany, _parentTech, list2[num6]);
		}
		num5 /= _category.OptimalDevTime;
		_varList.Add("ETA".Loc());
		_valueList.Add(DesignDocumentWindow.GetTimeString(num, actual, num5));
		_tipList.Add(null);
		_varList.Add("Recommendeddesigners".Loc());
		_valueList.Add(Mathf.Ceil(optimalEmployeeCount[0]).ToString());
		_tipList.Add(null);
		_varList.Add("Recommendedprogrammers".Loc());
		_valueList.Add(Mathf.Ceil((float)optimalEmployeeCount[1] * num2).ToString());
		_tipList.Add(null);
		_varList.Add("Recommendedartists".Loc());
		_valueList.Add(Mathf.Ceil((float)optimalEmployeeCount[1] * (1f - num2)).ToString());
		_tipList.Add(null);
		if (_category.Hardware)
		{
			float price;
			int mask;
			int inputMask;
			_category.Manufacturing.GetProcessInfo(features, list2, out price, out mask, out inputMask);
			_varList.Add("ManufacturingCost".Loc());
			_valueList.Add(price.Currency());
			_tipList.Add("ManufacturingCostTip");
		}
		_varList.Add("Licensecosts".Loc());
		_valueList.Add(GetLicenseCost(devEmps).Currency());
		_tipList.Add("LicenseCostTip");
		_varList.Add("Royalties".Loc());
		_valueList.Add((_parentTech.Values.Where((TechLevel x) => x.HasToPay(GameSettings.Instance.MyCompany)).SumSafe((TechLevel x) => x.Royalty) + _publishingRoyalties).ToPercent());
		_tipList.Add("RoyaltyTip");
		_varList.Add("Expectedinterest".Loc());
		double num7 = _category.PerceivedMarketValue(list, list2, _parentCategory, _parentTech, _targetMarket);
		_valueList.Add((Utilities.RoundToInt(num7 * 100.0) + "%").FontColor(HUD.Instance.docWindow.InterestGradient.Evaluate((float)num7)));
		_tipList.Add("ProductInterestTip");
		_varList.Add("WastedInterest".Loc());
		num7 = _category.PerceivedMarketValue(list, list2, _parentCategory, _parentTech, _targetMarket, true);
		_valueList.Add((Utilities.RoundToInt(num7 * 100.0) + "%").FontColor(Color.Lerp(new Color32(50, 50, 50, byte.MaxValue), Color.red, (float)num7.MapRange(0.1, 0.5, 0.0, 1.0, true))));
		_tipList.Add("WastedInterestTip");
		_varList.Add("Consumerreach".Loc());
		_valueList.Add(item);
		_tipList.Add("ConsumerReachTip");
		DataPanel.SetData(_varList.ToArray(), _valueList.ToArray(), false);
		DataPanel.ToolTips = _tipList.ToArray();
	}

	public void GenerateName()
	{
		Name.text = MarketSimulation.Active.GenerateAddonName(ParentProduct, _sequelTo, _category, _forced, Utilities.RNG);
	}

	public void UpdateMarketSatisfaction()
	{
		List<KeyValuePair<AddOnFeature, uint>> features = GetFeatures();
		double[] array = new double[3];
		for (int i = 0; i < features.Count; i++)
		{
			features[i].Key.GetSubAdd(_category, _parentCategory, _parentTech.GetOrNull(features[i].Key.Spec), array, features[i].Value, true);
		}
		for (int j = 0; j < 3; j++)
		{
			MarketBars[j].Value = (float)((_targetMarket[j] == 0.0) ? 1.0 : Math.Min(1.0, array[j] / _targetMarket[j]));
		}
	}

	public void ChangeDevTeam(bool design)
	{
		HashSet<string> teams = (design ? DesignTeams : DevelopmentTeams);
		HUD.Instance.TeamSelectWindow.Show(false, teams, delegate(string[] t)
		{
			teams.Clear();
			teams.AddRange(t);
			RefreshData();
		}, design ? "Design" : "Development", null, design ? "DesignDocument" : "SoftwareAlpha");
	}

	private string CheckCompetency()
	{
		return DesignDocumentWindow.CheckCompetency(GetFeatureBases(), DesignTeams.SelectNotNull(GameSettings.GetTeam), DevelopmentTeams.SelectNotNull(GameSettings.GetTeam));
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
			TeamIssueText.gameObject.SetActive(false);
			return;
		}
		TeamIssueText.gameObject.SetActive(true);
		TeamIssueText.text = "MissingThing".Loc(text);
	}

	private string GetSCM()
	{
		if (SCM.Selected >= 1)
		{
			ServerGroup selected = SCM.GetSelected<ServerGroup>();
			if (selected == null)
			{
				return null;
			}
			return selected.Name;
		}
		return null;
	}

	private AddonDesign CreateProtoDesign()
	{
		List<AddOnFeature> list = new List<AddOnFeature>();
		List<uint> list2 = new List<uint>();
		GetFeatures(list, list2);
		Dictionary<string, SoftwareProduct> tools = _activeTools.Where((KeyValuePair<string, SWToolPanel> x) => x.Value.gameObject.activeSelf).ToDictionary((KeyValuePair<string, SWToolPanel> x) => x.Key, (KeyValuePair<string, SWToolPanel> x) => x.Value.PickedProduct);
		return new AddonDesign(Name.text, _category, GetPrice(), list.ToArray(), list2.ToArray(), tools, DesignTeams.ToHashSet(), DevelopmentTeams.ToHashSet(), GetFinalHardwareDesign(list), GetSCM());
	}

	private DesignDocument CreateDesign()
	{
		List<KeyValuePair<AddOnFeature, uint>> features = GetFeatures();
		Dictionary<string, SoftwareProduct> dictionary = _activeTools.Where((KeyValuePair<string, SWToolPanel> x) => x.Value.gameObject.activeSelf).ToDictionary((KeyValuePair<string, SWToolPanel> x) => x.Key, (KeyValuePair<string, SWToolPanel> x) => x.Value.PickedProduct);
		DesignDocument designDocument = new DesignDocument(Name.text, _category, _parentCategory, dictionary, GetPrice(), SDateTime.Now(), GameSettings.Instance.MyCompany, _parentProduct, null, 0.0, ((IList<KeyValuePair<AddOnFeature, uint>>)features).SelectInPlace((Func<KeyValuePair<AddOnFeature, uint>, FeatureBase>)((KeyValuePair<AddOnFeature, uint> x) => x.Key)), features.SelectInPlace((KeyValuePair<AddOnFeature, uint> x) => x.Value), GetSCM(), dictionary.Values.ToList());
		designDocument.HardwareDesign = GetFinalHardwareDesign(features.SelectInPlace((KeyValuePair<AddOnFeature, uint> x) => x.Key));
		designDocument.AddDevTeams(DesignTeams);
		designDocument.NextPhaseTeam = DevelopmentTeams.ToSHashSet();
		designDocument.CheckCompetency();
		GameSettings.Instance.MyCompany.AddWorkItem(designDocument);
		return designDocument;
	}

	public void BeginDevelop()
	{
		if (_activeFeatures.Count((AddonFeatureCard x) => x.MainToggle.isOn) == 0 && _category.BaseFeature == null)
		{
			WindowManager.Instance.ShowMessageBox("NoAddonFeatures".LocColor(Name.text, _category), true, DialogWindow.DialogType.Error);
			return;
		}
		if (_activeTools.Values.Where((SWToolPanel x) => x.gameObject.activeSelf).Any((SWToolPanel x) => x.PickedProduct == null))
		{
			WindowManager.Instance.ShowMessageBox("ProductNeedError".Loc(), false, DialogWindow.DialogType.Error);
			return;
		}
		if (GameSettings.Instance.IsNetworkMode && !NetworkManager.Instance.Layer.FilterName(Name.text))
		{
			WindowManager.Instance.ShowMessageBox("SteamFilterWarning".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		string text = DesignDocumentWindow.CheckCompetency(GetFeatureBases(), DesignTeams.SelectNotNull(GameSettings.GetTeam), DevelopmentTeams.SelectNotNull(GameSettings.GetTeam));
		if (text != null)
		{
			WindowManager.Instance.ShowMessageBox("DesignProductFeatureHint".Loc(text), false, DialogWindow.DialogType.Question, HardDesignTest);
		}
		else
		{
			HardDesignTest();
		}
	}

	public void HardDesignTest()
	{
		if (_category.Hardware && _category.Manufacturing.Designs.Values.Any((int x) => x <= SDateTime.Now().RealYear) && _hardwareDesign == null)
		{
			WindowManager.Instance.ShowMessageBox("HardwareDesignMissWarning".Loc(), true, DialogWindow.DialogType.Question, ActuallyBeginDevelop, "HardDesignMiss", delegate
			{
				TutorialSystem.Instance.AddRing(HardwareDesignButton.GetComponent<RectTransform>().ToScreenSpace().center, 256, true);
			});
		}
		else
		{
			ActuallyBeginDevelop();
		}
	}

	private void ActuallyBeginDevelop()
	{
		if (_parentProduct != null)
		{
			GameSettings.SavePrefServer("AddonDesign", GetSCM());
			CreateDesign();
		}
		else
		{
			_onFinish(CreateProtoDesign());
		}
		GameSettings.Instance.TeamDefaults["Design"] = DesignTeams.ToHashSet();
		GameSettings.Instance.TeamDefaults["Development"] = DevelopmentTeams.ToHashSet();
		Window.Close();
	}

	private void Start()
	{
		GameSettings instance = GameSettings.Instance;
		instance.OnServersChanged = (EventHandler)Delegate.Combine(instance.OnServersChanged, (EventHandler)delegate
		{
			if (Window.Shown)
			{
				UpdateSCMCombo();
			}
		});
	}

	private void UpdateSCMCombo()
	{
		SCM.UpdateContent(GameSettings.Instance.GetAllServerGroups(true));
	}

	private void OnEnable()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			UpdateSCMCombo();
			ServerGroup server;
			if (GameSettings.GetPrefServer("AddonDesign", out server))
			{
				SCM.SelectedItem = server;
			}
		}
	}
}
