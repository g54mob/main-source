using System.Collections.Generic;
using UnityEngine;

public class EnergyRangeCircleWaveHighlighter : CircleWaveHighlighter
{
	[SerializeField]
	private Color _radiusColor = Color.white;

	private static bool _visible = false;

	private static HashSet<EnergyRangeCircleWaveHighlighter> _rangeIndicators = new HashSet<EnergyRangeCircleWaveHighlighter>();

	private void Start()
	{
		Initialize(GameManager.Settings.BuildableSettings.CableLinkRange, base.transform.position, _radiusColor);
		_rangeIndicators.Add(this);
		DisplayObject(_visible);
	}

	private void OnDestroy()
	{
		_rangeIndicators.Remove(this);
	}

	public static void Display(bool display)
	{
		if (display == _visible)
		{
			return;
		}
		_visible = display;
		foreach (EnergyRangeCircleWaveHighlighter rangeIndicator in _rangeIndicators)
		{
			rangeIndicator.DisplayObject(_visible);
		}
	}

	public void DisplayObject(bool display)
	{
		base.gameObject.SetActive(display);
	}
}
