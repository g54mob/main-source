using Aggro.Core.Networking;
using UnityEngine;

public class PlayerStressVisual : NetworkEntityBehaviourBase
{
	private static readonly int CrashingOut = Shader.PropertyToID("_crashingOut");

	public PlayerStress playerStress;

	[Header("stress VFX")]
	public GameObject collisionStressVFX;

	public ParticleSystem sweatingVFX;

	public float sweatingEmmissionRatio = 0.1f;

	public Vector2 sweatingSpeedRange = Vector2.zero;

	public int sweatingStressThreshold = 1;

	public ParticleSystem crashingOutVFX;

	private float stressScreenEffectTime = 1f;

	public AnimationCurve stressScreenEffectCurve;

	private float crashingOutEffect;

	public float crashingOutEffectGrowSpeed = 1f;

	public Transform playerUITransform;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvLocalPlayerStressAdded>(OnLocalPlayerStressAdded);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvLocalPlayerStressAdded>(OnLocalPlayerStressAdded);
		Shader.SetGlobalFloat(CrashingOut, 0f);
	}

	private void OnLocalPlayerStressAdded(EvLocalPlayerStressAdded ev)
	{
		if (base.isLocalPlayer)
		{
			NetworkAggroManagerBase<VFXManager>.instance.Play(collisionStressVFX, base.entity.transform.position);
			stressScreenEffectTime = 0f;
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isLocalPlayer)
		{
			stressScreenEffectTime += Time.deltaTime;
			float min = playerStress.stressNormalizedValue / 2f;
			float value = stressScreenEffectCurve.Evaluate(Mathf.Clamp(stressScreenEffectTime, min, 1f));
			Shader.SetGlobalFloat("_stressEffect", value);
			float num = (playerStress.crashingOut ? 1f : (-1f));
			crashingOutEffect += crashingOutEffectGrowSpeed * Time.deltaTime * num;
			crashingOutEffect = Mathf.Clamp01(crashingOutEffect);
			Shader.SetGlobalFloat(CrashingOut, crashingOutEffect);
		}
		ParticleSystem.EmissionModule emission = sweatingVFX.emission;
		ParticleSystem.MainModule main = sweatingVFX.main;
		main.simulationSpeed = Mathf.Lerp(sweatingSpeedRange.x, sweatingSpeedRange.y, playerStress.stressNormalizedValue);
		if (playerStress.stressNormalizedValue >= (float)sweatingStressThreshold)
		{
			emission.rateOverTime = playerStress.stressNormalizedValue * sweatingEmmissionRatio;
		}
		else
		{
			emission.rateOverTime = 0f;
		}
		ParticleSystem.EmissionModule emission2 = crashingOutVFX.emission;
		if (playerStress.crashingOut)
		{
			emission2.enabled = true;
		}
		else
		{
			emission2.enabled = false;
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
