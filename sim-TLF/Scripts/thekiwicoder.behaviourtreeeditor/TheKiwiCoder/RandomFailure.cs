using System;
using UnityEngine;

namespace TheKiwiCoder
{
	[Serializable]
	public class RandomFailure : ActionNode
	{
		[Range(0f, 1f)]
		[Tooltip("Percentage chance of failure")]
		public float chanceOfFailure = 0.5f;

		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			if (UnityEngine.Random.value <= chanceOfFailure)
			{
				return State.Failure;
			}
			return State.Success;
		}
	}
}
