using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Earth1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public float __repeatInterval;

		public TP_Earth1_Weapon _003C_003E4__this;

		public Vector2 pos;

		public float __amount;

		public Action _003C_003E9__0;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_016b: Invalid comparison between F4 and I4
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0086: Expected O, but got I4
			//IL_014c: Invalid comparison between F4 and I4
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
				_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass17_1();
				CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 = this;
				CS_0024_003C_003E8__locals11.localIndex = (flag2 ? 1 : 0);
				object obj = flag * __repeatInterval;
				if ((nint)obj <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					object obj2 = CS_0024_003C_003E8__locals11.localIndex + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Earth1_Weapon tP_Earth1_Weapon = _003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_020e: Expected O, but got I4
						//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
						{
							GameObject gameObject = obj3._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Earth1_Weapon tP_Earth1_Weapon2 = obj5._003C_003E4__this;
									if ((object)obj5._003C_003E4__this != null && (object)obj5._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals11.localIndex, tP_Earth1_Weapon2._targetTransform);
										_003C_003Ec__DisplayClass17_0 obj6 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
										{
											TP_Earth1_Weapon tP_Earth1_Weapon3 = obj6._003C_003E4__this;
											if ((object)obj6._003C_003E4__this != null && (object)obj6._003C_003E4__this != null)
											{
												int index = CS_0024_003C_003E8__locals11.localIndex + 1;
												Projectile projectile2 = obj6._003C_003E4__this.FireOneProjectile(vector, index, tP_Earth1_Weapon3._targetTransform);
												return;
											}
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Earth1_Weapon._lastShotTimer = lastShotTimer;
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag2 = (byte)((flag2 ? 1u : 0u) + 2u) != 0;
			}
			while (__amount > (float)(flag ? 1 : 0));
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_020e: Expected O, but got I4
			//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
			//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
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
						TP_Earth1_Weapon tP_Earth1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Earth1_Weapon._targetTransform);
							_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_Earth1_Weapon tP_Earth1_Weapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null && (object)obj4._003C_003E4__this != null)
								{
									int index = localIndex + 1;
									Projectile projectile2 = obj4._003C_003E4__this.FireOneProjectile(pos, index, tP_Earth1_Weapon2._targetTransform);
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

	private bool _003CCanFireNormally_003Ek__BackingField = true;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private float _topBarHeight = 0.2f;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_EARTH1_COUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual float PlayerFacing => 1f;

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

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Rock13");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(2);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.7f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
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
			if (IsPrimaryWeapon && _003CCanFireNormally_003Ek__BackingField)
			{
				base.Fire();
			}
		}
		if (IsPrimaryWeapon)
		{
			staticTotalTime = base._003CTotalTime_003Ek__BackingField;
		}
		float num3 = base._003CTotalTime_003Ek__BackingField * 0.85f;
		float num4 = num3 / deltaTime;
		float alpha = num4 + 0.15f;
		PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
		float playerFacing = PlayerFacing;
		if (((Equipment)this)._003COwner_003Ek__BackingField.flipX)
		{
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserSprite phaserSprite2 = _cursor.setPosition(position);
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
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
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Invalid comparison between O and F4
		//IL_0087: Expected F4, but got O
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
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
		if (IsPrimaryWeapon)
		{
			Fire_FireCounter(skipTriggers);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_003d: Expected F4, but got O
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		CS_0024_003C_003E8__locals17.pos = pos;
		float num = base.PAmount();
		CS_0024_003C_003E8__locals17.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float _repeatInterval = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num3 = base.PSpeedRepeatInterval();
		CS_0024_003C_003E8__locals17.__repeatInterval = _repeatInterval;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num4 = default(int);
		DisplayCursorVFX(num4, hitBoxDelay2);
		if (num4 <= 0)
		{
			return;
		}
		bool flag = false;
		float num6 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num5 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num6);
			Action onComplete = CS_0024_003C_003E8__locals17._003C_003E9__0;
			if (CS_0024_003C_003E8__locals17._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals17._003C_003E9__0 = delegate
				{
					//IL_016b: Invalid comparison between F4 and I4
					//IL_0042: Unknown result type (might be due to invalid IL or missing references)
					//IL_0047: Expected O, but got Unknown
					//IL_0086: Expected O, but got I4
					//IL_014c: Invalid comparison between F4 and I4
					if (CS_0024_003C_003E8__locals17.__amount > 0f)
					{
						bool flag2 = false;
						bool flag3 = false;
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						do
						{
							_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass17_1();
							CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals17;
							CS_0024_003C_003E8__locals25.localIndex = (flag3 ? 1 : 0);
							object obj = flag2 * CS_0024_003C_003E8__locals17.__repeatInterval;
							if ((nint)obj <= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
								object obj2 = CS_0024_003C_003E8__locals25.localIndex + 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							}
							else
							{
								TP_Earth1_Weapon tP_Earth1_Weapon = CS_0024_003C_003E8__locals17._003C_003E4__this;
								Action onComplete2 = delegate
								{
									//IL_020e: Expected O, but got I4
									//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
									{
										GameObject gameObject = obj3._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj4 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Earth1_Weapon tP_Earth1_Weapon2 = obj5._003C_003E4__this;
												if ((object)obj5._003C_003E4__this != null && (object)obj5._003C_003E4__this != null)
												{
													Vector2 pos2 = default(Vector2);
													Projectile projectile = obj5._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals25.localIndex, tP_Earth1_Weapon2._targetTransform);
													_003C_003Ec__DisplayClass17_0 obj6 = CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1 != null)
													{
														TP_Earth1_Weapon tP_Earth1_Weapon3 = obj6._003C_003E4__this;
														if ((object)obj6._003C_003E4__this != null && (object)obj6._003C_003E4__this != null)
														{
															int index = CS_0024_003C_003E8__locals25.localIndex + 1;
															Projectile projectile2 = obj6._003C_003E4__this.FireOneProjectile(pos2, index, tP_Earth1_Weapon3._targetTransform);
															return;
														}
													}
												}
											}
										}
									}
									throw new NullReferenceException();
								};
								float num9 = (float)(flag2 ? 1 : 0) * CS_0024_003C_003E8__locals17.__repeatInterval;
								float duration2 = num9 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								tP_Earth1_Weapon._lastShotTimer = lastShotTimer;
							}
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							flag3 = (byte)((flag3 ? 1u : 0u) + 2u) != 0;
						}
						while (CS_0024_003C_003E8__locals17.__amount > (float)(flag2 ? 1 : 0));
					}
				});
			}
			float num7 = (float)(flag ? 1 : 0) * num5;
			float num8 = num7 + 1f;
			float duration = num8 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < num4);
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				_counterWeapon = weaponByType;
				_counterWeapon.Cleanup();
				GameObject gameObject = _counterWeapon.gameObject;
				gameObject.SetActive(value: true);
			}
		}
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire(skipTriggers);
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
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 3;
			}
		}
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
			while (((Equipment)weapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				bool flag = weapon.LevelUp(skipFire: true);
			}
			GM.Core.SetSeenWeapon(_counterWeaponType);
		}
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0112: Expected O, but got Ref
		//IL_0169->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0113: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
			if ((object)pool != null)
			{
				SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
				if ((object)_cursor != null)
				{
					Transform transform = _cursor.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor != null)
						{
							Transform transform2 = _cursor.transform;
							if ((object)transform2 != null)
							{
								Vector3 localEulerAngles = transform2.localEulerAngles;
								if ((object)objectComponent != null)
								{
									object obj = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj), angle, texture, frame, flip);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
	}
}
