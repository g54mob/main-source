using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveableBranch
{
	public int foliageIndex;

	public SerializableVector3 currentFoliageScale = new SerializableVector3(Vector3.one);

	public int trunkBoneIndex;

	public SerializableVector3 localBranchScale;

	public List<float> finalBranchGrowth = new List<float>();

	public List<SerializableVector3> finalBranchRotation = new List<SerializableVector3>();

	public List<float> currentBranchGrowth = new List<float>();

	public List<SerializableVector3> currentBranchRotation = new List<SerializableVector3>();

	public List<SerializableVector3> currentBranchPositions = new List<SerializableVector3>();

	public List<SerializableQuaternion> currentBranchRotations = new List<SerializableQuaternion>();

	public SaveableBranch()
	{
	}

	public SaveableBranch(TreeBranch branch, LeafSpawner leafs)
	{
		branch.SaveBranch(this, leafs);
	}

	public void Load(TreeBranch branch, LeafSpawner leafs)
	{
		branch.LoadBranch(this, leafs);
	}

	public SaveableBranch GetCopy()
	{
		SaveableBranch saveableBranch = new SaveableBranch();
		saveableBranch.foliageIndex = foliageIndex;
		if (currentFoliageScale != null)
		{
			saveableBranch.currentFoliageScale = currentFoliageScale.GetCopy();
		}
		saveableBranch.trunkBoneIndex = trunkBoneIndex;
		if (localBranchScale != null)
		{
			saveableBranch.localBranchScale = localBranchScale.GetCopy();
		}
		saveableBranch.finalBranchGrowth = new List<float>();
		saveableBranch.finalBranchGrowth.AddRange(finalBranchGrowth);
		saveableBranch.finalBranchRotation = new List<SerializableVector3>();
		for (int i = 0; i < finalBranchRotation.Count; i++)
		{
			if (finalBranchRotation[i] != null)
			{
				saveableBranch.finalBranchRotation.Add(finalBranchRotation[i].GetCopy());
			}
		}
		saveableBranch.currentBranchGrowth = new List<float>();
		saveableBranch.currentBranchGrowth.AddRange(currentBranchGrowth);
		saveableBranch.currentBranchRotation = new List<SerializableVector3>();
		for (int j = 0; j < currentBranchRotation.Count; j++)
		{
			if (currentBranchRotation[j] != null)
			{
				saveableBranch.currentBranchRotation.Add(currentBranchRotation[j].GetCopy());
			}
		}
		saveableBranch.currentBranchPositions = new List<SerializableVector3>();
		for (int k = 0; k < currentBranchPositions.Count; k++)
		{
			if (currentBranchPositions[k] != null)
			{
				saveableBranch.currentBranchPositions.Add(currentBranchPositions[k].GetCopy());
			}
		}
		saveableBranch.currentBranchRotations = new List<SerializableQuaternion>();
		for (int l = 0; l < currentBranchRotations.Count; l++)
		{
			if (currentBranchRotations[l] != null)
			{
				saveableBranch.currentBranchRotations.Add(currentBranchRotations[l].GetCopy());
			}
		}
		return saveableBranch;
	}
}
