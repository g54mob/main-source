using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class SilfWeapon : Weapon
{
	protected SpriteRenderer _TargetZone;

	public List<Vector2> _Targets;

	public int _EnemyIndex;

	public SpriteRenderer _Bird;

	public float _RayDuration;

	public float _TotalTime;

	public float _AngleTime;

	protected float _damageZoneDistance;

	protected float _damageZoneDefaultRadius;

	protected bool _blockFire;

	protected float _delayBasedOnDuration;

	protected Vector2 _currentDirection;

	protected float _runSpeed;

	protected Circle _damageZone;

	protected float _targetZoneAngle;

	protected float _damageZoneAngle;

	private const bool IsPortrait = false;

	private const float GameplayPixelWidth = 3.42f;

	private const float GameplayPixelHeight = 4.56f;

	protected Color _targetZoneCol;

	protected float _targetZoneStroke;

	protected float _targetZoneAlphaOn;

	protected float _targetZoneAlphaOff;

	protected float _offsetY;

	protected string _birdSprite;

	protected string _birdAnimPrefix;

	protected int _birdAnimStartFrame;

	protected int _birdAnimFrameCount;

	private static readonly int ColorId;

	private static readonly int ThicknessId;

	protected WeaponType _counterWeaponType;

	protected Weapon _counterWeapon;

	public override void CheckArcanas()
	{
		//IL_015e: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_0176: Expected O, but got I
		//IL_01f6: Expected O, but got I4
		//IL_01b2: Expected O, but got I
		//IL_01e8: Expected O, but got I4
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_explodeOnExpire = true;
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		Weapon weapon;
		object obj5;
		if ((nint)obj2 > -1)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				return;
			}
			GameManager core3 = GM.Core;
			bool allowDuplicates = default(bool);
			weapon = core3._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
			nint num = (nint)typeof(SilfWeapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rcx_v34+FFFFFFF8+v558 @ rcx_v26*8]");
				if (0 == (nint)typeof(SilfWeapon))
				{
					obj5 = 1;
					goto IL_032c;
				}
			}
			obj5 = 0;
			goto IL_032c;
		}
		goto IL_034e;
		IL_034e:
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager3 = gameMan._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
		return;
		IL_032c:
		bool flag = obj5 == null;
		Weapon weapon2 = null;
		if (!flag)
		{
			weapon2 = weapon;
		}
		_ = _TotalTime;
		_ = _AngleTime;
		_counterWeapon = weapon2;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag2 = weapon2.LevelUp();
		}
		goto IL_034e;
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
	{
		//IL_007b: Expected I4, but got O
		bool result = base.ApplyLimitBreak(weightedLimitBreak);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.ApplyLimitBreak(weightedLimitBreak);
		}
		return result;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		MakeBirb();
		_damageZoneDefaultRadius = 0.57f;
		_damageZoneDistance = 1.71f;
		SetupTargetZone(_TargetZone);
		Circle circle = new Circle();
		circle._radius = _damageZoneDefaultRadius;
		circle._x = 0f;
		_damageZone = circle;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0557: Expected O, but got Ref
		//IL_05c0: Expected O, but got Ref
		//IL_0679: Expected O, but got I
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00f1: Expected O, but got F4
		//IL_0144: Expected O, but got F4
		//IL_0171: Invalid comparison between I4 and F4
		//IL_0190: Invalid comparison between F4 and I4
		//IL_06fc: Expected O, but got F4
		//IL_0759: Expected O, but got Ref
		//IL_0725: Expected O, but got F4
		//IL_026c: Invalid comparison between F4 and I4
		//IL_07dd: Expected O, but got Ref
		//IL_08c4: Expected O, but got Ref
		//IL_0398: Expected O, but got Ref
		//IL_0458: Expected F4, but got I
		//IL_046d: Expected F4, but got I
		//IL_0947: Expected O, but got Ref
		//IL_0163->IL0514: Incompatible stack heights: 1 vs 0
		//IL_01e3->IL0514: Incompatible stack heights: 1 vs 0
		//IL_0717->IL0514: Incompatible stack heights: 1 vs 0
		//IL_0330->IL0514: Incompatible stack heights: 7 vs 0
		//IL_034f->IL0514: Incompatible stack heights: 7 vs 0
		//IL_037b->IL0514: Incompatible stack heights: 7 vs 0
		//IL_08f3->IL0514: Incompatible stack heights: 8 vs 0
		//IL_0915->IL091a: Incompatible stack heights: 8 vs 7
		//IL_0403->IL091a: Incompatible stack heights: 8 vs 7
		//IL_043e->IL0514: Incompatible stack heights: 8 vs 0
		//IL_0487->IL0514: Incompatible stack heights: 8 vs 0
		//IL_095e->IL091a: Incompatible stack heights: 10 vs 7
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InternalUpdate();
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				}
				else
				{
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
					if ((object)_Bird != null)
					{
						Transform transform2 = _Bird.transform;
						if ((object)transform2 != null)
						{
							_ = 0;
							_ = 0;
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
							float deltaTime = PauseSystem.DeltaTime;
							float num = deltaTime * 1000f;
							float totalTime = num + _TotalTime;
							_TotalTime = totalTime;
							float deltaTime2 = PauseSystem.DeltaTime;
							float num2 = deltaTime2 * 1000f;
							float num3 = (_AngleTime = num2 + _AngleTime);
							float num4 = OffsetX();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
							float num5 = 0f + num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
							object obj5 = num6 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
							float num7 = 0f - num5;
							object obj6 = obj5 * obj5;
							float num8 = num7 * num7;
							float num9 = num8 + (float)obj6;
							if (!(num9 > 0.5f))
							{
								goto IL_06d8;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
							float num10 = 0f - 0.24f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
							float num11 = 0f + num3;
							Vector2 vector = (Vector2)(this + 404);
							float num12 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
							float num13 = num12 - 0f;
							float num14 = num11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
							float num15 = num14 - 0f;
							_currentDirection = (Vector2)num15;
							float num16 = num13 + _offsetY;
							((Vector2*)vector)->Normalize();
							float num17 = (float)_currentDirection * 0.02f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.SilfWeapon)+198]");
							num9 = 0f * 0.02f;
							_currentDirection = (Vector2)num17;
							if ((object)_Bird != null)
							{
								bool flag2 = 0f < num17;
								float num18 = 0f - num17;
								bool flag3 = num18 == 0f;
								bool flag4 = !flag2;
								bool flag5 = !flag3;
								bool flipX = flag5 & flag4;
								_Bird.flipX = flipX;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									float num19 = ((Equipment)this)._003COwner_003Ek__BackingField.PMoveSpeed();
									object obj7 = Time.timeScale;
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
									{
										float num20 = ((Equipment)this)._003COwner_003Ek__BackingField.PMoveSpeed();
										object obj8 = Time.timeScale;
										goto IL_06d8;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0514;
		IL_0514:
		throw new NullReferenceException();
		IL_06d8:
		bool flag6 = (object)_Bird == null;
		Transform transform3 = _Bird.transform;
		bool flag7 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-51]");
		_ = 0;
		bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj9);
		float num21 = base.PDuration();
		float num22 = default(float);
		float num23;
		if (_TotalTime < num22)
		{
			num23 = _TotalTime;
			if (_TotalTime > 0f)
			{
				UnblockFire();
			}
		}
		else
		{
			BlockFire();
			num23 = num22;
		}
		bool flag9 = (object)_Bird == null;
		Transform transform4 = _Bird.transform;
		bool flag10 = (object)transform4 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-51]");
		_ = 0;
		bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj10);
		float num24 = base.PSpeed();
		float num25 = _AngleTime - _RayDuration;
		float num26 = num25 * -0.001f;
		float num27 = (_targetZoneAngle = num23 * num26);
		float num28 = base.PSpeed();
		float num29 = _AngleTime * -0.001f;
		float damageZoneAngle = num27 * num29;
		_damageZoneAngle = damageZoneAngle;
		if (!IsHoming)
		{
			UpdateTargetZonePos(_TargetZone, _targetZoneAngle);
			UpdateDamageZonePos(_damageZone, _damageZoneAngle);
			return;
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform5 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform5 != null)
			{
				_ = 0;
				_ = 0;
				bool flag12 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj11);
				if ((object)core._stage != null)
				{
					Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
					_ = 0;
					EnemyController enemyController = core._stage.FindClosestEnemy(queryPos);
					if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					Circle damageZone = _damageZone;
					float2 position = enemyController.position;
					if (_damageZone != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
						damageZone._x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+6B]");
						damageZone._y = 0f;
						if ((object)_TargetZone != null)
						{
							Transform transform6 = _TargetZone.transform;
							float2 position2 = enemyController.position;
							bool flag13 = (object)transform6 == null;
							_ = 0;
							bool flag14 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
							object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
							Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj12);
							return;
						}
					}
				}
			}
		}
		goto IL_0514;
	}

	public override void Fire(bool skipTriggers = false)
	{
		if (!_blockFire)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num = base.PAmount();
			object obj = default(object);
			float num2 = currentWeaponData._003Cinterval_003Ek__BackingField / (float)obj;
			currentWeaponData._003CrepeatInterval_003Ek__BackingField = num2;
			Circle damageZone = _damageZone;
			damageZone._radius = _damageZoneDefaultRadius;
			float diameter = _damageZoneDefaultRadius + _damageZoneDefaultRadius;
			damageZone._diameter = diameter;
			List<Vector2> targets = _Targets;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			AddTargets();
			base.Fire(skipTriggers);
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		SpriteRenderer bird = _Bird;
		if ((object)_Bird != null && ((UnityEngine.Object)bird).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Bird.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = _Bird.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
		SpriteRenderer targetZone = _TargetZone;
		if ((object)_TargetZone != null && ((UnityEngine.Object)targetZone).m_CachedPtr != (IntPtr)0)
		{
			_TargetZone.enabled = false;
		}
	}

	public override void HandlePlayerTeleport(float2 destinationPos)
	{
		//IL_014b->IL00c6: Incompatible stack heights: 1 vs 0
		//IL_00b2->IL00c6: Incompatible stack heights: 1 vs 0
		//IL_019e->IL0100: Incompatible stack heights: 3 vs 0
		Transform transform = (Transform)(object)((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)_Bird != null)
		{
			Transform transform2 = _Bird.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Transform transform3 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					if ((object)transform3 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual float OffsetX()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._isFlipped)
		{
			return 0.24f;
		}
		return -0.24f;
	}

	protected virtual void AddTargets()
	{
		//IL_00b8: Expected O, but got I4
		//IL_003c: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		object obj = 0;
		do
		{
			List<Vector2> targets = _Targets;
			Vector2 randomPoint = _damageZone.GetRandomPoint();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v5+18]");
			if (num >= 0)
			{
				targets.AddWithResize(randomPoint);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
			obj++;
		}
		while ((nint)obj < 12);
	}

	protected virtual void BlockFire()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		float num = base.PDuration();
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = default(object);
		object obj = obj2 ^ 0;
		float num3 = (float)obj * _delayBasedOnDuration;
		_blockFire = true;
		float num4 = (_TotalTime = (float)obj2 * num3);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_TargetZone, _targetZoneAlphaOff);
		float num5 = base.PDuration();
		if (!(_TotalTime < num4))
		{
			_TotalTime = 0f;
			_blockFire = false;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_TargetZone, _targetZoneAlphaOn);
		}
	}

	protected virtual void UnblockFire()
	{
		_blockFire = false;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_TargetZone, _targetZoneAlphaOn);
	}

	protected unsafe virtual void UpdateTargetZonePos(SpriteRenderer targetZone, float angle)
	{
		//IL_0137: Expected O, but got Ref
		//IL_009a: Expected O, but got I
		//IL_029b: Expected F4, but got I4
		//IL_02b3: Expected O, but got Ref
		//IL_01b8: Expected O, but got I
		//IL_036e: Expected F4, but got I4
		//IL_0386: Expected O, but got Ref
		//IL_0262->IL01ee: Incompatible stack heights: 1 vs 0
		//IL_032b->IL0330: Incompatible stack heights: 0 vs 3
		//IL_016c->IL0330: Incompatible stack heights: 0 vs 3
		//IL_038b->IL038b: Incompatible stack heights: 1 vs 3
		float ret;
		float num5 = default(float);
		if (!IsHoming)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num = angle * _damageZoneDistance;
					if ((object)targetZone != null)
					{
						Transform transform2 = targetZone.transform;
						object obj = default(object);
						float num2 = (float)obj + num;
						bool flag2 = (object)transform2 == null;
						IntPtr cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj2 = 0;
						float num3 = 0f;
						float num4 = num5;
						float num6 = angle;
						object obj3 = (object)(&ret);
						goto IL_038b;
					}
				}
			}
		}
		else
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform3 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform3 != null)
				{
					if (((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform3);
					}
					else
					{
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)(&ret));
						if ((object)core._stage != null)
						{
							float num7 = default(float);
							EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&num7));
							if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							if ((object)targetZone != null)
							{
								Transform transform4 = targetZone.transform;
								float2 position = enemyController.position;
								IntPtr cachedPtr = ((UnityEngine.Object)transform4).m_CachedPtr;
								bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								object obj2 = 0;
								float num3 = 3.4028235E+38f;
								float num2 = 0f;
								float num8 = default(float);
								float num4 = num8;
								float num6 = num5;
								object obj3 = (object)(&num7);
								goto IL_038b;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_038b:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v957 @ rax_v2 (should have been resolved before IL gen)");
	}

	protected virtual void UpdateDamageZonePos(Circle damageZone, float angle)
	{
		//IL_0118->IL00c9: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (damageZone != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num = angle * _damageZoneDistance;
					float x = num + (float)ret;
					damageZone._x = x;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num2 = angle * _damageZoneDistance;
					object obj = default(object);
					float y = num2 + (float)obj;
					damageZone._y = y;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeBirb()
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		if ((object)gameObject != null)
		{
			((UnityEngine.Object)gameObject).SetName("Silf_Weapon_Bird");
			SpriteRenderer bird = gameObject.AddComponent<SpriteRenderer>();
			_Bird = bird;
			Sprite sprite = SpriteManager.GetSprite(_birdSprite, "vfx");
			if ((object)_Bird != null)
			{
				_Bird.sprite = sprite;
				Camera main = Camera.main;
				Bounds bounds = CameraExtensions.OrthographicBounds(main);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v28 (UnityEngine.Bounds)+10]");
				float num = 0f * 2f;
				float num2 = num + num;
				float num3 = num2 * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				if ((object)_Bird != null)
				{
					int sortingOrder = default(int);
					_Bird.sortingOrder = sortingOrder;
					SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
					bool flag = default(bool);
					List<Sprite> animation = SpriteManager.GetAnimation(_birdAnimPrefix, _birdAnimStartFrame, _birdAnimFrameCount, "vfx", flag);
					if ((object)spriteAnimation != null)
					{
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						spriteAnimation.AddAnimation("idle", animation, 6, flag, startRandomFrame, onComplete, autoSetAnimation);
						Transform transform = gameObject.transform;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
								bool flag3 = (object)transform == null;
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private float DistanceSquared(Vector2 vec1, Vector2 vec2)
	{
		object obj = vec1 - vec2;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj5 = obj * obj;
		object obj6 = obj2 * obj2;
		return (float)obj5 + (float)obj6;
	}

	protected unsafe void SetupTargetZone(SpriteRenderer targetZone)
	{
		//IL_015e->IL00c3: Incompatible stack heights: 1 vs 0
		//IL_00b4->IL00c3: Incompatible stack heights: 1 vs 0
		if ((object)targetZone != null)
		{
			Material material = ((Renderer)targetZone).GetMaterial();
			RenderingExtensions.SetAlpha(material, _targetZoneAlphaOn);
			Material material2 = ((Renderer)targetZone).GetMaterial();
			if ((object)material2 != null)
			{
				bool flag = ((UnityEngine.Object)material2).m_CachedPtr == (IntPtr)0;
				Color value = default(Color);
				Material.SetColorImpl_Injected(((UnityEngine.Object)material2).m_CachedPtr, ColorId, ref value);
				Material material3 = ((Renderer)targetZone).GetMaterial();
				if ((object)material3 != null)
				{
					float num = _targetZoneStroke / 100f;
					float value2 = num * 2.25f;
					material3.SetFloatImpl(ThicknessId, value2);
					float num2 = base.PArea();
					Transform transform = targetZone.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&value));
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		//IL_010e: Expected O, but got I4
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		SpriteRenderer bird = _Bird;
		if ((object)_Bird != null && ((UnityEngine.Object)bird).m_CachedPtr != (IntPtr)0)
		{
			_Bird.enabled = visible;
		}
		SpriteRenderer targetZone = _TargetZone;
		if ((object)_TargetZone != null && ((UnityEngine.Object)targetZone).m_CachedPtr != (IntPtr)0)
		{
			_TargetZone.enabled = visible;
		}
		if (!visible)
		{
			if (_lastShotTimer != null)
			{
				_lastShotTimer.Cancel();
			}
			List<Projectile> spawnedProjectiles = _spawnedProjectiles;
			bool flag = (nint)_spawnedProjectiles < 0;
			object obj = spawnedProjectiles._size - 1;
			if (!flag)
			{
				Projectile[] items;
				do
				{
					List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
					if ((nint)obj < spawnedProjectiles2._size)
					{
						items = spawnedProjectiles2._items;
						items[obj].Despawn();
						obj--;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				while ((nint)items[obj] >= 0);
			}
		}
		_isVisible = visible;
	}

	public SilfWeapon()
	{
		//IL_009a: Expected I, but got O
		//IL_010b: Expected O, but got I
		List<Vector2> targets = new List<Vector2>();
		_Targets = targets;
		_RayDuration = 500f;
		_damageZoneDistance = 1.5f;
		_damageZoneDefaultRadius = 0.5f;
		_delayBasedOnDuration = 1f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v6 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		float runSpeed = GameManager.PlayerPxSpeed / 1.1785715f;
		_targetZoneStroke = 1f;
		_targetZoneAlphaOn = 0.5f;
		_targetZoneAlphaOff = 0.1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12470]");
		_targetZoneCol = (Color)0;
		_runSpeed = runSpeed;
		_birdSprite = "ProjectileBird2";
		_birdAnimPrefix = "ProjectileBird";
		_birdAnimStartFrame = 1;
		_birdAnimFrameCount = 2;
		_counterWeaponType = WeaponType.SILF_COUNTER;
		base._002Ector();
	}

	static SilfWeapon()
	{
		int colorId = Shader.PropertyToID("_Color");
		ColorId = colorId;
		int thicknessId = Shader.PropertyToID("_Thickness");
		ThicknessId = thicknessId;
	}
}
