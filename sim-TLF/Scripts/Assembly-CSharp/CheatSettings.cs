using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "CheatSettings", menuName = "Cheats/CheatSettings")]
public class CheatSettings : ScriptableObject
{
	[Serializable]
	public class SpawnableEntry
	{
		public string Label;

		public AssetReference AssetRef;
	}

	[Header("Toggle Key")]
	public KeyCode ToggleKey = KeyCode.F1;

	[Header("Spawn Objects")]
	public List<SpawnableEntry> SpawnableObjects = new List<SpawnableEntry>();

	[Header("Time Scale Slider Range")]
	public float TimeScaleMin;

	public float TimeScaleMax = 5f;

	[Header("Drain Multiplier Slider Range")]
	public float DrainMin = -1f;

	public float DrainMax = 1f;

	[Header("Fly Speed Slider Range")]
	public float FlySpeedMin = 1f;

	public float FlySpeedMax = 50f;

	[Header("Assembly Object Names (scene GameObject names)")]
	public string EngineName = "Engine";

	public string PlaneName = "Plane";
}
