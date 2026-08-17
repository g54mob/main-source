using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_EX_Torino : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CMakeLevelOne_003Eb__7_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 222;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private MorphVFX _morphVFX;

	private Weapon _groundHitWeapon;

	private bool _canRetaliate;

	private int _morphLevel;

	private List<WeaponType> _magicWeapons;

	private void SyncedMorph()
	{
		//IL_006f: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v13 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v13 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v13 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				Morph();
				return;
			}
			Action action = Morph;
			bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	public override void LevelUp()
	{
		//IL_00b6: Expected O, but got I
		base.LevelUp();
		if (base._level != 16 && base._level != 36)
		{
			return;
		}
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v14 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v14 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v14 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
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
		MakeMorphVFX();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		_canRetaliate = true;
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__7_0;
		if (_003C_003Ec._003C_003E9__7_0 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__7_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 222;
				return obj == null;
			});
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
		if (list._size == 0)
		{
			GameManager core = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon groundHitWeapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.EX_GROUNDHIT, this, removeFromStore: true, allowDuplicates);
			_groundHitWeapon = groundHitWeapon;
			Weapon groundHitWeapon2 = _groundHitWeapon;
			WeaponData currentWeaponData = groundHitWeapon2._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = 1f;
			Weapon groundHitWeapon3 = _groundHitWeapon;
			((Equipment)groundHitWeapon3)._003CShowInRecap_003Ek__BackingField = false;
		}
		EnableDestroyDestructiblesOnTouch();
	}

	public override bool GetDamaged(float damageAmount)
	{
		//IL_00db: Expected I4, but got O
		if ((object)GM.Core != null)
		{
			if (GM.Core.IsStageHost && _canRetaliate)
			{
				if ((object)_groundHitWeapon == null)
				{
					goto IL_00cd;
				}
				_groundHitWeapon.Fire();
				_canRetaliate = false;
				Action onComplete = delegate
				{
					_canRetaliate = true;
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			}
			return base.GetDamaged(damageAmount);
		}
		goto IL_00cd;
		IL_00cd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void Morph()
	{
		//IL_0026: Expected O, but got Ref
		//IL_0050: Expected O, but got I4
		//IL_00b5: Expected O, but got F4
		//IL_0104: Expected O, but got I4
		//IL_0104: Expected I4, but got F4
		//IL_046a: Expected O, but got F4
		//IL_013e: Expected O, but got I4
		//IL_049c: Expected O, but got I4
		//IL_049c: Expected I4, but got F4
		//IL_04d6: Expected O, but got I4
		//IL_0703: Expected F4, but got O
		//IL_03f5: Expected F4, but got O
		int morphLevel = _morphLevel + 1;
		_morphLevel = morphLevel;
		CheckRenderer();
		Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		Vector2 vector = default(Vector2);
		int num2 = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Torino2_i0", 1, 4, vector, (string)num, num2, flag);
		bool autoSetAnimation = default(bool);
		if (_morphLevel == 1)
		{
			_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk2");
			base._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
			BaseBody baseBody = body.setOffset(8.5f, (float?)(object)1);
			CharacterData currentCharacterData = _currentCharacterData;
			List<Vector2> list = new List<Vector2>();
			list.Add(vector);
			currentCharacterData._003CheadOffsets_003Ek__BackingField = list;
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 35f;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CPower_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + 0.35f;
			playerStats2._003CPower_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CArea_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + 0.35f;
			playerStats3._003CArea_003Ek__BackingField = eggFloat6;
			PlayerModifierStats playerStats4 = _playerStats;
			EggFloat eggFloat7 = playerStats4._003CMoveSpeed_003Ek__BackingField;
			float value4 = default(float);
			EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
			value4 = eggFloat7._val - 0.2f;
			playerStats4._003CMoveSpeed_003Ek__BackingField = eggFloat8;
			PlayerModifierStats playerStats5 = _playerStats;
			EggFloat eggFloat9 = playerStats5._003CArmor_003Ek__BackingField;
			float value5 = default(float);
			EggFloat eggFloat10 = new EggFloat(value5, eggFloat9._eggVal);
			value5 = eggFloat9._val + 1f;
			playerStats5._003CArmor_003Ek__BackingField = eggFloat10;
			PlayerModifierStats playerStats6 = _playerStats;
			EggFloat eggFloat11 = playerStats6._003CDuration_003Ek__BackingField;
			float value6 = default(float);
			EggFloat eggFloat12 = new EggFloat(value6, eggFloat11._eggVal);
			value6 = eggFloat11._val + 0.2f;
			playerStats6._003CDuration_003Ek__BackingField = eggFloat12;
			float num3 = base.MaxHp();
			Weapon groundHitWeapon = _groundHitWeapon;
			base._currentHp = (float)vector;
			WeaponData currentWeaponData = groundHitWeapon._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = 1.65f;
		}
		else if (_morphLevel == 2)
		{
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("Torino3_i0", 1, 5, vector, (string)num, num2, flag);
			_spriteAnimation.AddAnimation("walk3", animationFrames2, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk3");
			base.CurrentWalkAnimName = "walk3";
			BaseBody baseBody2 = body.setOffset(14.5f, (float?)(object)1);
			List<Vector2> list2 = new List<Vector2>();
			list2.Add(vector);
			_currentCharacterData.headOffsets = list2;
			PlayerModifierStats playerStats7 = _playerStats;
			EggFloat eggFloat13 = playerStats7._003CMoveSpeed_003Ek__BackingField;
			float value7 = default(float);
			EggFloat moveSpeed = new EggFloat(value7, eggFloat13._eggVal);
			value7 = eggFloat13._val - 0.2f;
			playerStats7.MoveSpeed = moveSpeed;
			PlayerModifierStats playerStats8 = _playerStats;
			EggFloat eggFloat14 = playerStats8._003CPower_003Ek__BackingField;
			float value8 = default(float);
			EggFloat power = new EggFloat(value8, eggFloat14._eggVal);
			value8 = eggFloat14._val + 0.35f;
			playerStats8.Power = power;
			PlayerModifierStats playerStats9 = _playerStats;
			EggFloat eggFloat15 = playerStats9._003CMaxHp_003Ek__BackingField;
			float value9 = default(float);
			EggFloat maxHp = new EggFloat(value9, eggFloat15._eggVal);
			value9 = eggFloat15._val + 108f;
			playerStats9.MaxHp = maxHp;
			PlayerModifierStats playerStats10 = _playerStats;
			EggFloat eggFloat16 = playerStats10._003CArmor_003Ek__BackingField;
			float value10 = default(float);
			EggFloat armor = new EggFloat(value10, eggFloat16._eggVal);
			value10 = eggFloat16._val + 2f;
			playerStats10.Armor = armor;
			PlayerModifierStats playerStats11 = _playerStats;
			EggFloat eggFloat17 = playerStats11._003CDuration_003Ek__BackingField;
			float value11 = default(float);
			EggFloat duration = new EggFloat(value11, eggFloat17._eggVal);
			value11 = eggFloat17._val + 0.2f;
			playerStats11.Duration = duration;
			float num4 = base.MaxHp();
			Weapon groundHitWeapon2 = _groundHitWeapon;
			base._currentHp = (float)vector;
			WeaponData currentWeaponData2 = groundHitWeapon2._currentWeaponData;
			currentWeaponData2._003Cpower_003Ek__BackingField = 2.3f;
		}
	}

	private void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 16711680u, 65280u, 13421568u, 8947712u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}

	private void MorphToSecondForm()
	{
		_morphLevel = 0;
		Morph();
	}

	private void MorphToThirdForm()
	{
		_morphLevel = 1;
		Morph();
	}

	private void SetBodyOffset(float x, float y)
	{
		//IL_0019: Expected O, but got I4
		BaseBody baseBody = body.setOffset(x, (float?)(object)1);
	}

	public CharacterController_EX_Torino()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0283: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02ab: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02d3: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_02fb: Expected O, but got I
		//IL_022a: Expected O, but got I
		_canRetaliate = true;
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)37);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 37;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)24);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)12);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)161);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 161;
		}
		_magicWeapons = list;
		base._002Ector();
	}

	private void _003CGetDamaged_003Eb__8_0()
	{
		_canRetaliate = true;
	}
}
