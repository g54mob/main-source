using UnityEngine;

namespace Pathfinding
{
	public class FloodPathTracer : ABPath
	{
		protected FloodPath flood;

		protected override bool hasEndPoint => false;

		public static FloodPathTracer Construct(Vector3 start, FloodPath flood, OnPathDelegate callback = null)
		{
			return null;
		}

		protected void Setup(Vector3 start, FloodPath flood, OnPathDelegate callback)
		{
		}

		protected override void Reset()
		{
		}

		protected override void Initialize()
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}

		public void Trace(GraphNode from)
		{
		}
	}
}
