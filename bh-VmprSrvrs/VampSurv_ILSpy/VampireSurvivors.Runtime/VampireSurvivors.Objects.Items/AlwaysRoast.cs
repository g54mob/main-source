using System;
using System.Runtime.CompilerServices;
using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class AlwaysRoast : Pickup
{
	public override void GetTaken()
	{
		//IL_003e: Invalid comparison between O and F4
		//IL_0143: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		CharacterController targetPlayer = _targetPlayer;
		targetPlayer._003CAlwaysRoast_003Ek__BackingField = true;
		CharacterController targetPlayer2 = _targetPlayer;
		float num = _targetPlayer.MaxHp();
		object obj = default(object);
		float time = default(float);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)targetPlayer2._currentHp))
		{
			float num2 = _playerOptions.AddCoins(25f, _targetPlayer);
			base.AddToRunPickups(ItemType.COINBAG2);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, time);
		}
		else
		{
			_targetPlayer.RecoverHp(base._003CValue_003Ek__BackingField, showRecovery: true, mulByRegen: true);
			base.AddToRunPickups(ItemType.ROAST);
		}
		base.GetTaken();
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Roast, soundConfig2, 0f, 10, time);
	}
}
