using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketAnalysisWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIProgressBar[] Bars;

	public Text[] Labels;

	public GUILineChart Chart;

	public Text TypeLabel;

	private void Start()
	{
		Chart.ToolTipFunc = (int a, int b, float x) => x.ToPercent();
		Chart.HighlightCallback = delegate(int i)
		{
			for (int j = 0; j < 3; j++)
			{
				Labels[j].fontStyle = ((j == i) ? FontStyle.Bold : FontStyle.Normal);
			}
		};
	}

	public void Apply()
	{
		HUD.Instance.docWindow.SubmarketSlider.ApplyRatio(Bars[0].Value, Bars[1].Value, Bars[2].Value);
		Window.Close();
	}

	public void Show(SoftwareCategory cat)
	{
		TypeLabel.text = cat.GetActualString();
		SDateTime time = SDateTime.Now();
		double[] array = GameSettings.Instance.simulation.GetSubMarket(cat).ToArray();
		double[] quality = GameSettings.Instance.simulation.GetQuality(cat, time);
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			Labels[i].text = cat.Parent.SubMarkets[i].LocTry();
			num += quality[i];
		}
		if (num > 0.0)
		{
			for (int j = 0; j < 3; j++)
			{
				array[j] *= 1.0 - quality[j] / num;
			}
		}
		double num2 = 0.0;
		for (int k = 0; k < 3; k++)
		{
			num2 += array[k];
		}
		for (int l = 0; l < 3; l++)
		{
			array[l] /= num2;
		}
		for (int m = Chart.Values.Count; m < 3; m++)
		{
			Chart.Values.Add(new List<float>());
		}
		for (int n = 0; n < 3; n++)
		{
			Bars[n].ResetAnimation();
			Bars[n].Value = (float)array[n];
			Chart.Values[n].Clear();
			for (int num3 = 0; num3 < cat.SubmarketHistory.GetLength(0); num3++)
			{
				int num4 = (num3 + cat.SubmarketHistoryIndex) % cat.SubmarketHistory.GetLength(0);
				float[] array2 = cat.SubmarketHistory[num4];
				float num5 = ((array2 == null) ? 0f : (array2[0] + array2[1] + array2[2]));
				Chart.Values[n].Add((num5 == 0f) ? 0f : (array2[n] / num5));
			}
		}
		Chart.UpdateCachedLines();
		Window.Show();
	}
}
