using System;
using UnityEngine;
using UnityEngine.AI;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class NavMeshAgentValidator : Validator
	{
		[Tooltip("The agent whose path has to be verified.")]
		public NavMeshAgent Agent;

		public NavMeshAgentValidator()
		{
			Enabled = true;
		}

		public override bool Validate()
		{
			if (Agent != null && (Agent.isPathStale || Agent.pathStatus == NavMeshPathStatus.PathInvalid))
			{
				return false;
			}
			return true;
		}
	}
}
