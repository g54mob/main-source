using System.Collections.Generic;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

public class DEMO_LegsAnim_TriggerImpact : MonoBehaviour
{
	public List<LegsAnimator> TriggerOn;

	[Space(5f)]
	public LegsAnimator.PelvisImpulseSettings Landing;

	public LegsAnimator.PelvisImpulseSettings Stopping;

	public LegsAnimator.PelvisImpulseSettings GetHit;

	public void CallLandingImpact()
	{
		CallImpact(Landing);
	}

	public void CallStoppingImpact()
	{
		CallImpact(Stopping);
	}

	public void CallGetHitImpact()
	{
		CallImpact(GetHit);
	}

	public void CallImpact(LegsAnimator.PelvisImpulseSettings settings)
	{
		for (int i = 0; i < TriggerOn.Count; i++)
		{
			TriggerOn[i].User_AddImpulse(settings);
		}
	}
}
