using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardwareMorphWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Toggle UseGauss;

	public Slider Mean;

	public Slider Deviation;

	public Slider Chance;

	public Slider MinValue;

	public GUILineChart Chart;

	public int Discretization = 50;

	[NonSerialized]
	public HardwareDesign.MorphInfo Target;

	private bool _isInit;

	public void Show(HardwareDesign.MorphInfo m)
	{
		_isInit = true;
		Chart.Values = new List<List<float>>
		{
			new List<float>()
		};
		Target = m;
		UseGauss.isOn = Target.Gauss;
		Mean.value = Target.Mean;
		Deviation.value = Target.Deviation;
		MinValue.value = Target.MinValue / 100f;
		Chance.value = Target.Chance;
		Mean.gameObject.SetActive(UseGauss.isOn);
		Deviation.gameObject.SetActive(UseGauss.isOn);
		_isInit = false;
		Window.NonLocTitle = m.Label + " morph random distribution";
		Window.Show();
		UpdateChart();
	}

	public void OnToggle()
	{
		if (!_isInit)
		{
			if (Target.Gauss != UseGauss.isOn)
			{
				HardwareDesignEditor.Instance.MarkAsChanged();
			}
			Target.Gauss = UseGauss.isOn;
			Mean.gameObject.SetActive(UseGauss.isOn);
			Deviation.gameObject.SetActive(UseGauss.isOn);
			UpdateChart();
		}
	}

	public void SliderChange()
	{
		if (!_isInit)
		{
			if (Target.Deviation != Deviation.value || Target.Mean != Mean.value || Target.MinValue != MinValue.value * 100f || Target.Chance != Chance.value)
			{
				HardwareDesignEditor.Instance.MarkAsChanged();
			}
			Target.Deviation = Deviation.value;
			Target.Mean = Mean.value;
			Target.MinValue = MinValue.value * 100f;
			Target.Chance = Chance.value;
			UpdateChart();
		}
	}

	private void UpdateChart()
	{
		Chart.Values[0].Clear();
		if (UseGauss.isOn)
		{
			float num = 1f / (Deviation.value * Mathf.Sqrt((float)Math.PI * 2f));
			for (int i = 0; i <= Discretization; i++)
			{
				float num2 = (float)i / (float)Discretization;
				if (Chance.value < 1f && i == 0)
				{
					Chart.Values[0].Add(1f);
				}
				else if (num2 >= MinValue.value)
				{
					num2 = num2.MapRange(MinValue.value, 1f, 0f, 1f, true);
					num2 = 1f / (Deviation.value * Mathf.Sqrt((float)Math.PI * 2f)) * Mathf.Exp(-0.5f * Mathf.Pow((num2 - Mean.value) / Deviation.value, 2f));
					num2 /= num;
					Chart.Values[0].Add(num2 * Chance.value);
				}
				else
				{
					Chart.Values[0].Add(0f);
				}
			}
		}
		else
		{
			for (int j = 0; j <= Discretization; j++)
			{
				Chart.Values[0].Add((j == 0 && Chance.value < 1f) ? 1f : (((float)j / (float)Discretization >= MinValue.value) ? Chance.value : 0f));
			}
		}
		Chart.UpdateCachedLines();
	}
}
