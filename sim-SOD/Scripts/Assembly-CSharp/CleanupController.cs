using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CleanupController : MonoBehaviour
{
	[Serializable]
	public class DebugInteractable
	{
		public string name;

		public int count;

		[ProgressBar("Savable", 100f, EColor.Green)]
		public int savablePercent;

		[ProgressBar("Trash", 100f, EColor.Blue)]
		public int trashPercent;

		[Space(7f)]
		public List<SaveableBecause> savableDetails;

		[Space(7f)]
		public List<Interactable> contents;
	}

	[Serializable]
	public class SaveableBecause
	{
		public string reason;

		public int count;
	}

	public const int trashLimit = 250;

	[Header("Interactables")]
	[ReadOnly]
	[InfoBox("Breakdown of active interactables", EInfoBoxType.Normal)]
	public int totalInteractables;

	[ReadOnly]
	public int removedCityDataInteractables;

	[NonSerialized]
	public List<int> removedCityDataItems;

	[ReadOnly]
	public int savableCount;

	[ProgressBar("Savable %", 100f, EColor.Green)]
	public int savablePercent;

	[ReadOnly]
	public int trashCount;

	[ProgressBar("Trash %", 100f, EColor.Blue)]
	public int trashPercent;

	[ReadOnly]
	public int trashThreshold;

	[ProgressBar("Trash Threshold %", 100f, EColor.Red)]
	public int trashThresholdPercent;

	[ReadOnly]
	public int trashRemovedLastUpdate;

	[Space(7f)]
	public List<DebugInteractable> breakdownSavable;

	public List<DebugInteractable> breakdownNonSavable;

	public List<DebugInteractable> breakdownTrash;

	[ReadOnly]
	[Header("Trash")]
	public int currentTrash;

	[NonSerialized]
	public List<Interactable> trash;

	[ReadOnly]
	public int binTrash;

	[ReadOnly]
	[Header("Other Objects")]
	public int metaObjectsCount;

	[ReadOnly]
	public int fingerprintsCount;

	[ReadOnly]
	public int fingerprintThreshold;

	[ProgressBar("Fingerprint Threshold %", 100f, EColor.Yellow)]
	public int fingerprintThresholdPercent;

	[ReadOnly]
	public int footprintsCount;

	[ReadOnly]
	public int footprintThreshold;

	[ProgressBar("Footprint Threshold %", 100f, EColor.Yellow)]
	public int footprintThresholdPercent;

	[ReadOnly]
	public int cctvCount;

	[ReadOnly]
	public int cctvThreshold;

	[ProgressBar("CCTV Threshold %", 100f, EColor.Yellow)]
	public int cctvThresholdPercent;

	[ReadOnly]
	public int evidenceCount;

	[ReadOnly]
	public int factsCount;

	private static CleanupController _instance;

	public static CleanupController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TrashUpdate()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateData()
	{
	}

	public void RemoveUnusedPlayerPhotoCaptures(Interactable captureDevice)
	{
	}
}
