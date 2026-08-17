using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class C1_Shapeshifter : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__20_0;

		public static Predicate<Equipment> _003C_003E9__20_1;

		public static Predicate<Equipment> _003C_003E9__20_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CMakeLevelOne_003Eb__20_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 203;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CMakeLevelOne_003Eb__20_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 204;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CMakeLevelOne_003Eb__20_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 205;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public Pickup bodyPart;

		internal void _003CGetDamaged_003Eb__1()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_SampleDrop4, 400f, 10, 0f, volume, rate, detune, loop, 1f);
			Pickup pickup = bodyPart;
			pickup._003CDisableGet_003Ek__BackingField = false;
			Pickup pickup2 = bodyPart;
			pickup2._goToPlayer = false;
			Pickup pickup3 = bodyPart;
			pickup3._003CIsStationary_003Ek__BackingField = false;
		}
	}

	private Weapon _003CFireNovaWeapon_003Ek__BackingField;

	private Weapon _003CIceNovaWeapon_003Ek__BackingField;

	private Weapon _003CFearNovaWeapon_003Ek__BackingField;

	private bool _canDropBodyPart;

	private Timer _bodyPartTimer;

	private ShapeShifterShapes currentForm;

	private ShapeShifterShapes[] shapesBag;

	private bool _hasSecondAnim;

	private float _meatDelay = 5000f;

	private int MaxHealthMaxBonus = 300;

	private int CurrentMaxHPBonus;

	public Weapon FireNovaWeapon
	{
		get
		{
			return _003CFireNovaWeapon_003Ek__BackingField;
		}
		set
		{
			_003CFireNovaWeapon_003Ek__BackingField = value;
		}
	}

	public Weapon IceNovaWeapon
	{
		get
		{
			return _003CIceNovaWeapon_003Ek__BackingField;
		}
		set
		{
			_003CIceNovaWeapon_003Ek__BackingField = value;
		}
	}

	public Weapon FearNovaWeapon
	{
		get
		{
			return _003CFearNovaWeapon_003Ek__BackingField;
		}
		set
		{
			_003CFearNovaWeapon_003Ek__BackingField = value;
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_02c5: Expected O, but got I4
		//IL_02ed: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0342: Expected O, but got I4
		//IL_036f: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_03c4: Expected O, but got I4
		//IL_03ec: Expected O, but got I4
		//IL_041e: Expected O, but got I4
		//IL_044c: Expected O, but got I4
		//IL_047a: Expected O, but got I4
		//IL_04a8: Expected O, but got I4
		//IL_04d6: Expected O, but got I4
		//IL_0504: Expected O, but got I4
		//IL_0532: Expected O, but got I4
		//IL_0560: Expected O, but got I4
		base.MakeLevelOne();
		_canDropBodyPart = true;
		currentForm = ShapeShifterShapes.Default;
		shapesBag = new ShapeShifterShapes[6]
		{
			ShapeShifterShapes.Ghost,
			ShapeShifterShapes.Lava,
			ShapeShifterShapes.Snow,
			ShapeShifterShapes.Sus,
			ShapeShifterShapes.Sus,
			ShapeShifterShapes.Sus
		};
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__20_0;
		if (_003C_003Ec._003C_003E9__20_0 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__20_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 203;
				return obj == null;
			});
		}
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
		bool flag = default(bool);
		if (list._size == 0)
		{
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.NOVA_FIRE, this, removeFromStore: true, flag);
			_003CFireNovaWeapon_003Ek__BackingField = weapon;
			Weapon weapon2 = _003CFireNovaWeapon_003Ek__BackingField;
			WeaponData currentWeaponData = weapon2._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = 2f;
			Weapon weapon3 = _003CFireNovaWeapon_003Ek__BackingField;
			((Equipment)weapon3)._003CShowInRecap_003Ek__BackingField = false;
		}
		CharacterWeaponsManager weaponsManager2 = base._weaponsManager;
		Predicate<object> match2 = (Predicate<object>)_003C_003Ec._003C_003E9__20_1;
		if (_003C_003Ec._003C_003E9__20_1 == null)
		{
			match2 = (Predicate<object>)(_003C_003Ec._003C_003E9__20_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 204;
				return obj == null;
			});
		}
		List<object> list2 = ((List<object>)(object)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField).FindAll(match2);
		if (list2._size == 0)
		{
			GameManager core2 = GM.Core;
			Weapon weapon4 = core2._weaponsFacade.AddHiddenWeapon(WeaponType.NOVA_ICEE, this, removeFromStore: true, flag);
			_003CIceNovaWeapon_003Ek__BackingField = weapon4;
			Weapon weapon5 = _003CIceNovaWeapon_003Ek__BackingField;
			WeaponData currentWeaponData2 = weapon5._currentWeaponData;
			currentWeaponData2._003Cpower_003Ek__BackingField = 0.5f;
			Weapon weapon6 = _003CIceNovaWeapon_003Ek__BackingField;
			weapon6._003CFreezeChance_003Ek__BackingField = 0.5f;
			Weapon weapon7 = _003CIceNovaWeapon_003Ek__BackingField;
			((Equipment)weapon7)._003CShowInRecap_003Ek__BackingField = false;
		}
		CharacterWeaponsManager weaponsManager3 = base._weaponsManager;
		Predicate<object> match3 = (Predicate<object>)_003C_003Ec._003C_003E9__20_2;
		if (_003C_003Ec._003C_003E9__20_2 == null)
		{
			match3 = (Predicate<object>)(_003C_003Ec._003C_003E9__20_2 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x._equipmentType - 205;
				return obj == null;
			});
		}
		List<object> list3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CHiddenEquipment_003Ek__BackingField).FindAll(match3);
		if (list3._size == 0)
		{
			GameManager core3 = GM.Core;
			Weapon weapon8 = core3._weaponsFacade.AddHiddenWeapon(WeaponType.NOVA_FEAR, this, removeFromStore: true, flag);
			_003CFearNovaWeapon_003Ek__BackingField = weapon8;
			Weapon weapon9 = _003CFearNovaWeapon_003Ek__BackingField;
			((Equipment)weapon9)._003CShowInRecap_003Ek__BackingField = false;
		}
		if (!_hasSecondAnim)
		{
			Vector2 pivot = default(Vector2);
			int num = default(int);
			bool flag2 = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("shapes_susBin_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("shapes_susBrick_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("shapes_susGhost_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("shapes_susGhostR_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("shapes_susLava_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames6 = SpriteManager.GetAnimationFrames("shapes_susMeat_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames7 = SpriteManager.GetAnimationFrames("shapes_susNugget_i", 1, 4, pivot, (string)flag, num, flag2);
			List<Sprite> animationFrames8 = SpriteManager.GetAnimationFrames("shapes_susSnow_i", 1, 4, pivot, (string)flag, num, flag2);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walkBin", animationFrames, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkBrick", animationFrames2, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkGhostB", animationFrames3, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkGhostR", animationFrames4, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkLava", animationFrames5, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkMeat", animationFrames6, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkNugget", animationFrames7, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.AddAnimation("walkSnow", animationFrames8, 8, flag, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_hasSecondAnim = true;
		}
	}

	public float MeatInterval()
	{
		float num = base.PCooldownFinal(0.25f);
		object obj = default(object);
		return (float)obj * _meatDelay;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		base.SetBloodColor(39168u);
	}

	public override void LevelUp()
	{
		//IL_001f: Expected O, but got I4
		base.LevelUp();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		object obj = 0 * 4;
		object obj2 = obj + obj;
		if (base._level == (nint)obj2 && base._level <= 100)
		{
			Weapon weapon = _003CFireNovaWeapon_003Ek__BackingField;
			WeaponData currentWeaponData = weapon._currentWeaponData;
			float num = (float)base._level / 10f;
			float num2 = num + 2f;
			currentWeaponData._003Cpower_003Ek__BackingField = num2;
			Weapon weapon2 = _003CIceNovaWeapon_003Ek__BackingField;
			float num3 = (float)base._level / 100f;
			float num4 = num3 + 0.5f;
			weapon2._003CFreezeChance_003Ek__BackingField = num4;
			Weapon weapon3 = _003CFireNovaWeapon_003Ek__BackingField;
			float num5 = (float)base._level / 100f;
			float num6 = num5 + 1f;
			WeaponData currentWeaponData2 = weapon3._currentWeaponData;
			currentWeaponData2._003Carea_003Ek__BackingField = num6;
			Weapon weapon4 = _003CIceNovaWeapon_003Ek__BackingField;
			WeaponData currentWeaponData3 = weapon4._currentWeaponData;
			currentWeaponData3._003Carea_003Ek__BackingField = num6;
			Weapon weapon5 = _003CFearNovaWeapon_003Ek__BackingField;
			WeaponData currentWeaponData4 = weapon5._currentWeaponData;
			currentWeaponData4._003Carea_003Ek__BackingField = num6;
		}
	}

	public override bool GetDamaged(float damageAmount)
	{
		//IL_0ad0: Expected O, but got F4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0af7: Invalid comparison between F4 and O
		//IL_0b15: Invalid comparison between F4 and I4
		//IL_0b3e: Expected O, but got I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0202: Expected I4, but got O
		//IL_0202: Expected F4, but got I4
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_0527: Expected O, but got I4
		//IL_04be: Expected I, but got O
		//IL_05fd: Expected O, but got I4
		//IL_05b0: Expected I, but got O
		//IL_0640: Invalid comparison between F4 and I4
		//IL_0653: Expected O, but got I4
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected I4, but got Unknown
		//IL_078c: Expected I, but got O
		//IL_0c06: Expected O, but got F4
		//IL_06f3: Expected O, but got I4
		//IL_070b: Expected I, but got O
		//IL_07de: Expected O, but got I
		//IL_081e: Expected O, but got I
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_0851: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Expected O, but got Unknown
		//IL_04e1->IL04e1: Incompatible stack heights: 1 vs 0
		//IL_05d3->IL05d3: Incompatible stack heights: 1 vs 0
		if (!GM.Core.IsStageHost || !_canDropBodyPart)
		{
			goto IL_0ab4;
		}
		object obj = UnityEngine.Random.value;
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj2 = num & -2147483649L;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = num & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DC56Ch\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0adf;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0adf;
		IL_0a9d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v64+20+v242 @ rax_v97 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.ShapeShifterShapes>)*4]");
		currentForm = ShapeShifterShapes.Default;
		goto IL_0ab4;
		IL_0adf:
		float num2 = num * 0.2f;
		object obj4 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
		float num3 = num2 - (float)obj4;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj5 = flag4 & flag3;
		if (obj5 == null)
		{
			goto IL_0ab4;
		}
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass24_0();
		_canDropBodyPart = false;
		float num4 = base.PCooldownFinal(0.25f);
		object obj6 = obj4 * _meatDelay;
		Action onComplete = delegate
		{
			_canDropBodyPart = true;
		};
		float duration = (float)obj6 * 0.001f;
		bool flag5 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num5 = default(int);
		TimerType timerType = default(TimerType);
		Timer bodyPartTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag5, monoBehaviour, num5, timerType, isOnlineTimer: false, canPause: false);
		_bodyPartTimer = bodyPartTimer;
		float2 float5 = base.position;
		float2 float6 = base.position;
		Vector2 pos = default(Vector2);
		Pickup bodyPart = GM.Core.MakePickup(pos, ItemType.ROAST, WeaponType.VOID, flag5 ? 1 : 0, (ItemType)monoBehaviour, (byte)num5 != 0, (byte)timerType != 0, onlineSynchronization: false);
		CS_0024_003C_003E8__locals11.bodyPart = bodyPart;
		Pickup bodyPart2 = CS_0024_003C_003E8__locals11.bodyPart;
		bodyPart2._spriteAnimation.Stop();
		CS_0024_003C_003E8__locals11.bodyPart.SetFrame("mmmeat.png");
		Pickup bodyPart3 = CS_0024_003C_003E8__locals11.bodyPart;
		float value = UnityEngine.Random.value;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat2 = playerStats2._003CLuck_003Ek__BackingField;
		float num6 = eggFloat2._eggVal + eggFloat2._val;
		object obj7 = num6 & -2147483649L;
		float num7;
		if ((nint)obj7 != 2139095040)
		{
			object obj8 = num6 & -2147483649L;
			if ((nint)obj8 <= 2139095040)
			{
				bool flag6 = num6 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DC764h\"");
				num7 = -3.4028235E+38f;
				if (!flag6)
				{
					num7 = num6;
				}
				goto IL_0b5b;
			}
		}
		num7 = 3.4028235E+38f;
		goto IL_0b5b;
		IL_0ab4:
		return base.GetDamaged(damageAmount);
		IL_0a82:
		CoherenceSync coherenceSync = default(CoherenceSync);
		Action action = default(Action);
		bool flag7 = coherenceSync.SendCommand(action, MessageTarget.All);
		goto IL_0a9d;
		IL_0b5b:
		float num8 = num7 * value;
		bool flag8 = num8 > 1f;
		float num9 = 1f;
		if (!flag8)
		{
			num9 = num8;
		}
		float num10 = num9 * 4f;
		float num11 = num10 + 4f;
		bodyPart3._003CValue_003Ek__BackingField = num11;
		Pickup bodyPart4 = CS_0024_003C_003E8__locals11.bodyPart;
		bodyPart4._003CDisableGet_003Ek__BackingField = true;
		Pickup bodyPart5 = CS_0024_003C_003E8__locals11.bodyPart;
		bodyPart5._003CIsStationary_003Ek__BackingField = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num12 = renderer.height;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		if (!(renderer2.width > renderer.height))
		{
			num12 = renderer2.width;
		}
		float num13 = num12 * 0.5f;
		float value2 = UnityEngine.Random.value;
		float num14 = value2 * (float)Math.PI;
		float num15 = num14 + num14;
		float2 float7 = base.position;
		float2 float8 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num16 = num15 * num13;
		object obj9 = default(object);
		float num17 = num16 + (float)obj9;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals11.bodyPart != null)
		{
			nint num18 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag9 = obj10 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_SampleDrop4, 400f, 10, 0f, volume, rate, detune, loop, 1f);
			Pickup bodyPart6 = CS_0024_003C_003E8__locals11.bodyPart;
			bodyPart6._003CDisableGet_003Ek__BackingField = false;
			Pickup bodyPart7 = CS_0024_003C_003E8__locals11.bodyPart;
			bodyPart7._goToPlayer = false;
			Pickup bodyPart8 = CS_0024_003C_003E8__locals11.bodyPart;
			bodyPart8._003CIsStationary_003Ek__BackingField = false;
		};
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)CS_0024_003C_003E8__locals11.bodyPart != null)
		{
			nint num19 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			bool flag10 = obj11 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.y = (float?)(object)1;
		tweenConfig2.duration = 500f;
		float2 float9 = base.position;
		bool flag11 = num17 < num17;
		float num20 = num17 - num17;
		bool flag12 = num20 == 0f;
		object obj12 = flag11 | flag12;
		Ease ease = (Ease)(obj12 + 26);
		tweenConfig2.ease = ease;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		List<ShapeShifterShapes> list = new List<ShapeShifterShapes>();
		List<ShapeShifterShapes> list2;
		if (currentForm == ShapeShifterShapes.Default)
		{
			ShapeShifterShapes[] array3 = shapesBag;
			bool flag13 = false;
			nint num21 = 0;
			bool flag14 = false;
			while (true)
			{
				bool flag15 = (flag14 ? 1 : 0) >= array3.Length;
				list2 = (List<ShapeShifterShapes>)flag14;
				if (!flag15)
				{
					num21 = (nint)shapesBag;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v34 (Il2CppMethodInfo)+20+v72 @ rsi_v19 (System.Boolean)*4]");
					if ((nint)0 != (nint)currentForm)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v34 (Il2CppMethodInfo)+20+v72 @ rsi_v19 (System.Boolean)*4]");
						num21 = 0;
						list._002Ector();
					}
					array3 = shapesBag;
					flag13 = (byte)((flag13 ? 1u : 0u) + 1u) != 0;
					flag14 = flag13;
					continue;
				}
				break;
			}
		}
		else
		{
			list._002Ector();
			nint num21 = unchecked((nint)null);
			list2 = list;
		}
		object obj13 = UnityEngine.Random.value;
		list2._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1642 @ rax_v89 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.ShapeShifterShapes>)+18]");
		List<ShapeShifterShapes> list3 = default(List<ShapeShifterShapes>);
		if ((nint)list3 < 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1642 @ rax_v89 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.ShapeShifterShapes>)+10]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v64+20+v242 @ rax_v97 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.ShapeShifterShapes>)*4]");
			bool flag16 = (nint)0 == 0;
			if (!flag16)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v64+20+v242 @ rax_v97 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.ShapeShifterShapes>)*4]");
				object obj15 = -1;
				if (!flag16)
				{
					object obj16 = obj15 - 1;
					if (!flag16)
					{
						object obj17 = obj16 - 1;
						if (!flag16)
						{
							if ((nint)obj17 == 1)
							{
								string susAnimation = GetSusAnimation();
								GameManager core = GM.Core;
								if (!core._multiplayer.IsOnlineMultiplayer)
								{
									TurnToSus(susAnimation);
								}
								else
								{
									Action<string> action2 = TurnToSus;
									bool flag17 = _coherenceSync.SendCommand((Action<object>)action2, MessageTarget.All, susAnimation);
								}
							}
						}
						else
						{
							string ghostAnimation = GetGhostAnimation();
							GameManager core2 = GM.Core;
							if (!core2._multiplayer.IsOnlineMultiplayer)
							{
								TurnToGhost(ghostAnimation);
							}
							else
							{
								Action<string> action3 = TurnToGhost;
								bool flag18 = _coherenceSync.SendCommand((Action<object>)action3, MessageTarget.All, ghostAnimation);
							}
						}
					}
					else
					{
						GameManager core3 = GM.Core;
						if (core3._multiplayer.IsOnlineMultiplayer)
						{
							coherenceSync = _coherenceSync;
							action = null;
							nint num22 = 0;
							goto IL_0a82;
						}
						TurnToLava();
					}
				}
				else
				{
					GameManager core4 = GM.Core;
					if (core4._multiplayer.IsOnlineMultiplayer)
					{
						coherenceSync = _coherenceSync;
						nint num22 = default(nint);
						action = new Action(this, num22);
						num22 = 0;
						goto IL_0a82;
					}
					TurnToSnow();
				}
			}
			else
			{
				GameManager core5 = GM.Core;
				if (core5._multiplayer.IsOnlineMultiplayer)
				{
					coherenceSync = _coherenceSync;
					action = null;
					nint num22 = 0;
					goto IL_0a82;
				}
				TurnToNormal();
			}
			goto IL_0a9d;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0a82;
	}

	public void TurnToNormal()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5C33]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_spriteAnimation.SetAnimation("walk");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walk";
		AddMaxHPBonus(1);
	}

	public void TurnToSnow()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5C34]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_spriteAnimation.SetAnimation("walkSnow");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walkSnow";
		_003CIceNovaWeapon_003Ek__BackingField.Fire();
		AddMaxHPBonus(1);
	}

	public void TurnToLava()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5C35]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_spriteAnimation.SetAnimation("walkLava");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walkLava";
		_003CFireNovaWeapon_003Ek__BackingField.Fire();
		AddMaxHPBonus(1);
	}

	public void TurnToGhost(string anim)
	{
		_spriteAnimation.SetAnimation(anim);
		base._003CCurrentWalkAnimName_003Ek__BackingField = anim;
		_003CFearNovaWeapon_003Ek__BackingField.Fire();
		AddMaxHPBonus(1);
	}

	public void TurnToSus(string anim)
	{
		_spriteAnimation.SetAnimation(anim);
		base._003CCurrentWalkAnimName_003Ek__BackingField = anim;
		AddMaxHPBonus(8);
	}

	private string GetSusAnimation()
	{
		//IL_00b1: Expected O, but got F4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5C36]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj3 = default(object);
		bool flag = obj3 == null;
		if (!flag)
		{
			object obj4 = obj3 - 1;
			if (flag)
			{
				return "walkBrick";
			}
			object obj5 = obj4 - 1;
			if (flag)
			{
				return "walkNugget";
			}
			if ((nint)obj5 == 1)
			{
				return "walkMeat";
			}
		}
		return "walkBin";
	}

	private string GetGhostAnimation()
	{
		//IL_0054: Expected O, but got F4
		//IL_005d: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5C37]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		string result = "walkGhostR";
		if (!flag)
		{
			result = "walkGhostB";
		}
		return result;
	}

	private void AddMaxHPBonus(int value)
	{
		if (CurrentMaxHPBonus < MaxHealthMaxBonus)
		{
			int num = MaxHealthMaxBonus - CurrentMaxHPBonus;
			if (value <= num)
			{
				num = value;
			}
			PlayerModifierStats playerStats = _playerStats;
			int currentMaxHPBonus = CurrentMaxHPBonus + num;
			CurrentMaxHPBonus = currentMaxHPBonus;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat2 = new EggFloat(value2, eggFloat._eggVal);
			value2 = (float)num + eggFloat._val;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
		}
	}

	private void DebugTurnToGhost()
	{
		string ghostAnimation = GetGhostAnimation();
		TurnToGhost(ghostAnimation);
	}

	private void DebugTurnToSus()
	{
		string susAnimation = GetSusAnimation();
		TurnToSus(susAnimation);
	}

	private void _003CGetDamaged_003Eb__24_0()
	{
		_canDropBodyPart = true;
	}
}
