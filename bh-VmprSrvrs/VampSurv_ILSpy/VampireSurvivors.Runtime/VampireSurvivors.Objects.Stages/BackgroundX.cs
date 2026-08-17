using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.Engine.UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.RenderPass;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundX : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__41_0;

		public static Action _003C_003E9__42_0;

		public static TweenCallback _003C_003E9__46_1;

		public static Predicate<ScriptableRendererFeature> _003C_003E9__47_0;

		public static Action _003C_003E9__60_24;

		public static Action _003C_003E9__60_25;

		public static Action _003C_003E9__60_26;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CCustomPreload_003Eb__41_0(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.Wind, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCreate_003Eb__42_0()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Chapet;
			GM.Core.SetupMusicBanger();
		}

		internal void _003CRosaryTriggered_003Eb__46_1()
		{
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5510");
		}

		internal unsafe bool _003CInitFishEye_003Eb__47_0(ScriptableRendererFeature feature)
		{
			//IL_0135: Expected I4, but got O
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			//IL_00f2: Expected I8, but got I4
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3E63]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)feature != null)
			{
				string name = ((UnityEngine.Object)feature).GetName();
				object obj = "FishEye";
				if ((object)name != "FishEye")
				{
					if (name != null && "FishEye" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(name + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("FishEye" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal void _003CSetupTimers_003Eb__60_24()
		{
			//IL_00a9: Expected O, but got I4
			//IL_0184: Expected I4, but got I8
			//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)core._stage != null)
			{
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE1S, spawnPos, asRemote: false, forceSpawn);
				if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				EnemySpin component = gameObject.GetComponent<EnemySpin>();
				if ((object)component != null)
				{
					SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
					component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
					if ((object)((EnemyController)component)._EnemyRenderer != null)
					{
						bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CSetupTimers_003Eb__60_25()
		{
			//IL_00a9: Expected O, but got I4
			//IL_0184: Expected I4, but got I8
			//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)core._stage != null)
			{
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE2S, spawnPos, asRemote: false, forceSpawn);
				if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				EnemySpin component = gameObject.GetComponent<EnemySpin>();
				if ((object)component != null)
				{
					SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
					component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
					if ((object)((EnemyController)component)._EnemyRenderer != null)
					{
						bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CSetupTimers_003Eb__60_26()
		{
			//IL_00a9: Expected O, but got I4
			//IL_0184: Expected I4, but got I8
			//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)core._stage != null)
			{
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE3S, spawnPos, asRemote: false, forceSpawn);
				if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				EnemySpin component = gameObject.GetComponent<EnemySpin>();
				if ((object)component != null)
				{
					SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
					component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
					if ((object)((EnemyController)component)._EnemyRenderer != null)
					{
						bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public float intensity;

		public BackgroundX _003C_003E4__this;

		public float radius;

		internal float _003CTweenFishEye_003Eb__0()
		{
			return intensity;
		}

		internal void _003CTweenFishEye_003Eb__1(float x)
		{
			intensity = x;
		}

		internal void _003CTweenFishEye_003Eb__2()
		{
			BackgroundX backgroundX = _003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature = backgroundX._fishEyeRenderFeature;
			fishEyeRenderFeature.passMaterial.SetFloatImpl(Intensity, intensity);
		}

		internal float _003CTweenFishEye_003Eb__3()
		{
			return radius;
		}

		internal void _003CTweenFishEye_003Eb__4(float x)
		{
			radius = x;
		}

		internal void _003CTweenFishEye_003Eb__5()
		{
			BackgroundX backgroundX = _003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature = backgroundX._fishEyeRenderFeature;
			fishEyeRenderFeature.passMaterial.SetFloatImpl(Radius, radius);
		}
	}

	private sealed class _003C_003Ec__DisplayClass57_0
	{
		public SpriteRenderer s;

		public int index;

		public TweenCallback _003C_003E9__2;

		internal void _003CRemovePowers_003Eb__0()
		{
			//IL_0031: Expected O, but got I4
			s.enabled = true;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Haha, soundConfig, 10000f, 1, time);
		}

		internal unsafe void _003CRemovePowers_003Eb__1()
		{
			//IL_0026: Expected O, but got Ref
			Transform transform = s.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num = (float)index + 1100f;
			float delay = num * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					s.enabled = false;
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CRemovePowers_003Eb__2()
		{
			s.enabled = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass66_0
	{
		public BackgroundX _003C_003E4__this;

		public float radiusMul;

		public Action _003C_003E9__0;

		internal void _003CShootEyes_003Eb__0()
		{
			BackgroundX backgroundX = _003C_003E4__this;
			if (!backgroundX._hasRosaryBeenTriggered && backgroundX._shootingEyesManager != null)
			{
				backgroundX._shootingEyesManager.ShootOne(radiusMul);
			}
		}
	}

	private sealed class _003CInitFishEye_003Ed__47(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BackgroundX _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0305: Expected I4, but got I8
			//IL_055d: Expected I4, but got O
			//IL_036f: Expected O, but got Ref
			//IL_03d8: Expected O, but got Ref
			//IL_00f8: Expected I, but got O
			//IL_0106: Expected I, but got O
			//IL_0116: Expected O, but got I
			//IL_0196: Expected O, but got I4
			//IL_0152: Expected O, but got I
			//IL_0188: Expected O, but got I4
			BackgroundX backgroundX = _003C_003E4__this;
			ScriptableRendererFeature scriptableRendererFeature;
			ScriptableRendererFeature fishEyeRenderFeature;
			object obj3;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Renderer2DData renderer2DData = core._Renderer2DData;
					if ((object)core._Renderer2DData != null)
					{
						Predicate<ScriptableRendererFeature> match = _003C_003Ec._003C_003E9__47_0;
						if (_003C_003Ec._003C_003E9__47_0 == null)
						{
							match = (_003C_003Ec._003C_003E9__47_0 = delegate(ScriptableRendererFeature feature)
							{
								//IL_0135: Expected I4, but got O
								//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
								//IL_00db: Expected Ref, but got Unknown
								//IL_00f2: Expected I8, but got I4
								//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
								//IL_0101: Expected Ref, but got Unknown
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3E63]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if ((object)feature == null)
								{
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								}
								string name = ((UnityEngine.Object)feature).GetName();
								object obj5 = "FishEye";
								if ((object)name != "FishEye")
								{
									if (name != null && "FishEye" != null)
									{
										int stringLength = name._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
										if ((nint)stringLength == 0)
										{
											ref byte first = ref *(byte*)(name + 20);
											ulong length = (ulong)(name._stringLength + name._stringLength);
											return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("FishEye" + 20), length);
										}
									}
									return false;
								}
								return true;
							});
						}
						if (((ScriptableRendererData)renderer2DData).m_RendererFeatures != null)
						{
							scriptableRendererFeature = ((ScriptableRendererData)renderer2DData).m_RendererFeatures.Find(match);
							if ((object)_003C_003E4__this != null)
							{
								bool flag = (object)scriptableRendererFeature == null;
								fishEyeRenderFeature = scriptableRendererFeature;
								if (flag)
								{
									goto IL_05de;
								}
								nint num = (nint)scriptableRendererFeature;
								nint num2 = (nint)typeof(FishEyeRenderFeature);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rdx_v31 (Il2CppClass<VampireSurvivors.Graphics.RenderPass.FishEyeRenderFeature>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ r9_v11 (Il2CppClass<UnityEngine.Rendering.Universal.ScriptableRendererFeature>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rdx_v31 (Il2CppClass<VampireSurvivors.Graphics.RenderPass.FishEyeRenderFeature>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ r9_v11 (Il2CppClass<UnityEngine.Rendering.Universal.ScriptableRendererFeature>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rax_v70+FFFFFFF8+v674 @ rax_v65*8]");
									if (0 == (nint)typeof(FishEyeRenderFeature))
									{
										obj3 = 1;
										goto IL_05f0;
									}
								}
								obj3 = 0;
								goto IL_05f0;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_02c6;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					FishEyeRenderFeature fishEyeRenderFeature2 = backgroundX._fishEyeRenderFeature;
					if ((object)backgroundX._fishEyeRenderFeature != null && (object)fishEyeRenderFeature2.passMaterial != null)
					{
						object obj4 = default(object);
						fishEyeRenderFeature2.passMaterial.SetVector(TexSize, (Vector4)(&obj4));
						FishEyeRenderFeature fishEyeRenderFeature3 = backgroundX._fishEyeRenderFeature;
						if ((object)backgroundX._fishEyeRenderFeature != null && (object)fishEyeRenderFeature3.passMaterial != null)
						{
							fishEyeRenderFeature3.passMaterial.SetVector(Center, (Vector4)(&obj4));
							FishEyeRenderFeature fishEyeRenderFeature4 = backgroundX._fishEyeRenderFeature;
							if ((object)backgroundX._fishEyeRenderFeature != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.Objects.Stages.BackgroundX)+40]");
								float num4 = 0f * 2f;
								if ((object)fishEyeRenderFeature4.passMaterial != null)
								{
									float num5 = num4 * 0.5f;
									float value = num5 * 0.625f;
									fishEyeRenderFeature4.passMaterial.SetFloatImpl(Radius, value);
									FishEyeRenderFeature fishEyeRenderFeature5 = backgroundX._fishEyeRenderFeature;
									if ((object)backgroundX._fishEyeRenderFeature != null && (object)fishEyeRenderFeature5.passMaterial != null)
									{
										fishEyeRenderFeature5.passMaterial.SetFloatImpl(Intensity, 0f);
										FishEyeRenderFeature fishEyeRenderFeature6 = backgroundX._fishEyeRenderFeature;
										if ((object)backgroundX._fishEyeRenderFeature != null && (object)fishEyeRenderFeature6.passMaterial != null)
										{
											fishEyeRenderFeature6.passMaterial.SetFloatImpl(Mode, 1f);
											goto IL_02c6;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_054f;
			IL_05de:
			backgroundX._fishEyeRenderFeature = (FishEyeRenderFeature)fishEyeRenderFeature;
			FishEyeRenderFeature fishEyeRenderFeature7 = backgroundX._fishEyeRenderFeature;
			if ((object)backgroundX._fishEyeRenderFeature != null && ((UnityEngine.Object)fishEyeRenderFeature7).m_CachedPtr != (IntPtr)0)
			{
				FishEyeRenderFeature fishEyeRenderFeature8 = backgroundX._fishEyeRenderFeature;
				if ((object)backgroundX._fishEyeRenderFeature != null)
				{
					Material passMaterial = new Material(fishEyeRenderFeature8._FishEyeMaterial);
					fishEyeRenderFeature8.passMaterial = passMaterial;
					FishEyeRenderFeature fishEyeRenderFeature9 = backgroundX._fishEyeRenderFeature;
					if ((object)backgroundX._fishEyeRenderFeature != null)
					{
						((ScriptableRendererFeature)fishEyeRenderFeature9).m_Active = true;
						WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
						_003C_003E2__current = waitForEndOfFrame;
						_003C_003E1__state = 1;
						return true;
					}
				}
				goto IL_054f;
			}
			Debug.LogError("Couldn't find render feature FishEye");
			goto IL_02c6;
			IL_054f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02c6:
			return false;
			IL_05f0:
			bool flag2 = obj3 == null;
			fishEyeRenderFeature = null;
			if (!flag2)
			{
				fishEyeRenderFeature = scriptableRendererFeature;
			}
			goto IL_05de;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private float _wind;

	private float _fireTimer;

	private bool _hasRosaryBeenTriggered;

	private bool _saveOption;

	private FishEyeRenderFeature _fishEyeRenderFeature;

	private ShootingEyesManager _shootingEyesManager;

	private Pickup _rosary;

	private Transform _spritesRootTransform;

	private TileSprite _skyBlue;

	private TileSprite _cloudsBlue;

	private TileSprite _cloudsWhite;

	private TileSprite _cloudsAddBlue;

	private TileSprite _cloudsAddRed;

	private TileSprite _cloudsRed;

	private TileSprite _skyRed;

	private SpriteRenderer _whiteFader;

	private SpriteRenderer _shootingRay;

	private SpriteRenderer _shootingRing;

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleEmitterManager _particleEmitterManagerRed;

	private ParticleSystem _pfxEmitterRed1;

	private ParticleSystem _pfxEmitterRed2;

	private ParticleEmitterManager _particleEmitterManagerRedBelow;

	private ParticleSystem _pfxEmitterBelow1;

	private ParticleSystem _pfxEmitterBelow2;

	private EnemyMaddener _enemyMaddener;

	private Timer _tweenExplosionsTimer;

	private int _tweenExplosionsTimerRepeatCount;

	private Tween _tweenExplosions;

	private List<Timer> _timers;

	private Timer _checkRosaryTimer;

	private int _checkRosaryTimerRepeatCount;

	private Sequence _permanentVfxTween;

	private static readonly int Intensity;

	private static readonly int Radius;

	private static readonly int Mode;

	private static readonly int TexSize;

	private static readonly int Center;

	public override void Awake()
	{
		base.Awake();
		_hasRosaryBeenTriggered = false;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_013d: Expected O, but got F4
		//IL_01ea: Expected O, but got F4
		//IL_0297: Expected O, but got F4
		//IL_0344: Expected O, but got F4
		//IL_03f7: Expected O, but got F4
		//IL_04aa: Expected O, but got F4
		//IL_055d: Expected O, but got F4
		//IL_0610: Expected O, but got F4
		//IL_06bd: Expected O, but got F4
		//IL_076a: Expected O, but got F4
		//IL_0817: Expected O, but got F4
		//IL_08ca: Expected O, but got F4
		//IL_097d: Expected O, but got F4
		//IL_0a30: Expected O, but got F4
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebb: Expected O, but got Unknown
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Expected O, but got Unknown
		//IL_0f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Expected O, but got Unknown
		//IL_0c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Expected O, but got Unknown
		//IL_0c67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Expected O, but got Unknown
		//IL_0fa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa9: Expected O, but got Unknown
		//IL_0ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffe: Expected O, but got Unknown
		//IL_0e7b->IL0d94: Incompatible stack heights: 1 vs 0
		//IL_0b57->IL0d94: Incompatible stack heights: 1 vs 0
		//IL_0b79->IL0d94: Incompatible stack heights: 1 vs 0
		//IL_0ba8->IL0d94: Incompatible stack heights: 1 vs 0
		//IL_0d5e->IL0d5e: Incompatible stack heights: 15 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 0.01f;
		float num2 = num * 1000f;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = deltaTime2 * 0.02f;
		float num4 = num3 * 1000f;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num5 = deltaTime3 * 0.015f;
		float num6 = num5 * 1000f;
		float deltaTime4 = PauseSystem.DeltaTime;
		float num7 = deltaTime4 * 0.025f;
		float num8 = num7 * 1000f;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					TileSprite skyBlue = _skyBlue;
					if ((object)_skyBlue != null)
					{
						float num9 = num2 * _wind;
						object obj3 = num9 ^ -0f;
						float num10 = (float)obj3 * 0.01f;
						float scrollOffsetX = (skyBlue._xScrollOffset = num10 + skyBlue._xScrollOffset);
						if ((object)skyBlue._spriteScroller != null)
						{
							skyBlue._spriteScroller.SetScrollOffsetX(scrollOffsetX);
							TileSprite cloudsWhite = _cloudsWhite;
							if ((object)_cloudsWhite != null)
							{
								float num11 = num4 * _wind;
								object obj4 = num11 ^ -0f;
								float num12 = (float)obj4 * 0.01f;
								float scrollOffsetX2 = (cloudsWhite._xScrollOffset = num12 + cloudsWhite._xScrollOffset);
								if ((object)cloudsWhite._spriteScroller != null)
								{
									cloudsWhite._spriteScroller.SetScrollOffsetX(scrollOffsetX2);
									TileSprite cloudsBlue = _cloudsBlue;
									if ((object)_cloudsBlue != null)
									{
										float num13 = num6 * _wind;
										object obj5 = num13 ^ -0f;
										float num14 = (float)obj5 * 0.01f;
										float scrollOffsetX3 = (cloudsBlue._xScrollOffset = num14 + cloudsBlue._xScrollOffset);
										if ((object)cloudsBlue._spriteScroller != null)
										{
											cloudsBlue._spriteScroller.SetScrollOffsetX(scrollOffsetX3);
											TileSprite cloudsAddBlue = _cloudsAddBlue;
											if ((object)_cloudsAddBlue != null)
											{
												float num15 = num8 * _wind;
												object obj6 = num15 ^ -0f;
												float num16 = (float)obj6 * 0.01f;
												float scrollOffsetX4 = (cloudsAddBlue._xScrollOffset = num16 + cloudsAddBlue._xScrollOffset);
												if ((object)cloudsAddBlue._spriteScroller != null)
												{
													cloudsAddBlue._spriteScroller.SetScrollOffsetX(scrollOffsetX4);
													TileSprite skyBlue2 = _skyBlue;
													if ((object)_skyBlue != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
														float num17 = 0f * num2;
														object obj7 = num17 ^ -0f;
														float num18 = (float)obj7 * 0.01f;
														float scrollOffsetY = (skyBlue2._yScrollOffset = num18 + skyBlue2._yScrollOffset);
														if ((object)skyBlue2._spriteScroller != null)
														{
															skyBlue2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
															TileSprite cloudsWhite2 = _cloudsWhite;
															if ((object)_cloudsWhite != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
																float num19 = 0f * num4;
																object obj8 = num19 ^ -0f;
																float num20 = (float)obj8 * 0.01f;
																float scrollOffsetY2 = (cloudsWhite2._yScrollOffset = num20 + cloudsWhite2._yScrollOffset);
																if ((object)cloudsWhite2._spriteScroller != null)
																{
																	cloudsWhite2._spriteScroller.SetScrollOffsetY(scrollOffsetY2);
																	TileSprite cloudsBlue2 = _cloudsBlue;
																	if ((object)_cloudsBlue != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
																		float num21 = 0f * num6;
																		object obj9 = num21 ^ -0f;
																		float num22 = (float)obj9 * 0.01f;
																		float scrollOffsetY3 = (cloudsBlue2._yScrollOffset = num22 + cloudsBlue2._yScrollOffset);
																		if ((object)cloudsBlue2._spriteScroller != null)
																		{
																			cloudsBlue2._spriteScroller.SetScrollOffsetY(scrollOffsetY3);
																			TileSprite cloudsAddBlue2 = _cloudsAddBlue;
																			if ((object)_cloudsAddBlue != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
																				float num23 = 0f * num8;
																				object obj10 = num23 ^ -0f;
																				float num24 = (float)obj10 * 0.01f;
																				float scrollOffsetY4 = (cloudsAddBlue2._yScrollOffset = num24 + cloudsAddBlue2._yScrollOffset);
																				if ((object)cloudsAddBlue2._spriteScroller != null)
																				{
																					cloudsAddBlue2._spriteScroller.SetScrollOffsetY(scrollOffsetY4);
																					TileSprite skyRed = _skyRed;
																					if ((object)_skyRed != null)
																					{
																						float num25 = num2 * _wind;
																						object obj11 = num25 ^ -0f;
																						float num26 = (float)obj11 * 0.01f;
																						float scrollOffsetX5 = (skyRed._xScrollOffset = num26 + skyRed._xScrollOffset);
																						if ((object)skyRed._spriteScroller != null)
																						{
																							skyRed._spriteScroller.SetScrollOffsetX(scrollOffsetX5);
																							TileSprite cloudsRed = _cloudsRed;
																							if ((object)_cloudsRed != null)
																							{
																								float num27 = num6 * _wind;
																								object obj12 = num27 ^ -0f;
																								float num28 = (float)obj12 * 0.01f;
																								float scrollOffsetX6 = (cloudsRed._xScrollOffset = num28 + cloudsRed._xScrollOffset);
																								if ((object)cloudsRed._spriteScroller != null)
																								{
																									cloudsRed._spriteScroller.SetScrollOffsetX(scrollOffsetX6);
																									TileSprite cloudsAddRed = _cloudsAddRed;
																									if ((object)_cloudsAddRed != null)
																									{
																										float num29 = num8 * _wind;
																										object obj13 = num29 ^ -0f;
																										float num30 = (float)obj13 * 0.01f;
																										float scrollOffsetX7 = (cloudsAddRed._xScrollOffset = num30 + cloudsAddRed._xScrollOffset);
																										if ((object)cloudsAddRed._spriteScroller != null)
																										{
																											cloudsAddRed._spriteScroller.SetScrollOffsetX(scrollOffsetX7);
																											TileSprite skyRed2 = _skyRed;
																											if ((object)_skyRed != null)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
																												float num31 = 0f * num2;
																												object obj14 = num31 ^ -0f;
																												float num32 = (float)obj14 * 0.01f;
																												float scrollOffsetY5 = (skyRed2._yScrollOffset = num32 + skyRed2._yScrollOffset);
																												if ((object)skyRed2._spriteScroller != null)
																												{
																													skyRed2._spriteScroller.SetScrollOffsetY(scrollOffsetY5);
																													TileSprite cloudsRed2 = _cloudsRed;
																													if ((object)_cloudsRed != null)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
																														float num33 = 0f * num4;
																														object obj15 = num33 ^ -0f;
																														float num34 = (float)obj15 * 0.01f;
																														float scrollOffsetY6 = (cloudsRed2._yScrollOffset = num34 + cloudsRed2._yScrollOffset);
																														if ((object)cloudsRed2._spriteScroller != null)
																														{
																															cloudsRed2._spriteScroller.SetScrollOffsetY(scrollOffsetY6);
																															TileSprite cloudsAddRed2 = _cloudsAddRed;
																															if ((object)_cloudsAddRed != null)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v42 (PhaserScene+Renderer)+40]");
																																float num35 = 0f * num6;
																																object obj16 = num35 ^ -0f;
																																float num36 = (float)obj16 * 0.01f;
																																float scrollOffsetY7 = (cloudsAddRed2._yScrollOffset = num36 + cloudsAddRed2._yScrollOffset);
																																if ((object)cloudsAddRed2._spriteScroller != null)
																																{
																																	cloudsAddRed2._spriteScroller.SetScrollOffsetY(scrollOffsetY7);
																																	object enemyMaddener = _enemyMaddener;
																																	if ((object)_enemyMaddener != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v15 (System.Object)+10]");
																																		if ((nint)0 != 0)
																																		{
																																			if ((object)_enemyMaddener != null)
																																			{
																																				Transform transform = _enemyMaddener.transform;
																																				if ((object)transform != null)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v80 (UnityEngine.Transform)+10]");
																																					bool flag = (nint)0 == 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v80 (UnityEngine.Transform)+10]");
																																					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
																																					GameManager core = GM.Core;
																																					if ((object)GM.Core != null)
																																					{
																																						GameSessionData gameSessionData = core._gameSessionData;
																																						if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
																																						{
																																							Transform transform2 = gameSessionData._activeCharacter.transform;
																																							if ((object)transform2 != null)
																																							{
																																								_ = 0;
																																								_ = 0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rax_v89 (UnityEngine.Transform)+10]");
																																								bool flag2 = (nint)0 == 0;
																																								object obj17 = obj - 121;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rax_v89 (UnityEngine.Transform)+10]");
																																								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj17);
																																								bool flag3 = (object)_shootingRay == null;
																																								Transform transform3 = _shootingRay.transform;
																																								bool flag4 = (object)_shootingRing == null;
																																								Transform transform4 = _shootingRing.transform;
																																								bool flag5 = (object)transform4 == null;
																																								_ = 0;
																																								bool flag6 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																																								object obj18 = obj - 105;
																																								Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj18);
																																								bool flag7 = (object)transform3 == null;
																																								_ = 0;
																																								bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																																								object obj19 = obj - 89;
																																								Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj19);
																																								bool flag9 = (object)_shootingRay == null;
																																								Transform transform5 = _shootingRay.transform;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-75]");
																																								object obj21 = default(object);
																																								object obj20 = obj21 - 0;
																																								Vector3 vector = ret;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
																																								object obj22 = vector - 0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
																																								float num37 = (float)obj20 * 57.29578f;
																																								float num38 = num37 * ((float)Math.PI / 180f);
																																								object obj23 = obj - 121;
																																								Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj23, out *(Quaternion*)(&ret));
																																								bool flag10 = (object)transform5 == null;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1766 @ rax_v105 (UnityEngine.Transform)+10]");
																																								bool flag11 = (nint)0 == 0;
																																								object obj24 = obj - 73;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1766 @ rax_v105 (UnityEngine.Transform)+10]");
																																								Transform.set_localRotation_Injected((IntPtr)0, ref *(Quaternion*)obj24);
																																								EnemyMaddener enemyMaddener2 = _enemyMaddener;
																																								bool flag12 = (object)_enemyMaddener == null;
																																								bool flag13 = (object)((EnemyController)enemyMaddener2)._EnemyRenderer == null;
																																								int sortingOrder = ((EnemyController)enemyMaddener2)._EnemyRenderer.sortingOrder;
																																								bool flag14 = (object)_shootingRing == null;
																																								int sortingOrder2 = sortingOrder - 1;
																																								_shootingRing.sortingOrder = sortingOrder2;
																																								bool flag15 = (object)_shootingRay == null;
																																								int sortingOrder3 = sortingOrder - 1;
																																								_shootingRay.sortingOrder = sortingOrder3;
																																								goto IL_0d5e;
																																							}
																																						}
																																					}
																																				}
																																			}
																																			goto IL_0d94;
																																		}
																																	}
																																	goto IL_0d5e;
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
		goto IL_0d94;
		IL_0d94:
		throw new NullReferenceException();
		IL_0d5e:
		if (_shootingEyesManager != null)
		{
			_shootingEyesManager.InternalUpdate();
		}
		CheckDistanceFromRosary();
	}

	protected override void OnDestroy()
	{
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		if ((object)_fishEyeRenderFeature != null && ((UnityEngine.Object)fishEyeRenderFeature).m_CachedPtr != (IntPtr)0)
		{
			FishEyeRenderFeature fishEyeRenderFeature2 = _fishEyeRenderFeature;
			((ScriptableRendererFeature)fishEyeRenderFeature2).m_Active = false;
		}
		SoundManager.StopSound(SfxType.Wind);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CFlashingVFXEnabled_003Ek__BackingField = _saveOption;
		if (_tweenExplosions != null)
		{
			DG.Tweening.TweenExtensions.Kill(_tweenExplosions);
		}
		if (_permanentVfxTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_permanentVfxTween);
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
		Action<Pickup> value2 = OnRemoteItemInstantiated;
		Delegate obj3 = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value2);
		if ((object)obj3 == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Pickup> action2 = default(Action<Pickup>);
			if (action2 == null)
			{
				throw new InvalidCastException();
			}
			ItemInstantiator.OnRemoteItemInstantiated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				throw new InvalidCastException();
			}
		}
		base.OnDestroy();
	}

	public override void CustomPreload(Action onComplete)
	{
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		Action<Action> loadCall = _003C_003Ec._003C_003E9__41_0;
		if (_003C_003Ec._003C_003E9__41_0 == null)
		{
			loadCall = (_003C_003Ec._003C_003E9__41_0 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.Wind, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall);
		asyncLoader.Load();
	}

	public unsafe override void Create()
	{
		//IL_0ad9: Expected F4, but got I4
		//IL_00ba: Expected F4, but got I4
		//IL_0b64: Expected F4, but got I4
		//IL_00fd: Expected F4, but got I4
		//IL_0249: Expected F4, but got I4
		//IL_01a3: Expected F4, but got I4
		//IL_02a4: Expected F4, but got I4
		//IL_017c: Expected O, but got I4
		//IL_01e6: Expected F4, but got I4
		//IL_03c3: Expected F4, but got I4
		//IL_03e9: Expected O, but got I
		//IL_0409: Expected F4, but got I4
		//IL_0c19: Expected F4, but got O
		//IL_0474: Expected F4, but got O
		//IL_04b0: Expected F4, but got O
		//IL_0c7b: Expected F4, but got O
		//IL_05ad: Expected F4, but got O
		//IL_05e9: Expected F4, but got O
		//IL_0cca: Expected F4, but got O
		//IL_0821: Expected O, but got I
		//IL_06da: Expected I, but got O
		//IL_06f0: Expected O, but got I
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected O, but got Unknown
		//IL_0869: Expected O, but got I
		//IL_0772: Expected F4, but got O
		//IL_079f: Expected I, but got O
		//IL_0d4d: Expected O, but got I4
		//IL_0d64: Expected I, but got I8
		//IL_0750: Expected I, but got I8
		//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0902: Expected O, but got Unknown
		//IL_0a99: Expected I, but got O
		base.Create();
		bool flag = (object)GM.Core == null;
		float num = 0f;
		int num2;
		PlayerOptions playerOptions;
		_003CInitFishEye_003Ed__47 obj2;
		Action<float> action2;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if (!flag)
		{
			if (!GM.Core.IsStageHost)
			{
				Action<EnemyController> b = OnRemoteEnemySpawned;
				Delegate obj = Delegate.Combine(EnemyInstantiator.OnRemoteEnemySpawned, b);
				PickupRelic pickupRelic;
				if ((object)obj == null)
				{
					EnemyInstantiator.OnRemoteEnemySpawned = null;
					num2 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Action<EnemyController> action = default(Action<EnemyController>);
					bool flag2 = action == null;
					num = 0f;
					action2 = null;
					obj2 = null;
					if (flag2)
					{
						throw new InvalidCastException();
					}
					EnemyInstantiator.OnRemoteEnemySpawned = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					bool flag3 = obj3 == null;
					num = 0f;
					action2 = null;
					obj2 = null;
					pickupRelic = (PickupRelic)(object)obj;
					if (flag3)
					{
						throw new InvalidCastException();
					}
					num2 = 0;
				}
				Action<Pickup> b2 = OnRemoteItemInstantiated;
				Delegate obj4 = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b2);
				if ((object)obj4 == null)
				{
					ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)num2;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Action<Pickup> action3 = default(Action<Pickup>);
					bool flag4 = action3 == null;
					num = 0f;
					action2 = null;
					obj2 = null;
					if (flag4)
					{
						throw new InvalidCastException();
					}
					ItemInstantiator.OnRemoteItemInstantiated = action3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					bool flag5 = obj5 == null;
					num = 0f;
					action2 = null;
					obj2 = null;
					pickupRelic = (PickupRelic)(object)obj4;
					if (flag5)
					{
						throw new InvalidCastException();
					}
				}
				pickupRelic = (PickupRelic)(object)obj4;
			}
			else
			{
				num2 = 0;
			}
			_checkRosaryTimerRepeatCount = num2;
			_tweenExplosionsTimerRepeatCount = num2;
			_003CInitFishEye_003Ed__47 obj6 = null;
			obj6._003C_003E1__state = num2;
			obj6._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj6);
			GameManager core = GM.Core;
			bool flag6 = (object)GM.Core == null;
			num = 0f;
			action2 = null;
			obj2 = obj6;
			if (!flag6)
			{
				bool flag7 = core._diContainer == null;
				num = 0f;
				action2 = null;
				obj2 = obj6;
				if (!flag7)
				{
					ShootingEyesManager shootingEyesManager = core._diContainer.Instantiate<ShootingEyesManager>();
					_shootingEyesManager = shootingEyesManager;
					action2 = null;
					bool flag8 = _shootingEyesManager == null;
					num = 0f;
					obj2 = obj6;
					if (!flag8)
					{
						_shootingEyesManager.Initialize();
						GenerateSprites();
						base._003CAlias_003Ek__BackingField = false;
						_wind = 1f;
						Pickup pickupItemFromWorld = PickupManager.GetPickupItemFromWorld(ItemType.ROSARY);
						if ((object)pickupItemFromWorld != null && ((UnityEngine.Object)pickupItemFromWorld).m_CachedPtr != (IntPtr)0)
						{
							_rosary = pickupItemFromWorld;
						}
						PickupRelic relicItemFromWorld = PickupManager.GetRelicItemFromWorld(ItemType.RELIC_YELLOW);
						if ((object)relicItemFromWorld != null && ((UnityEngine.Object)relicItemFromWorld).m_CachedPtr != (IntPtr)0)
						{
							OnYellowRelicFound(relicItemFromWorld);
							action2 = null;
						}
						RemovePowers();
						obj2 = (_003CInitFishEye_003Ed__47)(object)GM.Core;
						bool flag9 = (object)GM.Core == null;
						num = 0f;
						PickupRelic pickupRelic = relicItemFromWorld;
						if (!flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ r9_v31 (VampireSurvivors.Objects.Stages.BackgroundX+<InitFishEye>d__47)+298]");
							obj2 = (_003CInitFishEye_003Ed__47)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ r9_v31 (VampireSurvivors.Objects.Stages.BackgroundX+<InitFishEye>d__47)+298]");
							bool flag10 = (nint)0 == 0;
							num = 0f;
							pickupRelic = relicItemFromWorld;
							if (!flag10)
							{
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
								while (enumerator.MoveNext())
								{
									SetupCharacterAnimation(null);
									action2 = null;
								}
								GameManager core2 = GM.Core;
								bool flag11 = (object)GM.Core == null;
								characterController = null;
								num = (float)obj2;
								pickupRelic = relicItemFromWorld;
								if (!flag11)
								{
									core2._003CCanPause_003Ek__BackingField = false;
									UpdatePlayerOptions();
									pickupRelic = (PickupRelic)(object)GM.Core;
									bool flag12 = (object)GM.Core == null;
									characterController = null;
									num = (float)obj2;
									if (!flag12)
									{
										pickupRelic = (PickupRelic)(object)pickupRelic._spriteAnimation;
										bool flag13 = (object)pickupRelic._spriteAnimation == null;
										characterController = null;
										num = (float)obj2;
										if (!flag13)
										{
											if (((Pickup)pickupRelic)._playerOptions == null)
											{
												if ((object)((BasePoolableSpriteBehaviour)pickupRelic)._ParentPool == null)
												{
													if (((Pickup)pickupRelic)._gameSessionData != null)
													{
														playerOptions = (PlayerOptions)(object)((Pickup)pickupRelic)._gameSessionData;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v87 (VampireSurvivors.Objects.PlayerOptions)+2CC]");
														if ((nint)0 != 0)
														{
															goto IL_0c5f;
														}
													}
													playerOptions = (PlayerOptions)(object)((ArcadeSprite)pickupRelic)._cachedTrans;
												}
												else
												{
													playerOptions = (PlayerOptions)(object)((BasePoolableSpriteBehaviour)pickupRelic)._ParentPool;
												}
											}
											else
											{
												playerOptions = ((Pickup)pickupRelic)._playerOptions;
											}
											goto IL_0c5f;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a36;
		IL_0d44:
		object obj7 = 24;
		Action action4;
		((Delegate)action4).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__42_0 = action4;
		Action onComplete = action4;
		goto IL_07a4;
		IL_0a36:
		throw new NullReferenceException();
		IL_0cae:
		PlayerOptions playerOptions2;
		bool flag14 = playerOptions2 == null;
		characterController = null;
		num = (float)obj2;
		if (flag14)
		{
			goto IL_0a36;
		}
		_ = 1;
		SoundManager.StopMusic(BgmType.BGM_Chapet);
		onComplete = _003C_003Ec._003C_003E9__42_0;
		if (_003C_003Ec._003C_003E9__42_0 != null)
		{
			goto IL_07a4;
		}
		action4 = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ r10_v20 (Il2CppMethodInfo)+8]");
		((Delegate)action4).method_ptr = (IntPtr)0;
		((Delegate)action4).method = (nint)__ldftn(_003C_003Ec._003CCreate_003Eb__42_0);
		((Delegate)action4).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action4).method_code = (IntPtr)action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ r10_v20 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		nint num4;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ r10_v20 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num4 = unchecked((nint)6447293664L);
				goto IL_0d44;
			}
		}
		else
		{
			bool flag15 = _003C_003Ec._003C_003E9 == null;
			characterController = null;
			num = (float)obj2;
			if (flag15)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
				object obj10 = default(object);
				throw obj10;
			}
		}
		num4 = ((Delegate)action4).method_ptr;
		((Delegate)action4).method_code = (IntPtr)((Delegate)action4).m_target;
		goto IL_0d44;
		IL_07a4:
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(4f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)num2 != 0);
		obj2 = (_003CInitFishEye_003Ed__47)(object)GM.Core;
		bool flag16 = (object)GM.Core == null;
		characterController = null;
		num = 4f;
		action2 = null;
		if (!flag16)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ r9_v31 (VampireSurvivors.Objects.Stages.BackgroundX+<InitFishEye>d__47)+B8]");
			obj2 = (_003CInitFishEye_003Ed__47)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ r9_v31 (VampireSurvivors.Objects.Stages.BackgroundX+<InitFishEye>d__47)+B8]");
			bool flag17 = (nint)0 == 0;
			characterController = null;
			num = 4f;
			action2 = null;
			if (!flag17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ r9_v31 (VampireSurvivors.Objects.Stages.BackgroundX+<InitFishEye>d__47)+C0]");
				obj2 = (_003CInitFishEye_003Ed__47)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ r9_v31 (VampireSurvivors.Objects.Stages.BackgroundX+<InitFishEye>d__47)+C0]");
				bool flag18 = (nint)0 == 0;
				characterController = null;
				num = 4f;
				action2 = null;
				if (!flag18)
				{
					object obj11 = default(object);
					object obj12 = default(object);
					object obj14 = default(object);
					Vector2 pos = default(Vector2);
					while (true)
					{
						Stage stage3;
						PropType destructibleType;
						if (obj11 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ stack_-80_v15+1C]");
							if (obj12 != null)
							{
								break;
							}
							object obj13 = obj14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ stack_-80_v15+18]");
							if ((nint)obj13 >= 0)
							{
								break;
							}
							obj14++;
							GameManager core3 = GM.Core;
							Stage stage = core3._stage;
							stage._003CMaxDestructibles_003Ek__BackingField = 108;
							GameManager core4 = GM.Core;
							Stage stage2 = core4._stage;
							Vector2 defaultMapPosition = stage2._tilingTileset.DefaultMapPosition;
							GameManager core5 = GM.Core;
							stage3 = core5._stage;
							StageData stageData = stage3._stageData;
							if (stage3._stageData != null)
							{
								string text = stageData._003CdestructibleType_003Ek__BackingField;
								if (stageData._003CdestructibleType_003Ek__BackingField != null && text._stringLength > 0)
								{
									destructibleType = Enum.Parse<PropType>(stageData._003CdestructibleType_003Ek__BackingField);
									goto IL_0dd3;
								}
							}
							destructibleType = PropType.BRAZIER;
							goto IL_0dd3;
						}
						throw new NullReferenceException();
						IL_0dd3:
						Destructible destructible = stage3.MakeDestructible(destructibleType, pos);
					}
					bool flag19 = obj11 == null;
					nint num5 = 0;
					if (!flag19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ stack_-80_v15+1C]");
						if (obj12 == null)
						{
							SetupTimers();
							return;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						num5 = unchecked((nint)null);
					}
					throw new NullReferenceException();
				}
			}
		}
		goto IL_0a36;
		IL_0c5f:
		bool flag20 = playerOptions == null;
		characterController = null;
		num = (float)obj2;
		if (!flag20)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v87 (VampireSurvivors.Objects.PlayerOptions)+118]");
			_saveOption = false;
			PickupRelic pickupRelic = (PickupRelic)(object)GM.Core;
			bool flag21 = (object)GM.Core == null;
			characterController = null;
			num = (float)obj2;
			if (!flag21)
			{
				pickupRelic = (PickupRelic)(object)pickupRelic._spriteAnimation;
				bool flag22 = (object)pickupRelic._spriteAnimation == null;
				characterController = null;
				num = (float)obj2;
				if (!flag22)
				{
					if (((Pickup)pickupRelic)._playerOptions == null)
					{
						if ((object)((BasePoolableSpriteBehaviour)pickupRelic)._ParentPool == null)
						{
							if (((Pickup)pickupRelic)._gameSessionData != null)
							{
								playerOptions2 = (PlayerOptions)(object)((Pickup)pickupRelic)._gameSessionData;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v91 (VampireSurvivors.Objects.PlayerOptions)+2CC]");
								if ((nint)0 != 0)
								{
									goto IL_0cae;
								}
							}
							playerOptions2 = (PlayerOptions)(object)((ArcadeSprite)pickupRelic)._cachedTrans;
						}
						else
						{
							playerOptions2 = (PlayerOptions)(object)((BasePoolableSpriteBehaviour)pickupRelic)._ParentPool;
						}
					}
					else
					{
						playerOptions2 = ((Pickup)pickupRelic)._playerOptions;
					}
					goto IL_0cae;
				}
			}
		}
		goto IL_0a36;
	}

	private void OnRemoteItemInstantiated(Pickup item)
	{
		if (item._003CPickupType_003Ek__BackingField == ItemType.RELIC)
		{
			PickupRelic component = item.GetComponent<PickupRelic>();
			if (component._itemType == ItemType.RELIC_YELLOW)
			{
				OnYellowRelicFound(component);
			}
		}
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		//IL_0018: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_01b7: Expected I4, but got I8
		//IL_01bc->IL01bc: Incompatible stack heights: 1 vs 0
		if ((object)enemy != null)
		{
			object obj = enemy._enemyType - 185;
			if ((nint)obj <= 2)
			{
				EnemySpin component = enemy.GetComponent<EnemySpin>();
				if ((object)component != null)
				{
					EnemyController enemyRenderer = (EnemyController)(object)((EnemyController)component)._EnemyRenderer;
					component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
					if ((object)((EnemyController)component)._EnemyRenderer != null)
					{
						bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
						return;
					}
				}
			}
			else
			{
				if (enemy._enemyType != EnemyType.MOON_SHADE)
				{
					if (enemy._enemyType == EnemyType.BOSS_XLMADDENER)
					{
						EnemyMaddener component2 = enemy.GetComponent<EnemyMaddener>();
						_enemyMaddener = component2;
					}
					return;
				}
				EnemyData currentEnemyData = enemy._currentEnemyData;
				if (enemy._currentEnemyData != null)
				{
					currentEnemyData._003Cxp_003Ek__BackingField = 0f;
					enemy._003CSelfDestDistance_003Ek__BackingField = 1200000f;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		ParticleEmitterManager particleEmitterManager = _particleEmitterManager;
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if ((object)_particleEmitterManager != null && ((UnityEngine.Object)particleEmitterManager).m_CachedPtr != (IntPtr)0)
		{
			_particleEmitterManager.StopAllEmitters();
		}
		ParticleEmitterManager particleEmitterManagerRed = _particleEmitterManagerRed;
		if ((object)_particleEmitterManagerRed != null && ((UnityEngine.Object)particleEmitterManagerRed).m_CachedPtr != (IntPtr)0)
		{
			_particleEmitterManagerRed.StopAllEmitters();
		}
		ParticleEmitterManager particleEmitterManagerRedBelow = _particleEmitterManagerRedBelow;
		if ((object)_particleEmitterManagerRedBelow != null && ((UnityEngine.Object)particleEmitterManagerRedBelow).m_CachedPtr != (IntPtr)0)
		{
			_particleEmitterManagerRedBelow.StopAllEmitters();
		}
		SoundManager.StopSound(SfxType.Wind);
	}

	public unsafe override void RosaryTriggered()
	{
		if (_hasRosaryBeenTriggered)
		{
			return;
		}
		_hasRosaryBeenTriggered = true;
		Action onComplete = delegate
		{
			//IL_0844: Expected I, but got O
			//IL_002b: Expected I, but got O
			//IL_005f: Expected I, but got O
			//IL_0086: Expected I, but got O
			//IL_00d0: Expected I, but got O
			//IL_0104: Expected I, but got O
			//IL_014c: Expected I, but got O
			//IL_016d: Expected O, but got I4
			//IL_0172: Expected I, but got O
			//IL_0197: Expected I, but got O
			//IL_04a2: Expected O, but got I4
			//IL_0500: Expected F4, but got I4
			//IL_0459: Expected I, but got O
			//IL_0549: Expected F4, but got I4
			//IL_0598: Expected F4, but got I4
			//IL_02dd: Expected I4, but got O
			//IL_02ed: Expected O, but got I
			//IL_030a: Expected O, but got I
			//IL_05e1: Expected F4, but got I4
			//IL_03be: Expected I, but got O
			//IL_0872: Unknown result type (might be due to invalid IL or missing references)
			//IL_0877: Expected O, but got Unknown
			//IL_0882: Expected O, but got I4
			//IL_0355: Expected O, but got I
			//IL_036a: Expected O, but got I
			//IL_08eb: Expected F4, but got I4
			//IL_0665: Expected F4, but got I4
			//IL_06a1: Expected F4, but got I4
			//IL_0931: Expected F4, but got I4
			//IL_0715: Expected I, but got O
			//IL_072b: Expected O, but got I
			//IL_0734: Unknown result type (might be due to invalid IL or missing references)
			//IL_0739: Expected O, but got Unknown
			//IL_07a9: Expected F4, but got I4
			//IL_07de: Expected I, but got O
			//IL_09a4: Expected O, but got I4
			//IL_09bb: Expected I, but got I8
			//IL_078b: Expected I, but got I8
			base._003CAlias_003Ek__BackingField = false;
			ToggleBlue(visible: true);
			ToggleRed(visible: false);
			_wind = 1f;
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			nint num = unchecked((nint)null);
			nint num2;
			int num4 = default(int);
			if (!flag)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				bool flag2 = core._gameSessionData == null;
				num = unchecked((nint)null);
				if (!flag2)
				{
					VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
					bool flag3 = (object)gameSessionData._activeCharacter == null;
					num = unchecked((nint)null);
					if (!flag3)
					{
						bool flag4 = (object)activeCharacter._spriteAnimation == null;
						num = unchecked((nint)null);
						if (!flag4)
						{
							activeCharacter._spriteAnimation.SetAnimation("walk");
							StopAllTimers();
							GameManager core2 = GM.Core;
							bool flag5 = (object)GM.Core == null;
							num = unchecked((nint)null);
							if (!flag5)
							{
								Stage stage = core2._stage;
								bool flag6 = (object)core2._stage == null;
								num = unchecked((nint)null);
								if (!flag6)
								{
									List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
									bool flag7 = (nint)stage._spawnedEnemies < 0;
									bool flag8 = stage._spawnedEnemies == null;
									num = unchecked((nint)null);
									if (!flag8)
									{
										object obj = spawnedEnemies._size - 1;
										num2 = unchecked((nint)null);
										if (flag7)
										{
											goto IL_03cb;
										}
										int num3 = num4;
										num = (nint)typeof(EnemyMaddener);
										while (true)
										{
											GameManager core3 = GM.Core;
											bool flag9 = (object)GM.Core == null;
											num4 = num3;
											if (flag9)
											{
												break;
											}
											Stage stage2 = core3._stage;
											bool flag10 = (object)core3._stage == null;
											num4 = num3;
											if (flag10)
											{
												break;
											}
											List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
											bool flag11 = stage2._spawnedEnemies == null;
											num4 = num3;
											if (flag11)
											{
												break;
											}
											bool flag12 = (nint)obj >= spawnedEnemies2._size;
											num4 = num3;
											if (flag12)
											{
												goto IL_0852;
											}
											EnemyController[] items = spawnedEnemies2._items;
											bool flag13 = spawnedEnemies2._items == null;
											num4 = num3;
											if (flag13)
											{
												break;
											}
											bool flag14 = (nint)obj >= items.Length;
											num4 = num3;
											if (flag14)
											{
												throw new IndexOutOfRangeException();
											}
											EnemyController enemyController = items[obj];
											bool flag15 = (object)items[obj] == null;
											num4 = num3;
											if (flag15)
											{
												break;
											}
											num4 = (int)enemyController;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener>)+130]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v5 (System.Int32)+130]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener>)+130]");
											object obj3 = num5 - 0;
											bool flag16 = (nint)obj3 < 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v5 (System.Int32)+130]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener>)+130]");
											bool flag18;
											if (num6 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v5 (System.Int32)+C8]");
												object obj4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rax_v102+FFFFFFF8+v751 @ rax_v98*8]");
												object obj5 = -num;
												flag16 = (nint)obj5 < 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rax_v102+FFFFFFF8+v751 @ rax_v98*8]");
												bool flag17 = 0 == num;
												flag18 = flag16;
												if (flag17)
												{
													goto IL_0869;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v100 @ r9_v5 (System.Int32)+388] (should have been resolved before IL gen)");
											num = (nint)typeof(EnemyMaddener);
											flag18 = flag16;
											goto IL_0869;
											IL_0869:
											obj--;
											object obj6 = !flag18;
											num2 = num;
											num3 = num4;
											if (obj6 != null)
											{
												continue;
											}
											goto IL_03cb;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_07ee;
			IL_0852:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			goto IL_09d1;
			IL_07ee:
			throw new NullReferenceException();
			IL_03cb:
			StopRedEmitters();
			EnemyMaddener enemyMaddener = _enemyMaddener;
			if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
			{
				bool flag19 = (object)_enemyMaddener == null;
				num = num2;
				if (flag19)
				{
					goto IL_07ee;
				}
				_enemyMaddener.GetDamaged(108f, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
				num2 = unchecked((nint)null);
			}
			else
			{
				Debug.LogWarning("[GURU] EnemyMaddener is invalid, cannot damage");
			}
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Loop = true;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Wind, soundConfig, 0f, 10, time);
			GameManager core4 = GM.Core;
			bool flag20 = (object)GM.Core == null;
			float num7 = 0f;
			num4 = 10;
			num = num2;
			TweenCallback callback;
			TweenCallback tweenCallback;
			if (!flag20)
			{
				Stage stage3 = core4._stage;
				bool flag21 = (object)core4._stage == null;
				num7 = 0f;
				num4 = 10;
				num = num2;
				if (!flag21)
				{
					stage3._003CPause_003Ek__BackingField = 2.1474836E+09f;
					GameManager core5 = GM.Core;
					bool flag22 = (object)GM.Core == null;
					num7 = 0f;
					num4 = 10;
					num = num2;
					if (!flag22)
					{
						Stage stage4 = core5._stage;
						bool flag23 = (object)core5._stage == null;
						num7 = 0f;
						num4 = 10;
						num = num2;
						if (!flag23)
						{
							if (stage4._spawnTimer != null)
							{
								stage4._spawnTimer.Cancel();
							}
							GameManager core6 = GM.Core;
							bool flag24 = (object)GM.Core == null;
							num7 = 0f;
							num4 = 10;
							num = num2;
							if (!flag24)
							{
								core6._003CCanInterrupt_003Ek__BackingField = true;
								GameManager core7 = GM.Core;
								bool flag25 = (object)GM.Core == null;
								num7 = 0f;
								num4 = 10;
								num = num2;
								if (!flag25)
								{
									bool flag26 = core7._multiplayer == null;
									num7 = 0f;
									num4 = 10;
									num = num2;
									if (!flag26)
									{
										if (core7._multiplayer.IsOnlineMultiplayer)
										{
											OnlineStageManager instance = OnlineStageManager._instance;
											bool flag27 = (object)OnlineStageManager._instance == null;
											num7 = 0f;
											num4 = 10;
											num = num2;
											if (flag27)
											{
												goto IL_07ee;
											}
											instance._003CListenForHostDisconnection_003Ek__BackingField = false;
										}
										callback = _003C_003Ec._003C_003E9__46_1;
										if (_003C_003Ec._003C_003E9__46_1 != null)
										{
											goto IL_07e3;
										}
										tweenCallback = null;
										nint num8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r10_v8 (Il2CppMethodInfo)+8]");
										((Delegate)tweenCallback).method_ptr = (IntPtr)0;
										((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec._003CRosaryTriggered_003Eb__46_1);
										((Delegate)tweenCallback).m_target = _003C_003Ec._003C_003E9;
										num4 = 10;
										((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r10_v8 (Il2CppMethodInfo)+4C]");
										object obj7 = (nint)0 >> 4;
										object obj8 = obj7 & 1;
										nint num9;
										if (obj8 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r10_v8 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num9 = unchecked((nint)6447293664L);
												goto IL_099b;
											}
										}
										else
										{
											bool flag28 = _003C_003Ec._003C_003E9 == null;
											num7 = 0f;
											num = num2;
											if (flag28)
											{
												goto IL_09d1;
											}
										}
										num9 = ((Delegate)tweenCallback).method_ptr;
										((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
										goto IL_099b;
									}
								}
							}
						}
					}
				}
			}
			goto IL_07ee;
			IL_07e3:
			TweenFishEye(callback);
			return;
			IL_099b:
			object obj9 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			_003C_003Ec._003C_003E9__46_1 = tweenCallback;
			callback = tweenCallback;
			goto IL_07e3;
			IL_09d1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
			object obj10 = default(object);
			throw obj10;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		BgmType bgmType = default(BgmType);
		SoundManager.FadeMusic(bgmType, 0f, 100f);
	}

	private IEnumerator InitFishEye()
	{
		_003CInitFishEye_003Ed__47 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void TweenFishEye(TweenCallback callback)
	{
		//IL_0012: Expected O, but got I8
		//IL_01cc: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0529: Expected O, but got I4
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Expected O, but got Unknown
		//IL_018e: Expected O, but got I4
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_057b: Expected O, but got I4
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass48_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		float floatImpl = fishEyeRenderFeature.passMaterial.GetFloatImpl(Intensity);
		CS_0024_003C_003E8__locals11.intensity = floatImpl;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass48_0)(object)dOSetter)._003CTweenFishEye_003Eb__1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.2f, 30.000002f);
		object obj9;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v436 @ rdx_v36*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v436 @ rdx_v36*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v436 @ rdx_v36*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v436 @ rdx_v36*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v436 @ rdx_v36*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						BackgroundX backgroundX = CS_0024_003C_003E8__locals11._003C_003E4__this;
						FishEyeRenderFeature fishEyeRenderFeature3 = backgroundX._fishEyeRenderFeature;
						fishEyeRenderFeature3.passMaterial.SetFloatImpl(Intensity, CS_0024_003C_003E8__locals11.intensity);
					};
					obj9 = 0;
					tweenCallback2 = tweenCallback;
					goto IL_01eb;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			BackgroundX backgroundX = CS_0024_003C_003E8__locals11._003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature3 = backgroundX._fishEyeRenderFeature;
			fishEyeRenderFeature3.passMaterial.SetFloatImpl(Intensity, CS_0024_003C_003E8__locals11.intensity);
		};
		bool flag2 = tweenerCore == null;
		obj9 = 0;
		tweenCallback2 = tweenCallback3;
		object obj10 = 0;
		if (!flag2)
		{
			goto IL_01eb;
		}
		goto IL_022a;
		IL_0470:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return;
		IL_022a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FishEyeRenderFeature fishEyeRenderFeature2 = _fishEyeRenderFeature;
		float floatImpl2 = fishEyeRenderFeature2.passMaterial.GetFloatImpl(Radius);
		CS_0024_003C_003E8__locals11.radius = floatImpl2;
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((_003C_003Ec__DisplayClass48_0)(object)dOSetter2)._003CTweenFishEye_003Eb__4(x);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 0.01f, 30.000002f);
		TweenCallback tweenCallback5;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag3 = (nint)0 == 0;
				_ = 0;
				if (!flag3)
				{
					object obj11 = tweenerCore2 + 184;
					object obj12 = obj11 >> 12;
					object obj13 = obj12 & 0x1FFFFF;
					object obj14 = obj13 >> 6;
					object obj15 = obj13 & 0x3F;
					nint num4;
					do
					{
						object obj16 = 1 << (int)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v725 @ rdx_v27*8]");
						object obj17 = 0 | obj16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v725 @ rdx_v27*8]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v725 @ rdx_v27*8]");
						if (num3 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v725 @ rdx_v27*8]");
						num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r15_v2+462E0+v725 @ rdx_v27*8]");
					}
					while (num4 != 0);
					TweenCallback tweenCallback4 = delegate
					{
						BackgroundX backgroundX = CS_0024_003C_003E8__locals11._003C_003E4__this;
						FishEyeRenderFeature fishEyeRenderFeature3 = backgroundX._fishEyeRenderFeature;
						fishEyeRenderFeature3.passMaterial.SetFloatImpl(Radius, CS_0024_003C_003E8__locals11.radius);
					};
					tweenCallback5 = tweenCallback4;
					goto IL_0412;
				}
			}
		}
		TweenCallback tweenCallback6 = delegate
		{
			BackgroundX backgroundX = CS_0024_003C_003E8__locals11._003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature3 = backgroundX._fishEyeRenderFeature;
			fishEyeRenderFeature3.passMaterial.SetFloatImpl(Radius, CS_0024_003C_003E8__locals11.radius);
		};
		bool flag4 = tweenerCore2 == null;
		tweenCallback5 = tweenCallback6;
		if (!flag4)
		{
			goto IL_0412;
		}
		goto IL_0470;
		IL_0412:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		goto IL_0470;
		IL_01eb:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		bool flag5 = (nint)0 == 0;
		obj10 = obj9;
		if (!flag5)
		{
			obj10 = obj9;
		}
		goto IL_022a;
	}

	private void InitShootingEyesManager()
	{
		GameManager core = GM.Core;
		ShootingEyesManager shootingEyesManager = core._diContainer.Instantiate<ShootingEyesManager>();
		_shootingEyesManager = shootingEyesManager;
		_shootingEyesManager.Initialize();
	}

	private unsafe void GenerateSprites()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Expected O, but got Unknown
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6c: Expected O, but got Unknown
		//IL_0180: Expected F4, but got I
		//IL_0180: Expected F4, but got I
		//IL_0232: Expected F4, but got I
		//IL_0232: Expected F4, but got I
		//IL_02f2: Expected F4, but got I
		//IL_02f2: Expected F4, but got I
		//IL_03b2: Expected F4, but got I
		//IL_03b2: Expected F4, but got I
		//IL_0480: Expected F4, but got I
		//IL_0480: Expected F4, but got I
		//IL_0583: Expected F4, but got I
		//IL_0583: Expected F4, but got I
		//IL_0694: Expected F4, but got I
		//IL_0694: Expected F4, but got I
		//IL_07db: Expected F4, but got I
		//IL_07db: Expected F4, but got I
		//IL_00dd->IL09c9: Incompatible stack heights: 1 vs 0
		//IL_0bbf->IL09c9: Incompatible stack heights: 17 vs 0
		//IL_0c1f->IL09c9: Incompatible stack heights: 18 vs 0
		//IL_087f->IL09c9: Incompatible stack heights: 18 vs 0
		//IL_091e->IL09c9: Incompatible stack heights: 18 vs 0
		//IL_09a6->IL09c9: Incompatible stack heights: 18 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		Camera main = Camera.main;
		int2 renderTextureSize = VampireSurvivors.Tools.CameraExtensions.GetRenderTextureSize(main);
		object obj3 = (object)renderTextureSize >> 32;
		float tileWidth = (float)renderTextureSize / 100f;
		float tileHeight = (float)obj3 / 100f;
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj4 = obj - 89;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj4);
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "BackgroundXSpritesRoot");
				if ((object)gameObject != null)
				{
					Transform spritesRootTransform = gameObject.transform;
					_spritesRootTransform = spritesRootTransform;
					Camera spritesRootTransform2 = (Camera)(object)_spritesRootTransform;
					bool flag2 = (object)_spritesRootTransform == null;
					_ = 0;
					bool flag3 = ((UnityEngine.Object)spritesRootTransform2).m_CachedPtr == (IntPtr)0;
					object obj5 = obj - 73;
					Transform.set_position_Injected(((UnityEngine.Object)spritesRootTransform2).m_CachedPtr, ref *(Vector3*)obj5);
					bool flag4 = (object)_spritesRootTransform == null;
					_spritesRootTransform.SetParent(transform, worldPositionStays: true);
					GameObject go = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					string spriteName = default(string);
					TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, num, 0f, "backgroundX", spriteName);
					bool flag5 = tileSpriteBuilder == null;
					tileSpriteBuilder._depth = -32768f;
					tileSpriteBuilder._depthMul = 1f;
					tileSpriteBuilder._parent = _spritesRootTransform;
					tileSpriteBuilder._tileWidth = tileWidth;
					tileSpriteBuilder._tileHeight = tileHeight;
					tileSpriteBuilder._name = "SkyBlue";
					TileSprite skyBlue = tileSpriteBuilder.Build();
					_skyBlue = skyBlue;
					GameObject go2 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					TileSpriteBuilder tileSpriteBuilder2 = RenderingExtensions.AddTileSprite(go2, num2, 0f, "backgroundX", spriteName);
					bool flag6 = tileSpriteBuilder2 == null;
					tileSpriteBuilder2._depth = -32767f;
					tileSpriteBuilder2._depthMul = 1f;
					tileSpriteBuilder2._alpha = 0.75f;
					tileSpriteBuilder2._parent = _spritesRootTransform;
					tileSpriteBuilder2._tileWidth = tileWidth;
					tileSpriteBuilder2._tileHeight = tileHeight;
					tileSpriteBuilder2._name = "CloudsWhite";
					TileSprite cloudsWhite = tileSpriteBuilder2.Build();
					_cloudsWhite = cloudsWhite;
					GameObject go3 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					TileSpriteBuilder tileSpriteBuilder3 = RenderingExtensions.AddTileSprite(go3, num3, 0f, "backgroundX", spriteName);
					bool flag7 = tileSpriteBuilder3 == null;
					tileSpriteBuilder3._depth = -32766f;
					tileSpriteBuilder3._depthMul = 1f;
					tileSpriteBuilder3._alpha = 0.5f;
					tileSpriteBuilder3._parent = _spritesRootTransform;
					tileSpriteBuilder3._tileWidth = tileWidth;
					tileSpriteBuilder3._tileHeight = tileHeight;
					tileSpriteBuilder3._name = "CloudsBlue";
					TileSprite cloudsBlue = tileSpriteBuilder3.Build();
					_cloudsBlue = cloudsBlue;
					GameObject go4 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					TileSpriteBuilder tileSpriteBuilder4 = RenderingExtensions.AddTileSprite(go4, num4, 0f, "backgroundX", spriteName);
					bool flag8 = tileSpriteBuilder4 == null;
					tileSpriteBuilder4._depth = -32765f;
					tileSpriteBuilder4._depthMul = 1f;
					tileSpriteBuilder4._alpha = 0.5f;
					tileSpriteBuilder4._blendMode = BlendMode.Add;
					tileSpriteBuilder4._parent = _spritesRootTransform;
					tileSpriteBuilder4._tileWidth = tileWidth;
					tileSpriteBuilder4._tileHeight = tileHeight;
					tileSpriteBuilder4._name = "CloudsAddBlue";
					TileSprite cloudsAddBlue = tileSpriteBuilder4.Build();
					_cloudsAddBlue = cloudsAddBlue;
					GameObject go5 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					TileSpriteBuilder tileSpriteBuilder5 = RenderingExtensions.AddTileSprite(go5, num5, 0f, "backgroundX", spriteName);
					bool flag9 = tileSpriteBuilder5 == null;
					tileSpriteBuilder5._depth = -32768f;
					tileSpriteBuilder5._depthMul = 1f;
					tileSpriteBuilder5._parent = _spritesRootTransform;
					tileSpriteBuilder5._tileWidth = tileWidth;
					tileSpriteBuilder5._tileHeight = tileHeight;
					tileSpriteBuilder5._name = "SkyRed";
					TileSprite skyRed = tileSpriteBuilder5.Build();
					_skyRed = skyRed;
					bool flag10 = (object)_skyRed == null;
					GameObject gameObject2 = _skyRed.gameObject;
					bool flag11 = (object)gameObject2 == null;
					gameObject2.SetActive(value: false);
					GameObject go6 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					TileSpriteBuilder tileSpriteBuilder6 = RenderingExtensions.AddTileSprite(go6, num6, 0f, "backgroundX", spriteName);
					bool flag12 = tileSpriteBuilder6 == null;
					tileSpriteBuilder6._depth = -32766f;
					tileSpriteBuilder6._depthMul = 1f;
					tileSpriteBuilder6._alpha = 0.5f;
					tileSpriteBuilder6._parent = _spritesRootTransform;
					tileSpriteBuilder6._tileWidth = tileWidth;
					tileSpriteBuilder6._tileHeight = tileHeight;
					tileSpriteBuilder6._name = "CloudsRed";
					TileSprite cloudsRed = tileSpriteBuilder6.Build();
					_cloudsRed = cloudsRed;
					bool flag13 = (object)_cloudsRed == null;
					GameObject gameObject3 = _cloudsRed.gameObject;
					bool flag14 = (object)gameObject3 == null;
					gameObject3.SetActive(value: false);
					GameObject go7 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					TileSpriteBuilder tileSpriteBuilder7 = RenderingExtensions.AddTileSprite(go7, num7, 0f, "backgroundX", spriteName);
					bool flag15 = tileSpriteBuilder7 == null;
					tileSpriteBuilder7._depth = -32765f;
					tileSpriteBuilder7._depthMul = 1f;
					tileSpriteBuilder7._alpha = 0.5f;
					tileSpriteBuilder7._blendMode = BlendMode.Add;
					tileSpriteBuilder7._parent = _spritesRootTransform;
					tileSpriteBuilder7._tileWidth = tileWidth;
					tileSpriteBuilder7._tileHeight = tileHeight;
					tileSpriteBuilder7._name = "CloudsAddRed";
					TileSprite cloudsAddRed = tileSpriteBuilder7.Build();
					_cloudsAddRed = cloudsAddRed;
					bool flag16 = (object)_cloudsAddRed == null;
					GameObject gameObject4 = _cloudsAddRed.gameObject;
					bool flag17 = (object)gameObject4 == null;
					gameObject4.SetActive(value: false);
					Camera main2 = Camera.main;
					Bounds bounds = VampireSurvivors.Tools.CameraExtensions.OrthographicBoundsIgnoringBorders(main2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2879 @ rax_v116 (UnityEngine.Bounds)+10]");
					_ = 0;
					GameObject gameObject5 = base.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
					SpriteRenderer component = RenderingExtensions.AddSprite(gameObject5, num8, 0f, "backgroundX", spriteName);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
					float num9 = 0f * 2f;
					Vector2 vector = default(Vector2);
					float num10 = (float)vector * 2f;
					float num11 = num10 * 100f;
					float num12 = num9 * 100f;
					if (!(num12 > num11))
					{
						num12 = num11;
					}
					SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, num12);
					if ((object)spriteRenderer != null)
					{
						bool flag18 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 10000);
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
						if ((object)spriteRenderer2 != null)
						{
							Transform transform2 = spriteRenderer2.transform;
							if ((object)transform2 != null)
							{
								transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
								((UnityEngine.Object)spriteRenderer2).SetName("WhiteFader");
								_whiteFader = spriteRenderer2;
								GameObject gameObject6 = base.gameObject;
								SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject6, vector, vector, "vfx", spriteName);
								SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
								SpriteRenderer spriteRenderer5 = RenderingExtensions.SetTint(spriteRenderer4, 16776960u);
								if ((object)spriteRenderer5 != null)
								{
									((UnityEngine.Object)spriteRenderer5).SetName("ShootingRay");
									_shootingRay = spriteRenderer5;
									GameObject gameObject7 = base.gameObject;
									SpriteRenderer spriteRenderer6 = RenderingExtensions.AddSprite(gameObject7, 0f, 0f, "vfx", spriteName);
									SpriteRenderer spriteRenderer7 = RenderingExtensions.SetAlpha(spriteRenderer6, 0f);
									SpriteRenderer spriteRenderer8 = RenderingExtensions.SetTint(spriteRenderer7, 16776960u);
									if ((object)spriteRenderer8 != null)
									{
										((UnityEngine.Object)spriteRenderer8).SetName("ShootingRing");
										_shootingRing = spriteRenderer8;
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

	private void AddYellowParticles()
	{
		PickupRelic relicItemFromWorld = PickupManager.GetRelicItemFromWorld(ItemType.RELIC_YELLOW);
		if ((object)relicItemFromWorld != null && ((UnityEngine.Object)relicItemFromWorld).m_CachedPtr != (IntPtr)0)
		{
			OnYellowRelicFound(relicItemFromWorld);
		}
	}

	private unsafe void OnYellowRelicFound(PickupRelic found)
	{
		//IL_0008: Expected O, but got Ref
		//IL_019a: Expected O, but got I
		//IL_0241: Expected O, but got I
		//IL_02e8: Expected O, but got I
		//IL_038f: Expected O, but got I
		//IL_0436: Expected O, but got I
		//IL_0483: Expected O, but got Ref
		//IL_04bb: Expected native int or pointer, but got O
		//IL_04d5: Expected O, but got I
		//IL_0539: Expected O, but got I4
		//IL_0560: Expected O, but got I4
		//IL_0579: Expected O, but got Ref
		//IL_0593: Expected native int or pointer, but got O
		//IL_0dbb: Expected O, but got I
		//IL_05cb: Expected O, but got Ref
		//IL_05e5: Expected native int or pointer, but got O
		//IL_0df5: Expected O, but got I
		//IL_061d: Expected O, but got Ref
		//IL_0637: Expected native int or pointer, but got O
		//IL_0e2f: Expected O, but got I
		//IL_0688: Expected O, but got I
		//IL_0797: Expected O, but got I
		//IL_0842: Expected O, but got I
		//IL_08ed: Expected O, but got I
		//IL_0998: Expected O, but got I
		//IL_09e9: Expected O, but got Ref
		//IL_0a21: Expected native int or pointer, but got O
		//IL_0a3b: Expected O, but got I
		//IL_0a9f: Expected O, but got I4
		//IL_0ac6: Expected O, but got I4
		//IL_0adf: Expected O, but got Ref
		//IL_0af9: Expected native int or pointer, but got O
		//IL_0b14: Expected O, but got I
		//IL_0e69: Expected O, but got I
		//IL_0b34: Expected O, but got Ref
		//IL_0b4e: Expected native int or pointer, but got O
		//IL_0ea3: Expected O, but got I
		//IL_0b86: Expected O, but got Ref
		//IL_0ba0: Expected native int or pointer, but got O
		//IL_0edd: Expected O, but got I
		//IL_0bf7: Expected O, but got I
		//IL_0c1e: Expected O, but got I
		//IL_0c3f: Expected O, but got I
		//IL_0caa: Expected I4, but got I8
		//IL_06a2->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_06fb->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_073d->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_07e8->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_0893->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_093e->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_09c4->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_0c59->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_0c91->IL0cd9: Incompatible stack heights: 12 vs 0
		//IL_0cc8->IL0cd9: Incompatible stack heights: 12 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)found != null)
		{
			Transform transform = found.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "YellowPxfEmitter");
				bool flag2 = (object)gameObject == null;
				Transform transform2 = gameObject.transform;
				bool flag3 = (object)transform2 == null;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				Transform transform3 = gameObject.transform;
				Transform parent = base.transform;
				bool flag5 = (object)transform3 == null;
				transform3.SetParent(parent, worldPositionStays: true);
				ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
				_particleEmitterManager = particleEmitterManager;
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("backgroundX");
				List<string> list = new List<string>();
				bool flag6 = list == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
				bool flag7 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rcx_v35 (System.IntPtr)+18]");
				if (num >= 0)
				{
					((List<object>)(object)list).AddWithResize((object)"Window1.png");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list).m_CachedPtr;
				bool flag8 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ rcx_v37 (System.IntPtr)+18]");
				if (num2 >= 0)
				{
					((List<object>)(object)list).AddWithResize((object)"Window2.png");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
					object obj4 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr3 = ((UnityEngine.Object)(object)list).m_CachedPtr;
				bool flag9 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rcx_v39 (System.IntPtr)+18]");
				if (num3 >= 0)
				{
					((List<object>)(object)list).AddWithResize((object)"Window3.png");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
					object obj5 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr4 = ((UnityEngine.Object)(object)list).m_CachedPtr;
				bool flag10 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ rcx_v41 (System.IntPtr)+18]");
				if (num4 >= 0)
				{
					((List<object>)(object)list).AddWithResize((object)"Window4.png");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
					object obj6 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr5 = ((UnityEngine.Object)(object)list).m_CachedPtr;
				bool flag11 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rcx_v43 (System.IntPtr)+18]");
				if (num5 >= 0)
				{
					((List<object>)(object)list).AddWithResize((object)"Window6.png");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v38 (System.Collections.Generic.List`1<System.String>)+18]");
					object obj7 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				bool flag12 = particleSystemConfig == null;
				particleSystemConfig._frame = list;
				ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
				float max = (float)ret + 0.64f;
				float min = (float)ret - 0.64f;
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(min, max));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
				particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundX)+40]");
				float num6 = 0f * 2f;
				object obj8 = default(object);
				float num7 = (float)obj8 - num6;
				float constant = num7 - 0.32f;
				ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(constant);
				particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
				_ = 0;
				minMaxCurve2 = new ParticleSystem.MinMaxCurve(6000f);
				particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, -300f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
				particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.9f, 0.8f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
				particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 2f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
				particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
				_ = 0;
				_ = 0;
				_ = 1;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B8]");
				particleSystemConfig._quantity = (int?)(object)0;
				if ((object)_particleEmitterManager != null)
				{
					ParticleSystem particleSystem = _particleEmitterManager.CreateEmitter(particleSystemConfig, null, "YellowPfxEmitter1");
					ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("backgroundX");
					List<string> list2 = new List<string>();
					if (list2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+1C]");
						_ = (nint)0 + (nint)1;
						IntPtr cachedPtr6 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
						if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v66 (System.IntPtr)+18]");
							if (num8 >= 0)
							{
								((List<object>)(object)list2).AddWithResize((object)"Window1.png");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj9 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr7 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
							if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
								nint num9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v68 (System.IntPtr)+18]");
								if (num9 >= 0)
								{
									((List<object>)(object)list2).AddWithResize((object)"Window2.png");
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
									object obj10 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+1C]");
								_ = (nint)0 + (nint)1;
								IntPtr cachedPtr8 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
								if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v70 (System.IntPtr)+18]");
									if (num10 >= 0)
									{
										((List<object>)(object)list2).AddWithResize((object)"Window3.png");
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
										object obj11 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+1C]");
									_ = (nint)0 + (nint)1;
									IntPtr cachedPtr9 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
									if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v72 (System.IntPtr)+18]");
										if (num11 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"Window4.png");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ rax_v69 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj12 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										if (particleSystemConfig2 != null)
										{
											particleSystemConfig2._frame = list2;
											ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
											float max2 = (float)ret + 0.64f;
											float min2 = (float)ret - 0.64f;
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(min2, max2));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
											particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundX)+40]");
											float num12 = 0f * 2f;
											float num13 = (float)obj8 - num12;
											float constant2 = num13 - 0.32f;
											minMaxCurve2 = new ParticleSystem.MinMaxCurve(constant2);
											particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											minMaxCurve2 = new ParticleSystem.MinMaxCurve(7000f);
											particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(-100f, -300f));
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
											obj = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
											particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
											particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 2f));
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+160]");
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
											particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
											_ = 0;
											_ = 0;
											_ = 1;
											_ = 1;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B8]");
											particleSystemConfig2._quantity = (int?)(object)0;
											_ = 1128792064;
											_ = 1;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B8]");
											particleSystemConfig2._frequency = (float?)(object)0;
											_ = 1;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B8]");
											particleSystemConfig2._blendMode = (BlendMode?)(object)0;
											if ((object)_particleEmitterManager != null)
											{
												ParticleSystem particleSystem2 = _particleEmitterManager.CreateEmitter(particleSystemConfig2, null, "YellowPfxEmitter2");
												if ((object)_particleEmitterManager != null)
												{
													ParticleEmitterManager particleEmitterManager2 = _particleEmitterManager.SetDepth(-1000);
													if ((object)_particleEmitterManager != null)
													{
														_particleEmitterManager.StartAllEmitters();
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
		throw new NullReferenceException();
	}

	private unsafe void AddRedParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_019a: Expected O, but got I
		//IL_0207: Expected O, but got Ref
		//IL_0220: Expected native int or pointer, but got O
		//IL_023a: Expected O, but got I
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_028e: Expected O, but got I4
		//IL_02b5: Expected O, but got I4
		//IL_02ce: Expected O, but got Ref
		//IL_02e8: Expected native int or pointer, but got O
		//IL_099a: Expected O, but got I4
		//IL_030d: Expected O, but got Ref
		//IL_0327: Expected native int or pointer, but got O
		//IL_09d4: Expected O, but got I
		//IL_0a0e: Expected O, but got I
		//IL_03a3: Expected O, but got I
		//IL_03ca: Expected O, but got I
		//IL_03e5: Expected O, but got I
		//IL_057c: Expected O, but got I
		//IL_05e1: Expected O, but got Ref
		//IL_05fa: Expected native int or pointer, but got O
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Expected O, but got Unknown
		//IL_0698: Expected O, but got Ref
		//IL_06b2: Expected native int or pointer, but got O
		//IL_06da: Expected O, but got I
		//IL_06ed: Expected O, but got Ref
		//IL_0707: Expected native int or pointer, but got O
		//IL_040d->IL08c2: Incompatible stack heights: 7 vs 0
		//IL_0454->IL08c2: Incompatible stack heights: 7 vs 0
		//IL_0482->IL08c2: Incompatible stack heights: 7 vs 0
		//IL_04ae->IL08c2: Incompatible stack heights: 7 vs 0
		//IL_07cd->IL08c2: Incompatible stack heights: 13 vs 0
		//IL_0814->IL08c2: Incompatible stack heights: 13 vs 0
		//IL_0842->IL08c2: Incompatible stack heights: 13 vs 0
		//IL_086e->IL08c2: Incompatible stack heights: 13 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, "RedPxfEmitter");
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					Transform transform3 = gameObject.transform;
					bool flag4 = (object)transform3 == null;
					transform3.SetParent(transform, worldPositionStays: true);
					ParticleEmitterManager particleEmitterManagerRed = gameObject.AddComponent<ParticleEmitterManager>();
					_particleEmitterManagerRed = particleEmitterManagerRed;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("enemies");
					List<string> list = new List<string>();
					bool flag5 = list == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
					_ = (nint)0 + (nint)1;
					IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
					bool flag6 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rcx_v56 (System.IntPtr)+18]");
					if (num >= 0)
					{
						((List<object>)(object)list).AddWithResize((object)"XLReaper_0");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
						object obj3 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					bool flag7 = particleSystemConfig == null;
					particleSystemConfig._frame = list;
					object obj4 = default(object);
					float num2 = (float)obj4 * 2f;
					float max = num2 * 0.3f;
					ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
					particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
					_ = 0;
					Bounds camBounds = _camBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundX)+3C]");
					object obj5 = camBounds - 0;
					float constant = (float)obj5 - 0.32f;
					ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(constant);
					particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					minMaxCurve2 = new ParticleSystem.MinMaxCurve(6000f);
					particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 300f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
					_ = 0;
					particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.9f, 0.8f));
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
					particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
					_ = 0;
					minMaxCurve2 = new ParticleSystem.MinMaxCurve(-1f);
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
					particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
					particleSystemConfig._quantity = (int?)(object)0;
					_ = 1112014848;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
					particleSystemConfig._frequency = (float?)(object)0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
					particleSystemConfig._simulationSpace = (ParticleSystemSimulationSpace?)(object)0;
					particleSystemConfig._on = true;
					if ((object)_particleEmitterManagerRed != null)
					{
						ParticleSystem pfxEmitterRed = _particleEmitterManagerRed.CreateEmitter(particleSystemConfig, null, "PfxEmitterRed1");
						_pfxEmitterRed1 = pfxEmitterRed;
						if ((object)_pfxEmitterRed1 != null)
						{
							Transform transform4 = _pfxEmitterRed1.transform;
							if ((object)_pfxEmitterRed1 != null)
							{
								Transform transform5 = _pfxEmitterRed1.transform;
								if ((object)transform5 != null)
								{
									bool flag8 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
									Transform.get_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
									float num3 = (float)obj4 * 2f;
									float num4 = num3 * 0.3f;
									bool flag9 = (object)transform4 == null;
									bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("enemies");
									List<string> list2 = new List<string>();
									list2._002Ector();
									bool flag11 = list2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2498 @ rax_v106 (System.Collections.Generic.List`1<System.String>)+1C]");
									_ = (nint)0 + (nint)1;
									IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
									bool flag12 = ((UnityEngine.Object)(object)list2).m_CachedPtr == (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2498 @ rax_v106 (System.Collections.Generic.List`1<System.String>)+18]");
									nint num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1565 @ rcx_v88 (System.IntPtr)+18]");
									if (num5 >= 0)
									{
										((List<object>)(object)list2).AddWithResize((object)"XLReaper_0");
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2498 @ rax_v106 (System.Collections.Generic.List`1<System.String>)+18]");
										object obj6 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									bool flag13 = particleSystemConfig2 == null;
									float num6 = (float)obj4 * 2f;
									float max2 = num6 * 0.4f;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, max2));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
									_ = 0;
									Bounds camBounds2 = _camBounds;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundX)+3C]");
									object obj7 = camBounds2 - 0;
									float constant2 = (float)obj7 - 0.32f;
									minMaxCurve2 = new ParticleSystem.MinMaxCurve(constant2);
									((UnityEngine.Object)(object)particleSystemConfig2).m_CachedPtr = (IntPtr)0;
									_ = 0;
									minMaxCurve2 = new ParticleSystem.MinMaxCurve(7000f);
									_ = 0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(100f, 300f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
									obj = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
									_ = 0;
									minMaxCurve2 = new ParticleSystem.MinMaxCurve(-1f);
									_ = 0;
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
									_ = 0;
									_ = 1112014848;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
									_ = 0;
									_ = 1;
									if ((object)_particleEmitterManagerRed != null)
									{
										ParticleSystem pfxEmitterRed2 = _particleEmitterManagerRed.CreateEmitter(particleSystemConfig2, null, "PfxEmitterRed2");
										_pfxEmitterRed2 = pfxEmitterRed2;
										if ((object)_pfxEmitterRed2 != null)
										{
											Transform transform6 = _pfxEmitterRed2.transform;
											if ((object)_pfxEmitterRed2 != null)
											{
												Transform transform7 = _pfxEmitterRed2.transform;
												if ((object)transform7 != null)
												{
													bool flag14 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
													Transform.get_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out ret);
													bool flag15 = (object)transform6 == null;
													bool flag16 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
													Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value);
													bool flag17 = (object)_particleEmitterManagerRed == null;
													ParticleEmitterManager particleEmitterManager = _particleEmitterManagerRed.SetDepth(3000);
													bool flag18 = (object)_particleEmitterManagerRed == null;
													_particleEmitterManagerRed.StartAllEmitters();
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
		throw new NullReferenceException();
	}

	private unsafe void AddRedParticlesBelow()
	{
		//IL_0008: Expected O, but got Ref
		//IL_019a: Expected O, but got I
		//IL_0207: Expected O, but got Ref
		//IL_0220: Expected native int or pointer, but got O
		//IL_023a: Expected O, but got I
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_028e: Expected O, but got I4
		//IL_02b5: Expected O, but got I4
		//IL_02ce: Expected O, but got Ref
		//IL_02e8: Expected native int or pointer, but got O
		//IL_099e: Expected O, but got I4
		//IL_030d: Expected O, but got Ref
		//IL_0327: Expected native int or pointer, but got O
		//IL_09d8: Expected O, but got I
		//IL_0a12: Expected O, but got I
		//IL_03a3: Expected O, but got I
		//IL_03ca: Expected O, but got I
		//IL_03e5: Expected O, but got I
		//IL_057c: Expected O, but got I
		//IL_05e1: Expected O, but got Ref
		//IL_05fa: Expected native int or pointer, but got O
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Expected O, but got Unknown
		//IL_0698: Expected O, but got Ref
		//IL_06b2: Expected native int or pointer, but got O
		//IL_06da: Expected O, but got I
		//IL_06ed: Expected O, but got Ref
		//IL_0707: Expected native int or pointer, but got O
		//IL_089b: Expected I4, but got I8
		//IL_040d->IL08c6: Incompatible stack heights: 7 vs 0
		//IL_0454->IL08c6: Incompatible stack heights: 7 vs 0
		//IL_0482->IL08c6: Incompatible stack heights: 7 vs 0
		//IL_04ae->IL08c6: Incompatible stack heights: 7 vs 0
		//IL_07cd->IL08c6: Incompatible stack heights: 13 vs 0
		//IL_0814->IL08c6: Incompatible stack heights: 13 vs 0
		//IL_0842->IL08c6: Incompatible stack heights: 13 vs 0
		//IL_086e->IL08c6: Incompatible stack heights: 13 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, "RedPxfEmitterBelow");
			if ((object)gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					Transform transform3 = gameObject.transform;
					bool flag4 = (object)transform3 == null;
					transform3.SetParent(transform, worldPositionStays: true);
					ParticleEmitterManager particleEmitterManagerRedBelow = gameObject.AddComponent<ParticleEmitterManager>();
					_particleEmitterManagerRedBelow = particleEmitterManagerRedBelow;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("enemies");
					List<string> list = new List<string>();
					bool flag5 = list == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+1C]");
					_ = (nint)0 + (nint)1;
					IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
					bool flag6 = ((UnityEngine.Object)(object)list).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rcx_v56 (System.IntPtr)+18]");
					if (num >= 0)
					{
						((List<object>)(object)list).AddWithResize((object)"XLReaper_0");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v61 (System.Collections.Generic.List`1<System.String>)+18]");
						object obj3 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					bool flag7 = particleSystemConfig == null;
					particleSystemConfig._frame = list;
					object obj4 = default(object);
					float num2 = (float)obj4 * 2f;
					float max = num2 * 0.5f;
					ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
					particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
					_ = 0;
					Bounds camBounds = _camBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundX)+3C]");
					object obj5 = camBounds - 0;
					float constant = (float)obj5 - 0.32f;
					ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(constant);
					particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					minMaxCurve2 = new ParticleSystem.MinMaxCurve(6000f);
					particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 300f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
					_ = 0;
					particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.9f, 0.8f));
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
					particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
					_ = 0;
					minMaxCurve2 = new ParticleSystem.MinMaxCurve(-1f);
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
					particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
					particleSystemConfig._quantity = (int?)(object)0;
					_ = 1112014848;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
					particleSystemConfig._frequency = (float?)(object)0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
					particleSystemConfig._simulationSpace = (ParticleSystemSimulationSpace?)(object)0;
					particleSystemConfig._on = true;
					if ((object)_particleEmitterManagerRedBelow != null)
					{
						ParticleSystem pfxEmitterBelow = _particleEmitterManagerRedBelow.CreateEmitter(particleSystemConfig, null, "PfxEmitterBelow1");
						_pfxEmitterBelow1 = pfxEmitterBelow;
						if ((object)_pfxEmitterBelow1 != null)
						{
							Transform transform4 = _pfxEmitterBelow1.transform;
							if ((object)_pfxEmitterBelow1 != null)
							{
								Transform transform5 = _pfxEmitterBelow1.transform;
								if ((object)transform5 != null)
								{
									bool flag8 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
									Transform.get_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
									float num3 = (float)obj4 * 2f;
									float num4 = num3 * 0.25f;
									bool flag9 = (object)transform4 == null;
									bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("enemies");
									List<string> list2 = new List<string>();
									list2._002Ector();
									bool flag11 = list2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2498 @ rax_v106 (System.Collections.Generic.List`1<System.String>)+1C]");
									_ = (nint)0 + (nint)1;
									IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
									bool flag12 = ((UnityEngine.Object)(object)list2).m_CachedPtr == (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2498 @ rax_v106 (System.Collections.Generic.List`1<System.String>)+18]");
									nint num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1565 @ rcx_v88 (System.IntPtr)+18]");
									if (num5 >= 0)
									{
										((List<object>)(object)list2).AddWithResize((object)"XLReaper_0");
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2498 @ rax_v106 (System.Collections.Generic.List`1<System.String>)+18]");
										object obj6 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									bool flag13 = particleSystemConfig2 == null;
									float num6 = (float)obj4 * 2f;
									float max2 = num6 * 0.5f;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, max2));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
									_ = 0;
									Bounds camBounds2 = _camBounds;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundX)+3C]");
									object obj7 = camBounds2 - 0;
									float constant2 = (float)obj7 - 0.32f;
									minMaxCurve2 = new ParticleSystem.MinMaxCurve(constant2);
									((UnityEngine.Object)(object)particleSystemConfig2).m_CachedPtr = (IntPtr)0;
									_ = 0;
									minMaxCurve2 = new ParticleSystem.MinMaxCurve(7000f);
									_ = 0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(100f, 300f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
									obj = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
									_ = 0;
									minMaxCurve2 = new ParticleSystem.MinMaxCurve(-1f);
									_ = 0;
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
									_ = 0;
									_ = 1112014848;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
									_ = 0;
									_ = 1;
									if ((object)_particleEmitterManagerRedBelow != null)
									{
										ParticleSystem pfxEmitterBelow2 = _particleEmitterManagerRedBelow.CreateEmitter(particleSystemConfig2, null, "PfxEmitterBelow2");
										_pfxEmitterBelow2 = pfxEmitterBelow2;
										if ((object)_pfxEmitterBelow2 != null)
										{
											Transform transform6 = _pfxEmitterBelow2.transform;
											if ((object)_pfxEmitterBelow2 != null)
											{
												Transform transform7 = _pfxEmitterBelow2.transform;
												if ((object)transform7 != null)
												{
													bool flag14 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
													Transform.get_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out ret);
													bool flag15 = (object)transform6 == null;
													bool flag16 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
													Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value);
													bool flag17 = (object)_particleEmitterManagerRedBelow == null;
													ParticleEmitterManager particleEmitterManager = _particleEmitterManagerRedBelow.SetDepth(-3000);
													bool flag18 = (object)_particleEmitterManagerRedBelow == null;
													_particleEmitterManagerRedBelow.StartAllEmitters();
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
		throw new NullReferenceException();
	}

	private void AddRosary()
	{
		Pickup pickupItemFromWorld = PickupManager.GetPickupItemFromWorld(ItemType.ROSARY);
		if ((object)pickupItemFromWorld != null && ((UnityEngine.Object)pickupItemFromWorld).m_CachedPtr != (IntPtr)0)
		{
			_rosary = pickupItemFromWorld;
		}
	}

	private bool RemoveEggs()
	{
		//IL_010d: Expected I4, but got O
		//IL_00dc: Invalid comparison between I4 and F4
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				if (config._003CSelectedGoldenEggs_003Ek__BackingField)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core == null || core2._eggManager == null)
					{
						goto IL_00ff;
					}
					float num = core2._eggManager.RemoveBonuses();
					if (0f < num)
					{
						return true;
					}
				}
				return false;
			}
		}
		goto IL_00ff;
		IL_00ff:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void RemovePowers()
	{
		//IL_0336: Expected F4, but got I4
		//IL_0262: Invalid comparison between I4 and F4
		//IL_0274: Expected F4, but got I4
		//IL_0327: Expected F4, but got I4
		//IL_02ee: Expected F4, but got I4
		//IL_0f4d: Expected F4, but got I
		//IL_04fd: Expected F4, but got I4
		//IL_0505: Expected O, but got Ref
		//IL_0aa8: Expected O, but got I
		//IL_116b: Expected F4, but got O
		//IL_11ca: Expected O, but got Ref
		//IL_11f8: Expected I, but got O
		//IL_120e: Expected O, but got I
		//IL_1217: Unknown result type (might be due to invalid IL or missing references)
		//IL_121c: Expected O, but got Unknown
		//IL_0be1: Expected I, but got O
		//IL_1242: Expected O, but got I4
		//IL_1259: Expected I, but got I8
		//IL_0c70: Expected I, but got O
		//IL_0c86: Expected O, but got I
		//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c94: Expected O, but got Unknown
		//IL_0bca: Expected I, but got I8
		//IL_0cfd: Expected I, but got O
		//IL_127f: Expected O, but got I4
		//IL_1296: Expected I, but got I8
		//IL_0ce6: Expected I, but got I8
		//IL_0d9f->IL12b3: Incompatible stack heights: 9 vs 2
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Crown");
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
			((List<object>)(object)list).AddWithResize((object)"ArmorIron");
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
			((List<object>)(object)list).AddWithResize((object)"Tarots");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			float num = core2._eggManager.RemoveBonuses();
			bool flag = !(0f < num);
			float num2 = 0f;
			if (!flag)
			{
				int version4 = list._version + 1;
				list._version = version4;
				string[] items4 = list._items;
				if (list._size >= items4.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"goldenegg");
					num2 = 0f;
				}
				else
				{
					int size4 = list._size + 1;
					list._size = size4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					num2 = 0f;
				}
			}
		}
		else
		{
			float num2 = 0f;
		}
		if (GM.Core.HasAPlayerGotRevivals())
		{
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"Tiramisu");
			}
			else
			{
				int size5 = list._size + 1;
				list._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		if (config2._003CSelectedHurry_003Ek__BackingField)
		{
			int version6 = list._version + 1;
			list._version = version6;
			string[] items6 = list._items;
			if (list._size >= items6.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"Tear");
			}
			else
			{
				int size6 = list._size + 1;
				list._size = size6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		GameManager core4 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			float num3 = 0f;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		float num4 = (float)Math.PI * 2f / (float)list._size;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1296 @ stack_8 (UnityEngine.Component)+28]");
		float num5 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdi_v20 (System.Single)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdi_v20 (System.Single)+10]");
		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
		Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		int num6 = 0;
		List<string> list2 = list;
		int num7 = 0;
		Component component = default(Component);
		Vector2 vector = default(Vector2);
		string spriteName = default(string);
		Vector2 vector2 = default(Vector2);
		while (num7 < list._size)
		{
			_003C_003Ec__DisplayClass57_0 obj = new _003C_003Ec__DisplayClass57_0();
			bool flag4 = num6 >= list2._size;
			string[] items7 = list2._items;
			bool flag5 = num6 >= items7.Length;
			GameObject gameObject = component.gameObject;
			SpriteRenderer s = RenderingExtensions.AddSprite(gameObject, vector, vector, "items", spriteName);
			obj.s = s;
			object s2 = obj.s;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdi_v25 (System.Object)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdi_v25 (System.Object)+10]");
			Renderer.set_enabled_Injected((IntPtr)0, false);
			object s3 = obj.s;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdi_v26 (System.Object)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdi_v26 (System.Object)+10]");
			Renderer.set_sortingOrder_Injected((IntPtr)0, 2000);
			Transform transform2 = obj.s.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1296 @ stack_8 (UnityEngine.Component)+A8]");
			transform2.SetParent((Transform)0, worldPositionStays: true);
			object s4 = obj.s;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v28 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v28 (System.Object)+10]");
			IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rax_v102 (UnityEngine.Transform)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rax_v102 (UnityEngine.Transform)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out Vector3 _);
			float num8 = (float)num6 * num4;
			float num9 = num8 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num10 = (float)num6 * num4;
			float num11 = num10 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			obj.index = num6;
			float num12 = (float)obj.s;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v30 (System.Single)+10]");
			bool flag10 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdi_v30 (System.Single)+10]");
			IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMove(target, (Vector3)(&vector2), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3253 @ rax_v115 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num13 = (float)num6 * 100f;
			float num14 = num13 + 800f;
			float delay = num14 * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = null;
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3329 @ r10_v17 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass57_0._003CRemovePowers_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3329 @ r10_v17 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num16;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3329 @ r10_v17 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num16 = unchecked((nint)6447293664L);
					goto IL_1239;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num16 = ((Delegate)tweenCallback).method_ptr;
			goto IL_1239;
			IL_1276:
			object obj4 = 24;
			TweenCallback tweenCallback2;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3321 @ rax_v117 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			num6++;
			list2 = list;
			num7 = num6;
			continue;
			IL_1239:
			object obj5 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3321 @ rax_v117 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			tweenCallback2 = null;
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r10_v18 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass57_0._003CRemovePowers_003Eb__1);
			((Delegate)tweenCallback2).m_target = obj;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r10_v18 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num18;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r10_v18 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num18 = unchecked((nint)6447293664L);
					goto IL_1276;
				}
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num18 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_1276;
		}
	}

	private void SetupCharacterAnimation(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_013f: Expected O, but got I4
		//IL_013f: Expected I4, but got O
		//IL_0101: Expected I4, but got O
		GameManager core = GM.Core;
		SkinType skinTypeForCharacter = core._playerOptions.GetSkinTypeForCharacter(character._characterType);
		Skin skinForCharacter = core._playerOptions.GetSkinForCharacter(character._characterType, skinTypeForCharacter);
		if (skinForCharacter._003CwalkingFrames_003Ek__BackingField > 0)
		{
			string text = skinForCharacter._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			string animName = "mad" + text;
			Vector2 pivot = default(Vector2);
			string text2 = default(string);
			int num = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, skinForCharacter._003CwalkingFrames_003Ek__BackingField, pivot, text2, num, flag);
			int fps = (((object)skinForCharacter._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)skinForCharacter._003CwalkFrameRate_003Ek__BackingField >> 32));
			bool autoSetAnimation = default(bool);
			character._spriteAnimation.AddAnimation("uwalk", animationFrames, fps, (byte)(int)text2 != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		}
	}

	private void UpdatePlayerOptions()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.STAGEX;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.NONE;
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GameManager core4 = GM.Core;
		PlayerOptionsData config4 = core4._playerOptions.Config;
		config4._003CSelectedHurry_003Ek__BackingField = false;
		GameManager core5 = GM.Core;
		PlayerOptionsData config5 = core5._playerOptions.Config;
		config5._003CSelectedMazzo_003Ek__BackingField = false;
		GameManager core6 = GM.Core;
		PlayerOptionsData config6 = core6._playerOptions.Config;
		config6._003CSelectedHyper_003Ek__BackingField = false;
		GameManager core7 = GM.Core;
		PlayerOptionsData config7 = core7._playerOptions.Config;
		config7._003CSelectedInverse_003Ek__BackingField = false;
		GameManager core8 = GM.Core;
		PlayerOptionsData config8 = core8._playerOptions.Config;
		config8._003CSelectedReapers_003Ek__BackingField = false;
		GameManager core9 = GM.Core;
		PlayerOptionsData config9 = core9._playerOptions.Config;
		config9._003CSelectedRandomEvents_003Ek__BackingField = false;
	}

	private unsafe void SetupTimers()
	{
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_whiteFader, 1f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 15.300001f);
		TweenCallback tweenCallback = delegate
		{
			//IL_00d8: Expected O, but got I4
			//IL_00e0: Expected O, but got Ref
			//IL_0168: Expected O, but got I4
			//IL_0374->IL026f: Incompatible stack heights: 1 vs 0
			//IL_03c7->IL026f: Incompatible stack heights: 2 vs 0
			//IL_0406->IL026f: Incompatible stack heights: 2 vs 0
			Debug.Log("Starting 1st section");
			ToggleBlue(visible: false);
			ToggleRed(visible: true);
			ToggleAlias();
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				core._canRunTickerTimer = false;
				UIView.ExecuteHide("Game", "Main Game", false);
				base._003CAlias_003Ek__BackingField = true;
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._characters != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core2._characters;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					if (enumerator.MoveNext())
					{
						object obj = 0;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null)
					{
						string gameSessionData = (string)(object)core3._gameSessionData;
						if (core3._gameSessionData != null)
						{
							object obj2 = gameSessionData._stringLength;
							if (gameSessionData._stringLength != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v10 (System.Object)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v10 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform != null)
								{
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
									if ((object)core3._stage != null)
									{
										Vector2 spawnPos = default(Vector2);
										bool forceSpawn = default(bool);
										GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.BOSS_XLMADDENER, spawnPos, asRemote: false, forceSpawn);
										if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
										{
											EnemyMaddener component = gameObject.GetComponent<EnemyMaddener>();
											_enemyMaddener = component;
										}
										TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleSprite.DOFade(_whiteFader, 0f, 1f);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if (tweenerCore4 != null)
										{
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
		};
		tweenCallback._002Ector(this, (nint)__ldftn(BackgroundX._003CSetupTimers_003Eb__60_0));
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((BackgroundX)(object)dOSetter)._003CSetupTimers_003Eb__60_2(15.300001f);
		TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter, dOSetter, 16f, 0.5f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 27.000002f);
		TweenCallback tweenCallback2 = delegate
		{
			Debug.Log("Starting 2nd section");
			_enemyMaddener.Spinnn();
			Transform target = _cloudsWhite.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScaleX(target, 4f, 3.0000002f);
			if (tweenerCore4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 6;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
							float num = 0f * 6f;
						}
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			DOGetter<float> getter3 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter3 = null;
			((BackgroundX)(object)dOSetter3)._003CSetupTimers_003Eb__60_15(4f);
			TweenerCore<float, float, FloatOptions> tweenerCore5 = DOTween.To(getter3, dOSetter3, 0f, 0.38000003f);
			TweenCallback tweenCallback5;
			if (tweenerCore5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
							float num2 = 0f * 7f;
						}
						TweenCallback tweenCallback4 = delegate
						{
							//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
							ShootVfx();
							GameManager core = GM.Core;
							if ((object)GM.Core != null && (object)_enemyMaddener != null)
							{
								Transform transform = _enemyMaddener.transform;
								if ((object)transform != null)
								{
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
									if ((object)core._stage != null)
									{
										Vector2 spawnPos = default(Vector2);
										bool forceSpawn = default(bool);
										GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
										return;
									}
								}
							}
							throw new NullReferenceException();
						};
						tweenCallback5 = tweenCallback4;
						goto IL_029c;
					}
				}
			}
			TweenCallback tweenCallback6 = delegate
			{
				//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
				ShootVfx();
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_enemyMaddener != null)
				{
					Transform transform = _enemyMaddener.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)core._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
							return;
						}
					}
				}
				throw new NullReferenceException();
			};
			bool flag = tweenerCore5 == null;
			tweenCallback5 = tweenCallback6;
			if (!flag)
			{
				goto IL_029c;
			}
			goto IL_02cb;
			IL_02cb:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Action onComplete8 = delegate
			{
				DOGetter<float> getter4 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter4 = null;
				float x = default(float);
				((BackgroundX)(object)dOSetter4)._003CSetupTimers_003Eb__60_19(x);
				TweenerCore<float, float, FloatOptions> tweenerCore6 = DOTween.To(getter4, dOSetter4, 0f, 0.38000003f);
				TweenCallback tweenCallback8;
				if (tweenerCore6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
								float num3 = 0f * 7f;
							}
							TweenCallback tweenCallback7 = delegate
							{
								//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
								ShootVfx();
								GameManager core = GM.Core;
								if ((object)GM.Core != null && (object)_enemyMaddener != null)
								{
									Transform transform = _enemyMaddener.transform;
									if ((object)transform != null)
									{
										bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
										if ((object)core._stage != null)
										{
											Vector2 spawnPos = default(Vector2);
											bool forceSpawn = default(bool);
											GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
											return;
										}
									}
								}
								throw new NullReferenceException();
							};
							tweenCallback8 = tweenCallback7;
							goto IL_0127;
						}
					}
				}
				TweenCallback tweenCallback9 = delegate
				{
					//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
					ShootVfx();
					GameManager core = GM.Core;
					if ((object)GM.Core != null && (object)_enemyMaddener != null)
					{
						Transform transform = _enemyMaddener.transform;
						if ((object)transform != null)
						{
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							if ((object)core._stage != null)
							{
								Vector2 spawnPos = default(Vector2);
								bool forceSpawn = default(bool);
								GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
								return;
							}
						}
					}
					throw new NullReferenceException();
				};
				bool flag2 = tweenerCore6 == null;
				tweenCallback8 = tweenCallback9;
				if (!flag2)
				{
					goto IL_0127;
				}
				goto IL_0156;
				IL_0127:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
				goto IL_0156;
				IL_0156:
				_tweenExplosions = tweenerCore6;
				Tween tweenExplosions = _tweenExplosions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				tweenExplosions.stringId = "DefaultGameTweenId";
				if (++_tweenExplosionsTimerRepeatCount >= 6)
				{
					_tweenExplosionsTimer.Cancel();
				}
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer tweenExplosionsTimer = Timers.Register(3.0400002f, onComplete8, null, isLooped: true, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_tweenExplosionsTimer = tweenExplosionsTimer;
			return;
			IL_029c:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
			goto IL_02cb;
		};
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((BackgroundX)(object)dOSetter2)._003CSetupTimers_003Eb__60_5(27.000002f);
		TweenerCore<float, float, FloatOptions> t3 = DOTween.To(getter2, dOSetter2, 17f, 0.5f);
		TweenerCore<float, float, FloatOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t3, 51.500004f);
		TweenCallback tweenCallback3 = delegate
		{
			Debug.Log("Starting 3rd section");
			_enemyMaddener.StartLowerScreenMotion();
			DOGetter<float> getter3 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter3 = null;
			float x = default(float);
			((BackgroundX)(object)dOSetter3)._003CSetupTimers_003Eb__60_22(x);
			TweenerCore<float, float, FloatOptions> t4 = DOTween.To(getter3, dOSetter3, 0f, 0.4f);
			TweenerCore<float, float, FloatOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(t4, 1f);
			TweenCallback tweenCallback5;
			if (tweenerCore4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 40;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
							float num = 0f * 40f;
						}
						TweenCallback tweenCallback4 = delegate
						{
							//IL_01af->IL012e: Incompatible stack heights: 1 vs 0
							//IL_00d9->IL012e: Incompatible stack heights: 1 vs 0
							//IL_0108->IL012e: Incompatible stack heights: 1 vs 0
							ShootVfx();
							GameManager core = GM.Core;
							if ((object)GM.Core != null && (object)_enemyMaddener != null)
							{
								Transform transform = _enemyMaddener.transform;
								if ((object)transform != null)
								{
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
									if ((object)core._stage != null)
									{
										Vector2 spawnPos = default(Vector2);
										bool forceSpawn = default(bool);
										GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_SHADE, spawnPos, asRemote: false, forceSpawn);
										if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
										{
											return;
										}
										EnemyController component = gameObject.GetComponent<EnemyController>();
										if ((object)component != null)
										{
											EnemyData currentEnemyData = component._currentEnemyData;
											if (component._currentEnemyData != null)
											{
												currentEnemyData._003Cxp_003Ek__BackingField = 0f;
												component._003CSelfDestDistance_003Ek__BackingField = 1200000f;
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						tweenCallback5 = tweenCallback4;
						goto IL_0176;
					}
				}
			}
			TweenCallback tweenCallback6 = delegate
			{
				//IL_01af->IL012e: Incompatible stack heights: 1 vs 0
				//IL_00d9->IL012e: Incompatible stack heights: 1 vs 0
				//IL_0108->IL012e: Incompatible stack heights: 1 vs 0
				ShootVfx();
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_enemyMaddener != null)
				{
					Transform transform = _enemyMaddener.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)core._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_SHADE, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							EnemyController component = gameObject.GetComponent<EnemyController>();
							if ((object)component != null)
							{
								EnemyData currentEnemyData = component._currentEnemyData;
								if (component._currentEnemyData != null)
								{
									currentEnemyData._003Cxp_003Ek__BackingField = 0f;
									component._003CSelfDestDistance_003Ek__BackingField = 1200000f;
									return;
								}
							}
						}
					}
				}
				throw new NullReferenceException();
			};
			bool flag = tweenerCore4 == null;
			tweenCallback5 = tweenCallback6;
			if (!flag)
			{
				goto IL_0176;
			}
			goto IL_01a5;
			IL_0176:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
			goto IL_01a5;
			IL_01a5:
			_tweenExplosions = tweenerCore4;
			Tween tweenExplosions = _tweenExplosions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tweenExplosions.stringId = "DefaultGameTweenId";
		};
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action onComplete = delegate
		{
			Debug.Log("Starting 4th section");
			bool flag = false;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			do
			{
				Action onComplete8 = _003C_003Ec._003C_003E9__60_24;
				if (_003C_003Ec._003C_003E9__60_24 == null)
				{
					onComplete8 = (_003C_003Ec._003C_003E9__60_24 = delegate
					{
						//IL_00a9: Expected O, but got I4
						//IL_0184: Expected I4, but got I8
						//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)core._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE1S, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							EnemySpin component = gameObject.GetComponent<EnemySpin>();
							if ((object)component != null)
							{
								SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
								component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
								if ((object)((EnemyController)component)._EnemyRenderer != null)
								{
									bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
									Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
									return;
								}
							}
						}
						throw new NullReferenceException();
					});
				}
				float num = (float)(flag ? 1 : 0) * 100f;
				float duration = num * 0.001f;
				Timer timer8 = Timers.Register(duration, onComplete8, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((flag ? 1 : 0) < 60);
			bool flag2 = false;
			do
			{
				Action onComplete9 = _003C_003Ec._003C_003E9__60_25;
				if (_003C_003Ec._003C_003E9__60_25 == null)
				{
					onComplete9 = (_003C_003Ec._003C_003E9__60_25 = delegate
					{
						//IL_00a9: Expected O, but got I4
						//IL_0184: Expected I4, but got I8
						//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)core._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE2S, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							EnemySpin component = gameObject.GetComponent<EnemySpin>();
							if ((object)component != null)
							{
								SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
								component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
								if ((object)((EnemyController)component)._EnemyRenderer != null)
								{
									bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
									Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
									return;
								}
							}
						}
						throw new NullReferenceException();
					});
				}
				float num2 = (float)(flag2 ? 1 : 0) * 150f;
				float duration2 = num2 * 0.001f;
				Timer timer9 = Timers.Register(duration2, onComplete9, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			}
			while ((flag2 ? 1 : 0) < 40);
			bool flag3 = false;
			do
			{
				Action onComplete10 = _003C_003Ec._003C_003E9__60_26;
				if (_003C_003Ec._003C_003E9__60_26 == null)
				{
					onComplete10 = (_003C_003Ec._003C_003E9__60_26 = delegate
					{
						//IL_00a9: Expected O, but got I4
						//IL_0184: Expected I4, but got I8
						//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)core._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE3S, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							EnemySpin component = gameObject.GetComponent<EnemySpin>();
							if ((object)component != null)
							{
								SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
								component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
								if ((object)((EnemyController)component)._EnemyRenderer != null)
								{
									bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
									Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
									return;
								}
							}
						}
						throw new NullReferenceException();
					});
				}
				float num3 = (float)(flag3 ? 1 : 0) * 200f;
				float duration3 = num3 * 0.001f;
				Timer timer10 = Timers.Register(duration3, onComplete10, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
				flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
			}
			while ((flag3 ? 1 : 0) < 20);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(64f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		Action onComplete2 = delegate
		{
			AddRedParticlesBelow();
			EnemyMaddener enemyMaddener = _enemyMaddener;
			if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
			{
				_enemyMaddener.StartPursuit();
			}
			Action onComplete8 = AddRedParticles;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timer8 = Timers.Register(5f, onComplete8, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		};
		Timer timer2 = Timers.Register(72f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		Action onComplete3 = delegate
		{
			if (!_hasRosaryBeenTriggered)
			{
				ShootEyes(6, 800f, 0.2f);
			}
		};
		Timer timer3 = Timers.Register(72f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		Action onComplete4 = delegate
		{
			if (!_hasRosaryBeenTriggered)
			{
				ShootEyes(4800, 400f, 0.2f);
			}
		};
		Timer timer4 = Timers.Register(77f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		Action onComplete5 = delegate
		{
			if (!_hasRosaryBeenTriggered)
			{
				ShootEyes(25, 200f, 0.1f);
			}
		};
		Timer timer5 = Timers.Register(81.8f, onComplete5, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		Action onComplete6 = delegate
		{
			if (!_hasRosaryBeenTriggered)
			{
				ShootEyes(50, 100f, 0f);
			}
		};
		Timer timer6 = Timers.Register(86.8f, onComplete6, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
		Action onComplete7 = delegate
		{
			if (!_hasRosaryBeenTriggered)
			{
				EnemyMaddener enemyMaddener = _enemyMaddener;
				if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
				{
					_enemyMaddener.StartKill();
				}
			}
		};
		Timer timer7 = Timers.Register(95.00001f, onComplete7, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
	}

	private void ToggleBlue(bool visible)
	{
		GameObject gameObject = _skyBlue.gameObject;
		gameObject.SetActive(visible);
		GameObject gameObject2 = _cloudsBlue.gameObject;
		gameObject2.SetActive(visible);
		GameObject gameObject3 = _cloudsAddBlue.gameObject;
		gameObject3.SetActive(visible);
	}

	private void ToggleRed(bool visible)
	{
		GameObject gameObject = _skyRed.gameObject;
		gameObject.SetActive(visible);
		GameObject gameObject2 = _cloudsRed.gameObject;
		gameObject2.SetActive(visible);
		GameObject gameObject3 = _cloudsAddRed.gameObject;
		gameObject3.SetActive(visible);
	}

	private void ToggleAlias()
	{
		//IL_001f: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_012d: Expected I, but got O
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
			object obj2 = 0;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdi_v4+10]");
				if ((nint)0 != 0)
				{
					nint num = (nint)typeof(UnityEngine.Object);
					throw new NullReferenceException();
				}
			}
		}
	}

	private void RemoveTimer()
	{
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		UIView.ExecuteHide("Game", "Main Game", false);
	}

	private void ShootVfx()
	{
		//IL_00a3: Expected O, but got I
		//IL_023b: Expected O, but got I
		//IL_03c1: Expected O, but got I
		//IL_0559: Expected O, but got I
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_shootingRay, 1f, 0.1f);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						object obj = num + 0;
					}
					TweenCallback tweenCallback = delegate
					{
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRay, 0f);
					};
					tweenCallback2 = tweenCallback;
					goto IL_00e8;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRay, 0f);
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_00e8;
		}
		goto IL_0117;
		IL_0406:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0435;
		IL_02af:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_shootingRing, 1f, 0.1f);
		TweenCallback tweenCallback5;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						object obj2 = num2 + 0;
					}
					TweenCallback tweenCallback4 = delegate
					{
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRing, 0f);
					};
					tweenCallback5 = tweenCallback4;
					goto IL_0406;
				}
			}
		}
		TweenCallback tweenCallback6 = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRing, 0f);
		};
		bool flag2 = tweenerCore2 == null;
		tweenCallback5 = tweenCallback6;
		if (!flag2)
		{
			goto IL_0406;
		}
		goto IL_0435;
		IL_05cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return;
		IL_0435:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target = _shootingRing.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target, 2f, 0.1f);
		TweenCallback tweenCallback8;
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj3 = num3 + 0;
					}
					TweenCallback tweenCallback7 = delegate
					{
						Transform transform = _shootingRing.transform;
						bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					};
					tweenCallback8 = tweenCallback7;
					goto IL_059e;
				}
			}
		}
		TweenCallback tweenCallback9 = delegate
		{
			Transform transform = _shootingRing.transform;
			bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		};
		bool flag3 = tweenerCore3 == null;
		tweenCallback8 = tweenCallback9;
		if (!flag3)
		{
			goto IL_059e;
		}
		goto IL_05cd;
		IL_059e:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_05cd;
		IL_0280:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_02af;
		IL_00e8:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0117;
		IL_0117:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target2 = _shootingRay.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target2, 1f, 0.1f);
		TweenCallback tweenCallback11;
		if (tweenerCore4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj4 = num4 + 0;
					}
					TweenCallback tweenCallback10 = delegate
					{
						Transform transform = _shootingRay.transform;
						bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					};
					tweenCallback11 = tweenCallback10;
					goto IL_0280;
				}
			}
		}
		TweenCallback tweenCallback12 = delegate
		{
			Transform transform = _shootingRay.transform;
			bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		};
		bool flag4 = tweenerCore4 == null;
		tweenCallback11 = tweenCallback12;
		if (!flag4)
		{
			goto IL_0280;
		}
		goto IL_02af;
	}

	private void ShootEyes(int times, float delay, float radiusMul)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		_003C_003Ec__DisplayClass66_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass66_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.radiusMul = radiusMul;
		PermanentVfx();
		if (times <= 0)
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
			Action onComplete = CS_0024_003C_003E8__locals8._003C_003E9__0;
			if (CS_0024_003C_003E8__locals8._003C_003E9__0 == null)
			{
				Action action = delegate
				{
					BackgroundX backgroundX2 = CS_0024_003C_003E8__locals8._003C_003E4__this;
					if (!backgroundX2._hasRosaryBeenTriggered && backgroundX2._shootingEyesManager != null)
					{
						backgroundX2._shootingEyesManager.ShootOne(CS_0024_003C_003E8__locals8.radiusMul);
					}
				};
				BackgroundX backgroundX = (BackgroundX)(CS_0024_003C_003E8__locals8 + 32);
				CS_0024_003C_003E8__locals8._003C_003E9__0 = action;
				onComplete = action;
			}
			float num = (float)(flag ? 1 : 0) * delay;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < times);
	}

	private void PermanentVfx()
	{
		//IL_01b9: Expected I4, but got I8
		//IL_02d3: Expected I4, but got I8
		//IL_0051->IL0330: Incompatible stack heights: 1 vs 0
		if ((object)_shootingRay != null)
		{
			Transform transform = _shootingRay.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRay, 0.7f);
				if ((object)_shootingRing != null)
				{
					Transform transform2 = _shootingRing.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_shootingRing, 0.7f);
					Sequence permanentVfxTween = DOTween.Sequence();
					_permanentVfxTween = permanentVfxTween;
					Sequence permanentVfxTween2 = _permanentVfxTween;
					TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_shootingRay, 0.5f, 0.4f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_permanentVfxTween, (Tween)t, false))
					{
						Sequence sequence = Sequence.DoInsert(_permanentVfxTween, (Tween)t, 0f);
					}
					if (_permanentVfxTween != null && ((Tween)permanentVfxTween2)._003Cactive_003Ek__BackingField)
					{
						((Tween)permanentVfxTween2).easeType = Ease.InOutSine;
						((Tween)permanentVfxTween2).customEase = null;
						if (((Tween)permanentVfxTween2)._003Cactive_003Ek__BackingField && !((Tween)permanentVfxTween2).creationLocked)
						{
							((Tween)permanentVfxTween2).loops = -1;
							((Tween)permanentVfxTween2).loopType = LoopType.Restart;
							if (((ABSSequentiable)permanentVfxTween2).tweenType == TweenType.Tweener)
							{
								((Tween)permanentVfxTween2).fullDuration = 1f / 0f;
							}
						}
					}
					Sequence permanentVfxTween3 = _permanentVfxTween;
					TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_shootingRing, 0.5f, 0.4f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_permanentVfxTween, (Tween)t2, false))
					{
						Sequence sequence2 = Sequence.DoInsert(_permanentVfxTween, (Tween)t2, 0f);
					}
					if (_permanentVfxTween != null && ((Tween)permanentVfxTween3)._003Cactive_003Ek__BackingField)
					{
						((Tween)permanentVfxTween3).easeType = Ease.InOutSine;
						((Tween)permanentVfxTween3).customEase = null;
						if (((Tween)permanentVfxTween3)._003Cactive_003Ek__BackingField && !((Tween)permanentVfxTween3).creationLocked)
						{
							((Tween)permanentVfxTween3).loops = -1;
							((Tween)permanentVfxTween3).loopType = LoopType.Restart;
							if (((ABSSequentiable)permanentVfxTween3).tweenType == TweenType.Tweener)
							{
								((Tween)permanentVfxTween3).fullDuration = 1f / 0f;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					bool flag4 = _permanentVfxTween == null;
					return;
				}
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private void CheckDistanceFromRosary()
	{
		//IL_0247->IL019a: Incompatible stack heights: 1 vs 0
		//IL_00d7->IL019a: Incompatible stack heights: 1 vs 0
		//IL_00f9->IL019a: Incompatible stack heights: 1 vs 0
		//IL_0128->IL019a: Incompatible stack heights: 1 vs 0
		//IL_0302->IL01d4: Incompatible stack heights: 2 vs 0
		//IL_019a->IL01d4: Incompatible stack heights: 2 vs 0
		Transform rosary = (Transform)(object)_rosary;
		if ((object)_rosary == null || ((UnityEngine.Object)rosary).m_CachedPtr == (IntPtr)0 || _hasRosaryBeenTriggered)
		{
			return;
		}
		if ((object)_rosary != null)
		{
			Transform transform = _rosary.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float num = (float)ret * 100f;
				object obj = default(object);
				float num2 = (float)obj * 100f;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core._gameSessionData;
					if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						Transform transform2 = gameSessionData._activeCharacter.transform;
						if ((object)transform2 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
							float num3 = (float)ret * 100f;
							float num4 = (float)obj * 100f;
							float num5 = num2 - num4;
							float num6 = num - num3;
							float num7 = num5 * num5;
							float num8 = num6 * num6;
							float num9 = num8 + num7;
							if (!(60000f > num9))
							{
								return;
							}
							_rosary = null;
							Action onComplete = delegate
							{
								if (!_hasRosaryBeenTriggered)
								{
									GameManager core2 = GM.Core;
									Vector2 bossyPosition = core2._stage.GetBossyPosition();
									GameManager core3 = GM.Core;
									bool forceSpawn = default(bool);
									GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.MOON_TRINACRIA_X, bossyPosition, asRemote: false, forceSpawn);
								}
								if (++_checkRosaryTimerRepeatCount >= 50)
								{
									_checkRosaryTimer.Cancel();
								}
							};
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer checkRosaryTimer = Timers.Register(0.1f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_checkRosaryTimer = checkRosaryTimer;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StopAllTimers()
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0212: Expected O, but got I
		//IL_0254: Expected O, but got I
		//IL_0449->IL0324: Incompatible stack heights: 1 vs 0
		//IL_04a9->IL0324: Incompatible stack heights: 2 vs 0
		if (_tweenExplosions != null)
		{
			DG.Tweening.TweenExtensions.Kill(_tweenExplosions);
		}
		List<Timer> timers = _timers;
		bool flag = _timers == null;
		object obj = null;
		object obj2 = null;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj2 < timers._size)
				{
					List<Timer> timers2 = _timers;
					if (_timers == null)
					{
						break;
					}
					if ((nint)obj < timers2._size)
					{
						Timer[] items = timers2._items;
						if (timers2._items == null)
						{
							break;
						}
						if ((nint)obj < items.Length)
						{
							if (items[obj] != null)
							{
								items[obj].Cancel();
							}
							timers = _timers;
							obj++;
							if (_timers == null)
							{
								break;
							}
							obj2 = obj;
							continue;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				EnemyMaddener enemyMaddener = _enemyMaddener;
				if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
				{
					object enemyMaddener2 = _enemyMaddener;
					if ((object)_enemyMaddener == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v17 (System.Object)+290]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v17 (System.Object)+290]");
						DG.Tweening.TweenExtensions.Kill((Tween)0);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v17 (System.Object)+298]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v17 (System.Object)+298]");
						DG.Tweening.TweenExtensions.Kill((Tween)0);
					}
				}
				if (_permanentVfxTween != null)
				{
					DG.Tweening.TweenExtensions.Kill(_permanentVfxTween);
				}
				object shootingRay = _shootingRay;
				if ((object)_shootingRay == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v12 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_shootingRay);
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v12 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v34 (UnityEngine.GameObject)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v34 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, false);
				object shootingRing = _shootingRing;
				if ((object)_shootingRing == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v14 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v14 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				if ((object)gameObject2 == null)
				{
					break;
				}
				bool flag4 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
				if (_shootingEyesManager != null)
				{
					_shootingEyesManager.Stop();
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void StopRedEmitters()
	{
		ParticleSystem pfxEmitterRed = _pfxEmitterRed1;
		if ((object)_pfxEmitterRed1 != null && ((UnityEngine.Object)pfxEmitterRed).m_CachedPtr != (IntPtr)0)
		{
			_pfxEmitterRed1.Stop();
		}
		ParticleSystem pfxEmitterRed2 = _pfxEmitterRed2;
		if ((object)_pfxEmitterRed2 != null && ((UnityEngine.Object)pfxEmitterRed2).m_CachedPtr != (IntPtr)0)
		{
			_pfxEmitterRed2.Stop();
		}
		ParticleSystem pfxEmitterBelow = _pfxEmitterBelow1;
		if ((object)_pfxEmitterBelow1 != null && ((UnityEngine.Object)pfxEmitterBelow).m_CachedPtr != (IntPtr)0)
		{
			_pfxEmitterBelow1.Stop();
		}
		ParticleSystem pfxEmitterBelow2 = _pfxEmitterBelow2;
		if ((object)_pfxEmitterBelow2 != null && ((UnityEngine.Object)pfxEmitterBelow2).m_CachedPtr != (IntPtr)0)
		{
			_pfxEmitterBelow2.Stop();
		}
		MoveStoppedParticles(_pfxEmitterRed1);
		MoveStoppedParticles(_pfxEmitterRed2);
		MoveStoppedParticles(_pfxEmitterBelow1);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 484 Invalid \"Jump target not found in method: 0x186FB1DB0\"");
		throw new NullReferenceException();
	}

	private void MoveStoppedParticles(ParticleSystem ps)
	{
		//IL_0070: Expected I4, but got I8
		//IL_009d: Expected O, but got I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		if ((object)ps == null || ((UnityEngine.Object)ps).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		int particleCount = ps.particleCount;
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
		int particles2 = ps.GetParticles(particles, -1, 0);
		if (particles2 > 0)
		{
			object obj = 0;
			bool flag;
			do
			{
				object obj2 = obj * 132;
				object obj3 = obj + 1;
				object obj4 = obj * 132;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+30+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+40+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+50+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+60+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+70+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+80+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+90+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v15+A0+v305 @ rax_v9 (Particle[])]");
				_ = 0;
				flag = (nint)obj3 < particles2;
				obj = obj3;
			}
			while (flag);
		}
		ps.SetParticles(particles, particles2, 0);
	}

	public BackgroundX()
	{
		List<Timer> timers = new List<Timer>();
		_timers = timers;
		base._002Ector();
	}

	static BackgroundX()
	{
		int intensity = Shader.PropertyToID("_Intensity");
		Intensity = intensity;
		int radius = Shader.PropertyToID("_Radius");
		Radius = radius;
		int mode = Shader.PropertyToID("_Mode");
		Mode = mode;
		int texSize = Shader.PropertyToID("_TexSize");
		TexSize = texSize;
		int center = Shader.PropertyToID("_Center");
		Center = center;
	}

	private unsafe void _003CRosaryTriggered_003Eb__46_0()
	{
		//IL_0844: Expected I, but got O
		//IL_002b: Expected I, but got O
		//IL_005f: Expected I, but got O
		//IL_0086: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_0104: Expected I, but got O
		//IL_014c: Expected I, but got O
		//IL_016d: Expected O, but got I4
		//IL_0172: Expected I, but got O
		//IL_0197: Expected I, but got O
		//IL_04a2: Expected O, but got I4
		//IL_0500: Expected F4, but got I4
		//IL_0459: Expected I, but got O
		//IL_0549: Expected F4, but got I4
		//IL_0598: Expected F4, but got I4
		//IL_02dd: Expected I4, but got O
		//IL_02ed: Expected O, but got I
		//IL_030a: Expected O, but got I
		//IL_05e1: Expected F4, but got I4
		//IL_03be: Expected I, but got O
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_0877: Expected O, but got Unknown
		//IL_0882: Expected O, but got I4
		//IL_0355: Expected O, but got I
		//IL_036a: Expected O, but got I
		//IL_08eb: Expected F4, but got I4
		//IL_0665: Expected F4, but got I4
		//IL_06a1: Expected F4, but got I4
		//IL_0931: Expected F4, but got I4
		//IL_0715: Expected I, but got O
		//IL_072b: Expected O, but got I
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Expected O, but got Unknown
		//IL_07a9: Expected F4, but got I4
		//IL_07de: Expected I, but got O
		//IL_09a4: Expected O, but got I4
		//IL_09bb: Expected I, but got I8
		//IL_078b: Expected I, but got I8
		base._003CAlias_003Ek__BackingField = false;
		ToggleBlue(visible: true);
		ToggleRed(visible: false);
		_wind = 1f;
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		nint num = unchecked((nint)null);
		nint num2;
		int num4 = default(int);
		if (!flag)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			bool flag2 = core._gameSessionData == null;
			num = unchecked((nint)null);
			if (!flag2)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				bool flag3 = (object)gameSessionData._activeCharacter == null;
				num = unchecked((nint)null);
				if (!flag3)
				{
					bool flag4 = (object)activeCharacter._spriteAnimation == null;
					num = unchecked((nint)null);
					if (!flag4)
					{
						activeCharacter._spriteAnimation.SetAnimation("walk");
						StopAllTimers();
						GameManager core2 = GM.Core;
						bool flag5 = (object)GM.Core == null;
						num = unchecked((nint)null);
						if (!flag5)
						{
							Stage stage = core2._stage;
							bool flag6 = (object)core2._stage == null;
							num = unchecked((nint)null);
							if (!flag6)
							{
								List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
								bool flag7 = (nint)stage._spawnedEnemies < 0;
								bool flag8 = stage._spawnedEnemies == null;
								num = unchecked((nint)null);
								if (!flag8)
								{
									object obj = spawnedEnemies._size - 1;
									num2 = unchecked((nint)null);
									if (flag7)
									{
										goto IL_03cb;
									}
									int num3 = num4;
									num = (nint)typeof(EnemyMaddener);
									while (true)
									{
										GameManager core3 = GM.Core;
										bool flag9 = (object)GM.Core == null;
										num4 = num3;
										if (flag9)
										{
											break;
										}
										Stage stage2 = core3._stage;
										bool flag10 = (object)core3._stage == null;
										num4 = num3;
										if (flag10)
										{
											break;
										}
										List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
										bool flag11 = stage2._spawnedEnemies == null;
										num4 = num3;
										if (flag11)
										{
											break;
										}
										bool flag12 = (nint)obj >= spawnedEnemies2._size;
										num4 = num3;
										if (flag12)
										{
											goto IL_0852;
										}
										EnemyController[] items = spawnedEnemies2._items;
										bool flag13 = spawnedEnemies2._items == null;
										num4 = num3;
										if (flag13)
										{
											break;
										}
										bool flag14 = (nint)obj >= items.Length;
										num4 = num3;
										bool flag18;
										if (!flag14)
										{
											EnemyController enemyController = items[obj];
											bool flag15 = (object)items[obj] == null;
											num4 = num3;
											if (flag15)
											{
												break;
											}
											num4 = (int)enemyController;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener>)+130]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v5 (System.Int32)+130]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener>)+130]");
											object obj3 = num5 - 0;
											bool flag16 = (nint)obj3 < 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v5 (System.Int32)+130]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener>)+130]");
											if (num6 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v5 (System.Int32)+C8]");
												object obj4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rax_v102+FFFFFFF8+v751 @ rax_v98*8]");
												object obj5 = -num;
												flag16 = (nint)obj5 < 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rax_v102+FFFFFFF8+v751 @ rax_v98*8]");
												bool flag17 = 0 == num;
												flag18 = flag16;
												if (flag17)
												{
													goto IL_0869;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v100 @ r9_v5 (System.Int32)+388] (should have been resolved before IL gen)");
											num = (nint)typeof(EnemyMaddener);
											flag18 = flag16;
											goto IL_0869;
										}
										throw new IndexOutOfRangeException();
										IL_0869:
										obj--;
										object obj6 = !flag18;
										num2 = num;
										num3 = num4;
										if (obj6 != null)
										{
											continue;
										}
										goto IL_03cb;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07ee;
		IL_0852:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_09d1;
		IL_07ee:
		throw new NullReferenceException();
		IL_03cb:
		StopRedEmitters();
		EnemyMaddener enemyMaddener = _enemyMaddener;
		if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
		{
			bool flag19 = (object)_enemyMaddener == null;
			num = num2;
			if (flag19)
			{
				goto IL_07ee;
			}
			_enemyMaddener.GetDamaged(108f, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
			num2 = unchecked((nint)null);
		}
		else
		{
			Debug.LogWarning("[GURU] EnemyMaddener is invalid, cannot damage");
		}
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Loop = true;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Wind, soundConfig, 0f, 10, time);
		GameManager core4 = GM.Core;
		bool flag20 = (object)GM.Core == null;
		float num7 = 0f;
		num4 = 10;
		num = num2;
		TweenCallback callback;
		TweenCallback tweenCallback;
		if (!flag20)
		{
			Stage stage3 = core4._stage;
			bool flag21 = (object)core4._stage == null;
			num7 = 0f;
			num4 = 10;
			num = num2;
			if (!flag21)
			{
				stage3._003CPause_003Ek__BackingField = 2.1474836E+09f;
				GameManager core5 = GM.Core;
				bool flag22 = (object)GM.Core == null;
				num7 = 0f;
				num4 = 10;
				num = num2;
				if (!flag22)
				{
					Stage stage4 = core5._stage;
					bool flag23 = (object)core5._stage == null;
					num7 = 0f;
					num4 = 10;
					num = num2;
					if (!flag23)
					{
						if (stage4._spawnTimer != null)
						{
							stage4._spawnTimer.Cancel();
						}
						GameManager core6 = GM.Core;
						bool flag24 = (object)GM.Core == null;
						num7 = 0f;
						num4 = 10;
						num = num2;
						if (!flag24)
						{
							core6._003CCanInterrupt_003Ek__BackingField = true;
							GameManager core7 = GM.Core;
							bool flag25 = (object)GM.Core == null;
							num7 = 0f;
							num4 = 10;
							num = num2;
							if (!flag25)
							{
								bool flag26 = core7._multiplayer == null;
								num7 = 0f;
								num4 = 10;
								num = num2;
								if (!flag26)
								{
									if (core7._multiplayer.IsOnlineMultiplayer)
									{
										OnlineStageManager instance = OnlineStageManager._instance;
										bool flag27 = (object)OnlineStageManager._instance == null;
										num7 = 0f;
										num4 = 10;
										num = num2;
										if (flag27)
										{
											goto IL_07ee;
										}
										instance._003CListenForHostDisconnection_003Ek__BackingField = false;
									}
									callback = _003C_003Ec._003C_003E9__46_1;
									if (_003C_003Ec._003C_003E9__46_1 != null)
									{
										goto IL_07e3;
									}
									tweenCallback = null;
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r10_v8 (Il2CppMethodInfo)+8]");
									((Delegate)tweenCallback).method_ptr = (IntPtr)0;
									((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec._003CRosaryTriggered_003Eb__46_1);
									((Delegate)tweenCallback).m_target = _003C_003Ec._003C_003E9;
									num4 = 10;
									((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r10_v8 (Il2CppMethodInfo)+4C]");
									object obj7 = (nint)0 >> 4;
									object obj8 = obj7 & 1;
									nint num9;
									if (obj8 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r10_v8 (Il2CppMethodInfo)+52]");
										if ((nint)0 == 0)
										{
											num9 = unchecked((nint)6447293664L);
											goto IL_099b;
										}
									}
									else
									{
										bool flag28 = _003C_003Ec._003C_003E9 == null;
										num7 = 0f;
										num = num2;
										if (flag28)
										{
											goto IL_09d1;
										}
									}
									num9 = ((Delegate)tweenCallback).method_ptr;
									((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
									goto IL_099b;
								}
							}
						}
					}
				}
			}
		}
		goto IL_07ee;
		IL_07e3:
		TweenFishEye(callback);
		return;
		IL_099b:
		object obj9 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__46_1 = tweenCallback;
		callback = tweenCallback;
		goto IL_07e3;
		IL_09d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
		object obj10 = default(object);
		throw obj10;
	}

	private unsafe void _003CSetupTimers_003Eb__60_0()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00e0: Expected O, but got Ref
		//IL_0168: Expected O, but got I4
		//IL_0374->IL026f: Incompatible stack heights: 1 vs 0
		//IL_03c7->IL026f: Incompatible stack heights: 2 vs 0
		//IL_0406->IL026f: Incompatible stack heights: 2 vs 0
		Debug.Log("Starting 1st section");
		ToggleBlue(visible: false);
		ToggleRed(visible: true);
		ToggleAlias();
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			core._canRunTickerTimer = false;
			UIView.ExecuteHide("Game", "Main Game", false);
			base._003CAlias_003Ek__BackingField = true;
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null && core2._characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator ret = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core2._characters;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					string gameSessionData = (string)(object)core3._gameSessionData;
					if (core3._gameSessionData != null)
					{
						object obj2 = gameSessionData._stringLength;
						if (gameSessionData._stringLength != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v10 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v10 (System.Object)+10]");
							IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
								if ((object)core3._stage != null)
								{
									Vector2 spawnPos = default(Vector2);
									bool forceSpawn = default(bool);
									GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.BOSS_XLMADDENER, spawnPos, asRemote: false, forceSpawn);
									if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
									{
										EnemyMaddener component = gameObject.GetComponent<EnemyMaddener>();
										_enemyMaddener = component;
									}
									TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_whiteFader, 0f, 1f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (tweenerCore != null)
									{
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

	private float _003CSetupTimers_003Eb__60_1()
	{
		return _wind;
	}

	private void _003CSetupTimers_003Eb__60_2(float x)
	{
		_wind = x;
	}

	private void _003CSetupTimers_003Eb__60_3()
	{
		Debug.Log("Starting 2nd section");
		_enemyMaddener.Spinnn();
		Transform target = _cloudsWhite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, 4f, 3.0000002f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 6;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						float num = 0f * 6f;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((BackgroundX)(object)dOSetter)._003CSetupTimers_003Eb__60_15(4f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0f, 0.38000003f);
		TweenCallback tweenCallback2;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
						float num2 = 0f * 7f;
					}
					TweenCallback tweenCallback = delegate
					{
						//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
						ShootVfx();
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)_enemyMaddener != null)
						{
							Transform transform = _enemyMaddener.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								if ((object)core._stage != null)
								{
									Vector2 spawnPos = default(Vector2);
									bool forceSpawn = default(bool);
									GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
									return;
								}
							}
						}
						throw new NullReferenceException();
					};
					tweenCallback2 = tweenCallback;
					goto IL_029c;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
			ShootVfx();
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)_enemyMaddener != null)
			{
				Transform transform = _enemyMaddener.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
						return;
					}
				}
			}
			throw new NullReferenceException();
		};
		bool flag = tweenerCore2 == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_029c;
		}
		goto IL_02cb;
		IL_02cb:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action onComplete = delegate
		{
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			float x = default(float);
			((BackgroundX)(object)dOSetter2)._003CSetupTimers_003Eb__60_19(x);
			TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, 0f, 0.38000003f);
			TweenCallback tweenCallback5;
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
							float num3 = 0f * 7f;
						}
						TweenCallback tweenCallback4 = delegate
						{
							//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
							ShootVfx();
							GameManager core = GM.Core;
							if ((object)GM.Core != null && (object)_enemyMaddener != null)
							{
								Transform transform = _enemyMaddener.transform;
								if ((object)transform != null)
								{
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
									if ((object)core._stage != null)
									{
										Vector2 spawnPos = default(Vector2);
										bool forceSpawn = default(bool);
										GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
										return;
									}
								}
							}
							throw new NullReferenceException();
						};
						tweenCallback5 = tweenCallback4;
						goto IL_0127;
					}
				}
			}
			TweenCallback tweenCallback6 = delegate
			{
				//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
				ShootVfx();
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_enemyMaddener != null)
				{
					Transform transform = _enemyMaddener.transform;
					if ((object)transform != null)
					{
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)core._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
							return;
						}
					}
				}
				throw new NullReferenceException();
			};
			bool flag2 = tweenerCore3 == null;
			tweenCallback5 = tweenCallback6;
			if (!flag2)
			{
				goto IL_0127;
			}
			goto IL_0156;
			IL_0127:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
			goto IL_0156;
			IL_0156:
			_tweenExplosions = tweenerCore3;
			Tween tweenExplosions = _tweenExplosions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tweenExplosions.stringId = "DefaultGameTweenId";
			if (++_tweenExplosionsTimerRepeatCount >= 6)
			{
				_tweenExplosionsTimer.Cancel();
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer tweenExplosionsTimer = Timers.Register(3.0400002f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tweenExplosionsTimer = tweenExplosionsTimer;
		return;
		IL_029c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_02cb;
	}

	private float _003CSetupTimers_003Eb__60_14()
	{
		return _fireTimer;
	}

	private void _003CSetupTimers_003Eb__60_15(float x)
	{
		_fireTimer = x;
	}

	private void _003CSetupTimers_003Eb__60_16()
	{
		//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
		ShootVfx();
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)_enemyMaddener != null)
		{
			Transform transform = _enemyMaddener.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)core._stage != null)
				{
					Vector2 spawnPos = default(Vector2);
					bool forceSpawn = default(bool);
					GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CSetupTimers_003Eb__60_17()
	{
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((BackgroundX)(object)dOSetter)._003CSetupTimers_003Eb__60_19(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, 0.38000003f);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
						float num = 0f * 7f;
					}
					TweenCallback tweenCallback = delegate
					{
						//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
						ShootVfx();
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)_enemyMaddener != null)
						{
							Transform transform = _enemyMaddener.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								if ((object)core._stage != null)
								{
									Vector2 spawnPos = default(Vector2);
									bool forceSpawn = default(bool);
									GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
									return;
								}
							}
						}
						throw new NullReferenceException();
					};
					tweenCallback2 = tweenCallback;
					goto IL_0127;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
			ShootVfx();
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)_enemyMaddener != null)
			{
				Transform transform = _enemyMaddener.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
						return;
					}
				}
			}
			throw new NullReferenceException();
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_0127;
		}
		goto IL_0156;
		IL_0127:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0156;
		IL_0156:
		_tweenExplosions = tweenerCore;
		Tween tweenExplosions = _tweenExplosions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tweenExplosions.stringId = "DefaultGameTweenId";
		if (++_tweenExplosionsTimerRepeatCount >= 6)
		{
			_tweenExplosionsTimer.Cancel();
		}
	}

	private float _003CSetupTimers_003Eb__60_18()
	{
		return _fireTimer;
	}

	private void _003CSetupTimers_003Eb__60_19(float x)
	{
		_fireTimer = x;
	}

	private void _003CSetupTimers_003Eb__60_20()
	{
		//IL_0100->IL007f: Incompatible stack heights: 1 vs 0
		ShootVfx();
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)_enemyMaddener != null)
		{
			Transform transform = _enemyMaddener.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)core._stage != null)
				{
					Vector2 spawnPos = default(Vector2);
					bool forceSpawn = default(bool);
					GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_BAT_PROJECTILE, spawnPos, asRemote: false, forceSpawn);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private float _003CSetupTimers_003Eb__60_4()
	{
		return _wind;
	}

	private void _003CSetupTimers_003Eb__60_5(float x)
	{
		_wind = x;
	}

	private void _003CSetupTimers_003Eb__60_6()
	{
		Debug.Log("Starting 3rd section");
		_enemyMaddener.StartLowerScreenMotion();
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((BackgroundX)(object)dOSetter)._003CSetupTimers_003Eb__60_22(x);
		TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.4f);
		TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 1f);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 40;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
						float num = 0f * 40f;
					}
					TweenCallback tweenCallback = delegate
					{
						//IL_01af->IL012e: Incompatible stack heights: 1 vs 0
						//IL_00d9->IL012e: Incompatible stack heights: 1 vs 0
						//IL_0108->IL012e: Incompatible stack heights: 1 vs 0
						ShootVfx();
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)_enemyMaddener != null)
						{
							Transform transform = _enemyMaddener.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								if ((object)core._stage != null)
								{
									Vector2 spawnPos = default(Vector2);
									bool forceSpawn = default(bool);
									GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_SHADE, spawnPos, asRemote: false, forceSpawn);
									if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
									{
										return;
									}
									EnemyController component = gameObject.GetComponent<EnemyController>();
									if ((object)component != null)
									{
										EnemyData currentEnemyData = component._currentEnemyData;
										if (component._currentEnemyData != null)
										{
											currentEnemyData._003Cxp_003Ek__BackingField = 0f;
											component._003CSelfDestDistance_003Ek__BackingField = 1200000f;
											return;
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					tweenCallback2 = tweenCallback;
					goto IL_0176;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			//IL_01af->IL012e: Incompatible stack heights: 1 vs 0
			//IL_00d9->IL012e: Incompatible stack heights: 1 vs 0
			//IL_0108->IL012e: Incompatible stack heights: 1 vs 0
			ShootVfx();
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)_enemyMaddener != null)
			{
				Transform transform = _enemyMaddener.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_SHADE, spawnPos, asRemote: false, forceSpawn);
						if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						EnemyController component = gameObject.GetComponent<EnemyController>();
						if ((object)component != null)
						{
							EnemyData currentEnemyData = component._currentEnemyData;
							if (component._currentEnemyData != null)
							{
								currentEnemyData._003Cxp_003Ek__BackingField = 0f;
								component._003CSelfDestDistance_003Ek__BackingField = 1200000f;
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_0176;
		}
		goto IL_01a5;
		IL_0176:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01a5;
		IL_01a5:
		_tweenExplosions = tweenerCore;
		Tween tweenExplosions = _tweenExplosions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tweenExplosions.stringId = "DefaultGameTweenId";
	}

	private float _003CSetupTimers_003Eb__60_21()
	{
		return _fireTimer;
	}

	private void _003CSetupTimers_003Eb__60_22(float x)
	{
		_fireTimer = x;
	}

	private void _003CSetupTimers_003Eb__60_23()
	{
		//IL_01af->IL012e: Incompatible stack heights: 1 vs 0
		//IL_00d9->IL012e: Incompatible stack heights: 1 vs 0
		//IL_0108->IL012e: Incompatible stack heights: 1 vs 0
		ShootVfx();
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)_enemyMaddener != null)
		{
			Transform transform = _enemyMaddener.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)core._stage != null)
				{
					Vector2 spawnPos = default(Vector2);
					bool forceSpawn = default(bool);
					GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_SHADE, spawnPos, asRemote: false, forceSpawn);
					if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					EnemyController component = gameObject.GetComponent<EnemyController>();
					if ((object)component != null)
					{
						EnemyData currentEnemyData = component._currentEnemyData;
						if (component._currentEnemyData != null)
						{
							currentEnemyData._003Cxp_003Ek__BackingField = 0f;
							component._003CSelfDestDistance_003Ek__BackingField = 1200000f;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CSetupTimers_003Eb__60_7()
	{
		Debug.Log("Starting 4th section");
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = _003C_003Ec._003C_003E9__60_24;
			if (_003C_003Ec._003C_003E9__60_24 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__60_24 = delegate
				{
					//IL_00a9: Expected O, but got I4
					//IL_0184: Expected I4, but got I8
					//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
					GameManager core = GM.Core;
					if ((object)GM.Core != null && (object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE1S, spawnPos, asRemote: false, forceSpawn);
						if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						EnemySpin component = gameObject.GetComponent<EnemySpin>();
						if ((object)component != null)
						{
							SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
							component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
							if ((object)((EnemyController)component)._EnemyRenderer != null)
							{
								bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
								return;
							}
						}
					}
					throw new NullReferenceException();
				});
			}
			float num = (float)(flag ? 1 : 0) * 100f;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < 60);
		bool flag2 = false;
		do
		{
			Action onComplete2 = _003C_003Ec._003C_003E9__60_25;
			if (_003C_003Ec._003C_003E9__60_25 == null)
			{
				onComplete2 = (_003C_003Ec._003C_003E9__60_25 = delegate
				{
					//IL_00a9: Expected O, but got I4
					//IL_0184: Expected I4, but got I8
					//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
					GameManager core = GM.Core;
					if ((object)GM.Core != null && (object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE2S, spawnPos, asRemote: false, forceSpawn);
						if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						EnemySpin component = gameObject.GetComponent<EnemySpin>();
						if ((object)component != null)
						{
							SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
							component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
							if ((object)((EnemyController)component)._EnemyRenderer != null)
							{
								bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
								return;
							}
						}
					}
					throw new NullReferenceException();
				});
			}
			float num2 = (float)(flag2 ? 1 : 0) * 150f;
			float duration2 = num2 * 0.001f;
			Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag2 ? 1 : 0) < 40);
		bool flag3 = false;
		do
		{
			Action onComplete3 = _003C_003Ec._003C_003E9__60_26;
			if (_003C_003Ec._003C_003E9__60_26 == null)
			{
				onComplete3 = (_003C_003Ec._003C_003E9__60_26 = delegate
				{
					//IL_00a9: Expected O, but got I4
					//IL_0184: Expected I4, but got I8
					//IL_0189->IL014e: Incompatible stack heights: 1 vs 0
					GameManager core = GM.Core;
					if ((object)GM.Core != null && (object)core._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE3S, spawnPos, asRemote: false, forceSpawn);
						if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						EnemySpin component = gameObject.GetComponent<EnemySpin>();
						if ((object)component != null)
						{
							SpriteRenderer enemyRenderer = ((EnemyController)component)._EnemyRenderer;
							component._003CDepthOverride_003Ek__BackingField = (int?)(object)1;
							if ((object)((EnemyController)component)._EnemyRenderer != null)
							{
								bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, -2001);
								return;
							}
						}
					}
					throw new NullReferenceException();
				});
			}
			float num3 = (float)(flag3 ? 1 : 0) * 200f;
			float duration3 = num3 * 0.001f;
			Timer timer3 = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag3 ? 1 : 0) < 20);
	}

	private void _003CSetupTimers_003Eb__60_8()
	{
		AddRedParticlesBelow();
		EnemyMaddener enemyMaddener = _enemyMaddener;
		if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
		{
			_enemyMaddener.StartPursuit();
		}
		Action onComplete = AddRedParticles;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
	}

	private void _003CSetupTimers_003Eb__60_9()
	{
		if (!_hasRosaryBeenTriggered)
		{
			ShootEyes(6, 800f, 0.2f);
		}
	}

	private void _003CSetupTimers_003Eb__60_10()
	{
		if (!_hasRosaryBeenTriggered)
		{
			ShootEyes(4800, 400f, 0.2f);
		}
	}

	private void _003CSetupTimers_003Eb__60_11()
	{
		if (!_hasRosaryBeenTriggered)
		{
			ShootEyes(25, 200f, 0.1f);
		}
	}

	private void _003CSetupTimers_003Eb__60_12()
	{
		if (!_hasRosaryBeenTriggered)
		{
			ShootEyes(50, 100f, 0f);
		}
	}

	private void _003CSetupTimers_003Eb__60_13()
	{
		if (!_hasRosaryBeenTriggered)
		{
			EnemyMaddener enemyMaddener = _enemyMaddener;
			if ((object)_enemyMaddener != null && ((UnityEngine.Object)enemyMaddener).m_CachedPtr != (IntPtr)0)
			{
				_enemyMaddener.StartKill();
			}
		}
	}

	private void _003CShootVfx_003Eb__65_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRay, 0f);
	}

	private void _003CShootVfx_003Eb__65_1()
	{
		Transform transform = _shootingRay.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void _003CShootVfx_003Eb__65_2()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_shootingRing, 0f);
	}

	private void _003CShootVfx_003Eb__65_3()
	{
		Transform transform = _shootingRing.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void _003CCheckDistanceFromRosary_003Eb__68_0()
	{
		if (!_hasRosaryBeenTriggered)
		{
			GameManager core = GM.Core;
			Vector2 bossyPosition = core._stage.GetBossyPosition();
			GameManager core2 = GM.Core;
			bool forceSpawn = default(bool);
			GameObject gameObject = core2._stage.SpawnEnemy(EnemyType.MOON_TRINACRIA_X, bossyPosition, asRemote: false, forceSpawn);
		}
		if (++_checkRosaryTimerRepeatCount >= 50)
		{
			_checkRosaryTimer.Cancel();
		}
	}
}
