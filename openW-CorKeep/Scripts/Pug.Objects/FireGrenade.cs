using System;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

public class FireGrenade : Projectile
{
	public ParticleEffectSpawner projectileTrail;

	public Transform verticalTransform;

	public float maxHeight = 0.625f;

	private Vector3 startPosition;

	protected override void Awake()
	{
		base.Awake();
		startPosition = verticalTransform.localPosition;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
		projectileTrail.enabled = true;
		projectileTrail.transform.LookAt(projectileTrail.transform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
		projectileTrail.transform.LookAt(projectileTrail.transform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
		UpdateVerticalBouncePosition();
	}

	private void UpdateVerticalBouncePosition()
	{
		float fraction;
		NetworkTick currentTickOnClient = EntityUtility.GetCurrentTickOnClient(base.entity, base.world, out fraction);
		DestroyTimerCD componentData = EntityUtility.GetComponentData<DestroyTimerCD>(base.entity, base.world);
		GroundBouncableProjectileCD componentData2 = EntityUtility.GetComponentData<GroundBouncableProjectileCD>(base.entity, base.world);
		if (componentData2.startFallTick.IsValid)
		{
			NetworkTick startFallTick = componentData2.startFallTick;
			NetworkTick currentTick = startFallTick;
			currentTick.Decrement();
			int simulationTickRate = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			float time = componentData.timer.GetPercentageFinished(startFallTick);
			float time2 = componentData.timer.GetPercentageFinished(currentTick);
			float num = componentData2.verticalCurve.Evaluate(in time) * maxHeight;
			float num2 = componentData2.verticalCurve.Evaluate(in time2) * maxHeight;
			float num3 = (num - num2) * (float)simulationTickRate;
			float num4 = NetworkTimeUtilities.TimeSincePastTickInSeconds(startFallTick, currentTickOnClient, fraction, (uint)simulationTickRate);
			if (componentData2.fallingInWater)
			{
				float start = num + num3 * num4;
				float end = -0.25f + -0.25f * math.sin(-MathF.PI * num4);
				float y = math.lerp(start, end, math.clamp(num4 * 2f, 0f, 1f));
				verticalTransform.localPosition = startPosition + new Vector3(0f, y, 0f);
			}
			else
			{
				float num5 = num3 * num4 + -2.455f * num4 * num4;
				float num6 = -4f * (1f - Mathf.Exp(-5f * Mathf.Clamp01(num5 / -20f)));
				verticalTransform.localPosition = startPosition + new Vector3(0f, num + num6, 0f);
			}
		}
		else
		{
			float time3 = componentData.timer.GetPercentageFinished(currentTickOnClient);
			float y2 = componentData2.verticalCurve.Evaluate(in time3) * maxHeight;
			verticalTransform.localPosition = startPosition + new Vector3(0f, y2, 0f);
		}
	}

	protected override void OnDeath()
	{
		Manager.effects.ExploDisc(SRPivot.position + new Vector3(0f, 2f, -2f), 0.25f);
		projectileTrail.enabled = false;
	}
}
