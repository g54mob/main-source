using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveableTree
{
	public float totalGrowthTime;

	public float currentTrunkScale;

	public SerializableVector3 awakeScale;

	public int foliageIndex;

	public SerializableVector3 currentFoliageScale = new SerializableVector3(Vector3.one);

	public List<float> finalTrunkGrowth = new List<float>();

	public List<SerializableVector3> finalTrunkRotation = new List<SerializableVector3>();

	public List<float> currentTrunkGrowth = new List<float>();

	public List<SerializableVector3> currentTrunkRotation = new List<SerializableVector3>();

	public List<SerializableVector3> currentTrunkPositions = new List<SerializableVector3>();

	public List<SerializableQuaternion> currentTrunkRotations = new List<SerializableQuaternion>();

	public List<SaveableBranch> branches = new List<SaveableBranch>();

	public bool doneGrowing;

	public SaveableTree()
	{
	}

	public SaveableTree(DynamicTree t)
	{
		t.SaveTree(this);
	}

	public void Load(DynamicTree t)
	{
		t.LoadTree(this);
	}

	public SaveableTree GetCopy()
	{
		SaveableTree saveableTree = new SaveableTree();
		saveableTree.totalGrowthTime = totalGrowthTime;
		saveableTree.currentTrunkScale = currentTrunkScale;
		saveableTree.awakeScale = awakeScale;
		saveableTree.foliageIndex = foliageIndex;
		if (currentFoliageScale != null)
		{
			saveableTree.currentFoliageScale = currentFoliageScale.GetCopy();
		}
		saveableTree.finalTrunkGrowth = new List<float>();
		saveableTree.finalTrunkGrowth.AddRange(finalTrunkGrowth);
		saveableTree.finalTrunkRotation = new List<SerializableVector3>();
		for (int i = 0; i < finalTrunkRotation.Count; i++)
		{
			if (finalTrunkRotation[i] != null)
			{
				saveableTree.finalTrunkRotation.Add(finalTrunkRotation[i].GetCopy());
			}
		}
		saveableTree.currentTrunkGrowth = new List<float>();
		saveableTree.currentTrunkGrowth.AddRange(currentTrunkGrowth);
		saveableTree.currentTrunkRotation = new List<SerializableVector3>();
		for (int j = 0; j < currentTrunkRotation.Count; j++)
		{
			if (currentTrunkRotation[j] != null)
			{
				saveableTree.currentTrunkRotation.Add(currentTrunkRotation[j].GetCopy());
			}
		}
		saveableTree.currentTrunkPositions = new List<SerializableVector3>();
		for (int k = 0; k < currentTrunkPositions.Count; k++)
		{
			if (currentTrunkPositions[k] != null)
			{
				saveableTree.currentTrunkPositions.Add(currentTrunkPositions[k].GetCopy());
			}
		}
		saveableTree.currentTrunkRotations = new List<SerializableQuaternion>();
		for (int l = 0; l < currentTrunkRotations.Count; l++)
		{
			if (currentTrunkRotations[l] != null)
			{
				saveableTree.currentTrunkRotations.Add(currentTrunkRotations[l].GetCopy());
			}
		}
		saveableTree.branches = new List<SaveableBranch>();
		for (int m = 0; m < branches.Count; m++)
		{
			if (branches[m] != null)
			{
				saveableTree.branches.Add(branches[m].GetCopy());
			}
		}
		saveableTree.doneGrowing = doneGrowing;
		return saveableTree;
	}
}
