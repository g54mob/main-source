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

public class TP_Ice1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public float __area;

		public Vector2 pos;

		public float __repeatInterval;

		public TP_Ice1_Weapon _003C_003E4__this;

		public float __amount;

		public Action _003C_003E9__0;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0210: Invalid comparison between F4 and I4
			//IL_0042: Expected O, but got I
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_01c6: Expected I, but got O
			//IL_0119: Expected O, but got I4
			//IL_0123: Expected I, but got O
			//IL_01f1: Invalid comparison between F4 and I4
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			nint num = default(nint);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass16_1();
				CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1 = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
				object obj = num + (flag ? 1 : 0);
				object obj2 = obj >> 2;
				object obj3 = obj2 >> 31;
				object obj4 = obj2 + obj3;
				object obj5 = obj4 * 7;
				object obj6 = flag - obj5;
				object obj7 = obj6 * __area;
				Vector2 _pos = (Vector2)(obj7 + (object)pos);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Ice1_Weapon+<>c__DisplayClass16_0)+18]");
				_ = 0;
				CS_0024_003C_003E8__locals12.localIndex = (flag2 ? 1 : 0);
				CS_0024_003C_003E8__locals12.__pos = _pos;
				object obj8 = flag * __repeatInterval;
				if ((nint)obj8 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					object obj9 = CS_0024_003C_003E8__locals12.localIndex + 1;
					num = (nint)_003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					TP_Ice1_Weapon tP_Ice1_Weapon = _003C_003E4__this;
					Action action = delegate
					{
						//IL_020e: Expected O, but got I4
						//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
						//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass16_0 obj10 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass16_0 obj12 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Ice1_Weapon tP_Ice1_Weapon2 = obj12._003C_003E4__this;
									if ((object)obj12._003C_003E4__this != null && (object)obj12._003C_003E4__this != null)
									{
										Vector2 vector = default(Vector2);
										Projectile projectile = obj12._003C_003E4__this.FireOneProjectile(vector, CS_0024_003C_003E8__locals12.localIndex, tP_Ice1_Weapon2._targetTransform);
										_003C_003Ec__DisplayClass16_0 obj13 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1 != null)
										{
											TP_Ice1_Weapon tP_Ice1_Weapon3 = obj13._003C_003E4__this;
											if ((object)obj13._003C_003E4__this != null && (object)obj13._003C_003E4__this != null)
											{
												int index = CS_0024_003C_003E8__locals12.localIndex + 1;
												Projectile projectile2 = obj13._003C_003E4__this.FireOneProjectile(vector, index, tP_Ice1_Weapon3._targetTransform);
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
					Timer lastShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					tP_Ice1_Weapon._lastShotTimer = lastShotTimer;
					num = (nint)action;
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
						TP_Ice1_Weapon tP_Ice1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Ice1_Weapon._targetTransform);
							_003C_003Ec__DisplayClass16_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_Ice1_Weapon tP_Ice1_Weapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null && (object)obj4._003C_003E4__this != null)
								{
									int index = localIndex + 1;
									Projectile projectile2 = obj4._003C_003E4__this.FireOneProjectile(pos, index, tP_Ice1_Weapon2._targetTransform);
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

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_ICE1_COUNTER;

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
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Ice07");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
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
		//IL_025b: Invalid comparison between I4 and F4
		//IL_037c->IL029e: Incompatible stack heights: 1 vs 0
		//IL_0196->IL029e: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL029e: Incompatible stack heights: 1 vs 0
		//IL_0428->IL029e: Incompatible stack heights: 2 vs 0
		//IL_03df->IL029e: Incompatible stack heights: 2 vs 0
		//IL_01fd->IL029e: Incompatible stack heights: 2 vs 0
		//IL_022f->IL029e: Incompatible stack heights: 2 vs 0
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
		bool flipX2 = default(bool);
		if ((object)_cursor != null)
		{
			float num3 = base._003CTotalTime_003Ek__BackingField * 0.85f;
			float num4 = num3 / deltaTime;
			float alpha = num4 + 0.15f;
			PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
				ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							ArcadeSprite arcadeSprite2 = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite2._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if (flipX)
										{
											goto IL_03c5;
										}
										float playerFacing = PlayerFacing;
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
										{
											float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
											if ((object)_cursor != null)
											{
												PhaserSprite phaserSprite2 = _cursor.setPosition(position);
												if ((object)_cursor != null)
												{
													float2 localPosition = default(float2);
													PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
													float playerFacing2 = PlayerFacing;
													bool flag3 = 0f > -1f;
													flipX2 = flipX;
													if (!flag3)
													{
														flipX2 = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
													}
													goto IL_03c5;
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
		goto IL_029e;
		IL_029e:
		throw new NullReferenceException();
		IL_03c5:
		if ((object)_cursor != null)
		{
			PhaserSprite phaserSprite4 = _cursor.setFlipX(flipX2);
			return;
		}
		goto IL_029e;
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
		//IL_00e4: Expected O, but got I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals23.pos = pos;
		CS_0024_003C_003E8__locals23._003C_003E4__this = this;
		float num = base.PAmount();
		CS_0024_003C_003E8__locals23.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float num3 = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num4 = renderer.width * 0.5f;
		float num5 = (CS_0024_003C_003E8__locals23.__area = num4 / 7f);
		float playerFacing = PlayerFacing;
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		object obj = (flipX ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		float num6 = (float)obj3 * num3;
		float _area = num6 * num5;
		CS_0024_003C_003E8__locals23.__area = _area;
		float num7 = base.PSpeedRepeatInterval();
		CS_0024_003C_003E8__locals23.__repeatInterval = num3;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num8 = default(int);
		DisplayCursorVFX(num8, hitBoxDelay2);
		if (num8 <= 0)
		{
			return;
		}
		bool flag = false;
		float num10 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num9 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num10);
			Action onComplete = CS_0024_003C_003E8__locals23._003C_003E9__0;
			if (CS_0024_003C_003E8__locals23._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals23._003C_003E9__0 = delegate
				{
					//IL_0210: Invalid comparison between F4 and I4
					//IL_0042: Expected O, but got I
					//IL_0074: Unknown result type (might be due to invalid IL or missing references)
					//IL_0079: Expected O, but got Unknown
					//IL_0081: Unknown result type (might be due to invalid IL or missing references)
					//IL_0086: Expected O, but got Unknown
					//IL_0090: Unknown result type (might be due to invalid IL or missing references)
					//IL_0095: Expected O, but got Unknown
					//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
					//IL_00da: Expected O, but got Unknown
					//IL_01c6: Expected I, but got O
					//IL_0119: Expected O, but got I4
					//IL_0123: Expected I, but got O
					//IL_01f1: Invalid comparison between F4 and I4
					if (CS_0024_003C_003E8__locals23.__amount > 0f)
					{
						bool flag2 = false;
						bool flag3 = false;
						nint num13 = default(nint);
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						do
						{
							_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals31 = new _003C_003Ec__DisplayClass16_1();
							CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals23;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
							object obj4 = num13 + (flag2 ? 1 : 0);
							object obj5 = obj4 >> 2;
							object obj6 = obj5 >> 31;
							object obj7 = obj5 + obj6;
							object obj8 = obj7 * 7;
							object obj9 = flag2 - obj8;
							object obj10 = obj9 * CS_0024_003C_003E8__locals23.__area;
							Vector2 _pos = (Vector2)(obj10 + (object)CS_0024_003C_003E8__locals23.pos);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Ice1_Weapon+<>c__DisplayClass16_0)+18]");
							_ = 0;
							CS_0024_003C_003E8__locals31.localIndex = (flag3 ? 1 : 0);
							CS_0024_003C_003E8__locals31.__pos = _pos;
							object obj11 = flag2 * CS_0024_003C_003E8__locals23.__repeatInterval;
							if ((nint)obj11 <= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
								object obj12 = CS_0024_003C_003E8__locals31.localIndex + 1;
								num13 = (nint)CS_0024_003C_003E8__locals23._003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							}
							else
							{
								TP_Ice1_Weapon tP_Ice1_Weapon = CS_0024_003C_003E8__locals23._003C_003E4__this;
								Action action = delegate
								{
									//IL_020e: Expected O, but got I4
									//IL_00a8->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_00d7->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_00f9->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_0148->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_0177->IL01d7: Incompatible stack heights: 1 vs 0
									//IL_0199->IL01d7: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass16_0 obj13 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null && (object)obj13._003C_003E4__this != null)
									{
										GameObject gameObject = obj13._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj14 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj14 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass16_0 obj15 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Ice1_Weapon tP_Ice1_Weapon2 = obj15._003C_003E4__this;
												if ((object)obj15._003C_003E4__this != null && (object)obj15._003C_003E4__this != null)
												{
													Vector2 pos2 = default(Vector2);
													Projectile projectile = obj15._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals31.localIndex, tP_Ice1_Weapon2._targetTransform);
													_003C_003Ec__DisplayClass16_0 obj16 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
													{
														TP_Ice1_Weapon tP_Ice1_Weapon3 = obj16._003C_003E4__this;
														if ((object)obj16._003C_003E4__this != null && (object)obj16._003C_003E4__this != null)
														{
															int index = CS_0024_003C_003E8__locals31.localIndex + 1;
															Projectile projectile2 = obj16._003C_003E4__this.FireOneProjectile(pos2, index, tP_Ice1_Weapon3._targetTransform);
															return;
														}
													}
												}
											}
										}
									}
									throw new NullReferenceException();
								};
								float num14 = (float)(flag2 ? 1 : 0) * CS_0024_003C_003E8__locals23.__repeatInterval;
								float duration2 = num14 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration2, action, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								tP_Ice1_Weapon._lastShotTimer = lastShotTimer;
								num13 = (nint)action;
							}
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							flag3 = (byte)((flag3 ? 1u : 0u) + 2u) != 0;
						}
						while (CS_0024_003C_003E8__locals23.__amount > (float)(flag2 ? 1 : 0));
					}
				});
			}
			float num11 = (float)(flag ? 1 : 0) * num9;
			float num12 = num11 + 1f;
			float duration = num12 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < num8);
	}

	public void Fire_FireCounter(bool skipTriggers = false)
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
				base._003CFreezeChance_003Ek__BackingField = 0.1f;
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
		//IL_00e3: Invalid comparison between O and F4
		//IL_0185: Expected O, but got Ref
		//IL_01dc->IL0186: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0186: Incompatible stack heights: 1 vs 0
		//IL_0147->IL0186: Incompatible stack heights: 1 vs 0
		//IL_0114->IL0186: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL0186: Incompatible stack heights: 1 vs 0
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
								float playerFacing = PlayerFacing;
								object obj = default(object);
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-1f)))
								{
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
									{
										goto IL_0186;
									}
									bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
								}
								else
								{
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
									{
										goto IL_0186;
									}
									bool flipX2 = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
								}
								if ((object)objectComponent != null)
								{
									object obj2 = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj2), angle, texture, frame, flip);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0186;
		IL_0186:
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
	}
}
