using System;
using System.Collections.Generic;
using Coherence;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Props;

public class PropFoscariSeal2 : Destructible
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__14_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnDestroyed_003Eb__14_2()
		{
			ProCamera2D instance = ProCamera2D.Instance;
			instance.RemoveAllCameraTargets(0.5f);
			GM.Core.AddAllPlayersAsCameraTargets(0.5f);
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
		//IL_0112: Expected O, but got I4
		//IL_0136: Expected O, but got I4
		//IL_0136: Expected O, but got I4
		//IL_0208: Expected I, but got O
		//IL_0288: Expected I4, but got I8
		//IL_02a4: Expected O, but got I4
		//IL_0376: Expected F4, but got O
		base.Init(destructibleType);
		base._003CIsStationary_003Ek__BackingField = true;
		_spriteAnimation.CleanAnimations();
		PropData propData = _propData;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(propData._003CframeName_003Ek__BackingField, 1, 4, propData._003CtextureName_003Ek__BackingField, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 4, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PropData propData2 = _propData;
		string animName = propData2._003CframeName_003Ek__BackingField + "d_";
		PropData propData3 = _propData;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName, 0, 19, propData3._003CtextureName_003Ek__BackingField, num);
		_spriteAnimation.AddAnimation("destroy", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(38f, (float?)(object)1, (float?)(object)1);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			_destructibleRenderer.sortingOrder = renderer.pixelHeight;
			if (_floatTween != null)
			{
				_floatTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				nint num2 = (nint)array;
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
			float2 float5 = base.position;
			tweenConfig.duration = 1000f;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.repeat = -1;
			tweenConfig.yoyo = true;
			tweenConfig.y = (float?)(object)1;
			MultiTargetTween floatTween = Tweens.Add(tweenConfig);
			_floatTween = floatTween;
			if (GM.Core.HasCharacterInPlay(CharacterType.VICTOR))
			{
				if (_mapToken == null)
				{
					MapToken mapToken = new MapToken();
					_mapToken = mapToken;
					GameManager core = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
				}
				MapToken mapToken2 = _mapToken;
				float2 float6 = base.position;
				mapToken2.x = (float)float6;
				MapToken mapToken3 = _mapToken;
				float2 float7 = base.position;
				mapToken3.y = 0.08f;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVFX, float knockbackMul, WeaponType damageType, bool hasKnockback = true)
	{
		//IL_00fc: Expected O, but got I4
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0194: Expected O, but got I4
		//IL_01d5: Invalid comparison between I4 and F4
		//IL_027a: Expected I8, but got O
		//IL_0289: Expected I8, but got O
		object obj = default(object);
		if (_isDead || !GM.Core.HasCharacterInPlay(CharacterType.VICTOR) || (nint)obj != 139)
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
		if (obj5 != null)
		{
			return;
		}
		float2 float6 = base.position;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		bool flag5 = (nint)s_scene2._renderer < 0;
		bool flag6 = s_scene2._renderer == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A106C8h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj6 = flag8 & flag7;
		if (obj6 == null)
		{
			return;
		}
		if (0f < (_hp -= value))
		{
			OnGetDamaged(showHitVFX);
		}
		else if (GM.Core.IsStageHost)
		{
			_isDead = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				OnDestroyed();
				return;
			}
			Action<long> action = null;
			((PropFoscariSeal2)(object)action).DestroySeal((long)this);
			((PropFoscariSeal2)(object)action).DestroySeal((long)this);
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+370]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal2>)+370]");
		action._002Ector(this, (IntPtr)0);
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, action);
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setTint(16777215u);
	}

	private void KillIt()
	{
		OnDestroyed();
	}

	protected unsafe override void OnDestroyed()
	{
		//IL_00a6: Expected I, but got O
		//IL_00bf: Expected I4, but got O
		//IL_00c9: Expected I4, but got O
		//IL_00d6: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_014e: Expected O, but got I
		//IL_016f: Expected F4, but got I4
		//IL_0177: Expected F4, but got I4
		//IL_02ba: Expected F4, but got I4
		//IL_02c2: Expected F4, but got I4
		//IL_02fa: Expected I, but got O
		//IL_033e: Expected F4, but got I4
		//IL_0354: Expected O, but got I
		//IL_037e: Expected I, but got O
		//IL_03c2: Expected F4, but got I4
		//IL_03d8: Expected O, but got I
		//IL_041f: Expected F4, but got I4
		//IL_0461: Expected I, but got O
		//IL_04a5: Expected F4, but got I4
		//IL_04bb: Expected O, but got I
		//IL_050b: Expected F4, but got I4
		//IL_0521: Expected O, but got I
		//IL_056b: Expected F4, but got I4
		//IL_0581: Expected O, but got I
		//IL_0c26: Expected F4, but got I4
		//IL_0615: Expected F4, but got I4
		//IL_06b7: Expected I, but got O
		//IL_06cd: Expected O, but got I
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		//IL_077c: Expected F4, but got I4
		//IL_071f: Expected I, but got I8
		//IL_0797: Expected I, but got I8
		//IL_0c5d: Expected I, but got O
		//IL_0c78: Expected O, but got I4
		//IL_0c8f: Expected I, but got I8
		//IL_0cbd: Expected I4, but got F4
		//IL_073a: Expected I, but got I8
		//IL_0747: Expected I, but got I8
		//IL_07a9: Expected I, but got O
		//IL_07bf: Expected O, but got I
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Expected O, but got Unknown
		//IL_086f: Expected I, but got O
		//IL_0d39: Expected I, but got I8
		//IL_0d67: Expected I4, but got F4
		//IL_0dae: Expected I, but got I8
		//IL_0eba: Expected I4, but got F4
		//IL_08ad: Expected I, but got O
		//IL_08c3: Expected O, but got I
		//IL_08cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d1: Expected O, but got Unknown
		//IL_089b: Expected I, but got I8
		//IL_0e1f: Expected I4, but got F4
		//IL_0932: Expected I, but got O
		//IL_0947: Expected O, but got I
		//IL_09dd: Expected O, but got I
		//IL_09e2: Expected I4, but got O
		//IL_0a11: Expected I, but got O
		//IL_0a67: Expected O, but got I
		//IL_0a6b: Expected I4, but got O
		//IL_0a78: Expected O, but got I
		//IL_0ac7: Expected O, but got I
		//IL_0acb: Expected I4, but got O
		if (_alreadyDestroyed)
		{
			return;
		}
		PlayerOptions playerOptions = _playerOptions;
		float num12 = default(float);
		Vector2 vector = default(Vector2);
		Action action2;
		bool flag;
		Action<float> action;
		float num16;
		float num5;
		float num3;
		float num4;
		nint num14;
		if (_playerOptions != null)
		{
			_playerOptions.IncreaseDestroyedPropCount(VampireSurvivors.Data.PropType.FOSCARI_SEAL_2);
			if (_floatTween != null)
			{
				_floatTween.Kill();
			}
			_alreadyDestroyed = true;
			ArcadeSprite arcadeSprite = setVisible(visible: true);
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			flag = (byte)(int)GM.Core != 0;
			bool flag2 = (byte)(int)(~GM.Core) != 0;
			action = null;
			playerOptions = (PlayerOptions)num2;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ r9_v2 (System.Boolean)+3C0]");
				flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ r9_v2 (System.Boolean)+3C0]");
				bool flag3 = (byte)(~(nuint)0u) != 0;
				action = null;
				playerOptions = (PlayerOptions)num2;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ r9_v2 (System.Boolean)+18]");
					flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ r9_v2 (System.Boolean)+18]");
					bool flag4 = (byte)(~(nuint)0u) != 0;
					action = null;
					playerOptions = (PlayerOptions)num2;
					if (!flag4)
					{
						action = null;
						HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
						if (enumerator.MoveNext())
						{
							num3 = 0f;
							num4 = (flag ? 1 : 0);
							Component component = null;
							throw new NullReferenceException();
						}
						SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 1500f);
						ProCamera2D instance = ProCamera2D.Instance;
						bool flag5 = (object)instance == null;
						num5 = 1500f;
						num3 = 0f;
						num4 = (flag ? 1 : 0);
						flag = false;
						playerOptions = null;
						if (!flag5)
						{
							instance.RemoveAllCameraTargets(2f);
							nint num6 = (nint)typeof(GM);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ rax_v40 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
							nint num7 = 0;
							GameManager core = GM.Core;
							bool flag6 = (object)GM.Core == null;
							num5 = 1500f;
							num3 = 2f;
							num4 = 0f;
							flag = false;
							action = null;
							playerOptions = (PlayerOptions)num7;
							if (!flag6)
							{
								core._003CCanInterrupt_003Ek__BackingField = false;
								nint num8 = (nint)typeof(GM);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1237 @ rax_v42 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
								nint num9 = 0;
								GameManager core2 = GM.Core;
								bool flag7 = (object)GM.Core == null;
								num5 = 1500f;
								num3 = 2f;
								num4 = 0f;
								flag = false;
								action = null;
								playerOptions = (PlayerOptions)num9;
								if (!flag7)
								{
									core2._003CCanPause_003Ek__BackingField = false;
									bool flag8 = (object)GM.Core == null;
									num5 = 1500f;
									num3 = 2f;
									num4 = 0f;
									flag = false;
									action = null;
									playerOptions = (PlayerOptions)(object)GM.Core;
									if (!flag8)
									{
										GM.Core.TogglePlayerHealthBar(visible: false);
										nint num10 = (nint)typeof(GM);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v46 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
										nint num11 = 0;
										GameManager core3 = GM.Core;
										bool flag9 = (object)GM.Core == null;
										num5 = 1500f;
										num3 = 2f;
										num4 = 0f;
										flag = false;
										action = null;
										playerOptions = (PlayerOptions)num11;
										if (!flag9)
										{
											core3._canRunTickerTimer = false;
											GameManager core4 = GM.Core;
											bool flag10 = (object)GM.Core == null;
											num5 = 1500f;
											num3 = 2f;
											num4 = 0f;
											flag = false;
											action = null;
											playerOptions = (PlayerOptions)num11;
											if (!flag10)
											{
												Stage stage = core4._stage;
												bool flag11 = (object)core4._stage == null;
												num5 = 1500f;
												num3 = 2f;
												num4 = 0f;
												flag = false;
												action = null;
												playerOptions = (PlayerOptions)num11;
												if (!flag11)
												{
													if (stage._spawnTimer != null)
													{
														stage._spawnTimer.Cancel();
													}
													bool flag12 = (object)GM.Core == null;
													num5 = 1500f;
													num3 = 2f;
													num4 = (flag ? 1 : 0);
													flag = false;
													action = null;
													playerOptions = (PlayerOptions)(object)GM.Core;
													if (!flag12)
													{
														GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
														ProCamera2D instance2 = ProCamera2D.Instance;
														Transform targetTransform = base.transform;
														bool flag13 = (object)instance2 == null;
														num5 = 1500f;
														num3 = 30000f;
														num4 = 0f;
														flag = false;
														action = null;
														playerOptions = null;
														if (!flag13)
														{
															Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance2.AddCameraTarget(targetTransform, 1f, 1f, num12, vector);
															action2 = null;
															nint num13 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v778 @ r10_v9 (Il2CppMethodInfo)+8]");
															((Delegate)action2).method_ptr = (IntPtr)0;
															((Delegate)action2).method = (nint)__ldftn(PropFoscariSeal2._003COnDestroyed_003Eb__14_0);
															((Delegate)action2).m_target = this;
															flag = false;
															action = null;
															((Delegate)action2).method_code = (IntPtr)action2;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v778 @ r10_v9 (Il2CppMethodInfo)+4C]");
															object obj = (nint)0 >> 4;
															object obj2 = obj & 1;
															nint num15;
															if (obj2 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v778 @ r10_v9 (Il2CppMethodInfo)+52]");
																bool flag14 = (nint)0 != 0;
																num14 = unchecked((nint)6447293664L);
																if (!flag14)
																{
																	num14 = unchecked((nint)6447293664L);
																	num15 = unchecked((nint)6447293664L);
																	goto IL_0c6f;
																}
															}
															else
															{
																bool flag15 = (object)this == null;
																num16 = 1f;
																num5 = 1f;
																num3 = 30000f;
																num4 = 0f;
																if (flag15)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
																	object obj3 = default(object);
																	throw obj3;
																}
																num14 = unchecked((nint)6447293664L);
															}
															((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
															num15 = ((Delegate)action2).method_ptr;
															goto IL_0c6f;
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
		goto IL_0b4c;
		IL_0b4c:
		throw new NullReferenceException();
		IL_0ddf:
		Action action3;
		nint extra_arg;
		((Delegate)action3).extra_arg = extra_arg;
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(10f, action3, null, isLooped: false, (byte)(int)num12 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		playerOptions = (PlayerOptions)(object)GM.Core;
		bool flag16 = (object)GM.Core == null;
		num16 = 1f;
		num5 = 1f;
		num3 = 30000f;
		num4 = 10f;
		flag = false;
		action = null;
		if (!flag16)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v16 (VampireSurvivors.Objects.PlayerOptions)+200]");
			playerOptions = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v16 (VampireSurvivors.Objects.PlayerOptions)+200]");
			bool flag17 = (nint)0 == 0;
			num16 = 1f;
			num5 = 1f;
			num3 = 30000f;
			num4 = 10f;
			flag = false;
			action = null;
			if (!flag17)
			{
				if (playerOptions.PowerUpPurchased == null)
				{
					return;
				}
				nint num18 = default(nint);
				int num17 = Array.IndexOf((object[])(object)playerOptions.RunGoldUpdated, _mapToken, 0, (int)((PlayerOptions)num18).PowerUpPurchased);
				if (num17 == -1)
				{
					return;
				}
				nint num19 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1761 @ rax_v89 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				num18 = 0;
				GameManager core5 = GM.Core;
				bool flag18 = (object)GM.Core == null;
				num16 = 1f;
				num5 = 1f;
				num3 = 30000f;
				num4 = 10f;
				flag = (byte)(int)((PlayerOptions)num18).PowerUpPurchased != 0;
				action = null;
				playerOptions = (PlayerOptions)num18;
				if (!flag18)
				{
					bool flag19 = core5._mapTokens == null;
					num16 = 1f;
					num5 = 1f;
					num3 = 30000f;
					num4 = 10f;
					flag = (byte)(int)((PlayerOptions)num18).PowerUpPurchased != 0;
					action = null;
					playerOptions = (PlayerOptions)(object)core5._mapTokens;
					if (!flag19)
					{
						bool flag20 = ((List<object>)(object)core5._mapTokens).Remove((object)_mapToken);
						return;
					}
				}
			}
		}
		goto IL_0b4c;
		IL_0c6f:
		object obj4 = 24;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(2f, action2, null, isLooped: false, (byte)(int)num12 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action action4 = null;
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ r10_v10 (Il2CppMethodInfo)+8]");
		((Delegate)action4).method_ptr = (IntPtr)0;
		((Delegate)action4).method = (nint)__ldftn(PropFoscariSeal2._003COnDestroyed_003Eb__14_1);
		((Delegate)action4).m_target = this;
		flag = false;
		action = null;
		((Delegate)action4).method_code = (IntPtr)action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ r10_v10 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		IntPtr intPtr;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ r10_v10 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				intPtr = num14;
				goto IL_0d22;
			}
		}
		else
		{
			bool flag21 = (object)this == null;
			num16 = 1f;
			num5 = 1f;
			num3 = 30000f;
			num4 = 2f;
			if (flag21)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
				object obj7 = default(object);
				throw obj7;
			}
		}
		((Delegate)action4).method_code = (IntPtr)((Delegate)action4).m_target;
		intPtr = ((Delegate)action4).method_ptr;
		goto IL_0d22;
		IL_0d22:
		((Delegate)action4).extra_arg = unchecked((nint)6447293568L);
		Timer timer3 = Timers.Register(5f, action4, null, isLooped: false, (byte)(int)num12 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete = _003C_003Ec._003C_003E9__14_2;
		bool flag22 = _003C_003Ec._003C_003E9__14_2 != null;
		extra_arg = unchecked((nint)6447293568L);
		if (!flag22)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_2 = delegate
			{
				ProCamera2D instance3 = ProCamera2D.Instance;
				instance3.RemoveAllCameraTargets(0.5f);
				GM.Core.AddAllPlayersAsCameraTargets(0.5f);
			});
			extra_arg = unchecked((nint)6447293568L);
		}
		Timer timer4 = Timers.Register(7.0000005f, onComplete, null, isLooped: false, (byte)(int)num12 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		action3 = null;
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r10_v11 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(PropFoscariSeal2._003COnDestroyed_003Eb__14_3);
		((Delegate)action3).m_target = this;
		flag = false;
		action = null;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r10_v11 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r10_v11 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				goto IL_0ddf;
			}
		}
		else
		{
			bool flag23 = (object)this == null;
			num16 = 1f;
			num5 = 1f;
			num3 = 30000f;
			num4 = 7.0000005f;
			if (flag23)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
				object obj10 = default(object);
				throw obj10;
			}
		}
		num14 = ((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_0ddf;
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

	public PropFoscariSeal2()
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

	private void _003COnDestroyed_003Eb__14_1()
	{
		//IL_003b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.25f;
		SoundManager.PlayMusic(BgmType.TheEndIndeed, soundConfig);
		ScreenShake(312);
	}

	private void _003COnDestroyed_003Eb__14_3()
	{
		Action action = _003CDestroyedCallback_003Ek__BackingField;
		if (_003CDestroyedCallback_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v30.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = true;
		GM.Core.TogglePlayerHealthBar(visible: true);
		GameManager core3 = GM.Core;
		core3._canRunTickerTimer = true;
		GameManager core4 = GM.Core;
		core4._stage.StartTimers();
	}

	private void _003CScreenShake_003Eb__15_0()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		followOffset.x = -2f;
	}

	private void _003CScreenShake_003Eb__15_1()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		followOffset.x = 0f;
		followOffset.y = 0f;
	}
}
