using UnityEngine;

namespace Pathfinding
{
	public class XPath : ABPath
	{
		public PathEndingCondition endingCondition;

		public new static XPath Construct(Vector3 start, Vector3 end, OnPathDelegate callback = null)
		{
			return null;
		}

		protected override void Reset()
		{
		}

		protected override bool EndPointGridGraphSpecialCase(GraphNode endNode)
		{
			return false;
		}

		protected override void CompletePathIfStartIsValidTarget()
		{
		}

		private void ChangeEndNode(GraphNode target)
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}
	}
}
