using System;
using UnityEngine;

namespace Pathfinding
{
	public class RandomPath : ABPath
	{
		public int searchLength;

		public int spread;

		public float aimStrength;

		private PathNode chosenNodeR;

		private PathNode maxGScoreNodeR;

		private int maxGScore;

		public Vector3 aim;

		private int nodesEvaluatedRep;

		private readonly System.Random rnd;

		public override bool FloodingPath => false;

		protected override bool hasEndPoint => false;

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

		protected override void Initialize()
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}
	}
}
