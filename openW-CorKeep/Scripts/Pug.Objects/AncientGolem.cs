using System.Collections;
using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class AncientGolem : EntityMonoBehaviour
{
	private const float LIGHT_INTENSITY_MIN = 0.5f;

	private const float LIGHT_INTENSITY_MAX = 1.5f;

	public Light golemLight;

	[ColorUsage(false, true)]
	public Color emissiveMinColor = Color.white;

	[ColorUsage(false, true)]
	public Color emissiveMaxColor = Color.white;

	private readonly int m_AttackEvent = SpriteAsset.StringToHash("attack");

	public override Vector3 center => base.center + Vector3.up * 1.5f;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 255050412)
		{
			golemLight.intensity = 0f;
			spriteObjects[0].emissiveColor = Color.clear;
			spriteObjects[0].PlayAnimation(-601574123);
		}
		if (animID == 910517187)
		{
			StartCoroutine(WakeUp_Coroutine());
			AudioManager.Sfx(SfxID.Bell, base.transform.position, 0.35f, 1.35f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		}
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.MediumPurplePuff, base.transform.position, 80);
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
		}
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_AttackEvent == hash)
		{
			StartCoroutine(LightRangeChange_Coroutine(1.5f, 0.5f, emissiveMaxColor, emissiveMinColor, 0.7f));
		}
	}

	protected override void OnDeath()
	{
		StopAllCoroutines();
		Manager.effects.ExploDisc(center);
	}

	public IEnumerator WakeUp_Coroutine()
	{
		StartCoroutine(LightRangeChange_Coroutine(0f, 1.5f, Color.clear, emissiveMaxColor, 1.5f));
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(LightRangeChange_Coroutine(1.5f, 0.5f, emissiveMaxColor, emissiveMinColor, 1f));
	}

	public IEnumerator LightRangeChange_Coroutine(float StartIntensity, float EndIntensity, Color startColor, Color endColor, float Duration)
	{
		TimerSimple timer = new TimerSimple(Duration);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			float elapsedRatio = timer.elapsedRatio;
			Mathf.Lerp(StartIntensity, EndIntensity, elapsedRatio);
			golemLight.intensity = Mathf.Lerp(StartIntensity, EndIntensity, elapsedRatio);
			spriteObjects[0].emissiveColor = Color.Lerp(startColor, endColor, elapsedRatio);
			yield return null;
		}
		golemLight.intensity = EndIntensity;
	}
}
