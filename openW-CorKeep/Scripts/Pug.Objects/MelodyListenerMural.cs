using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MelodyListenerMural : EntityMonoBehaviour
{
	public float emissiveStrengthAddition;

	public List<SpriteRenderer> unlitOrbRenderers;

	public List<SpriteRenderer> litOrbRenderers;

	public List<SpriteRenderer> noteRenderers;

	public List<SpriteRenderer> rimRenderers;

	public SpriteRenderer midLightRenderer;

	private static readonly int EmissiveAdd = Shader.PropertyToID("_emissiveAdd");

	private AffectObjectWhenMelodyPlayedSystem affectSystem;

	private bool isOpen;

	private bool updateShadowsContinuously;

	private int oldProgress;

	private int oldHumIndex;

	private bool setupDone;

	private int dif;

	private Vector3 puffPos = new Vector3(0f, -0.1f, -0.1f);

	private PoolableAudioSource rumbleSound;

	public override void OnOccupied()
	{
		isOpen = base.variation == 1;
		base.OnOccupied();
		animator.SetTrigger(isOpen ? (-1536130140) : 80170468);
		InitializeNotes();
	}

	public void InitializeNotes()
	{
		MelodyID melodyID = EntityUtility.GetComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world).melodyID;
		int[] melody = MelodyData.melodies[0].melody;
		if (melodyID > MelodyID.None)
		{
			melody = MelodyData.melodies[(int)(melodyID - 1)].melody;
		}
		int num = math.min(melody.Length, noteRenderers.Count);
		dif = noteRenderers.Count - num;
		int num2 = (int)math.floor(dif / 2);
		foreach (SpriteRenderer noteRenderer in noteRenderers)
		{
			noteRenderer.enabled = false;
		}
		foreach (SpriteRenderer litOrbRenderer in litOrbRenderers)
		{
			litOrbRenderer.enabled = false;
		}
		foreach (SpriteRenderer unlitOrbRenderer in unlitOrbRenderers)
		{
			unlitOrbRenderer.enabled = false;
		}
		float num3 = 0.0625f;
		float num4 = 0.6875f;
		for (int i = 0; i < num; i++)
		{
			noteRenderers[i + num2].enabled = true;
			unlitOrbRenderers[i + num2].enabled = true;
			float num5 = (float)melody[i] * num3 + num4;
			if (melody[i] > 4)
			{
				num5 += num3;
			}
			Vector3 localPosition = noteRenderers[i + num2].transform.localPosition;
			noteRenderers[i + num2].transform.localPosition = new Vector3(localPosition.x, num5, localPosition.z);
		}
		for (int j = 0; j < num; j++)
		{
			int index = (int)(math.floor((7 - j) / 2) + ((float)j + (float)j * math.pow(-1f, j + 1)) / 2f);
			if (num <= j)
			{
				noteRenderers[index].enabled = false;
			}
		}
		foreach (SpriteRenderer rimRenderer in rimRenderers)
		{
			rimRenderer.enabled = false;
		}
	}

	public void UpdateProgress()
	{
		int num = (int)math.floor(dif / 2);
		isOpen = base.variation == 1;
		if (!isOpen && EntityUtility.HasComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world))
		{
			int humIndex = EntityUtility.GetComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world).humIndex;
			if (humIndex != -1 && humIndex != oldHumIndex)
			{
				animator.SetTrigger(-657533988);
			}
			int melodyProgress = EntityUtility.GetComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world).melodyProgress;
			for (int i = 0; i < litOrbRenderers.Count - dif; i++)
			{
				int index = i + num;
				litOrbRenderers[index].enabled = i < melodyProgress;
			}
			if (melodyProgress > oldProgress)
			{
				animator.SetTrigger(570552902);
				Manager.effects.PlayPuff(PuffID.AncientSparks, litOrbRenderers[melodyProgress - 1].transform.position + puffPos);
			}
			oldProgress = melodyProgress;
			oldHumIndex = humIndex;
		}
		else if (oldProgress != 0)
		{
			oldProgress = 0;
			for (int j = 0; j < litOrbRenderers.Count - dif; j++)
			{
				int index2 = j + num;
				litOrbRenderers[index2].enabled = true;
			}
			animator.SetTrigger(238408899);
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
		UpdateProgress();
		bool flag = false;
		if (EntityUtility.HasComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world))
		{
			flag = !isOpen && EntityUtility.GetComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world).playerHoldingInstrumentExists;
		}
		midLightRenderer.material.SetFloat(EmissiveAdd, emissiveStrengthAddition);
		midLightRenderer.enabled = flag;
		foreach (SpriteRenderer litOrbRenderer in litOrbRenderers)
		{
			litOrbRenderer.material.SetFloat(EmissiveAdd, emissiveStrengthAddition);
		}
	}

	public void AE_RumbleAndOpenEffects()
	{
		midLightRenderer.enabled = true;
		foreach (SpriteRenderer rimRenderer in rimRenderers)
		{
			rimRenderer.enabled = true;
		}
		Manager.effects.PlayPuff(PuffID.AncientSparks, midLightRenderer.transform.position, 1);
		foreach (SpriteRenderer litOrbRenderer in litOrbRenderers)
		{
			if (litOrbRenderer.enabled)
			{
				Manager.effects.PlayPuff(PuffID.AncientSparks, litOrbRenderer.transform.position + puffPos);
			}
		}
		AudioManager.Sfx(SfxID.wall, base.transform.position, 1f, 0.5f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.twinkle2, base.transform.position, 0.3f);
		AudioManager.Sfx(SfxID.windupMagicGlass, base.transform.position, 0.3f);
		StartCoroutine(FadeOutSound_Coroutine());
		AffectObjectWhenMelodyPlayedCD componentData = EntityUtility.GetComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world);
		MelodyID melodyID = componentData.melodyID;
		int scale = componentData.scale;
		MelodyData.OnMelodyPlayed(melodyID, this, scale, autoplay: true);
	}

	public void AE_DoneOpening()
	{
		midLightRenderer.enabled = false;
		foreach (SpriteRenderer rimRenderer in rimRenderers)
		{
			rimRenderer.enabled = false;
		}
		foreach (SpriteRenderer litOrbRenderer in litOrbRenderers)
		{
			litOrbRenderer.enabled = false;
		}
	}

	public void AE_Progress()
	{
		AudioManager.Sfx(SfxID.twinkle, base.transform.position, 0.2f);
	}

	public void AE_Hum()
	{
		AffectObjectWhenMelodyPlayedCD componentData = EntityUtility.GetComponentData<AffectObjectWhenMelodyPlayedCD>(base.entity, base.world);
		int humIndex = componentData.humIndex;
		if (componentData.humIndex != -1)
		{
			int[] melody = MelodyData.melodies[(int)(componentData.melodyID - 1)].melody;
			float volume = 0.2f;
			float pitch = Mathf.Pow(2f, ((float)melody[humIndex] - 12f) / 12f);
			AudioManager.Sfx(SfxID.melody_C6, base.transform.position, volume, pitch);
			Manager.effects.PlayPuff(PuffID.AncientSparks, midLightRenderer.transform.position + puffPos);
		}
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
}
