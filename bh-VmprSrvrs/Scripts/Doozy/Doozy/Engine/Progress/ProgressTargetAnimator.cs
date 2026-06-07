using UnityEngine;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Targets/Progress Target Animator", 13)]
	[DefaultExecutionOrder(-99)]
	public class ProgressTargetAnimator : ProgressTarget
	{
		public Animator Animator;

		public string ParameterName;

		public TargetProgress TargetProgress;

		public override void UpdateTarget(Progressor progressor)
		{
		}

		private void Reset()
		{
		}

		private void UpdateReference()
		{
		}
	}
}
