using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class UModelerMigrationData
	{
		public Vector3[] VertexPositions;

		public Vector2[] UVcoords;

		public int[] UVVertexIDs;

		public UModelerFaceMigrationData[] faceDatas;

		public Material[] materials;

		public MirrorMigrationData mirrorData;

		public string assetPath;

		private UModeler modeler;

		public UModelerMigrationData(UModeler modeler)
		{
			this.modeler = modeler;
			Migration();
		}

		private void Migration()
		{
			EditableMesh editableMesh = modeler.editableMesh;
			EditableMeshCache editableMeshCache = editableMesh.editableMeshCache;
			if (editableMesh.EditMeshVersion == 2)
			{
				modeler.SetPrefabInstance(isPrefabInstance: false);
			}
			if (editableMesh.mirrorMode.enable)
			{
				mirrorData = new MirrorMigrationData(editableMesh.mirrorMode);
			}
			else
			{
				mirrorData = null;
			}
			materials = modeler.materials.ToArray();
			int vertexCount = editableMeshCache.GetVertexCount();
			VertexPositions = new Vector3[vertexCount];
			Dictionary<VertexInfo, int> dictionary = new Dictionary<VertexInfo, int>(vertexCount);
			for (int i = 0; i < vertexCount; i++)
			{
				VertexPositions[i] = editableMeshCache.GetVertexInfo(i).pos;
				dictionary.Add(editableMeshCache.GetVertexInfo(i), i);
			}
			List<SimplePolygon> allPolygons = editableMesh.GetAllPolygons();
			int count = allPolygons.Count;
			int uVIslandCount = editableMesh.uvIslandManager.GetUVIslandCount();
			faceDatas = new UModelerFaceMigrationData[count];
			Dictionary<UVIsland, Dictionary<VertexInfo, int>> dictionary2 = new Dictionary<UVIsland, Dictionary<VertexInfo, int>>();
			List<Vector2> list = new List<Vector2>();
			List<int> list2 = new List<int>();
			for (int j = 0; j < uVIslandCount; j++)
			{
				UVIsland uVIsland = editableMesh.uvIslandManager.GetUVIsland(j);
				Dictionary<VertexInfo, int> dictionary3 = new Dictionary<VertexInfo, int>();
				int polygonCount = uVIsland.GetPolygonCount();
				for (int k = 0; k < polygonCount; k++)
				{
					SimplePolygon polygon = uVIsland.GetPolygon(k);
					int vertexCount2 = polygon.GetVertexCount();
					for (int l = 0; l < vertexCount2; l++)
					{
						VertexInfo vertexInfo = editableMeshCache.GetVertexInfo(polygon.GetVertex(l));
						if (vertexInfo == null)
						{
							vertexInfo = editableMeshCache.FindVertexByComparer(polygon.GetVertex(l));
						}
						if (!dictionary3.ContainsKey(vertexInfo))
						{
							dictionary3.Add(vertexInfo, list.Count);
							list.Add(polygon.GetVertex(l).uv);
							list2.Add(dictionary[vertexInfo]);
						}
					}
				}
				dictionary2.Add(uVIsland, dictionary3);
			}
			for (int m = 0; m < count; m++)
			{
				SimplePolygon polygon2 = allPolygons[m];
				faceDatas[m] = new UModelerFaceMigrationData(polygon2, editableMesh, dictionary, dictionary2);
			}
			UVcoords = list.ToArray();
			UVVertexIDs = list2.ToArray();
		}
	}
}
