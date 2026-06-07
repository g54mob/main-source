using UnityEngine;

public class BoneChecker : MonoBehaviour
{
	public SkinnedMeshRenderer mainModel;

	public SkinnedMeshRenderer[] comparisonModels;

	public GameObject[] comparisonObjects;

	[ContextMenu("Compare Bones")]
	private void CheckBoneMismatches()
	{
	}

	[ContextMenu("CountBones")]
	private void CountAllBones()
	{
	}

	private void CountBones(SkinnedMeshRenderer smr)
	{
	}

	[ContextMenu("CheckForDuplicateBones")]
	private void CheckForDuplicateBones()
	{
	}

	public static void CheckForDuplicateBones(SkinnedMeshRenderer smr)
	{
	}
}
