using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TechUpdatePanel : MonoBehaviour
{
	public Text Spec;

	public Text Level;

	public Image Header;

	public Color ActiveColor;

	public Color InactiveColor;

	public GUIToolTipper IncTip;

	public Button Dec;

	public Button Inc;

	[NonSerialized]
	private SoftwareProduct _product;

	[NonSerialized]
	private SoftwareFramework _framework;

	[NonSerialized]
	private TechLevel _tech;

	private string _spec;

	[NonSerialized]
	private SpecFeature _specFeat;

	private int _maxTech;

	private string _maxTechReason;

	[NonSerialized]
	public UpdateWindow Parent;

	public TechLevel Tech
	{
		get
		{
			return _tech;
		}
	}

	public SpecFeature SpecFeat
	{
		get
		{
			return _specFeat;
		}
	}

	private TechLevel GetPrevTech()
	{
		List<TechLevel> list = GameSettings.Instance.simulation.TechLevels[_spec];
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

	public void ChangeTech(bool up)
	{
		bool flag = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		if (up)
		{
			TechLevel techLevel = (flag ? GameSettings.Instance.simulation.TechLevels[_spec].LastOrDefault((TechLevel x) => x.Year > Tech.Year && x.Year <= _maxTech) : GameSettings.Instance.simulation.TechLevels[_spec].FirstOrDefault((TechLevel x) => x.Year > Tech.Year && x.Year <= _maxTech));
			if (techLevel != null)
			{
				ChangeTech(techLevel);
			}
		}
		else
		{
			TechLevel techLevel2 = ((flag && _product != null) ? _product.TechLevels[_spec] : GetPrevTech());
			if (techLevel2.Year >= Parent.GetTechs()[_spec].Year)
			{
				ChangeTech(techLevel2);
			}
		}
	}

	private void ChangeTech(TechLevel t)
	{
		_tech = t;
		Refresh();
		Parent.RefreshActiveTech();
		Parent.RefreshTooling();
	}

	private void Refresh()
	{
		Level.text = _tech.ActualYear.ToString();
		if (_tech.HasToPay(GameSettings.Instance.MyCompany))
		{
			Text level = Level;
			level.text = level.text + " (" + _tech.Royalty.ToPercent() + ")";
		}
		Header.color = (Active() ? ActiveColor : InactiveColor);
		if (Tech.Year == _maxTech)
		{
			Inc.interactable = false;
			IncTip.TooltipDescription = _maxTechReason;
		}
		else
		{
			Inc.interactable = true;
			IncTip.TooltipDescription = null;
		}
		if (Tech.Year <= GameSettings.Instance.MyCompany.GetLatestResearch(_spec, -1))
		{
			Text level2 = Level;
			level2.text = level2.text + " (" + "Researched".Loc() + ")";
		}
		TechLevel prevTech = GetPrevTech();
		int year = Parent.GetTechs()[_spec].Year;
		if (_tech.Year <= year)
		{
			Dec.interactable = false;
		}
		else if (Tech == prevTech)
		{
			Dec.interactable = false;
		}
		else
		{
			Dec.interactable = true;
		}
		IncTip.UpdateTip();
	}

	public void RefreshLimits()
	{
		string lim = null;
		TechLevel techLevel = GameSettings.Instance.simulation.TechLevels[_spec].Last();
		TechLevel latestTech = GameSettings.Instance.simulation.GetLatestTech(_spec, SDateTime.Now(), GetCategory(), GameSettings.Instance.MyCompany);
		TechLevel techLevel2 = latestTech;
		if (_product != null)
		{
			techLevel2 = GetCategory().GetTechLimit(_specFeat, Parent.Tools, null, ref lim, latestTech) ?? latestTech;
			string[] needsFromSpec = GetSWType().GetNeedsFromSpec(_spec, GetFeatures());
			if (needsFromSpec != null && needsFromSpec.Length != 0)
			{
				HashSet<string> hashSet = needsFromSpec.ToHashSet();
				int num = 0;
				TechLevel techLevel3 = null;
				foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(true))
				{
					TechLevel value;
					if (hashSet.Contains(allProduct.Type.Name) && allProduct.TechLevels.TryGetValue(_spec, out value) && value.Year > num)
					{
						num = value.Year;
						techLevel3 = value;
						if (num >= techLevel2.Year)
						{
							break;
						}
					}
				}
				if (techLevel3 != null && num < techLevel2.Year)
				{
					lim = "Marketplace".Loc().ToLower();
					techLevel2 = techLevel3;
				}
			}
		}
		_maxTech = techLevel2.Year;
		_maxTechReason = ((lim != null) ? "TechLimitedBy".Loc(lim) : ((latestTech.Year < techLevel.Year) ? "Missingresearch".Loc() : "NewestTech".Loc()));
		if (techLevel2.Year < _tech.Year)
		{
			_tech = techLevel2;
		}
		Refresh();
	}

	public Dictionary<string, TechLevel> GetTechs()
	{
		if (_product == null)
		{
			return _framework.TechLevels;
		}
		return _product.TechLevels;
	}

	public SoftwareType GetSWType()
	{
		if (_product == null)
		{
			return _framework.Type;
		}
		return _product.Type;
	}

	public SoftwareCategory GetCategory()
	{
		if (_product == null)
		{
			return _framework.Category;
		}
		return _product.Category;
	}

	public IList<FeatureBase> GetFeatures()
	{
		if (_product == null)
		{
			return _framework.Features.Keys.ToList();
		}
		return _product.Features;
	}

	public bool Active()
	{
		if (base.gameObject.activeSelf)
		{
			return Tech.Year > GetTechs()[_spec].Year;
		}
		return false;
	}

	public void Init(SoftwareProduct p, string spec)
	{
		_product = p;
		_framework = null;
		_spec = spec;
		_specFeat = p.Features.OfType<SpecFeature>().FirstOrDefault((SpecFeature x) => x.Spec == _spec);
		Spec.text = _spec.Loc();
		_tech = _product.TechLevels[_spec];
		RefreshLimits();
	}

	public void Init(SoftwareFramework f, string spec)
	{
		_product = null;
		_framework = f;
		_spec = spec;
		_specFeat = f.Features.Keys.OfType<SpecFeature>().FirstOrDefault((SpecFeature x) => x.Spec == _spec);
		Spec.text = _spec.Loc();
		_tech = _framework.TechLevels[_spec];
		RefreshLimits();
	}
}
