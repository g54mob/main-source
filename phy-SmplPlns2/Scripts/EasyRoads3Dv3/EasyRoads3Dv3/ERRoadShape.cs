using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERRoadShape
	{
		public List<Vector2> nodes;

		public List<bool> hardEdge;

		public int priorityNodeIndexLeft;

		public int priorityNodeIndexRight;

		public List<Vector3> nodesV3;

		public List<ERLane> lanes;

		public int leftLanes;

		public int rightLanes;

		public bool symmetrical;

		public float leftSidewalkOffset;

		public float rightSidewalkOffset;

		public int outerLaneMarkingLeftIndex;

		public bool includeOuterlaneLeftInShape;

		public bool includeOuterlaneRightInShape;

		public int outerLaneMarkingRightIndex;

		public int outerOuterLaneMarkingLeftIndex;

		public int outerOuterLaneMarkingRightIndex;

		public int selectedNode;

		public int selectedLaneNode;

		public int isSymmetrical;

		public bool isset;

		public ERRoadShape(float width)
		{
			nodes = new List<Vector2>();
			nodes.Add(new Vector2((0f - width) * 0.5f, 0f));
			nodes.Add(new Vector2(width * 0.5f, 0f));
			hardEdge = new List<bool> { false, false };
			symmetrical = true;
			leftSidewalkOffset = 0f;
			rightSidewalkOffset = 0f;
			selectedNode = (selectedLaneNode = 0);
			lanes = new List<ERLane>();
			lanes.Add(new ERLane(-0.5f, ERLaneDirection.Left, 0));
			lanes.Add(new ERLane(0.5f, ERLaneDirection.Right, 0));
			nodesV3 = new List<Vector3>();
			priorityNodeIndexLeft = 0;
			priorityNodeIndexRight = 1;
			outerLaneMarkingLeftIndex = -1;
			outerLaneMarkingRightIndex = -1;
			outerOuterLaneMarkingLeftIndex = -1;
			outerOuterLaneMarkingRightIndex = -1;
			includeOuterlaneLeftInShape = false;
			includeOuterlaneRightInShape = false;
			leftLanes = -1;
			rightLanes = -1;
			isSymmetrical = 0;
			isset = true;
		}

		public void OQDDCDOOOQ(List<Vector2> _nodes)
		{
			nodes = new List<Vector2>(_nodes);
		}

		public void Copy(ERRoadShape shape)
		{
			nodes = new List<Vector2>(shape.nodes);
			hardEdge = new List<bool>(shape.hardEdge);
			symmetrical = shape.symmetrical;
			leftSidewalkOffset = shape.leftSidewalkOffset;
			rightSidewalkOffset = shape.rightSidewalkOffset;
			selectedNode = (selectedLaneNode = 0);
			lanes.Clear();
			foreach (ERLane lane in shape.lanes)
			{
				lanes.Add(new ERLane(lane));
			}
			nodesV3 = new List<Vector3>(shape.nodesV3);
			priorityNodeIndexLeft = shape.priorityNodeIndexLeft;
			priorityNodeIndexRight = shape.priorityNodeIndexRight;
			outerLaneMarkingLeftIndex = shape.outerLaneMarkingLeftIndex;
			includeOuterlaneLeftInShape = shape.includeOuterlaneLeftInShape;
			includeOuterlaneRightInShape = shape.includeOuterlaneRightInShape;
			outerLaneMarkingRightIndex = shape.outerLaneMarkingRightIndex;
			outerOuterLaneMarkingLeftIndex = shape.outerOuterLaneMarkingLeftIndex;
			outerOuterLaneMarkingRightIndex = shape.outerOuterLaneMarkingRightIndex;
			isSymmetrical = shape.isSymmetrical;
			leftLanes = shape.leftLanes;
			rightLanes = shape.rightLanes;
			isset = true;
		}

		public void IsSymmetrical()
		{
			float num = Mathf.Floor((float)nodes.Count * 0.5f);
			isSymmetrical = 2;
			for (int i = 0; (float)i < num; i++)
			{
				Vector2 vector = nodes[nodes.Count - 1 - i];
				vector.x *= -1f;
				if (nodes[i] != vector)
				{
					isSymmetrical = 1;
					break;
				}
			}
		}
	}
}
