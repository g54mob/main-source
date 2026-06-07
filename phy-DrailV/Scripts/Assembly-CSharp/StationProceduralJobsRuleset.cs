using System;
using System.Collections.Generic;
using UnityEngine;

public class StationProceduralJobsRuleset : MonoBehaviour
{
	[NonSerialized]
	public int jobsCapacity = 30;

	[NonSerialized]
	public int maxShuntingStorageTracks = 3;

	[NonSerialized]
	public int minCarsPerJob = 3;

	[NonSerialized]
	public int maxCarsPerJob = 20;

	[Header("Cargo groups")]
	public List<CargoGroup> inputCargoGroups;

	public List<CargoGroup> outputCargoGroups;

	[Header("Starting chain job priorities")]
	public bool loadStartingJobSupported = true;

	public bool haulStartingJobSupported = true;

	public bool unloadStartingJobSupported = true;

	public bool emptyHaulStartingJobSupported = true;

	private void Awake()
	{
		foreach (CargoGroup inputCargoGroup in inputCargoGroups)
		{
			inputCargoGroup.InitializeLicenseRequirements();
		}
		foreach (CargoGroup outputCargoGroup in outputCargoGroups)
		{
			outputCargoGroup.InitializeLicenseRequirements();
		}
	}
}
