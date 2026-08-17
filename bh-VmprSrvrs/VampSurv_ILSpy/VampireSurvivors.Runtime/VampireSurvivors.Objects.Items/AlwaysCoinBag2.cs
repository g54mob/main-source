using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class AlwaysCoinBag2 : Pickup
{
	public override void GetTaken()
	{
		//IL_005f: Expected O, but got I4
		float num = _playerOptions.AddCoins(base._003CValue_003Ek__BackingField, _targetPlayer);
		base.AddToRunPickups(ItemType.COINBAG2);
		CharacterController targetPlayer = _targetPlayer;
		targetPlayer._003CAlwaysCoinBag_003Ek__BackingField = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, time);
		base.SetHasSeenItem();
		base.GetTaken();
	}
}
