using System;

namespace EngineCore
{
	[Serializable]
	public class PendingFogTarget
	{
		public FogTarget TargetFogTarget;

		public FogTargetTransitionParams TransitionParams = new FogTargetTransitionParams();

		public int Priority = -1;

		public bool KeepTransitionActive;

		public bool KeepFogUpdateActiveAfterBlend;

		public bool SetFlags;

		public PendingFogTarget()
		{
		}

		public PendingFogTarget(FogTarget targetFogTarget, FogTargetTransitionParams transistionParams, int priority, bool keepTransitionActive, bool keepFogUpdateActiveAfterBlend, bool setFlags)
		{
			TargetFogTarget = targetFogTarget;
			TransitionParams = transistionParams;
			Priority = priority;
			KeepTransitionActive = keepTransitionActive;
			KeepFogUpdateActiveAfterBlend = keepFogUpdateActiveAfterBlend;
			SetFlags = setFlags;
		}
	}
}
