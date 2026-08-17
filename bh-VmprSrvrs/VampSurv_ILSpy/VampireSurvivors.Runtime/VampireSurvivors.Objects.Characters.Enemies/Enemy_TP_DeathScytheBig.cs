using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_DeathScytheBig : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__20_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CRemoveAllWeaponsFromEachPlayer_003Eb__20_0()
		{
			//IL_0013: Expected O, but got I4
			GameManager core = GM.Core;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public PhaserSprite slash;

		internal void _003CDoSwing_003Eb__2()
		{
			GameObject gameObject = slash.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public Enemy_TP_DeathScytheBig _003C_003E4__this;

		public PhaserSprite s;

		public TweenCallback _003C_003E9__1;

		internal void _003CSingleWarning_003Eb__0()
		{
			//IL_003e: Expected I, but got O
			//IL_0094: Expected O, but got I4
			Enemy_TP_DeathScytheBig enemy_TP_DeathScytheBig = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = s.transform;
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
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.duration = 200f;
			tweenConfig.delay = 200f;
			TweenCallback onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(s, 0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween warningTween = Tweens.Add(tweenConfig);
			enemy_TP_DeathScytheBig._warningTween = warningTween;
		}

		internal void _003CSingleWarning_003Eb__1()
		{
			UnityEngine.Object.Destroy(s, 0f);
		}
	}

	private float _chaseTimer;

	private bool _hasHit;

	private bool _startedSwing;

	private MultiTargetTween _warningTween;

	private MultiTargetTween _swingTween;

	private MultiTargetTween _swingFadeATween;

	private MultiTargetTween _swingFadeBTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00fb: Expected O, but got I4
		//IL_008c: Expected O, but got I
		//IL_0186: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_0247;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v37 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v37 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v37 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj = -3;
					bool flag2 = obj == null;
					flag = flag2;
				}
				if (!flag)
				{
					goto IL_00eb;
				}
			}
			CharacterController characterController = FindBestPlayerTarget();
			if ((object)characterController != null)
			{
				Transform targetTransform = characterController.transform;
				base._targetTransform = targetTransform;
				goto IL_00eb;
			}
		}
		goto IL_0247;
		IL_00eb:
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		BaseBody baseBody = body;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		if (body != null)
		{
			baseBody._immovable = true;
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
				Sprite sprite = default(Sprite);
				ArcadeSprite arcadeSprite2 = setFrame(sprite);
				BaseBody baseBody3 = body;
				if (body != null && baseBody3._transform != null)
				{
					float2 float5 = default(float2);
					baseBody3._transform.setOrigin(float5);
					_chaseTimer = 0f;
					_hasHit = false;
					ArcadeSprite arcadeSprite3 = setAlpha(1f);
					CoherenceSync targetTransform2 = (CoherenceSync)(object)base._targetTransform;
					if ((object)base._targetTransform != null)
					{
						bool flag3 = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)targetTransform2).m_CachedPtr, out Vector3 ret);
						float2 float6 = base.position;
						bool flag4 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6);
						object obj2 = (object)ret - (object)float6;
						bool flag5 = obj2 == null;
						bool flag6 = !flag4;
						bool flag7 = !flag5;
						bool flag8 = flag7 & flag6;
						ArcadeSprite arcadeSprite4 = setFlipX(flag8);
						return;
					}
				}
			}
		}
		goto IL_0247;
		IL_0247:
		throw new NullReferenceException();
	}

	private unsafe CharacterController FindBestPlayerTarget()
	{
		//IL_0039: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._mainCharacters != null)
		{
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				CharacterController characterController = null;
				List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if ((object)GM.Core != null)
			{
				return GM.Core.PlayerOne;
			}
		}
		throw new NullReferenceException();
	}

	protected override void Die()
	{
	}

	public override void Disappear()
	{
		base.Disappear();
	}

	public void Cleanup()
	{
		if (_swingTween != null)
		{
			_swingTween.Kill();
		}
		if (_warningTween != null)
		{
			_warningTween.Kill();
		}
		if (_swingFadeATween != null)
		{
			_swingFadeATween.Kill();
		}
		if (_swingFadeBTween != null)
		{
			_swingFadeBTween.Kill();
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	protected override void OnUpdate()
	{
		//IL_008c: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_0116: Expected I, but got O
		//IL_014d: Expected F4, but got O
		//IL_015d: Expected F4, but got I
		//IL_0184: Invalid comparison between F4 and I4
		//IL_03df: Expected O, but got F4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		float2 point = base.position;
		if (s_scene._renderer.IsInPlayableScreenBounds(point))
		{
			float deltaTime = PauseSystem.DeltaTime;
			float chaseTimer = deltaTime + _chaseTimer;
			_chaseTimer = chaseTimer;
		}
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setDepth(4000);
		float num = _chaseTimer + _chaseTimer;
		float num2 = num + base._003CSpeed_003Ek__BackingField;
		RetargetIfNecessary();
		float2 float5 = SwingTargetPos();
		float2 float6 = base.position;
		object obj = float5 - float6;
		nint num3 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v17 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num4 = 0;
		object obj2 = obj * obj;
		float num5 = 1.0569646E+09f * 1.0569646E+09f;
		float num6 = (float)float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v15 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		float num7 = 0f;
		float num8 = (float)obj2 + num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		bool flag = num8 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001876C4166h\"");
		if (!flag)
		{
			float num9 = num2 * 0.01f;
			float num10 = (float)obj / num8;
			float num11 = 1.0569646E+09f / num8;
			num6 = num10 * num9;
			num7 = num11 * num9;
			if (_chaseTimer > 2f)
			{
				num6 *= 4f;
				num7 *= 4f;
			}
		}
		GameObject gameObject = _owner;
		Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
		if (_startedSwing)
		{
			gameObject = (GameObject)(object)typeof(UnityEngine.Object);
			if ((object)component != null)
			{
				bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				gameObject = (GameObject)(object)typeof(UnityEngine.Object);
				if (!flag2)
				{
					bool flag3 = component._isDirecterDead;
					gameObject = (GameObject)(object)typeof(UnityEngine.Object);
					if (!flag3)
					{
						num6 *= 16f;
						num7 *= 16f;
						gameObject = (GameObject)(object)typeof(UnityEngine.Object);
					}
				}
			}
		}
		float num12 = num7 * num7;
		float num13 = num6 * num6;
		float num14 = num12 + num13;
		Enemy_TP_Death component2 = gameObject.GetComponent<Enemy_TP_Death>();
		float num15 = 1.0569646E+09f * 1.0569646E+09f;
		object obj3 = obj * obj;
		float num16 = (float)obj3 + num15;
		Enemy_TP_Death component3 = gameObject.GetComponent<Enemy_TP_Death>();
		float num17 = num16 * 60f;
		if (num14 > num17)
		{
			num6 = (float)obj * 60f;
			num7 = 1.0569646E+09f * 60f;
		}
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && component.body != null)
		{
			BaseBody baseBody2 = component.body;
			num6 += (float)baseBody2._velocity;
			float num18 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v664 @ rax_v34 (BaseBody)+74]");
			num7 = num18 + 0f;
		}
		BaseBody baseBody3 = body;
		baseBody3._velocity = (float2)num6;
		if (0.1f > num8 && _chaseTimer > 3f && !_startedSwing)
		{
			CharacterController component4 = base._targetTransform.GetComponent<CharacterController>();
			if (!component4._isDead && !component4.IsDisconnectedFromOnlinePlay)
			{
				_startedSwing = true;
				_chaseTimer = 0f;
				DoSwing();
			}
		}
	}

	private float2 SwingTargetPos()
	{
		Transform targetTransform = base._targetTransform;
		bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 _);
		if (base.flipX)
		{
		}
		float2 result = default(float2);
		return result;
	}

	private void DoSwing()
	{
		//IL_0042: Expected I, but got O
		//IL_017d: Expected O, but got I4
		//IL_0035->IL00f6: Incompatible stack heights: 1 vs 0
		//IL_0087->IL00f6: Incompatible stack heights: 2 vs 0
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 _);
			float2 float5 = default(float2);
			SingleWarning(float5);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				bool flag2 = obj == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.duration = 1000f;
					if (base.flipX)
					{
					}
					tweenConfig.angle = (float?)(object)1;
					tweenConfig.rotateMode = RotateMode.FastBeyond360;
					TweenCallback onComplete = delegate
					{
						//IL_0033: Expected F4, but got I4
						//IL_007b: Expected I, but got O
						//IL_0147: Expected O, but got I4
						float? volume = default(float?);
						float rate = default(float);
						float detune = default(float);
						bool loop = default(bool);
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Attack1, 0f, 10, 0f, volume, rate, detune, loop, 1f);
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if ((object)this != null)
						{
							nint num2 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj2 = default(object);
							if (obj2 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig2.targets = array2;
						tweenConfig2.duration = 100f;
						bool flag3 = base.flipX;
						if (!base.flipX)
						{
							tweenConfig2.angle = (float?)(object)1;
							tweenConfig2.rotateMode = RotateMode.FastBeyond360;
							TweenCallback onComplete2 = delegate
							{
								//IL_004f: Expected O, but got I4
								//IL_00bc: Expected O, but got I4
								//IL_0511: Expected I, but got O
								//IL_0575: Expected O, but got I4
								//IL_05eb: Expected I, but got O
								//IL_064f: Expected O, but got I4
								//IL_066a: Expected I, but got O
								//IL_020f: Invalid comparison between F4 and O
								//IL_0494: Expected I, but got O
								//IL_04a4: Expected O, but got I
								_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass15_0();
								PhaserWorld instance = PhaserWorld.Instance;
								float2 float6 = base.position;
								Vector2 vector = default(Vector2);
								PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "ThosePeople", "New folder-p_sgami00_p098");
								PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.5f);
								PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
								int num3 = base.depth;
								int num4 = num3 - 1;
								PhaserSprite phaserSprite4 = phaserSprite3.setDepth(num4);
								bool flag4 = base.flipX;
								PhaserSprite slash = phaserSprite4.setFlipX(flag4);
								CS_0024_003C_003E8__locals4.slash = slash;
								object obj3 = 0;
								CharacterController component = base._targetTransform.GetComponent<CharacterController>();
								bool flag5 = (object)component == null;
								Vector2 vector2 = vector;
								float num5 = 2f;
								if (!flag5)
								{
									bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
									vector2 = vector;
									num5 = 2f;
									if (!flag6)
									{
										Enemy_TP_Death component2 = _owner.GetComponent<Enemy_TP_Death>();
										bool flag7 = (object)component2 == null;
										vector2 = vector;
										num5 = 2f;
										if (!flag7)
										{
											bool flag8 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
											vector2 = vector;
											num5 = 2f;
											if (!flag8)
											{
												bool flag9 = ((EnemyController)component2)._003CIsDead_003Ek__BackingField;
												vector2 = vector;
												num5 = 2f;
												if (!flag9)
												{
													bool flag10 = !component2._isDirecterDead;
													Vector2 vector3 = vector;
													float num6 = 2f;
													if (!flag10)
													{
														float2 float7 = SwingTargetPos();
														float2 float8 = base.position;
														object obj5 = default(object);
														object obj6 = default(object);
														object obj4 = obj5 - obj6;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850046E0");
														bool flag11 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2f) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
														vector3 = vector;
														num6 = 0.2f;
														vector2 = vector;
														num5 = 0.2f;
														if (flag11)
														{
															goto IL_04cc;
														}
													}
													bool flag12 = _hasHit;
													vector2 = vector3;
													num5 = num6;
													if (!flag12)
													{
														bool flag13 = base._003CIsDead_003Ek__BackingField;
														vector2 = vector3;
														num5 = num6;
														if (!flag13)
														{
															_hasHit = true;
															base._003CIsDead_003Ek__BackingField = true;
															bool flag14 = component._isDead;
															vector2 = vector3;
															num5 = num6;
															if (!flag14)
															{
																bool isDisconnectedFromOnlinePlay = component.IsDisconnectedFromOnlinePlay;
																vector2 = vector3;
																num5 = num6;
																if (!isDisconnectedFromOnlinePlay)
																{
																	Enemy_TP_Death component3 = _owner.GetComponent<Enemy_TP_Death>();
																	if (component3._isDirecterDead)
																	{
																		nint num7 = (nint)component;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1333 @ rax_v90 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+600]");
																		obj3 = 0;
																		bool damaged = component.GetDamaged(20f);
																		vector2 = vector3;
																		num5 = 20f;
																	}
																	else
																	{
																		DeathFightDirecter directer = component3._directer;
																		if ((object)component3._directer != null && ((UnityEngine.Object)directer).m_CachedPtr != (IntPtr)0)
																		{
																			if (component3._003CDirecterRevivals_003Ek__BackingField >= 2)
																			{
																				Enemy_TP_Death component4 = _owner.GetComponent<Enemy_TP_Death>();
																				DeathFightDirecter._003C_BlockCutscene_003Ed__40 obj7 = null;
																				obj7._003C_003E1__state = 0;
																				obj7._003C_003E4__this = component4._directer;
																				Coroutine coroutine = component4._directer.StartCoroutine(obj7);
																				GameObject obj8 = CS_0024_003C_003E8__locals4.slash.gameObject;
																				UnityEngine.Object.Destroy(obj8, 0f);
																				return;
																			}
																			KillAndDirecterRevives();
																			vector2 = vector3;
																			num5 = num6;
																		}
																		else if (component3._003CHasRemovedWeapons_003Ek__BackingField)
																		{
																			KillAndDirecterRevives();
																			SummonDirecter();
																			vector2 = vector3;
																			num5 = num6;
																		}
																		else
																		{
																			component3._003CHasRemovedWeapons_003Ek__BackingField = true;
																			RemoveAllWeaponsFromEachPlayer();
																			RemoveAllFollowers();
																			GiveEveryoneWhipsBecauseWhyNot();
																			vector2 = vector3;
																			num5 = num6;
																		}
																	}
																}
															}
														}
													}
													goto IL_06f2;
												}
											}
										}
										goto IL_04cc;
									}
								}
								goto IL_06f2;
								IL_04cc:
								_hasHit = true;
								base._003CIsDead_003Ek__BackingField = true;
								goto IL_06f2;
								IL_06f2:
								TweenConfig tweenConfig3 = new TweenConfig();
								object[] array3 = new object[1];
								if ((object)CS_0024_003C_003E8__locals4.slash != null)
								{
									nint num8 = (nint)array3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj9 = default(object);
									if (obj9 == null)
									{
										ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
										throw ex2;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig3.targets = array3;
								tweenConfig3.duration = 1000f;
								tweenConfig3.alpha = (float?)(object)1;
								TweenCallback onComplete3 = delegate
								{
									GameObject obj11 = CS_0024_003C_003E8__locals4.slash.gameObject;
									UnityEngine.Object.Destroy(obj11, 0f);
								};
								tweenConfig3.onComplete = onComplete3;
								MultiTargetTween swingFadeATween = Tweens.Add(tweenConfig3);
								_swingFadeATween = swingFadeATween;
								TweenConfig tweenConfig4 = new TweenConfig();
								object[] array4 = new object[1];
								nint num9 = (nint)array4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj10 = default(object);
								if (obj10 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig4.targets = array4;
									tweenConfig4.duration = 1000f;
									tweenConfig4.alpha = (float?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_DeathScytheBig>)+3A0]");
									TweenCallback onComplete4 = new TweenCallback(this, (IntPtr)0);
									nint num10 = (nint)this;
									tweenConfig4.onComplete = onComplete4;
									MultiTargetTween swingFadeBTween = Tweens.Add(tweenConfig4);
									_swingFadeBTween = swingFadeBTween;
									return;
								}
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							};
							tweenConfig2.onComplete = onComplete2;
						}
						MultiTargetTween swingTween2 = Tweens.Add(tweenConfig2);
						_swingTween = swingTween2;
					};
					tweenConfig.onComplete = onComplete;
					MultiTargetTween swingTween = Tweens.Add(tweenConfig);
					_swingTween = swingTween;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SingleWarning(float2 position)
	{
		//IL_0055: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		//IL_01ee: Expected O, but got F4
		//IL_012a: Expected I, but got O
		//IL_018a: Expected O, but got I4
		//IL_014d->IL014d: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "UI", "ExclamationMark");
		PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
		PhaserSprite s = phaserSprite2.setDepth(9000);
		CS_0024_003C_003E8__locals9.s = s;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float detune = (float)vector * 500f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = CS_0024_003C_003E8__locals9.s.transform;
		if ((object)transform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			bool flag = obj2 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_003e: Expected I, but got O
			//IL_0094: Expected O, but got I4
			Enemy_TP_DeathScytheBig enemy_TP_DeathScytheBig = CS_0024_003C_003E8__locals9._003C_003E4__this;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Transform transform2 = CS_0024_003C_003E8__locals9.s.transform;
			if ((object)transform2 != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.scale = (float?)(object)1;
			tweenConfig2.duration = 200f;
			tweenConfig2.delay = 200f;
			TweenCallback onComplete2 = CS_0024_003C_003E8__locals9._003C_003E9__1;
			if (CS_0024_003C_003E8__locals9._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals9._003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals9.s, 0f);
				});
			}
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween warningTween2 = Tweens.Add(tweenConfig2);
			enemy_TP_DeathScytheBig._warningTween = warningTween2;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween warningTween = Tweens.Add(tweenConfig);
		_warningTween = warningTween;
	}

	private bool DoHit(CharacterController player)
	{
		//IL_0271: Expected I4, but got O
		if (!_hasHit && !base._003CIsDead_003Ek__BackingField)
		{
			_hasHit = true;
			base._003CIsDead_003Ek__BackingField = true;
			if ((object)player != null)
			{
				if (player._isDead || player.IsDisconnectedFromOnlinePlay)
				{
					goto IL_01e1;
				}
				if ((object)_owner != null)
				{
					Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
					if ((object)component != null)
					{
						if (component._isDirecterDead)
						{
							bool damaged = player.GetDamaged(20f);
							return true;
						}
						DeathFightDirecter directer = component._directer;
						if ((object)component._directer == null || ((UnityEngine.Object)directer).m_CachedPtr == (IntPtr)0)
						{
							if (component._003CHasRemovedWeapons_003Ek__BackingField)
							{
								KillAndDirecterRevives();
								SummonDirecter();
								return true;
							}
							component._003CHasRemovedWeapons_003Ek__BackingField = true;
							RemoveAllWeaponsFromEachPlayer();
							RemoveAllFollowers();
							GiveEveryoneWhipsBecauseWhyNot();
							return true;
						}
						if (component._003CDirecterRevivals_003Ek__BackingField < 2)
						{
							KillAndDirecterRevives();
							goto IL_01e1;
						}
						if ((object)_owner != null)
						{
							Enemy_TP_Death component2 = _owner.GetComponent<Enemy_TP_Death>();
							if ((object)component2 != null && (object)component2._directer != null)
							{
								DeathFightDirecter._003C_BlockCutscene_003Ed__40 obj = null;
								obj._003C_003E1__state = 0;
								obj._003C_003E4__this = component2._directer;
								Coroutine coroutine = component2._directer.StartCoroutine(obj);
								return false;
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_01e1;
		IL_01e1:
		return true;
	}

	public override void OnPlayerOverlap(CharacterController player)
	{
	}

	private void SummonDirecter()
	{
		Action onComplete = delegate
		{
			Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
			component.SummonDirecter();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void RemoveAllWeaponsFromEachPlayer()
	{
		//IL_0098: Expected O, but got Ref
		//IL_093b: Expected F4, but got I4
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list2._002Ector();
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._mainCharacters != null)
		{
			List<CharacterController>.Enumerator mainCharacters = (List<CharacterController>.Enumerator)core._mainCharacters;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Crystal12, 0f, 10, 0f, volume, rate, detune, loop, 1f);
			Action onComplete = _003C_003Ec._003C_003E9__20_0;
			if (_003C_003Ec._003C_003E9__20_0 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__20_0 = delegate
				{
					//IL_0013: Expected O, but got I4
					GameManager core2 = GM.Core;
					List<CharacterController>.Enumerator enumerator3 = default(List<CharacterController>.Enumerator);
					if (!enumerator3.MoveNext())
					{
						return;
					}
					object obj = 0;
					throw new NullReferenceException();
				});
			}
			if ((object)GM.Core != null)
			{
				GM.Core.FrameFreeze(onComplete, 240f);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void GiveEveryoneWhipsBecauseWhyNot()
	{
		//IL_001e: Expected I, but got O
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				nint num = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v11 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num2 = 0;
				GameManager core = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				Weapon weapon = core._weaponsFacade.AddWeapon(WeaponType.WHIP, null, removeFromStore: false);
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void RemoveAllFollowers()
	{
		//IL_001d: Expected O, but got Ref
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			CharacterController characterController = null;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private unsafe void KillAndUseUpRevivals()
	{
		//IL_003d: Expected O, but got Ref
		//IL_0242: Expected F4, but got I4
		//IL_0274: Expected F4, but got I4
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			CharacterController characterController = null;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Glass01, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Haha, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		SummonDirecter();
	}

	private unsafe void KillAndDirecterRevives()
	{
		//IL_0039: Expected O, but got Ref
		//IL_01f4: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._characters != null)
		{
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				CharacterController characterController = null;
				EggDouble eggDouble = (EggDouble)(&enumerator);
				throw new NullReferenceException();
			}
			if ((object)_owner != null)
			{
				Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
				if ((object)component != null)
				{
					int num = component._003CDirecterRevivals_003Ek__BackingField + 1;
					component._003CDirecterRevivals_003Ek__BackingField = num;
					if ((object)_owner != null)
					{
						Enemy_TP_Death component2 = _owner.GetComponent<Enemy_TP_Death>();
						if ((object)component2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object arg = default(object);
							System.ParamsArray paramsArray = new System.ParamsArray(arg);
							System.ParamsArray paramsArray2 = default(System.ParamsArray);
							string message = string.FormatHelper((IFormatProvider)null, "Adding Directer Revival: {0}", (System.ParamsArray)(&paramsArray2));
							Debug.Log(message);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void BlockByDirecter()
	{
		Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
		DeathFightDirecter._003C_BlockCutscene_003Ed__40 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = component._directer;
		Coroutine coroutine = component._directer.StartCoroutine(obj);
	}

	private void _003CDoSwing_003Eb__15_0()
	{
		//IL_0033: Expected F4, but got I4
		//IL_007b: Expected I, but got O
		//IL_0147: Expected O, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Attack1, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
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
		tweenConfig.duration = 100f;
		bool flag = base.flipX;
		if (!base.flipX)
		{
			tweenConfig.angle = (float?)(object)1;
			tweenConfig.rotateMode = RotateMode.FastBeyond360;
			TweenCallback onComplete = delegate
			{
				//IL_004f: Expected O, but got I4
				//IL_00bc: Expected O, but got I4
				//IL_0511: Expected I, but got O
				//IL_0575: Expected O, but got I4
				//IL_05eb: Expected I, but got O
				//IL_064f: Expected O, but got I4
				//IL_066a: Expected I, but got O
				//IL_020f: Invalid comparison between F4 and O
				//IL_0494: Expected I, but got O
				//IL_04a4: Expected O, but got I
				_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass15_0();
				PhaserWorld instance = PhaserWorld.Instance;
				float2 float5 = base.position;
				Vector2 vector = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "ThosePeople", "New folder-p_sgami00_p098");
				PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.5f);
				PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
				int num2 = base.depth;
				int num3 = num2 - 1;
				PhaserSprite phaserSprite4 = phaserSprite3.setDepth(num3);
				bool flag2 = base.flipX;
				PhaserSprite slash = phaserSprite4.setFlipX(flag2);
				CS_0024_003C_003E8__locals4.slash = slash;
				object obj2 = 0;
				CharacterController component = base._targetTransform.GetComponent<CharacterController>();
				bool flag3 = (object)component == null;
				Vector2 vector2 = vector;
				float num4 = 2f;
				if (!flag3)
				{
					bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					vector2 = vector;
					num4 = 2f;
					if (!flag4)
					{
						Enemy_TP_Death component2 = _owner.GetComponent<Enemy_TP_Death>();
						bool flag5 = (object)component2 == null;
						vector2 = vector;
						num4 = 2f;
						if (!flag5)
						{
							bool flag6 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
							vector2 = vector;
							num4 = 2f;
							if (!flag6)
							{
								bool flag7 = ((EnemyController)component2)._003CIsDead_003Ek__BackingField;
								vector2 = vector;
								num4 = 2f;
								if (!flag7)
								{
									bool flag8 = !component2._isDirecterDead;
									Vector2 vector3 = vector;
									float num5 = 2f;
									if (!flag8)
									{
										float2 float6 = SwingTargetPos();
										float2 float7 = base.position;
										object obj4 = default(object);
										object obj5 = default(object);
										object obj3 = obj4 - obj5;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850046E0");
										bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2f) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
										vector3 = vector;
										num5 = 0.2f;
										vector2 = vector;
										num4 = 0.2f;
										if (flag9)
										{
											goto IL_04cc;
										}
									}
									bool flag10 = _hasHit;
									vector2 = vector3;
									num4 = num5;
									if (!flag10)
									{
										bool flag11 = base._003CIsDead_003Ek__BackingField;
										vector2 = vector3;
										num4 = num5;
										if (!flag11)
										{
											_hasHit = true;
											base._003CIsDead_003Ek__BackingField = true;
											bool flag12 = component._isDead;
											vector2 = vector3;
											num4 = num5;
											if (!flag12)
											{
												bool isDisconnectedFromOnlinePlay = component.IsDisconnectedFromOnlinePlay;
												vector2 = vector3;
												num4 = num5;
												if (!isDisconnectedFromOnlinePlay)
												{
													Enemy_TP_Death component3 = _owner.GetComponent<Enemy_TP_Death>();
													if (component3._isDirecterDead)
													{
														nint num6 = (nint)component;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1333 @ rax_v90 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+600]");
														obj2 = 0;
														bool damaged = component.GetDamaged(20f);
														vector2 = vector3;
														num4 = 20f;
													}
													else
													{
														DeathFightDirecter directer = component3._directer;
														if ((object)component3._directer != null && ((UnityEngine.Object)directer).m_CachedPtr != (IntPtr)0)
														{
															if (component3._003CDirecterRevivals_003Ek__BackingField >= 2)
															{
																Enemy_TP_Death component4 = _owner.GetComponent<Enemy_TP_Death>();
																DeathFightDirecter._003C_BlockCutscene_003Ed__40 obj6 = null;
																obj6._003C_003E1__state = 0;
																obj6._003C_003E4__this = component4._directer;
																Coroutine coroutine = component4._directer.StartCoroutine(obj6);
																GameObject obj7 = CS_0024_003C_003E8__locals4.slash.gameObject;
																UnityEngine.Object.Destroy(obj7, 0f);
																return;
															}
															KillAndDirecterRevives();
															vector2 = vector3;
															num4 = num5;
														}
														else if (component3._003CHasRemovedWeapons_003Ek__BackingField)
														{
															KillAndDirecterRevives();
															SummonDirecter();
															vector2 = vector3;
															num4 = num5;
														}
														else
														{
															component3._003CHasRemovedWeapons_003Ek__BackingField = true;
															RemoveAllWeaponsFromEachPlayer();
															RemoveAllFollowers();
															GiveEveryoneWhipsBecauseWhyNot();
															vector2 = vector3;
															num4 = num5;
														}
													}
												}
											}
										}
									}
									goto IL_06f2;
								}
							}
						}
						goto IL_04cc;
					}
				}
				goto IL_06f2;
				IL_04cc:
				_hasHit = true;
				base._003CIsDead_003Ek__BackingField = true;
				goto IL_06f2;
				IL_06f2:
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)CS_0024_003C_003E8__locals4.slash != null)
				{
					nint num7 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					if (obj8 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 1000f;
				tweenConfig2.alpha = (float?)(object)1;
				TweenCallback onComplete2 = delegate
				{
					GameObject obj10 = CS_0024_003C_003E8__locals4.slash.gameObject;
					UnityEngine.Object.Destroy(obj10, 0f);
				};
				tweenConfig2.onComplete = onComplete2;
				MultiTargetTween swingFadeATween = Tweens.Add(tweenConfig2);
				_swingFadeATween = swingFadeATween;
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				nint num8 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					tweenConfig3.duration = 1000f;
					tweenConfig3.alpha = (float?)(object)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_DeathScytheBig>)+3A0]");
					TweenCallback onComplete3 = new TweenCallback(this, (IntPtr)0);
					nint num9 = (nint)this;
					tweenConfig3.onComplete = onComplete3;
					MultiTargetTween swingFadeBTween = Tweens.Add(tweenConfig3);
					_swingFadeBTween = swingFadeBTween;
					return;
				}
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			};
			tweenConfig.onComplete = onComplete;
		}
		MultiTargetTween swingTween = Tweens.Add(tweenConfig);
		_swingTween = swingTween;
	}

	private void _003CDoSwing_003Eb__15_1()
	{
		//IL_004f: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_0511: Expected I, but got O
		//IL_0575: Expected O, but got I4
		//IL_05eb: Expected I, but got O
		//IL_064f: Expected O, but got I4
		//IL_066a: Expected I, but got O
		//IL_020f: Invalid comparison between F4 and O
		//IL_0494: Expected I, but got O
		//IL_04a4: Expected O, but got I
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass15_0();
		PhaserWorld instance = PhaserWorld.Instance;
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "ThosePeople", "New folder-p_sgami00_p098");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.5f);
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
		int num = base.depth;
		int num2 = num - 1;
		PhaserSprite phaserSprite4 = phaserSprite3.setDepth(num2);
		bool flag = base.flipX;
		PhaserSprite slash = phaserSprite4.setFlipX(flag);
		CS_0024_003C_003E8__locals4.slash = slash;
		object obj = 0;
		CharacterController component = base._targetTransform.GetComponent<CharacterController>();
		bool flag2 = (object)component == null;
		Vector2 vector2 = vector;
		float num3 = 2f;
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			vector2 = vector;
			num3 = 2f;
			if (!flag3)
			{
				Enemy_TP_Death component2 = _owner.GetComponent<Enemy_TP_Death>();
				bool flag4 = (object)component2 == null;
				vector2 = vector;
				num3 = 2f;
				if (!flag4)
				{
					bool flag5 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					vector2 = vector;
					num3 = 2f;
					if (!flag5)
					{
						bool flag6 = ((EnemyController)component2)._003CIsDead_003Ek__BackingField;
						vector2 = vector;
						num3 = 2f;
						if (!flag6)
						{
							bool flag7 = !component2._isDirecterDead;
							Vector2 vector3 = vector;
							float num4 = 2f;
							if (!flag7)
							{
								float2 float6 = SwingTargetPos();
								float2 float7 = base.position;
								object obj3 = default(object);
								object obj4 = default(object);
								object obj2 = obj3 - obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850046E0");
								bool flag8 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2f) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
								vector3 = vector;
								num4 = 0.2f;
								vector2 = vector;
								num3 = 0.2f;
								if (flag8)
								{
									goto IL_04cc;
								}
							}
							bool flag9 = _hasHit;
							vector2 = vector3;
							num3 = num4;
							if (!flag9)
							{
								bool flag10 = base._003CIsDead_003Ek__BackingField;
								vector2 = vector3;
								num3 = num4;
								if (!flag10)
								{
									_hasHit = true;
									base._003CIsDead_003Ek__BackingField = true;
									bool flag11 = component._isDead;
									vector2 = vector3;
									num3 = num4;
									if (!flag11)
									{
										bool isDisconnectedFromOnlinePlay = component.IsDisconnectedFromOnlinePlay;
										vector2 = vector3;
										num3 = num4;
										if (!isDisconnectedFromOnlinePlay)
										{
											Enemy_TP_Death component3 = _owner.GetComponent<Enemy_TP_Death>();
											if (component3._isDirecterDead)
											{
												nint num5 = (nint)component;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1333 @ rax_v90 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+600]");
												obj = 0;
												bool damaged = component.GetDamaged(20f);
												vector2 = vector3;
												num3 = 20f;
											}
											else
											{
												DeathFightDirecter directer = component3._directer;
												if ((object)component3._directer != null && ((UnityEngine.Object)directer).m_CachedPtr != (IntPtr)0)
												{
													if (component3._003CDirecterRevivals_003Ek__BackingField >= 2)
													{
														Enemy_TP_Death component4 = _owner.GetComponent<Enemy_TP_Death>();
														DeathFightDirecter._003C_BlockCutscene_003Ed__40 obj5 = null;
														obj5._003C_003E1__state = 0;
														obj5._003C_003E4__this = component4._directer;
														Coroutine coroutine = component4._directer.StartCoroutine(obj5);
														GameObject obj6 = CS_0024_003C_003E8__locals4.slash.gameObject;
														UnityEngine.Object.Destroy(obj6, 0f);
														return;
													}
													KillAndDirecterRevives();
													vector2 = vector3;
													num3 = num4;
												}
												else if (component3._003CHasRemovedWeapons_003Ek__BackingField)
												{
													KillAndDirecterRevives();
													SummonDirecter();
													vector2 = vector3;
													num3 = num4;
												}
												else
												{
													component3._003CHasRemovedWeapons_003Ek__BackingField = true;
													RemoveAllWeaponsFromEachPlayer();
													RemoveAllFollowers();
													GiveEveryoneWhipsBecauseWhyNot();
													vector2 = vector3;
													num3 = num4;
												}
											}
										}
									}
								}
							}
							goto IL_06f2;
						}
					}
				}
				goto IL_04cc;
			}
		}
		goto IL_06f2;
		IL_04cc:
		_hasHit = true;
		base._003CIsDead_003Ek__BackingField = true;
		goto IL_06f2;
		IL_06f2:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals4.slash != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			GameObject obj9 = CS_0024_003C_003E8__locals4.slash.gameObject;
			UnityEngine.Object.Destroy(obj9, 0f);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween swingFadeATween = Tweens.Add(tweenConfig);
		_swingFadeATween = swingFadeATween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num7 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj8 = default(object);
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 1000f;
			tweenConfig2.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_DeathScytheBig>)+3A0]");
			TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
			nint num8 = (nint)this;
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween swingFadeBTween = Tweens.Add(tweenConfig2);
			_swingFadeBTween = swingFadeBTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void _003CSummonDirecter_003Eb__19_0()
	{
		Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
		component.SummonDirecter();
	}
}
