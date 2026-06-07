using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UtilityInterface : MonoBehaviour
{
	public GUILineChart Chart;

	public GUILegend Legend;

	public Text[] ElecticityLabels;

	public Text[] WaterLabels;

	public Text[] GasLabels;

	public Text Hint;

	private bool _init;

	private bool _hourMode;

	private List<List<float>> _listCache = new List<List<float>>
	{
		new List<float>(),
		new List<float>(),
		new List<float>(),
		new List<float>()
	};

	private Func<float, string>[] _conversions = new Func<float, string>[3]
	{
		(float x) => x.ToString("0.#") + " " + "LiterAbbr".Loc(),
		(float x) => x.ToString("0.#") + "  m3",
		(float x) => (x * 1000f).GetWatt(true)
	};

	private List<Func<float, string>> _activeConversions = new List<Func<float, string>>();

	private void Init()
	{
		if (!_init)
		{
			_init = true;
			Chart.Values.Clear();
			Legend.Items.AddRange(new string[4]
			{
				"ElectricityConsumed".Loc(),
				"ElectricityProduced".Loc(),
				"WaterConsumed".Loc(),
				"GasConsumed".Loc()
			});
			Legend.OnToggle = UpdateChart;
			Legend.Colors = (Chart.Colors = HUD.GetThemeColors().ToList());
			Chart.HighlightCallback = delegate(int i)
			{
				Legend.Highlight(i);
			};
			Legend.HighlightCallback = delegate(int i)
			{
				Chart.Highlighted = i;
			};
			Legend.UpdateItems();
			Chart.ToolTipFunc = (int j, int i, float x) => _activeConversions[j](x);
			Hint.text = GameSettings.DaysPerMonth + " " + "Day".Loc().ToLower() + " = 1 " + "Month".Loc().ToLower();
		}
	}

	private void Start()
	{
		Init();
	}

	private void OnEnable()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Init();
			UpdateChart();
			UpdateLabels();
		}
	}

	public void SwitchMode(bool hour)
	{
		_hourMode = hour;
		UpdateChart();
	}

	private List<float> GetList(float[] arr, int i)
	{
		_listCache[i].Clear();
		_listCache[i].AddRange(arr);
		return _listCache[i];
	}

	private void UpdateChart()
	{
		Chart.Values.Clear();
		Chart.Colors.Clear();
		_activeConversions.Clear();
		if (_hourMode)
		{
			if (Legend.IsOn(0))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.HourWattUse, 0));
				Chart.Colors.Add(HUD.GetThemeColor(0));
				_activeConversions.Add(_conversions[2]);
			}
			if (Legend.IsOn(1))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.HourWattGen, 1));
				Chart.Colors.Add(HUD.GetThemeColor(1));
				_activeConversions.Add(_conversions[2]);
			}
			if (Legend.IsOn(2))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.HourWaterUse, 2));
				Chart.Colors.Add(HUD.GetThemeColor(2));
				_activeConversions.Add(_conversions[0]);
			}
			if (Legend.IsOn(3))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.HourGasUse, 3));
				Chart.Colors.Add(HUD.GetThemeColor(3));
				_activeConversions.Add(_conversions[1]);
			}
		}
		else
		{
			if (Legend.IsOn(0))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.MonthWattUse, 0));
				Chart.Colors.Add(HUD.GetThemeColor(0));
				_activeConversions.Add(_conversions[2]);
			}
			if (Legend.IsOn(1))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.MonthWattGen, 1));
				Chart.Colors.Add(HUD.GetThemeColor(1));
				_activeConversions.Add(_conversions[2]);
			}
			if (Legend.IsOn(2))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.MonthWaterUse, 2));
				Chart.Colors.Add(HUD.GetThemeColor(2));
				_activeConversions.Add(_conversions[0]);
			}
			if (Legend.IsOn(3))
			{
				Chart.Values.Add(GetList(GameSettings.Instance.MonthGasUse, 3));
				Chart.Colors.Add(HUD.GetThemeColor(3));
				_activeConversions.Add(_conversions[1]);
			}
		}
		Chart.UpdateCachedLines();
	}

	private void UpdateLabels()
	{
		ElecticityLabels[0].text = (GameSettings.Instance.ElectricityDelta + (double)GameSettings.Instance.ProductPrinters.SumSafe((ProductPrinter x) => (!(x.OwedWatt > 0f)) ? 0f : (x.Furn.Wattage * x.Furn.UseModifier))).GetWatt(false);
		ElecticityLabels[1].text = GameSettings.Instance.ElectricityGenerationDelta.GetWatt(false);
		float num = 0f;
		float num2 = 0f;
		for (int num3 = 0; num3 < GameSettings.Instance.Batteries.Count; num3++)
		{
			Battery battery = GameSettings.Instance.Batteries[num3];
			num += battery.CurrentCharge;
			num2 += battery.MaxCapacity;
		}
		ElecticityLabels[2].text = (num * 1000f).GetWatt(true) + " / " + (num2 * 1000f).GetWatt(true);
		ElecticityLabels[3].text = Furniture.GetElectricityPrice().Currency() + "/" + "KiloWattHour".Loc();
		ElecticityLabels[4].text = (GameSettings.Instance.ElectricityBill * Furniture.GetElectricityPrice()).Currency();
		ElecticityLabels[5].text = (GameSettings.Instance.ElectricityIncome * Furniture.GetElectricityPrice() * 0.25f).Currency();
		WaterLabels[0].text = GameSettings.Instance.WaterDelta.ToString("0.#") + " " + "LiterAbbr".Loc();
		WaterLabels[1].text = "NotApplicableAbbr".Loc();
		WaterLabels[2].text = "NotApplicableAbbr".Loc();
		WaterLabels[3].text = Furniture.GetWaterPrice().Currency() + "/" + "LiterAbbr".Loc();
		WaterLabels[4].text = (GameSettings.Instance.Waterbill * Furniture.GetWaterPrice()).Currency();
		WaterLabels[5].text = "NotApplicableAbbr".Loc();
		GasLabels[0].text = GameSettings.Instance.GasDelta.ToString("0.#") + " m3";
		GasLabels[1].text = "NotApplicableAbbr".Loc();
		GasLabels[2].text = "NotApplicableAbbr".Loc();
		GasLabels[3].text = Furniture.GetGasPrice().Currency() + "/m3";
		GasLabels[4].text = (GameSettings.Instance.Gasbill * Furniture.GetGasPrice()).Currency();
		GasLabels[5].text = "NotApplicableAbbr".Loc();
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.GameSpeed > 0f)
		{
			UpdateChart();
			UpdateLabels();
		}
	}
}
