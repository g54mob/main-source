using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.MeshTools
{
	public class VegetationMeshCombiner : MonoBehaviour
	{
		public GameObject TargetGameObject;

		public bool MergeSubmeshesWitEquialMaterial = true;

		private void Reset()
		{
			TargetGameObject = base.gameObject;
		}

		public static GameObject CombineMeshes(GameObject sourceGameObject, bool mergeSubmeshesWitEquialMaterial)
		{
			MeshFilter[] componentsInChildren = sourceGameObject.GetComponentsInChildren<MeshFilter>();
			MeshRenderer[] componentsInChildren2 = sourceGameObject.GetComponentsInChildren<MeshRenderer>();
			Vector3 position = sourceGameObject.transform.position;
			Quaternion rotation = sourceGameObject.transform.rotation;
			Vector3 localScale = sourceGameObject.transform.localScale;
			sourceGameObject.transform.position = new Vector3(0f, 0f, 0f);
			sourceGameObject.transform.rotation = Quaternion.identity;
			sourceGameObject.transform.localScale = Vector3.one;
			CombineInstance[] array = new CombineInstance[componentsInChildren.Length];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				array[i].mesh = componentsInChildren[i].sharedMesh;
				array[i].transform = componentsInChildren[i].transform.localToWorldMatrix;
			}
			GameObject gameObject = new GameObject(sourceGameObject.name + "_Merged");
			gameObject.transform.position = new Vector3(0f, 0f, 0f);
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = new Mesh();
			meshFilter.sharedMesh.CombineMeshes(array, mergeSubMeshes: false, useMatrices: true);
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			List<Material> list = new List<Material>();
			for (int j = 0; j <= componentsInChildren2.Length - 1; j++)
			{
				list.AddRange(componentsInChildren2[j].sharedMaterials);
			}
			Material[] array2 = (meshRenderer.sharedMaterials = list.ToArray());
			if (mergeSubmeshesWitEquialMaterial)
			{
				SubmeshCombiner submeshCombiner = new SubmeshCombiner();
				for (int k = 0; k <= meshFilter.sharedMesh.subMeshCount - 1; k++)
				{
					submeshCombiner.AddSubmesh(meshFilter.sharedMesh.GetIndices(k), array2[k]);
				}
				submeshCombiner.UpdateMesh(meshFilter.sharedMesh);
				meshRenderer.sharedMaterials = submeshCombiner.GetMaterials();
			}
			sourceGameObject.transform.position = position;
			sourceGameObject.transform.rotation = rotation;
			sourceGameObject.transform.localScale = localScale;
			gameObject.transform.position = position;
			gameObject.transform.rotation = rotation;
			gameObject.transform.localScale = localScale;
			return gameObject;
		}
	}
}
