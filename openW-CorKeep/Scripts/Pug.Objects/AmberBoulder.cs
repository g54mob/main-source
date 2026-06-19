using UnityEngine;

public class AmberBoulder : EntityMonoBehaviour
{
	public SpriteRenderer SR;

	public Sprite crackedStage0;

	public Sprite crackedStage1;

	public Sprite crackedStage2;

	private int previousCrackLevel;

	public override void OnOccupied()
	{
		base.OnOccupied();
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
		Vector3 position = base.transform.position + new Vector3(0f, 1.25f, -1.5f);
		Manager.effects.PlayPuff(PuffID.AmberDebris, position);
		AudioManager.Sfx(SfxID.wall, position, 1f, 1.5f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
	}

	private int GetCrackLevel()
	{
		int num = currentHealth;
		if (num <= 50)
		{
			return 2;
		}
		if (num <= 100)
		{
			return 1;
		}
		return 0;
	}
}
