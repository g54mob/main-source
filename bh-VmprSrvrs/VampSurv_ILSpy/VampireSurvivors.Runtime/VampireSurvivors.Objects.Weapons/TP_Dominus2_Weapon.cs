using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Dominus2_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public float __unit;

		public float __firstX;

		public float __firstY;

		public float __repeatInterval;

		public TP_Dominus2_Weapon _003C_003E4__this;

		public float __amount;

		public Action _003C_003E9__0;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_01d0: Invalid comparison between F4 and I4
			//IL_0039: Expected O, but got I4
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_009d: Expected O, but got F4
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00eb: Expected O, but got I4
			//IL_01b1: Invalid comparison between F4 and I4
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass16_1();
				CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = this;
				object obj = (flag ? 1 : 0) + 1;
				object obj2 = obj * __unit;
				Vector2 _pos = (Vector2)(obj2 + __firstX);
				_ = __firstY;
				CS_0024_003C_003E8__locals13.__pos = _pos;
				float num = __firstX - (float)obj2;
				_ = __firstY;
				CS_0024_003C_003E8__locals13.localIndex = (flag2 ? 1 : 0);
				CS_0024_003C_003E8__locals13.__pos2 = (Vector2)num;
				object obj3 = flag * __repeatInterval;
				if ((nint)obj3 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					object obj4 = CS_0024_003C_003E8__locals13.localIndex + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Dominus2_Weapon tP_Dominus2_Weapon = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_020e: Expected O, but got I4
						//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass16_0 obj5 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
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
								_003C_003Ec__DisplayClass16_0 obj7 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Dominus2_Weapon tP_Dominus2_Weapon2 = obj7._003C_003E4__this;
									if ((object)obj7._003C_003E4__this != null && (object)obj7._003C_003E4__this != null)
									{
										Vector2 pos = default(Vector2);
										Projectile projectile = obj7._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals13.localIndex, tP_Dominus2_Weapon2._targetTransform);
										_003C_003Ec__DisplayClass16_0 obj8 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
										{
											TP_Dominus2_Weapon tP_Dominus2_Weapon3 = obj8._003C_003E4__this;
											if ((object)obj8._003C_003E4__this != null && (object)obj8._003C_003E4__this != null)
											{
												int index = CS_0024_003C_003E8__locals13.localIndex + 1;
												Projectile projectile2 = obj8._003C_003E4__this.FireOneProjectile(pos, index, tP_Dominus2_Weapon3._targetTransform);
												return;
											}
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num2 = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num2 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Dominus2_Weapon._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag2 = (byte)((flag2 ? 1u : 0u) + 2u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public Vector2 __pos;

		public int localIndex;

		public Vector2 __pos2;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_020e: Expected O, but got I4
			//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass16_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass16_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Dominus2_Weapon tP_Dominus2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Dominus2_Weapon._targetTransform);
							_003C_003Ec__DisplayClass16_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_Dominus2_Weapon tP_Dominus2_Weapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null && (object)obj4._003C_003E4__this != null)
								{
									int index = localIndex + 1;
									Projectile projectile2 = obj4._003C_003E4__this.FireOneProjectile(pos, index, tP_Dominus2_Weapon2._targetTransform);
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

	private bool _initialisedParticles;

	private BulletPool _centralProjectilePool;

	private Projectile _centralProjectilePrefab;

	private bool _003CInverted_003Ek__BackingField;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public bool Inverted
	{
		get
		{
			return _003CInverted_003Ek__BackingField;
		}
		set
		{
			_003CInverted_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		_003CInverted_003Ek__BackingField = false;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0055: Expected I, but got O
		//IL_00f8: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		BulletPool centralProjectilePool = new BulletPool(_centralProjectilePrefab);
		_centralProjectilePool = centralProjectilePool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_centralProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			Collider collider2 = physics2.add.overlap(_centralProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
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
		//IL_014f: Expected O, but got F4
		//IL_0123: Expected F4, but got I4
		if (!((Equipment)this)._003COwner_003Ek__BackingField.DrainWeaponsImmunity)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num3 = default(float);
			float num2 = characterController._currentHp / num3;
			float num4 = num2 * 4f;
			bool flag = !(1f < num4);
			float num5 = 1f;
			if (!flag)
			{
				num5 = num4;
			}
			float num6 = num5 + 1f;
			if (characterController2._currentHp > num6)
			{
				characterController2.TriggerGetDamagedByOwnWeapon(num5);
			}
		}
		FireProjectiles();
		object obj = UnityEngine.Random.value;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_DominusHatred, 200f, 3, 0f, volume, rate, detune, loop, 1f);
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireProjectiles()
	{
		//IL_006c: Expected F4, but got O
		//IL_010b: Expected F4, but got O
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals27._003C_003E4__this = this;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 float5 = default(float2);
		Projectile projectile = _centralProjectilePool.SpawnAt(float5, this);
		float num = base.PAmount();
		CS_0024_003C_003E8__locals27.__amount = (float)float5;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num3 = (float)float5 / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num4 = renderer.width * 0.5f;
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			CS_0024_003C_003E8__locals27.__firstX = (float)position3;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float num5 = CS_0024_003C_003E8__locals27.__amount + 1f;
				float num6 = renderer2.height * 0.65f;
				float num7 = default(float);
				float _firstY = num6 + num7;
				float _unit = num4 / num5;
				CS_0024_003C_003E8__locals27.__firstY = _firstY;
				CS_0024_003C_003E8__locals27.__unit = _unit;
				float num8 = base.PSpeedRepeatInterval();
				CS_0024_003C_003E8__locals27.__repeatInterval = num5;
				object obj = default(object);
				if ((nint)obj <= 0)
				{
					return;
				}
				bool flag = false;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					float num9 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num7);
					Action onComplete = CS_0024_003C_003E8__locals27._003C_003E9__0;
					if (CS_0024_003C_003E8__locals27._003C_003E9__0 == null)
					{
						onComplete = (CS_0024_003C_003E8__locals27._003C_003E9__0 = delegate
						{
							//IL_01d0: Invalid comparison between F4 and I4
							//IL_0039: Expected O, but got I4
							//IL_0043: Unknown result type (might be due to invalid IL or missing references)
							//IL_0048: Expected O, but got Unknown
							//IL_0052: Unknown result type (might be due to invalid IL or missing references)
							//IL_0057: Expected O, but got Unknown
							//IL_009d: Expected O, but got F4
							//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
							//IL_00ac: Expected O, but got Unknown
							//IL_00eb: Expected O, but got I4
							//IL_01b1: Invalid comparison between F4 and I4
							if (CS_0024_003C_003E8__locals27.__amount > 0f)
							{
								bool flag2 = false;
								bool flag3 = false;
								bool useRealTime2 = default(bool);
								MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
								int repeat2 = default(int);
								TimerType type2 = default(TimerType);
								do
								{
									_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals35 = new _003C_003Ec__DisplayClass16_1();
									CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals27;
									object obj2 = (flag2 ? 1 : 0) + 1;
									object obj3 = obj2 * CS_0024_003C_003E8__locals27.__unit;
									Vector2 _pos = (Vector2)(obj3 + CS_0024_003C_003E8__locals27.__firstX);
									_ = CS_0024_003C_003E8__locals27.__firstY;
									CS_0024_003C_003E8__locals35.__pos = _pos;
									float num12 = CS_0024_003C_003E8__locals27.__firstX - (float)obj3;
									_ = CS_0024_003C_003E8__locals27.__firstY;
									CS_0024_003C_003E8__locals35.localIndex = (flag3 ? 1 : 0);
									CS_0024_003C_003E8__locals35.__pos2 = (Vector2)num12;
									object obj4 = flag2 * CS_0024_003C_003E8__locals27.__repeatInterval;
									if ((nint)obj4 <= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
										object obj5 = CS_0024_003C_003E8__locals35.localIndex + 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
									}
									else
									{
										TP_Dominus2_Weapon tP_Dominus2_Weapon = CS_0024_003C_003E8__locals27._003C_003E4__this;
										Action onComplete2 = delegate
										{
											//IL_020e: Expected O, but got I4
											//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
											//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
											//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
											//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
											//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
											//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
											_003C_003Ec__DisplayClass16_0 obj6 = CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1 != null && (object)obj6._003C_003E4__this != null)
											{
												GameObject gameObject = obj6._003C_003E4__this.gameObject;
												if ((object)gameObject != null)
												{
													bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
													object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
													if (obj7 == null)
													{
														return;
													}
													_003C_003Ec__DisplayClass16_0 obj8 = CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1 != null)
													{
														TP_Dominus2_Weapon tP_Dominus2_Weapon2 = obj8._003C_003E4__this;
														if ((object)obj8._003C_003E4__this != null && (object)obj8._003C_003E4__this != null)
														{
															Vector2 pos = default(Vector2);
															Projectile projectile2 = obj8._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals35.localIndex, tP_Dominus2_Weapon2._targetTransform);
															_003C_003Ec__DisplayClass16_0 obj9 = CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1;
															if (CS_0024_003C_003E8__locals35.CS_0024_003C_003E8__locals1 != null)
															{
																TP_Dominus2_Weapon tP_Dominus2_Weapon3 = obj9._003C_003E4__this;
																if ((object)obj9._003C_003E4__this != null && (object)obj9._003C_003E4__this != null)
																{
																	int index = CS_0024_003C_003E8__locals35.localIndex + 1;
																	Projectile projectile3 = obj9._003C_003E4__this.FireOneProjectile(pos, index, tP_Dominus2_Weapon3._targetTransform);
																	return;
																}
															}
														}
													}
												}
											}
											throw new NullReferenceException();
										};
										float num13 = (float)(flag2 ? 1 : 0) * CS_0024_003C_003E8__locals27.__repeatInterval;
										float duration2 = num13 * 0.001f;
										Timer lastShotTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
										tP_Dominus2_Weapon._lastShotTimer = lastShotTimer;
									}
									flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
									flag3 = (byte)((flag3 ? 1u : 0u) + 2u) != 0;
								}
								while (CS_0024_003C_003E8__locals27.__amount > (float)(flag2 ? 1 : 0));
							}
						});
					}
					float num10 = (float)(flag ? 1 : 0) * num9;
					float num11 = num10 + 200f;
					float duration = num11 * 0.001f;
					Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				}
				while ((flag ? 1 : 0) < (nint)obj);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0018: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		_isVisible = visible;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		_centralProjectilePool.Cleanup();
		base.Cleanup();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
	}
}
