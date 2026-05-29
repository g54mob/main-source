using Pathfinding.RVO.Sampled;
using UnityEngine;

namespace Pathfinding.RVO
{
	public class RVOQuadtree
	{
		private struct Node
		{
			public int child00;

			public Agent linkedList;

			public byte count;

			public float maxSpeed;

			public void Add(Agent agent)
			{
			}

			public void Distribute(Node[] nodes, Rect r)
			{
			}

			public float CalculateMaxSpeed(Node[] nodes, int index)
			{
				return 0f;
			}
		}

		private struct QuadtreeQuery
		{
			public Vector2 p;

			public float speed;

			public float timeHorizon;

			public float agentRadius;

			public float maxRadius;

			public Agent agent;

			public Node[] nodes;

			public void QueryRec(int i, Rect r)
			{
			}
		}

		private const int LeafSize = 15;

		private float maxRadius;

		private Node[] nodes;

		private int filledNodes;

		private Rect bounds;

		public void Clear()
		{
		}

		public void SetBounds(Rect r)
		{
		}

		private int GetNodeIndex()
		{
			return 0;
		}

		public void Insert(Agent agent)
		{
		}

		public void CalculateSpeeds()
		{
		}

		public void Query(Vector2 p, float speed, float timeHorizon, float agentRadius, Agent agent)
		{
		}

		public void DebugDraw()
		{
		}

		private void DebugDrawRec(int i, Rect r)
		{
		}
	}
}
