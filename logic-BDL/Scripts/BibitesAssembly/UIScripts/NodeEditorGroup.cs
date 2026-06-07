using System.Collections.Generic;
using OneUseScripts;
using UnityEngine;
using Utility;

namespace UIScripts
{
	public class NodeEditorGroup : PoolableItem<NodeEditorGroup>
	{
		public List<NodeEditor> nodes = new List<NodeEditor>();

		private RectTransform rt;

		private Camera cam;

		private Rect groupBounds;

		public void InitGroup()
		{
			rt = GetComponent<RectTransform>();
			cam = UICamera.cam;
		}

		public void OnChildMove(NodeEditor moved)
		{
			groupBounds = new Rect(moved.rt.anchoredPosition, Vector2.zero);
			foreach (NodeEditor node in nodes)
			{
				if (!(node == moved))
				{
					Vector2 anchoredPosition = node.rt.anchoredPosition;
					groupBounds.xMin = Mathf.Min(groupBounds.xMin, anchoredPosition.x);
					groupBounds.xMax = Mathf.Max(groupBounds.xMax, anchoredPosition.x);
					groupBounds.yMin = Mathf.Max(groupBounds.yMin, anchoredPosition.y);
					groupBounds.yMax = Mathf.Min(groupBounds.yMax, anchoredPosition.y);
				}
			}
			foreach (NodeEditor node2 in nodes)
			{
				node2.groupPos = Rect.PointToNormalized(point: node2.rt.anchoredPosition, rectangle: groupBounds);
			}
		}

		private void OnDrawGizmos()
		{
			Rect rect = rt.rect;
			Gizmos.DrawCube(rect.center, rect.size);
		}
	}
}
