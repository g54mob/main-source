using System.Collections.Generic;
using System.Linq;
using Dorfromantik.Area;
using UnityEngine;

public class TileOutliner : MonoBehaviour
{
	[SerializeField]
	private LineRenderer outlinePrefab;

	[SerializeField]
	private float widthMultiplier = 0.05f;

	[SerializeField]
	private float outlineYPos = 0.1f;

	[SerializeField]
	internal float offset = 0.075f;

	private List<Vector3> contourOffsetPositions = new List<Vector3>
	{
		new Vector3(GridCalculator._tileSize.x / 4f, 0f, GridCalculator._tileSize.y / 2f),
		new Vector3(GridCalculator._tileSize.x / 2f, 0f, 0f),
		new Vector3(GridCalculator._tileSize.x / 4f, 0f, (0f - GridCalculator._tileSize.y) / 2f),
		new Vector3((0f - GridCalculator._tileSize.x) / 4f, 0f, (0f - GridCalculator._tileSize.y) / 2f),
		new Vector3((0f - GridCalculator._tileSize.x) / 2f, 0f, 0f),
		new Vector3((0f - GridCalculator._tileSize.x) / 4f, 0f, GridCalculator._tileSize.y / 2f)
	};

	private List<GameObject> drawnOutlines;

	[SerializeField]
	private World world;

	private void Awake()
	{
		contourOffsetPositions = new List<Vector3>
		{
			new Vector3(GridCalculator._tileSize.x / 4f, 0f, GridCalculator._tileSize.y / 2f),
			new Vector3(GridCalculator._tileSize.x / 2f, 0f, 0f),
			new Vector3(GridCalculator._tileSize.x / 4f, 0f, (0f - GridCalculator._tileSize.y) / 2f),
			new Vector3((0f - GridCalculator._tileSize.x) / 4f, 0f, (0f - GridCalculator._tileSize.y) / 2f),
			new Vector3((0f - GridCalculator._tileSize.x) / 2f, 0f, 0f),
			new Vector3((0f - GridCalculator._tileSize.x) / 4f, 0f, GridCalculator._tileSize.y / 2f)
		};
		drawnOutlines = new List<GameObject>();
	}

	internal void Outline(List<IOutlineable> outlineables)
	{
		Dictionary<IOutlineable, List<int>> dictionary = new Dictionary<IOutlineable, List<int>>();
		List<List<Vector3>> list = new List<List<Vector3>>();
		foreach (IOutlineable outlineable2 in outlineables)
		{
			if (!Enumerable.Contains(outlineable2.Neighbors, null))
			{
				continue;
			}
			dictionary.Add(outlineable2, new List<int>());
			for (int i = 0; i < 6; i++)
			{
				if (outlineable2.GetNeighbor(i, Space.World) == null)
				{
					dictionary[outlineable2].Add(i);
				}
			}
		}
		int num = 0;
		while (dictionary.Count > 0 && num < 5000)
		{
			IOutlineable outlineable = Enumerable.First(dictionary.Keys);
			int num2 = DetermineStartEdge(dictionary[outlineable]);
			List<Vector3> list2 = new List<Vector3>();
			list.Add(list2);
			while (num2 != -1 && num < 5000)
			{
				num++;
				AddEdgeLine(list2, outlineable, num2);
				dictionary[outlineable].Remove(num2);
				int num3 = (num2 + 1) % 6;
				if (dictionary[outlineable].Count == 0)
				{
					dictionary.Remove(outlineable);
				}
				else if (dictionary[outlineable].Contains(num3))
				{
					num2 = num3;
					continue;
				}
				IOutlineable neighbor = outlineable.GetNeighbor(num3, Space.World);
				if (neighbor != null && dictionary.ContainsKey(neighbor))
				{
					num3 = (num3 + 4) % 6;
					if (dictionary[neighbor].Contains(num3))
					{
						outlineable = neighbor;
						num2 = num3;
						continue;
					}
				}
				num2 = -1;
			}
		}
		DrawOutlines(list);
	}

