using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERRoadShape
	{
		public List<Vector2> nodes;

		public List<ERLane> lanes;

		public bool symmetrical;

		public float leftSidewalkOffset;

		public float rightSidewalkOffset;

		public int selectedNode;

		public int selectedLaneNode;

		public ERRoadShape(float width)
		{
			nodes = new List<Vector2>();
			nodes.Add(new Vector2((0f - width) * 0.5f, 0f));
			nodes.Add(new Vector2(width * 0.5f, 0f));
			symmetrical = true;
			leftSidewalkOffset = 0f;
			rightSidewalkOffset = 0f;
			selectedNode = (selectedLaneNode = 0);
			lanes = new List<ERLane>();
		}
	}
}
