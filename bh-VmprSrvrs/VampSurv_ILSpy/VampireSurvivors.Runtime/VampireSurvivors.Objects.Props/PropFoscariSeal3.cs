using System;
using System.Collections.Generic;
using Coherence;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Props;

public class PropFoscariSeal3 : Destructible
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static DOGetter<float> _003C_003E9__14_1;

		public static DOSetter<float> _003C_003E9__14_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003COnDestroyed_003Eb__14_1()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003COnDestroyed_003Eb__14_2(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}
	}

	private bool _alreadyDestroyed;

	private MultiTargetTween _floatTween;

	private MapToken _mapToken;

	private Action _003CDestroyedCallback_003Ek__BackingField;

	public Action DestroyedCallback
	{
		get
		{
			return _003CDestroyedCallback_003Ek__BackingField;
		}
		set
		{
			_003CDestroyedCallback_003Ek__BackingField = value;
		}
	}

	public override void Awake()
	{
		base.Awake();
		_alreadyDestroyed = false;
	}

	public override void Init(PropType destructibleType)
	{
		//IL_0194: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_0291: Expected I, but got O
		//IL_0325: Expected I4, but got I8
		//IL_0341: Expected O, but got I4
		//IL_0486: Expected F4, but got O
		//IL_0267->IL04cc: Incompatible stack heights: 1 vs 0
		//IL_02d6->IL04cc: Incompatible stack heights: 1 vs 0
		//IL_02b4->IL02b4: Incompatible stack heights: 2 vs 1
		//IL_037b->IL04cc: Incompatible stack heights: 1 vs 0
		//IL_0474->IL04cc: Incompatible stack heights: 1 vs 0
		//IL_04b4->IL04cc: Incompatible stack heights: 1 vs 0
		//IL_040f->IL04cc: Incompatible stack heights: 1 vs 0
		//IL_0431->IL04cc: Incompatible stack heights: 1 vs 0
		base.Init(destructibleType);
		base._003CIsStationary_003Ek__BackingField = true;
		if ((object)_spriteAnimation != null)
		{
			_spriteAnimation.CleanAnimations();
			PropData propData = _propData;
			if (_propData != null)
			{
				int num = default(int);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(propData._003CframeName_003Ek__BackingField, 1, 4, propData._003CtextureName_003Ek__BackingField, num);
				if ((object)_spriteAnimation != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					_spriteAnimation.AddAnimation("idle", animationFrames, 4, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					PropData propData2 = _propData;
					if (_propData != null)
					{
						string animName = propData2._003CframeName_003Ek__BackingField + "d_";
						PropData propData3 = _propData;
						if (_propData != null)
						{
							List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName, 0, 19, propData3._003CtextureName_003Ek__BackingField, num);
							if ((object)_spriteAnimation != null)
							{
								_spriteAnimation.AddAnimation("destroy", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
								ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
								if (body != null)
								{
									BaseBody baseBody = body.setCircle(38f, (float?)(object)1, (float?)(object)1);
									string destructibleRenderer = (string)(object)_destructibleRenderer;
									if ((object)_destructibleRenderer != null)
									{
										bool flag = destructibleRenderer._stringLength == 0;
										Renderer.set_sortingOrder_Injected((IntPtr)destructibleRenderer._stringLength, 2000);
										if (_floatTween != null)
										{
											_floatTween.Kill();
										}
										TweenConfig tweenConfig = new TweenConfig();
										object[] array = new object[1];
										Transform transform = base.transform;
										if (array != null)
										{
											if ((object)transform != null)
											{
												nint num2 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj = default(object);
												bool flag2 = obj == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig != null)
											{
												tweenConfig.targets = array;
												float2 float5 = base.position;
												tweenConfig.duration = 1000f;
												tweenConfig.ease = Ease.InOutSine;
												tweenConfig.repeat = -1;
												tweenConfig.yoyo = true;
												tweenConfig.y = (float?)(object)1;
												MultiTargetTween floatTween = Tweens.Add(tweenConfig);
												_floatTween = floatTween;
												if ((object)GM.Core != null)
												{
													if (!GM.Core.HasCharacterInPlay(CharacterType.ELEANOR))
													{
														return;
													}
													if (_mapToken == null)
													{
														MapToken mapToken = new MapToken();
														_mapToken = mapToken;
														GameManager core = GM.Core;
														if ((object)GM.Core == null || core._mapTokens == null)
														{
															goto IL_04cc;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
													}
													MapToken mapToken2 = _mapToken;
													float2 float6 = base.position;
													if (_mapToken != null)
													{
														mapToken2.x = (float)float6;
														MapToken mapToken3 = _mapToken;
														float2 float7 = base.position;
														if (_mapToken != null)
														{
															mapToken3.y = 0.08f;
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
		goto IL_04cc;
		IL_04cc:
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
	}

	public override void GetDamaged(float value, HitVfxType showHitVFX, float knockbackMul, WeaponType damageType, bool hasKnockback = true)
	{
		//IL_00fc: Expected O, but got I4
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0213: Invalid comparison between I4 and F4
		//IL_0194: Expected O, but got I4
		//IL_02b8: Expected I8, but got O
		//IL_02c7: Expected I8, but got O
		object obj = default(object);
		if (_isDead || !GM.Core.HasCharacterInPlay(CharacterType.ELEANOR) || (nint)obj != 127)
		{
			return;
		}
		float2 float5 = base.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		object obj2 = (object)s_scene._renderer ^ (object)s_scene._renderer;
		object obj3 = (object)s_scene._renderer & obj2;
		bool flag = (nint)obj3 < 0;
		bool flag2 = (nint)s_scene._renderer < 0;
		bool flag3 = s_scene._renderer == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A106C8h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag4 = flag2 == flag;
		object obj4 = !flag4;
		object obj5 = obj4 | flag3;
		if (obj5 == null)
		{
			float2 float6 = base.position;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			bool flag5 = (nint)s_scene2._renderer < 0;
			bool flag6 = s_scene2._renderer == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A106C8h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			bool flag7 = !flag5;
			bool flag8 = !flag6;
			object obj6 = flag8 & flag7;
			if (obj6 != null)
			{
				goto IL_01ef;
			}
		}
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			goto IL_01ef;
		}
		return;
		IL_01ef:
		if (0f < (_hp -= value))
		{
			OnGetDamaged(showHitVFX);
		}
		else if (GM.Core.IsStageHost)
		{
			_isDead = true;
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				OnDestroyed();
				return;
			}
			Action<long> action = null;
			((PropFoscariSeal3)(object)action).DestroySeal((long)this);
			((PropFoscariSeal3)(object)action).DestroySeal((long)this);
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
			bool flag9 = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	public override void RemoteDestroy()
	{
		_hp = 0f;
		_isDead = true;
		Despawn();
	}

	public void DestroySeal(long startingSimFrame)
	{
		//IL_000a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+370]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal3>)+370]");
		action._002Ector(this, (IntPtr)0);
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, action);
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setTint(16777215u);
	}

	protected unsafe override void OnDestroyed()
	{
		//IL_0194: Expected F4, but got I4
		//IL_069a: Expected I, but got O
		//IL_06b0: Expected O, but got I
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Expected O, but got Unknown
		//IL_075f: Expected F4, but got I4
		//IL_0702: Expected I, but got I8
		//IL_077a: Expected I, but got I8
		//IL_0a30: Expected I, but got O
		//IL_0a4b: Expected O, but got I4
		//IL_0a62: Expected I, but got I8
		//IL_0a90: Expected I4, but got F4
		//IL_071d: Expected I, but got I8
		//IL_072a: Expected I, but got I8
		//IL_0b24: Expected I, but got O
		//IL_0afb: Expected O, but got I
		//IL_0817: Expected I, but got O
		//IL_082d: Expected O, but got I
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Expected O, but got Unknown
		//IL_0b78: Expected I, but got I8
		//IL_0ba6: Expected I4, but got F4
		//IL_089c: Expected I, but got O
		if (_alreadyDestroyed)
		{
			return;
		}
		float num4 = default(float);
		Vector2 vector2 = default(Vector2);
		Action action;
		bool flag17;
		bool flag2;
		nint num6;
		if (_playerOptions != null)
		{
			_playerOptions.IncreaseDestroyedPropCount(VampireSurvivors.Data.PropType.FOSCARI_SEAL_3);
			if (_floatTween != null)
			{
				_floatTween.Kill();
			}
			_alreadyDestroyed = true;
			ArcadeSprite arcadeSprite = setVisible(visible: true);
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			flag2 = false;
			if (!flag)
			{
				bool flag3 = core._playerOptions == null;
				flag2 = false;
				if (!flag3)
				{
					core._playerOptions.Save();
					GameManager core2 = GM.Core;
					bool flag4 = (object)GM.Core == null;
					flag2 = false;
					if (!flag4)
					{
						core2 = (GameManager)(object)core2.Enemies;
						bool flag5 = core2.Enemies == null;
						flag2 = false;
						if (!flag5)
						{
							core2 = (GameManager)(object)((MonoBehaviour)core2).m_CancellationTokenSource;
							bool flag6 = ((MonoBehaviour)core2).m_CancellationTokenSource == null;
							flag2 = false;
							if (!flag6)
							{
								flag2 = false;
								HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
								HashSet<object>.Enumerator enumerator2;
								float num;
								if (enumerator.MoveNext())
								{
									num = 0f;
									enumerator2 = (HashSet<object>.Enumerator)core2;
									Component component = null;
									throw new NullReferenceException();
								}
								SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 1500f);
								float2 float5 = base.position;
								bool flag7 = (object)GM.Core == null;
								float num2 = 1500f;
								float num3 = default(float);
								num = num3;
								enumerator2 = (HashSet<object>.Enumerator)core2;
								core2 = null;
								if (!flag7)
								{
									Vector2 vector = default(Vector2);
									GM.Core.StopCamera(vector, 2f);
									GameManager core3 = GM.Core;
									bool flag8 = (object)GM.Core == null;
									num2 = 2f;
									num = num3;
									enumerator2 = (HashSet<object>.Enumerator)vector;
									core2 = null;
									if (!flag8)
									{
										core3._003CCanInterrupt_003Ek__BackingField = false;
										GameManager core4 = GM.Core;
										bool flag9 = (object)GM.Core == null;
										num2 = 2f;
										num = num3;
										enumerator2 = (HashSet<object>.Enumerator)vector;
										core2 = null;
										if (!flag9)
										{
											core4._003CCanPause_003Ek__BackingField = false;
											bool flag10 = (object)GM.Core == null;
											num2 = 2f;
											num = num3;
											enumerator2 = (HashSet<object>.Enumerator)vector;
											core2 = null;
											if (!flag10)
											{
												GM.Core.TogglePlayerHealthBar(visible: false);
												GameManager core5 = GM.Core;
												bool flag11 = (object)GM.Core == null;
												num2 = 2f;
												num = num3;
												enumerator2 = (HashSet<object>.Enumerator)vector;
												core2 = null;
												flag2 = false;
												if (!flag11)
												{
													core5._canRunTickerTimer = false;
													GameManager core6 = GM.Core;
													bool flag12 = (object)GM.Core == null;
													num2 = 2f;
													num = num3;
													enumerator2 = (HashSet<object>.Enumerator)vector;
													core2 = null;
													flag2 = false;
													if (!flag12)
													{
														Stage stage = core6._stage;
														bool flag13 = (object)core6._stage == null;
														num2 = 2f;
														num = num3;
														enumerator2 = (HashSet<object>.Enumerator)vector;
														core2 = null;
														flag2 = false;
														if (!flag13)
														{
															if (stage._spawnTimer != null)
															{
																stage._spawnTimer.Cancel();
															}
															bool flag14 = (object)GM.Core == null;
															num2 = 2f;
															num = num3;
															enumerator2 = (HashSet<object>.Enumerator)vector;
															core2 = null;
															flag2 = false;
															if (!flag14)
															{
																GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
																SpeedupManager instance = SpeedupManager.Instance;
																bool flag15 = instance == null;
																num2 = 2f;
																num = 30000f;
																enumerator2 = (HashSet<object>.Enumerator)vector;
																core2 = null;
																flag2 = false;
																if (!flag15)
																{
																	instance.SetSpeedupBlocked(isBlocked: true);
																	ProCamera2D instance2 = ProCamera2D.Instance;
																	Transform targetTransform = base.transform;
																	bool flag16 = (object)instance2 == null;
																	num2 = 2f;
																	num = 30000f;
																	enumerator2 = (HashSet<object>.Enumerator)vector;
																	core2 = null;
																	flag2 = false;
																	if (!flag16)
																	{
																		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance2.AddCameraTarget(targetTransform, 1f, 1f, num4, vector2);
																		action = null;
																		nint num5 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ r10_v4 (Il2CppMethodInfo)+8]");
																		((Delegate)action).method_ptr = (IntPtr)0;
																		((Delegate)action).method = (nint)__ldftn(PropFoscariSeal3._003COnDestroyed_003Eb__14_0);
																		((Delegate)action).m_target = this;
																		flag17 = false;
																		flag2 = false;
																		((Delegate)action).method_code = (IntPtr)action;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ r10_v4 (Il2CppMethodInfo)+4C]");
																		object obj = (nint)0 >> 4;
																		object obj2 = obj & 1;
																		nint num7;
																		if (obj2 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ r10_v4 (Il2CppMethodInfo)+52]");
																			bool flag18 = (nint)0 != 0;
																			num6 = unchecked((nint)6447293664L);
																			if (!flag18)
																			{
																				num6 = unchecked((nint)6447293664L);
																				num7 = unchecked((nint)6447293664L);
																				goto IL_0a42;
																			}
																		}
																		else
																		{
																			bool flag19 = (object)this == null;
																			float num8 = 1f;
																			num2 = 1f;
																			num = 30000f;
																			float num9 = 0f;
																			if (flag19)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
																				object obj3 = default(object);
																				throw obj3;
																			}
																			num6 = unchecked((nint)6447293664L);
																		}
																		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
																		num7 = ((Delegate)action).method_ptr;
																		goto IL_0a42;
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
		}
		throw new NullReferenceException();
		IL_0b61:
		Action action2;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, action2, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector2, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0a42:
		object obj4 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(2f, action, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector2, repeat, type, isOnlineTimer: false, canPause: false);
		DOGetter<float> getter = _003C_003Ec._003C_003E9__14_1;
		bool flag20 = _003C_003Ec._003C_003E9__14_1 != null;
		Action<float> action3 = null;
		if (!flag20)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__14_1 = dOGetter;
			action3 = (Action<float>)0;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__14_2;
		bool flag21 = _003C_003Ec._003C_003E9__14_2 != null;
		nint num10 = (nint)action3;
		if (!flag21)
		{
			DOSetter<float> dOSetter = null;
			((_003C_003Ec)(object)dOSetter)._003COnDestroyed_003Eb__14_2(30000f);
			_003C_003Ec._003C_003E9__14_2 = dOSetter;
			setter = dOSetter;
			num10 = 0;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.1f, 2.5f);
		action2 = null;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r10_v5 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(PropFoscariSeal3._003COnDestroyed_003Eb__14_3);
		((Delegate)action2).m_target = this;
		flag17 = false;
		flag2 = (byte)num10 != 0;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r10_v5 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r10_v5 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				goto IL_0b61;
			}
		}
		else
		{
			bool flag22 = (object)this == null;
			float num8 = 2.5f;
			float num2 = 0.1f;
			float num = 30000f;
			float num9 = 2f;
			if (flag22)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
				object obj7 = default(object);
				throw obj7;
			}
		}
		num6 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_0b61;
	}

	private void SaveProgress()
	{
		GameManager core = GM.Core;
		core._playerOptions.Save();
	}

	protected void ShakeEarth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x186FE73B0\"");
	}

	private void ScreenShake(int repeats = 6)
	{
		//IL_0058: Expected I, but got O
		//IL_00d7: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
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
		tweenConfig.duration = 16f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset = main2.followOffset;
			followOffset.x = -2f;
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset = main2.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public PropFoscariSeal3()
	{
		//IL_0036: Expected I, but got O
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003COnDestroyed_003Eb__14_0()
	{
		//IL_00ae: Expected O, but got I4
		//IL_00ca: Expected O, but got F4
		//IL_007d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
		GM.Core.FrameFreeze();
		ScreenShake();
		SpriteAnimation spriteAnimation = _spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		_spriteAnimation.SetAnimation("destroy");
	}

	private void _003COnDestroyed_003Eb__14_3()
	{
		if (_003CDestroyedCallback_003Ek__BackingField != null)
		{
			Action action = _003CDestroyedCallback_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void _003CScreenShake_003Eb__17_0()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		followOffset.x = -2f;
	}

	private void _003CScreenShake_003Eb__17_1()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		followOffset.x = 0f;
		followOffset.y = 0f;
	}
}
