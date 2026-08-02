using System;
using System.Collections.Generic;

[Serializable]
public class ChemistryTableSaveData
{
	public List<string> fuelSlotItems = new List<string>();

	public float remainingFuelTime;

	public float maxFuelTime;

	public List<string> inputItems = new List<string>();

	public List<int> inputItemCounts = new List<int>();

	public string outputItemName;

	public int outputItemCount;

	public string currentRecipeItemName;

	public float currentProductionProgress;

	public float totalProductionDuration;

	public bool isProcessing;
}
