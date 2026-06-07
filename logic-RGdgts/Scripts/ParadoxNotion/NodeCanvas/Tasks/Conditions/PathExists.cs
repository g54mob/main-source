using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Conditions
{
	public class PathExists : ConditionTask<NavMeshAgent>
	{
		public BBParameter<Vector3> targetPosition;

		[BlackboardOnly]
		public BBParameter<List<Vector3>> savePathAs;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
