using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class HydraBossIceShardMortarProjectile : EntityMonoBehaviour
{
	public AnimationCurve flyingCurve;

	public Transform srPivot;

	private TimerSimple _timer;

	private bool explosionPlayed;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0)
		{
			_timer.Start(1.5f);
		}
		else
		{
			_timer.Stop();
		}
		explosionPlayed = false;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.entityExist)
		{
			UpdateFlyingPosition();
		}
	}

	private void UpdateFlyingPosition()
	{
		MortarProjectileCD componentData = EntityUtility.GetComponentData<MortarProjectileCD>(base.entity, base.world);
		Entity owner = EntityUtility.GetComponentData<OwnerReferenceCD>(base.entity, base.world).owner;
		if (owner == Entity.Null)
		{
			return;
		}
		HydraBoss hydraBoss = Manager.memory.GetEntityMono(owner) as HydraBoss;
		if (hydraBoss == null)
		{
			return;
		}
		if (_timer.isRunning && !_timer.isTimerElapsed)
		{
			Vector3 position = hydraBoss.GetActiveHydraData().controller.controlPoints[5].transform.position;
			Vector3 b = EntityMonoBehaviour.ToRenderFromWorld(componentData.targetPosition);
			srPivot.position = Vector3.Lerp(position, b, _timer.elapsedRatio);
			srPivot.position = new Vector3(srPivot.position.x, flyingCurve.Evaluate(_timer.elapsedRatio), srPivot.position.z);
		}
		else
		{
			srPivot.position = EntityMonoBehaviour.ToRenderFromWorld(componentData.targetPosition);
			if (!explosionPlayed)
			{
				Explode();
			}
		}
	}

	protected void Explode()
	{
		explosionPlayed = true;
		base.OnDeath();
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}
}
