using Pug.UnityExtensions;
using UnityEngine;

public class CrystalMeteorBoulder : EntityMonoBehaviour
{
	public SpriteRenderer SR;

	public Sprite crackedStage0;

	public Sprite crackedStage1;

	public Sprite crackedStage2;

	private int previousCrackLevel;

	public Transform pivot;

	public override void OnOccupied()
	{
		base.OnOccupied();
		int hashCode = base.WorldPosition.GetHashCode();
		bool flag = PugRandom.Range(0f, 1f, hashCode) > 0.5f;
		pivot.localScale = new Vector3((!flag) ? 1 : (-1), 1f, 1f);
		previousCrackLevel = GetCrackLevel();
		Crack(previousCrackLevel, playEffects: false);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		int crackLevel = GetCrackLevel();
		if (crackLevel != previousCrackLevel)
		{
			Crack(crackLevel, playEffects: true);
			previousCrackLevel = crackLevel;
		}
	}

	private void Crack(int crackLevel, bool playEffects)
	{
		switch (crackLevel)
		{
		case 0:
			SR.sprite = crackedStage0;
			break;
		case 1:
			SR.sprite = crackedStage1;
			break;
		case 2:
			SR.sprite = crackedStage2;
			break;
		default:
			SR.sprite = crackedStage0;
			break;
		}
		if (playEffects)
		{
			PlayEffect();
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		PlayEffect();
	}

	private void PlayEffect()
	{
		Vector3 position = particleOptions.particleSpawnLocations[0].position;
		Manager.effects.PlayPuff(PuffID.CrystalDebris, position);
		AudioManager.Sfx(SfxID.wall, position, 1f, 1.5f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
	}

	private int GetCrackLevel()
	{
		int num = currentHealth;
		if (num <= 150)
		{
			return 2;
		}
		if (num <= 300)
		{
			return 1;
		}
		return 0;
	}
}
