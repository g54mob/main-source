using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	public class HouseMeshCombiner
	{
		private const string CombinedHouseMeshName = "Combined House Mesh";

		public readonly GameObject combinedMeshHousePrefab;

		private readonly Mesh[] _meshForGroup = new Mesh[MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS];

		public Mesh MeshForGroupIndex(int groupIndex)
		{
			if (Diagnostics.Verify(groupIndex >= 0 && groupIndex < _meshForGroup.Length, "groupIndex >= 0 && groupIndex < _meshForGroup.Length"))
			{
				return _meshForGroup[groupIndex];
			}
			return null;
		}

		public HouseMeshCombiner(GameObject housePrefab)
		{
			combinedMeshHousePrefab = Object.Instantiate(housePrefab);
			combinedMeshHousePrefab.SetActive(value: false);
			combinedMeshHousePrefab.hideFlags = HideFlags.HideAndDontSave;
			HouseMesh[] componentsInChildren = combinedMeshHousePrefab.GetComponentsInChildren<HouseMesh>(includeInactive: true);
			Mesh mesh = CombineHouseMesh(componentsInChildren);
			List<Color> list = new List<Color>();
			mesh.GetColors(list);
			for (int i = 0; i < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS; i++)
			{
				Mesh mesh2 = Object.Instantiate(mesh);
				Color[] array = new Color[mesh.vertexCount];
				int num = CombinedMeshThemeComponent.RelativeThemeComponentGroupTargetOffsetForGroup(i);
				for (int j = 0; j < array.Length; j++)
				{
					float r = list[j].r;
					array[j] = new Color((float)num + r, list[j].g, list[j].b, list[j].a);
				}
				mesh2.SetColors(array);
				_meshForGroup[i] = mesh2;
			}
			HouseMesh[] array2 = componentsInChildren;
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k].gameObject.SetActive(value: false);
			}
		}

		private Mesh CombineHouseMesh(HouseMesh[] houseMeshes)
		{
			CombineInstance[] combineInstances = new CombineInstance[houseMeshes.Length];
			for (int i = 0; i < combineInstances.Length; i++)
			{
				Combine(i, houseMeshes[i], in combineInstances);
			}
			Mesh mesh = new Mesh();
			mesh.name = "Combined House Mesh";
			mesh.CombineMeshes(combineInstances);
			return mesh;
		}

		private void Combine(int index, HouseMesh houseMesh, in CombineInstance[] combineInstances)
		{
			MeshFilter component = houseMesh.GetComponent<MeshFilter>();
			Mesh mesh = Object.Instantiate(component.sharedMesh);
			CombinedMeshThemeComponent.SetRelativeVertexColorIndexForMesh(mesh, houseMesh.groupTarget);
			combineInstances[index].mesh = mesh;
			Transform transform = component.transform;
			combineInstances[index].transform = transform.localToWorldMatrix;
		}
	}
}
