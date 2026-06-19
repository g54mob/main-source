using UnityEngine;

public class AFPortal : Portal
{
	public SpriteRenderer portalSR;

	private static readonly int LoadingMul = Shader.PropertyToID("_loadingMul");

	private static readonly int EmissiveStrengthMul = Shader.PropertyToID("_emissiveStrengthMul");

	private PoolableAudioSource portalAudioLoop;

	protected override void UpdateVisuals()
	{
		bool flag = isActivated;
		float value = (flag ? 0f : 1f);
		sr.material.SetFloat(LoadingMul, value);
		float value2 = (flag ? 1f : 0f);
		sr.material.SetFloat(EmissiveStrengthMul, value2);
		if (portalEffectSR.gameObject.activeSelf != flag)
		{
			portalEffectSR.gameObject.SetActive(flag);
		}
		if (portalSR.gameObject.activeSelf != flag)
		{
			portalSR.gameObject.SetActive(flag);
		}
		if (!wasActivePreviousFrame && flag)
		{
			wasActivePreviousFrame = flag;
			if (animator != null)
			{
				animator.SetTrigger(2039883312);
				AudioManager.Sfx(SfxTableID.AFSFXPortalAppear, base.transform.position);
			}
		}
		if (flag && portalAudioLoop == null)
		{
			portalAudioLoop = AudioManager.SfxFollowTransform(SfxID.AF_portal_loop, base.transform, 0.2f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 20f);
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		StopAudioLoopsAndTimers();
	}

	private void StopAudioLoopsAndTimers()
	{
		if (portalAudioLoop != null)
		{
			portalAudioLoop.FadeOutAndStop();
			portalAudioLoop = null;
		}
	}
}
