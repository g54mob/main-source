using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Movement")]
	[Description("Check if a path exists for the agent and optionaly save the resulting path positions")]
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
