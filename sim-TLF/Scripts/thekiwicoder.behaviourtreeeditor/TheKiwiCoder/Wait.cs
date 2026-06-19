using System;
using UnityEngine;

namespace TheKiwiCoder
{
	[Serializable]
	public class Wait : ActionNode
	{
		[Tooltip("Amount of time to wait before returning success")]
		public NodeProperty<float> duration = new NodeProperty<float>
		{
			Value = 1f
		};

		private float startTime;

		protected override void OnStart()
		{
			startTime = Time.time;
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			if (Time.time - startTime > duration.Value)
			{
				return State.Success;
			}
			return State.Running;
		}
	}
}
