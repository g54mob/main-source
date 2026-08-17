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
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Evil1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public TP_Evil1_Weapon _003C_003E4__this;

		public Vector2 pos;

		public float direction;
	}

	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_01e4: Expected O, but got I4
			//IL_0125: Expected I, but got O
			//IL_017e: Expected O, but got I4
			//IL_0084->IL0184: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL0184: Incompatible stack heights: 1 vs 0
			//IL_00d5->IL0184: Incompatible stack heights: 1 vs 0
			//IL_0153->IL0184: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass22_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Evil1_Weapon tP_Evil1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 vector = default(Vector2);
							ArcadeSprite arcadeSprite = obj3._003C_003E4__this.FireOneProjectile(vector, localIndex, tP_Evil1_Weapon._targetTransform);
							if ((object)arcadeSprite == null)
							{
								return;
							}
							nint num = (nint)arcadeSprite;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v398 @ rdx_v10 (Il2CppClass<ArcadeSprite>)+2D8] (should have been resolved before IL gen)");
							_003C_003Ec__DisplayClass22_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								float xVel = (float)vector * obj4.direction;
								arcadeSprite.setVelocity(xVel, (float?)(object)1);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private bool _003CCanFireNormally_003Ek__BackingField = true;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private bool _lockCursor;

	private EnemyController _lockOnTarget;

	private Projectile _skullPrefab;

	private BulletPool _skullPool;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_EVIL1_COUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual bool IsPrimaryWeapon => true;

	public bool CanFireNormally
	{
		get
		{
			return _003CCanFireNormally_003Ek__BackingField;
		}
		set
		{
			_003CCanFireNormally_003Ek__BackingField = value;
		}
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCurse();
			float num2 = default(float);
			bool flag = !(1f < num2);
			float num3 = 1f;
			if (!flag)
			{
				num3 = num2;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num3 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num2;
					return num2 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Evil02");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
		BulletPool skullPool = new BulletPool(_skullPrefab);
		_skullPool = skullPool;
		BulletPool skullPool2 = _skullPool;
		skullPool2.UpperLimit = 100;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnSkullOverlapsEnemy;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_skullPool, core.Enemies, collideCallback, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		_explosionType = WeaponType.RAYEXPLOSION;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public override void InternalUpdate()
	{
		//IL_00b6: Expected I, but got O
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon && _003CCanFireNormally_003Ek__BackingField)
			{
				base.Fire();
			}
		}
		if (IsPrimaryWeapon)
		{
			staticTotalTime = base._003CTotalTime_003Ek__BackingField;
		}
		float num3 = base._003CTotalTime_003Ek__BackingField * 0.75f;
		float num4 = num3 / deltaTime;
		float alpha = num4 + 0.25f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		nint num5 = (nint)this;
		if (!IsPrimaryWeapon)
		{
			return;
		}
		PhaserSprite cursor;
		float2 position2;
		if (_lockCursor)
		{
			ArcadeSprite lockOnTarget = _lockOnTarget;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v38 (ArcadeSprite)+260]");
			if ((nint)0 == 0)
			{
				cursor = _cursor;
				float2 position = lockOnTarget.position;
				position2 = position;
				goto IL_028f;
			}
			_lockCursor = false;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		cursor = _cursor;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float5 = default(float2);
		position2 = float5;
		goto IL_028f;
		IL_028f:
		PhaserSprite phaserSprite2 = cursor.setPosition(position2);
		if (_hasCounterSet)
		{
			float2 position5 = _cursor.position;
			_counterWeapon.OnMirrorData(float5);
		}
	}

	public override void OnMirrorData(Vector2 position)
	{
		//IL_00ba->IL0069: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_cursor != null)
				{
					float2 position2 = default(float2);
					PhaserSprite phaserSprite = _cursor.setPosition(position2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected float CalcRadAngle(float x1, float y1, float x2, float y2)
	{
		float num = x2 - x1;
		object obj = default(object);
		float result = (float)obj - y1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		return result;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		_lockCursor = false;
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (IsPrimaryWeapon && _hasCounterSet)
		{
			Weapon counterWeapon = _counterWeapon;
			if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
			{
				_counterWeapon.Fire(skipTriggers);
			}
		}
	}

	public void FireSkull(Vector2 pos)
	{
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
	}

	public void FireProjectiles(Vector2 pos, float direction)
	{
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_0223: Invalid comparison between F4 and I4
		//IL_009c: Expected I, but got O
		//IL_00cc: Expected O, but got I4
		_003C_003Ec__DisplayClass22_0 obj = new _003C_003Ec__DisplayClass22_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		obj.direction = direction;
		float num = base.PAmount();
		float num2 = base.PArea();
		float num3 = base.PSpeed();
		float num4 = (float)pos * 160f;
		object obj2 = pos * GameManager.ProjectileSpeed;
		float num5 = num4 / (float)obj2;
		if ((nint)pos <= 0)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		object obj3 = default(object);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool flag3;
		do
		{
			float num6 = (float)(flag2 ? 1 : 0) * num5;
			if (!(num6 > 0f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if ((object)arcadeSprite != null)
				{
					nint num7 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v477 @ rdx_v15 (Il2CppClass<ArcadeSprite>)+2D8] (should have been resolved before IL gen)");
					float xVel = (float)obj3 * obj.direction;
					arcadeSprite.setVelocity(xVel, (float?)(object)1);
				}
			}
			else
			{
				_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass22_1();
				CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals9.localIndex = (flag ? 1 : 0);
				Action onComplete = delegate
				{
					//IL_01e4: Expected O, but got I4
					//IL_0125: Expected I, but got O
					//IL_017e: Expected O, but got I4
					//IL_0084->IL0184: Incompatible stack heights: 1 vs 0
					//IL_00b3->IL0184: Incompatible stack heights: 1 vs 0
					//IL_00d5->IL0184: Incompatible stack heights: 1 vs 0
					//IL_0153->IL0184: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass22_0 obj4 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
					{
						GameObject gameObject = obj4._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj5 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass22_0 obj6 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Evil1_Weapon tP_Evil1_Weapon = obj6._003C_003E4__this;
								if ((object)obj6._003C_003E4__this != null && (object)obj6._003C_003E4__this != null)
								{
									Vector2 vector = default(Vector2);
									ArcadeSprite arcadeSprite2 = obj6._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals9.localIndex, tP_Evil1_Weapon._targetTransform);
									if ((object)arcadeSprite2 == null)
									{
										return;
									}
									nint num9 = (nint)arcadeSprite2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v398 @ rdx_v10 (Il2CppClass<ArcadeSprite>)+2D8] (should have been resolved before IL gen)");
									_003C_003Ec__DisplayClass22_0 obj7 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
									{
										float xVel2 = (float)vector * obj7.direction;
										arcadeSprite2.setVelocity(xVel2, (float?)(object)1);
										return;
									}
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num8 = (float)(flag2 ? 1 : 0) * num5;
				float duration = num8 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag3 = (nint)pos > (flag ? 1 : 0);
			flag2 = flag;
		}
		while (flag3);
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		if (_hasCounterSet)
		{
			Weapon counterWeapon = _counterWeapon;
			if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
			{
				_counterWeapon.Fire(skipTriggers);
			}
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

	public override void CheckArcanas()
	{
		//IL_0460->IL0364: Incompatible stack heights: 1 vs 0
		//IL_049b->IL03c2: Incompatible stack heights: 2 vs 0
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		if ((object)_gameMan != null)
		{
			ArcanaManager arcanaManager = gameMan._arcanaManager;
			if (gameMan._arcanaManager != null)
			{
				List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
				if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							_explodeOnExpire = true;
						}
					}
					if (!IsPrimaryWeapon)
					{
						return;
					}
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						ArcanaManager arcanaManager2 = core._arcanaManager;
						if (core._arcanaManager != null)
						{
							List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
							if (arcanaManager2._003CActiveArcanas_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj2 = default(object);
								if ((nint)obj2 <= -1)
								{
									return;
								}
								VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController._weaponsManager != null)
								{
									Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
									if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
									{
										return;
									}
									GameManager core2 = GM.Core;
									if ((object)GM.Core != null && core2._weaponsFacade != null)
									{
										bool allowDuplicates = default(bool);
										Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
										if ((object)weapon != null)
										{
											while (((Equipment)weapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
											{
												bool flag = weapon.LevelUp(skipFire: true);
											}
											if ((object)GM.Core != null)
											{
												GM.Core.SetSeenWeapon(_counterWeaponType);
												_hasCounterSet = true;
												if ((object)_counterWeapon != null)
												{
													_counterWeapon.Cleanup();
													TP_Evil1_Weapon counterWeapon = (TP_Evil1_Weapon)_counterWeapon;
													if ((object)_counterWeapon != null)
													{
														bool flag2 = ((UnityEngine.Object)counterWeapon).m_CachedPtr == (IntPtr)0;
														IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)counterWeapon).m_CachedPtr);
														GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
														if ((object)gameObject != null)
														{
															bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
															GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
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
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected bool OnSkullOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0178: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0195;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.SecondaryCursePPower();
									WeaponData currentWeaponData = _currentWeaponData;
									object obj = default(object);
									float num2 = (float)obj + (float)obj;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_0195;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0195:
		return false;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
	}
}
