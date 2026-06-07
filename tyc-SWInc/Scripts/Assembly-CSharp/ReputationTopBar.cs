using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ReputationTopBar : DropDownPanel
{
	public PosNegBar RepItemPrefab;

	public RectTransform ContentRect;

	private readonly List<PosNegBar> _bars = new List<PosNegBar>();

	protected override float GetHeight()
	{
		int num = _bars.Count((PosNegBar x) => x.gameObject.activeSelf);
		return Mathf.Clamp(2 + num * 24 + (num - 1), 0, Screen.height - 128);
	}

	protected override void Refresh()
	{
		UpdateBars();
	}

	public void UpdateBars()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		int num = 0;
		foreach (KeyValuePair<string, Company.RepEffectItem> item in from x in GameSettings.Instance.MyCompany.RepEffects
			where x.Value.IsRelevant()
			orderby x.Value.GetValue(true) + x.Value.GetValue(false) descending
			select x)
		{
			if (_bars.Count <= num)
			{
				_bars.Add(MakeBar());
			}
			PosNegBar posNegBar = _bars[num];
			posNegBar.gameObject.SetActive(true);
			posNegBar.GetComponentInChildren<Text>().text = item.Key.Loc();
			posNegBar.SetValues(ConvertValue(item.Value.GetValue(true)), ConvertValue(item.Value.GetValue(false)));
			num++;
		}
		for (int num2 = num; num2 < _bars.Count; num2++)
		{
			_bars[num2].gameObject.SetActive(false);
		}
	}

	private float ConvertValue(float val)
	{
		if (val != 0f)
		{
			return Mathf.Sqrt(val.MapRange(0f, 0.5f, 0.01f, 1f, true)) * 3f;
		}
		return 0f;
	}

	private PosNegBar MakeBar()
	{
		PosNegBar posNegBar = Object.Instantiate(RepItemPrefab);
		posNegBar.transform.SetParent(ContentRect, false);
		return posNegBar;
	}
}
