using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_MusclesPowerOnFallMode : RagdollAnimatorFeatureBase
	{
		private FUniversalVariable musclesOnFallMultiplier;

		private FUniversalVariable transitionDuration;

		public override bool OnInit()
		{
			musclesOnFallMultiplier = base.InitializedWith.RequestVariable("Multiplier", 1f);
			transitionDuration = base.InitializedWith.RequestVariable("Transition Duration:", 1f);
			base.ParentRagdollHandler.AddToLateUpdateLoop(Update);
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromLateUpdateLoop(Update);
		}

		private void Update()
		{
			if (base.InitializedWith.Enabled)
			{
				float musclesPowerMultiplier = base.ParentRagdollHandler.musclesPowerMultiplier;
				if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
				{
					base.ParentRagdollHandler.musclesPowerMultiplier = Mathf.MoveTowards(base.ParentRagdollHandler.musclesPowerMultiplier, 1f, base.ParentRagdollHandler.Delta / transitionDuration.GetFloat());
				}
				else if (base.ParentRagdollHandler.IsFallingOrSleep)
				{
					base.ParentRagdollHandler.musclesPowerMultiplier = Mathf.MoveTowards(base.ParentRagdollHandler.musclesPowerMultiplier, musclesOnFallMultiplier.GetFloat(), base.ParentRagdollHandler.Delta / transitionDuration.GetFloat());
				}
				if (musclesPowerMultiplier != base.ParentRagdollHandler.musclesPowerMultiplier)
				{
					base.ParentRagdollHandler.User_UpdateJointsPlayParameters(reset: false);
				}
			}
		}
	}
}
