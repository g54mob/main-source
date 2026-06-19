using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class SoccerGoal : NetworkEntityBehaviourBase
{
	public Transform ballResetTransform;

	public GameObject soccerBall;

	public GameObject goalVFX;

	public GameObject poofVFX;

	private void OnTriggerEnter(Collider other)
	{
		if (base.isServer && GameUtil.isReady && soccerBall != null && soccerBall.TryGetEntity(out var entity) && other.TryGetEntity(out var entity2) && entity == entity2)
		{
			ScoreGoal(entity.GetObject<Grabbable>());
		}
	}

	private void ScoreGoal(Grabbable grabbable)
	{
		NetworkAggroManagerBase<VFXManager>.instance.Play(poofVFX, grabbable.transform.position);
		NetworkAggroManagerBase<VFXManager>.instance.Play(poofVFX, ballResetTransform.position);
		NetworkAggroManagerBase<VFXManager>.instance.Play(goalVFX, grabbable.transform.position);
		grabbable.ServerBreakEntireStack();
		GameUtil.ServerTeleportBox(grabbable.entity, ballResetTransform.position, ballResetTransform.rotation);
		grabbable.GetComponent<Rigidbody>().velocity = Vector3.zero;
		grabbable.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		NetworkAggroManagerBase<AchievementManager>.instance.ServerUnlockAchievement("ach_breakroom_goal");
	}

	public override bool Weaved()
	{
		return true;
	}
}
