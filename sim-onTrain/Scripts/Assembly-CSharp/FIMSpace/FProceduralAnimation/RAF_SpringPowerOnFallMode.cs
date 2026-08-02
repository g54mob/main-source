using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_SpringPowerOnFallMode : RagdollAnimatorFeatureBase
	{
		private FUniversalVariable springsOnFallPower;

		private FUniversalVariable transitionDuration;

		private float _sd;

		public override bool OnInit()
		{
			springsOnFallPower = base.InitializedWith.RequestVariable("Power", 1f);
			transitionDuration = base.InitializedWith.RequestVariable("Transition Duration:", 0.15f);
			base.ParentRagdollHandler.AddToLateUpdateLoop(Update);
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromLateUpdateLoop(Update);
		}

		private void Update()
		{
			if (!base.InitializedWith.Enabled)
			{
				return;
			}
			float? overrideSpringsValueOnFall = base.ParentRagdollHandler.OverrideSpringsValueOnFall;
			if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
			{
				if (base.ParentRagdollHandler.OverrideSpringsValueOnFall.HasValue)
				{
					SmoothChange(base.ParentRagdollHandler.SpringsValue, transitionDuration.GetFloat());
					if (base.ParentRagdollHandler.OverrideSpringsValueOnFall == base.ParentRagdollHandler.SpringsValue)
					{
						base.ParentRagdollHandler.OverrideSpringsValueOnFall = null;
					}
				}
			}
			else if (base.ParentRagdollHandler.IsFallingOrSleep)
			{
				if (!base.ParentRagdollHandler.OverrideSpringsValueOnFall.HasValue)
				{
					base.ParentRagdollHandler.OverrideSpringsValueOnFall = base.ParentRagdollHandler.GetCurrentMainSpringsValue;
				}
				SmoothChange(springsOnFallPower.GetFloat(), transitionDuration.GetFloat());
			}
			if (overrideSpringsValueOnFall != base.ParentRagdollHandler.OverrideSpringsValueOnFall)
			{
				base.ParentRagdollHandler.User_UpdateJointsPlayParameters(reset: false);
			}
		}

		private void SmoothChange(float to, float duration)
		{
			base.ParentRagdollHandler.OverrideSpringsValueOnFall = Mathf.SmoothDamp(base.ParentRagdollHandler.OverrideSpringsValueOnFall.Value, to, ref _sd, duration, 10000000f, base.ParentRagdollHandler.Delta);
			if (Mathf.Abs(base.ParentRagdollHandler.OverrideSpringsValueOnFall.Value - to) < 0.1f)
			{
				base.ParentRagdollHandler.OverrideSpringsValueOnFall = to;
			}
		}
	}
}
