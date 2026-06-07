using System.Collections.Generic;
using System.Linq;
using AwesomeTechnologies;
using DV.PointSet;
using UnityEngine;

public class RailwayVegetationRemover : MonoBehaviour
{
	public float simplificationTolerance = 0.5f;

	public float terrainTileSize = 1024f;

	public float worldSize = 16384f;

	private float baseWidth;

	private float grassPerimiter = 2f;

	private float plantPerimiter = 4f;

	private float treePerimiter = 5f;

	private float objectPerimiter = 5f;

	private float largeObjectPerimiter = 6f;

	private GameObject rootGO;

	private void Start()
	{
		rootGO = new GameObject("[railway vegetation remover]");
		PrepareChunks();
		Object.Destroy(this);
	}

	private void PrepareChunks()
	{
		TrackChunkSpatialHash trackChunkSpatialHash = new TrackChunkSpatialHash(terrainTileSize);
		RailTrack[] array = Object.FindObjectsOfType<RailTrack>();
		foreach (RailTrack railTrack in array)
		{
			EquiPointSet kinkedPointSet = railTrack.GetKinkedPointSet();
			for (int j = 0; j < kinkedPointSet.points.Length; j++)
			{
				EquiPointSet.Point point = kinkedPointSet.points[j];
				TrackChunk trackChunk = trackChunkSpatialHash.Add(kinkedPointSet, point);
				trackChunk.isSleepers = false;
				trackChunk.track = railTrack;
			}
		}
		trackChunkSpatialHash.DoneAdding();
		Vector3 position = new Vector3(worldSize / 2f, 0f, worldSize / 2f);
		Dictionary<Vector2Int, List<TrackChunk>> dictionary = new Dictionary<Vector2Int, List<TrackChunk>>();
		trackChunkSpatialHash.FindInRange(position, worldSize / 2f, dictionary);
		Dictionary<Vector2Int, GameObject> containerGOs = new Dictionary<Vector2Int, GameObject>();
		(from chunk in dictionary.Values.SelectMany((List<TrackChunk> chunksList) => chunksList)
			select MakeMaskLine(chunk, GetChunkContainerGO(chunk.coords))).ToList();
		GameObject GetChunkContainerGO(Vector2Int cellId)
		{
			if (!containerGOs.TryGetValue(cellId, out var value))
			{
				value = new GameObject($"mask lines @ {cellId}");
				containerGOs[cellId] = value;
				value.transform.SetParent(rootGO.transform);
				value.transform.localPosition = new Vector3(cellId.x, 0f, cellId.y) * terrainTileSize;
			}
			return value;
		}
	}

	private VegetationMaskLine MakeMaskLine(TrackChunk chunk, GameObject containerGO)
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = chunk.minIndex; i < chunk.maxIndex; i++)
		{
			Vector3 item = (Vector3)chunk.pointSet.points[i].position;
			list.Add(item);
		}
		List<Vector3> list2 = new List<Vector3>();
		LineUtility.Simplify(list, simplificationTolerance, list2);
		VegetationMaskLine vegetationMaskLine = containerGO.AddComponent<VegetationMaskLine>();
		vegetationMaskLine.RemoveGrass = false;
		vegetationMaskLine.LineWidth = baseWidth;
		vegetationMaskLine.AdditionalGrassPerimiter = grassPerimiter;
		vegetationMaskLine.AdditionalLargeObjectPerimiter = largeObjectPerimiter;
		vegetationMaskLine.AdditionalObjectPerimiter = objectPerimiter;
		vegetationMaskLine.AdditionalPlantPerimiter = plantPerimiter;
		vegetationMaskLine.AdditionalTreePerimiter = treePerimiter;
		vegetationMaskLine.ClearNodes();
		vegetationMaskLine.AddNodesToEnd(list2.ToArray());
		return vegetationMaskLine;
	}
}
