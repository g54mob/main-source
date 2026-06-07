using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Targets/Progress Target Image", 13)]
	[DefaultExecutionOrder(-99)]
	public class ProgressTargetImage : ProgressTarget
	{
		public Image Image;

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
