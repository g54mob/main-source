using System;
using System.Collections.Generic;

namespace tripolygon.UModeler
{
	[Serializable]
	public class UModelerFaceMigrationData
	{
		public LoopMigration triangulationDatas;

		public LoopMigration outLoop;

		public LoopMigration[] innerLoops;

		public int faceMaterialIDs;

		public bool faceOpen;

		public bool faceUnwrappeds;

		public int faceSmoothingGroupIDs;

		public UModelerFaceMigrationData(SimplePolygon polygon, EditableMesh editableMesh, Dictionary<VertexInfo, int> sortingVertices, Dictionary<UVIsland, Dictionary<VertexInfo, int>> sortingUVs)
		{
			if (sortingUVs != null && sortingVertices != null)
			{
				Init(polygon, editableMesh, sortingVertices, sortingUVs);
			}
		}

		public void Init(SimplePolygon polygon, EditableMesh editableMesh, Dictionary<VertexInfo, int> sortingVertices, Dictionary<UVIsland, Dictionary<VertexInfo, int>> sortingUVs)
		{
			Segment outsideLoop = polygon.segments.GetOutsideLoop();
			int holeCount = polygon.segments.GetHoleCount();
			List<Vertex> list = null;
			faceMaterialIDs = polygon.matID;
			faceSmoothingGroupIDs = editableMesh.smoothingGroups.FindSmoothingGroupIndexIncludingPolygon(polygon);
			faceOpen = outsideLoop.open;
			faceUnwrappeds = polygon.IsUnwrapped() && !faceOpen;
			if (polygon.renderableMesh != null)
			{
				list = new List<Vertex>(polygon.renderableMesh.indices.Count);
				for (int i = 0; i < polygon.renderableMesh.indices.Count; i++)
				{
					list.Add(polygon.renderableMesh.vertices[polygon.renderableMesh.indices[i]]);
				}
				triangulationDatas = new LoopMigration();
				triangulationDatas.SetLoopVertices(editableMesh.editableMeshCache, list, sortingVertices);
			}
			else
			{
				triangulationDatas = null;
			}
			outLoop = new LoopMigration();
			outLoop.SetLoopVertices(editableMesh.editableMeshCache, outsideLoop.vertices, sortingVertices);
			if (faceUnwrappeds)
			{
				UVIsland uVIsland = editableMesh.uvIslandManager.FindUVIsland(polygon);
				if (uVIsland != null)
				{
					outLoop.SetLoopUVs(editableMesh.editableMeshCache, outsideLoop.vertices, sortingUVs[uVIsland]);
					if (triangulationDatas != null)
					{
						triangulationDatas.SetLoopUVs(editableMesh.editableMeshCache, list, sortingUVs[uVIsland]);
					}
				}
			}
			innerLoops = ((holeCount > 0) ? new LoopMigration[holeCount] : null);
			for (int j = 0; j < holeCount; j++)
			{
				List<Vertex> vertices = polygon.segments.GetHole(j).vertices;
				innerLoops[j] = new LoopMigration();
				innerLoops[j].SetLoopVertices(editableMesh.editableMeshCache, vertices, sortingVertices);
				if (faceUnwrappeds)
				{
					UVIsland key = editableMesh.uvIslandManager.FindUVIsland(polygon);
					innerLoops[j].SetLoopUVs(editableMesh.editableMeshCache, vertices, sortingUVs[key]);
				}
			}
		}
	}
}
