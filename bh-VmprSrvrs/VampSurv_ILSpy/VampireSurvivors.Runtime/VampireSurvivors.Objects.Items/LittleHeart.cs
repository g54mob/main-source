using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class LittleHeart : Pickup
{
	public float _Volume = 0.35f;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void GetTaken()
	{
		//IL_0092: Expected O, but got F4
		//IL_005e: Expected F4, but got I4
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			_targetPlayer.RecoverHp(1f, showRecovery: true, mulByRegen: true);
			base.SetHasSeenItem();
			base.GetTaken();
			object obj = Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.LittleHeart, 50f, 3, 0f, volume, rate, detune, loop, 1f);
		}
	}
}
