using System.Collections.Generic;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class CoinBag1 : Pickup, ICountedPickup
{
	private int _003CAmountOnCollection_003Ek__BackingField = 1;

	private GoldFeverController _goldFever;

	public int AmountOnCollection
	{
		get
		{
			return _003CAmountOnCollection_003Ek__BackingField;
		}
		set
		{
			_003CAmountOnCollection_003Ek__BackingField = value;
		}
	}

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

	public override void Despawn()
	{
		base.Despawn();
		GameManager gameManager = _gameManager;
		ObjectPool redCoinBagPool = _gameManager.RedCoinBagPool;
		GameObject obj = base.gameObject;
		redCoinBagPool.Release(obj);
		bool flag = ((HashSet<object>)(object)gameManager._redCoinBags).Remove((object)this);
	}
}
