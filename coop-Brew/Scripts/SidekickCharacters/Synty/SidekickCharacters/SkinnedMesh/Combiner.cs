using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Synty.SidekickCharacters.SkinnedMesh
{
	public static class Combiner
	{
		public static void MergeAndGetAllBlendShapeDataOfSkinnedMeshRenderers(SkinnedMeshRenderer[] skinnedMeshesToMerge, Mesh finalMesh, SkinnedMeshRenderer finalSkinnedMeshRenderer)
		{
		}

		public static GameObject CreateCombinedSkinnedMesh(List<SkinnedMeshRenderer> skinnedMeshesToCombine, GameObject baseModel, Material baseMaterial)
		{
			return null;
		}

		public static void ProcessBoneMovement(Hashtable boneNameMap, Dictionary<string, Vector3> movementDictionary, Dictionary<string, Quaternion> rotationDictionary)
		{
		}

		public static Hashtable CreateBoneNameMap(GameObject currentBone)
		{
			return null;
		}

		public static Transform[] FindAdditionalBones(Hashtable boneMap, List<SkinnedMeshRenderer> meshes)
		{
			return null;
		}

		public static Transform[] JoinAdditionalBonesToBoneArray(Transform[] bones, Transform[] additionBones, Hashtable boneMap)
		{
			return null;
		}
	}
}
