using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class CoinBagMax : Pickup
{
	private GoldFeverController _goldFever;

	private void InjectGoldFever(GoldFeverController gold)
	{
		_goldFever = gold;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void GetTaken()
	{
		//IL_0063: Expected O, but got I4
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			_goldFever.OnCoinPickup(this);
			GM.Core.CoinPickedup(this);
			float num = _playerOptions.AddCoins(base._003CValue_003Ek__BackingField, _targetPlayer);
			base.AddToRunPickups();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, time);
			base.SetHasSeenItem();
			base.GetTaken();
		}
	}
}
