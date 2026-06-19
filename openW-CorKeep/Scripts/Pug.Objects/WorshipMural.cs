using System.Collections;
using System.Collections.Generic;
using Pug.RP;
using UnityEngine;

public class WorshipMural : EntityMonoBehaviour
{
	public float emissiveStrengthAddition;

	public List<SpriteRenderer> emissiveRenderers;

	public List<MeshRenderer> shadowRenderers;

	private static readonly int EmissiveAdd = Shader.PropertyToID("_emissiveAdd");

	private bool isOpen;

	private bool updateShadowsContinuously;

	private PoolableAudioSource rumbleSound;

	public override void OnOccupied()
	{
		isOpen = base.variation == 1;
		base.OnOccupied();
		if (isOpen)
		{
			animator.SetTrigger(-1536130140);
		}
		else
		{
			animator.SetTrigger(80170468);
		}
	}

	protected override void HandleInitialAnimationTrigger(int animID)
	{
		if (animID != 238408899 || !isOpen)
		{
			base.HandleInitialAnimationTrigger(animID);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		foreach (SpriteRenderer emissiveRenderer in emissiveRenderers)
		{
			emissiveRenderer.material.SetFloat(EmissiveAdd, emissiveStrengthAddition);
		}
		if (updateShadowsContinuously && shadowRenderers != null && shadowRenderers.Count > 0)
		{
			Bounds bounds = shadowRenderers[0].bounds;
			for (int i = 1; i < shadowRenderers.Count; i++)
			{
				bounds.Encapsulate(shadowRenderers[i].bounds);
			}
			Shadows.MarkAreaDirty(bounds, allowAmortization: true);
		}
	}

	public void AE_RumbleAndOpenEffects()
	{
		AudioManager.Sfx(SfxID.wall, base.transform.position, 1f, 0.5f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		StartCoroutine(FadeOutSound_Coroutine());
	}

	private IEnumerator FadeOutSound_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
		rumbleSound = AudioManager.Sfx(SfxID.EarthquakeSpawn, base.transform.position);
		updateShadowsContinuously = true;
		yield return new WaitForSeconds(2.5f);
		if (rumbleSound != null)
		{
			rumbleSound.FadeOutAndStop(1f);
			rumbleSound = null;
		}
		yield return new WaitForSeconds(1f);
		updateShadowsContinuously = false;
	}

	public void AE_DoneOpening()
	{
	}
}
