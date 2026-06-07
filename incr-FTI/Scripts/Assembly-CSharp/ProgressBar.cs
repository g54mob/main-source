using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	public TextMeshProUGUI label;

	public Slider slider;

	public Image fillImage;

	private double displayedCount = double.MaxValue;

	private double displayedMax = double.MaxValue;

	[NonSerialized]
	public bool allowExtra;

	[NonSerialized]
	public bool hideMaxValue;

	public bool debug;

	public void SetStale()
	{
		displayedCount = double.MaxValue;
		displayedMax = double.MaxValue;
	}

	public void DisplayAsInfinite()
	{
		base.gameObject.SetActive(value: false);
	}

	public void TryUpdateDisplay(LevelStat stat)
	{
		TryUpdateDisplay(Math.Floor(stat.points - (double)stat.currentLevelFloor), stat.currentLevelCeil - stat.currentLevelFloor);
	}

	public void TryUpdateDisplay(ConsumableState consumableState)
	{
		_ = consumableState.debug;
		if (consumableState.frameIsLimitingInput)
		{
			TryUpdateDisplay(0.0, consumableState.maxCount);
		}
		else if (consumableState.frameIsLimitingOutput)
		{
			TryUpdateDisplay(consumableState.maxCount, consumableState.maxCount);
		}
		else if (consumableState.currentCount < 2147483647.0)
		{
			TryUpdateDisplay(Math.Floor(consumableState.currentCount), consumableState.maxCount);
		}
		else
		{
			TryUpdateDisplay(consumableState.currentCount, consumableState.maxCount);
		}
		fillImage.color = consumableState.FillColor();
	}

	public void TryUpdateDisplay(double count, double max)
	{
		count = ((!(count < 100.0)) ? Math.Floor(count) : Math.Ceiling(count));
		double num;
		if (allowExtra)
		{
			num = count;
			if (!debug)
			{
			}
		}
		else
		{
			num = Math.Clamp(count, 0.0, max);
			_ = debug;
		}
		if (num >= 10000.0)
		{
			num = GameUtility.TruncateToSignificantDigits(num, 3);
			_ = debug;
		}
		if (!GameUtility.NearlyEquals(displayedCount, num) || !GameUtility.NearlyEquals(displayedMax, max))
		{
			UpdateDisplay(num, max);
		}
	}

	public string DebugString()
	{
		return "Displayed: " + displayedCount;
	}

	public void UpdateDisplay(double cappedCount, double max)
	{
		if (max >= double.MaxValue)
		{
			if (cappedCount <= 0.0)
			{
				slider.value = 0f;
			}
			else
			{
				slider.value = 1f;
			}
			TextDisplay.SetNumber(label, cappedCount);
		}
		else if (GameUtility.IsNotZero(max))
		{
			slider.value = GameUtility.AsFloat(cappedCount / max);
			if (hideMaxValue)
			{
				TextDisplay.SetNumber(label, cappedCount);
			}
			else
			{
				TextDisplay.SetFraction(label, cappedCount, max);
			}
		}
		else
		{
			slider.value = 0f;
			label.text = string.Empty;
		}
		displayedCount = cappedCount;
		displayedMax = max;
		_ = debug;
	}
}
