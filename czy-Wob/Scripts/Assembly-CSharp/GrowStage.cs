using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GrowStage
{
	public GameObject objectRef;

	public GameObject triggerRef;

	public float minutesInStage = 1f;

	public float percentageGrowJiggle = 0.2f;

	[HideInInspector]
	public int spreaderCount;

	public List<RoomCustomizationObject> spreaderObjects;

	public float spreadTimerLow = 1f;

	public float spreadTimerHigh = 5f;

	public float spreadDistanceLow = 0.35f;

	public float spreadDistanceHigh = 1f;

	public float spreadChance = 0.5f;

	public int maxSpreadAttempts = 5;

	public bool cycleBack;

	public int cycleBackCounter;

	public int stageIncrementLow = 1;

	public int stageIncrementHigh = 1;

	public bool isFinalStage;

	public void CacheSpreaderCount()
	{
		spreaderCount = spreaderObjects.Count;
	}
}
