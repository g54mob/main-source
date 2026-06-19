using System.Collections.Generic;
using UnityEngine;

public class RobotSwarmer : EntityMonoBehaviour
{
	private Vector3 lastPosition;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	private float walkSfxFadeInDuration = 0.3f;

	private float walkSfxFadeOutDuration = 0.7f;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateGraphicsFromObjectInfo(base.objectInfo);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		bool flag = base.transform.position != lastPosition;
		if (flag && loopingSfx.Count == 0)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx)
			{
				item.FadeOutAndStop();
			}
			loopingSfx.Clear();
			AudioManager.SfxFollowTransform(SfxTableID.robotPatrollerWalkLoopSfx2, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.ROBOT_SWARMER, reuseSfxs: false, playOnGamepad: false, loopingSfx, 2.5f);
			foreach (AudioManager.RunningSfxReference item2 in loopingSfx)
			{
				if (item2.IsValid)
				{
					item2.FadeIn(walkSfxFadeInDuration, startVolumeAtZero: true);
				}
			}
		}
		else if (!flag && loopingSfx.Count > 0)
		{
			foreach (AudioManager.RunningSfxReference item3 in loopingSfx)
			{
				if (item3.IsValid)
				{
					item3.FadeOutAndStop(walkSfxFadeOutDuration);
				}
			}
			loopingSfx.Clear();
		}
		lastPosition = base.transform.position;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID != -414722770)
		{
			return;
		}
		Manager.effects.PlayPuff(PuffID.SmallPurplePuff, base.transform.position, 30);
		if (hasShadow)
		{
			shadow.SetActive(value: false);
		}
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
		int num = 1;
		if (Random.value < 0.5f)
		{
			num = -1;
		}
		Manager.effects.PlayTempSprite(SpriteTempEffectID.HitEffect, center + new Vector3(0f, 2f, -2f) + offset, (float)num * 0.8f);
	}

	protected override void DeathEffect()
	{
		Manager.effects.ExploDisc(center, 0.25f);
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}
}
