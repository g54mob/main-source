using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FeatureCard : MonoBehaviour
{
	public Toggle SubFeaturePrefab;

	public Toggle MainToggle;

	public Text Name;

	public Text Spec;

	public Text Description;

	public Text TechLevel;

	public Button TechDown;

	public Button TechUp;

	public Sprite[] HeaderSprites;

	private int _minTech;

	private int _maxTech;

	private string _maxTechReason = "Newest tech";

	public GUIToolTipper TechUpTip;

	public GUIToolTipper TechDownTip;

	public RectTransform MainPanel;

	public RectTransform SubFeaturePanel;

	public GUIProgressBar TechProg;

	[NonSerialized]
	public SpecFeature Feature;

	[NonSerialized]
	public Dictionary<SubFeature, Toggle> SubFeatures = new Dictionary<SubFeature, Toggle>();

	[NonSerialized]
	private TechLevel _tech;

	public DesignDocumentWindow Parent;

	public Color ShortDev;

	public Color SeqDev;

	public Color FrameDev;

	public Color InvalidDev;

	public GameObject TechPanel;

	[NonSerialized]
	public SoftwareCategory ForcedCat;

	public FeatureTipperTarget MainTipper;

	public TechLevel Tech
	{
		get
		{
			return _tech;
		}
		set
		{
			_tech = value;
			TechChanged();
		}
	}

	public void SetTechDirect(TechLevel tech)
	{
		if (tech != null)
		{
			TechPanel.SetActive(true);
			Tech = tech;
		}
		else
		{
			TechPanel.SetActive(false);
		}
	}

	public void SetBoostDirect(HashSet<FeatureBase> features)
	{
		MainToggle.targetGraphic.color = (features.Contains(Feature) ? FrameDev : Color.white);
		foreach (KeyValuePair<SubFeature, Toggle> subFeature in SubFeatures)
		{
			subFeature.Value.targetGraphic.color = (features.Contains(subFeature.Key) ? FrameDev : Color.white);
		}
	}

	public void Init(SpecFeature feat, IEnumerable<SubFeature> subs, SoftwareCategory cat)
	{
		string[] feature = Localization.GetFeature(feat);
		MainTipper.SWCat = cat;
		MainTipper.Feature = feat;
		Feature = feat;
		ForcedCat = cat;
		Name.text = feature[0];
		Spec.text = Feature.Spec.LocTry();
		MainToggle.interactable = false;
		if (feature.Length < 2 || string.IsNullOrEmpty(feature[1]))
		{
			Description.gameObject.SetActive(false);
		}
		else
		{
			Description.text = feature[1].Format();
		}
		int num = 0;
		float num2 = 0f;
		foreach (SubFeature item in from x in subs
			orderby x.Level, x.DevTime
			select x)
		{
			if (num != item.Level)
			{
				CreateHeader(item.Level).transform.SetParent(SubFeaturePanel, false);
				num = item.Level;
				num2 += HeaderSprites[item.Level - 1].rect.height + 2f;
			}
			Toggle toggle = UnityEngine.Object.Instantiate(SubFeaturePrefab);
			toggle.interactable = false;
			string[] feature2 = Localization.GetFeature(item);
			toggle.GetComponentInChildren<Text>().text = feature2[0];
			FeatureTipperTarget component = toggle.GetComponent<FeatureTipperTarget>();
			component.Feature = item;
			component.SWCat = cat;
			toggle.transform.SetParent(SubFeaturePanel, false);
			SubFeatures[item] = toggle;
		}
		if (SubFeatures.Count == 0)
		{
			SubFeaturePanel.gameObject.SetActive(false);
		}
		MainPanel.sizeDelta = new Vector2(256f, 82f + (Description.gameObject.activeSelf ? (GetDescHeight() + 2f) : 0f) + (float)(SubFeatures.Count * 22) + num2);
	}

	private float GetDescHeight()
	{
		TextGenerationSettings generationSettings = Description.GetGenerationSettings(new Vector2(Description.rectTransform.rect.width, 0f));
		return Description.cachedTextGeneratorForLayout.GetPreferredHeight(Description.text, generationSettings) / Options.UISize;
	}

	public bool CheckDeps(out string dep, out bool direct, Dictionary<string, SoftwareProduct> needs)
	{
		dep = null;
		direct = false;
		if (Feature.Dependencies.Length != 0)
		{
			HashSet<string> hashSet = Feature.Dependencies.ToHashSet();
			string[] dependencies = Feature.Dependencies;
			foreach (string text in dependencies)
			{
				SoftwareProduct value;
				if (needs.TryGetValue(text, out value) && value != null)
				{
					if (!value.TechLevels.ContainsKey(Feature.Spec))
					{
						dep = value.Name;
						direct = true;
						return false;
					}
					hashSet.Remove(text);
				}
			}
			foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
			{
				if (hashSet.Contains(allProduct.Type.Name) && allProduct.TechLevels.ContainsKey(Feature.Spec) && hashSet.Remove(allProduct.Type.Name) && hashSet.Count == 0)
				{
					break;
				}
			}
			if (hashSet.Count == 0)
			{
				return true;
			}
			dep = hashSet.First();
			return false;
		}
		return true;
	}

	public void Init(SpecFeature feat, IEnumerable<SubFeature> subs, SoftwareCategory cat, DesignDocumentWindow window)
	{
		string[] feature = Localization.GetFeature(feat);
		MainTipper.SWCat = cat;
		MainTipper.Feature = feat;
		Parent = window;
		Feature = feat;
		Name.text = feature[0];
		Spec.text = Feature.Spec.LocTry();
		bool flag = feat.IsForced(cat.Name);
		MainToggle.isOn = flag;
		MainToggle.interactable = !flag;
		MainToggle.onValueChanged.AddListener(delegate
		{
			Parent.CheckWithPublisher(MainToggle, delegate
			{
				RefreshSubToggles();
				Parent.FixFeatures();
			});
		});
		_minTech = Feature.GetUnlock(cat) - 1900;
		UpdateTech(cat, window.GetNeeds(), window.GetOSs(), true);
		TechProg.Value = _tech.GetRelevancy(cat);
		if (feature.Length < 2 || string.IsNullOrEmpty(feature[1]))
		{
			Description.gameObject.SetActive(false);
		}
		else
		{
			Description.text = feature[1].Format();
		}
		int num = 0;
		float num2 = 0f;
		foreach (SubFeature item in from x in subs
			orderby x.Level, x.DevTime
			select x)
		{
			if (num != item.Level)
			{
				CreateHeader(item.Level).transform.SetParent(SubFeaturePanel, false);
				num = item.Level;
				num2 += HeaderSprites[item.Level - 1].rect.height + 2f;
			}
			Toggle toggle = UnityEngine.Object.Instantiate(SubFeaturePrefab);
			toggle.isOn = false;
			string[] feature2 = Localization.GetFeature(item);
			toggle.GetComponentInChildren<Text>().text = feature2[0];
			FeatureTipperTarget component = toggle.GetComponent<FeatureTipperTarget>();
			component.Feature = item;
			component.SWCat = cat;
			toggle.transform.SetParent(SubFeaturePanel, false);
			toggle.onValueChanged.AddListener(delegate
			{
				Parent.CheckWithPublisher(toggle, Parent.FixFeatures);
			});
			if (!MainToggle.isOn)
			{
				toggle.interactable = false;
				component.Warning = "FeatureLimitMain".Loc(feature[0]);
			}
			SubFeatures[item] = toggle;
		}
		if (SubFeatures.Count == 0)
		{
			SubFeaturePanel.gameObject.SetActive(false);
		}
		MainPanel.sizeDelta = new Vector2(256f, 82f + (Description.gameObject.activeSelf ? (GetDescHeight() + 2f) : 0f) + (float)(SubFeatures.Count * 22) + num2);
	}

	public void RefreshSubToggles()
	{
		Parent.DisableFeatureUpdate = true;
		SoftwareCategory cat = ForcedCat ?? Parent.GetCategory();
		foreach (KeyValuePair<SubFeature, Toggle> subFeature in SubFeatures)
		{
			bool flag = true;
			FeatureTipperTarget component = subFeature.Value.GetComponent<FeatureTipperTarget>();
			if (!subFeature.Key.IsUnlocked(Parent.GetTechLevelDict(true), cat))
			{
				flag = false;
				component.Warning = "FeatureLimitYear".Loc(subFeature.Key.GetUnlock(cat));
			}
			else if (!MainToggle.isOn)
			{
				flag = false;
				string[] feature = Localization.GetFeature(Feature);
				component.Warning = "FeatureLimitMain".Loc(feature[0]);
			}
			else
			{
				component.Warning = null;
			}
			subFeature.Value.isOn &= flag;
			subFeature.Value.interactable = flag;
		}
		Parent.DisableFeatureUpdate = false;
	}

	public void RefreshSpeedBoost(SoftwareProduct sequel, SoftwareFramework framework, Dictionary<Employee.EmployeeRole, Dictionary<string, int>> specs)
	{
		RefreshSubToggles();
		HashSet<FeatureBase> sequel2 = null;
		if (sequel != null)
		{
			sequel2 = sequel.Features.ToHashSet();
		}
		FixFeatColor(Feature, MainToggle, Tech, sequel2, framework, specs, false, MainTipper);
		foreach (KeyValuePair<SubFeature, Toggle> subFeature in SubFeatures)
		{
			FixFeatColor(subFeature.Key, subFeature.Value, Tech, sequel2, framework, specs, true, subFeature.Value.GetComponent<FeatureTipperTarget>());
		}
	}

	private bool CheckValid(Employee.EmployeeRole role, FeatureBase feat, Dictionary<Employee.EmployeeRole, Dictionary<string, int>> specs)
	{
		Dictionary<string, int> value;
		int value2;
		if (specs.TryGetValue(role, out value) && value.TryGetValue(feat.Spec, out value2))
		{
			return value2 >= feat.Level;
		}
		return false;
	}

	private void FixFeatColor(FeatureBase feat, Toggle t, TechLevel tt, HashSet<FeatureBase> sequel, SoftwareFramework framework, Dictionary<Employee.EmployeeRole, Dictionary<string, int>> specs, bool withTip, FeatureTipperTarget tipper)
	{
		Employee.EmployeeRole? employeeRole = null;
		if (specs != null)
		{
			if (!CheckValid(Employee.EmployeeRole.Designer, feat, specs))
			{
				employeeRole = Employee.EmployeeRole.Designer;
			}
			else if (feat.CodeArtRatio > 0f && !CheckValid(Employee.EmployeeRole.Programmer, feat, specs))
			{
				employeeRole = Employee.EmployeeRole.Programmer;
			}
			else if (feat.CodeArtRatio < 1f && !CheckValid(Employee.EmployeeRole.Artist, feat, specs))
			{
				employeeRole = Employee.EmployeeRole.Artist;
			}
		}
		float tech = 1f - tt.GetDevTime();
		bool flag = sequel != null && sequel.Contains(feat);
		TechLevel value;
		double num = ((framework == null || !framework.TechLevels.TryGetValue(feat.Spec, out value) || !framework.Features.TryGetValue(feat, out num)) ? 0.0 : (num * (double)SoftwareFramework.SpeedBoost(value, tt)));
		if (employeeRole.HasValue)
		{
			t.targetGraphic.color = InvalidDev;
			if (withTip)
			{
				tipper.Warning = "MissingThing".Loc("SpecSkillRole".Loc(feat.Level, feat.Spec, employeeRole.Value.ToString().Loc()));
			}
		}
		else if (flag && num > 0.03999999910593033)
		{
			t.targetGraphic.color = ShortDev;
		}
		else if (flag)
		{
			t.targetGraphic.color = SeqDev;
		}
		else if (num > 0.03999999910593033)
		{
			t.targetGraphic.color = FrameDev;
		}
		else
		{
			t.targetGraphic.color = Color.white;
		}
		AddTip(tipper, flag, (float)num, GameSettings.Instance.MyCompany.GetLatestResearch(Feature.Spec, -1) >= tt.Year, tech);
	}

	private void AddTip(FeatureTipperTarget t, bool seq, float frame, bool research, float tech)
	{
		t.Boosts.Clear();
		if (tech != 0f)
		{
			t.Boosts.Add(new KeyValuePair<string, float>("Techlevel", tech));
		}
		if (research)
		{
			t.Boosts.Add(new KeyValuePair<string, float>("Research", 0.100000024f));
		}
		if (seq)
		{
			t.Boosts.Add(new KeyValuePair<string, float>("Predecessor", 1f - SoftwareType.SequelBoost));
		}
		if (frame > 0.04f)
		{
			t.Boosts.Add(new KeyValuePair<string, float>("Framework", frame * 0.25f));
		}
	}

	private void TechChanged()
	{
		if (Parent != null)
		{
			RefreshSubToggles();
			Parent.FeatureToggle();
			RefreshSpeedBoost(Parent.SequelTo, Parent.Framework, Parent.TeamSpecs);
		}
		RefreshTechLabel();
		TechProg.Value = _tech.GetRelevancy(ForcedCat ?? Parent.GetCategory());
	}

	private GameObject CreateHeader(int stars)
	{
		GameObject obj = new GameObject("Header");
		obj.AddComponent<RectTransform>().sizeDelta = new Vector2(0f, HeaderSprites[stars - 1].rect.height);
		obj.AddComponent<Image>().sprite = HeaderSprites[stars - 1];
		return obj;
	}

	public void UpdateTech(SoftwareCategory cat, Dictionary<string, SoftwareProduct> needs, IList<SoftwareProduct> OSs, bool direct = false)
	{
		string lim = null;
		TechLevel techLevel = GameSettings.Instance.simulation.TechLevels[Feature.Spec].Last();
		TechLevel latestTech = GameSettings.Instance.simulation.GetLatestTech(Feature.Spec, SDateTime.Now(), cat, GameSettings.Instance.MyCompany);
		TechLevel techLevel2 = cat.GetTechLimit(Feature, needs, null, ref lim, latestTech) ?? latestTech;
		_maxTech = techLevel2.Year;
		_maxTechReason = ((lim != null) ? "TechLimitedBy".Loc(lim) : ((latestTech.Year < techLevel.Year) ? "Missingresearch".Loc() : "NewestTech".Loc()));
		if (direct)
		{
			_tech = techLevel2;
			RefreshTechLabel();
		}
		else if (techLevel2.Year < Tech.Year)
		{
			Tech = techLevel2;
		}
		else
		{
			RefreshTechLabel();
		}
	}

	public void ChangeTech(TechLevel tech)
	{
		if (Parent.Framework != null)
		{
			TechLevel orDefault = Parent.Framework.TechLevels.GetOrDefault(Feature.Spec);
			if (orDefault != null && _tech.Year <= orDefault.Year && tech.Year > orDefault.Year)
			{
				WindowManager.Instance.ShowMessageBox("FrameworkLimitPrompt".Loc(), true, DialogWindow.DialogType.Warning, delegate
				{
					ActuallyChangeTech(tech);
				}, "FrameworkTechLimit");
				return;
			}
		}
		ActuallyChangeTech(tech);
	}

	private void ActuallyChangeTech(TechLevel tech)
	{
		Tech = tech;
	}

	public void ChangeTech(bool up)
	{
		if (!(Parent != null))
		{
			return;
		}
		Parent.CheckWithPublisher(delegate
		{
			if (up)
			{
				TechLevel techLevel = GameSettings.Instance.simulation.TechLevels[Feature.Spec].FirstOrDefault((TechLevel x) => x.Year > Tech.Year && x.Year <= _maxTech);
				if (techLevel != null)
				{
					ChangeTech(techLevel);
				}
			}
			else
			{
				TechLevel prevTech = GetPrevTech();
				if (prevTech.Year >= _minTech)
				{
					ChangeTech(prevTech);
				}
			}
		});
	}

	private TechLevel GetPrevTech()
	{
		List<TechLevel> list = GameSettings.Instance.simulation.TechLevels[Feature.Spec];
		TechLevel result = list[0];
		for (int i = 0; i < list.Count; i++)
		{
			TechLevel techLevel = list[i];
			if (techLevel.Year >= Tech.Year)
			{
				break;
			}
			result = techLevel;
		}
		return result;
	}

	private void RefreshTechLabel()
	{
		TechLevel.text = "Techlevel".Loc() + ": " + Tech.ActualYear;
		if (GameSettings.Instance.MyCompany.GetLatestResearch(Feature.Spec, -1) >= Tech.Year)
		{
			TechLevel.color = new Color(0f, 0.4f, 0f);
			TechLevel.fontStyle = FontStyle.Bold;
		}
		else
		{
			TechLevel.color = new Color(0.2f, 0.2f, 0.2f);
			TechLevel.fontStyle = FontStyle.Normal;
		}
		if (Tech.HasToPay(GameSettings.Instance.MyCompany))
		{
			Text techLevel = TechLevel;
			techLevel.text = techLevel.text + " (" + Tech.Royalty.ToPercent() + ")";
		}
		if (Tech.Year == _maxTech)
		{
			TechUp.interactable = false;
			TechUpTip.TooltipDescription = _maxTechReason;
		}
		else
		{
			TechUp.interactable = true;
			TechUpTip.TooltipDescription = null;
		}
		TechLevel prevTech = GetPrevTech();
		if (prevTech.Year < _minTech)
		{
			TechDown.interactable = false;
			TechDownTip.TooltipDescription = "UnlockTechLimit".Loc(1900 + _minTech);
		}
		else if (Tech == prevTech)
		{
			TechDown.interactable = false;
			TechDownTip.TooltipDescription = null;
		}
		else
		{
			TechDown.interactable = true;
			TechDownTip.TooltipDescription = null;
		}
		TechUpTip.UpdateTip();
		TechDownTip.UpdateTip();
	}
}
