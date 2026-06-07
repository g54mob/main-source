using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.MeshTools
{
	public class SubmeshCombiner
	{
		public readonly List<SubmeshInfo> SubmeshInfoList = new List<SubmeshInfo>();

		public void AddSubmesh(int[] indices, Material material)
		{
			SubmeshInfo submeshInfo = GetSubmeshInfo(material);
			if (submeshInfo == null)
			{
				submeshInfo = new SubmeshInfo
				{
					Material = material
				};
				SubmeshInfoList.Add(submeshInfo);
			}
			submeshInfo.IndicesList.AddRange(indices);
		}

		private SubmeshInfo GetSubmeshInfo(Material material)
		{
			for (int i = 0; i <= SubmeshInfoList.Count - 1; i++)
			{
				if (SubmeshInfoList[i].Material == material)
				{
					return SubmeshInfoList[i];
				}
			}
			return null;
		}

		public void UpdateMesh(Mesh mesh)
		{
			mesh.subMeshCount = SubmeshInfoList.Count;
			for (int i = 0; i <= SubmeshInfoList.Count - 1; i++)
			{
				mesh.SetIndices(SubmeshInfoList[i].IndicesList.ToArray(), mesh.GetTopology(i), i);
			}
		}

		public Material[] GetMaterials()
		{
			Material[] array = new Material[SubmeshInfoList.Count];
			for (int i = 0; i <= SubmeshInfoList.Count - 1; i++)
			{
				array[i] = SubmeshInfoList[i].Material;
			}
			return array;
		}
	}
}
