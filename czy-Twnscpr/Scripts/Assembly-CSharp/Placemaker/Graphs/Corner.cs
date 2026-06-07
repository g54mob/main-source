using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Graphs
{
	[Serializable]
	public class Corner : MonoBehaviour
	{
		public int2 hexPos;

		public List<Square> squares;

		public Mesh colliderMesh;

		public List<Vector2> blitVerts;

		public List<FlowData> flowDatas;

		public bool inFlowUpdateQueue;

		public float angle;

		public byte groundCoverage;

		private void OnDrawGizmos()
		{
		}

		public void AddSquare(Square quad0)
		{
		}
	}
}
