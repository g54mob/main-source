using System.Collections.Generic;
using System.Linq;
using Dorfromantik.Area;
using UnityEngine;

public class Section_Area : Section
{
	[SerializeField]
	private AreaSlot areaSlotPrefab;

	private Dictionary<Vector2Int, AreaSlot> areaSlotsByGridPos;

	private List<Section_Area> neighbors;

	private List<AreaSlot> edgeSlots;

	[SerializeField]
	private int slotCount;

	protected override void SpecificSetup()
	{
		DebugInfluence(0f, 0f);
	}

	private void FillArea()
	{
		areaSlotsByGridPos = new Dictionary<Vector2Int, AreaSlot>();
		neighbors = new List<Section_Area>();
		edgeSlots = new List<AreaSlot>();
		Vector2Int startGridPos = GridCalculator.WorldToGridPos(base.Center);
		RecursivelyFillArea(startGridPos);
	}

	private void RecursivelyFillArea(Vector2Int startGridPos)
	{
		List<Vector2Int> list = new List<Vector2Int> { startGridPos };
		List<Vector2Int> list2 = new List<Vector2Int>();
		int num = 0;
		while (list.Count > 0 && num < 500)
		{
			foreach (Vector2Int item2 in list)
			{
				AreaSlot item = CreateAreaSlot(item2);
				foreach (Vector2Int item3 in new List<Vector2Int>(GridCalculator.GetNeighborGridPositions(item2)))
				{
					if (list.Contains(item3) || list2.Contains(item3) || areaSlotsByGridPos.ContainsKey(item3))
					{
						continue;
					}
					Section sectionAtGridPos = base.SectionManager.GetSectionAtGridPos(item3);
					if (sectionAtGridPos == this)
					{
						list2.Add(item3);
						continue;
					}
					if (!edgeSlots.Contains(item))
					{
						edgeSlots.Add(item);
					}
					if (!Enumerable.Contains(neighbors, sectionAtGridPos))
					{
						neighbors.Add((Section_Area)sectionAtGridPos);
					}
				}
				num++;
			}
			list = new List<Vector2Int>(list2);
			list2.Clear();
		}
	}

	private AreaSlot CreateAreaSlot(Vector2Int gridPos)
	{
		Vector3 position = GridCalculator.GridToWorldPos(gridPos);
		AreaSlot areaSlot = Object.Instantiate(areaSlotPrefab, position, Quaternion.identity, base.transform);
		areaSlotsByGridPos.Add(gridPos, areaSlot);
		areaSlot.name = $"AreaSlot {gridPos}";
		slotCount++;
		return areaSlot;
	}

	public override void DebugInfluence(float distance, float influence)
	{
		debugLabel.text = $"Area {base.GridPos}";
	}

	private void HighlightEdge()
	{
		Material material = new Material(Enumerable.FirstOrDefault(edgeSlots)?.GetComponentInChildren<Renderer>().sharedMaterial);
		material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f, 0.45f, 0.55f);
		foreach (AreaSlot edgeSlot in edgeSlots)
		{
			edgeSlot.GetComponentInChildren<Renderer>().sharedMaterial = material;
		}
	}
}
