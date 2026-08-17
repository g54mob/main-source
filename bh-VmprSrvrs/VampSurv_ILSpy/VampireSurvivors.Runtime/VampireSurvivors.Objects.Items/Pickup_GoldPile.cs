using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_GoldPile : Pickup
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

	public unsafe override void GetTaken()
	{
		//IL_006b: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_0154: Expected O, but got Ref
		//IL_0192: Expected O, but got F4
		//IL_0192: Expected O, but got Ref
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			_goldFever.OnCoinPickup(this);
			GM.Core.CoinPickedup(this);
			float num = _playerOptions.AddCoins(base._003CValue_003Ek__BackingField, _targetPlayer);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float num2 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, num2);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1.5f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Coin, soundConfig2, 0f, 10, num2);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 2f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Coin, soundConfig3, 0f, 10, num2);
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm7\"");
			int value2 = default(int);
			object obj = default(object);
			string value = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&obj), null);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("MoneyBagGreen", value, (Color?)(object)(&obj), (VampireSurvivors.Objects.Characters.CharacterController)num2, displayTimeMultiplier, vOffset, textureName);
			GameManager core2 = GM.Core;
			core2._gizmoManager.DisplayQuickTreasureChestAnimation(_targetPlayer);
			base.GetTaken();
		}
	}
}
