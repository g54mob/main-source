using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class TP_Leon_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__2_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1530;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public TP_Leon_Character _003C_003E4__this;

		public Equipment statue;

		internal void _003CLevelUp_003Eb__1()
		{
			Equipment equipment = statue;
			if (equipment._003CLevel_003Ek__BackingField < 8)
			{
				bool flag = equipment.LevelUp();
				_003C_003E4__this.ShowIcons();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public PhaserSprite _sunraySprite;

		internal void _003COnWeaponMadeLevelOne_003Eb__1()
		{
			_sunraySprite.destroy();
		}
	}

	private bool _hasVKBonuses;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_hasVKBonuses = false;
	}

	public override void LevelUp()
	{
		//IL_0037: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_0083: Expected O, but got I4
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		base.LevelUp();
		bool flag = ((CharacterController)this)._level != 5;
		object obj = 0;
		bool flag2 = default(bool);
		if (!flag)
		{
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.TP_SAVROG_WEAPON, this, removeFromStore: true, flag2);
			ShowIcons();
			obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj2 = obj >> 2;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 4;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 + obj6;
		if (((CharacterController)this)._level != (nint)obj7)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__2_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj8 = x._equipmentType - 1530;
				return obj8 == null;
			});
		}
		Equipment statue = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.Find(match);
		CS_0024_003C_003E8__locals7.statue = statue;
		Equipment statue2 = CS_0024_003C_003E8__locals7.statue;
		if ((object)CS_0024_003C_003E8__locals7.statue == null || ((UnityEngine.Object)statue2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Equipment statue3 = CS_0024_003C_003E8__locals7.statue;
		if (statue3._003CLevel_003Ek__BackingField >= 8)
		{
			return;
		}
		Action onComplete = delegate
		{
			Equipment statue4 = CS_0024_003C_003E8__locals7.statue;
			if (statue4._003CLevel_003Ek__BackingField < 8)
			{
				bool flag3 = statue4.LevelUp();
				CS_0024_003C_003E8__locals7._003C_003E4__this.ShowIcons();
			}
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public unsafe void ShowIcons()
	{
		Action onComplete = delegate
		{
			//IL_002d: Expected O, but got Ref
			GameManager core = GM.Core;
			object obj = default(object);
			CharacterController character = default(CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.TP_SAVROG_WEAPON, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(400f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
	}

	public override void OnWeaponMadeLevelOne(WeaponType type)
	{
		//IL_005a: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_06a6: Expected I4, but got F4
		if (type != WeaponType.TP_ALCHEMYWHIP2 || _hasVKBonuses)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -100f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 500f, 5, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -600f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Roast, soundConfig2, 500f, 5, num);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = -1100f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Roast, soundConfig3, 500f, 5, num);
		PlayerModifierStats playerStats = _playerStats;
		_hasVKBonuses = true;
		EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
		float value = default(float);
		EggFloat maxHp = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 80f;
		playerStats.MaxHp = maxHp;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat2 = playerStats2._003CRegen_003Ek__BackingField;
		float value2 = default(float);
		EggFloat regen = new EggFloat(value2, eggFloat2._eggVal);
		value2 = eggFloat2._val + 0.1f;
		playerStats2.Regen = regen;
		PlayerModifierStats playerStats3 = _playerStats;
		EggFloat eggFloat3 = playerStats3._003CArmor_003Ek__BackingField;
		float value3 = default(float);
		EggFloat armor = new EggFloat(value3, eggFloat3._eggVal);
		value3 = eggFloat3._val + 1f;
		playerStats3.Armor = armor;
		PlayerModifierStats playerStats4 = _playerStats;
		EggFloat eggFloat4 = playerStats4._003CMoveSpeed_003Ek__BackingField;
		float value4 = default(float);
		EggFloat moveSpeed = new EggFloat(value4, eggFloat4._eggVal);
		value4 = eggFloat4._val + 0.1f;
		playerStats4.MoveSpeed = moveSpeed;
		PlayerModifierStats playerStats5 = _playerStats;
		EggFloat eggFloat5 = playerStats5._003CPower_003Ek__BackingField;
		float value5 = default(float);
		EggFloat power = new EggFloat(value5, eggFloat5._eggVal);
		value5 = eggFloat5._val + 0.1f;
		playerStats5.Power = power;
		PlayerModifierStats playerStats6 = _playerStats;
		EggFloat eggFloat6 = playerStats6._003CSpeed_003Ek__BackingField;
		float value6 = default(float);
		EggFloat speed = new EggFloat(value6, eggFloat6._eggVal);
		value6 = eggFloat6._val + 0.1f;
		playerStats6.Speed = speed;
		PlayerModifierStats playerStats7 = _playerStats;
		EggFloat eggFloat7 = playerStats7._003CDuration_003Ek__BackingField;
		float value7 = default(float);
		EggFloat duration = new EggFloat(value7, eggFloat7._eggVal);
		value7 = eggFloat7._val + 0.1f;
		playerStats7.Duration = duration;
		PlayerModifierStats playerStats8 = _playerStats;
		EggFloat eggFloat8 = playerStats8._003CArea_003Ek__BackingField;
		float value8 = default(float);
		EggFloat area = new EggFloat(value8, eggFloat8._eggVal);
		value8 = eggFloat8._val + 0.1f;
		playerStats8.Area = area;
		PlayerModifierStats playerStats9 = _playerStats;
		EggFloat eggFloat9 = playerStats9._003CCooldown_003Ek__BackingField;
		float value9 = default(float);
		EggFloat cooldown = new EggFloat(value9, eggFloat9._eggVal);
		value9 = eggFloat9._val - 0.05f;
		playerStats9.Cooldown = cooldown;
		PlayerModifierStats playerStats10 = _playerStats;
		EggFloat eggFloat10 = playerStats10._003CAmount_003Ek__BackingField;
		float value10 = default(float);
		EggFloat amount = new EggFloat(value10, eggFloat10._eggVal);
		value10 = eggFloat10._val + 1f;
		playerStats10.Amount = amount;
		PlayerModifierStats playerStats11 = _playerStats;
		EggDouble eggDouble = playerStats11._003CRevivals_003Ek__BackingField;
		EggDouble revivals = new EggDouble(eggDouble._val, eggDouble._eggVal);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,qword ptr [188A10758h]\"");
		playerStats11.Revivals = revivals;
		PlayerModifierStats playerStats12 = _playerStats;
		EggFloat eggFloat11 = playerStats12._003CLuck_003Ek__BackingField;
		float value11 = default(float);
		EggFloat luck = new EggFloat(value11, eggFloat11._eggVal);
		value11 = eggFloat11._val + 0.1f;
		playerStats12.Luck = luck;
		PlayerModifierStats playerStats13 = _playerStats;
		EggFloat eggFloat12 = playerStats13._003CGrowth_003Ek__BackingField;
		float value12 = default(float);
		EggFloat growth = new EggFloat(value12, eggFloat12._eggVal);
		value12 = eggFloat12._val + 0.1f;
		playerStats13.Growth = growth;
		float num2 = base.MaxHp();
		object obj = default(object);
		float value13 = (float)obj - ((CharacterController)this)._currentHp;
		base.RecoverHp(value13);
		base.IsInvul = true;
		float invincibilityTimer = ((CharacterController)this)._invincibilityTimer + 0.3f;
		((CharacterController)this)._invincibilityTimer = invincibilityTimer;
		Action onComplete = delegate
		{
			//IL_00d3: Expected O, but got I4
			//IL_00d3: Expected I4, but got O
			//IL_0115: Expected O, but got I4
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass4_0();
			GameObject gameObject = GM.Core.gameObject;
			Vector2 vector = default(Vector2);
			PhaserSprite sunraySprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_TeleportRay01");
			CS_0024_003C_003E8__locals7._sunraySprite = sunraySprite;
			string text = default(string);
			int num3 = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_TeleportRay", 1, 10, vector, text, num3, flag);
			PhaserSprite sunraySprite2 = CS_0024_003C_003E8__locals7._sunraySprite;
			Action action = delegate
			{
				CS_0024_003C_003E8__locals7._sunraySprite.destroy();
			};
			bool autoSetAnimation = default(bool);
			sunraySprite2._spriteAnimation.AddAnimation("sunray", animationFrames, 16, (byte)(int)text != 0, (byte)num3 != 0, (Action)flag, autoSetAnimation);
			PhaserSprite sunraySprite3 = CS_0024_003C_003E8__locals7._sunraySprite;
			sunraySprite3._spriteAnimation.SetAnimation("sunray");
			PhaserSprite phaserSprite = CS_0024_003C_003E8__locals7._sunraySprite.setScale(1f, (float?)(object)1);
			Transform transform = CS_0024_003C_003E8__locals7._sunraySprite.transform;
			Transform parent = base.transform;
			transform.SetParent(parent, worldPositionStays: true);
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals7._sunraySprite.setLocalPosition(vector);
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type2 = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type2, isOnlineTimer: false, canPause: false);
	}

	private unsafe void _003CShowIcons_003Eb__3_0()
	{
		//IL_002d: Expected O, but got Ref
		GameManager core = GM.Core;
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.TP_SAVROG_WEAPON, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
	}

	private void _003COnWeaponMadeLevelOne_003Eb__4_0()
	{
		//IL_00d3: Expected O, but got I4
		//IL_00d3: Expected I4, but got O
		//IL_0115: Expected O, but got I4
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass4_0();
		GameObject gameObject = GM.Core.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite sunraySprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_TeleportRay01");
		CS_0024_003C_003E8__locals7._sunraySprite = sunraySprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_TeleportRay", 1, 10, vector, text, num, flag);
		PhaserSprite sunraySprite2 = CS_0024_003C_003E8__locals7._sunraySprite;
		Action action = delegate
		{
			CS_0024_003C_003E8__locals7._sunraySprite.destroy();
		};
		bool autoSetAnimation = default(bool);
		sunraySprite2._spriteAnimation.AddAnimation("sunray", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite sunraySprite3 = CS_0024_003C_003E8__locals7._sunraySprite;
		sunraySprite3._spriteAnimation.SetAnimation("sunray");
		PhaserSprite phaserSprite = CS_0024_003C_003E8__locals7._sunraySprite.setScale(1f, (float?)(object)1);
		Transform transform = CS_0024_003C_003E8__locals7._sunraySprite.transform;
		Transform parent = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
		PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals7._sunraySprite.setLocalPosition(vector);
	}
}
