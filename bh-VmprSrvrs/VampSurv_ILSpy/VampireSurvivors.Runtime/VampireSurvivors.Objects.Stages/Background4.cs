using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class Background4 : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__37_0;

		public static Action _003C_003E9__43_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CCustomPreload_003Eb__37_0(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.Wind, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCheckPlayerVsBot_003Eb__43_0()
		{
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		}
	}

	private bool _hasSpawnedGuards;

	private bool _stopp;

	private bool _passed;

	private BgmType _saveBgm;

	private Timer _firstEvent;

	private Timer _recurringEvent;

	private MultiTargetTween _randomazzoTween;

	private Transform _spritesRootTransform;

	private readonly List<SpriteRenderer> _allSprites;

	private SpriteRenderer _sBackground;

	private SpriteRenderer _sStars2;

	private SpriteRenderer _sStars1;

	private SpriteRenderer _sPeaks;

	private SpriteRenderer _sMount2;

	private SpriteRenderer _sMist3;

	private SpriteRenderer _sMount1;

	private SpriteRenderer _sFlash;

	private SpriteRenderer _sMist2;

	private SpriteRenderer _sHills;

	private SpriteRenderer _sMist1;

	private SpriteRenderer _sForest;

	private SpriteRenderer _sDarkness;

	private PhaserSprite _sFog;

	private PhaserSprite _sFogExtraA;

	private PhaserSprite _sFogExtraB;

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _pfxEmitter;

	private GravityWell _well;

	private List<RuneStripVfx> _runeStrips;

	private List<RuneStripVfx2> _runeStrips2;

	private const int SortingOrderBackmost = -32768;

	private const float TowerTop = 122.88f;

	private const float Bot = -245.76f;

	private const float Bott = -491.52f;

	protected unsafe override void OnUpdate()
	{
		//IL_024d->IL0184: Incompatible stack heights: 1 vs 0
		//IL_029c->IL0184: Incompatible stack heights: 1 vs 0
		//IL_0324->IL0184: Incompatible stack heights: 2 vs 0
		//IL_03ac->IL0184: Incompatible stack heights: 3 vs 0
		//IL_0434->IL0184: Incompatible stack heights: 4 vs 0
		//IL_04bc->IL0184: Incompatible stack heights: 5 vs 0
		base.OnUpdate();
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core2._gameSessionData;
					if (core2._gameSessionData != null)
					{
						characterController = gameSessionData._activeCharacter;
						goto IL_01d6;
					}
				}
			}
			else if ((object)OnlineStageManager._instance != null)
			{
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				if ((object)myPlayerInfo != null)
				{
					characterController = myPlayerInfo.CharacterController;
					goto IL_01d6;
				}
			}
		}
		goto IL_0184;
		IL_0184:
		throw new NullReferenceException();
		IL_01d6:
		if ((object)characterController != null)
		{
			Transform transform = characterController.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				List<RuneStripVfx> ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				object obj = default(object);
				float prop = (float)obj / 122.88f;
				if (_runeStrips != null)
				{
					List<RuneStripVfx>.Enumerator enumerator = default(List<RuneStripVfx>.Enumerator);
					while (enumerator.MoveNext())
					{
						((RuneStripVfx)null).InternalUpdate(prop);
					}
					object sForest = _sForest;
					if ((object)_sForest != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r15_v15 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r15_v15 (System.Object)+10]");
						SpriteRenderer.get_size_Injected((IntPtr)0, out Vector2 ret2);
						object obj2 = default(object);
						float max = (float)obj2 * 0.4f;
						float prop2 = default(float);
						FixY(_sForest, 0f, max, prop2);
						object sHills = _sHills;
						if ((object)_sHills != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r15_v16 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r15_v16 (System.Object)+10]");
							SpriteRenderer.get_size_Injected((IntPtr)0, out ret2);
							float max2 = (float)obj2 * 0.5f;
							FixY(_sHills, 0f, max2, prop2);
							object sMount = _sMount1;
							if ((object)_sMount1 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r15_v17 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r15_v17 (System.Object)+10]");
								SpriteRenderer.get_size_Injected((IntPtr)0, out ret2);
								float max3 = (float)obj2 * 0.5f;
								FixY(_sMount1, -0.53f, max3, prop2);
								object sMount2 = _sMount2;
								if ((object)_sMount2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r15_v18 (System.Object)+10]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r15_v18 (System.Object)+10]");
									SpriteRenderer.get_size_Injected((IntPtr)0, out ret2);
									float max4 = (float)obj2 * 0.5f;
									FixY(_sMount2, -1.53f, max4, prop2);
									SpriteRenderer sPeaks = _sPeaks;
									if ((object)_sPeaks != null)
									{
										bool flag6 = ((UnityEngine.Object)sPeaks).m_CachedPtr == (IntPtr)0;
										SpriteRenderer.get_size_Injected(((UnityEngine.Object)sPeaks).m_CachedPtr, out ret2);
										float max5 = (float)obj2 * 0.5f;
										FixY(_sPeaks, -2.34f, max5, prop2);
										CheckPlayerVsBot(prop);
										CheckPlayerVsTop();
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0184;
	}

	public override void OnInitCompleted()
	{
		base.OnInitCompleted();
		Action onComplete = delegate
		{
			PlayFlash();
			Action onComplete2 = PlayFlash;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			Timer recurringEvent = TimerHelper.RegisterMillisUI(101048.01f, onComplete2, null, isLooped: true, useRealTime2, autoDestroyOwner2, repeat2);
			_recurringEvent = recurringEvent;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer firstEvent = TimerHelper.RegisterMillisUI(82100f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		_firstEvent = firstEvent;
	}

	protected override void OnDestroy()
	{
		Action<EnemyController> value = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<EnemyController> action = default(Action<EnemyController>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		base.OnDestroy();
	}

	public override void CustomPreload(Action onComplete)
	{
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		Action<Action> loadCall = _003C_003Ec._003C_003E9__37_0;
		if (_003C_003Ec._003C_003E9__37_0 == null)
		{
			loadCall = (_003C_003Ec._003C_003E9__37_0 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.Wind, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall);
		asyncLoader.Load();
	}

	public override void Create()
	{
		base.Create();
		GenerateObjects();
		GenerateParticleSystems();
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		SoundManager.StopSound(SfxType.Wind);
		if (_randomazzoTween != null)
		{
			_randomazzoTween.Kill();
		}
	}

	private unsafe void PlayFlash()
	{
		//IL_0109: Expected O, but got Ref
		//IL_0116: Expected O, but got I8
		//IL_011f: Expected O, but got I4
		//IL_024a: Expected O, but got I
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		//IL_0320: Expected O, but got I
		//IL_0505: Expected O, but got I4
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_1306: Expected O, but got I4
		//IL_1316: Unknown result type (might be due to invalid IL or missing references)
		//IL_131b: Expected O, but got Unknown
		//IL_077a: Expected I, but got O
		//IL_0790: Expected O, but got I
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Expected O, but got Unknown
		//IL_05d0: Expected O, but got I
		//IL_0807: Expected I, but got O
		//IL_109a: Expected I, but got I8
		//IL_07f0: Expected I, but got I8
		//IL_0713: Expected O, but got I
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a9: Expected O, but got Unknown
		//IL_092b: Expected O, but got Ref
		//IL_1215: Expected I, but got O
		//IL_122b: Expected O, but got I
		//IL_1234: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected O, but got Unknown
		//IL_0a2b: Expected O, but got I
		//IL_0c14: Expected I, but got O
		//IL_126d: Expected I, but got I8
		//IL_0ca0: Expected I, but got O
		//IL_0cb6: Expected O, but got I
		//IL_0cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc4: Expected O, but got Unknown
		//IL_0bfd: Expected I, but got I8
		//IL_0d32: Expected I, but got O
		//IL_12a1: Expected I, but got I8
		//IL_0d05: Expected I, but got I8
		//IL_0b6f: Expected O, but got I
		//IL_1059->IL0eb8: Incompatible stack heights: 1 vs 0
		//IL_10d9->IL0eb8: Incompatible stack heights: 1 vs 0
		//IL_08c3->IL10de: Incompatible stack heights: 1 vs 0
		//IL_0961->IL0eb8: Incompatible stack heights: 1 vs 0
		//IL_11de->IL0eb8: Incompatible stack heights: 2 vs 0
		//IL_12d6->IL0eb8: Incompatible stack heights: 2 vs 0
		//IL_0dc8->IL0eb8: Incompatible stack heights: 2 vs 0
		//IL_12f3->IL0eb8: Incompatible stack heights: 2 vs 0
		//IL_0e90->IL0e90: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
				object obj = default(object);
				if ((nint)obj != 6)
				{
					return;
				}
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_sFlash, 0f);
				if ((object)_sFlash != null)
				{
					Transform transform = _sFlash.transform;
					Vector3 vector = Vector3.zeroVector;
					object obj2 = default(object);
					transform.localScale = (Vector3)(&obj2);
					object obj3 = 6603577472L;
					object obj4 = 0;
					object arg = default(object);
					object obj15 = default(object);
					while (true)
					{
						float num = (float)obj4 * 800f;
						float delay = num * 0.001f;
						if ((object)_sFlash == null)
						{
							break;
						}
						Transform target = _sFlash.transform;
						float num2 = (float)obj4 * 8f;
						float num3 = num2 + 24f;
						float endValue = num3 * (1f / 128f);
						TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, endValue, 0.4f);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 2;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
										vector = (Vector3)(num4 + 0);
									}
								}
							}
						}
						TweenerCore<Vector3, Vector3, VectorOptions> gameId = TweenSettingsExtensions.SetEase(tweenerCore, Ease.InOutSine);
						Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
						TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_sFlash, 1f, 0.4f);
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, delay);
						nint num8;
						TweenCallback tweenCallback2;
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 2;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
										vector = (Vector3)(num5 + 0);
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
									bool flag = (nint)0 == 0;
									_ = 0;
									if (!flag)
									{
										object obj5 = tweenerCore2 + 184;
										object obj6 = obj5 >> 12;
										object obj7 = obj6 & 0x1FFFFF;
										object obj8 = obj7 >> 6;
										object obj9 = obj7 & 0x3F;
										nint num7;
										do
										{
											object obj10 = 1 << (int)obj9;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r12_v8+462E0+v1285 @ rdx_v75*8]");
											object obj11 = 0 | obj10;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r12_v8+462E0+v1285 @ rdx_v75*8]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r12_v8+462E0+v1285 @ rdx_v75*8]");
											if (num6 == 0)
											{
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r12_v8+462E0+v1285 @ rdx_v75*8]");
											num7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r12_v8+462E0+v1285 @ rdx_v75*8]");
										}
										while (num7 != 0);
										TweenCallback tweenCallback = delegate
										{
											SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sFlash, 0f);
										};
										tweenCallback2 = tweenCallback;
										num8 = 0;
										goto IL_042e;
									}
								}
							}
						}
						TweenCallback tweenCallback3 = delegate
						{
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sFlash, 0f);
						};
						bool flag2 = tweenerCore2 == null;
						tweenCallback2 = tweenCallback3;
						num8 = 0;
						Vector3 vector2 = vector;
						nint num9 = 0;
						if (!flag2)
						{
							goto IL_042e;
						}
						goto IL_0481;
						IL_042e:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1081 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
						bool flag3 = (nint)0 == 0;
						vector2 = vector;
						num9 = num8;
						if (!flag3)
						{
							vector2 = vector;
							num9 = num8;
						}
						goto IL_0481;
						IL_0481:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore2 == null)
						{
							break;
						}
						obj4++;
						bool flag4 = (nint)obj4 < 4;
						vector = vector2;
						if (flag4)
						{
							continue;
						}
						nint num10 = 24;
						object obj12 = 0;
						while (true)
						{
							object sFlash = _sFlash;
							float num11 = (float)obj12 * 400f;
							float num12 = num11 + 3200f;
							float delay2 = num12 * 0.001f;
							if ((object)_sFlash == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v14 (System.Object)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v14 (System.Object)+10]");
							IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
							Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScale(target2, 0.25f, 0.2f);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t3, delay2);
							if (tweenerCore3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v47 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v47 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 2;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v47 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v47 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
											nint num13 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v47 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
											vector2 = (Vector3)(num13 + 0);
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v47 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 4;
										_ = 0;
									}
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore3 == null)
							{
								break;
							}
							TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(_sFlash, 1f, 0.2f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(t4, delay2);
							if (tweenerCore4 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 2;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
											nint num14 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
											vector2 = (Vector3)(num14 + 0);
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 4;
										_ = 0;
									}
								}
							}
							TweenCallback tweenCallback4 = null;
							nint num15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r10_v8 (Il2CppMethodInfo)+8]");
							((Delegate)tweenCallback4).method_ptr = (IntPtr)0;
							((Delegate)tweenCallback4).method = (nint)__ldftn(Background4._003CPlayFlash_003Eb__40_5);
							((Delegate)tweenCallback4).m_target = this;
							((Delegate)tweenCallback4).method_code = (IntPtr)tweenCallback4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r10_v8 (Il2CppMethodInfo)+4C]");
							object obj13 = (nint)0 >> 4;
							object obj14 = obj13 & 1;
							nint num16;
							if (obj14 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r10_v8 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num16 = unchecked((nint)6447293664L);
									goto IL_1083;
								}
							}
							((Delegate)tweenCallback4).method_code = (IntPtr)((Delegate)tweenCallback4).m_target;
							num16 = ((Delegate)tweenCallback4).method_ptr;
							goto IL_1083;
							IL_1083:
							((Delegate)tweenCallback4).extra_arg = unchecked((nint)6447293568L);
							bool flag6 = tweenerCore4 == null;
							num9 = 24;
							if (!flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								bool flag7 = (nint)0 == 0;
								num9 = 24;
								if (!flag7)
								{
									num9 = 24;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore4 == null)
							{
								break;
							}
							obj12++;
							if ((nint)obj12 < 8)
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
							float num17 = 0f * 2f;
							float num18 = num17 * 3f;
							float endValue2 = num18 / 1.28f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							System.ParamsArray paramsArray = new System.ParamsArray(arg);
							string message = string.FormatHelper((IFormatProvider)null, "Final Scale: {0}", (System.ParamsArray)(&obj15));
							Debug.Log(message);
							Transform sFlash2 = (Transform)(object)_sFlash;
							if ((object)_sFlash == null)
							{
								break;
							}
							bool flag8 = ((UnityEngine.Object)sFlash2).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)sFlash2).m_CachedPtr);
							Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
							TweenerCore<Vector3, Vector3, VectorOptions> t5 = ShortcutExtensions.DOScale(target3, endValue2, 0.4f);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = TweenSettingsExtensions.SetDelay(t5, 6.4f);
							if (tweenerCore5 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 2;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
											nint num19 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
											object obj16 = num19 + 0;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2177 @ rax_v76 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 4;
										_ = 0;
									}
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore5 == null)
							{
								break;
							}
							TweenerCore<Color, Color, ColorOptions> t6 = DOTweenModuleSprite.DOFade(_sFlash, 1f, 0.4f);
							TweenerCore<Color, Color, ColorOptions> tweenerCore6 = TweenSettingsExtensions.SetDelay(t6, 6.4f);
							if (tweenerCore6 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 2;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
											nint num20 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
											object obj17 = num20 + 0;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 4;
										_ = 0;
									}
								}
							}
							TweenCallback tweenCallback5 = null;
							nint num21 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ r10_v9 (Il2CppMethodInfo)+8]");
							((Delegate)tweenCallback5).method_ptr = (IntPtr)0;
							((Delegate)tweenCallback5).method = (nint)__ldftn(Background4._003CPlayFlash_003Eb__40_0);
							((Delegate)tweenCallback5).m_target = this;
							((Delegate)tweenCallback5).method_code = (IntPtr)tweenCallback5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ r10_v9 (Il2CppMethodInfo)+4C]");
							object obj18 = (nint)0 >> 4;
							object obj19 = obj18 & 1;
							nint num22;
							if (obj19 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ r10_v9 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num22 = unchecked((nint)6447293664L);
									goto IL_1256;
								}
							}
							((Delegate)tweenCallback5).method_code = (IntPtr)((Delegate)tweenCallback5).m_target;
							num22 = ((Delegate)tweenCallback5).method_ptr;
							goto IL_1256;
							IL_128a:
							TweenCallback tweenCallback6;
							((Delegate)tweenCallback6).extra_arg = unchecked((nint)6447293568L);
							if (tweenerCore6 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore6 == null)
							{
								break;
							}
							GravityWell well = _well;
							if ((object)_well == null)
							{
								break;
							}
							float power = well._gravity * 0f;
							well._power = power;
							DOGetter<float> getter = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
							DOSetter<float> dOSetter = null;
							((Background4)(object)dOSetter)._003CPlayFlash_003Eb__40_3(6.4f);
							TweenerCore<float, float, FloatOptions> t7 = DOTween.To(getter, dOSetter, 2f, 0.8f);
							TweenerCore<float, float, FloatOptions> tweenerCore7 = TweenSettingsExtensions.SetDelay(t7, 6.4f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore7 == null)
							{
								break;
							}
							return;
							IL_1256:
							((Delegate)tweenCallback5).extra_arg = unchecked((nint)6447293568L);
							if (tweenerCore6 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2369 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							tweenCallback6 = null;
							nint num23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r10_v10 (Il2CppMethodInfo)+8]");
							((Delegate)tweenCallback6).method_ptr = (IntPtr)0;
							((Delegate)tweenCallback6).method = (nint)__ldftn(Background4._003CPlayFlash_003Eb__40_1);
							((Delegate)tweenCallback6).m_target = this;
							((Delegate)tweenCallback6).method_code = (IntPtr)tweenCallback6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r10_v10 (Il2CppMethodInfo)+4C]");
							object obj20 = (nint)0 >> 4;
							object obj21 = obj20 & 1;
							nint num24;
							if (obj21 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r10_v10 (Il2CppMethodInfo)+52]");
								bool flag9 = (nint)0 == 0;
								num24 = unchecked((nint)6447293664L);
								if (flag9)
								{
									goto IL_128a;
								}
							}
							num24 = ((Delegate)tweenCallback6).method_ptr;
							((Delegate)tweenCallback6).method_code = (IntPtr)((Delegate)tweenCallback6).m_target;
							goto IL_128a;
						}
						break;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StopRune2()
	{
		//IL_0286: Expected O, but got I4
		//IL_03b3->IL0439: Incompatible stack heights: 3 vs 0
		List<RuneStripVfx2>.Enumerator enumerator = default(List<RuneStripVfx2>.Enumerator);
		while (true)
		{
			_stopp = true;
			SoundManager.StopSound(SfxType.Wind);
			List<RuneStripVfx2> runeStrips = _runeStrips2;
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rbx_v19 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rbx_v19 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				bool flag2 = (object)gameObject == null;
				bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
			}
			List<RuneStripVfx2> runeStrips2 = _runeStrips2;
			int version = runeStrips2._version + 1;
			runeStrips2._version = version;
			runeStrips2._size = 0;
			if (runeStrips2._size > 0)
			{
				Array.Clear(runeStrips2._items, 0, runeStrips2._size);
				runeStrips = null;
			}
			PhaserSprite phaserSprite = _sFog.setVisible(visible: false);
			PhaserSprite phaserSprite2 = _sFog.setAlpha(0f);
			PhaserSprite phaserSprite3 = _sFogExtraA.setAlpha(0f);
			PhaserSprite phaserSprite4 = _sFogExtraB.setAlpha(0f);
			object sDarkness = _sDarkness;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rbx_v10 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(sDarkness);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rbx_v10 (System.Object)+10]");
		Renderer.set_enabled_Injected((IntPtr)0, false);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_sDarkness, 0f);
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0427;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0427;
		IL_0427:
		List<CharacterType> list = playerOptionsData._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v37 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				return;
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		bool flag4 = core2._playerOptions.UnlockSecret(SecretType.BringMeBackThere, config);
	}

	private unsafe void FixY(SpriteRenderer spriteRenderer, float min, float max, float prop)
	{
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_0165: Expected F4, but got O
		//IL_01a5: Expected O, but got I
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_0340: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_027a->IL01dd: Incompatible stack heights: 1 vs 0
		//IL_0056->IL01dd: Incompatible stack heights: 1 vs 0
		//IL_0085->IL01dd: Incompatible stack heights: 1 vs 0
		//IL_01dd->IL01dd: Incompatible stack heights: 3 vs 0
		if ((object)spriteRenderer != null)
		{
			Transform transform = spriteRenderer.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				_ = 0;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+44]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+38]");
						_ = 0;
						object obj3 = default(object);
						bool num7;
						if (!config._003CSelectedInverse_003Ek__BackingField)
						{
							_ = _camBounds;
							float num = (float)obj3 - (float)obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
							_ = 0;
							float num2 = max;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
							float num3 = num2 * 0f;
							bool flag2 = !(min < num3);
							float num4 = min;
							if (!flag2)
							{
								num4 = num3;
							}
							float num5 = num - max;
							float num6 = num - num4;
							if (num5 > num6)
							{
								num -= max;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
							_ = 0;
							IntPtr cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							num7 = flag3;
							object obj5 = 0;
						}
						else
						{
							float num6 = (float)_camBounds;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
							_ = 0;
							float num = (float)obj3 + (float)obj3;
							_ = _camBounds;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
							_ = 0;
							IntPtr cachedPtr = ((UnityEngine.Object)transform).m_CachedPtr;
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							num7 = flag4;
							object obj5 = 0;
							bool flag5 = (nint)0 != 0;
							object obj4 = obj3;
							if (!flag5)
							{
								bool flag6 = (nint)0 == 0;
								goto IL_01dd;
							}
						}
						object obj6 = obj2 - 48;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v623 @ rax_v29 (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		goto IL_01dd;
		IL_01dd:
		throw new NullReferenceException();
	}

	private unsafe void CheckPlayerVsBot(float prop)
	{
		//IL_053d: Invalid comparison between F4 and O
		//IL_0208: Expected I4, but got I8
		//IL_026c: Expected I4, but got I8
		//IL_02a0: Expected I4, but got I8
		//IL_0334: Expected I4, but got I8
		//IL_03ac: Expected I4, but got F4
		//IL_03da: Expected O, but got I4
		//IL_06df->IL079d: Incompatible stack heights: 3 vs 1
		//IL_05e5->IL0777: Incompatible stack heights: 3 vs 1
		//IL_0777->IL07c3: Incompatible stack heights: 4 vs 1
		//IL_0683->IL0683: Incompatible stack heights: 4 vs 1
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			characterController = myPlayerInfo.CharacterController;
		}
		else
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData = core2._gameSessionData;
			characterController = gameSessionData._activeCharacter;
		}
		Transform transform = characterController.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		List<RuneStripVfx> ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-245.76f)) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			return;
		}
		float num = (float)obj - -245.76f;
		float num2 = num / -491.52f;
		if (!_stopp)
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_sDarkness, num2);
			PhaserSprite phaserSprite = _sFog.setAlpha(num2);
			PhaserSprite phaserSprite2 = _sFogExtraA.setAlpha(num2);
			PhaserSprite phaserSprite3 = _sFogExtraB.setAlpha(num2);
		}
		if (num2 > 1f)
		{
			if (!_passed)
			{
				float num3 = default(float);
				RuneStripVfx2 runeStripVfx = RuneStripVfx2.Create(100f, 10000f, 1, 0.5f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx2 = RuneStripVfx2.Create(150f, 8000f, -1, 0.5f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx3 = RuneStripVfx2.Create(200f, 12000f, 1, 0f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx4 = RuneStripVfx2.Create(250f, 10000f, -1, 0.5f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx5 = RuneStripVfx2.Create(490f, 10000f, -1, 0.5f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx6 = RuneStripVfx2.Create(560f, 10000f, 1, 0.5f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx7 = RuneStripVfx2.Create(600f, 12000f, 1, 0f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				RuneStripVfx2 runeStripVfx8 = RuneStripVfx2.Create(650f, 8000f, -1, 0.5f, num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA51D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
				BgmType saveBgm = default(BgmType);
				_saveBgm = saveBgm;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
				BgmType bgmType = default(BgmType);
				SoundManager.FadeMusic(bgmType, 0f, 500f);
				Action onComplete = _003C_003Ec._003C_003E9__43_0;
				if (_003C_003Ec._003C_003E9__43_0 == null)
				{
					onComplete = (_003C_003Ec._003C_003E9__43_0 = delegate
					{
						SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
					});
				}
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				Timer timer = TimerHelper.RegisterMillisUI(500f, onComplete, null, isLooped: false, (byte)(int)num3 != 0, autoDestroyOwner, repeat);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Wind, new SoundManager.SoundConfig
				{
					Rate = 1f,
					Volume = (float?)(object)1,
					Loop = true
				}, 0f, 10, num3);
			}
			_passed = true;
			ret = _runeStrips;
			List<RuneStripVfx>.Enumerator enumerator = default(List<RuneStripVfx>.Enumerator);
			while (enumerator.MoveNext())
			{
				GameObject gameObject = ((Component)null).gameObject;
				bool flag2 = (object)gameObject == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v104 (UnityEngine.GameObject)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v104 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
			}
			List<RuneStripVfx2>.Enumerator enumerator2 = default(List<RuneStripVfx2>.Enumerator);
			while (enumerator2.MoveNext())
			{
				Transform transform2 = null;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
				GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				bool flag5 = (object)gameObject2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2397 @ rax_v89 (UnityEngine.GameObject)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2397 @ rax_v89 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, true);
				((RuneStripVfx2)null).InternalUpdate(prop);
			}
		}
		else
		{
			ret = _runeStrips;
			List<RuneStripVfx>.Enumerator enumerator3 = default(List<RuneStripVfx>.Enumerator);
			while (enumerator3.MoveNext())
			{
				GameObject gameObject3 = ((Component)null).gameObject;
				bool flag7 = (object)gameObject3 == null;
				bool flag8 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr, true);
			}
			List<RuneStripVfx2>.Enumerator enumerator4 = default(List<RuneStripVfx2>.Enumerator);
			while (enumerator4.MoveNext())
			{
				object obj2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1813 @ rbx_v13 (System.Object)+10]");
				bool flag9 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1813 @ rbx_v13 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				bool flag10 = (object)gameObject4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2710 @ rax_v47 (UnityEngine.GameObject)+10]");
				bool flag11 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2710 @ rax_v47 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
			}
		}
	}

	private void CheckPlayerVsTop()
	{
		//IL_0467: Invalid comparison between O and F4
		//IL_0302: Expected I, but got O
		//IL_0387: Expected I4, but got I8
		//IL_03a3: Expected O, but got I4
		//IL_0152->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_0174->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_01a3->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_04a8->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_02d8->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_0347->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_0325->IL0325: Incompatible stack heights: 2 vs 1
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core2._gameSessionData;
					if (core2._gameSessionData != null)
					{
						characterController = gameSessionData._activeCharacter;
						goto IL_0411;
					}
				}
			}
			else if ((object)OnlineStageManager._instance != null)
			{
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				if ((object)myPlayerInfo != null)
				{
					characterController = myPlayerInfo.CharacterController;
					goto IL_0411;
				}
			}
		}
		goto IL_03c5;
		IL_03c5:
		throw new NullReferenceException();
		IL_0411:
		if ((object)characterController != null)
		{
			Transform transform = characterController.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)122.88f))
				{
					return;
				}
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null && core3._playerOptions != null)
				{
					PlayerOptionsData config = core3._playerOptions.Config;
					if (config != null)
					{
						List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
						if (config._003CCollectedItems_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj2 = default(object);
								if ((nint)obj2 != -1)
								{
									return;
								}
							}
							if (_hasSpawnedGuards)
							{
								return;
							}
							_hasSpawnedGuards = true;
							PickupRelic relicItemFromWorld = PickupManager.GetRelicItemFromWorld(ItemType.RELIC_RANDOMAZZO);
							if ((object)relicItemFromWorld == null || ((UnityEngine.Object)relicItemFromWorld).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							float2 position = relicItemFromWorld.position;
							float2 position2 = default(float2);
							relicItemFromWorld.position = position2;
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							Transform transform2 = relicItemFromWorld.transform;
							if (array != null)
							{
								if ((object)transform2 != null)
								{
									nint num = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									bool flag2 = obj3 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									tweenConfig.ease = Ease.InOutSine;
									tweenConfig.duration = 10000f;
									tweenConfig.repeat = -1;
									tweenConfig.yoyo = true;
									tweenConfig.x = (float?)(object)1;
									MultiTargetTween randomazzoTween = Tweens.Add(tweenConfig);
									_randomazzoTween = randomazzoTween;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03c5;
	}

	private unsafe void GenerateObjects()
	{
		//IL_1f36: Expected O, but got I
		//IL_0070: Expected O, but got I
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Expected Ref, but got Unknown
		//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Expected Ref, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected Ref, but got Unknown
		//IL_0ab3: Expected O, but got I
		//IL_0abc: Expected F4, but got I4
		//IL_0c50: Expected O, but got Ref
		//IL_0b1e: Expected I, but got O
		//IL_0ba4: Expected F4, but got I
		//IL_0c1d: Expected O, but got I
		//IL_0cec: Expected O, but got I4
		//IL_0cfc: Expected O, but got I
		//IL_0b42: Expected O, but got I
		//IL_0d4a: Expected O, but got I
		//IL_1f9f: Expected O, but got I4
		//IL_2656: Expected O, but got I4
		//IL_0e3c: Expected O, but got Ref
		//IL_0e44: Expected F4, but got O
		//IL_0e4c: Expected O, but got F4
		//IL_0e6e: Expected O, but got I4
		//IL_0e76: Expected O, but got F4
		//IL_0db9: Expected O, but got Ref
		//IL_0dc1: Expected F4, but got O
		//IL_0dd1: Expected O, but got F4
		//IL_2083: Expected O, but got I4
		//IL_267b: Expected O, but got I4
		//IL_20b4: Expected F4, but got O
		//IL_108b: Expected F4, but got O
		//IL_108b: Expected I4, but got I8
		//IL_2011: Expected O, but got I4
		//IL_2023: Expected I4, but got O
		//IL_10e5: Expected F4, but got O
		//IL_1143: Expected F4, but got O
		//IL_1143: Expected I4, but got I8
		//IL_11a1: Expected F4, but got O
		//IL_11a1: Expected I4, but got I8
		//IL_11fb: Expected F4, but got O
		//IL_1255: Expected F4, but got O
		//IL_12b3: Expected F4, but got O
		//IL_12b3: Expected I4, but got I8
		//IL_1322: Expected O, but got Ref
		//IL_1417: Expected O, but got Ref
		//IL_13ab: Expected I4, but got I8
		//IL_14a0: Expected I4, but got I8
		//IL_21d9: Expected O, but got Ref
		//IL_2269: Expected O, but got Ref
		//IL_1767: Expected I4, but got I8
		//IL_2320: Expected O, but got Ref
		//IL_23b0: Expected O, but got Ref
		//IL_19ad: Expected I4, but got I8
		//IL_2467: Expected O, but got Ref
		//IL_24f7: Expected O, but got Ref
		//IL_1c5c: Expected I4, but got I8
		//IL_1ef9: Expected I4, but got O
		//IL_0c22->IL0c22: Incompatible stack heights: 35 vs 34
		//IL_0e84->IL1fa4: Incompatible stack heights: 36 vs 34
		//IL_0ff8->IL2056: Incompatible stack heights: 45 vs 38
		//IL_1e01->IL2608: Incompatible stack heights: 69 vs 68
		//IL_1eb1->IL1f02: Incompatible stack heights: 71 vs 68
		//IL_1f02->IL1f02: Incompatible stack heights: 73 vs 68
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
		object obj = num + 0;
		Vector2 vector = default(Vector2);
		object obj2 = vector + vector;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBoundsIgnoringBorders(main);
		object obj3 = vector + vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v7 (UnityEngine.Bounds)+10]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v7 (UnityEngine.Bounds)+10]");
		object obj4 = num2 + 0;
		bool flag = (object)_mainCamera == null;
		Transform transform = _mainCamera.transform;
		bool flag2 = (object)transform == null;
		Vector3 position = transform.position;
		GameObject gameObject = new GameObject("Background4SpritesRoot");
		bool flag3 = (object)gameObject == null;
		Transform spritesRootTransform = gameObject.transform;
		_spritesRootTransform = spritesRootTransform;
		float y = (float)vector - (float)vector;
		string text = default(string);
		string spriteName = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(this, position.x, y, vector, text, spriteName);
		bool flag4 = (object)spriteRenderer == null;
		((UnityEngine.Object)spriteRenderer).SetName("sBackground");
		_sBackground = spriteRenderer;
		object obj5 = vector + vector;
		float y2 = (float)obj5 - 0.5f;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(this, position.x, y2, "background4", text);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetBlendMode(spriteRenderer2, BlendMode.Add);
		bool flag5 = (object)spriteRenderer3 == null;
		((UnityEngine.Object)spriteRenderer3).SetName("sStars2");
		_sStars2 = spriteRenderer3;
		object obj6 = vector + vector;
		float y3 = (float)obj6 - 0.5f;
		SpriteRenderer spriteRenderer4 = RenderingExtensions.AddSprite(this, position.x, y3, "background4", text);
		SpriteRenderer spriteRenderer5 = RenderingExtensions.SetBlendMode(spriteRenderer4, BlendMode.Add);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B5F0");
		UnityEngine.Object obj7 = default(UnityEngine.Object);
		bool flag6 = (object)obj7 == null;
		obj7.SetName("sStars1");
		_sStars1 = (SpriteRenderer)obj7;
		float y4 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer6 = RenderingExtensions.AddSprite(this, position.x, y4, vector, text, spriteName);
		bool flag7 = (object)spriteRenderer6 == null;
		((UnityEngine.Object)spriteRenderer6).SetName("sPeaks");
		_sPeaks = spriteRenderer6;
		float y5 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer7 = RenderingExtensions.AddSprite(this, position.x, y5, vector, text, spriteName);
		bool flag8 = (object)spriteRenderer7 == null;
		((UnityEngine.Object)spriteRenderer7).SetName("sMount2");
		_sMount2 = spriteRenderer7;
		float num3 = (float)_camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
		float x = num3 - 0f;
		float y6 = default(float);
		SpriteRenderer spriteRenderer8 = RenderingExtensions.AddSprite(this, x, y6, "background4", text);
		SpriteRenderer spriteRenderer9 = RenderingExtensions.SetAlpha(spriteRenderer8, 0.05f);
		SpriteRenderer spriteRenderer10 = RenderingExtensions.SetBlendMode(spriteRenderer9, BlendMode.Add);
		bool flag9 = (object)spriteRenderer10 == null;
		((UnityEngine.Object)spriteRenderer10).SetName("sMist3");
		_sMist3 = spriteRenderer10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
		float x2 = 0f + (float)_camBounds;
		float y7 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer11 = RenderingExtensions.AddSprite(this, x2, y7, "background4", text);
		SpriteRenderer spriteRenderer12 = RenderingExtensions.SetAlpha(spriteRenderer11, 0.05f);
		SpriteRenderer spriteRenderer13 = RenderingExtensions.SetBlendMode(spriteRenderer12, BlendMode.Add);
		bool flag10 = (object)spriteRenderer13 == null;
		((UnityEngine.Object)spriteRenderer13).SetName("sMist2");
		_sMist2 = spriteRenderer13;
		float num4 = (float)_camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
		float x3 = num4 - 0f;
		float y8 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer14 = RenderingExtensions.AddSprite(this, x3, y8, "background4", text);
		SpriteRenderer spriteRenderer15 = RenderingExtensions.SetAlpha(spriteRenderer14, 0.05f);
		SpriteRenderer spriteRenderer16 = RenderingExtensions.SetBlendMode(spriteRenderer15, BlendMode.Add);
		bool flag11 = (object)spriteRenderer16 == null;
		((UnityEngine.Object)spriteRenderer16).SetName("sMist1");
		_sMist1 = spriteRenderer16;
		float y9 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer17 = RenderingExtensions.AddSprite(this, position.x, y9, vector, text, spriteName);
		bool flag12 = (object)spriteRenderer17 == null;
		((UnityEngine.Object)spriteRenderer17).SetName("sMount1");
		_sMount1 = spriteRenderer17;
		object obj8 = vector + vector;
		float y10 = (float)obj8 - 0.5f;
		SpriteRenderer spriteRenderer18 = RenderingExtensions.AddSprite(this, position.x, y10, "vfx", text);
		SpriteRenderer spriteRenderer19 = RenderingExtensions.SetAlpha(spriteRenderer18, 0f);
		bool flag13 = (object)spriteRenderer19 == null;
		((UnityEngine.Object)spriteRenderer19).SetName("sFlash");
		_sFlash = spriteRenderer19;
		float y11 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer20 = RenderingExtensions.AddSprite(this, position.x, y11, vector, text, spriteName);
		bool flag14 = (object)spriteRenderer20 == null;
		((UnityEngine.Object)spriteRenderer20).SetName("sHills");
		_sHills = spriteRenderer20;
		float y12 = (float)vector - (float)vector;
		SpriteRenderer spriteRenderer21 = RenderingExtensions.AddSprite(this, position.x, y12, vector, text, spriteName);
		bool flag15 = (object)spriteRenderer21 == null;
		((UnityEngine.Object)spriteRenderer21).SetName("sForest");
		_sForest = spriteRenderer21;
		SpriteRenderer spriteRenderer22 = RenderingExtensions.AddSprite(this, position.x, y6, "vfx", text);
		SpriteRenderer component = RenderingExtensions.SetAlpha(spriteRenderer22, 0f);
		float num5 = (float)obj4 * 100f;
		float xScale = (float)obj3 * 100f;
		SpriteRenderer spriteRenderer23 = RenderingExtensions.SetScale(component, xScale, num5);
		bool flag16 = (object)spriteRenderer23 == null;
		((UnityEngine.Object)spriteRenderer23).SetName("sDarkness");
		_sDarkness = spriteRenderer23;
		base.SetupDarknessFog(ref *(PhaserSprite*)(this + 280), ref *(PhaserSprite*)(this + 288), ref *(PhaserSprite*)(this + 296));
		bool flag17 = (object)_sFog == null;
		PhaserSprite phaserSprite = _sFog.setAlpha(0f);
		bool flag18 = (object)_sFogExtraA == null;
		PhaserSprite phaserSprite2 = _sFogExtraA.setAlpha(0f);
		bool flag19 = (object)_sFogExtraB == null;
		PhaserSprite phaserSprite3 = _sFogExtraB.setAlpha(0f);
		bool flag20 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag21 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag22 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag23 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag24 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag25 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag26 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag27 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag28 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag29 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag30 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		bool flag31 = _allSprites == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
		GameManager core = GM.Core;
		bool flag32 = (object)GM.Core == null;
		bool flag33 = core._playerOptions == null;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag34 = config == null;
		bool flag35 = !config._003CSelectedInverse_003Ek__BackingField;
		float num6 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
		object obj9 = 0;
		float num7 = 0f;
		if (!flag35)
		{
			bool flag36 = _allSprites == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
			List<SpriteRenderer>.Enumerator enumerator = default(List<SpriteRenderer>.Enumerator);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3749 @ rax_v459+10]");
				bool flag37 = (nint)0 == 0;
				nint num8 = (nint)typeof(RenderingExtensions);
				if (!flag37)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3749 @ rax_v459+10]");
					((SpriteRenderer)0).flipY = true;
					continue;
				}
				throw new NullReferenceException();
			}
			float y13 = (float)vector - (float)vector;
			SpriteRenderer spriteRenderer24 = RenderingExtensions.SetY(_sBackground, y13);
			object obj10 = vector - vector;
			float y14 = (float)obj10 + 0.5f;
			SpriteRenderer spriteRenderer25 = RenderingExtensions.SetY(_sStars2, y14);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
			num6 = 0f;
			object obj11 = vector - vector;
			float y15 = (float)obj11 + 0.5f;
			SpriteRenderer spriteRenderer26 = RenderingExtensions.SetY(_sStars1, y15);
			object obj12 = vector + vector;
			num7 = (float)obj12 + 0.5f;
			SpriteRenderer spriteRenderer27 = RenderingExtensions.SetY(_sFlash, num7);
			LoopType loopType = LoopType.Restart;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
			obj9 = 0;
		}
		PlayerOptionsData playerOptionsData;
		if ((object)_spritesRootTransform != null)
		{
			Vector2 vector2 = default(Vector2);
			_spritesRootTransform.position = (Vector3)(&vector2);
			if ((object)_mainCamera != null)
			{
				Transform parent = _mainCamera.transform;
				if ((object)_spritesRootTransform != null)
				{
					_spritesRootTransform.SetParent(parent, worldPositionStays: true);
					if (_allSprites != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
						object obj13 = default(object);
						List<SpriteRenderer>.Enumerator enumerator2 = (List<SpriteRenderer>.Enumerator)obj13;
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4067 @ rax_v208+10]");
						Component component2 = (Component)0;
						vector2 = vector;
						bool flag38 = true;
						Background4 background = this;
						List<SpriteRenderer>.Enumerator enumerator3 = default(List<SpriteRenderer>.Enumerator);
						float num12 = default(float);
						while (enumerator3.MoveNext())
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4067 @ rax_v208+10]");
							bool flag39 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4067 @ rax_v208+10]");
							Transform transform2 = ((Component)0).transform;
							Background4 background2 = (Background4)Screen.height;
							object obj15 = Screen.width;
							float num10;
							bool num11;
							if (System.Runtime.CompilerServices.Unsafe.As<Background4, UIntPtr>(ref background2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2FF0");
								float num9 = (float)obj / 5.4f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4160 @ rax_v455+8]");
								y8 = 0f * num9;
								num10 = (float)vector * num9;
								bool flag40 = (object)transform2 == null;
								num11 = flag40;
								transform2.localScale = (Vector3)(&num12);
								num6 = (float)vector;
								vector2 = vector;
								enumerator2 = (List<SpriteRenderer>.Enumerator)num9;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2FF0");
								float num13 = (float)obj2 / 3.6f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4286 @ rax_v453+8]");
								y8 = 0f * num13;
								num10 = (float)vector * num13;
								bool flag41 = (object)transform2 == null;
								num11 = flag41;
								transform2.localScale = (Vector3)(&background);
								num6 = (float)vector;
								enumerator2 = (List<SpriteRenderer>.Enumerator)num13;
							}
							transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
							obj14 = 0;
							component2 = (Component)num10;
							flag38 = true;
						}
						bool flag42 = (object)_sDarkness == null;
						Transform transform3 = _sDarkness.transform;
						bool flag43 = (object)transform3 == null;
						transform3.SetParent(_spritesRootTransform, worldPositionStays: true);
						bool flag44 = _allSprites == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
						List<SpriteRenderer> allSprites = _allSprites;
						bool flag45 = _allSprites == null;
						LoopType loopType2 = LoopType.Restart;
						LoopType loopType3 = LoopType.Restart;
						while ((int)loopType3 < allSprites._size)
						{
							List<SpriteRenderer> allSprites2 = _allSprites;
							bool flag46 = _allSprites == null;
							bool flag47 = (int)loopType2 >= allSprites2._size;
							SpriteRenderer[] items = allSprites2._items;
							bool flag48 = allSprites2._items == null;
							bool flag49 = (int)loopType2 >= items.Length;
							Background4 background3 = (Background4)(object)items[(int)loopType2];
							bool flag50 = (object)items[(int)loopType2] == null;
							bool flag51 = ((UnityEngine.Object)background3).m_CachedPtr == (IntPtr)0;
							SpriteRenderer spriteRenderer28 = (SpriteRenderer)(loopType2 - 32768);
							Renderer.set_sortingOrder_Injected(((UnityEngine.Object)background3).m_CachedPtr, (int)spriteRenderer28);
							loopType2++;
							allSprites = _allSprites;
							bool flag52 = _allSprites == null;
							loopType3 = loopType2;
						}
						List<RuneStripVfx> runeStrips = new List<RuneStripVfx>();
						_runeStrips = runeStrips;
						List<RuneStripVfx2> runeStrips2 = new List<RuneStripVfx2>();
						_runeStrips2 = runeStrips2;
						object obj16 = Screen.height;
						object obj17 = Screen.width;
						float num14 = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17)) ? 1f : 0.625f);
						float x4 = num14 * 50f;
						RuneStripVfx runeStripVfx = RuneStripVfx.Create(x4, 10000f, 1, 0.5f, (float)text);
						bool flag53 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x5 = num14 * 100f;
						RuneStripVfx runeStripVfx2 = RuneStripVfx.Create(x5, 8000f, -1, 0.5f, (float)text);
						bool flag54 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x6 = num14 * 150f;
						RuneStripVfx runeStripVfx3 = RuneStripVfx.Create(x6, 12000f, 1, 0f, (float)text);
						bool flag55 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x7 = num14 * 200f;
						RuneStripVfx runeStripVfx4 = RuneStripVfx.Create(x7, 10000f, -1, 0.5f, (float)text);
						bool flag56 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x8 = num14 * 490f;
						RuneStripVfx runeStripVfx5 = RuneStripVfx.Create(x8, 10000f, -1, 0.5f, (float)text);
						bool flag57 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x9 = num14 * 560f;
						RuneStripVfx runeStripVfx6 = RuneStripVfx.Create(x9, 10000f, 1, 0.5f, (float)text);
						bool flag58 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x10 = num14 * 600f;
						RuneStripVfx runeStripVfx7 = RuneStripVfx.Create(x10, 12000f, 1, 0f, (float)text);
						bool flag59 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						float x11 = num14 * 650f;
						RuneStripVfx runeStripVfx8 = RuneStripVfx.Create(x11, 8000f, -1, 0.5f, (float)text);
						bool flag60 = _runeStrips == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5290");
						bool flag61 = (object)_sStars2 == null;
						Transform target = _sStars2.transform;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&vector2), 10f, RotateMode.FastBeyond360);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
						Tween tween = default(Tween);
						if (tween != null && tween._003Cactive_003Ek__BackingField && !tween.creationLocked)
						{
							tween.loops = -1;
							tween.loopType = LoopType.Restart;
							if (((ABSSequentiable)tween).tweenType == TweenType.Tweener)
							{
								tween.fullDuration = 1f / 0f;
							}
						}
						Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(tween);
						bool flag62 = (object)_sStars1 == null;
						Transform target2 = _sStars1.transform;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target2, (Vector3)(&vector2), 10f, RotateMode.FastBeyond360);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
						Tween tween3 = default(Tween);
						if (tween3 != null && tween3._003Cactive_003Ek__BackingField && !tween3.creationLocked)
						{
							tween3.loops = -1;
							tween3.loopType = LoopType.Restart;
							if (((ABSSequentiable)tween3).tweenType == TweenType.Tweener)
							{
								tween3.fullDuration = 1f / 0f;
							}
						}
						Tween tween4 = VampireSurvivors.Tools.TweenExtensions.SetGameId(tween3);
						TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(_sStars1, 0.5f, 5f);
						if (tweenerCore3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4756 @ rax_v253 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4756 @ rax_v253 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4756 @ rax_v253 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4756 @ rax_v253 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 4;
									_ = 0;
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag63 = tweenerCore3 == null;
						Sequence sequence = DOTween.Sequence();
						TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_sMist1, 0.1f, 45.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
						{
							Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
						}
						object sMist = _sMist1;
						bool flag64 = (object)_sMist1 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v25 (System.Object)+10]");
						bool flag65 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v25 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target3, (Vector3)(&vector2), 45.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
						{
							Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
						}
						object sMist2 = _sMist1;
						bool flag66 = (object)_sMist1 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r15_v28 (System.Object)+10]");
						bool flag67 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r15_v28 (System.Object)+10]");
						IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
						Transform target4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> t3 = ShortcutExtensions.DORotate(target4, (Vector3)(&vector2), 45.000004f, RotateMode.FastBeyond360);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
						{
							Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t3, 0f);
						}
						if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
						{
							if (!((Tween)sequence).creationLocked)
							{
								((Tween)sequence).loops = -1;
								((Tween)sequence).loopType = LoopType.Yoyo;
								if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
								{
									((Tween)sequence).fullDuration = 1f / 0f;
								}
							}
							if (((Tween)sequence)._003Cactive_003Ek__BackingField)
							{
								((Tween)sequence).easeType = Ease.InOutSine;
								((Tween)sequence).customEase = null;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag68 = sequence == null;
						sequence.stringId = "DefaultGameTweenId";
						Sequence sequence5 = DOTween.Sequence();
						TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(_sMist2, 0.1f, 45.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t4, false))
						{
							Sequence sequence6 = Sequence.DoInsert(sequence5, (Tween)t4, 0f);
						}
						object sMist3 = _sMist2;
						bool flag69 = (object)_sMist2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r15_v31 (System.Object)+10]");
						bool flag70 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r15_v31 (System.Object)+10]");
						IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
						Transform target5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
						TweenerCore<Vector3, Vector3, VectorOptions> t5 = ShortcutExtensions.DOScale(target5, (Vector3)(&vector2), 45.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t5, false))
						{
							Sequence sequence7 = Sequence.DoInsert(sequence5, (Tween)t5, 0f);
						}
						object sMist4 = _sMist2;
						bool flag71 = (object)_sMist2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ r15_v34 (System.Object)+10]");
						bool flag72 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ r15_v34 (System.Object)+10]");
						IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
						Transform target6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> t6 = ShortcutExtensions.DORotate(target6, (Vector3)(&vector2), 45.000004f, RotateMode.FastBeyond360);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t6, false))
						{
							Sequence sequence8 = Sequence.DoInsert(sequence5, (Tween)t6, 0f);
						}
						if (sequence5 != null && ((Tween)sequence5)._003Cactive_003Ek__BackingField)
						{
							if (!((Tween)sequence5).creationLocked)
							{
								((Tween)sequence5).loops = -1;
								((Tween)sequence5).loopType = LoopType.Yoyo;
								if (((ABSSequentiable)sequence5).tweenType == TweenType.Tweener)
								{
									((Tween)sequence5).fullDuration = 1f / 0f;
								}
							}
							if (((Tween)sequence5)._003Cactive_003Ek__BackingField)
							{
								((Tween)sequence5).easeType = Ease.InOutSine;
								((Tween)sequence5).customEase = null;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag73 = sequence5 == null;
						sequence5.stringId = "DefaultGameTweenId";
						Sequence sequence9 = DOTween.Sequence();
						TweenerCore<Color, Color, ColorOptions> t7 = DOTweenModuleSprite.DOFade(_sMist3, 0.1f, 60.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence9, (Tween)t7, false))
						{
							Sequence sequence10 = Sequence.DoInsert(sequence9, (Tween)t7, 0f);
						}
						object sMist5 = _sMist3;
						bool flag74 = (object)_sMist3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r15_v37 (System.Object)+10]");
						bool flag75 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r15_v37 (System.Object)+10]");
						IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
						Transform target7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
						TweenerCore<Vector3, Vector3, VectorOptions> t8 = ShortcutExtensions.DOScale(target7, (Vector3)(&vector2), 60.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence9, (Tween)t8, false))
						{
							Sequence sequence11 = Sequence.DoInsert(sequence9, (Tween)t8, 0f);
						}
						object sMist6 = _sMist3;
						bool flag76 = (object)_sMist3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2477 @ r15_v40 (System.Object)+10]");
						bool flag77 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2477 @ r15_v40 (System.Object)+10]");
						IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
						Transform target8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> t9 = ShortcutExtensions.DORotate(target8, (Vector3)(&vector2), 60.000004f, RotateMode.FastBeyond360);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence9, (Tween)t9, false))
						{
							Sequence sequence12 = Sequence.DoInsert(sequence9, (Tween)t9, 0f);
						}
						object sMist7 = _sMist3;
						bool flag78 = (object)_sMist3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2578 @ r15_v42 (System.Object)+10]");
						bool flag79 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2578 @ r15_v42 (System.Object)+10]");
						IntPtr gcHandlePtr7 = Component.get_transform_Injected((IntPtr)0);
						Transform target9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background4)+3C]");
						float endValue = 0f + (float)_camBounds;
						TweenerCore<Vector3, Vector3, VectorOptions> t10 = ShortcutExtensions.DOLocalMoveY(target9, endValue, 60.000004f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence9, (Tween)t10, false))
						{
							Sequence sequence13 = Sequence.DoInsert(sequence9, (Tween)t10, 0f);
						}
						if (sequence9 != null && ((Tween)sequence9)._003Cactive_003Ek__BackingField)
						{
							if (!((Tween)sequence9).creationLocked)
							{
								((Tween)sequence9).loops = -1;
								((Tween)sequence9).loopType = LoopType.Yoyo;
								if (((ABSSequentiable)sequence9).tweenType == TweenType.Tweener)
								{
									((Tween)sequence9).fullDuration = 1f / 0f;
								}
							}
							if (((Tween)sequence9)._003Cactive_003Ek__BackingField)
							{
								((Tween)sequence9).easeType = Ease.InOutSine;
								((Tween)sequence9).customEase = null;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag80 = sequence9 == null;
						sequence9.stringId = "DefaultGameTweenId";
						GameManager core2 = GM.Core;
						bool flag81 = (object)GM.Core == null;
						PlayerOptions playerOptions = core2._playerOptions;
						bool flag82 = core2._playerOptions == null;
						if (playerOptions._onlineClientWithRunDataConfig == null)
						{
							if (playerOptions._hostGameConfig == null)
							{
								if (playerOptions._currentAdventureSaveData != null)
								{
									playerOptionsData = playerOptions._currentAdventureSaveData;
									if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_2608;
									}
								}
								playerOptionsData = playerOptions._mainGameConfig;
								bool flag83 = playerOptions._mainGameConfig == null;
							}
							else
							{
								playerOptionsData = playerOptions._hostGameConfig;
							}
						}
						else
						{
							playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
						}
						goto IL_2608;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_2608:
		if (playerOptionsData._003CSelectedStage_003Ek__BackingField != StageType.TOWER)
		{
			GameManager core3 = GM.Core;
			bool flag84 = (object)GM.Core == null;
			bool flag85 = core3._playerOptions == null;
			PlayerOptionsData config2 = core3._playerOptions.Config;
			bool flag86 = config2 == null;
			if (config2._003CSelectedStage_003Ek__BackingField == StageType.TOWERBRIDGE)
			{
				GameManager core4 = GM.Core;
				bool flag87 = (object)GM.Core == null;
				bool flag88 = (object)core4._stage == null;
				GameObject gameObject2 = core4._stage.SpawnEnemy(EnemyType.BRIDGE_BOSS, vector, asRemote: false, (byte)(int)text != 0);
			}
		}
		else
		{
			GenerateTrappedSorceress();
		}
	}

	private void GenerateTrappedSorceress()
	{
		if (GM.Core.IsStageHost)
		{
			GameManager core = GM.Core;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = core._stage.SpawnEnemy(EnemyType.BOSS_XLLEDA, spawnPos, asRemote: false, forceSpawn);
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				EnemyStalkerTrappedSorceress component = gameObject.GetComponent<EnemyStalkerTrappedSorceress>();
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					Action onDefeat = StopRune2;
					component.OnDefeat = onDefeat;
				}
			}
			return;
		}
		Action<EnemyController> b = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Combine(EnemyInstantiator.OnRemoteEnemySpawned, b);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<EnemyController> action = default(Action<EnemyController>);
		if (action != null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		if (enemy._enemyType != EnemyType.BOSS_XLLEDA)
		{
			return;
		}
		Action<EnemyController> value = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<EnemyController> action = default(Action<EnemyController>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		Debug.Log("Remote Trapped Sorceress spawned");
		EnemyStalkerTrappedSorceress component = enemy.GetComponent<EnemyStalkerTrappedSorceress>();
		Action onDefeat = StopRune2;
		component.OnDefeat = onDefeat;
	}

	private void GenerateBridgeBoss()
	{
		GameManager core = GM.Core;
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		GameObject gameObject = core._stage.SpawnEnemy(EnemyType.BRIDGE_BOSS, spawnPos, asRemote: false, forceSpawn);
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_040c: Expected O, but got I4
		//IL_0432: Expected O, but got I4
		//IL_0459: Expected O, but got I4
		//IL_0472: Expected O, but got Ref
		//IL_048c: Expected native int or pointer, but got O
		//IL_04a6: Expected O, but got I
		//IL_04c6: Expected O, but got Ref
		//IL_04e0: Expected native int or pointer, but got O
		//IL_04fa: Expected O, but got I
		//IL_051a: Expected O, but got Ref
		//IL_0534: Expected native int or pointer, but got O
		//IL_0811: Expected O, but got I4
		//IL_054c: Expected O, but got Ref
		//IL_0573: Expected O, but got I
		//IL_058d: Expected native int or pointer, but got O
		//IL_0843: Expected O, but got I
		//IL_05c5: Expected O, but got Ref
		//IL_05df: Expected native int or pointer, but got O
		//IL_087d: Expected O, but got I
		//IL_0636: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_068c: Expected O, but got I
		//IL_071c: Expected O, but got I
		//IL_0766: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			particleEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particleEmitterManager = particleEmitterManager;
		List<SpriteRenderer> allSprites = _allSprites;
		int depth = allSprites._size - 32766;
		ParticleEmitterManager particleEmitterManager2 = _particleEmitterManager.SetDepth(depth);
		Transform transform = _sFlash.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_02.png");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_03.png");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_04.png");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_05.png");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_06.png");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float num = default(float);
		minMaxCurve = new ParticleSystem.MinMaxCurve(num);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(3000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 300f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 64;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		_ = 0;
		_ = 1115684864;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 11206655;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = false;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		Transform parent = _mainCamera.transform;
		ParticleSystem pfxEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig, parent);
		_pfxEmitter = pfxEmitter;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		_ = 1;
		float num2 = num + 2f;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		gravityWellConfig._x = (float?)(object)0;
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 25f;
		gravityWellConfig._gravity = 150f;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		gravityWellConfig._y = (float?)(object)0;
		Transform parent2 = _mainCamera.transform;
		GravityWell well = _particleEmitterManager.CreateGravityWell(gravityWellConfig, parent2);
		_well = well;
	}

	public Background4()
	{
		List<SpriteRenderer> allSprites = new List<SpriteRenderer>();
		_allSprites = allSprites;
		_runeStrips = new List<RuneStripVfx>();
		_runeStrips2 = new List<RuneStripVfx2>();
		base._002Ector();
	}

	private void _003COnInitCompleted_003Eb__35_0()
	{
		PlayFlash();
		Action onComplete = PlayFlash;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer recurringEvent = TimerHelper.RegisterMillisUI(101048.01f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat);
		_recurringEvent = recurringEvent;
	}

	private void _003CPlayFlash_003Eb__40_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_sFlash, 0f);
	}

	private void _003CPlayFlash_003Eb__40_5()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_sFlash, 0f);
	}

	private void _003CPlayFlash_003Eb__40_0()
	{
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null)
		{
			Transform transform = _pfxEmitter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)_pfxEmitter == null;
				bool flag3 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, ref emitParams, 120);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CPlayFlash_003Eb__40_1()
	{
		RenderingExtensions.StopEmitting(_pfxEmitter);
	}

	private float _003CPlayFlash_003Eb__40_2()
	{
		GravityWell well = _well;
		return well._power / well._gravity;
	}

	private void _003CPlayFlash_003Eb__40_3(float x)
	{
		GravityWell well = _well;
		float power = x * well._gravity;
		well._power = power;
	}
}
