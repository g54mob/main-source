using System;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class Enemy_Charger : EnemyController
{
	private float chargeMechanicInterval = 2000f;

	private float chargeActivationDelay = 1000f;

	private float chargeActiveDuration = 750f;

	private Timer _chargerMechanicTimer;

	private Timer _chargeDelayTimer;

	private Timer _chargeFinishTimer;

	private float chargeSpeedModifier = 10f;

	private bool _isCharging;

	private bool _isMoving = true;

	private Vector2 _chargeDirection;

	private SpriteTrail trail;

	private float flashRepeatingInterval = 250f;

	private Timer _warningFlashTimer;

	private bool _toggleWarningColour;

	private PhaserSprite _exclamationMark;

	private MultiTargetTween _warningTween;

	private PhaserSprite _groundFx;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_010d: Expected O, but got Ref
		//IL_01dc: Expected O, but got I4
		//IL_03f4->IL037f: Incompatible stack heights: 1 vs 0
		//IL_005f->IL037f: Incompatible stack heights: 1 vs 0
		//IL_008e->IL037f: Incompatible stack heights: 1 vs 0
		//IL_00bd->IL037f: Incompatible stack heights: 1 vs 0
		//IL_00ec->IL037f: Incompatible stack heights: 1 vs 0
		//IL_0129->IL037f: Incompatible stack heights: 1 vs 0
		//IL_0153->IL037f: Incompatible stack heights: 1 vs 0
		//IL_018f->IL037f: Incompatible stack heights: 1 vs 0
		//IL_01c2->IL037f: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL037f: Incompatible stack heights: 1 vs 0
		//IL_0228->IL037f: Incompatible stack heights: 1 vs 0
		//IL_0413->IL037f: Incompatible stack heights: 1 vs 0
		//IL_02c7->IL037f: Incompatible stack heights: 1 vs 0
		//IL_02f6->IL037f: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		PhaserWorld instance = PhaserWorld.Instance;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "WhiteDot");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.5f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
							if ((object)phaserSprite4 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
								PhaserSprite phaserSprite5 = phaserSprite4.setTintFill(isEnabled: true, (Color?)(object)(&ret));
								if ((object)phaserSprite5 != null)
								{
									GameObject gameObject = phaserSprite5.gameObject;
									if ((object)gameObject != null)
									{
										((UnityEngine.Object)gameObject).SetName("GroundFx (ChargingZone)");
										_groundFx = phaserSprite5;
										if ((object)_groundFx != null)
										{
											PhaserSprite phaserSprite6 = _groundFx.setVisible(visible: false);
											if ((object)_groundFx != null)
											{
												PhaserSprite phaserSprite7 = _groundFx.setOrigin(0.5f, (float?)(object)1);
												if ((object)_EnemyRenderer != null)
												{
													Vector2 vector = _EnemyRenderer.size;
													if ((object)_EnemyRenderer != null)
													{
														Vector2 vector2 = _EnemyRenderer.size;
														float num = (float)vector * 100f;
														float yScale = 0f * 100f;
														float xScale = num * 0.5f;
														PhaserSprite phaserSprite8 = RenderingExtensions.SetScale(_groundFx, xScale, yScale);
														if ((object)_groundFx != null)
														{
															PhaserSprite phaserSprite9 = _groundFx.setVisible(visible: false);
															_isCharging = false;
															if ((object)trail != null)
															{
																trail.enabled = false;
																if ((object)trail != null)
																{
																	trail.Reset();
																	_isMoving = true;
																	Action onComplete = SetupChargeAtPlayer;
																	float duration = chargeMechanicInterval * 0.001f;
																	bool useRealTime = default(bool);
																	MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																	int repeat = default(int);
																	TimerType type = default(TimerType);
																	Timer chargerMechanicTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																	_chargerMechanicTimer = chargerMechanicTimer;
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
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Expected O, but got Unknown
		//IL_00d5: Expected O, but got F4
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_06df: Expected O, but got I
		//IL_06fc: Expected O, but got I
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Expected O, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_01fa: Expected O, but got F4
		//IL_04f2: Expected O, but got F4
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_066d->IL0502: Incompatible stack heights: 1 vs 0
		//IL_0820->IL0502: Incompatible stack heights: 2 vs 0
		//IL_0502->IL052b: Incompatible stack heights: 2 vs 0
		//IL_05f9->IL052b: Incompatible stack heights: 2 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.UpdateDepth();
		if (base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		RetargetIfNecessary();
		object obj2 = default(object);
		if (!_isMoving)
		{
			if (_isCharging)
			{
				bool flag = (nint)_chargeDirection < 0;
				bool flag2 = (object)_chargeDirection == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				bool flag5 = flag4 & flag3;
				base.SetFlipX(flag5);
				float num = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
				float num2 = num * chargeSpeedModifier;
				float num3 = num2 / 100f;
				float num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemy_Charger)+2A4]");
				float num5 = num4 * 0f;
				float num6 = num3 * (float)_chargeDirection;
				BaseBody baseBody = body;
				if (body != null)
				{
					baseBody._velocity = (float2)num6;
					return;
				}
			}
			else if ((object)_cachedTransform != null)
			{
				Vector3 vector = _cachedTransform.position;
				if ((object)_cachedTransform != null)
				{
					Vector3 vector2 = _cachedTransform.position;
					Vector2 vector3 = AdjustedMarkPositionY(vector.x, vector2.y);
					if ((object)_exclamationMark != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
						if ((object)_cachedTransform != null)
						{
							Vector3 vector4 = _cachedTransform.position;
							_ = vector4.z;
							_ = vector4.x;
							if ((object)_groundFx != null)
							{
								float num7 = default(float);
								PhaserSprite phaserSprite = _groundFx.setPosition((float2)num7);
								if ((object)_EnemyRenderer != null)
								{
									Vector2 vector5 = _EnemyRenderer.size;
									if ((object)_cachedTransform != null)
									{
										Vector3 vector6 = _cachedTransform.position;
										_ = vector6.z;
										_ = vector6.x;
										if ((object)base._targetTransform != null)
										{
											Vector3 vector7 = base._targetTransform.position;
											_ = vector7.x;
											_ = vector7.z;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
											float yScale = num7 * 100f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+10]");
											float xScale = 0f * 100f;
											PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_groundFx, xScale, yScale);
											if ((object)_cachedTransform != null)
											{
												Vector3 vector8 = _cachedTransform.position;
												_ = vector8.x;
												_ = vector8.z;
												if ((object)base._targetTransform != null)
												{
													Vector3 vector9 = base._targetTransform.position;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
													float xScale2 = 0f - vector9.x;
													_ = vector9.z;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-2C]");
													float num8 = 0f - num7;
													_ = vector9.x;
													if ((object)_groundFx != null)
													{
														Transform transform = _groundFx.transform;
														PhaserSprite phaserSprite3 = RenderingExtensions.SetScale(_groundFx, xScale2, num7);
														float num9 = num8 * 57.29578f;
														float z = num9 - 90f;
														Quaternion quaternion2 = Quaternion.Euler(0f, 0f, z);
														bool flag6 = (object)transform == null;
														_ = quaternion2.x;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rax_v70 (UnityEngine.Transform)+10]");
														bool flag7 = (nint)0 == 0;
														object obj = obj2 - 48;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rax_v70 (UnityEngine.Transform)+10]");
														Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj);
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
		else
		{
			object targetTransform = base._targetTransform;
			if ((object)base._targetTransform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdi_v12 (System.Object)+10]");
				bool flag8 = (nint)0 == 0;
				object obj3 = obj2 - 64;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdi_v12 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdi_v13 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					object obj4 = obj2 - 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdi_v13 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
					Vector2 currentDirection = (Vector2)(num10 - 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-2C]");
					object obj5 = num11 - 0;
					Vector2 vector10 = (Vector2)(this + 480);
					_currentDirection = currentDirection;
					((Vector2*)vector10)->Normalize();
					bool flag10 = (nint)_currentDirection < 0;
					bool flag11 = (object)_currentDirection == null;
					bool flag12 = !flag10;
					bool flag13 = !flag11;
					bool flag14 = flag13 & flag12;
					base.SetFlipX(flag14);
					float num13;
					if (_receivingDamage)
					{
						float num12 = base._003CKnockBack_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj6 = num12 ^ 0;
						num13 = (float)obj6 * _damageKb;
					}
					else
					{
						num13 = 1f;
					}
					float num14 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
					float num15 = num14 / 100f;
					float num16 = num15 * num13;
					float num17 = num16 * base._003CSlow_003Ek__BackingField;
					float num18 = num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemy_Charger)+1E4]");
					float num19 = num18 * 0f;
					float num20 = num17 * (float)_currentDirection;
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._velocity = (float2)num20;
						base.ProcessWiggle();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ToggleWarningTint()
	{
		//IL_0019: Expected O, but got Ref
		if (_toggleWarningColour)
		{
		}
		object obj = default(object);
		RenderingExtensions.SetTint(_EnemyRenderer, (Color?)(object)(&obj));
		bool toggleWarningColour = !_toggleWarningColour;
		_toggleWarningColour = toggleWarningColour;
	}

	private void SetupChargeAtPlayer()
	{
		//IL_040d: Expected O, but got I4
		//IL_0236: Expected O, but got I4
		//IL_027c: Expected F4, but got I4
		//IL_028d: Expected O, but got I4
		//IL_0296: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_015a: Expected F4, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_0555->IL03eb: Incompatible stack heights: 1 vs 0
		//IL_04a1->IL03eb: Incompatible stack heights: 1 vs 0
		//IL_05aa->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_01e6->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_021e->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_04f6->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_0252->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_010a->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_0133->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_02d2->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_02fe->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_036d->IL03eb: Incompatible stack heights: 2 vs 0
		//IL_034b->IL034b: Incompatible stack heights: 3 vs 2
		_isMoving = false;
		setVelocity(0f, (float?)(object)0);
		Action onComplete = ToggleWarningTint;
		float duration = flashRepeatingInterval * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer warningFlashTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_warningFlashTimer = warningFlashTimer;
		PhaserSprite exclamationMark = _exclamationMark;
		bool num;
		Vector3 ret;
		bool num2;
		Vector3 ret2;
		Vector2 vector3 = default(Vector2);
		if ((object)_exclamationMark != null && ((UnityEngine.Object)exclamationMark).m_CachedPtr != (IntPtr)0)
		{
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdi_v18 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				num = flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdi_v18 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				object cachedTransform2 = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rdi_v19 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					num2 = flag2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rdi_v19 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret2);
					if ((object)_EnemyRenderer != null)
					{
						Vector2 vector = _EnemyRenderer.size;
						object obj2 = default(object);
						object obj3 = default(object);
						object obj = obj2 + obj3;
						if ((object)_exclamationMark != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
							if ((object)_exclamationMark != null)
							{
								PhaserSprite phaserSprite = _exclamationMark.setScale(0f, (float?)(object)0);
								float num3 = 0f;
								Vector2 vector2 = vector3;
								object obj4 = 0;
								float? num4 = (float?)(object)0;
								goto IL_029b;
							}
						}
					}
				}
			}
		}
		else
		{
			PhaserWorld instance = PhaserWorld.Instance;
			object cachedTransform3 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdi_v16 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				num = flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdi_v16 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret2);
				object cachedTransform4 = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rdi_v17 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					num2 = flag4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rdi_v17 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)_EnemyRenderer != null)
					{
						Vector2 vector4 = _EnemyRenderer.size;
						if ((object)instance != null)
						{
							PhaserSprite phaserSprite2 = instance.AddPhaserSprite(vector3, "UI", "ExclamationMark");
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite exclamationMark2 = phaserSprite3.setDepth(9000);
									_exclamationMark = exclamationMark2;
									float num3 = 0f;
									Vector2 vector2 = vector3;
									object obj4 = 0;
									float? num4 = (float?)(object)0;
									goto IL_029b;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03eb;
		IL_03eb:
		throw new NullReferenceException();
		IL_029b:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_exclamationMark != null)
		{
			Transform transform = _exclamationMark.transform;
			if (array != null)
			{
				if ((object)transform != null)
				{
					object obj5 = array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					bool flag5 = obj6 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					_ = 1;
					_ = chargeActivationDelay;
					TweenCallback tweenCallback = delegate
					{
						PhaserSprite phaserSprite4 = _groundFx.setVisible(visible: true);
						PhaserSprite phaserSprite5 = _exclamationMark.setVisible(visible: true);
					};
					TweenCallback tweenCallback2 = delegate
					{
						//IL_0051: Expected I, but got O
						//IL_00c3: Expected O, but got I4
						ChargeAtPlayer();
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						Transform transform2 = _exclamationMark.transform;
						if ((object)transform2 != null)
						{
							nint num5 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj7 = default(object);
							if (obj7 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig2.targets = array2;
						tweenConfig2.duration = 200f;
						tweenConfig2.delay = 200f;
						tweenConfig2.scale = (float?)(object)1;
						TweenCallback onComplete2 = delegate
						{
							PhaserSprite phaserSprite4 = _exclamationMark.setVisible(visible: false);
						};
						tweenConfig2.onComplete = onComplete2;
						MultiTargetTween warningTween2 = Tweens.Add(tweenConfig2);
						_warningTween = warningTween2;
					};
					MultiTargetTween warningTween = Tweens.Add(tweenConfig);
					_warningTween = warningTween;
					return;
				}
			}
		}
		goto IL_03eb;
	}

	private unsafe void ChargeAtPlayer()
	{
		//IL_0033: Expected O, but got Ref
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_00e1: Expected O, but got F4
		//IL_01c9->IL014f: Incompatible stack heights: 1 vs 0
		//IL_02d2->IL014f: Incompatible stack heights: 2 vs 0
		if (_warningFlashTimer != null)
		{
			_warningFlashTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
		Vector3 ret = default(Vector3);
		RenderingExtensions.SetTint(_EnemyRenderer, (Color?)(object)(&ret));
		if ((object)trail != null)
		{
			trail.Reset();
			if ((object)trail != null)
			{
				trail.enabled = true;
				RetargetIfNecessary();
				SpriteRenderer targetTransform = (SpriteRenderer)(object)base._targetTransform;
				if ((object)base._targetTransform != null)
				{
					bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret2);
					SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
					if ((object)_cachedTransform != null)
					{
						bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out ret);
						Vector2 chargeDirection = ret2 - ret;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
						object obj2 = default(object);
						object obj = obj2 - 0;
						Vector2 vector = (Vector2)(this + 672);
						_chargeDirection = chargeDirection;
						((Vector2*)vector)->Normalize();
						_isCharging = true;
						float num = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
						float num2 = num * chargeSpeedModifier;
						float num3 = num2 / 100f;
						float num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemy_Charger)+2A4]");
						float num5 = num4 * 0f;
						float num6 = num3 * (float)_chargeDirection;
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._velocity = (float2)num6;
							Action onComplete = RestartMovement;
							float duration = chargeActiveDuration * 0.001f;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer chargeFinishTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_chargeFinishTimer = chargeFinishTimer;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RestartMovement()
	{
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		_isCharging = false;
		trail.enabled = false;
		trail.Reset();
		_isMoving = true;
		Action onComplete = SetupChargeAtPlayer;
		float duration = chargeMechanicInterval * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer chargerMechanicTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_chargerMechanicTimer = chargerMechanicTimer;
	}

	private Vector2 AdjustedMarkPositionY(float x, float y)
	{
		if ((object)_EnemyRenderer != null)
		{
			Vector2 vector = _EnemyRenderer.size;
			Vector2 result = default(Vector2);
			return result;
		}
		return (Vector2)new NullReferenceException();
	}

	protected override void Die()
	{
		if ((object)_groundFx != null)
		{
			PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		}
		PhaserSprite exclamationMark = _exclamationMark;
		if ((object)_exclamationMark != null && ((UnityEngine.Object)exclamationMark).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _exclamationMark.setVisible(visible: false);
		}
		base.Die();
	}

	public override void Disappear()
	{
		if ((object)_groundFx != null)
		{
			PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		}
		base.Disappear();
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_warningTween != null)
		{
			_warningTween.Kill();
		}
		PhaserSprite exclamationMark = _exclamationMark;
		if ((object)_exclamationMark != null && ((UnityEngine.Object)exclamationMark).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _exclamationMark.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			_exclamationMark = null;
		}
		if (_chargerMechanicTimer != null)
		{
			_chargerMechanicTimer.Cancel();
		}
		if (_chargeDelayTimer != null)
		{
			_chargeDelayTimer.Cancel();
		}
		if (_chargeFinishTimer != null)
		{
			_chargeFinishTimer.Cancel();
		}
		if (_warningFlashTimer != null)
		{
			_warningFlashTimer.Cancel();
		}
		if ((object)_groundFx != null)
		{
			PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		}
	}

	private void _003CSetupChargeAtPlayer_003Eb__20_0()
	{
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _exclamationMark.setVisible(visible: true);
	}

	private void _003CSetupChargeAtPlayer_003Eb__20_1()
	{
		//IL_0051: Expected I, but got O
		//IL_00c3: Expected O, but got I4
		ChargeAtPlayer();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _exclamationMark.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.delay = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween warningTween = Tweens.Add(tweenConfig);
		_warningTween = warningTween;
	}

	private void _003CSetupChargeAtPlayer_003Eb__20_2()
	{
		PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
	}
}
