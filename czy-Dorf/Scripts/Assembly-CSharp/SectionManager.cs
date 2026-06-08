using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using Jobberwocky.GeometryAlgorithms.Source.API;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

public class SectionManager : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public Vector3 worldPos;

		internal float _003CGetSectionAtPosition_003Eb__0(Section x)
		{
			return Vector3.Distance(worldPos, x.Center);
		}
	}

	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public Vector3 worldPos;

		public SectionManager _003C_003E4__this;

		internal float _003CGetSectionInfluence_003Eb__0(Section x)
		{
			return Vector3.Distance(worldPos, x.Center);
		}

		internal float _003CGetSectionInfluence_003Eb__2(Section y)
		{
			return Vector3.Distance(worldPos, y.Center);
		}

		internal bool _003CGetSectionInfluence_003Eb__3(KeyValuePair<Section, float> x)
		{
			return x.Value <= _003C_003E4__this.influenceTreshold;
		}

		internal float _003CGetSectionInfluence_003Eb__5(KeyValuePair<Section, float> y)
		{
			return _003C_003E4__this.influenceTreshold - y.Value;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Section, bool> _003C_003E9__35_6;

		public static Func<Section, Section> _003C_003E9__35_1;

		public static Func<KeyValuePair<Section, float>, Section> _003C_003E9__35_4;

		internal bool _003CGetSectionInfluence_003Eb__35_6(Section x)
		{
			return x.TilePlacedInSection;
		}

		internal Section _003CGetSectionInfluence_003Eb__35_1(Section x)
		{
			return x;
		}

		internal Section _003CGetSectionInfluence_003Eb__35_4(KeyValuePair<Section, float> x)
		{
			return x.Key;
		}
	}

	[SerializeField]
	private float sectionSize = 10f;

	[SerializeField]
	private float influenceTreshold = 3f;

	[SerializeField]
	private float spreadRandomness = 1f;

	[SerializeField]
	private int seed;

	[SerializeField]
	private Section sectionPrefab;

	[SerializeField]
	private bool createSurroundingWhenTilePlacedInSection;

	public Dictionary<Vector2Int, Section> sectionsByGridPos;

	public Dictionary<Section, float> sectionInfluence;

	[SerializeField]
	private bool drawVoronoi;

	[SerializeField]
	private Material voronoiLineMaterial;

	[SerializeField]
	private Mesh lineMesh;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	private List<Vector3> sectionPoints;

	private VoronoiAPI voronoiApi;

	private GameObject voronoiLines;

	private List<GameObject> voronoiLineObjects;

	private Vector3 debug_worldPos;

	private bool debug_createSections;

	private Section initialSection;

	private Transform sectionContainer;

	public int Seed => seed;

	public float SectionSize => sectionSize;

	public float SpreadRandomness => spreadRandomness;

	public virtual void SetupSections(Transform container, bool randomizeSeed, bool setNewSeed = true)
	{
		if (setNewSeed)
		{
			if (randomizeSeed)
			{
				seed = Randomizer.GetRandomSeed();
			}
			else
			{
				seed = 299;
			}
		}
		if (sectionsByGridPos != null)
		{
			sectionsByGridPos.Clear();
			sectionsByGridPos = null;
			if ((bool)sectionContainer)
			{
				UnityEngine.Object.Destroy(sectionContainer.gameObject);
			}
		}
		sectionContainer = new GameObject().transform;
		sectionContainer.parent = container;
		sectionContainer.gameObject.name = base.name + " Container";
		sectionsByGridPos = new Dictionary<Vector2Int, Section>();
		sectionPoints = new List<Vector3>();
		sectionInfluence = new Dictionary<Section, float>();
		voronoiApi = new VoronoiAPI();
		voronoiLineObjects = new List<GameObject>();
		voronoiLines = new GameObject("Voronoi Lines");
		voronoiLines.transform.parent = sectionContainer;
		initialSection = CreateSection(new Vector2Int(0, 0));
		initialSection.PlaceTile();
		CreateSectionsAround(initialSection, initial: true);
		DrawVoronoi();
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= PlaceTileInSection;
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += PlaceTileInSection;
	}

	private void CreateSectionsAround(Section initialSection, bool initial)
	{
		for (int i = -2; i <= 2; i++)
		{
			for (int j = -2; j <= 2; j++)
			{
				Vector2Int vector2Int = initialSection.GridPos + new Vector2Int(j, i);
				if (!sectionsByGridPos.ContainsKey(vector2Int))
				{
					CreateSection(vector2Int);
					if (!initial)
					{
						DrawVoronoi();
					}
				}
			}
		}
	}

	private Section CreateSection(Vector2Int gridPos)
	{
		Section section = UnityEngine.Object.Instantiate(sectionPrefab, new Vector3((float)gridPos.x * sectionSize, 0f, (float)gridPos.y * sectionSize), Quaternion.identity);
		section.transform.parent = sectionContainer;
		section.Setup(gridPos, this);
		sectionsByGridPos.Add(gridPos, section);
		sectionPoints.Add(section.Center);
		return section;
	}

	private void PlaceTileInSection(Tile placedTile, bool isPlacedByPlayer)
	{
		Section sectionAtPosition = GetSectionAtPosition(placedTile.transform.position);
		sectionAtPosition.PlaceTile(placedTile);
		if (createSurroundingWhenTilePlacedInSection)
		{
			GetSurroundingSections(sectionAtPosition.GridPos);
		}
	}

	private void DrawVoronoi()
	{
		if (drawVoronoi)
		{
			Geometry geometry = voronoiApi.Voronoi2DRaw(new Voronoi2DParameters
			{
				Points = sectionPoints.ToArray(),
				CoordinateSystem = CoordinateSystem.XZY
			});
			CreateLineCylinders(geometry.ToUnityMesh(), voronoiLineMaterial, 0.05f, voronoiLines, voronoiLineObjects);
		}
	}

	private void ClearVoronoi()
	{
		foreach (GameObject voronoiLineObject in voronoiLineObjects)
		{
			UnityEngine.Object.Destroy(voronoiLineObject);
		}
		voronoiLineObjects.Clear();
	}

	private void CreateLineCylinders(Mesh mesh, Material material, float scale, GameObject parent, List<GameObject> existingObjects)
	{
		Vector3[] vertices = mesh.vertices;
		int[] indices = mesh.GetIndices(0);
		for (int i = 0; i < indices.Length; i += 2)
		{
			Vector3 vector = vertices[indices[i]];
			Vector3 vector2 = vertices[indices[i + 1]];
			GameObject gameObject;
			if (i / 2 < existingObjects.Count)
			{
				gameObject = existingObjects[i / 2];
			}
			else
			{
				gameObject = new GameObject(parent.name + " Cylinder " + i);
				gameObject.transform.parent = parent.transform;
				gameObject.AddComponent<MeshFilter>();
				gameObject.AddComponent<MeshRenderer>().material = material;
				existingObjects.Add(gameObject);
			}
			gameObject.transform.localPosition = (vector2 - vector) / 2f + vector;
			gameObject.transform.localScale = new Vector3(scale, (vector2 - vector).magnitude / 2f, scale);
			gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, vector2 - vector);
			gameObject.SetActive(value: true);
			gameObject.GetComponent<MeshFilter>().mesh = lineMesh;
		}
		for (int j = indices.Length / 2; j < existingObjects.Count; j++)
		{
			existingObjects[j].SetActive(value: false);
		}
	}

	public Section GetSectionAtPosition(Vector3 worldPos)
	{
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals3.worldPos = worldPos;
		Vector3 vector = CS_0024_003C_003E8__locals3.worldPos / sectionSize;
		Vector2Int gridPos = new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.z));
		return Enumerable.ToList(Enumerable.OrderBy(GetSurroundingSections(gridPos), (Section x) => Vector3.Distance(CS_0024_003C_003E8__locals3.worldPos, x.Center)))[0];
	}

	public Section GetSectionAtSectionPos(Vector2Int sectionGridPos)
	{
		if (sectionsByGridPos.ContainsKey(sectionGridPos))
		{
			return sectionsByGridPos[sectionGridPos];
		}
		Debug.LogError($"no section found at grid pos {sectionGridPos}");
		return null;
	}

	public Dictionary<Section, float> GetSectionInfluence(Vector3 worldPos, bool createSections = true, bool includeEmptySections = true)
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals8.worldPos = worldPos;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		debug_worldPos = CS_0024_003C_003E8__locals8.worldPos;
		debug_createSections = createSections;
		Vector3 vector = CS_0024_003C_003E8__locals8.worldPos / sectionSize;
		Vector2Int gridPos = new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.z));
		List<Section> list = GetSurroundingSections(gridPos, createSections);
		if (!includeEmptySections)
		{
			_ = list.Count;
			list = Enumerable.ToList(Enumerable.Where(list, (Section x) => x.TilePlacedInSection));
			if (list.Count == 0)
			{
				list.Add(initialSection);
			}
		}
		list = Enumerable.ToList(Enumerable.Take(Enumerable.OrderBy(list, (Section x) => Vector3.Distance(CS_0024_003C_003E8__locals8.worldPos, x.Center)), 25));
		sectionInfluence = Enumerable.ToDictionary(list, (Section x) => x, (Section y) => Vector3.Distance(CS_0024_003C_003E8__locals8.worldPos, y.Center));
		float num = sectionInfluence[list[0]];
		foreach (Section item in list)
		{
			sectionInfluence[item] -= num;
		}
		sectionInfluence = Enumerable.ToDictionary(Enumerable.Where(sectionInfluence, (KeyValuePair<Section, float> x) => x.Value <= CS_0024_003C_003E8__locals8._003C_003E4__this.influenceTreshold), (KeyValuePair<Section, float> x) => x.Key, (KeyValuePair<Section, float> y) => CS_0024_003C_003E8__locals8._003C_003E4__this.influenceTreshold - y.Value);
		List<Section> list2 = Enumerable.ToList(sectionInfluence.Keys);
		float num2 = 0f;
		foreach (Section item2 in list2)
		{
			num2 += sectionInfluence[item2];
		}
		if (list2.Count == 1)
		{
			sectionInfluence[list2[0]] = 1f;
		}
		else
		{
			foreach (Section item3 in list2)
			{
				sectionInfluence[item3] /= num2;
			}
		}
		return sectionInfluence;
	}

	private List<Section> GetSurroundingSections(Vector2Int gridPos, bool createSection = true)
	{
		List<Section> list = new List<Section>();
		bool flag = false;
		for (int i = -2; i <= 2; i++)
		{
			for (int j = -2; j <= 2; j++)
			{
				Vector2Int vector2Int = gridPos + new Vector2Int(j, i);
				if (!sectionsByGridPos.ContainsKey(vector2Int))
				{
					if (!createSection)
					{
						continue;
					}
					CreateSection(vector2Int);
					flag = true;
				}
				list.Add(sectionsByGridPos[vector2Int]);
			}
		}
		if (flag)
		{
			DrawVoronoi();
		}
		return list;
	}

	public void Clear()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= PlaceTileInSection;
		ClearSections();
	}

	public Section GetSectionAtGridPos(Vector2Int gridPos)
	{
		Vector3 worldPos = GridCalculator.GridToWorldPos(gridPos);
		return GetSectionAtPosition(worldPos);
	}

	public void SetWorldSeed(Transform container, int biomeSeed)
	{
		seed = biomeSeed;
		if (drawVoronoi)
		{
			ClearSections();
		}
		SetupSections(container, randomizeSeed: false, setNewSeed: false);
	}

	private void ClearSections()
	{
		sectionsByGridPos?.Clear();
		sectionInfluence?.Clear();
		if (voronoiLineObjects != null)
		{
			foreach (GameObject voronoiLineObject in voronoiLineObjects)
			{
				UnityEngine.Object.Destroy(voronoiLineObject);
			}
			voronoiLineObjects.Clear();
		}
		if ((bool)voronoiLines)
		{
			UnityEngine.Object.Destroy(voronoiLines);
		}
	}

	public void SetInfluenceTreshold(float influenceTreshold)
	{
		this.influenceTreshold = influenceTreshold;
	}
}
