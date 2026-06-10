using System;
using UnityEngine;

namespace NSEipix.TaskManager
{
	public class StepDoForTime : Step
	{
		private Action<float> action;

		private float duration;

		private float progress;

		public StepDoForTime(Action<float> action, float duration)
		{
			this.action = action;
			this.duration = duration;
			progress = 0f;
		}

		public override bool IsCompleted()
		{
			if (base.Timer >= duration)
			{
				return true;
			}
			return false;
		}

		public override void OnCompleted()
		{
			if (!(progress >= 1f))
			{
				progress = 1f;
				action(progress);
			}
		}

		protected override void OnUpdate()
		{
			float a = base.Timer / duration;
			progress = Mathf.Min(a, 1f);
			action(progress);
		}
	}
}
