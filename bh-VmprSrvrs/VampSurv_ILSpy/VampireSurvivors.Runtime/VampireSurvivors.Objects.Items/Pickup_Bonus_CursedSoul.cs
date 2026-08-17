using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class Pickup_Bonus_CursedSoul : Pickup
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Pickup_Bonus_CursedSoul _003C_003E4__this;

		public float maxHpVal;

		public float greedVal;

		internal unsafe void _003CGetTaken_003Eb__0()
		{
			//IL_00c9: Expected O, but got Ref
			//IL_00e5: Expected O, but got I4
			//IL_012f: Expected F4, but got O
			Pickup_Bonus_CursedSoul pickup_Bonus_CursedSoul = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = pickup_Bonus_CursedSoul._targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + maxHpVal;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("HeartBlack", "", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = GetDetune();
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig, 150f, 3, (float)characterController);
		}

		internal unsafe void _003CGetTaken_003Eb__1()
		{
			//IL_00c9: Expected O, but got Ref
			//IL_00e5: Expected O, but got I4
			//IL_012f: Expected F4, but got O
			Pickup_Bonus_CursedSoul pickup_Bonus_CursedSoul = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = pickup_Bonus_CursedSoul._targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CGreed_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + greedVal;
			playerStats._003CGreed_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Mask", "", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = GetDetune();
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig, 150f, 3, (float)characterController);
		}
	}

	public float _Volume = 0.35f;

	private static float[] _detuneValues = new float[64]
	{
		0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
		0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
		-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
		1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
		5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
		7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
		2f, 14f, 5f, 17f
	};

	private static int _sfxIndex = 0;

	protected float _MaxHpVal = 0.1f;

	protected float _CurseVal = 0.0005f;

	protected float _GreedVal = 0.0005f;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	private static float GetDetune()
	{
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		float[] detuneValues2 = _detuneValues;
		int num = _sfxIndex % detuneValues2.Length;
		return detuneValues[num] * -100f;
	}

	public unsafe override void GetTaken()
	{
		//IL_02b2: Expected O, but got F4
		//IL_00a8: Expected F4, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_01ac: Expected O, but got F4
		//IL_01ac: Expected O, but got Ref
		//IL_01c8: Expected O, but got I4
		//IL_0212: Expected F4, but got O
		//IL_024f: Expected I4, but got F4
		//IL_024f: Expected O, but got F4
		//IL_024f: Expected I4, but got O
		//IL_0291: Expected I4, but got F4
		//IL_0291: Expected O, but got F4
		//IL_0291: Expected I4, but got O
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			float? num = default(float?);
			float num2 = default(float);
			float num3 = default(float);
			bool flag = default(bool);
			if (!(base._003CValue_003Ek__BackingField < 1f))
			{
				_targetPlayer.RecoverHp(1f, showRecovery: true, mulByRegen: true);
				object obj = UnityEngine.Random.value;
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.LittleHeart, 50f, 3, 0f, num, num2, num3, flag, 1f);
			}
			base.SetHasSeenItem();
			float num4 = base._003CValue_003Ek__BackingField;
			if (1f > base._003CValue_003Ek__BackingField)
			{
				num4 = 1f;
			}
			float greedVal = num4 * _GreedVal;
			CS_0024_003C_003E8__locals7.greedVal = greedVal;
			float maxHpVal = num4 * _MaxHpVal;
			CS_0024_003C_003E8__locals7.maxHpVal = maxHpVal;
			base.GetTaken();
			base.SetHasSeenItem();
			base.AddToRunPickups();
			base.GetTaken();
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CCurse_003Ek__BackingField;
			float num5 = num4 * _CurseVal;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + num5;
			playerStats._003CCurse_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj2 = default(object);
			core._gizmoManager.DisplayIconOverhead("Curse", "", (Color?)(object)(&obj2), (VampireSurvivors.Objects.Characters.CharacterController)num, num2, (Vector2)num3, (string)flag);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = GetDetune();
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig, 150f, 3, (float)num);
			Action onComplete = delegate
			{
				//IL_00c9: Expected O, but got Ref
				//IL_00e5: Expected O, but got I4
				//IL_012f: Expected F4, but got O
				Pickup_Bonus_CursedSoul pickup_Bonus_CursedSoul = CS_0024_003C_003E8__locals7._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = pickup_Bonus_CursedSoul._targetPlayer;
				PlayerModifierStats playerStats2 = targetPlayer2._playerStats;
				EggFloat eggFloat3 = playerStats2._003CMaxHp_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + CS_0024_003C_003E8__locals7.maxHpVal;
				playerStats2._003CMaxHp_003Ek__BackingField = eggFloat4;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj3 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName = default(string);
				core2._gizmoManager.DisplayIconOverhead("HeartBlack", "", (Color?)(object)(&obj3), characterController, displayTimeMultiplier, vOffset, textureName);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				float detune2 = GetDetune();
				soundConfig2.Detune = detune2;
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig2, 150f, 3, (float)characterController);
			};
			Timer timer = TimerHelper.RegisterMillisUI(200f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3);
			Action onComplete2 = delegate
			{
				//IL_00c9: Expected O, but got Ref
				//IL_00e5: Expected O, but got I4
				//IL_012f: Expected F4, but got O
				Pickup_Bonus_CursedSoul pickup_Bonus_CursedSoul = CS_0024_003C_003E8__locals7._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = pickup_Bonus_CursedSoul._targetPlayer;
				PlayerModifierStats playerStats2 = targetPlayer2._playerStats;
				EggFloat eggFloat3 = playerStats2._003CGreed_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + CS_0024_003C_003E8__locals7.greedVal;
				playerStats2._003CGreed_003Ek__BackingField = eggFloat4;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj3 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName = default(string);
				core2._gizmoManager.DisplayIconOverhead("Mask", "", (Color?)(object)(&obj3), characterController, displayTimeMultiplier, vOffset, textureName);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				float detune2 = GetDetune();
				soundConfig2.Detune = detune2;
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig2, 150f, 3, (float)characterController);
			};
			Timer timer2 = TimerHelper.RegisterMillisUI(400f, onComplete2, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3);
		}
	}
}
