using System.Collections;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class WayPoint : Portal
{
	private float distanceToActivateStandingOn;

	public SpriteObject PlatformSO;

	public SpriteRenderer PlatformGlowSR;

	public Light platformLight;

	[ColorUsage(false, true)]
	public Color platformEmissiveMinColor = Color.white;

	[ColorUsage(false, true)]
	public Color platformEmissiveColor = Color.white;

	public Color platformGlowColor = Color.white;

	public ParticleSystem RisingParticles;

	private bool m_isCoreWaypoint;

	public override bool isActivated => base.objectData.amount >= 600;

	public override void OnOccupied()
	{
		base.OnOccupied();
		wasActivePreviousFrame = isActivated;
		if (EntityUtility.TryGetComponentData<WayPointCD>(base.entity, base.world, out var value))
		{
			m_isCoreWaypoint = value.isCoreWaypoint;
		}
		if (isActivated)
		{
			PlatformSO.PlayAnimation(1260321794);
			SetGlow(0.5f);
			return;
		}
		if (m_isCoreWaypoint)
		{
			PlatformSO.PlayAnimation(0);
			PlatformSO.SetVariantByIndex(0);
		}
		else if (PlatformSO != null)
		{
			PlatformSO.PlayAnimation(-601574123);
		}
		SetGlow(0f);
	}

	protected override void UpdateVisuals()
	{
		if (!wasActivePreviousFrame && isActivated)
		{
			wasActivePreviousFrame = isActivated;
			StartCoroutine(Activate_Coroutine());
		}
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (animID == -601574123 && (isActivated || m_isCoreWaypoint))
		{
			return false;
		}
		return base.ShouldPlayAnimTrigger(animID);
	}

	private void SetGlow(float strength)
	{
		PlatformSO.emissiveColor = Color.Lerp(platformEmissiveMinColor, platformEmissiveColor, math.pow(strength, 3.5f));
		PlatformGlowSR.color = Color.Lerp(Color.clear, platformGlowColor, strength);
		int num = 40;
		ParticleSystem.EmissionModule emission = RisingParticles.emission;
		emission.rateOverTime = Mathf.Min((float)num * strength, 20f);
		float a = 0.05f;
		float b = 0.75f;
		platformLight.intensity = Mathf.Lerp(a, b, strength);
	}

	public IEnumerator GlowChange_Coroutine(float StartStrength, float EndStrength, float Duration)
	{
		TimerSimple timer = new TimerSimple(Duration);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			SetGlow(Mathf.Lerp(StartStrength, EndStrength, timer.elapsedRatio));
			yield return null;
		}
	}

	public IEnumerator Activate_Coroutine()
	{
		PlatformSO.PlayAnimation(-601574123);
		StartCoroutine(GlowChange_Coroutine(0f, 1f, 2f));
		AudioManager.Sfx(SfxTableID.waypointStartup, base.transform.position);
		yield return new WaitForSeconds(2f);
		PlatformSO.PlayAnimation(1260321794);
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		Manager.effects.PlayPuff(PuffID.AncientSparks, position, 30);
		Manager.effects.PlayPuff(PuffID.EnergyPillarFlash, position, 1);
		if (!m_isCoreWaypoint)
		{
			Manager.effects.PlayPuff(PuffID.EnergyRipple, position, 1);
		}
		AudioManager.Sfx(SfxTableID.waypointActivate, base.transform.position);
		StartCoroutine(GlowChange_Coroutine(1f, 0.5f, 2f));
	}
}
