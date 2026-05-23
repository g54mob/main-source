using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Resources/ResourceViewMeshData", fileName = "ResourceViewMeshData", order = 0)]
public class ResourceViewMeshData : ScriptableObject
{
	[Serializable]
	public struct ResourceMeshData
	{
		public List<Material> Materials;

		public List<bool> ChangeColorOfMaterials;
	}

	public List<Mesh> Meshes;

	public List<ResourceMeshData> MeshDatas;

	private void OnValidate()
	{
		PopulateMeshDatasList();
		PopulateColorsLists();
	}

	private void PopulateMeshDatasList()
	{
		while (MeshDatas.Count > Meshes.Count)
		{
			MeshDatas.RemoveAt(MeshDatas.Count - 1);
		}
		while (MeshDatas.Count < Meshes.Count)
		{
			MeshDatas.Add(default(ResourceMeshData));
		}
	}

	private void PopulateColorsLists()
	{
		for (int i = 0; i < MeshDatas.Count; i++)
		{
			if (MeshDatas[i].ChangeColorOfMaterials != null && MeshDatas[i].Materials != null)
			{
				while (MeshDatas[i].ChangeColorOfMaterials.Count > MeshDatas[i].Materials.Count)
				{
					MeshDatas[i].ChangeColorOfMaterials.RemoveAt(MeshDatas[i].ChangeColorOfMaterials.Count - 1);
				}
				while (MeshDatas[i].ChangeColorOfMaterials.Count < MeshDatas[i].Materials.Count)
				{
					MeshDatas[i].ChangeColorOfMaterials.Add(item: false);
				}
			}
		}
	}
}
