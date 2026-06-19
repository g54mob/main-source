using System.Collections;
using System.Collections.Generic;
using Pug.RP;
using Unity.Mathematics;
using UnityEngine;

public class MoldWorshipMural : EntityMonoBehaviour
{
	private Vector4[] tulipPositionsArray;

	private static readonly int TulipPositionsArray = Shader.PropertyToID("TulipPositionsArray");

	private const int MAX_TULIPS = 5;

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
		InitTulipPositionsArray();
		if (isOpen)
		{
			animator.SetTrigger(-1536130140);
		}
		else
		{
			animator.SetTrigger(80170468);
		}
	}

	private void InitTulipPositionsArray()
	{
		tulipPositionsArray = new Vector4[5];
		for (int i = 0; i < 5; i++)
		{
			tulipPositionsArray[i] = new Vector4(0f, 0f, 0f, 0f);
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

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		List<PlayerController> allPlayers = Manager.main.allPlayers;
		List<Vector4> list = new List<Vector4>();
		foreach (PlayerController item in allPlayers)
		{
			Vector3 position = item.transform.position;
			if (item.visuallyEquippedContainedObject.objectID == ObjectID.GlowingTulipFlower && math.distancesq(position, base.transform.position) < 100f)
			{
				list.Add(new Vector4(position.x, 0f, position.z, 1f));
			}
		}
		for (int i = 0; i < tulipPositionsArray.Length; i++)
		{
			if (list.Count > i)
			{
				tulipPositionsArray[i] = list[i];
			}
			else
			{
				tulipPositionsArray[i] = Vector4.zero;
			}
		}
		Shader.SetGlobalVectorArray(TulipPositionsArray, tulipPositionsArray);
		foreach (SpriteRenderer emissiveRenderer in emissiveRenderers)
		{
			emissiveRenderer.material.SetFloat(EmissiveAdd, emissiveStrengthAddition);
		}
		if (updateShadowsContinuously && shadowRenderers != null && shadowRenderers.Count > 0)
		{
			Bounds bounds = shadowRenderers[0].bounds;
			for (int j = 1; j < shadowRenderers.Count; j++)
			{
				bounds.Encapsulate(shadowRenderers[j].bounds);
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
