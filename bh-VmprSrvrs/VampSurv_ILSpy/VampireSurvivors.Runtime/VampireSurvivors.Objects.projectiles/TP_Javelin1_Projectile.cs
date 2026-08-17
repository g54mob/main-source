using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Javelin1_Projectile : Projectile
{
	private const float Gravity = 4f;

	private const float InitialAngle = 30f;

	private const float Radius = 12f;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Vector2 _velocity;

	private Vector2 _initialVelocity;

	private bool _cachedFlipX;

	private float _flipNum;

	private VampireSurvivors.Framework.TimerSystem.Timer _expireTimer;

	protected virtual string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4524]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_Javelin01";
		}
	}

	protected virtual bool IsEvolution => false;

	protected virtual bool WrapX => false;

	protected virtual bool WrapY => false;

	protected override void Awake()
	{
		base.Awake();
		string frameName = FrameName;
		Sprite sprite = SpriteManager.GetSprite(frameName, "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0050: Expected I4, but got I8
		//IL_07c8: Expected F4, but got I4
		//IL_0111: Expected O, but got I4
		//IL_01e6: Expected I, but got O
		//IL_01fe: Expected O, but got I4
		//IL_020c: Expected O, but got I4
		//IL_02cd: Expected O, but got I4
		//IL_0367: Expected O, but got I4
		//IL_03a9: Expected O, but got I
		//IL_097e: Expected I, but got O
		//IL_040f: Expected O, but got I8
		//IL_055f: Invalid comparison between F4 and I4
		//IL_08c3: Expected O, but got I4
		//IL_0523: Invalid comparison between F4 and I4
		//IL_066e: Expected F4, but got O
		//IL_067e: Expected F4, but got I
		//IL_08e9: Expected O, but got I4
		//IL_08f2: Expected O, but got I4
		//IL_0728: Expected O, but got I4
		//IL_0768: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 2.5f;
		_isCullable = false;
		if ((object)weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				_cachedFlipX = characterController._isFlipped;
				bool flag = true;
				if (!characterController._isFlipped)
				{
					flag = true;
				}
				_flipNum = (flag ? 1 : 0);
				float num = weapon.PSpeed();
				float num2 = weapon.PArea();
				if ((object)_weapon != null)
				{
					float num3 = _weapon.PDuration();
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						float num4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PDuration();
						ArcadeSprite arcadeSprite = setFlipX(_cachedFlipX);
						ArcadeSprite arcadeSprite2 = setAlpha(1f);
						ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
						if (_scaleTween != null)
						{
							_scaleTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							void* value = ((IntPtr*)(&array))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							if (obj == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
								TP_Javelin1_Projectile tP_Javelin1_Projectile = this;
								((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1128792064;
								((Weapon)(object)tweenConfig)._gameSessionData = (GameSessionData)1;
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								float2 float5 = base.position;
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null)
								{
									Weapon weapon4 = (Weapon)(object)((Equipment)weapon3)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										((ArcadeSprite)((Equipment)weapon3)._003COwner_003Ek__BackingField).CheckRenderer();
										if (((Equipment)weapon4)._equipmentType != WeaponType.VOID)
										{
											Vector2 vector = ((SpriteRenderer)((Equipment)weapon4)._equipmentType).size;
											Weapon weapon5 = _weapon;
											if ((object)_weapon != null)
											{
												Weapon weapon6 = (Weapon)(object)((Equipment)weapon5)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
												{
													((ArcadeSprite)((Equipment)weapon5)._003COwner_003Ek__BackingField).CheckRenderer();
													if (((Equipment)weapon6)._equipmentType != WeaponType.VOID)
													{
														Vector2 vector2 = ((SpriteRenderer)((Equipment)weapon6)._equipmentType).size;
														object obj2 = default(object);
														float num5 = (float)obj2 * 0.8f;
														float num6 = (float)(flag ? 1 : 0) + num5;
														float2 float6 = default(float2);
														base.position = float6;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
														object obj3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
														bool flag2 = (nint)0 != 0;
														ArcadeSprite arcadeSprite4 = this;
														if (!flag2)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
															if (obj3 == null)
															{
																MissingMethodException ex2 = new MissingMethodException();
																throw ex2;
															}
															arcadeSprite4 = (ArcadeSprite)6573110936L;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1061 @ rax_v52 (should have been resolved before IL gen)");
														float num7 = -5f + 30f;
														float num8 = ((!_cachedFlipX) ? num7 : (180f - num7));
														if (IsEvolution)
														{
															float num9 = (float)index * 10f;
															float num10 = num9 * _flipNum;
															num7 = num10 + num8;
															bool flag3 = !(num7 > 85f);
															num8 = num7;
															if (!flag3)
															{
																bool flag4 = !(95f > num7);
																num8 = num7;
																if (!flag4)
																{
																	num7 = UnityEngine.Random.value;
																	num8 = ((!(num7 > 0.5f)) ? 95f : 85f);
																}
															}
															bool flag5;
															bool flag6;
															if (_cachedFlipX)
															{
																flag5 = 90f < num8;
																float num11 = 90f - num8;
																flag6 = num11 == 0f;
																num7 = 90f;
															}
															else
															{
																flag5 = num8 < 90f;
																float num12 = num8 - 90f;
																flag6 = num12 == 0f;
															}
															bool flag7 = !flag5;
															bool flag8 = !flag6;
															object obj4 = flag8 & flag7;
															if (obj4 != null)
															{
																ArcadeSprite arcadeSprite5 = setFlipX(_cachedFlipX = !_cachedFlipX);
																num7 = (_flipNum *= -1f);
																tP_Javelin1_Projectile = null;
															}
														}
														nint num13 = (nint)this;
														float num14 = num8 * ((float)Math.PI / 180f);
														float projectileSpeed = base.ProjectileSpeed;
														Weapon weapon7 = _weapon;
														if ((object)_weapon != null)
														{
															if (!weapon7.IsHoming)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																float num15 = num14 * num7;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																float num16 = (float)(flag ? 1 : 0) + (float)(flag ? 1 : 0);
																float num17 = num14 * num16;
															}
															else
															{
																Transform transform = base.AimForNearestEnemy();
																BaseBody baseBody = body;
																if (body == null)
																{
																	goto IL_076d;
																}
																float num15 = (float)baseBody._velocity;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v89 (BaseBody)+74]");
																float num17 = 0f;
															}
															object obj5 = 224;
															object obj6 = 228;
															Weapon cachedTransform = (Weapon)(object)_cachedTransform;
															_initialVelocity = _velocity;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+E4]");
															_ = 0;
															float2 euler = default(float2);
															Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
															bool flag9 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
															Quaternion value2 = default(Quaternion);
															Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value2);
															UpdateBody();
															if (_expireTimer != null)
															{
																_expireTimer.Cancel();
															}
															Action onComplete = StartDespawn;
															float duration = (float)(flag ? 1 : 0) * 0.001f;
															bool flag10 = default(bool);
															MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
															int repeat = default(int);
															TimerType type = default(TimerType);
															VampireSurvivors.Framework.TimerSystem.Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag10, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
															_expireTimer = expireTimer;
															SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
															{
																Rate = 1f,
																Volume = (float?)(object)1
															};
															float detune = (float)_indexInWeapon * -80f;
															soundConfig.Detune = detune;
															PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Javelin, soundConfig, 200f, 10, flag10 ? 1 : 0);
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
		goto IL_076d;
		IL_076d:
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_00b8: Invalid comparison between F4 and I4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+E4]");
		float num2 = 0f - num;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		Vector3 forward = default(Vector3);
		Vector3 upwards = default(Vector3);
		Quaternion.LookRotation_Injected(ref forward, ref upwards, out Quaternion ret);
		Vector3 eulerAngles = ret.eulerAngles;
		Transform cachedTransform = _cachedTransform;
		Quaternion.Internal_FromEulerRad_Injected(ref forward, out ret);
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Quaternion*)(&upwards));
		CheckForScreenWrapping();
		if (!CameraExtensions.IsObjectVisible(_mainCamera, _renderer))
		{
			Despawn();
		}
		if (body != null)
		{
			CheckIfVisibleOnScreen();
			if (base._pauseWallChecksTimer > 0f)
			{
				float deltaTime2 = PauseSystem.DeltaTime;
				float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime2;
				base._pauseWallChecksTimer = pauseWallChecksTimer;
			}
		}
	}

	private void CheckForDespawn()
	{
		if (!CameraExtensions.IsObjectVisible(_mainCamera, _renderer))
		{
			Despawn();
		}
	}

	private void CheckForScreenWrapping()
	{
		//IL_0062: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		if (CameraExtensions.IsObjectVisible(_mainCamera, _renderer))
		{
			return;
		}
		bool wrapX = WrapX;
		bool flag = !wrapX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (UnityEngine.Bounds)+10]");
		object obj = 0;
		if (!flag)
		{
			bool flag2 = (nint)_velocity <= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (UnityEngine.Bounds)+10]");
			obj = 0;
			object obj2 = default(object);
			if (!flag2)
			{
				float2 float5 = base.position;
				obj = (object)bounds.m_Center + obj2;
				if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					goto IL_0271;
				}
			}
			if (0 > (nint)_velocity)
			{
				float2 float6 = base.position;
				Vector3 vector = (Vector3)((object)bounds.m_Center - obj2);
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6))
				{
					goto IL_0271;
				}
			}
		}
		goto IL_014e;
		IL_0271:
		float2 float7 = base.position;
		float2 float8 = default(float2);
		base.position = float8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		goto IL_014e;
		IL_028a:
		base.position = float8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_014e:
		if (!WrapY)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+E4]");
		object obj3 = default(object);
		Vector3 vector2 = default(Vector3);
		if ((nint)0 > (nint)0)
		{
			float2 float9 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (UnityEngine.Bounds)+10]");
			obj = obj3 + 0;
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				float2 float10 = base.position;
				goto IL_028a;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+E4]");
		if ((nint)0 > (nint)0)
		{
			float2 float11 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (UnityEngine.Bounds)+10]");
			object obj4 = obj3 - 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector2))
			{
				float2 float12 = base.position;
				goto IL_028a;
			}
		}
	}

	private void UpdateBody()
	{
		//IL_00a8: Expected O, but got I4
		//IL_0015: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0168->IL00f5: Incompatible stack heights: 1 vs 0
		//IL_0098->IL016d: Incompatible stack heights: 1 vs 0
		float? offsetX;
		float? offsetY;
		float radius;
		BaseBody baseBody;
		if (!_cachedFlipX)
		{
			ArcadeSprite arcadeSprite = setOrigin(1f, (float?)(object)1);
			if ((object)_renderer != null)
			{
				Sprite sprite = _renderer.sprite;
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
					if (body != null)
					{
						offsetX = (float?)(object)1;
						offsetY = (float?)(object)1;
						radius = 12f;
						baseBody = body;
						goto IL_016d;
					}
				}
			}
		}
		else
		{
			ArcadeSprite arcadeSprite2 = setOrigin(0f, (float?)(object)1);
			baseBody = body;
			if (body != null)
			{
				offsetX = (float?)(object)1;
				offsetY = (float?)(object)1;
				radius = 12f;
				goto IL_016d;
			}
		}
		throw new NullReferenceException();
		IL_016d:
		BaseBody baseBody2 = baseBody.setCircle(radius, offsetX, offsetY);
	}

	private void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00cd: Expected F4, but got I4
		//IL_00e3: Expected I, but got O
		//IL_015d: Expected O, but got F4
		//IL_0167: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (--_penetrating <= 0)
			{
				Despawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+E4]");
		bool flag = (nint)0 <= (nint)0;
		float num = 0f;
		IDamageable damageable = other;
		nint num2 = (nint)typeof(IDamageable);
		if (!flag)
		{
			ArcadeSprite arcadeSprite = setFlipX(_cachedFlipX = !_cachedFlipX);
			UpdateBody();
			float flipNum = _flipNum * -1f;
			_flipNum = flipNum;
			num = (float)_velocity * -1f;
			_velocity = (Vector2)num;
			damageable = null;
			num2 = unchecked((nint)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+EC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
	}

	private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00e6: Expected F4, but got I4
		//IL_00fc: Expected I, but got O
		//IL_0176: Expected O, but got F4
		//IL_0180: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				Despawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+E4]");
		bool flag = (nint)0 <= (nint)0;
		float num = 0f;
		IDamageable damageable = other;
		nint num2 = (nint)typeof(IDamageable);
		if (!flag)
		{
			ArcadeSprite arcadeSprite = setFlipX(_cachedFlipX = !_cachedFlipX);
			UpdateBody();
			float flipNum = _flipNum * -1f;
			_flipNum = flipNum;
			num = (float)_velocity * -1f;
			_velocity = (Vector2)num;
			damageable = null;
			num2 = unchecked((nint)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Javelin1_Projectile)+EC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
