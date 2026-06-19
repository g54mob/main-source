using System.Collections.Generic;
using UnityEngine;

public class TreeBranch : MonoBehaviour
{
	public int trunkBoneIndex;

	public List<Transform> branchBones;

	public Transform foliageTransform;

	public List<float> finalBranchGrowth = new List<float>();

	public List<Vector3> finalBranchRotation = new List<Vector3>();

	public List<float> currentBranchGrowth = new List<float>();

	public List<Vector3> currentBranchRotation = new List<Vector3>();

	public List<Transform> allBranchBones = new List<Transform>();

	public List<GameObject> branchColliders = new List<GameObject>();

	public List<float> startingBranchColliderScales = new List<float>();

	public void SaveBranch(SaveableBranch branch, LeafSpawner leafs)
	{
		branch.finalBranchGrowth.Clear();
		branch.finalBranchGrowth.AddRange(finalBranchGrowth);
		branch.finalBranchRotation.Clear();
		for (int i = 0; i < finalBranchRotation.Count; i++)
		{
			branch.finalBranchRotation.Add(new SerializableVector3(finalBranchRotation[i]));
		}
		branch.currentBranchGrowth.Clear();
		branch.currentBranchGrowth.AddRange(currentBranchGrowth);
		branch.currentBranchRotation.Clear();
		for (int j = 0; j < currentBranchRotation.Count; j++)
		{
			branch.currentBranchRotation.Add(new SerializableVector3(currentBranchRotation[j]));
		}
		branch.currentBranchPositions.Clear();
		branch.currentBranchRotations.Clear();
		for (int k = 0; k < allBranchBones.Count; k++)
		{
			branch.currentBranchPositions.Add(new SerializableVector3(allBranchBones[k].localPosition));
			branch.currentBranchRotations.Add(new SerializableQuaternion(allBranchBones[k].localRotation));
		}
		branch.trunkBoneIndex = trunkBoneIndex;
		branch.foliageIndex = leafs.GetCluster();
		branch.localBranchScale = new SerializableVector3(base.transform.localScale);
		branch.currentFoliageScale = new SerializableVector3(leafs.transform.localScale);
	}

	public void LoadBranch(SaveableBranch branch, LeafSpawner leafs)
	{
		finalBranchGrowth.Clear();
		finalBranchRotation.Clear();
		finalBranchGrowth.AddRange(branch.finalBranchGrowth);
		for (int i = 0; i < branch.finalBranchRotation.Count; i++)
		{
			finalBranchRotation.Add(branch.finalBranchRotation[i].Load());
		}
		currentBranchGrowth.Clear();
		currentBranchRotation.Clear();
		currentBranchGrowth.AddRange(branch.currentBranchGrowth);
		for (int j = 0; j < branch.currentBranchRotation.Count; j++)
		{
			currentBranchRotation.Add(branch.currentBranchRotation[j].Load());
		}
		for (int k = 0; k < allBranchBones.Count; k++)
		{
			allBranchBones[k].localPosition = branch.currentBranchPositions[k].Load();
			allBranchBones[k].localRotation = branch.currentBranchRotations[k].Load();
		}
		leafs.SetCluster(branch.foliageIndex);
		leafs.transform.rotation = Quaternion.identity;
		leafs.transform.localScale = branch.currentFoliageScale.Load();
		base.transform.localScale = branch.localBranchScale.Load();
	}

	public void Cleanup()
	{
		for (int i = 0; i < branchColliders.Count; i++)
		{
			branchColliders[i].transform.SetParent(branchBones[i]);
		}
	}
}
