using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Props;

public class PropFoscariSeal1 : Destructible
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__15_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CChangeStage_003Eb__15_0()
		{
			//IL_00db: Expected I8, but got O
			//IL_00f0: Expected O, but got I
			//IL_0098: Expected O, but got I8
			//IL_00bf: Expected O, but got I
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				GM.Core.TransitionToFoscari2();
			}
			else if (GM.Core.IsStageHost)
			{
				long num = (long)OnlineStageManager._instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (System.Int64)+88]");
				object obj = 0;
				(string, object)[] array = Array.Empty<(string, object)>();
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v63 @ r10_v2+1E8] (should have been resolved before IL gen)");
				Action<long> action = null;
				((OnlineStageManager)(object)action).TransitionToFoscari2(num);
				long startingOnlineClientFrame = ((OnlineStageManager)num).GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (System.Int64)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		}
	}

	private bool _alreadyDestroyed;

	private MultiTargetTween _floatTween;

	private PhaserSprite _sDarkness;

	private PhaserSprite _sFog;

	public MeshRenderer magicWaterImage;

	private MapToken _mapToken;

	public override void Awake()
	{
		//IL_0072: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		base.Awake();
		_alreadyDestroyed = false;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = (float)renderer.pixelWidth + 2f;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(num, (float?)(object)1);
		PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
		PhaserSprite component = phaserSprite4.setDepth(6001);
		PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component, 0f);
		PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
		GameObject gameObject = phaserSprite6.gameObject;
		((UnityEngine.Object)gameObject).SetName("Darkness");
		_sDarkness = phaserSprite6;
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite7 = instance2.AddPhaserSprite(pos, "vfx", "fog");
		PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(0f, (float?)(object)0);
		float xScale = num / 160f;
		PhaserSprite phaserSprite9 = phaserSprite8.setScale(xScale, (float?)(object)1);
		PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(0f);
		PhaserSprite component2 = phaserSprite10.setDepth(3001);
		PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor(component2, 0f);
		PhaserSprite phaserSprite12 = phaserSprite11.setVisible(visible: false);
		GameObject gameObject2 = phaserSprite12.gameObject;
		((UnityEngine.Object)gameObject2).SetName("Fog");
		_sFog = phaserSprite12;
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
			if (GM.Core.HasCharacterInPlay(CharacterType.KEIRA))
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
		if (_isDead || !GM.Core.HasCharacterInPlay(CharacterType.KEIRA) || (nint)obj != 136)
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
			((PropFoscariSeal1)(object)action).DestroySeal((long)this);
			((PropFoscariSeal1)(object)action).DestroySeal((long)this);
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+370]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Props.PropFoscariSeal1>)+370]");
		action._002Ector(this, (IntPtr)0);
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, action);
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setTint(16777215u);
	}

	protected unsafe override void OnDestroyed()
	{
		//IL_00ed: Expected I, but got O
		//IL_0171: Expected I, but got O
		//IL_0183: Expected I, but got O
		//IL_0199: Expected O, but got I4
		//IL_01a1: Expected O, but got Ref
		//IL_0a21: Expected I4, but got F4
		//IL_0a6e: Expected I4, but got F4
		//IL_0ab6: Expected I4, but got F4
		//IL_0b03: Expected I4, but got F4
		if (_alreadyDestroyed)
		{
			return;
		}
		_isDead = true;
		if (_playerOptions != null)
		{
			_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
			_alreadyDestroyed = true;
			ArcadeSprite arcadeSprite = setVisible(visible: true);
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				core._003CCanInterrupt_003Ek__BackingField = false;
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					core2._003CCanPause_003Ek__BackingField = false;
					List<WeaponType> list = new List<WeaponType>();
					nint num = (nint)typeof(BackgroundFoscari2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rcx_v30 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFoscari2>)+E4]");
					bool flag = (nint)0 != 0;
					list._002Ector();
					BackgroundFoscari2.s_hasFallenFromFoscari1 = true;
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null && core3._characters != null)
					{
						nint num2 = unchecked((nint)null);
						nint num3 = (nint)core3._characters;
						List<WeaponType> list2 = list;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj = 0;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null)
						{
							core4._canRunTickerTimer = false;
							GameManager core5 = GM.Core;
							if ((object)GM.Core != null)
							{
								Stage stage = core5._stage;
								if ((object)core5._stage != null)
								{
									if (stage._spawnTimer != null)
									{
										stage._spawnTimer.Cancel();
									}
									GameManager core6 = GM.Core;
									if ((object)GM.Core != null)
									{
										PhysicsGroup enemies = core6.Enemies;
										if (core6.Enemies != null && ((Group)enemies).children != null)
										{
											HashSet<object>.Enumerator enumerator3 = default(HashSet<object>.Enumerator);
											if (enumerator3.MoveNext())
											{
												CoherenceSync coherenceSync = null;
												throw new NullReferenceException();
											}
											if ((object)GM.Core != null)
											{
												GM.Core.TogglePlayerHealthBar(visible: false);
												SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 1500f);
												float2 float5 = base.position;
												if ((object)GM.Core != null)
												{
													Vector2 center = default(Vector2);
													GM.Core.StopCamera(center, 2f);
													if ((object)GM.Core != null)
													{
														GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
														ProCamera2D instance = ProCamera2D.Instance;
														Transform targetTransform = base.transform;
														if ((object)instance != null)
														{
															float num4 = default(float);
															Vector2 vector = default(Vector2);
															Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.AddCameraTarget(targetTransform, 1f, 1f, num4, vector);
															Action onComplete = delegate
															{
																//IL_00ae: Expected O, but got I4
																//IL_00ca: Expected O, but got F4
																//IL_007d: Expected O, but got I4
																SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																soundConfig.Volume = (float?)(object)1;
																soundConfig.Rate = 1f;
																object obj2 = UnityEngine.Random.value;
																object obj3 = default(object);
																float detune = (float)obj3 * -600f;
																soundConfig.Detune = detune;
																float time = default(float);
																PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
																GM.Core.FrameFreeze();
																ScreenShake();
																SpriteAnimation spriteAnimation = _spriteAnimation;
																((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
																ArcadeSprite arcadeSprite2 = setScale(2f, (float?)(object)0);
																_spriteAnimation.SetAnimation("destroy");
															};
															int repeat = default(int);
															TimerType type = default(TimerType);
															Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
															Action onComplete2 = delegate
															{
																ScreenShake(625);
															};
															Timer timer2 = Timers.Register(5f, onComplete2, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
															Action onComplete3 = delegate
															{
																RemoveWater();
															};
															Timer timer3 = Timers.Register(6.0000005f, onComplete3, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
															Action onComplete4 = delegate
															{
																ChangeStage();
															};
															Timer timer4 = Timers.Register(15.000001f, onComplete4, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
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
		throw new NullReferenceException();
	}

	private void ShakeEarth()
	{
		ScreenShake(625);
	}

	private void RemoveWater()
	{
		//IL_02a0: Expected O, but got I4
		//IL_00e0: Expected I, but got O
		//IL_0164: Expected I, but got O
		//IL_01d2: Expected O, but got I4
		//IL_0332: Expected O, but got I4
		//IL_039d: Expected O, but got I4
		//IL_034c->IL026f: Incompatible stack heights: 1 vs 0
		//IL_024e->IL026f: Incompatible stack heights: 1 vs 0
		//IL_026f->IL02c9: Incompatible stack heights: 2 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.25f;
		soundConfig.Volume = (float?)(object)1;
		SoundManager.PlayMusic(BgmType.TheEndIndeed, soundConfig);
		MeshRenderer meshRenderer = magicWaterImage;
		if ((object)magicWaterImage == null || ((UnityEngine.Object)meshRenderer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)magicWaterImage != null)
		{
			Transform transform = magicWaterImage.transform;
			if (array != null)
			{
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
				if ((object)magicWaterImage != null)
				{
					Material material = ((Renderer)magicWaterImage).GetMaterial();
					if ((object)material != null)
					{
						nint num2 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						if (obj2 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						tweenConfig.alpha = (float?)(object)1;
						if ((object)magicWaterImage != null)
						{
							Transform transform2 = magicWaterImage.transform;
							if ((object)transform2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v40 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v40 (UnityEngine.Transform)+10]");
								Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
								tweenConfig.scaleX = (float?)(object)1;
								if ((object)magicWaterImage != null)
								{
									Transform transform3 = magicWaterImage.transform;
									if ((object)transform3 != null)
									{
										bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
										tweenConfig.duration = 4000f;
										tweenConfig.scaleY = (float?)(object)1;
										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
										return;
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

	private void ChangeStage()
	{
		//IL_035e: Expected O, but got I4
		//IL_00fb: Expected I, but got O
		//IL_0153: Expected I, but got O
		//IL_01ae: Expected I4, but got O
		//IL_0328: Expected I4, but got F4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Scream, soundConfig, 0f, 10, num);
		if ((object)_sFog != null)
		{
			PhaserSprite phaserSprite = _sFog.setVisible(visible: true);
			if ((object)_sDarkness != null)
			{
				PhaserSprite phaserSprite2 = _sDarkness.setVisible(visible: true);
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[2];
				if (array != null)
				{
					if ((object)_sFog != null)
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
					if ((object)_sDarkness != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						if (obj2 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						((SoundManager.SoundConfig)(object)tweenConfig).Mute = (byte)(int)array != 0;
						_ = 1140457472;
						_ = 1;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						ProCamera2D instance = ProCamera2D.Instance;
						Transform targetTransform = base.transform;
						if ((object)instance != null)
						{
							instance.RemoveCameraTarget(targetTransform, 0.5f);
							GameObject gameObject = new GameObject();
							GameObject.Internal_CreateGameObject(gameObject, (string)null);
							if ((object)gameObject != null)
							{
								Transform transform = gameObject.transform;
								Camera main = Camera.main;
								if ((object)main != null)
								{
									Transform transform2 = main.transform;
									if ((object)transform2 != null)
									{
										bool flag = (byte)(~(((SoundManager.SoundConfig)(object)transform2).Mute ? 1u : 0u)) != 0;
										Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform2).Mute ? 1 : 0), out Vector3 _);
										bool flag2 = (object)transform == null;
										bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
										ProCamera2D instance2 = ProCamera2D.Instance;
										bool flag4 = (object)instance2 == null;
										Vector2 vector = default(Vector2);
										Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance2.AddCameraTarget(transform, 1f, 1f, num, vector);
										Action onComplete = _003C_003Ec._003C_003E9__15_0;
										if (_003C_003Ec._003C_003E9__15_0 == null)
										{
											onComplete = (_003C_003Ec._003C_003E9__15_0 = delegate
											{
												//IL_00db: Expected I8, but got O
												//IL_00f0: Expected O, but got I
												//IL_0098: Expected O, but got I8
												//IL_00bf: Expected O, but got I
												GameManager core = GM.Core;
												if (!core._multiplayer.IsOnlineMultiplayer)
												{
													GM.Core.TransitionToFoscari2();
												}
												else if (GM.Core.IsStageHost)
												{
													long num4 = (long)OnlineStageManager._instance;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (System.Int64)+88]");
													object obj3 = 0;
													(string, object)[] array2 = Array.Empty<(string, object)>();
													object obj4 = obj3;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v63 @ r10_v2+1E8] (should have been resolved before IL gen)");
													Action<long> action = null;
													((OnlineStageManager)(object)action).TransitionToFoscari2(num4);
													long startingOnlineClientFrame = ((OnlineStageManager)num4).GetStartingOnlineClientFrame();
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (System.Int64)+78]");
													bool flag5 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
												}
											});
										}
										int repeat = default(int);
										TimerType type = default(TimerType);
										Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
										return;
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

	private void EditorBreakSeal()
	{
		OnDestroyed();
	}

	public PropFoscariSeal1()
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

	private void _003COnDestroyed_003Eb__12_0()
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

	private void _003COnDestroyed_003Eb__12_1()
	{
		ScreenShake(625);
	}

	private void _003COnDestroyed_003Eb__12_2()
	{
		RemoveWater();
	}

	private void _003COnDestroyed_003Eb__12_3()
	{
		ChangeStage();
	}

	private void _003CScreenShake_003Eb__16_0()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		followOffset.x = -2f;
	}

	private void _003CScreenShake_003Eb__16_1()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		followOffset.x = 0f;
		followOffset.y = 0f;
	}
}
