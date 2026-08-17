using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class TP_Cornell_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__8_0;

		public static Predicate<Equipment> _003C_003E9__8_1;

		public static Predicate<Equipment> _003C_003E9__8_2;

		public static Predicate<Equipment> _003C_003E9__8_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetFourthLevelUpOption_003Eb__8_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1440;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetFourthLevelUpOption_003Eb__8_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1437;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetFourthLevelUpOption_003Eb__8_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1438;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CGetFourthLevelUpOption_003Eb__8_3(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1439;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private float _amountBonus;

	private float _armorBonus;

	private float _maxHpBonus;

	private float _moveSpeedBonus;

	private MorphVFX _morphVFX;

	private bool _isMorphed;

	public override void OnWeaponMadeLevelOne(WeaponType type)
	{
		if (type == WeaponType.TP_CUSTOS4)
		{
			Morph();
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		HasFourthLevelUpOption = true;
		base.MakeLevelOne();
		_isMorphed = false;
		_armorBonus = 2f;
		_amountBonus = 2f;
		_moveSpeedBonus = 0.4f;
		_maxHpBonus = 100f;
		MakeMorphVFX();
	}

	public unsafe override WeaponType GetFourthLevelUpOption()
	{
		//IL_04c5: Expected I, but got O
		//IL_05dd: Expected I, but got O
		//IL_0035: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._characters != null)
		{
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				num2 = (nint)(&enumerator);
				throw new NullReferenceException();
			}
			nint num3 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v42 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num4 = 0;
			GameManager core2 = GM.Core;
			bool flag = (object)GM.Core == null;
			num2 = num4;
			if (!flag)
			{
				bool flag2 = core2._characters == null;
				num2 = num4;
				if (!flag2)
				{
					List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
					if (enumerator2.MoveNext())
					{
						object obj2 = 0;
						num2 = (nint)(&enumerator2);
						throw new NullReferenceException();
					}
					return WeaponType.TP_CUSTOS1;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 65280u, 255u, 16776960u, 16711680u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}

	private void Morph()
	{
		//IL_0051: Expected O, but got I4
		//IL_00ea: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_01d1: Expected O, but got F4
		//IL_0203: Expected O, but got I4
		//IL_0203: Expected I4, but got F4
		//IL_03d0: Expected F4, but got O
		if (_isMorphed)
		{
			return;
		}
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		_isMorphed = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)274);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v16 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v16 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v17+20]");
			object obj3 = 0;
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rbx_v6+78]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v18+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v18+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v11+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v19+68]");
				currentSkinData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
				SpriteAnimation spriteAnimation = _spriteAnimation;
				((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
				Vector2 vector = default(Vector2);
				int num2 = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_CornellB_i0", 1, 4, vector, (string)num, num2, flag);
				bool autoSetAnimation = default(bool);
				_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
				_spriteAnimation.SetAnimation("walk2");
				((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
				PlayerModifierStats playerStats = _playerStats;
				EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val + _amountBonus;
				playerStats._003CAmount_003Ek__BackingField = eggFloat2;
				PlayerModifierStats playerStats2 = _playerStats;
				EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + _armorBonus;
				playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
				PlayerModifierStats playerStats3 = _playerStats;
				EggFloat eggFloat5 = playerStats3._003CMaxHp_003Ek__BackingField;
				float value3 = default(float);
				EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
				value3 = eggFloat5._val + _maxHpBonus;
				playerStats3._003CMaxHp_003Ek__BackingField = eggFloat6;
				PlayerModifierStats playerStats4 = _playerStats;
				EggFloat eggFloat7 = playerStats4._003CMoveSpeed_003Ek__BackingField;
				float value4 = default(float);
				EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
				value4 = eggFloat7._val + _moveSpeedBonus;
				playerStats4._003CMoveSpeed_003Ek__BackingField = eggFloat8;
				float num3 = base.MaxHp();
				((CharacterController)this)._currentHp = (float)vector;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
