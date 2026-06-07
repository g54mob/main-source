using System.Collections.Generic;
using UnityEngine;

public class LedBarDriverSegmented : LedBarDriverBase
{
	[SerializeField]
	private List<GameObject> orderedSergments = new List<GameObject>();

	public override void Initialize()
	{
		if (!initialized)
		{
			ledsCount = orderedSergments.Count;
			base.Initialize();
		}
	}

	protected override void UpdateLeds(int amount)
	{
		if (mode == DisplayMode.OFF)
		{
			foreach (GameObject orderedSergment in orderedSergments)
			{
				orderedSergment.SetActive(value: false);
			}
			return;
		}
		for (int i = 0; i < ledsCount; i++)
		{
			orderedSergments[i].SetActive(i < amount);
		}
	}
}