	internal void ClearOutlines()
	{
		foreach (GameObject drawnOutline in drawnOutlines)
		{
			Object.Destroy(drawnOutline);
		}
		drawnOutlines.Clear();
	}

	private void DrawOutlines(List<List<Vector3>> outlinePositions)
	{
		foreach (List<Vector3> outlinePosition in outlinePositions)
		{
			LineRenderer lineRenderer = Object.Instantiate(outlinePrefab, base.transform);
			lineRenderer.positionCount = outlinePosition.Count;
			lineRenderer.SetPositions(outlinePosition.ToArray());
			lineRenderer.widthMultiplier = widthMultiplier;
			drawnOutlines.Add(lineRenderer.gameObject);
		}
	}

	private void AddEdgeLine(List<Vector3> outlinePositionList, IOutlineable currentOutlineable, int currentEdge)
	{
		Vector3 item = currentOutlineable.WorldPosition + contourOffsetPositions[currentEdge] + Vector3.up * outlineYPos;
		if (currentOutlineable.GetNeighbor((currentEdge + 1) % 6, Space.World) != null)
		{
			item += (contourOffsetPositions[currentEdge] + contourOffsetPositions[(currentEdge + 4) % 6]).normalized * offset;
		}
		else
		{
			item += contourOffsetPositions[currentEdge].normalized * offset;
		}
		outlinePositionList.Add(item);
	}

	private int DetermineStartEdge(List<int> openEdges)
	{
		for (int i = 0; i < 6; i++)
		{
			if (openEdges.Contains(i) && !openEdges.Contains((i - 1 + 6) % 6))
			{
				return i;
			}
		}
		Debug.LogError("all edges empty");
		return 0;
	}

	private void OutlineAllTiles()
	{
		ClearOutlines();
		Outline(Enumerable.ToList((IEnumerable<IOutlineable>)world.GetAllPlacedTiles()));
	}

	private void OutlineCurrentArea()
	{
		ClearOutlines();
		Outline(Enumerable.ToList((IEnumerable<IOutlineable>)GetComponent<Area>().EdgeAreaSlots));
	}

	public void Outline(List<Vector2Int> edgePositions)
	{
		List<Vector3> list = new List<Vector3>();
		int num = 1;
		Vector2Int vector2Int = edgePositions[0];
		Vector2Int vector2Int2 = vector2Int;
		bool flag = false;
		Debug.DrawLine(GridCalculator.GridToWorldPos(edgePositions[0]), GridCalculator.GridToWorldPos(edgePositions[0]) + contourOffsetPositions[num], Color.cyan, 1f);
		int num2 = 10000;
		while (!flag)
		{
			num2--;
			if (num2 <= 0)
			{
				break;
			}
			Vector3 vector = GridCalculator.GridToWorldPos(vector2Int2);
			Vector2Int[] neighborGridPositions = GridCalculator.GetNeighborGridPositions(vector2Int2);
			for (int i = 0; i < 6; i++)
			{
				Vector2Int vector2Int3 = neighborGridPositions[num];
				Vector3 end = GridCalculator.GridToWorldPos(vector2Int3);
				if (edgePositions.Contains(vector2Int3))
				{
					Debug.DrawLine(vector, end, Color.red, 1f);
					vector2Int2 = vector2Int3;
					if (vector2Int2 == vector2Int)
					{
						flag = true;
					}
					num = (num + 3) % 6;
					List<Vector3> list2 = list;
					list2[list2.Count - 1] += contourOffsetPositions[num] * offset;
					num = (num + 1) % 6;
					break;
				}
				list.Add(vector + contourOffsetPositions[num] * (1f + offset) + Vector3.up * outlineYPos);
				num = (num + 1) % 6;
				Debug.DrawLine(vector, vector + contourOffsetPositions[num], Color.green, 1f);
				Debug.DrawLine(vector, end, Color.green, 1f);
				if (i == 5)
				{
					flag = true;
				}
			}
		}
		DrawOutlines(new List<List<Vector3>> { list });
	}
}
