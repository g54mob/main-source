using System;
using System.Collections.Generic;
using System.Threading;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Annette_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public float x;

		public float y;

		public WeaponType weaponPrize;

		internal void _003CSpawnWorldSpaceWeapon_003Eb__0()
		{
			//IL_0061: Expected I, but got O
			//IL_006f: Expected I, but got O
			//IL_007f: Expected O, but got I
			//IL_00ff: Expected O, but got I4
			//IL_00bb: Expected O, but got I
			//IL_00f1: Expected O, but got I4
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, ItemType.WEAPON, weaponPrize, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			bool flag = (object)pickup == null;
			Pickup pickup2 = null;
			object obj3;
			if (!flag)
			{
				nint num = (nint)pickup;
				nint num2 = (nint)typeof(PickupWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v25+FFFFFFF8+v161 @ rax_v21*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj3 = 1;
						goto IL_016d;
					}
				}
				obj3 = 0;
				goto IL_016d;
			}
			goto IL_0194;
			IL_0194:
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				_ = 1;
			}
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(x, y);
			return;
			IL_016d:
			bool flag2 = obj3 == null;
			pickup2 = null;
			if (!flag2)
			{
				pickup2 = pickup;
			}
			goto IL_0194;
		}
	}

	private const string CarmillaTextureName = "character_tp_carmilla";

	private bool _firstUpdateDone;

	private bool _hasDominus2;

	private Weapon _dominus2Weapon;

	private bool _isMorphed;

	private MorphVFX _morphVFX;

	private Image _ChargeBar;

	private Image _ChargeBarFill;

	private bool _isCharging;

	private float _chargeTime;

	private float _maxChargeTimeMS;

	private List<WeaponType> spells;

	private PhaserSprite _cursor1;

	private PhaserSprite _cursor2;

	private MultiTargetTween _angle1Tween;

	private MultiTargetTween _angle2Tween;

	private MultiTargetTween _scaleTween;

	private bool _hasSecondAnim;

	public override bool DrainWeaponsImmunity => _isMorphed;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!_isMorphed)
		{
			OnUpdate_Annette();
		}
		else
		{
			OnUpdate_Carmilla();
		}
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_ChargeBar.enabled = false;
		_ChargeBarFill.enabled = false;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne(dontGetCharacterDataForCurrentLevel);
		GameManager core = GM.Core;
		CharacterLoader.LoadCharacterTexture("character_tp_carmilla", CharacterType.TP_CARMILLA, core._dataManager);
	}

	public override void OnWeaponMadeLevelOne(WeaponType type)
	{
		if (type == WeaponType.TP_DOMINUS2)
		{
			_hasDominus2 = true;
			Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(type);
			_dominus2Weapon = weaponByType;
		}
	}

	private void OnUpdate_Annette()
	{
		//IL_03c6: Expected O, but got I
		//IL_0422: Expected O, but got I
		//IL_0312->IL043e: Incompatible stack heights: 2 vs 0
		if (_hasDominus2)
		{
			Weapon dominus2Weapon = _dominus2Weapon;
			if ((object)_dominus2Weapon != null && ((UnityEngine.Object)dominus2Weapon).m_CachedPtr != (IntPtr)0)
			{
				Weapon dominus2Weapon2 = _dominus2Weapon;
				if (((Equipment)dominus2Weapon2)._003CLevel_003Ek__BackingField == 6)
				{
					_hasDominus2 = false;
					if (!_isMorphed && _coherenceSync.HasStateAuthority && !((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
					{
						_isMorphed = true;
						GameManager core = GM.Core;
						if (!core._multiplayer.IsOnlineMultiplayer)
						{
							AnnetteMorph();
						}
						else
						{
							Action action = SendAnnetteMorph;
							bool flag = _coherenceSync.SendCommand(action, MessageTarget.All);
							bool flag2 = false;
						}
					}
				}
			}
		}
		if (_firstUpdateDone)
		{
			return;
		}
		_firstUpdateDone = true;
		WeaponType[] array = new WeaponType[4]
		{
			WeaponType.TP_GEARS_WEAPON,
			WeaponType.TP_PENDULUM_WEAPON,
			WeaponType.TP_HEADS_WEAPON,
			WeaponType.TP_ELEVATOR_WEAPON
		};
		bool flag3 = false;
		Action<float> action2 = null;
		bool flag4 = false;
		object obj = default(object);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while ((flag4 ? 1 : 0) < array.Length)
		{
			float num = (float)Math.PI * 2f / (float)array.Length;
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			bool flag5 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out Vector3 ret);
			bool flag6 = body == null;
			Transform transform = (Transform)(nint)((UnityEngine.Object)cachedTrans).m_CachedPtr;
			if (!flag6)
			{
				BaseBody baseBody = body;
				transform = (Transform)(object)baseBody._transform;
			}
			float num2 = (float)(flag3 ? 1 : 0) * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num3 = num2 * 1.65f;
			float x = num3 + (float)ret;
			Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
			bool flag7 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out Vector3 _);
			bool flag8 = body == null;
			Transform transform2 = (Transform)(nint)((UnityEngine.Object)cachedTrans2).m_CachedPtr;
			if (!flag8)
			{
				BaseBody baseBody2 = body;
				transform2 = (Transform)(object)baseBody2._transform;
			}
			float num4 = (float)(flag3 ? 1 : 0) * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num5 = num4 * 1.65f;
			float y = num5 + (float)obj;
			float num6 = (float)(flag3 ? 1 : 0) * 50f;
			float num7 = num6 + 1f;
			_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass13_0
			{
				x = x,
				y = y
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v6 (VampireSurvivors.Data.WeaponType[])+20+v309 @ rbp_v5 (System.Boolean)*4]");
			CS_0024_003C_003E8__locals4.weaponPrize = WeaponType.VOID;
			Action onComplete = delegate
			{
				//IL_0061: Expected I, but got O
				//IL_006f: Expected I, but got O
				//IL_007f: Expected O, but got I
				//IL_00ff: Expected O, but got I4
				//IL_00bb: Expected O, but got I
				//IL_00f1: Expected O, but got I4
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool shouldCallValidatePickups = default(bool);
				bool isRemote = default(bool);
				Pickup pickup = GM.Core.MakePickup(pos, ItemType.WEAPON, CS_0024_003C_003E8__locals4.weaponPrize, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
				bool flag9 = (object)pickup == null;
				Pickup pickup2 = null;
				object obj4;
				if (!flag9)
				{
					nint num8 = (nint)pickup;
					nint num9 = (nint)typeof(PickupWeapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
					if (num10 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v25+FFFFFFF8+v161 @ rax_v21*8]");
						if (0 == (nint)typeof(PickupWeapon))
						{
							obj4 = 1;
							goto IL_016d;
						}
					}
					obj4 = 0;
					goto IL_016d;
				}
				goto IL_0194;
				IL_0194:
				if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
				{
					_ = 1;
				}
				GameManager core2 = GM.Core;
				core2._gizmoManager.ShowHighlightAt(CS_0024_003C_003E8__locals4.x, CS_0024_003C_003E8__locals4.y);
				return;
				IL_016d:
				bool flag10 = obj4 == null;
				pickup2 = null;
				if (!flag10)
				{
					pickup2 = pickup;
				}
				goto IL_0194;
			};
			float duration = num7 * 0.001f;
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
			bool flag2 = false;
			action2 = null;
			flag4 = flag3;
		}
	}

	private void SpawnWorldSpaceWeapon(float x, float y, WeaponType weaponPrize, float delay)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals6.x = x;
		CS_0024_003C_003E8__locals6.y = y;
		CS_0024_003C_003E8__locals6.weaponPrize = weaponPrize;
		Action onComplete = delegate
		{
			//IL_0061: Expected I, but got O
			//IL_006f: Expected I, but got O
			//IL_007f: Expected O, but got I
			//IL_00ff: Expected O, but got I4
			//IL_00bb: Expected O, but got I
			//IL_00f1: Expected O, but got I4
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, ItemType.WEAPON, CS_0024_003C_003E8__locals6.weaponPrize, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			bool flag = (object)pickup == null;
			Pickup pickup2 = null;
			object obj4;
			if (!flag)
			{
				nint num = (nint)pickup;
				nint num2 = (nint)typeof(PickupWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v25+FFFFFFF8+v161 @ rax_v21*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj4 = 1;
						goto IL_016d;
					}
				}
				obj4 = 0;
				goto IL_016d;
			}
			goto IL_0194;
			IL_0194:
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				_ = 1;
			}
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(CS_0024_003C_003E8__locals6.x, CS_0024_003C_003E8__locals6.y);
			return;
			IL_016d:
			bool flag2 = obj4 == null;
			pickup2 = null;
			if (!flag2)
			{
				pickup2 = pickup;
			}
			goto IL_0194;
		};
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SyncedMorph()
	{
		if (!_isMorphed && _coherenceSync.HasStateAuthority && !((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			_isMorphed = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				AnnetteMorph();
				return;
			}
			Action action = SendAnnetteMorph;
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	public void SendAnnetteMorph()
	{
		AnnetteMorph();
	}

	private unsafe void AnnetteMorph()
	{
		//IL_0026: Expected O, but got Ref
		//IL_0050: Expected O, but got I4
		//IL_00e2: Expected O, but got F4
		//IL_0114: Expected O, but got I4
		//IL_0114: Expected I4, but got F4
		//IL_01cd: Expected O, but got I
		//IL_01e2: Expected O, but got I
		//IL_0210: Expected O, but got I
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected O, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
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
		_isMorphed = true;
		if (!_hasSecondAnim)
		{
			Vector2 pivot = default(Vector2);
			int num2 = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_Carmilla_i0", 1, 5, pivot, (string)num, num2, flag);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk2");
			_hasSecondAnim = true;
		}
		_spriteAnimation.SetAnimation("walk2");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)204);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v22 (System.Object)+18]");
		float num3;
		float num4;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v22 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v24+20]");
			object obj4 = 0;
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v5+70]");
			currentSkinData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
			AfterFullInitialization_Carmilla();
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 100f;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CMoveSpeed_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + 0.8f;
			playerStats2._003CMoveSpeed_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CPower_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + 0.2f;
			playerStats3._003CPower_003Ek__BackingField = eggFloat6;
			PlayerModifierStats playerStats4 = _playerStats;
			EggFloat eggFloat7 = playerStats4._003CGreed_003Ek__BackingField;
			float value4 = default(float);
			EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
			value4 = eggFloat7._val + 1f;
			playerStats4._003CGreed_003Ek__BackingField = eggFloat8;
			PlayerModifierStats playerStats5 = _playerStats;
			EggFloat eggFloat9 = playerStats5._003CArmor_003Ek__BackingField;
			float value5 = default(float);
			EggFloat eggFloat10 = new EggFloat(value5, eggFloat9._eggVal);
			value5 = eggFloat9._val + 1f;
			playerStats5._003CArmor_003Ek__BackingField = eggFloat10;
			num3 = ((CharacterController)this)._currentHp + 100f;
			PlayerModifierStats playerStats6 = _playerStats;
			((CharacterController)this)._currentHp = num3;
			EggFloat eggFloat11 = playerStats6._003CMaxHp_003Ek__BackingField;
			num4 = eggFloat11._eggVal + eggFloat11._val;
			object obj5 = num4 & -2147483649L;
			if ((nint)obj5 != 2139095040)
			{
				object obj6 = num4 & -2147483649L;
				if ((nint)obj6 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E7D42h\"");
					if (num4 == -1f / 0f)
					{
						num4 = -3.4028235E+38f;
					}
					goto IL_06ba;
				}
			}
			num4 = 3.4028235E+38f;
			goto IL_06ba;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_06ba:
		if (!(num3 > num4))
		{
			goto IL_05ec;
		}
		PlayerModifierStats playerStats7 = _playerStats;
		EggFloat eggFloat12 = playerStats7._003CMaxHp_003Ek__BackingField;
		float num5 = eggFloat12._eggVal + eggFloat12._val;
		object obj7 = num5 & -2147483649L;
		float currentHp;
		if ((nint)obj7 != 2139095040)
		{
			object obj8 = num5 & -2147483649L;
			if ((nint)obj8 <= 2139095040)
			{
				bool flag2 = num5 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E7D96h\"");
				currentHp = -3.4028235E+38f;
				if (!flag2)
				{
					currentHp = num5;
				}
				goto IL_06d9;
			}
		}
		currentHp = 3.4028235E+38f;
		goto IL_06d9;
		IL_05ec:
		_ChargeBar.enabled = true;
		_ChargeBarFill.enabled = true;
		GameManager core2 = GM.Core;
		GameObject gameObject = base.gameObject;
		ArcadeSprite component = gameObject.GetComponent<ArcadeSprite>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			PhysicsManager physicsManager = core2._physicsManager;
			physicsManager._playersWithWallCollisionGroup.remove(component);
		}
		return;
		IL_06d9:
		((CharacterController)this)._currentHp = currentHp;
		goto IL_05ec;
	}

	public void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 16711680u, 0u, 16711680u, 0u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}

	public unsafe void AfterFullInitialization_Carmilla()
	{
		//IL_00fc: Expected I4, but got I8
		//IL_0143: Expected I4, but got I8
		//IL_0287: Expected I, but got O
		//IL_029a: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_03d2: Expected O, but got I4
		//IL_0550: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_0581: Expected O, but got I4
		//IL_058f: Expected O, but got I4
		//IL_01ff->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_0275->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_0253->IL0253: Incompatible stack heights: 3 vs 2
		//IL_0337->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_03ad->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_038b->IL038b: Incompatible stack heights: 3 vs 2
		//IL_046f->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_053e->IL05fa: Incompatible stack heights: 2 vs 0
		//IL_04c3->IL04c3: Incompatible stack heights: 3 vs 2
		//IL_051c->IL051c: Incompatible stack heights: 3 vs 2
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		if ((object)_ChargeBarFill != null)
		{
			_ChargeBarFill.sprite = unpackedSprite;
			if ((object)_ChargeBar != null)
			{
				_ChargeBar.sprite = unpackedSprite;
				_chargeTime = 0f;
				_isCharging = false;
				HideCharge();
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Diabologue03");
				_cursor1 = cursor;
				if ((object)_cursor1 != null)
				{
					PhaserSprite phaserSprite = _cursor1.setDepth(-1);
					GameObject gameObject2 = base.gameObject;
					PhaserSprite cursor2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Diabologue04");
					_cursor2 = cursor2;
					PhaserSprite phaserSprite2 = _cursor2.setDepth(-1);
					PhaserSprite phaserSprite3 = _cursor1.setAlpha(0f);
					PhaserSprite phaserSprite4 = _cursor2.setAlpha(0f);
					Transform transform = _cursor1.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector2 value = default(Vector2);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					Transform transform2 = _cursor2.transform;
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector2 value2 = default(Vector2);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
					if (_angle1Tween != null)
					{
						_angle1Tween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						if ((object)_cursor1 != null)
						{
							void* value3 = ((IntPtr*)(&array))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag3 = obj == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1157234688;
							_ = 4294967295L;
							((MaskableGraphic)(object)tweenConfig).m_ShouldRecalculateStencil = true;
							MultiTargetTween angle1Tween = Tweens.Add(tweenConfig);
							_angle1Tween = angle1Tween;
							if (_angle2Tween != null)
							{
								_angle2Tween.Kill();
							}
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							if (array2 != null)
							{
								if ((object)_cursor2 != null)
								{
									void* value4 = ((IntPtr*)(&array2))->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									bool flag4 = obj2 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig2 != null)
								{
									((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
									((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1158660096;
									_ = 4294967295L;
									((MaskableGraphic)(object)tweenConfig2).m_ShouldRecalculateStencil = true;
									MultiTargetTween angle2Tween = Tweens.Add(tweenConfig2);
									_angle2Tween = angle2Tween;
									if (_scaleTween != null)
									{
										_scaleTween.Kill();
									}
									TweenConfig tweenConfig3 = new TweenConfig();
									object[] array3 = new object[2];
									if (array3 != null)
									{
										if ((object)_cursor1 != null)
										{
											void* value5 = ((IntPtr*)(&array3))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj3 = default(object);
											bool flag5 = obj3 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if ((object)_cursor2 != null)
										{
											void* value6 = ((IntPtr*)(&array3))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj4 = default(object);
											bool flag6 = obj4 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig3 != null)
										{
											((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
											((MonoBehaviour)(object)tweenConfig3).m_CancellationTokenSource = (CancellationTokenSource)1133903872;
											_ = 4294967295L;
											_ = 1;
											((Graphic)(object)tweenConfig3).m_Material = (Material)4;
											((Graphic)(object)tweenConfig3).m_OnDirtyMaterialCallback = (UnityAction)1;
											Func<int, float> sprite = Tweens.Stagger(150f, new StaggerConfig
											{
												ease = Ease.Linear,
												start = 0f
											});
											((Image)(object)tweenConfig3).m_Sprite = (Sprite)(object)sprite;
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig3);
											_scaleTween = scaleTween;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void FireAllSpells()
	{
		//IL_0048: Expected O, but got Ref
		//IL_042f: Expected I, but got O
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0067: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			if ((object)x != null)
			{
				List<WeaponType> list4 = spells;
				if (spells != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj5 = default(object);
					object obj4 = obj5 >> 31;
					return (byte)(obj4 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			UnityEngine.Object obj = null;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		CharacterWeaponsManager weaponsManager2 = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match2 = delegate(Equipment x)
		{
			//IL_0067: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			if ((object)x != null)
			{
				List<WeaponType> list4 = spells;
				if (spells != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj5 = default(object);
					object obj4 = obj5 >> 31;
					return (byte)(obj4 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		List<object> list2 = ((List<object>)(object)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField).FindAll((Predicate<object>)match2);
		nint num = 0;
		List<object> list3 = list2;
		List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
		while (enumerator3.MoveNext())
		{
			UnityEngine.Object obj2 = null;
			UnityEngine.Object obj3 = null;
			if ((object)obj3 != null && obj3.m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rbx_v7 (UnityEngine.Object)+100]");
				if ((nint)0 != 0)
				{
					nint num2 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v970 @ rdx_v13 (Il2CppClass<UnityEngine.Object>)+4B8] (should have been resolved before IL gen)");
				}
			}
		}
	}

	protected unsafe void OnUpdate_Carmilla()
	{
		//IL_0015: Invalid comparison between F4 and I4
		//IL_004f: Expected O, but got Ref
		//IL_0072: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001875E95A7h\"");
		if (((CharacterController)this)._walked == 0f)
		{
			Color color = _ChargeBar.color;
			object obj = default(object);
			_ChargeBar.color = (Color)(&obj);
			Color color2 = _ChargeBarFill.color;
			_ChargeBarFill.color = (Color)(&obj);
			if (!_isCharging)
			{
				_isCharging = true;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float num2 = base.PCurse();
			bool flag = 5f > deltaTime;
			float num3 = deltaTime;
			if (!flag)
			{
				num3 = 5f;
			}
			float num4 = num3 * num;
			float num5 = (_chargeTime = num4 + _chargeTime) / _maxChargeTimeMS;
			float num6 = num5 * 0.75f;
			float alpha = num6 + 0.25f;
			PhaserSprite phaserSprite = _cursor1.setAlpha(alpha);
			PhaserSprite phaserSprite2 = _cursor2.setAlpha(alpha);
			_ChargeBarFill.fillAmount = num5;
			if (!(_chargeTime < _maxChargeTimeMS))
			{
				PhaserSprite phaserSprite3 = _cursor1.setAlpha(0f);
				PhaserSprite phaserSprite4 = _cursor2.setAlpha(0f);
				HideCharge();
				_chargeTime = 0f;
				FireAllSpells();
			}
		}
		else
		{
			PhaserSprite phaserSprite5 = _cursor1.setAlpha(0f);
			PhaserSprite phaserSprite6 = _cursor2.setAlpha(0f);
			HideCharge();
		}
	}

	private unsafe void HideCharge()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _ChargeBar.color;
		object obj = default(object);
		_ChargeBar.color = (Color)(&obj);
		Color color2 = _ChargeBarFill.color;
		_ChargeBarFill.color = (Color)(&obj);
		_isCharging = false;
	}

	private unsafe void ShowCharge()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _ChargeBar.color;
		object obj = default(object);
		_ChargeBar.color = (Color)(&obj);
		Color color2 = _ChargeBarFill.color;
		_ChargeBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	protected override void OnStop()
	{
		if (!_isMorphed)
		{
			base.OnStop();
			return;
		}
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	public TP_Annette_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0219: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0241: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0269: Expected O, but got I
		//IL_01c0: Expected O, but got I
		_maxChargeTimeMS = 15000f;
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
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1497);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1497;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1498);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1499);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1499;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1500;
		}
		spells = list;
		((CharacterController)this)._002Ector();
	}

	private bool _003CFireAllSpells_003Eb__31_0(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = spells;
			if (spells != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool _003CFireAllSpells_003Eb__31_1(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = spells;
			if (spells != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
