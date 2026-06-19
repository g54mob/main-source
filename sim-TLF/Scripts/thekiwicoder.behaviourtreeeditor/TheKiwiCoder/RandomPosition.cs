using System;
using UnityEngine;

namespace TheKiwiCoder
{
	[Serializable]
	public class RandomPosition : ActionNode
	{
		[Tooltip("Minimum bounds to generate point")]
		public Vector3 min = Vector2.one * -10f;

		[Tooltip("Maximum bounds to generate point")]
		public Vector3 max = Vector2.one * 10f;

		[Tooltip("Blackboard key to write the result to")]
		public NodeProperty<Vector3> result;

		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			Vector3 value = new Vector3
			{
				x = UnityEngine.Random.Range(min.x, max.x),
				y = UnityEngine.Random.Range(min.y, max.y),
				z = UnityEngine.Random.Range(min.z, max.z)
			};
			result.Value = value;
			return State.Success;
		}
	}
}
