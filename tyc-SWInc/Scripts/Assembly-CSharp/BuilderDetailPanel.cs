using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BuilderDetailPanel : MonoBehaviour
{
	public bool IsStatic;

	public GameObject ProgressBarPrefab;

	public GameObject DoubleProgressBarPrefab;

	public GameObject BaseDetailPanel;

	public GameObject BonusDetailPanel;

	public GameObject RightSidePanel;

	public GameObject ConsumptionPanel;

	public GameObject UnlockPanel;

	public GameObject InfoPanel;

	public List<GameObject> ProgressBars = new List<GameObject>();

	public Image Thumbnail;

	public CanvasGroup AlphaGroup;

	public Text Name;

	public Text Price;

	public Text Description;

	public Text BonusTitle;

	public Text Unlock;

	public Text Info;

	[NonSerialized]
	public Tweener dTween;

	[NonSerialized]
	private Sprite[] _thumbs;

	[NonSerialized]
	private bool _hasAddedConsPanel;

	[NonSerialized]
	private bool _hasAddedBonusPanel;

	[NonSerialized]
	private bool _hasAddedBasePanel;

	[NonSerialized]
	private bool _hasBonusInfo;

	public void Disable()
	{
		if (!IsStatic)
		{
			dTween = AlphaGroup.DOFade(0f, 0.2f).OnComplete(delegate
			{
				dTween = null;
				base.gameObject.SetActive(false);
			});
		}
	}

	private void EnableMe()
	{
		if (!IsStatic)
		{
			if (dTween != null)
			{
				dTween.Kill();
				dTween = null;
			}
			base.gameObject.SetActive(true);
			if (AlphaGroup.alpha < 1f)
			{
				AlphaGroup.DOFade(1f, 0.2f);
			}
		}
	}

	private void DestroyProgressBars()
	{
		foreach (GameObject progressBar in ProgressBars)
		{
			UnityEngine.Object.Destroy(progressBar);
		}
		ProgressBars.Clear();
		_hasAddedBonusPanel = false;
		_hasAddedConsPanel = false;
		_hasAddedBasePanel = false;
		_hasBonusInfo = false;
	}

	public void SetGeneric(string name, string description, Sprite thumbnail, float price, string locked)
	{
		DestroyProgressBars();
		EnableMe();
		Name.text = name;
		Description.text = description;
		Thumbnail.sprite = thumbnail;
		_thumbs = null;
		Price.text = ((price > 0f) ? price.Currency() : "");
		if (locked == null)
		{
			UnlockPanel.SetActive(false);
		}
		else
		{
			UnlockPanel.SetActive(true);
			Unlock.text = locked.Loc();
		}
		UpdateLayout();
	}

	private void Update()
	{
		if (_thumbs != null)
		{
			Thumbnail.sprite = _thumbs[Mathf.FloorToInt(Time.realtimeSinceStartup * 2f) % _thumbs.Length];
		}
	}

	public void SetFurniture(Furniture furn, AwardTrophy.AwardData award)
	{
		HUD.Instance.SetFurnitureNew(furn, false);
		List<Furniture> list = (from x in ObjectDatabase.Instance.GetAllFurniture()
			select x.GetComponent<Furniture>()).ToList();
		DestroyProgressBars();
		EnableMe();
		_thumbs = null;
		if (award != null)
		{
			Name.text = award.Type.ToString().Loc() + " " + award.Year + " - " + award.Tier.ToString().Loc();
			if (award.For != null)
			{
				Text text = Name;
				text.text = text.text + " (" + award.For + ")";
			}
			Description.text = string.Concat((AwardTrophy.BuffType)award.Type, "AwardBuffDesc").Loc();
			Thumbnail.sprite = ObjectDatabase.Instance.GetAwardSprite(award);
		}
		else
		{
			string[] furniture = Localization.GetFurniture(furn.GetLocalizationName(), furn.GetDefaultName(), furn.ButtonDescription);
			Name.text = furniture[0];
			Description.text = ((furniture.Length > 1) ? furniture[1].Format() : "");
			ObjectDatabase.ReplacementGroup group;
			if (furn.ReplacementGroups != null && furn.ReplacementGroups.Length == 1 && ObjectDatabase.Instance.GetReplacementGroup(furn.ReplacementGroups[0], out group))
			{
				ObjectDatabase.ReplacementObject replacementObject = group.Replacements[Mathf.FloorToInt(Time.realtimeSinceStartup) % group.Replacements.Count];
				_thumbs = (from x in @group.Replacements
					where x.Thumbnail != null
					select x.Thumbnail).ToArray();
				if (_thumbs.Length != 0)
				{
					Thumbnail.sprite = _thumbs[0];
				}
				else
				{
					_thumbs = null;
					Thumbnail.sprite = furn.Thumbnail;
				}
			}
			else
			{
				Thumbnail.sprite = furn.Thumbnail;
			}
		}
		string text2 = ("FurnDesc" + furn.Type).LocDef(null);
		_hasBonusInfo = text2 != null;
		_hasAddedBonusPanel = _hasBonusInfo;
		InfoPanel.SetActive(_hasBonusInfo);
		if (_hasBonusInfo)
		{
			Info.text = Utilities.RobustStringFormat(text2, true, false);
		}
		Price.text = ((award != null) ? AwardTrophy.GetAwardWorth(award.Tier, award.Year).Currency() : furn.GetCost().Currency());
		if (award != null)
		{
			AddProgressBar(BaseDetailPanel, "Effectiveness".Loc(), AwardTrophy.GetAwardEffectiveness(award.Tier, award.Year), false, false, true);
		}
		if (furn.Type.Equals("Chair"))
		{
			string input = (((double)furn.MiscPotential < 0.5) ? "Bad" : ((furn.MiscPotential > 0.5f) ? "Good" : "Neutral"));
			AddProgressBar(BaseDetailPanel, "Ergonomics".Loc() + ": " + input.Loc(), furn.MiscPotential * 2f - 1f, true, false);
		}
		if (furn.Comfort > 0f)
		{
			float num = list.Where((Furniture x) => x.Type.Equals(furn.Type)).Max((Furniture x) => x.Comfort);
			AddProgressBar(BaseDetailPanel, "Comfort".Loc(), furn.Comfort / num, false, false);
		}
		if (furn.Type.Equals("Coffee"))
		{
			float num2 = list.Where((Furniture x) => x.Type.Equals(furn.Type)).Max((Furniture x) => x.MiscPotential);
			AddProgressBar(BaseDetailPanel, "Quality".Loc(), furn.MiscPotential / num2, false, false, true);
		}
		if (furn.Type.Equals("Battery"))
		{
			float num3 = list.Where((Furniture x) => x.Type.Equals(furn.Type)).Max((Furniture x) => x.GetComponent<Battery>().MaxCapacity);
			float maxCapacity = furn.GetComponent<Battery>().MaxCapacity;
			AddProgressBar(BaseDetailPanel, "Capacity".Loc() + ": " + (maxCapacity * 1000f).GetWatt(true), maxCapacity / num3, false, false, true);
		}
		if (furn.Wattage < 0f)
		{
			float num4 = list.Where((Furniture x) => x.Wattage < 0f).Max((Furniture x) => 0f - x.Wattage);
			AddProgressBar(BaseDetailPanel, "PotentialSavings".Loc() + ": " + 0f.Currency() + " - " + ((0f - furn.Wattage) * 0.03f * furn.ExpectedOn * Furniture.GetElectricityPrice()).Currency() + "/" + "Month".Loc(), (0f - furn.Wattage) / num4, false, false, true);
		}
		if (furn.Type.Equals("Computer"))
		{
			AddProgressBar(BaseDetailPanel, "Power".Loc(), furn.ComputerPower, false, false, true);
		}
		if (furn.Type.Equals("Server"))
		{
			Server component = furn.GetComponent<Server>();
			if (component != null)
			{
				float num5 = (from x in list
					select x.GetComponent<Server>() into x
					where x != null
					select x).Max((Server x) => x.Power);
				AddProgressBar(BaseDetailPanel, "Bandwidth".Loc() + ": " + component.Power.Bandwidth(), Mathf.Sqrt(component.Power / num5), false, false, true);
			}
		}
		if (furn.Type.Equals("Tray") && furn.HoldablePoints.Length != 0)
		{
			float num6 = list.Max((Furniture x) => x.HoldablePoints.Length);
			AddProgressBar(BaseDetailPanel, "Capacity".Loc() + ": " + furn.HoldablePoints.Length, (float)furn.HoldablePoints.Length / num6, false, false, true);
		}
		if (furn.Type.Equals("ProductPrinter"))
		{
			ProductPrinter printer = furn.Printer;
			if (printer != null)
			{
				float num7 = (from x in list.SelectNotNull((Furniture x) => x.Printer)
					where x.Type == printer.Type
					select x).Max((ProductPrinter x) => x.PrintAmount);
				AddProgressBar(BaseDetailPanel, "CopyPerBox".Loc(printer.PrintAmount), (float)printer.PrintAmount / num7, false, false, true);
				if (!printer.IsManufacturing())
				{
					float num8 = (from x in list.SelectNotNull((Furniture x) => x.Printer)
						where x.Type == printer.Type
						select x).Max((ProductPrinter x) => x.PrintSpeed * (float)x.PrintAmount);
					float num9 = printer.PrintSpeed * (float)printer.PrintAmount;
					AddProgressBar(BaseDetailPanel, "CopyPerMonth".Loc(num9 * 24f), num9 / num8, false, false, true);
					float num10 = (from x in list.SelectNotNull((Furniture x) => x.Printer)
						where x.Type == printer.Type
						select x).Max((ProductPrinter x) => x.PrintPrice);
					AddProgressBar(ConsumptionPanel, "PricePerCopy".Loc(printer.PrintPrice.Currency()), printer.PrintPrice / num10, false, true, true);
				}
			}
		}
		if (furn.HasConveyor && furn.Type.Equals("Conveyor") && furn.Conveyor.Speed > 0f)
		{
			float num11 = list.Where((Furniture x) => x.HasConveyor).Max((Furniture x) => x.Conveyor.Speed);
			AddProgressBar(BaseDetailPanel, "BoxPerMinute".Loc(furn.Conveyor.Speed), furn.Conveyor.Speed / num11, false, false);
		}
		if (furn.TempControlType != Furniture.TemperatureType.None)
		{
			float num12 = list.Where((Furniture x) => x.TempControlType == furn.TempControlType && x.TemperatureController == furn.TemperatureController).Max((Furniture x) => x.HeatCoolArea);
			AddProgressBar(BaseDetailPanel, "Area".Loc() + ": " + furn.HeatCoolArea + " m2", Mathf.Sqrt(furn.HeatCoolArea / num12), false, false, true);
		}
		if (furn.Lighting > 0f)
		{
			float num13 = list.Max((Furniture x) => x.Lighting);
			AddProgressBar(BaseDetailPanel, "Lighting".Loc(), furn.Lighting / num13, false, false);
		}
		if (furn.AirCleaning > 0f)
		{
			float num14 = list.Max((Furniture x) => x.AirCleaning);
			AddProgressBar(BaseDetailPanel, "AirFiltration".Loc() + ": " + furn.AirCleaning + " m2 per hour", furn.AirCleaning / num14, false, false, true);
		}
		else if (furn.AirCleaning < 0f)
		{
			float num15 = list.Max((Furniture x) => 0f - x.AirCleaning);
			AddProgressBar(BaseDetailPanel, "AirPollution".Loc() + ": " + (0f - furn.AirCleaning) + " m2 per hour", (0f - furn.AirCleaning) / num15, false, true, true);
		}
		if (furn.Environment != 1f)
		{
			if (furn.Environment > 1f)
			{
				float num16 = list.Max((Furniture x) => x.Environment) - 1f;
				AddProgressBar(BaseDetailPanel, "Environment".Loc(), (furn.Environment - 1f) / num16, true, false);
			}
			else
			{
				float num17 = 0f - (list.Min((Furniture x) => x.Environment) - 1f);
				AddProgressBar(BaseDetailPanel, "Environment".Loc(), (furn.Environment - 1f) / num17, true, false);
			}
		}
		if (furn.Noisiness > 0f)
		{
			float num18 = list.Max((Furniture x) => x.Noisiness);
			AddProgressBar(BaseDetailPanel, "Noise".Loc(), 1f - Mathf.Pow(1f - furn.Noisiness / num18, 3f), false, true);
		}
		Upgradable component2 = furn.GetComponent<Upgradable>();
		if (component2 != null)
		{
			float num19 = 0f;
			float num20 = 0f;
			for (int num21 = 0; num21 < list.Count; num21++)
			{
				Furniture furniture2 = list[num21];
				Upgradable component3 = furniture2.GetComponent<Upgradable>();
				if (component3 != null)
				{
					num20 = Mathf.Max(num20, component3.FireStarter);
					if (furniture2.Type.Equals(furn.Type))
					{
						num19 = Mathf.Max(num19, component3.TimeToAtrophy * 24f / furniture2.ExpectedOn);
					}
				}
			}
			float num22 = component2.TimeToAtrophy * 24f / furn.ExpectedOn;
			AddProgressBar(ConsumptionPanel, "Durability".Loc() + ": " + "Month".LocPlural((int)num22), num22 / num19, false, false);
			if (component2.FireStarter > 0f)
			{
				AddProgressBar(ConsumptionPanel, "Flammability".Loc() + ": " + component2.FireStarter.ToPercent(), component2.FireStarter / num20, false, true, true);
			}
		}
		if (furn.Water > 0f)
		{
			float num23 = list.Where((Furniture x) => x.Water > 0f).Max((Furniture x) => x.Water);
			AddProgressBar(ConsumptionPanel, "Water".Loc() + ": " + furn.Water + " " + "LiterAbbr".Loc(), Mathf.Sqrt(furn.Water / num23), false, true);
		}
		if (furn.Wattage > 0f)
		{
			float num24 = list.Where((Furniture x) => x.Wattage > 0f).Max((Furniture x) => x.Wattage);
			AddProgressBar(ConsumptionPanel, "Electricity".Loc() + ": " + furn.Wattage.GetWatt(false), Mathf.Sqrt(furn.Wattage / num24), false, true);
		}
		if (furn.Wattage < 0f)
		{
			float num25 = list.Where((Furniture x) => x.Wattage < 0f).Max((Furniture x) => 0f - x.Wattage);
			AddProgressBar(ConsumptionPanel, "MaxProduction".Loc() + ": " + (0f - furn.Wattage).GetWatt(false), Mathf.Sqrt((0f - furn.Wattage) / num25), false, false, true);
		}
		if (furn.Gas > 0f)
		{
			float num26 = list.Where((Furniture x) => x.Gas > 0f).Max((Furniture x) => x.Gas);
			AddProgressBar(ConsumptionPanel, "Gas".Loc() + ": " + furn.Gas + " m3", Mathf.Sqrt(furn.Gas / num26), false, true);
		}
		float costs = GetCosts(furn);
		if (costs > 0f)
		{
			float num27 = float.MaxValue;
			float num28 = float.MinValue;
			foreach (Furniture item in list)
			{
				if (item.Type.Equals(furn.Type))
				{
					float costs2 = GetCosts(item);
					num27 = Mathf.Min(num27, costs2);
					num28 = Mathf.Max(num28, costs2);
				}
			}
			string text3 = GetUsageLabel(costs);
			if (furn.Type.Equals("Server"))
			{
				text3 += "/Mbps";
			}
			AddProgressBar(ConsumptionPanel, "RunningCosts".Loc() + ": " + text3, (num28 == num27) ? 0f : costs.MapRange(num27, num28, 0f, 1f), false, true);
		}
		if (furn.Capacity > 0)
		{
			float num29 = list.Where((Furniture x) => x.Type.Equals(furn.Type)).Max((Furniture x) => x.Capacity);
			string text4 = "Capacity".Loc() + ": " + furn.Capacity;
			if (furn.Expiration > 0)
			{
				text4 = text4 + ", " + "FoodExpiration".Loc() + ": " + "Month".LocPlural(furn.Expiration);
			}
			AddProgressBar(ConsumptionPanel, text4, (float)furn.Capacity / num29, false, false, true);
			if (furn.RefillCapacity && furn.UnitCost > 0f)
			{
				string label = ((furn.Expiration == 0) ? ("MonthlyRefillCost".Loc() + ": " + ((float)furn.Capacity * furn.UnitCost).Currency()) : ("MonthlyRefillCost".Loc() + ": " + furn.UnitCost.Currency() + " x " + furn.Capacity + " = " + ((float)furn.Capacity * furn.UnitCost).Currency()));
				num29 = list.Where((Furniture x) => x.Type.Equals(furn.Type)).Max((Furniture x) => x.UnitCost);
				AddProgressBar(ConsumptionPanel, label, furn.UnitCost / num29, false, true, true);
			}
		}
		if (!furn.IsPlayerControlled())
		{
			UnlockPanel.SetActive(true);
			Unlock.text = "Landlord".Loc();
		}
		else if (!GameSettings.Instance.EditMode)
		{
			if (TimeOfDay.Instance.Year + 1900 < furn.UnlockYear)
			{
				UnlockPanel.SetActive(true);
				Unlock.text = furn.UnlockYear.ToString();
			}
			else if (!string.IsNullOrEmpty(furn.UnlockMission) && !GameSettings.HasCompletedOrInMission(furn.UnlockMission))
			{
				UnlockPanel.SetActive(true);
				Unlock.text = "Campaign".Loc();
			}
			else if (!string.IsNullOrEmpty(furn.Unlockable) && !GameSettings.Instance.HasClaimedReward(furn.Unlockable))
			{
				UnlockPanel.SetActive(true);
				Unlock.text = "MissingTaskUnlock".Loc();
			}
			else
			{
				UnlockPanel.SetActive(false);
			}
		}
		else
		{
			UnlockPanel.SetActive(false);
		}
		BonusTitle.gameObject.SetActive(false);
		if (furn.UseEffects != null && furn.UseEffects.Length != 0)
		{
			bool flag = false;
			BonusTitle.text = "BonusEffects".Loc() + ":";
			for (int num30 = 0; num30 < furn.UseEffects.Length; num30++)
			{
				if (furn.UseEffects[num30] > 0f)
				{
					flag = true;
					GameObject bonusDetailPanel = BonusDetailPanel;
					Furniture.UseEffect useEffect = (Furniture.UseEffect)num30;
					AddProgressBar(bonusDetailPanel, useEffect.ToString().Loc(), furn.UseEffects[num30], false, false, true);
				}
			}
			if (!flag && _hasBonusInfo)
			{
				BonusTitle.text = "";
			}
			BonusTitle.gameObject.SetActive(true);
		}
		else if (furn.AuraValues != null && furn.AuraValues.Length != 0 && furn.AuraValues.Any((float x) => x > -1f))
		{
			BonusTitle.text = "Roomboost".Loc() + ":";
			for (int num31 = 0; num31 < furn.AuraValues.Length; num31++)
			{
				if (furn.AuraValues[num31] != -1f && furn.AuraValues[num31] != 0f)
				{
					GameObject bonusDetailPanel2 = BonusDetailPanel;
					Furniture.AuraTypes auraTypes = (Furniture.AuraTypes)num31;
					AddProgressBar(bonusDetailPanel2, auraTypes.ToString().Loc(), Mathf.Clamp(furn.AuraValues[num31] / 0.25f, -1f, 1f), true, false);
				}
			}
			BonusTitle.gameObject.SetActive(true);
		}
		else if (_hasBonusInfo)
		{
			BonusTitle.text = "";
		}
		UpdateLayout();
	}

	private static float GetCosts(Furniture f)
	{
		float num = 0f;
		if (f.Water > 0f)
		{
			num += f.Water * f.ExpectedOn * Furniture.GetWaterPrice() * 30f;
		}
		if (f.Gas > 0f)
		{
			num += f.Gas * f.ExpectedOn * Furniture.GetGasPrice() * 30f;
		}
		if (f.Wattage > 0f)
		{
			float num2 = f.Wattage / 1000f * f.ExpectedOn * Furniture.GetElectricityPrice() * 30f;
			if (f.Type.Equals("Server"))
			{
				num2 /= f.GetComponent<Server>().Power;
			}
			num += num2;
		}
		return num;
	}

	private static float GetPower(Furniture f)
	{
		Server component = f.GetComponent<Server>();
		if (component != null)
		{
			return component.Power;
		}
		return 1f;
	}

	private string GetUsageLabel(float amount)
	{
		if (amount > 1f)
		{
			amount = Mathf.Ceil(amount);
		}
		return "ApproximatelyAbbr".Loc() + " " + amount.Currency() + "/" + "Month".Loc();
	}

	private string GetUsageLabel(float expOn, float amount, bool appx)
	{
		if (expOn < 24f || appx)
		{
			float num = amount * expOn / 24f;
			if (num > 1f)
			{
				num = Mathf.Ceil(num);
			}
			return "ApproximatelyAbbr".Loc() + " " + num.Currency() + "/" + "Month".Loc();
		}
		return Mathf.Ceil(amount).Currency() + "/" + "Month".Loc();
	}

	private void UpdateLayout()
	{
		Canvas.ForceUpdateCanvases();
		BonusDetailPanel.SetActive(_hasAddedBonusPanel);
		ConsumptionPanel.SetActive(_hasAddedConsPanel);
		RightSidePanel.SetActive(_hasBonusInfo || BonusDetailPanel.activeSelf || ConsumptionPanel.activeSelf);
		if (!RightSidePanel.activeSelf && !_hasAddedBasePanel)
		{
			BaseDetailPanel.SetActive(false);
			GetComponent<RectTransform>().sizeDelta = new Vector2(518f, 108f);
		}
		else
		{
			BaseDetailPanel.SetActive(true);
			GetComponent<RectTransform>().sizeDelta = new Vector2(518f, 192f);
		}
		Canvas.ForceUpdateCanvases();
		foreach (GUIProgressBar item in ProgressBars.Select((GameObject x) => x.GetComponent<GUIProgressBar>()))
		{
			item.Value = item.Value;
		}
	}

	public void AddProgressBar(GameObject panel, string label, float value, bool dbl, bool bad, bool Solid = false)
	{
		if (!_hasAddedConsPanel && panel == ConsumptionPanel)
		{
			_hasAddedConsPanel = true;
		}
		else if (!_hasAddedBonusPanel && panel == BonusDetailPanel)
		{
			_hasAddedBonusPanel = true;
		}
		else if (!_hasAddedBasePanel && panel == BaseDetailPanel)
		{
			_hasAddedBasePanel = true;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(dbl ? DoubleProgressBarPrefab : ProgressBarPrefab);
		GUIProgressBar component = gameObject.GetComponent<GUIProgressBar>();
		if (bad)
		{
			Color startColor = component.StartColor;
			component.StartColor = component.EndColor;
			component.EndColor = startColor;
		}
		else if (!dbl)
		{
			component.StartColor = component.EndColor;
		}
		if (Solid)
		{
			component.StartColor = component.EndColor;
		}
		gameObject.GetComponentInChildren<Text>().text = label;
		ProgressBars.Add(gameObject);
		gameObject.transform.SetParent(panel.transform, false);
		component.Value = value;
	}
}
