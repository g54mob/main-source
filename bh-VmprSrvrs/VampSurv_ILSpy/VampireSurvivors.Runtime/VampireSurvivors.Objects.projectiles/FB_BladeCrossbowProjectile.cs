using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_BladeCrossbowProjectile : Projectile
{
	private enum BladeCrossbowState
	{
		GoingOutwards,
		Paused,
		Returning
	}

	private BladeCrossbowState _state;

	private float2 _positionBeforeReturning;

	private float _returningT;

	private float2 _originalPosition;

	private float _age;

	protected virtual string _FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A410C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Blade Crossbow-BladeCrossbow_01";
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileCross2", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_003d: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_0122: Invalid comparison between O and F4
		base.InitProjectile(pool, weapon, index);
		_age = 0f;
		_state = BladeCrossbowState.GoingOutwards;
		_isCullable = true;
		string frameName = _FrameName;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		BaseBody baseBody = body.setCircle(14f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		SetScaleToArea();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		float2 float5 = (_originalPosition = base.position);
		_ = 1055286886;
		float num = _weapon.PArea();
		float alpha;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
		{
			float num2 = (float)float5 - 1f;
			float num3 = num2 / 5f;
			float num4 = 1f - num3;
			float num5 = num4 * 0.65f;
			float num6 = num5 + 0.35f;
			alpha = num6;
		}
		else
		{
			alpha = 0.35f;
		}
		ArcadeSprite arcadeSprite3 = setAlpha(alpha);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0092: Expected O, but got I4
		//IL_0712: Expected O, but got I4
		//IL_02b9: Expected O, but got I4
		//IL_0278: Expected O, but got I4
		//IL_0292: Expected O, but got I4
		//IL_0840: Expected O, but got I4
		//IL_052b: Expected O, but got I4
		//IL_0574: Expected I, but got O
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected Ref, but got Unknown
		//IL_06d3: Expected O, but got I
		//IL_06f5: Expected O, but got I4
		//IL_08e0->IL075f: Incompatible stack heights: 1 vs 0
		//IL_05a7->IL075f: Incompatible stack heights: 1 vs 0
		//IL_062e->IL075f: Incompatible stack heights: 1 vs 0
		//IL_0657->IL075f: Incompatible stack heights: 1 vs 0
		//IL_067c->IL075f: Incompatible stack heights: 1 vs 0
		//IL_06fa->IL0717: Incompatible stack heights: 1 vs 0
		float deltaTime = PauseSystem.DeltaTime;
		float age = deltaTime + _age;
		_age = age;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		float num2;
		float num4;
		float? num5;
		if ((object)cachedTrans != null)
		{
			Vector3 localEulerAngles = cachedTrans.localEulerAngles;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num = deltaTime2 * 720f;
			num2 = (base.angle = num + localEulerAngles.z);
			if (_state != BladeCrossbowState.GoingOutwards)
			{
				bool flag = _state != BladeCrossbowState.Returning;
				num4 = num2;
				num5 = (float?)(object)0;
				if (!flag)
				{
					float deltaTime3 = PauseSystem.DeltaTime;
					Weapon weapon = _weapon;
					float returningT = deltaTime3 + _returningT;
					_returningT = returningT;
					if ((object)_weapon == null || (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
					{
						goto IL_075f;
					}
					float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					if (!(_returningT > 1f))
					{
						object obj = _positionBeforeReturning - _originalPosition;
						float num6 = _returningT * _returningT;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_BladeCrossbowProjectile)+D8]");
						float num7 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_BladeCrossbowProjectile)+E4]");
						float num8 = num7 - 0f;
						float num9 = num6 * _returningT;
						float num10 = num9 * _returningT;
						float num11 = 1f - num10;
						float num12 = num11 * num8;
						float num13 = num11 * (float)obj;
						float num14 = (float)_originalPosition + num13;
						float num15 = (float)float5 - num14;
						float num16 = num15 * num10;
						float2 float6 = default(float2);
						base.position = float6;
						if ((object)_weapon == null)
						{
							goto IL_075f;
						}
						float num17 = _weapon.PArea();
						float num18 = num16 * 1.5f;
						float num19 = 1f - num10;
						num2 = num18 * num19;
						ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
						ref float2 reference = ref *(float2*)null;
						num4 = num2;
						num5 = (float?)(object)0;
					}
					else
					{
						_returningT = 1f;
						Despawn();
						num4 = num2;
						num5 = (float?)(object)0;
						num2 = _returningT;
					}
				}
				goto IL_0717;
			}
			Transform targetTransform = _targetTransform;
			if ((object)_targetTransform == null || ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0)
			{
				goto IL_06fa;
			}
			if ((object)_targetTransform != null)
			{
				Transform parent = _targetTransform.parent;
				if ((object)parent == null || ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0)
				{
					goto IL_06fa;
				}
				if ((object)_targetTransform != null)
				{
					Transform parent2 = _targetTransform.parent;
					if ((object)parent2 != null)
					{
						GameObject gameObject = parent2.gameObject;
						if ((object)gameObject != null)
						{
							EnemyController component = gameObject.GetComponent<EnemyController>();
							if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
							{
								goto IL_06fa;
							}
							if ((object)_targetTransform != null)
							{
								Transform parent3 = _targetTransform.parent;
								if ((object)parent3 != null)
								{
									GameObject gameObject2 = parent3.gameObject;
									if ((object)gameObject2 != null)
									{
										EnemyController component2 = gameObject2.GetComponent<EnemyController>();
										if ((object)component2 != null)
										{
											if (component2._003CIsDead_003Ek__BackingField)
											{
												goto IL_06fa;
											}
											Transform targetTransform2 = _targetTransform;
											bool flag2 = (object)_targetTransform == null;
											num4 = num2;
											num5 = (float?)(object)0;
											if (!flag2)
											{
												bool flag3 = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
												num4 = num2;
												num5 = (float?)(object)0;
												if (!flag3)
												{
													Transform targetTransform3 = _targetTransform;
													if ((object)_targetTransform != null)
													{
														bool flag4 = ((UnityEngine.Object)targetTransform3).m_CachedPtr == (IntPtr)0;
														Transform.get_position_Injected(((UnityEngine.Object)targetTransform3).m_CachedPtr, out Vector3 ret);
														float2 float7 = base.cachedPosition;
														object obj2 = (object)ret - (object)float7;
														object obj4 = default(object);
														object obj5 = default(object);
														object obj3 = obj4 - obj5;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
														Weapon weapon2 = _weapon;
														float target = (float)obj3 * 57.29578f;
														if ((object)_weapon != null)
														{
															nint num20 = (nint)weapon2;
															float num21 = _weapon.PSpeed();
															BaseBody baseBody = body;
															if (body != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v53 (BaseBody)+74]");
																float current = 0f * 57.29578f;
																float deltaTime4 = PauseSystem.DeltaTime;
																float num22 = _age * 100f;
																float num23 = num22 * (float)obj3;
																float maxDelta = deltaTime4 * num23;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																object obj6 = default(object);
																if (obj6 != null)
																{
																	float projectileSpeed = base.ProjectileSpeed;
																	if (body != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v58+18]");
																		if ((nint)0 != 0)
																		{
																			float num24 = Mathf.MoveTowardsAngle(current, target, maxDelta);
																			num2 = num24 * ((float)Math.PI / 180f);
																			ref float2 reference = ref *(float2*)(body + 112);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v58+18]");
																			float2 float8 = ((ArcadePhysics)0).velocityFromRotation(num2, deltaTime4, ref reference);
																			float num8 = deltaTime4;
																			num4 = num2;
																			num5 = (float?)(object)0;
																			goto IL_0717;
																		}
																	}
																}
															}
														}
													}
													goto IL_075f;
												}
											}
											goto IL_0717;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_075f;
		IL_06fa:
		_targetTransform = null;
		num4 = num2;
		num5 = (float?)(object)0;
		goto IL_0717;
		IL_075f:
		throw new NullReferenceException();
		IL_0717:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num25 = default(int);
		ArcadeSprite arcadeSprite2 = setDepth(num25);
		if ((object)_spriteTrail != null)
		{
			_spriteTrail.UpdateDepth();
			return;
		}
		goto IL_075f;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		if (_state == BladeCrossbowState.GoingOutwards)
		{
			_state = BladeCrossbowState.Paused;
			PauseAttack();
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0083: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.DLC4_EnemyHit, soundConfig, 200f, 10, time);
		if (_state == BladeCrossbowState.GoingOutwards)
		{
			_state = BladeCrossbowState.Paused;
			PauseAttack();
		}
	}

	private void PauseAttack()
	{
		//IL_0196: Expected O, but got I4
		//IL_01c5: Expected I, but got O
		//IL_0238: Expected O, but got I4
		_isCullable = false;
		float num = _weapon.PDuration();
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		if ((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
			if ((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField != null)
			{
				Action onComplete = ClearEnemiesHit;
				object obj = default(object);
				float duration = (float)obj * 0.001f;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				Weapon weapon2 = _weapon;
				WeaponData currentWeaponData2 = weapon2._currentWeaponData;
				if ((object)currentWeaponData2._003ChitBoxDelay_003Ek__BackingField != null)
				{
					Action onComplete2 = RecallProjectile;
					object obj3 = default(object);
					object obj2 = obj3 * obj;
					float duration2 = (float)obj2 * 0.001f;
					Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					setVelocity(0f, (float?)(object)1);
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					nint num2 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig.targets = array;
						float num3 = _weapon.PArea();
						tweenConfig.duration = 200f;
						tweenConfig.scale = (float?)(object)1;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						return;
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private void ClearEnemiesHit()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void RecallProjectile()
	{
		float2 positionBeforeReturning = base.position;
		_positionBeforeReturning = positionBeforeReturning;
		_state = BladeCrossbowState.Returning;
		_returningT = 0f;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		base.Despawn();
	}
}
