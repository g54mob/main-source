using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	[ReplayComponentPreparer(typeof(Animator))]
	internal sealed class AnimatorPreparer : ComponentPreparer<Animator>
	{
		public override void PrepareForPlayback(Animator component, ReplayState additionalData)
		{
			additionalData.Write(component.enabled);
			component.enabled = false;
		}

		public override void PrepareForGameplay(Animator component, ReplayState additionalData)
		{
			bool enabled = additionalData.ReadBool();
			component.enabled = enabled;
		}
	}
}
