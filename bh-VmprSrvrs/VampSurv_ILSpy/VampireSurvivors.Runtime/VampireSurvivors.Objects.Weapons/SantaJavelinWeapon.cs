using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class SantaJavelinWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public SantaJavelinWeapon _003C_003E4__this;

		public Vector3 cachedPos;
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_FireProjectiles_003Eb__0()
		{
			//IL_0183: Expected O, but got I4
			//IL_0112: Expected O, but got I
			//IL_013d: Expected I, but got O
			//IL_00a8->IL014c: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL014c: Incompatible stack heights: 1 vs 0
			//IL_00fc->IL014c: Incompatible stack heights: 1 vs 0
			//IL_0130->IL014c: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						GameObject gameObject2 = (GameObject)(object)obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v7 (UnityEngine.GameObject)+58]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v7 (UnityEngine.GameObject)+58]");
								float2 position = ((ArcadeSprite)0).position;
								if (CS_0024_003C_003E8__locals1 != null)
								{
									nint num = (nint)gameObject2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v264 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+5F8] (should have been resolved before IL gen)");
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	[NonSerialized]
	public bool _doFiring = true;

	private float _mul = 166.66667f;

	protected bool _cooldownAffectedByMovement;

	protected WeaponType _counterWeaponType = WeaponType.SANTAJAVELINCOUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual float PitchCorrection
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	public virtual bool SingleProjectile => false;

	public override float PAmount()
	{
		//IL_00b1: Expected I, but got O
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_000e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		nint num = (nint)this;
		float num2 = base.PDuration();
		object obj = default(object);
		float num3 = (float)obj / 1000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj3 = default(object);
		object obj2 = obj3 - 1;
		if ((nint)obj2 > 10)
		{
			obj2 = 10;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float num4 = gameSessionData._activeCharacter.PAmount();
		bool flag = !(10f > num3);
		float num5 = 10f;
		if (!flag)
		{
			num5 = num3;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num6 = num5 + (float)currentWeaponData._003Camount_003Ek__BackingField;
		if ((nint)obj2 <= 0)
		{
			obj2 = 0;
		}
		return (float)obj2 + num6;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base._003CCanCrit_003Ek__BackingField = true;
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	public override void CheckArcanas()
	{
		//IL_0300: Expected I, but got O
		//IL_030e: Expected I, but got O
		//IL_031e: Expected O, but got I
		//IL_039e: Expected O, but got I4
		//IL_035a: Expected O, but got I
		//IL_0390: Expected O, but got I4
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_explodeOnExpire = true;
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan2._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager4 = gameMan3._arcanaManager;
		List<ArcanaType> list4 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager5 = core2._arcanaManager;
		List<ArcanaType> list5 = arcanaManager5._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj5 = default(object);
		if ((nint)obj5 <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core3 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core3._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		if (flag)
		{
			goto IL_044b;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(SantaJavelinCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelinCounterWeapon>)+130]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelinCounterWeapon>)+130]");
		object obj8;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v53+FFFFFFF8+v736 @ rax_v49*8]");
			if (0 == (nint)typeof(SantaJavelinCounterWeapon))
			{
				obj8 = 1;
				goto IL_045a;
			}
		}
		obj8 = 0;
		goto IL_045a;
		IL_045a:
		bool flag2 = obj8 == null;
		weapon2 = null;
		if (!flag2)
		{
			weapon2 = weapon;
		}
		goto IL_044b;
		IL_044b:
		_counterWeapon = weapon2;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag3 = weapon2.LevelUp();
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 1000f;
			float num4 = frameWalk * 100f;
			float num5 = num3 / _mul;
			float num6 = num5 * num4;
			num2 = (base._003CTotalTime_003Ek__BackingField = num6 + base._003CTotalTime_003Ek__BackingField);
		}
		float num7 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num2))
		{
			float num8 = base.PInterval();
			float num9 = base._003CTotalTime_003Ek__BackingField - num2;
			base._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0018: Expected O, but got Ref
		object obj = default(object);
		ForcedFire(hasTarget: false, (Vector3)(&obj), skipTriggers);
	}

	public unsafe virtual void ForcedFire(bool hasTarget, Vector3 position, bool skipTriggers = false)
	{
		//IL_0010: Expected O, but got Ref
		//IL_0022: Expected O, but got Ref
		float num = default(float);
		Vector3 vector = Fire_FireProjectiles(hasTarget, (Vector3)(&num));
		Fire_FireCounter((Vector3)(&num), skipTriggers);
	}

	protected unsafe virtual Vector3 Fire_FireProjectiles(bool hasTarget, Vector3 position, bool skipTriggers = false)
	{
		//IL_0022: Expected O, but got I4
		//IL_0053: Expected O, but got F4
		//IL_034a: Expected O, but got Ref
		//IL_034a: Expected O, but got F4
		//IL_0360: Expected O, but got F4
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_0538: Invalid comparison between O and F4
		//IL_024e: Expected O, but got Ref
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected Ref, but got Unknown
		//IL_0392: Expected O, but got F4
		//IL_069b: Expected F4, but got O
		//IL_0696: Expected native int or pointer, but got O
		//IL_06b0: Expected F4, but got I
		//IL_06ab: Expected native int or pointer, but got O
		//IL_0563: Expected F4, but got O
		//IL_03b7: Expected O, but got I4
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_043b: Expected I4, but got O
		//IL_040a: Expected O, but got Ref
		//IL_040a: Expected I4, but got O
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_04e3: Invalid comparison between F4 and O
		//IL_0647: Expected O, but got F4
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj._003C_003E4__this = this;
		obj.cachedPos = (Vector3)0;
		_ = 0;
		float num2 = default(float);
		Vector3 ret = default(Vector3);
		if (hasTarget)
		{
			Vector3 vector = default(Vector3);
			obj.cachedPos = (Vector3)vector.x;
			_ = vector.z;
		}
		else
		{
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			float num = num2 * 2f;
			float num3 = num * 0.75f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v49 (UnityEngine.Bounds)+10]");
			float num4 = 0f * 2f;
			float num5 = num4 * 0.85f;
			float num6 = num2 * 2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v49 (UnityEngine.Bounds)+10]");
			float num7 = 0f * 2f;
			float num8 = (float)bounds.m_Center - num2;
			float num9 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v49 (UnityEngine.Bounds)+10]");
			float num10 = num9 - 0f;
			Rectangle rectangle = new Rectangle();
			float num11 = num6 - num3;
			float num12 = num7 - num5;
			rectangle._width = num3;
			float num13 = num11 * 0.5f;
			float num14 = num12 * 0.5f;
			float x = num13 + num8;
			rectangle._height = num5;
			float y = num14 + num10;
			rectangle._x = x;
			rectangle._y = y;
			GameManager core = GM.Core;
			if (!IsHoming)
			{
				ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
				Transform targetTransform = core._stage.PickRandomEnemyInRectBounds(rectangle, ref rng);
				_targetTransform = targetTransform;
			}
			else
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&ret), excludeDead: true);
				if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
				{
					Transform targetTransform2 = enemyController.transform;
					_targetTransform = targetTransform2;
				}
			}
			Transform targetTransform3 = _targetTransform;
			if ((object)_targetTransform == null || ((UnityEngine.Object)targetTransform3).m_CachedPtr == (IntPtr)0)
			{
				Transform targetTransform4 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				_targetTransform = targetTransform4;
			}
			Vector3 targetTransform5 = (Vector3)_targetTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rbx_v8 (UnityEngine.Vector3)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(targetTransform5);
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rbx_v8 (UnityEngine.Vector3)+10]");
			Transform.get_position_Injected((IntPtr)0, out ret);
			obj.cachedPos = ret;
			_ = 0;
			obj.cachedPos = (Vector3)num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (VampireSurvivors.Objects.Weapons.SantaJavelinWeapon+<>c__DisplayClass17_0)+20]");
			_ = 0;
		}
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Projectile projectile = FireOneProjectileTo((Vector2)num2, 0, (Vector3)(&ret));
		bool singleProjectile = SingleProjectile;
		Vector2 vector2 = (Vector2)num2;
		if (!singleProjectile)
		{
			float num15 = PAmount();
			bool flag = !(num2 > 1f);
			vector2 = (Vector2)num2;
			if (!flag)
			{
				ret = obj.cachedPos;
				Action<float> action = (Action<float>)1;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				bool flag2;
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj2 = action * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj2 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Projectile projectile2 = FireOneProjectileTo(playerPos, (int)action, (Vector3)(&ret));
					}
					else
					{
						_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass17_1();
						CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = obj;
						CS_0024_003C_003E8__locals7.localIndex = (int)action;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_0183: Expected O, but got I4
							//IL_0112: Expected O, but got I
							//IL_013d: Expected I, but got O
							//IL_00a8->IL014c: Incompatible stack heights: 1 vs 0
							//IL_00d7->IL014c: Incompatible stack heights: 1 vs 0
							//IL_00fc->IL014c: Incompatible stack heights: 1 vs 0
							//IL_0130->IL014c: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
							{
								GameObject gameObject = obj5._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj6 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass17_0 obj7 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null)
									{
										GameObject gameObject2 = (GameObject)(object)obj7._003C_003E4__this;
										if ((object)obj7._003C_003E4__this != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v7 (UnityEngine.GameObject)+58]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v7 (UnityEngine.GameObject)+58]");
												float2 position4 = ((ArcadeSprite)0).position;
												if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null)
												{
													nint num20 = (nint)gameObject2;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v264 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+5F8] (should have been resolved before IL gen)");
													return;
												}
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num16 = (float)action * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						float duration = num16 * 0.001f;
						Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					action = (Action<float>)(action + 1);
					flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<Action<float>, UIntPtr>(ref action);
					vector2 = (Vector2)action;
				}
				while (flag2);
			}
		}
		float num17 = base.PInterval();
		float num18 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num18 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num19 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			ResetFiringTimer();
		}
		object obj4 = default(object);
		if (obj4 == null)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		Vector3 vector3 = default(Vector3);
		((Vector3*)(nint)vector3)->x = (float)obj.cachedPos;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (VampireSurvivors.Objects.Weapons.SantaJavelinWeapon+<>c__DisplayClass17_0)+20]");
		((Vector3*)(nint)vector3)->z = 0f;
		return vector3;
	}

	protected unsafe void Fire_FireCounter(Vector3 cachedPos, bool skipTriggers = false)
	{
		//IL_00be: Expected I, but got O
		//IL_00c6: Expected I, but got O
		//IL_00d6: Expected O, but got I
		//IL_0156: Expected O, but got I4
		//IL_0112: Expected O, but got I
		//IL_029e: Expected O, but got Ref
		//IL_0148: Expected O, but got I4
		//IL_0382->IL02a3: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL0337: Incompatible stack heights: 1 vs 0
		Weapon weaponByType;
		object obj3;
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || (object)characterController._weaponsManager == null)
			{
				goto IL_02a3;
			}
			weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				nint num = (nint)typeof(SantaJavelinCounterWeapon);
				nint num2 = (nint)weaponByType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelinCounterWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelinCounterWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v53+FFFFFFF8+v580 @ rax_v38*8]");
					if (0 == (nint)typeof(SantaJavelinCounterWeapon))
					{
						obj3 = 1;
						goto IL_02f1;
					}
				}
				obj3 = 0;
				goto IL_02f1;
			}
		}
		goto IL_01f1;
		IL_02f1:
		bool flag = obj3 == null;
		Weapon counterSet = null;
		if (!flag)
		{
			counterSet = weaponByType;
		}
		_counterSet = (SantaJavelinCounterWeapon)counterSet;
		if ((object)_counterSet != null)
		{
			_counterSet.Cleanup();
			if ((object)_counterSet != null)
			{
				GameObject gameObject = _counterSet.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					goto IL_01f1;
				}
			}
		}
		goto IL_02a3;
		IL_02a3:
		throw new NullReferenceException();
		IL_01f1:
		SantaJavelinCounterWeapon counterSet2 = _counterSet;
		if ((object)_counterSet == null || ((UnityEngine.Object)counterSet2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_counterSet != null)
				{
					_counterSet.ForcedFire(hasTarget: true, (Vector3)(&ret), skipTriggers);
					return;
				}
			}
		}
		goto IL_02a3;
	}

	public unsafe virtual Projectile FireOneProjectileTo(Vector2 pos, int index, Vector3 target)
	{
		//IL_0047: Expected I, but got O
		//IL_0055: Expected I, but got O
		//IL_0065: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		//IL_0135: Expected O, but got Ref
		if (_projectilePool == null)
		{
			goto IL_019e;
		}
		float2 pos2 = default(float2);
		Projectile projectile = _projectilePool.SpawnAt(pos2, this, index);
		bool flag = (object)projectile == null;
		Projectile projectile2 = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(SantaJavelinProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SantaJavelinProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SantaJavelinProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v25+FFFFFFF8+v140 @ rax_v21*8]");
				if (0 == (nint)typeof(SantaJavelinProjectile))
				{
					obj3 = 1;
					goto IL_01d0;
				}
			}
			obj3 = 0;
			goto IL_01d0;
		}
		goto IL_01f7;
		IL_01d0:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_01f7;
		IL_01f7:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			object obj4 = default(object);
			((SantaJavelinProjectile)projectile2).SetTargetVec((Vector3)(&obj4));
			BaseBody body = projectile2.body;
			if (projectile2.body != null)
			{
				if (body._transform == null)
				{
					goto IL_019e;
				}
				body._transform.ForceFullReupdate();
			}
		}
		return projectile2;
		IL_019e:
		return (Projectile)(object)new NullReferenceException();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
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
}
