using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class CompanyChart : MonoBehaviour
{
	private class Ranger
	{
		private RangeSlider _slider;

		public int this[int i]
		{
			get
			{
				switch (i)
				{
				case 0:
					return (int)_slider.MinValue;
				case 1:
					return (int)_slider.MaxValue;
				case 2:
					return (int)_slider.LowValue;
				case 3:
					return (int)Mathf.Max(0f, _slider.HighValue - _slider.LowValue);
				default:
					return 0;
				}
			}
			set
			{
				switch (i)
				{
				case 0:
					_slider.MinValue = value;
					break;
				case 1:
					_slider.MaxValue = value;
					break;
				case 2:
				{
					float num = _slider.HighValue - _slider.LowValue;
					if ((float)value > _slider.HighValue)
					{
						_slider.HighValue = value;
					}
					_slider.LowValue = value;
					_slider.HighValue = _slider.LowValue + num;
					break;
				}
				case 3:
					_slider.HighValue = Mathf.Max(_slider.LowValue + 1f, _slider.LowValue + (float)value);
					break;
				}
			}
		}

		public Ranger(RangeSlider slider)
		{
			_slider = slider;
		}
	}

	public GUIWindow Window;

	public GUILineChart LineChart;

	public GUILegend Legend;

	public SDateTime LastDate = new SDateTime(-1, -1);

	public bool Stats;

	[NonSerialized]
	public Company TCompany;

	public ChartLabel HorizLabel;

	public ChartLabel VertLabel;

	public GUICombobox GranularityCombo;

	private bool UpdatingScroll;

	public RangeSlider Slider;

	private int _lastGranularity = 1;

	private Ranger Range;

	public static readonly int[] Granularities = new int[3] { 1, 3, 12 };

	public static Dictionary<string, Func<float, string>> _toolTipConv = new Dictionary<string, Func<float, string>>
	{
		{
			"StockExchange",
			(float x) => x.Currency()
		},
		{
			"ServerBandwidth",
			(float x) => x.Bandwidth()
		}
	};

	private int Granularity
	{
		get
		{
			return Granularities[Mathf.Max(0, GranularityCombo.Selected)];
		}
	}

	private void Start()
	{
		Legend.OnToggle = UpdateChart;
		Legend.Colors = (LineChart.Colors = HUD.GetThemeColors().ToList());
		Legend.Sheet = true;
		LineChart.HighlightCallback = delegate(int i)
		{
			Legend.Highlight(i);
		};
		Legend.HighlightCallback = delegate(int i)
		{
			LineChart.Highlighted = i;
		};
		GranularityCombo.UpdateContent(new string[3] { "Monthly", "Quarterly", "Yearly" });
	}

	public void ToggleStatMode(bool stat)
	{
		Stats = stat;
		LineChart.Currency = !stat;
		Legend.Items.Clear();
		UpdateChart();
	}

	public void OnScroll(PointerEventData d)
	{
		int num = -(int)d.scrollDelta.y;
		if (num > 0)
		{
			if (Range[3] != Range[1])
			{
				if (Slider.HighValue == Slider.MaxValue || Range[3] % 2 == 0)
				{
					Range[2]--;
				}
				Range[3]++;
			}
		}
		else if (num < 0 && Range[2] < Range[1] - 1)
		{
			if (Slider.HighValue == Slider.MaxValue)
			{
				Range[2]++;
			}
			else if (Slider.LowValue > Slider.MinValue && Range[3] % 2 == 0)
			{
				Range[2]++;
				Range[3]--;
			}
			else
			{
				Range[3]--;
			}
		}
		UpdateScroll();
	}

	public void UpdateScroll()
	{
		if (!UpdatingScroll)
		{
			UpdateChart();
			UpdatingScroll = false;
		}
	}

	private void Update()
	{
		if (LastDate.Year != TimeOfDay.Instance.Year || LastDate.Month != TimeOfDay.Instance.Month)
		{
			LastDate = SDateTime.Now();
			UpdateChart();
		}
	}

	public void UpdateLabels(List<List<float>> values)
	{
		bool num = values.Count > 0;
		float num2 = (num ? values.Select((List<float> x) => (x.Count <= 0) ? 0f : x.Min()).Min() : 0f);
		float num3 = (num ? values.Select((List<float> x) => (x.Count <= 0) ? 0f : x.Max()).Max() : 0f);
		if (Stats)
		{
			VertLabel.Label1.text = num3.ToString("F0");
			VertLabel.Label2.text = num2.ToString("F0");
		}
		else
		{
			float f = Mathf.Max(Mathf.Abs(num2), Mathf.Abs(num3));
			f = Mathf.Pow(10f, Mathf.Floor(Mathf.Log10(f)));
			VertLabel.Label1.text = ((f == 0f) ? 0f.Currency() : num3.CurrencyRoundUpToNearest(f).Currency());
			VertLabel.Label2.text = ((f == 0f) ? 0f.Currency() : num2.CurrencyRoundDownToNearest(f).Currency());
		}
		int granularity = Granularity;
		switch (granularity)
		{
		case 12:
			HorizLabel.Label1.text = (TCompany.Founded.RealYear + Range[2]).ToString();
			HorizLabel.Label2.text = (TCompany.Founded.RealYear + Mathf.Min(Range[1] - 1, Range[2] + Range[3] - 1)).ToString();
			break;
		case 3:
		{
			SDateTime sDateTime3 = TCompany.Founded + new SDateTime(Range[2] * granularity, 0);
			SDateTime sDateTime4 = TCompany.Founded + new SDateTime(Mathf.Min(Range[1] - 1, Range[2] + Range[3] - 1) * granularity, 0);
			HorizLabel.Label1.text = sDateTime3.ToQuarterString();
			HorizLabel.Label2.text = sDateTime4.ToQuarterString();
			break;
		}
		default:
		{
			SDateTime sDateTime = TCompany.Founded + new SDateTime(Range[2], 0);
			SDateTime sDateTime2 = TCompany.Founded + new SDateTime(Mathf.Min(Range[1] - 1, Range[2] + Range[3] - 1), 0);
			HorizLabel.Label1.text = sDateTime.ToCompactString();
			HorizLabel.Label2.text = sDateTime2.ToCompactString();
			break;
		}
		}
	}

	public void UpdateChart()
	{
		if (TCompany == null)
		{
			return;
		}
		if (Range == null)
		{
			Range = new Ranger(Slider);
		}
		List<KeyValuePair<string, List<float>>> list = (Stats ? GameSettings.Instance.MiscStats.ToList() : TCompany.Cashflow.Where((KeyValuePair<string, List<float>> x) => x.Value.Sum() != 0f).ToList());
		if (list.Count > 0)
		{
			int granularity = Granularity;
			if (granularity != _lastGranularity)
			{
				int num = TCompany.Founded.Month % granularity / _lastGranularity;
				int num2 = TCompany.Founded.Month % _lastGranularity / granularity;
				int num3 = ConvertCount(list.Max((KeyValuePair<string, List<float>> x) => x.Value.Count));
				int num4 = Mathf.Clamp(Mathf.CeilToInt((float)Range[3] * (float)_lastGranularity / (float)granularity), Mathf.Min(2, num3), num3);
				int value = Mathf.Clamp((Range[2] + num) * _lastGranularity / granularity - num2, 0, num3 - num4);
				Range[1] = num3;
				Range[2] = value;
				Range[3] = num4;
				_lastGranularity = granularity;
				UpdatingScroll = true;
				UpdatingScroll = false;
			}
			else if (ConvertCount(list.Max((KeyValuePair<string, List<float>> x) => x.Value.Count)) != Range[1])
			{
				if (Range[1] == Range[2] + Range[3])
				{
					Range[1] = ConvertCount(list.Max((KeyValuePair<string, List<float>> x) => x.Value.Count));
					if (Range[2] == 0)
					{
						Range[3] = Range[1];
					}
					else
					{
						Range[2] = Range[1] - Range[3];
					}
					UpdatingScroll = true;
					UpdatingScroll = false;
				}
				else
				{
					Range[1] = ConvertCount(list.Max((KeyValuePair<string, List<float>> x) => x.Value.Count));
				}
				UpdateScroll();
			}
		}
		List<string> range = (from x in list
			select x.Key into x
			where !Legend.Items.Contains(x)
			select x).ToList();
		Legend.Items.AddRange(range);
		Dictionary<string, float> lastNumbers = new Dictionary<string, float>();
		List<List<float>> values = list.OrderBy((KeyValuePair<string, List<float>> x) => Legend.Items.IndexOf(x.Key)).Where((KeyValuePair<string, List<float>> x, int i) => Legend.IsOn(i)).Select(delegate(KeyValuePair<string, List<float>> x)
		{
			List<float> list2 = NormalizeValues(x.Value, !x.Key.Equals("Balance"));
			lastNumbers[x.Key] = ((list2.Count > 0) ? list2[list2.Count - 1] : 0f);
			return list2;
		})
			.ToList();
		if (Stats)
		{
			Legend.OrderItemsBy((string x) => GameSettings.MiscStatOrder.GetOrDefault(x, float.MaxValue));
		}
		else
		{
			Legend.OrderItemsBy((string x) => 0f - lastNumbers.GetOrDefault(x, float.NegativeInfinity));
		}
		UpdateLabels(values);
		UpdateLineChart(values);
	}

	private int ConvertCount(int count)
	{
		return Mathf.CeilToInt((float)count / (float)Granularity);
	}

	private List<float> NormalizeValues(List<float> input, bool aggregate)
	{
		int granularity = Granularity;
		int num = Range[2] * granularity;
		int num2 = Range[3];
		List<float> list = new List<float>(num2);
		if (granularity > 1)
		{
			int num3 = ((num == 0) ? (TCompany.Founded.Month % granularity) : 0);
			for (int i = 0; i < num2; i++)
			{
				if (aggregate)
				{
					list.Add(0f);
					for (int j = 0; j < granularity - num3; j++)
					{
						int num4 = num + i * granularity + j;
						if (num4 >= input.Count)
						{
							break;
						}
						list[i] += input[num4];
					}
				}
				else
				{
					list.Add(input[Mathf.Min(input.Count - 1, num + i * granularity + granularity - 1 - num3)]);
				}
				num3 = 0;
			}
		}
		else
		{
			for (int k = 0; k < num2; k++)
			{
				if (num + k < input.Count)
				{
					list.Add(input[num + k]);
				}
				else
				{
					list.Add(0f);
				}
			}
		}
		return list;
	}

	private void UpdateLineChart(List<List<float>> values)
	{
		LineChart.Values.Clear();
		LineChart.Values.AddRange(values);
		LineChart.UpdateCachedLines();
	}

	public void SetCompany(Company company)
	{
		if (Range == null)
		{
			Range = new Ranger(Slider);
		}
		TCompany = company;
		LineChart.ToolTipFunc = delegate(int j, int i, float x)
		{
			Func<float, string> value;
			string text = ((!Stats) ? x.Currency() : (_toolTipConv.TryGetValue(Legend.GetIthEnabled(j), out value) ? value(x) : x.ToString("N0")));
			int granularity = Granularity;
			switch (granularity)
			{
			case 12:
				return TCompany.Founded.RealYear + Range[2] + i + ": " + text;
			case 3:
				return (TCompany.Founded + new SDateTime((Range[2] + i) * granularity, 0)).ToQuarterString() + ": " + text;
			default:
				return (TCompany.Founded + new SDateTime(Range[2] + i, 0)).ToVeryCompactString() + ": " + text;
			}
		};
	}

	public void Show(Company company, GUIWindow parent = null)
	{
		if (Window.Shown && company == TCompany)
		{
			Window.Close();
			return;
		}
		Range = new Ranger(Slider);
		SetCompany(company);
		_lastGranularity = 1;
		GranularityCombo.Selected = 0;
		Range[0] = 0;
		Range[1] = TCompany.Cashflow.Max((KeyValuePair<string, List<float>> x) => x.Value.Count);
		Range[2] = Mathf.Max(0, Range[1] - 12);
		Range[3] = Mathf.Min(Range[1], 12);
		UpdatingScroll = true;
		UpdatingScroll = false;
		Legend.Items.Clear();
		UpdateChart();
		Window.NonLocTitle = company.Name + " " + "cashflow".Loc();
		Window.Modal = parent != null;
		Window.Show();
		if (parent != null)
		{
			Window.SetParentWindow(parent);
		}
	}
}
