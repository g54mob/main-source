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

public class TP_Wind1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public Vector2 pos;

		public float __repeatInterval;

		public TP_Wind1_Weapon _003C_003E4__this;

		public bool __flip;

		public float __amount;
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public int invert;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_02e2: Invalid comparison between F4 and I4
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00ff: Expected I, but got O
			//IL_0107: Expected I, but got O
			//IL_0117: Expected O, but got I
			//IL_0197: Expected O, but got I4
			//IL_0153: Expected O, but got I
			//IL_0189: Expected O, but got I4
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			bool flag = false;
			bool flag2 = false;
			TP_Wind1_Projectile tP_Wind1_Projectile = default(TP_Wind1_Projectile);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			for (bool flag3 = false; obj.__amount > (float)(flag3 ? 1 : 0); obj = CS_0024_003C_003E8__locals1, flag = (byte)((flag ? 1u : 0u) + 1u) != 0, flag2 = (byte)((flag2 ? 1u : 0u) + 2u) != 0, flag3 = flag)
			{
				_003C_003Ec__DisplayClass17_2 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass17_2();
				CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 = this;
				_003C_003Ec__DisplayClass17_0 obj2 = CS_0024_003C_003E8__locals1;
				CS_0024_003C_003E8__locals11.__pos = obj2.pos;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v7 (VampireSurvivors.Objects.Weapons.TP_Wind1_Weapon+<>c__DisplayClass17_0)+14]");
				_ = 0;
				int localIndex = invert + (flag2 ? 1 : 0);
				CS_0024_003C_003E8__locals11.localIndex = localIndex;
				_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals1;
				object obj4 = flag * obj3.__repeatInterval;
				object obj7;
				if ((nint)obj4 <= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if ((object)tP_Wind1_Projectile == null)
					{
						continue;
					}
					nint num = (nint)typeof(TP_Wind1_Projectile);
					nint num2 = (nint)tP_Wind1_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+C8]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rcx_v20+FFFFFFF8+v513 @ rcx_v14*8]");
						if (0 == (nint)typeof(TP_Wind1_Projectile))
						{
							obj7 = 1;
							goto IL_02b3;
						}
					}
					obj7 = 0;
					goto IL_02b3;
				}
				TP_Wind1_Weapon tP_Wind1_Weapon = obj3._003C_003E4__this;
				Action onComplete = delegate
				{
					//IL_0344: Expected O, but got I4
					//IL_01ca: Expected I, but got O
					//IL_01d2: Expected I, but got O
					//IL_01e2: Expected O, but got I
					//IL_0262: Expected O, but got I4
					//IL_021e: Expected O, but got I
					//IL_0254: Expected O, but got I4
					//IL_00b3->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_00e2->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_0101->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_0123->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_0152->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_0174->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_0298->IL02e4: Incompatible stack heights: 1 vs 0
					//IL_02c7->IL02e4: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass17_1 obj9 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
					TP_Wind1_Projectile tP_Wind1_Projectile3;
					object obj16;
					if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
					{
						_003C_003Ec__DisplayClass17_0 obj10 = obj9.CS_0024_003C_003E8__locals1;
						if (obj9.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass17_1 obj12 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
								if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
								{
									_003C_003Ec__DisplayClass17_0 obj13 = obj12.CS_0024_003C_003E8__locals1;
									if (obj12.CS_0024_003C_003E8__locals1 != null && CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null && obj12.CS_0024_003C_003E8__locals1 != null)
									{
										TP_Wind1_Weapon tP_Wind1_Weapon2 = obj13._003C_003E4__this;
										if ((object)obj13._003C_003E4__this != null && (object)obj13._003C_003E4__this != null)
										{
											Vector2 pos = default(Vector2);
											tP_Wind1_Projectile3 = (TP_Wind1_Projectile)obj13._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals11.localIndex, tP_Wind1_Weapon2._targetTransform);
											if ((object)tP_Wind1_Projectile3 == null)
											{
												return;
											}
											nint num5 = (nint)typeof(TP_Wind1_Projectile);
											nint num6 = (nint)tP_Wind1_Projectile3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
											object obj14 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
											nint num7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
											if (num7 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+C8]");
												object obj15 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20+FFFFFFF8+v454 @ rcx_v16*8]");
												if (0 == (nint)typeof(TP_Wind1_Projectile))
												{
													obj16 = 1;
													goto IL_0361;
												}
											}
											obj16 = 0;
											goto IL_0361;
										}
									}
								}
							}
						}
					}
					goto IL_02e4;
					IL_0361:
					bool flag6 = obj16 == null;
					TP_Wind1_Projectile tP_Wind1_Projectile4 = null;
					if (!flag6)
					{
						tP_Wind1_Projectile4 = tP_Wind1_Projectile3;
					}
					if ((object)tP_Wind1_Projectile4 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass17_1 obj17 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2;
					if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals2 != null)
					{
						_003C_003Ec__DisplayClass17_0 obj18 = obj17.CS_0024_003C_003E8__locals1;
						if (obj17.CS_0024_003C_003E8__locals1 != null)
						{
							tP_Wind1_Projectile4.SetFlip(obj18.__flip);
							return;
						}
					}
					goto IL_02e4;
					IL_02e4:
					throw new NullReferenceException();
				};
				float num4 = (float)(flag ? 1 : 0) * obj3.__repeatInterval;
				float duration = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				tP_Wind1_Weapon._lastShotTimer = lastShotTimer;
				continue;
				IL_02b3:
				bool flag4 = obj7 == null;
				TP_Wind1_Projectile tP_Wind1_Projectile2 = null;
				if (!flag4)
				{
					tP_Wind1_Projectile2 = tP_Wind1_Projectile;
				}
				if ((object)tP_Wind1_Projectile2 != null)
				{
					_003C_003Ec__DisplayClass17_0 obj8 = CS_0024_003C_003E8__locals1;
					tP_Wind1_Projectile2.SetFlip(obj8.__flip);
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_2
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals2;

		internal void _003CFireProjectiles_003Eb__1()
		{
			//IL_0344: Expected O, but got I4
			//IL_01ca: Expected I, but got O
			//IL_01d2: Expected I, but got O
			//IL_01e2: Expected O, but got I
			//IL_0262: Expected O, but got I4
			//IL_021e: Expected O, but got I
			//IL_0254: Expected O, but got I4
			//IL_00b3->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_00e2->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_0101->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_0123->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_0152->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_0174->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_0298->IL02e4: Incompatible stack heights: 1 vs 0
			//IL_02c7->IL02e4: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass17_1 obj = CS_0024_003C_003E8__locals2;
			TP_Wind1_Projectile tP_Wind1_Projectile;
			object obj8;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass17_0 obj2 = obj.CS_0024_003C_003E8__locals1;
				if (obj.CS_0024_003C_003E8__locals1 != null && (object)obj2._003C_003E4__this != null)
				{
					GameObject gameObject = obj2._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj3 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass17_1 obj4 = CS_0024_003C_003E8__locals2;
						if (CS_0024_003C_003E8__locals2 != null)
						{
							_003C_003Ec__DisplayClass17_0 obj5 = obj4.CS_0024_003C_003E8__locals1;
							if (obj4.CS_0024_003C_003E8__locals1 != null && CS_0024_003C_003E8__locals2 != null && obj4.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Wind1_Weapon tP_Wind1_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null && (object)obj5._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									tP_Wind1_Projectile = (TP_Wind1_Projectile)obj5._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Wind1_Weapon._targetTransform);
									if ((object)tP_Wind1_Projectile == null)
									{
										return;
									}
									nint num = (nint)typeof(TP_Wind1_Projectile);
									nint num2 = (nint)tP_Wind1_Projectile;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
									if (num3 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+C8]");
										object obj7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20+FFFFFFF8+v454 @ rcx_v16*8]");
										if (0 == (nint)typeof(TP_Wind1_Projectile))
										{
											obj8 = 1;
											goto IL_0361;
										}
									}
									obj8 = 0;
									goto IL_0361;
								}
							}
						}
					}
				}
			}
			goto IL_02e4;
			IL_0361:
			bool flag2 = obj8 == null;
			TP_Wind1_Projectile tP_Wind1_Projectile2 = null;
			if (!flag2)
			{
				tP_Wind1_Projectile2 = tP_Wind1_Projectile;
			}
			if ((object)tP_Wind1_Projectile2 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass17_1 obj9 = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass17_0 obj10 = obj9.CS_0024_003C_003E8__locals1;
				if (obj9.CS_0024_003C_003E8__locals1 != null)
				{
					tP_Wind1_Projectile2.SetFlip(obj10.__flip);
					return;
				}
			}
			goto IL_02e4;
			IL_02e4:
			throw new NullReferenceException();
		}
	}

	private bool _003CCanFireNormally_003Ek__BackingField = true;

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_WIND1_COUNTER;

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

	public override float PSpeed()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		float num2 = default(float);
		bool flag = !(4f > num2);
		float num3 = 4f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num4 *= value;
			}
		}
		return num4;
	}

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Wind04");
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
		//IL_0043: Invalid comparison between O and F4
		//IL_01e9: Expected F4, but got O
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj.pos = pos;
		obj._003C_003E4__this = this;
		float playerFacing = PlayerFacing;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018747D736h\"");
		bool _flip;
		if ((object)pos == (object)1f)
		{
			_flip = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		}
		else
		{
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			_flip = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
		}
		obj.__flip = _flip;
		float num = base.PAmount();
		obj.__amount = (float)pos;
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		float _repeatInterval = (float)pos / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num3 = base.PSpeedRepeatInterval();
		obj.__repeatInterval = _repeatInterval;
		float hitBoxDelay2 = base.HitBoxDelay;
		int num4 = default(int);
		DisplayCursorVFX(num4, hitBoxDelay2);
		if (num4 <= 0)
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
			_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass17_1();
			CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = obj;
			bool isPrimaryWeapon = IsPrimaryWeapon;
			bool invert = !isPrimaryWeapon;
			CS_0024_003C_003E8__locals13.invert = (invert ? 1 : 0);
			float hitBoxDelay3 = base.HitBoxDelay;
			Action onComplete = delegate
			{
				//IL_02e2: Invalid comparison between F4 and I4
				//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ad: Expected O, but got Unknown
				//IL_00ff: Expected I, but got O
				//IL_0107: Expected I, but got O
				//IL_0117: Expected O, but got I
				//IL_0197: Expected O, but got I4
				//IL_0153: Expected O, but got I
				//IL_0189: Expected O, but got I4
				_003C_003Ec__DisplayClass17_0 obj2 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
				bool flag2 = false;
				bool flag3 = false;
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				TP_Wind1_Projectile tP_Wind1_Projectile = default(TP_Wind1_Projectile);
				for (bool flag4 = false; obj2.__amount > (float)(flag4 ? 1 : 0); obj2 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1, flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0, flag3 = (byte)((flag3 ? 1u : 0u) + 2u) != 0, flag4 = flag2)
				{
					_003C_003Ec__DisplayClass17_2 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass17_2();
					CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals13;
					_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
					CS_0024_003C_003E8__locals21.__pos = obj3.pos;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v7 (VampireSurvivors.Objects.Weapons.TP_Wind1_Weapon+<>c__DisplayClass17_0)+14]");
					_ = 0;
					int localIndex = CS_0024_003C_003E8__locals13.invert + (flag3 ? 1 : 0);
					CS_0024_003C_003E8__locals21.localIndex = localIndex;
					_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
					object obj5 = flag2 * obj4.__repeatInterval;
					if ((nint)obj5 > 0)
					{
						TP_Wind1_Weapon tP_Wind1_Weapon = obj4._003C_003E4__this;
						Action onComplete2 = delegate
						{
							//IL_0344: Expected O, but got I4
							//IL_01ca: Expected I, but got O
							//IL_01d2: Expected I, but got O
							//IL_01e2: Expected O, but got I
							//IL_0262: Expected O, but got I4
							//IL_021e: Expected O, but got I
							//IL_0254: Expected O, but got I4
							//IL_00b3->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_00e2->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_0101->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_0123->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_0152->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_0174->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_0298->IL02e4: Incompatible stack heights: 1 vs 0
							//IL_02c7->IL02e4: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass17_1 obj10 = CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2;
							TP_Wind1_Projectile tP_Wind1_Projectile3;
							object obj17;
							if (CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2 != null)
							{
								_003C_003Ec__DisplayClass17_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
								if (obj10.CS_0024_003C_003E8__locals1 != null && (object)obj11._003C_003E4__this != null)
								{
									GameObject gameObject = obj11._003C_003E4__this.gameObject;
									if ((object)gameObject != null)
									{
										bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
										object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
										if (obj12 == null)
										{
											return;
										}
										_003C_003Ec__DisplayClass17_1 obj13 = CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2;
										if (CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2 != null)
										{
											_003C_003Ec__DisplayClass17_0 obj14 = obj13.CS_0024_003C_003E8__locals1;
											if (obj13.CS_0024_003C_003E8__locals1 != null && CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2 != null && obj13.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Wind1_Weapon tP_Wind1_Weapon2 = obj14._003C_003E4__this;
												if ((object)obj14._003C_003E4__this != null && (object)obj14._003C_003E4__this != null)
												{
													Vector2 pos2 = default(Vector2);
													tP_Wind1_Projectile3 = (TP_Wind1_Projectile)obj14._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals21.localIndex, tP_Wind1_Weapon2._targetTransform);
													if ((object)tP_Wind1_Projectile3 == null)
													{
														return;
													}
													nint num11 = (nint)typeof(TP_Wind1_Projectile);
													nint num12 = (nint)tP_Wind1_Projectile3;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
													object obj15 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
													nint num13 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
													if (num13 >= 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+C8]");
														object obj16 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20+FFFFFFF8+v454 @ rcx_v16*8]");
														if (0 == (nint)typeof(TP_Wind1_Projectile))
														{
															obj17 = 1;
															goto IL_0361;
														}
													}
													obj17 = 0;
													goto IL_0361;
												}
											}
										}
									}
								}
							}
							goto IL_02e4;
							IL_0361:
							bool flag7 = obj17 == null;
							TP_Wind1_Projectile tP_Wind1_Projectile4 = null;
							if (!flag7)
							{
								tP_Wind1_Projectile4 = tP_Wind1_Projectile3;
							}
							if ((object)tP_Wind1_Projectile4 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass17_1 obj18 = CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2;
							if (CS_0024_003C_003E8__locals21.CS_0024_003C_003E8__locals2 != null)
							{
								_003C_003Ec__DisplayClass17_0 obj19 = obj18.CS_0024_003C_003E8__locals1;
								if (obj18.CS_0024_003C_003E8__locals1 != null)
								{
									tP_Wind1_Projectile4.SetFlip(obj19.__flip);
									return;
								}
							}
							goto IL_02e4;
							IL_02e4:
							throw new NullReferenceException();
						};
						float num7 = (float)(flag2 ? 1 : 0) * obj4.__repeatInterval;
						float duration2 = num7 * 0.001f;
						Timer lastShotTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
						tP_Wind1_Weapon._lastShotTimer = lastShotTimer;
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if ((object)tP_Wind1_Projectile == null)
					{
						continue;
					}
					nint num8 = (nint)typeof(TP_Wind1_Projectile);
					nint num9 = (nint)tP_Wind1_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+130]");
					object obj8;
					if (num10 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+C8]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rcx_v20+FFFFFFF8+v513 @ rcx_v14*8]");
						if (0 == (nint)typeof(TP_Wind1_Projectile))
						{
							obj8 = 1;
							goto IL_02b3;
						}
					}
					obj8 = 0;
					goto IL_02b3;
					IL_02b3:
					bool flag5 = obj8 == null;
					TP_Wind1_Projectile tP_Wind1_Projectile2 = null;
					if (!flag5)
					{
						tP_Wind1_Projectile2 = tP_Wind1_Projectile;
					}
					if ((object)tP_Wind1_Projectile2 != null)
					{
						_003C_003Ec__DisplayClass17_0 obj9 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
						tP_Wind1_Projectile2.SetFlip(obj9.__flip);
					}
				}
			};
			float num5 = (float)(flag ? 1 : 0) * hitBoxDelay3;
			float num6 = num5 + 1f;
			float duration = num6 * 0.001f;
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
