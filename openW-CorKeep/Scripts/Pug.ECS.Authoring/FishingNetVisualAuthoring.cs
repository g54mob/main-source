using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FishingNetVisualAuthoring : MonoBehaviour
{
	[Serializable]
	public class Slot
	{
		public Vector2 visualOffset;
	}

	public float2 minMaxSplashTimerSingleFish;

	public float2 minMaxSplashTimerFullNet;

	public List<Slot> visualSlots;
}
