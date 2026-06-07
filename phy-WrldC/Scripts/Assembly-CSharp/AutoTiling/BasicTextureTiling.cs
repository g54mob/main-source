using System.Collections.Generic;
using UnityEngine;

namespace AutoTiling
{
	public class BasicTextureTiling : AutoTextureTiling
	{
		protected override MeshData SplitMeshForFaceUnwrapping(MeshData meshData)
		{
			MeshData meshData2 = meshData.Copy();
			List<FaceData> list = new List<FaceData>();
			for (int i = 0; i < meshData.Triangles.Length; i++)
			{
				if (_faceUnwrapData != null && i < _faceUnwrapData.Length)
				{
					list.Add(_faceUnwrapData[i]);
					continue;
				}
				FaceData faceData = new FaceData();
				faceData.Initialize();
				faceData.materialIndex = i;
				for (int j = 0; j < meshData.Triangles[i].Count; j += 3)
				{
					int[] array = new int[3];
					Vector3 zero = Vector3.zero;
					for (int k = 0; k < 3; k++)
					{
						int index = (array[k] = meshData.Triangles[i][j + k]);
						zero += meshData.Normals[index];
					}
					zero /= 3f;
					faceData.AddTriangle(array, zero);
				}
				list.Add(faceData);
			}
			MeshData meshData3 = new MeshData();
			meshData3.subMeshCount = meshData2.subMeshCount;
			for (int l = 0; l < list.Count; l++)
			{
				FaceData updatedFaceData = new FaceData();
				meshData3 = AddMeshDataForFaceData(list[l], meshData3, meshData2, out updatedFaceData);
				list[l] = updatedFaceData;
			}
			_faceUnwrapData = list.ToArray();
			return meshData3;
		}
	}
}
