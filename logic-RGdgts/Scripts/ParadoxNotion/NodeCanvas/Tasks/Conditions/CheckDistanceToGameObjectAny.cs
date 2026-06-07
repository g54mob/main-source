using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckDistanceToGameObjectAny : ConditionTask<Transform>
	{
		public BBParameter<List<GameObject>> targetObjects;

		public CompareMethod checkType;

		public BBParameter<float> distance;

		public float floatingPoint;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> allResults;

		[BlackboardOnly]
		public BBParameter<GameObject> closerResult;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
