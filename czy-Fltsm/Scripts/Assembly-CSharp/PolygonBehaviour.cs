using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class PolygonBehaviour : MonoBehaviour
{
	[SerializeField]
	private Polygon _polygon;

	[SerializeField]
	private GridBehaviour _grid;

	[SerializeField]
	private PolygonBehaviour _overlapPolygon;

	private Rect _lastBounds;

	private List<GridNode> _blockedNodes;

	private IEnumerator Start()
	{
		_polygon.Initialize(base.transform);
		_blockedNodes = new List<GridNode>();
		yield return null;
		UpdateBlockedNodes();
	}

	private void Update()
	{
		_polygon.Update();
	}

	private void UpdateBlockedNodes()
	{
		int count = _blockedNodes.Count;
		for (int i = 0; i < count; i++)
		{
			_blockedNodes[i].DecreaseObstacleCount();
		}
		_grid.Grid.UpdateBlockedNodes(_polygon, _polygon.Bounds, _blockedNodes);
	}

	private void OnDrawGizmos()
	{
		_polygon.DrawGizmos();
		if (!Application.isPlaying || _overlapPolygon == null)
		{
			return;
		}
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		if (_polygon.PopulateOverlap(_overlapPolygon._polygon, list))
		{
			Polygon2DBase.SortVertices(list);
			Gizmos.color = Color.black;
			for (int i = 0; i < list.Count; i++)
			{
				Gizmos.DrawSphere(list[i].Vector3TopDown(), 0.01f);
			}
		}
	}
}
