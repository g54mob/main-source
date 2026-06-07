using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FrameworkWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView List;

	public Transform FeaturePanel;

	public FeatureCard FeatureCardPrefab;

	public Text CoverageLabel;

	public GameObject UseButton;

	[NonSerialized]
	private SoftwareCategory _cat;

	private HashSet<FeatureBase> _compFeatures;

	private List<FeatureCard> _featureCards = new List<FeatureCard>();

	private Action<SoftwareFramework> _onFinish;

	[NonSerialized]
	private SoftwareCategory _lastSelected;

	[NonSerialized]
	private SoftwareFramework _lastFramework;

	public GameObject ListPanel;

	public GameObject OKButton;

	public GameObject SplitDrag;

	public StretchPanel SplitPanel;

	[NonSerialized]
	private float? _lastSplit;

	private void Start()
	{
		List.OnSelectChange = delegate(bool x)
		{
			if (x)
			{
				RefreshFeaturePanel(List.GetSelected<SoftwareFramework>().FirstOrDefault());
			}
		};
	}

	public void ShowUsage()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("AllRelease");
		productWindow.Show(true, _lastFramework.Name, false, true);
		productWindow.SetFilters(true, true);
		productWindow.SetContent(from x in MarketSimulation.Active.GetAllProducts(true)
			where x.Framework == _lastFramework
			select x);
		productWindow.Window.SetParentWindow(Window);
	}

	public void Show(SoftwareFramework framework)
	{
		_lastFramework = framework;
		_cat = framework.Category;
		_compFeatures = framework.Features.Keys.ToHashSet();
		ListPanel.gameObject.SetActive(false);
		OKButton.gameObject.SetActive(false);
		SplitDrag.SetActive(false);
		_lastSplit = SplitPanel.Split;
		SplitPanel.Split = 0f;
		SplitPanel.SetSizes();
		RefreshFeaturePanel(framework);
		UseButton.SetActive(true);
		Window.Show();
	}

	public void Show(SoftwareCategory cat, Action<SoftwareFramework> onFinish, HashSet<FeatureBase> features)
	{
		_cat = cat;
		_compFeatures = features;
		_onFinish = onFinish;
		_lastFramework = null;
		List.Items = GameSettings.Instance.simulation.Frameworks.Where((SoftwareFramework x) => x.Category == _cat).Cast<object>().ToList();
		List.ClearSelected();
		RefreshFeaturePanel(List.GetSelected<SoftwareFramework>().FirstOrDefault());
		ListPanel.gameObject.SetActive(true);
		OKButton.gameObject.SetActive(true);
		SplitDrag.SetActive(true);
		if (_lastSplit.HasValue)
		{
			SplitPanel.Split = _lastSplit.Value;
			_lastSplit = null;
		}
		SplitPanel.Split = Mathf.Max(0.1f, SplitPanel.Split);
		SplitPanel.SetSizes();
		UseButton.SetActive(false);
		Window.Show();
	}

	public void Finish()
	{
		SoftwareFramework softwareFramework = List.GetSelected<SoftwareFramework>().FirstOrDefault();
		if (softwareFramework != null)
		{
			_onFinish(softwareFramework);
		}
		Window.Close();
	}

	public void RefreshFeaturePanel(SoftwareFramework sel)
	{
		bool flag = sel == null || sel.Category != _lastSelected;
		if (flag)
		{
			foreach (FeatureCard featureCard2 in _featureCards)
			{
				UnityEngine.Object.Destroy(featureCard2.gameObject);
			}
			_featureCards.Clear();
		}
		if (sel != null)
		{
			if (flag)
			{
				List<SubFeature> l = sel.Type.Features.Values.OfType<SubFeature>().ToList();
				foreach (SpecFeature item in sel.Type.Features.Values.OfType<SpecFeature>())
				{
					if (item.IsCompatible(_cat.Name))
					{
						FeatureCard featureCard = UnityEngine.Object.Instantiate(FeatureCardPrefab);
						featureCard.transform.SetParent(FeaturePanel, false);
						_featureCards.Add(featureCard);
						SpecFeature f1 = item;
						featureCard.Init(item, l.Where((SubFeature x) => x.IsCompatible(_cat.Name) && x.Spec.Equals(f1.Spec)), _cat);
					}
				}
			}
			double cov = 0.0;
			double sum = 0.0;
			foreach (FeatureCard featureCard3 in _featureCards)
			{
				featureCard3.SetTechDirect(sel.TechLevels.GetOrDefault(featureCard3.Feature.Spec));
				featureCard3.MainToggle.isOn = sel.Features.ContainsKey(featureCard3.Feature);
				UpdateCovered(featureCard3.Feature, sel.Features.GetOrDefault(featureCard3.Feature, 0.0), ref cov, ref sum);
				if (_compFeatures != null)
				{
					featureCard3.SetBoostDirect(_compFeatures);
				}
				foreach (KeyValuePair<SubFeature, Toggle> subFeature in featureCard3.SubFeatures)
				{
					subFeature.Value.isOn = sel.Features.ContainsKey(subFeature.Key);
					UpdateCovered(subFeature.Key, sel.Features.GetOrDefault(subFeature.Key, 0.0), ref cov, ref sum);
				}
			}
			cov = ((sum > 0.0) ? (cov / sum) : 0.0);
			CoverageLabel.text = "Coverage".Loc() + ": " + cov.ToPercent();
		}
		else
		{
			CoverageLabel.text = "Coverage".Loc() + ": " + 0f.ToPercent();
		}
		_lastSelected = ((sel != null) ? sel.Category : null);
	}

	private void UpdateCovered(FeatureBase feat, double p, ref double cov, ref double sum)
	{
		if (_compFeatures != null)
		{
			float devTime = feat.DevTime;
			if (_compFeatures.Contains(feat))
			{
				cov += p * (double)devTime;
				sum += devTime;
			}
		}
	}
}
