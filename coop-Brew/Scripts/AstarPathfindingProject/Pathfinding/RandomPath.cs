using System;
using UnityEngine;

namespace Pathfinding
{
	public class RandomPath : ABPath
	{
		public int searchLength;

		public int spread;

		public float aimStrength;

		private uint chosenPathNodeIndex;

		private uint chosenPathNodeGScore;

		private uint maxGScorePathNodeIndex;

		private uint maxGScore;

		public Vector3 aim;

		private int nodesEvaluatedRep;

		private readonly System.Random rnd;

		protected override bool hasEndPoint => false;

		public override bool endPointKnownBeforeCalculation => false;

		protected override void Reset()
		{
		}

		public static RandomPath Construct(Vector3 start, int length, OnPathDelegate callback = null)
		{
			return null;
		}

		protected RandomPath Setup(Vector3 start, int length, OnPathDelegate callback)
		{
			return null;
		}

		protected override void ReturnPath()
		{
		}

		protected override void Prepare()
		{
		}

		protected override void OnHeapExhausted()
		{
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
		}

		public override void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
		}
	}
}
