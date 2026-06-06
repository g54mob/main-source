using System.Collections.Generic;
using UnityEngine;

public class MarkerProxy
{
	private List<MarkerProxy> _children;

	private Vector3 _localPosition;

	private Transform _parent;

	public Vector3 Position => _parent.TransformPoint(_localPosition);

	public float Range { get; private set; }

	public MarkerProxy(HierarchicalNodeMarker hierarchicalNodeMarker, ConstructionPreview constructionPreview, Transform parent)
	{
		Range = hierarchicalNodeMarker.Range;
		_parent = parent;
		_localPosition = _parent.InverseTransformPoint(hierarchicalNodeMarker.transform.position);
		HierarchicalNodeMarker[] componentsInChildren = hierarchicalNodeMarker.GetComponentsInChildren<HierarchicalNodeMarker>();
		_children = new List<MarkerProxy>(componentsInChildren.Length - 1);
		HierarchicalNodeMarker[] array = componentsInChildren;
		foreach (HierarchicalNodeMarker hierarchicalNodeMarker2 in array)
		{
			if (!(hierarchicalNodeMarker2 == hierarchicalNodeMarker))
			{
				_children.Add(new MarkerProxy(hierarchicalNodeMarker2, constructionPreview, _parent));
			}
		}
	}

	public bool ReturnConnectsToNavMesh(WalkwaySegment walkwaysegment = null)
	{
		if (walkwaysegment != null && walkwaysegment.IsMarkerInRange(Position, Range))
		{
			return true;
		}
		if (GameManager.GraphManager.ConstructionGraph.ReturnHasNodeInRange(this))
		{
			return true;
		}
		if (_children != null)
		{
			foreach (MarkerProxy child in _children)
			{
				if (child != this && child.ReturnConnectsToNavMesh(walkwaysegment))
				{
					return true;
				}
			}
		}
		return false;
	}
}
