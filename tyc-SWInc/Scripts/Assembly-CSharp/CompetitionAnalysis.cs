using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompetitionAnalysis : MonoBehaviour
{
	public GUIWindow Window;

	public GUIBarChart BarChart;

	public GUILegend Legend;

	public ChartLabel HorizLabel;

	public ChartLabel VertLabel;

	private SDateTime _startDate;

	private SDateTime _currentStartDate;

	private List<List<float>> _values = new List<List<float>>();

	private bool _initialized;

	private void Init()
	{
		if (!_initialized)
		{
			Legend.OnToggle = UpdateChart;
			Legend.Colors = HUD.GetThemeColors().ToList();
			Legend.Colors.Insert(0, Color.white);
			Legend.Colors.AddRange(HUD.GetThemeColors());
			BarChart.HighlightCallback = delegate(int i)
			{
				Legend.Highlight(Legend.GetIthEnabledIndex(i));
			};
			Legend.HighlightCallback = delegate(int i)
			{
				BarChart.Highlighted = Legend.GetIthEnabledIndexReverse(i);
			};
			BarChart.ToolTipFunc = (int i, float x, float a) => (_currentStartDate + i).ToCompactString() + ": " + x.ToString("N0");
			_initialized = true;
		}
	}

	public void UpdateChart()
	{
		if (_values.Count == 0)
		{
			return;
		}
		BarChart.Values.Clear();
		BarChart.Colors.Clear();
		int num = _values[0].Count;
		int num2 = 0;
		for (int i = 0; i < _values.Count; i++)
		{
			if (Legend.IsOn(i))
			{
				int j;
				for (j = 0; j < _values[i].Count && !(_values[i][j] > 0f); j++)
				{
				}
				int num3 = _values[i].Count - 1;
				while (num3 >= 0 && !(_values[i][num3] > 0f))
				{
					num3--;
				}
				if (j < num)
				{
					num = j;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
		}
		for (int k = 0; k < _values.Count; k++)
		{
			if (Legend.IsOn(k))
			{
				List<float> item = _values[k].Skip(num).Take(num2 - num).ToList();
				BarChart.Values.Add(item);
				BarChart.Colors.Add(Legend.Colors[k % Legend.Colors.Count]);
			}
		}
		float a = 0f;
		for (int l = num; l < num2; l++)
		{
			float num4 = 0f;
			for (int m = 0; m < _values.Count; m++)
			{
				if (Legend.IsOn(m))
				{
					num4 += _values[m][l];
				}
			}
			a = Mathf.Max(a, num4);
		}
		VertLabel.Label1.text = a.ToString("N0");
		_currentStartDate = _startDate + num;
		HorizLabel.Label1.text = _currentStartDate.ToCompactString();
		HorizLabel.Label2.text = (_startDate + num2 - 1).ToCompactString();
		BarChart.UpdateCachedBars();
	}

	private bool HasOverlap(int aa, int ab, SoftwareProduct b)
	{
		int num = b.Release.ToInt();
		List<int> unitSales = b.GetUnitSales(false);
		List<int> unitSales2 = b.GetUnitSales(true);
		int num2 = unitSales.Count - 1;
		while (num2 >= 0 && unitSales[num2] + unitSales2[num2] <= 200)
		{
			num2--;
		}
		int num3 = (b.Release + num2 + 1).ToInt();
		return Utilities.Overlap(aa, ab, num, num3);
	}

	public void Show(SoftwareProduct p)
	{
		Init();
		int pStart = p.Release.ToInt();
		List<int> unitSales = p.GetUnitSales(false);
		List<int> unitSales2 = p.GetUnitSales(true);
		int pEnd;
		for (pEnd = unitSales.Count - 1; pEnd >= 0 && unitSales[pEnd] + unitSales2[pEnd] <= 5; pEnd--)
		{
		}
		pEnd = (p.Release + pEnd + 1).ToInt();
		List<SoftwareProduct> list = (from x in MarketSimulation.Active.GetAllProducts(true)
			where x != p && x.Type == p.Type && x.Category == p.Category && HasOverlap(pStart, pEnd, x)
			select x).ToList();
		if (list.Count > 0)
		{
			Legend.Items.Clear();
			_values.Clear();
			list.Insert(0, p);
			_startDate = list.Min((SoftwareProduct x) => x.Release);
			SDateTime sDateTime = _startDate;
			for (int num = 0; num < list.Count; num++)
			{
				SoftwareProduct softwareProduct = list[num];
				List<int> unitSales3 = softwareProduct.GetUnitSales(false);
				List<int> unitSales4 = softwareProduct.GetUnitSales(true);
				int num2 = unitSales3.Count - 1;
				while (num2 >= 0 && unitSales3[num2] + unitSales4[num2] <= 200)
				{
					num2--;
				}
				SDateTime sDateTime2 = softwareProduct.Release + num2 + 1;
				if (sDateTime2 > sDateTime)
				{
					sDateTime = sDateTime2;
				}
			}
			if (sDateTime > SDateTime.Now())
			{
				sDateTime = SDateTime.Now();
			}
			float months = SDateTime.GetMonths(_startDate, sDateTime);
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				SoftwareProduct softwareProduct2 = list[num3];
				List<float> list2 = new List<float>();
				float months2 = SDateTime.GetMonths(_startDate, softwareProduct2.Release);
				for (int num4 = 0; (float)num4 < months2; num4++)
				{
					list2.Add(0f);
				}
				List<int> unitSales5 = softwareProduct2.GetUnitSales(true);
				List<int> unitSales6 = softwareProduct2.GetUnitSales(false);
				float num5 = months - months2;
				float num6 = Mathf.Min(num5, unitSales5.Count);
				for (int num7 = 0; (float)num7 < num6; num7++)
				{
					int num8 = unitSales5[num7] + unitSales6[num7];
					list2.Add(num8);
				}
				months2 = num5 - num6;
				for (int num9 = 0; (float)num9 < months2; num9++)
				{
					list2.Add(0f);
				}
				_values.Add(list2);
			}
			Legend.Items.AddRange(list.Select((SoftwareProduct x) => x.Name.FontBold() + ("\n    " + "MarketOverlap".Loc() + ": " + x.Submarkets.SubmarketDistance(p.Submarkets).ToPercent()).FontSize(12f)));
			UpdateChart();
			Window.Show();
		}
		else
		{
			WindowManager.SpawnDialog("NoCompetitionInfo".Loc(), true, DialogWindow.DialogType.Information);
		}
	}
}
