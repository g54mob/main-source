using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using Utils;

[Serializable]
public class TechTreeUIConnections
{
	[SerializeField]
	private TechTreeGrid _techTreeGrid;

	[SerializeField]
	private UILineRenderer _lineRenderer;

	[Space]
	[SerializeField]
	private Color _unlockedConnectionColor = Color.white;

	[SerializeField]
	private Color _lockedConnectionColor = Color.grey;

	[SerializeField]
	private float _connectionThickness = 4f;

	[SerializeField]
	private SerializedDictionary<int, float> _zoomTierLineWidths;

	private Vector2 CalculateNodePosition(Vector2Int gridPosition, Vector2Int gridCenter)
	{
		Vector3 vector = _techTreeGrid.GridToCanvasPositionCenter(gridPosition);
		Vector3 vector2 = _techTreeGrid.GridToCanvasPositionCenter(gridCenter);
		return vector - vector2;
	}

	public void SetZoomSize(TechTreeNodeSO startNode, Vector2Int gridCenterInt, int tier)
	{
		_connectionThickness = _zoomTierLineWidths[tier];
		DrawNodeConnections(startNode, gridCenterInt, redraw: true);
	}

	public void DrawNodeConnections(TechTreeNodeSO startNode, Vector2Int gridCenterInt, bool redraw = false)
	{
		if (startNode.RevealingRunTimeValue || (!redraw && (startNode == null || startNode.OutgoingNodes.IsNullOrEmpty())))
		{
			return;
		}
		List<TechTreeNodeSO> list = new List<TechTreeNodeSO>(startNode.OutgoingNodes);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (!list[num].CanShowNode() || list[num].RevealingRunTimeValue)
			{
				list.RemoveAt(num);
			}
		}
		Vector2Int startNodeGridPos = startNode.GridPosition;
		List<TechTreeNodeSO> nodesAboveStart = new List<TechTreeNodeSO>();
		List<TechTreeNodeSO> nodesBelowStart = new List<TechTreeNodeSO>();
		GetSortedNodes(list, in startNodeGridPos, nodesAboveStart, nodesBelowStart, out var sortedNodes);
		float cellSize = _techTreeGrid.CellSize;
		float horizontalOffsetSpacing = cellSize * 0.1f;
		Dictionary<int, float> dictionary = new Dictionary<int, float>();
		Dictionary<int, float> dictionary2 = new Dictionary<int, float>();
		CalculateStartOffsets(in startNodeGridPos, in cellSize, in horizontalOffsetSpacing, nodesAboveStart, nodesBelowStart, dictionary, dictionary2);
		for (int i = 0; i < sortedNodes.Count; i++)
		{
			TechTreeNodeSO techTreeNodeSO = sortedNodes[i];
			Vector2 vector = CalculateNodePosition(startNode.GridPosition, gridCenterInt);
			Vector2 vector2 = CalculateNodePosition(techTreeNodeSO.GridPosition, gridCenterInt);
			Vector2 vector3 = new Vector2(cellSize, cellSize);
			Vector2 vector4 = vector + vector3 * 0.5f;
			Vector2 vector5 = vector2 + vector3 * 0.5f;
			bool flag = vector4.x > vector5.x;
			Color color = (startNode.IsUnlocked ? _unlockedConnectionColor : _lockedConnectionColor);
			Vector2 vector6 = new Vector2(flag ? (vector.x - cellSize) : vector.x, vector4.y);
			Vector2 vector7 = new Vector2(flag ? (vector2.x + cellSize / 2f) : (vector2.x - cellSize / 2f), vector5.y);
			CalculateEndOffsets(startNode, techTreeNodeSO, cellSize, horizontalOffsetSpacing, out var endHorizontalOffset, out var endVerticalOffset);
			float num2 = (dictionary.ContainsKey(techTreeNodeSO.ID) ? dictionary[techTreeNodeSO.ID] : horizontalOffsetSpacing);
			float num3 = (dictionary2.ContainsKey(techTreeNodeSO.ID) ? dictionary2[techTreeNodeSO.ID] : 0f);
			List<UILine> list2 = new List<UILine>();
			if (startNode.GridPosition.x < techTreeNodeSO.GridPosition.x - 1)
			{
				if (startNode.GridPosition.y == techTreeNodeSO.GridPosition.y)
				{
					endVerticalOffset = num3;
				}
				Vector2 start = new Vector2(vector6.x, vector6.y + num3);
				Vector2 vector8 = new Vector2(vector6.x + num2, start.y);
				Vector2 vector9 = new Vector2(vector8.x, vector7.y + endVerticalOffset);
				Vector2 end = new Vector2(vector7.x - endHorizontalOffset, vector9.y);
				list2.Add(new UILine(start, vector8, color, _connectionThickness));
				list2.Add(new UILine(vector8, vector9, color, _connectionThickness));
				list2.Add(new UILine(vector9, end, color, _connectionThickness));
			}
			else
			{
				Vector2 start2 = new Vector2(vector6.x, vector6.y + num3);
				Vector2 vector10 = new Vector2(vector6.x + num2, start2.y);
				float y = (vector6.y + num3 + vector7.y + endVerticalOffset) * 0.5f;
				Vector2 vector11 = new Vector2(vector10.x, y);
				Vector2 vector12 = new Vector2(vector7.x - num2, y);
				Vector2 vector13 = new Vector2(vector12.x, vector7.y + endVerticalOffset);
				Vector2 end2 = new Vector2(vector7.x, vector7.y + endVerticalOffset);
				list2.Add(new UILine(start2, vector10, color, _connectionThickness));
				list2.Add(new UILine(vector10, vector11, color, _connectionThickness));
				list2.Add(new UILine(vector11, vector12, color, _connectionThickness));
				list2.Add(new UILine(vector12, vector13, color, _connectionThickness));
				list2.Add(new UILine(vector13, end2, color, _connectionThickness));
			}
			_lineRenderer.AddLineSegment(list2);
		}
	}

	public void Clear()
	{
		_lineRenderer.ClearLineSegments();
	}

	private static void CalculateEndOffsets(TechTreeNodeSO startNode, TechTreeNodeSO endNode, float cellSize, float horizontalOffsetSpacing, out float endHorizontalOffset, out float endVerticalOffset)
	{
		if (startNode.GridPosition.y == endNode.GridPosition.y)
		{
			endHorizontalOffset = horizontalOffsetSpacing - cellSize * 0.5f;
			endVerticalOffset = 0f - cellSize * 0.5f;
			return;
		}
		List<TechTreeNodeSO> list = new List<TechTreeNodeSO>(endNode.IncomingNodes);
		list.Sort((TechTreeNodeSO a, TechTreeNodeSO b) => b.GridPosition.y.CompareTo(a.GridPosition.y));
		int num = list.IndexOf(startNode);
		endHorizontalOffset = horizontalOffsetSpacing * (float)(num + 1) - cellSize * 0.5f;
		float num2 = cellSize / (float)(list.Count + 1);
		endVerticalOffset = num2 * (float)(num + 1) - cellSize;
	}

	private static void CalculateStartOffsets(in Vector2Int startNodeGridPos, in float cellSize, in float horizontalOffsetSpacing, IReadOnlyList<TechTreeNodeSO> nodesAboveStart, IReadOnlyList<TechTreeNodeSO> nodesBelowStart, IDictionary<int, float> startHorizontalOffsets, IDictionary<int, float> startVerticalOffsets)
	{
		int num = nodesAboveStart.Count + nodesBelowStart.Count;
		float num2 = cellSize / (float)(num + 1);
		for (int i = 0; i < nodesAboveStart.Count; i++)
		{
			TechTreeNodeSO techTreeNodeSO = nodesAboveStart[i];
			if (techTreeNodeSO.GridPosition.y == startNodeGridPos.y && num == 2)
			{
				startVerticalOffsets[techTreeNodeSO.ID] = 0f - cellSize * 0.5f;
			}
			else
			{
				float value = num2 * (float)(i + 1) - cellSize;
				startVerticalOffsets[techTreeNodeSO.ID] = value;
			}
			float value2 = horizontalOffsetSpacing * (float)(i + 1) + cellSize;
			startHorizontalOffsets[techTreeNodeSO.ID] = value2;
		}
		for (int j = 0; j < nodesBelowStart.Count; j++)
		{
			TechTreeNodeSO techTreeNodeSO2 = nodesBelowStart[j];
			if (techTreeNodeSO2.GridPosition.y == startNodeGridPos.y && num == 2)
			{
				startVerticalOffsets[techTreeNodeSO2.ID] = 0f - cellSize * 0.5f;
			}
			else
			{
				float value3 = num2 * (float)(nodesAboveStart.Count + j + 1) - cellSize;
				startVerticalOffsets[techTreeNodeSO2.ID] = value3;
			}
			float value4 = horizontalOffsetSpacing * (float)(nodesBelowStart.Count - j) + cellSize;
			startHorizontalOffsets[techTreeNodeSO2.ID] = value4;
		}
	}

	private static void GetSortedNodes(IReadOnlyList<TechTreeNodeSO> outgoingNodes, in Vector2Int startNodeGridPos, List<TechTreeNodeSO> nodesAboveStart, List<TechTreeNodeSO> nodesBelowStart, out List<TechTreeNodeSO> sortedNodes)
	{
		nodesAboveStart.Clear();
		nodesBelowStart.Clear();
		foreach (TechTreeNodeSO outgoingNode in outgoingNodes)
		{
			if (!(outgoingNode.GridPosition == startNodeGridPos))
			{
				if (outgoingNode.GridPosition.y > startNodeGridPos.y)
				{
					nodesAboveStart.Add(outgoingNode);
				}
				else
				{
					nodesBelowStart.Add(outgoingNode);
				}
			}
		}
		sortedNodes = new List<TechTreeNodeSO>(outgoingNodes);
		sortedNodes.Sort((TechTreeNodeSO a, TechTreeNodeSO b) => b.GridPosition.y.CompareTo(a.GridPosition.y));
		nodesAboveStart.Sort((TechTreeNodeSO a, TechTreeNodeSO b) => b.GridPosition.y.CompareTo(a.GridPosition.y));
		nodesBelowStart.Sort((TechTreeNodeSO a, TechTreeNodeSO b) => b.GridPosition.y.CompareTo(a.GridPosition.y));
	}
}
