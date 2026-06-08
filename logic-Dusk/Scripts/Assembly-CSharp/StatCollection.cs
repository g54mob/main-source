using UnityEngine;

public abstract class StatCollection : MonoBehaviour
{
	private static bool highlightRow;

	public StatHeaderItem[] headerArray;

	public StatHeaderItem noStatRow;

	public abstract void Refresh();

	protected void FormatText(StatItem item, int val)
	{
		FormatText(item, val, false, 0.0);
	}

	protected void FormatText(StatItem item, int val, bool colorOnCompare, double compareVal)
	{
		if (val > int.MaxValue)
		{
			val = int.MaxValue;
		}
		FormatText(item, (double)val, colorOnCompare, compareVal);
	}

	protected void FormatText(StatItem item, double val)
	{
		FormatText(item, val, false, 0.0);
	}

	protected void FormatText(StatItem item, double val, bool colorOnCompare, double compareVal)
	{
		if (val > 0.0)
		{
			if (val > double.MaxValue)
			{
				val = 9.0;
			}
			item.label.text = val.ToString("#,###,###,##0");
			if (StatUI.Instance != null)
			{
				if (!colorOnCompare || val < compareVal)
				{
					item.label.color = StatUI.Instance.filledValueColor;
				}
				else
				{
					item.label.color = StatUI.Instance.currentIsBestColor;
				}
			}
		}
		else
		{
			item.label.text = "0";
			if (StatUI.Instance != null)
			{
				item.label.color = StatUI.Instance.emptyValueColor;
			}
		}
	}

	protected void HideRow(StatHeaderItem item)
	{
		item.gameObject.SetActive(false);
		if (item.currentLabel != null)
		{
			item.currentLabel.gameObject.SetActive(false);
		}
		if (item.currentBest != null)
		{
			item.currentBest.gameObject.SetActive(false);
		}
		if (item.currentTotal != null)
		{
			item.currentTotal.gameObject.SetActive(false);
		}
	}

	protected void ShowRow(StatHeaderItem item)
	{
		ShowRow(item, false);
	}

	protected void ShowRow(StatHeaderItem item, bool isNoStatsRow)
	{
		if (!item.gameObject.activeSelf)
		{
			item.gameObject.SetActive(true);
			if (item.currentLabel != null)
			{
				item.currentLabel.gameObject.SetActive(true);
			}
			if (item.currentBest != null)
			{
				item.currentBest.gameObject.SetActive(true);
			}
			if (item.currentTotal != null)
			{
				item.currentTotal.gameObject.SetActive(true);
			}
		}
		Color color = Color.black;
		if (StatUI.Instance != null && !isNoStatsRow && highlightRow)
		{
			color = StatUI.Instance.highlightRowBackgroundColor;
		}
		if (item.backgroundImage != null)
		{
			item.backgroundImage.color = color;
		}
		if (item.currentLabel.backgroundImage != null)
		{
			item.currentLabel.backgroundImage.color = color;
		}
		if (item.currentBest.backgroundImage != null)
		{
			item.currentBest.backgroundImage.color = color;
		}
		if (item.currentTotal.backgroundImage != null)
		{
			item.currentTotal.backgroundImage.color = color;
		}
		highlightRow = !highlightRow;
	}
}
