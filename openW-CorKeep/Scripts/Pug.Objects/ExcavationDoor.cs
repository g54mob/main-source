using System.Collections;
using System.Collections.Generic;
using Pug.RP;
using Pug.Sprite;
using UnityEngine;

public class ExcavationDoor : Chest
{
	public float emissiveStrengthAddition;

	public List<SpriteRenderer> emissiveRenderers;

	public List<MeshRenderer> shadowRenderers;

	private bool isOpen;

	private bool updateShadowsContinuously;

	public SpriteRenderer keySR;

	public SpriteObject keySO;

	public List<SpriteObject> yellowLights;

	public SpriteObject openingDecal1;

	public SpriteObject openingDecal2;

	public SpriteObject openingDecal3;

	private List<AudioManager.RunningSfxReference> loopingSfx2 = new List<AudioManager.RunningSfxReference>();

	private PoolableAudioSource rumbleSound;

	public override void OnOccupied()
	{
		isOpen = base.variation >= 1;
		base.OnOccupied();
		foreach (SpriteObject yellowLight in yellowLights)
		{
			yellowLight.gameObject.SetActive(!isOpen);
		}
		if (isOpen)
		{
			animator.SetTrigger(-1536130140);
		}
		else
		{
			animator.SetTrigger(80170468);
		}
		AudioManager.Sfx(SfxTableID.excavationDoorIdleSfx, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx2);
		ResetDecals();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!isOpen)
		{
			isOpen = base.variation >= 1;
		}
		keySR.gameObject.SetActive(isOpen);
		int animationHash = (isOpen ? 1260321794 : (-601574123));
		keySO.PlayAnimation(animationHash);
		keySO.gameObject.SetActive(!isOpen);
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

	protected override void HandleInitialAnimationTrigger(int animID)
	{
		if (animID != 238408899 || !isOpen)
		{
			base.HandleInitialAnimationTrigger(animID);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID != 238408899 || !isOpen)
		{
			base.HandleAnimationTrigger(animID);
		}
	}

	public void AE_RumbleAndInitateOpen()
	{
		AudioManager.Sfx(SfxID.excavation_gate_open_3, base.transform.position, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.CINEMATIC_EVENTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 30f, 20f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 6f, 0f, 1f, 0.5f);
		Manager.camera.ShakeCameraNow(0.4f, 2.5f, 3f, null, null, 1, 12f);
		if (loopingSfx2 != null)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx2)
			{
				item.FadeOutAndStop(2.5f);
			}
			loopingSfx2.Clear();
		}
		foreach (SpriteObject yellowLight in yellowLights)
		{
			yellowLight.gameObject.SetActive(value: false);
		}
	}

	public void AE_RumbleAndDoorStartToGoDown()
	{
		Manager.camera.ShakeCameraNow(6f, 1f, 1.4f, null, null, 1, 15f);
	}

	public void AE_DoneOpening()
	{
		Manager.camera.ShakeCameraNow(0.2f, 2f, 2.4f, null, null, 1, 15f);
	}

	public void ResetDecals()
	{
		foreach (SpriteObject yellowLight in yellowLights)
		{
			yellowLight.PlayAnimation(1260321794);
		}
		openingDecal1.PlayAnimation(-601574123);
		openingDecal2.PlayAnimation(-601574123);
		openingDecal3.PlayAnimation(-601574123);
	}

	public void AE_YellowLightsOn()
	{
		foreach (SpriteObject yellowLight in yellowLights)
		{
			yellowLight.PlayAnimation(1260321794);
		}
	}

	public void AE_YellowLightsOff()
	{
		foreach (SpriteObject yellowLight in yellowLights)
		{
			yellowLight.PlayAnimation(-601574123);
		}
	}

	public void AE_ActivateDecal1()
	{
		openingDecal1.PlayAnimation(1260321794);
		Manager.camera.ShakeCameraNow(0.1f, 0f, 2f, null, null, 0, 8f);
	}

	public void AE_ActivateDecal2()
	{
		openingDecal2.PlayAnimation(1260321794);
		Manager.camera.ShakeCameraNow(0.1f, 0f, 2f, null, null, 0, 8f);
	}

	public void AE_ActivateDecal3()
	{
		openingDecal3.PlayAnimation(1260321794);
		Manager.camera.ShakeCameraNow(0.1f, 0f, 2f, null, null, 0, 8f);
	}

	private IEnumerator FadeOutSound_Coroutine()
	{
		yield return new WaitForSeconds(0.5f);
		Manager.camera.ShakeCameraNow(4f, 2.5f, 3f, null, null, 1, 7f);
		rumbleSound = AudioManager.Sfx(SfxID.EarthquakeSpawn, base.transform.position);
		updateShadowsContinuously = true;
		yield return new WaitForSeconds(4.5f);
		Manager.camera.ShakeCameraNow(0.2f, 1.8f, 2f, null, null, 1, 25f);
		if (rumbleSound != null)
		{
			rumbleSound.FadeOutAndStop(1f);
			rumbleSound = null;
		}
		yield return new WaitForSeconds(1f);
		updateShadowsContinuously = false;
	}
}
