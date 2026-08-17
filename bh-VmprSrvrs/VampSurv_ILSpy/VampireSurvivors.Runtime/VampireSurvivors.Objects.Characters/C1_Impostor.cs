using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class C1_Impostor : CharacterController
{
	private bool _hasSecondAnim;

	private float _mightBonus;

	private float _moveBonus;

	private float _cooldownBonus;

	private float _morphDuration = 30000f;

	private int _morphedTimes;

	private int _finalMorphedTimes;

	private SpriteRenderer _sparkSprite;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private SpriteRenderer _burstSprite;

	private SpriteRenderer _darkSprite;

	private MultiTargetTween _darkTween;

	private int[] _thresholds = new int[8] { 500, 1000, 2000, 3000, 5000, 7000, 10000, 15000 };

	private int _finalThreshold = 10000;

	private bool _isMorphed;

	private int _enemiesTs;

	private MorphVFX _morphVFX;

	private List<Weapon> hiddenTongues;

	private bool hasBonusesApplied;

	private float _originalMoveSpeed = 1f;

	private void CalculateTreshold()
	{
		int[] thresholds = _thresholds;
		if (_morphedTimes < thresholds.Length)
		{
			int[] thresholds2 = _thresholds;
			int morphedTimes = _morphedTimes;
			_enemiesTs = thresholds2[morphedTimes];
		}
		else
		{
			int enemiesTs = _finalThreshold * _finalMorphedTimes;
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			_enemiesTs = enemiesTs;
		}
	}

	protected override void OnUpdate()
	{
		//IL_006f: Expected O, but got I
		base.OnUpdate();
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v17 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v17 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v17 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (base._isDead)
		{
			return;
		}
		bool isDisconnectedFromOnlinePlay = base.IsDisconnectedFromOnlinePlay;
		if (isDisconnectedFromOnlinePlay || _isMorphed != isDisconnectedFromOnlinePlay)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CRunEnemies_003Ek__BackingField > _enemiesTs)
		{
			_isMorphed = true;
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				Morph();
				return;
			}
			Action action = Morph;
			bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		List<Weapon> list = new List<Weapon>();
		hiddenTongues = list;
		_finalMorphedTimes = 2;
		_morphedTimes = 0;
		_isMorphed = false;
		_hasSecondAnim = false;
		_mightBonus = 0f;
		_cooldownBonus = 0f;
		CalculateTreshold();
		MakeMorphVFX();
		float num = base.PMoveSpeed();
		float originalMoveSpeed = default(float);
		_originalMoveSpeed = originalMoveSpeed;
	}

	public unsafe void Morph()
	{
		//IL_08a1: Expected O, but got I4
		//IL_0079: Expected I, but got O
		//IL_0087: Expected I, but got O
		//IL_0097: Expected O, but got I
		//IL_0117: Expected O, but got I4
		//IL_00d3: Expected O, but got I
		//IL_0124: Expected I4, but got O
		//IL_0109: Expected O, but got I4
		//IL_01af: Expected I, but got O
		//IL_01bd: Expected I, but got O
		//IL_01cd: Expected O, but got I
		//IL_024d: Expected O, but got I4
		//IL_0209: Expected O, but got I
		//IL_095a: Expected I4, but got F4
		//IL_025a: Expected I4, but got O
		//IL_023f: Expected O, but got I4
		//IL_0321: Expected I, but got O
		//IL_032f: Expected I, but got O
		//IL_033f: Expected O, but got I
		//IL_03bf: Expected O, but got I4
		//IL_037b: Expected O, but got I
		//IL_03d4: Expected I4, but got O
		//IL_03b1: Expected O, but got I4
		//IL_09aa: Expected O, but got F4
		//IL_048c: Expected F4, but got O
		//IL_0407: Expected O, but got F4
		//IL_0462: Expected O, but got F4
		//IL_06e5: Invalid comparison between I4 and F4
		//IL_06f4: Expected F4, but got I4
		//IL_0574: Expected O, but got I
		//IL_0589: Expected O, but got I
		//IL_05ce: Expected I4, but got O
		//IL_05ce: Expected O, but got I4
		//IL_061a: Expected O, but got I4
		//IL_060c: Expected O, but got I
		//IL_062d: Expected I4, but got O
		//IL_0655: Expected O, but got I4
		//IL_0655: Expected I4, but got O
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.C1_TONGUE1);
		bool flag;
		if ((object)weaponByType == null)
		{
			flag = false;
			goto IL_08d6;
		}
		nint num2 = (nint)weaponByType;
		nint num3 = (nint)typeof(TongueWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ r9_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ r9_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rax_v122+FFFFFFF8+v521 @ rax_v118*8]");
			if (0 == (nint)typeof(TongueWeapon))
			{
				obj3 = 1;
				goto IL_08ab;
			}
		}
		obj3 = 0;
		goto IL_08ab;
		IL_08f4:
		object obj4;
		bool flag2 = obj4 == null;
		flag = false;
		Weapon weaponByType2;
		if (!flag2)
		{
			flag = (byte)(int)weaponByType2 != 0;
		}
		goto IL_091f;
		IL_0949:
		bool flag3 = false;
		float num5;
		bool flag4 = (byte)(int)num5 != 0;
		Vector2 vector;
		float num9 = default(float);
		bool flag11;
		bool flag13;
		do
		{
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.C1_TONGUE1, this, removeFromStore: true, flag4);
			bool flag6;
			bool flag5;
			if ((object)weapon == null)
			{
				flag5 = true;
				flag6 = false;
				goto IL_0997;
			}
			nint num6 = (nint)weapon;
			nint num7 = (nint)typeof(TongueWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ r9_v27 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon>)+130]");
			object obj7;
			if (num8 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ r9_v27 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1299 @ rax_v90+FFFFFFF8+v1241 @ rax_v86*8]");
				if (0 == (nint)typeof(TongueWeapon))
				{
					obj7 = 1;
					goto IL_0964;
				}
			}
			obj7 = 0;
			goto IL_0964;
			IL_0964:
			bool flag7 = obj7 == null;
			flag5 = (byte)num6 != 0;
			flag6 = false;
			if (!flag7)
			{
				flag5 = (byte)num6 != 0;
				flag6 = (byte)(int)weapon != 0;
			}
			goto IL_0997;
			IL_0997:
			bool flag8 = !flag6;
			vector = (Vector2)num9;
			if (!flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rbx_v9 (System.Boolean)+10]");
				bool flag9 = (nint)0 == 0;
				vector = (Vector2)num9;
				if (!flag9)
				{
					_ = 1;
					_ = 1;
					_ = 0;
					bool flag10 = (flag11 ? 1 : 0) <= (false ? 1 : 0);
					bool flag12 = false;
					if (!flag10)
					{
						do
						{
							bool value = ((bool*)(flag6 ? 1 : 0))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1502 @ rax_v77 (System.Boolean)+3C8] (should have been resolved before IL gen)");
							flag12 = true;
							float num10 = 0f * 0.5f;
							num9 = num10 + 1f;
						}
						while ((flag12 ? 1 : 0) < (flag11 ? 1 : 0));
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BCD0");
					vector = (Vector2)num9;
				}
			}
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
			flag13 = (flag3 ? 1 : 0) < 4;
			num9 = (float)vector;
			flag4 = flag4;
		}
		while (flag13);
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		int morphedTimes = _morphedTimes + 1;
		_morphedTimes = morphedTimes;
		CalculateTreshold();
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num11 = default(int);
		TimerType timerType = default(TimerType);
		if (!_hasSecondAnim)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core2._dataManager.GetConvertedCharacterData();
			object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)110);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v68 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v68 (System.Object)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v69+20]");
				object obj10 = 0;
				string animName = "C01Impostor2_01.png".Replace("01.png", "");
				Vector2 vector2 = default(Vector2);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 4, vector2, (string)flag4, (int)monoBehaviour, (byte)num11 != 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rbx_v20+80]");
				object obj11;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rbx_v20+80]");
					obj11 = 0;
				}
				else
				{
					obj11 = 1;
				}
				if (obj11 != null)
				{
					int fps = obj11 >> 32;
					_spriteAnimation.AddAnimation("walk2", animationFrames, fps, flag4, (byte)(int)monoBehaviour != 0, (Action)num11, (byte)timerType != 0);
					_hasSecondAnim = true;
					vector = vector2;
					goto IL_066d;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		goto IL_066d;
		IL_02a4:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rbx_v24 (System.Boolean)+4C]");
		flag11 = false;
		num5 = num;
		goto IL_0949;
		IL_066d:
		_spriteAnimation.SetAnimation("walk2");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		bool flag14 = hasBonusesApplied;
		bool useRealTime = flag4;
		if (!flag14)
		{
			_cooldownBonus = -0.2f;
			float num12 = base.PMoveSpeed();
			float num13 = 2f - (float)vector;
			bool flag15 = 0f > num13;
			float moveBonus = 0f;
			if (!flag15)
			{
				moveBonus = num13;
			}
			PlayerModifierStats playerStats = _playerStats;
			_moveBonus = moveBonus;
			_mightBonus = 2f;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value2 = default(float);
			EggFloat cooldown = new EggFloat(value2, eggFloat._eggVal);
			value2 = eggFloat._val + _cooldownBonus;
			playerStats.Cooldown = cooldown;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat2 = playerStats2._003CMoveSpeed_003Ek__BackingField;
			float value3 = default(float);
			EggFloat moveSpeed = new EggFloat(value3, eggFloat2._eggVal);
			value3 = eggFloat2._val + _moveBonus;
			playerStats2.MoveSpeed = moveSpeed;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat3 = playerStats3._003CPower_003Ek__BackingField;
			useRealTime = flag4;
			float value4 = default(float);
			EggFloat power = new EggFloat(value4, eggFloat3._eggVal);
			value4 = eggFloat3._val + _mightBonus;
			playerStats3.Power = power;
			hasBonusesApplied = true;
		}
		base.IsInvul = true;
		float num14 = _morphDuration * 0.001f;
		float invincibilityTimer = num14 + base._invincibilityTimer;
		base._invincibilityTimer = invincibilityTimer;
		base.RestoreTint();
		Action onComplete = Unmorph;
		float duration = _morphDuration * 0.001f;
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, monoBehaviour, num11, timerType, isOnlineTimer: false, canPause: false);
		return;
		IL_08ab:
		bool flag16 = obj3 == null;
		flag = false;
		if (!flag16)
		{
			flag = (byte)(int)weaponByType != 0;
		}
		goto IL_08d6;
		IL_091f:
		bool flag17 = !flag;
		flag11 = false;
		num5 = num;
		if (!flag17)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rbx_v24 (System.Boolean)+10]");
			bool flag18 = (nint)0 == 0;
			flag11 = false;
			num5 = num;
			if (!flag18)
			{
				goto IL_02a4;
			}
		}
		goto IL_0949;
		IL_08d6:
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rbx_v24 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				goto IL_02a4;
			}
		}
		weaponByType2 = base._weaponsManager.GetWeaponByType(WeaponType.C1_TONGUE2);
		if ((object)weaponByType2 == null)
		{
			flag = false;
			goto IL_091f;
		}
		nint num15 = (nint)weaponByType2;
		nint num16 = (nint)typeof(Tongue2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.Tongue2Weapon>)+130]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1048 @ r9_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.Tongue2Weapon>)+130]");
		if (num17 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1048 @ r9_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1133 @ rax_v110+FFFFFFF8+v1050 @ rax_v106*8]");
			if (0 == (nint)typeof(Tongue2Weapon))
			{
				obj4 = 1;
				goto IL_08f4;
			}
		}
		obj4 = 0;
		goto IL_08f4;
	}

	private void Unmorph()
	{
		//IL_0272: Expected O, but got I4
		//IL_027b: Expected O, but got I4
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		//IL_0148: Invalid comparison between F4 and O
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		if (!hasBonusesApplied)
		{
			goto IL_0234;
		}
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - _cooldownBonus;
		playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat3 = playerStats2._003CMoveSpeed_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val - _moveBonus;
		playerStats2._003CMoveSpeed_003Ek__BackingField = eggFloat4;
		PlayerModifierStats playerStats3 = _playerStats;
		EggFloat eggFloat5 = playerStats3._003CPower_003Ek__BackingField;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val - _mightBonus;
		playerStats3._003CPower_003Ek__BackingField = eggFloat6;
		float num = base.PMoveSpeed();
		float originalMoveSpeed = _originalMoveSpeed;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)originalMoveSpeed) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			goto IL_0374;
		}
		PlayerModifierStats playerStats4 = _playerStats;
		EggFloat eggFloat7 = playerStats4._003CMoveSpeed_003Ek__BackingField;
		object obj2 = _originalMoveSpeed & -2147483649L;
		float val;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = _originalMoveSpeed & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875D9619h\"");
				bool flag = _originalMoveSpeed != -1f / 0f;
				val = _originalMoveSpeed;
				if (!flag)
				{
					val = -3.4028235E+38f;
				}
				goto IL_0384;
			}
		}
		val = 3.4028235E+38f;
		goto IL_0384;
		IL_0234:
		_spriteAnimation.SetAnimation("walk");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walk";
		List<Weapon> list = hiddenTongues;
		_isMorphed = false;
		object obj4 = 0;
		object obj5 = 0;
		while (true)
		{
			if ((nint)obj5 < list._size)
			{
				GameManager core = GM.Core;
				List<Weapon> list2 = hiddenTongues;
				if ((nint)obj4 >= list2._size)
				{
					break;
				}
				Weapon[] items = list2._items;
				core._weaponsFacade.RemoveThisHiddenWeapon(items[obj4], this);
				list = hiddenTongues;
				obj4++;
				obj5 = obj4;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_0374:
		hasBonusesApplied = false;
		goto IL_0234;
		IL_0384:
		eggFloat7._val = val;
		goto IL_0374;
	}

	public void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 16711680u, 16711935u, 13369548u, 8913032u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}
}
