using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyJeneviv : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static DOGetter<float> _003C_003E9__44_0;

		public static DOSetter<float> _003C_003E9__44_1;

		public static TweenCallback _003C_003E9__46_0;

		public static TweenCallback _003C_003E9__46_1;

		public static Predicate<CharacterController> _003C_003E9__54_0;

		public static Predicate<CharacterController> _003C_003E9__56_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CCastWorldEater_003Eb__44_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CCastWorldEater_003Eb__44_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}

		internal void _003CScreenShake_003Eb__46_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -2f;
		}

		internal void _003CScreenShake_003Eb__46_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}

		internal bool _003CStealHearts_003Eb__54_0(CharacterController x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._characterType - 75;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CDevourEleanor_003Eb__56_0(CharacterController x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._characterType - 75;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public PhaserSprite ray;

		internal void _003CChargeWorldEater_003Eb__0()
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite = ray.setAlpha(1f);
			PhaserSprite phaserSprite2 = ray.setScale(0f, (float?)(object)0);
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public EnemyJeneviv _003C_003E4__this;

		public PhaserSprite img2;

		internal void _003CStealHearts_003Eb__1()
		{
			//IL_0097: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.65f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 500f, 1, time);
			float2 position = _003C_003E4__this.position;
			Vector2 pos = default(Vector2);
			GM.Core.ShowDamageAt(pos, -6f);
			GameObject gameObject = img2.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public PhaserSprite s;

		public int index;

		public TweenCallback _003C_003E9__3;

		internal void _003CDevourEleanor_003Eb__1()
		{
			PhaserSprite phaserSprite = s.setVisible(visible: true);
		}

		internal void _003CDevourEleanor_003Eb__2()
		{
			//IL_002c: Expected I, but got O
			//IL_0090: Expected O, but got I4
			//IL_00ac: Expected O, but got I4
			//IL_00bc: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)s != null)
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
			tweenConfig.duration = 500f;
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.scaleY = (float?)(object)1;
			object obj2 = index + 10;
			float delay = (float)obj2 * 100f;
			tweenConfig.delay = delay;
			TweenCallback onComplete = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onComplete = (_003C_003E9__3 = delegate
				{
					PhaserSprite phaserSprite = s.setVisible(visible: false);
					s.destroy();
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CDevourEleanor_003Eb__3()
		{
			PhaserSprite phaserSprite = s.setVisible(visible: false);
			s.destroy();
		}
	}

	private sealed class _003C_003Ec__DisplayClass58_0
	{
		public float radius;

		public EnemyJeneviv _003C_003E4__this;

		public Action _003C_003E9__0;

		internal void _003CFireOphion_003Eb__0()
		{
			//IL_00eb: Expected O, but got F4
			//IL_014e: Expected O, but got F4
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			object obj = UnityEngine.Random.value;
			float num = radius * 0.01f;
			object obj2 = default(object);
			float num2 = (float)obj2 - 0.5f;
			float num3 = num * num2;
			float num4 = num3 + (float)renderer.screenCenter;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			object obj3 = UnityEngine.Random.value;
			float num5 = num2 - 0.5f;
			float num6 = radius * 0.01f;
			float num7 = num6 * num5;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v21 (PhaserScene+Renderer)+38]");
			float y = 0f - num7;
			bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
			EnemyJeneviv enemyJeneviv = _003C_003E4__this;
			float num8 = default(float);
			if (!isOnlineMultiplayer)
			{
				float duration = default(float);
				float hitboxDelay = default(float);
				DamagingZoneOphion damagingZoneOphion = enemyJeneviv._damagingZonePool.SpawnAt(num4, y, 64f, num8, duration, hitboxDelay);
				return;
			}
			Action<float, float> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
			bool flag = enemyJeneviv._coherenceSync.SendCommand(action, MessageTarget.All, num4, num8);
		}
	}

	private DiContainer _diContainer;

	private float _totalTime;

	private float _scitheTime = 5000f;

	private float _shieldDamage;

	private float _activationDistance = 7f;

	private bool _hasShield;

	private bool _isInvul;

	private bool _painInTheAss;

	private bool _isActivated;

	private bool _specialDeath;

	private Timer _shieldTimer;

	private Timer _summonSnakesEvent;

	private Timer _damagingZonesEvent;

	private DamagingZonePool_Ophion _damagingZonePool;

	private PhaserSprite _ringSprite;

	private PhaserSprite _breakFreeSprite;

	private PhaserSprite _worldEaterImage;

	private PhaserSprite _faderImage;

	private MultiTargetTween _worldEaterTween1;

	private MultiTargetTween _worldEaterTween2;

	private MultiTargetTween _worldEaterTween3;

	private List<EquipmentInfo> _playerEquipment;

	private List<PhaserSprite> _rays;

	private const float SHIELD_TIME = 45000f;

	private Action _003COnActivated_003Ek__BackingField;

	private Action _003COnDefeat_003Ek__BackingField;

	public Action OnActivated
	{
		get
		{
			return _003COnActivated_003Ek__BackingField;
		}
		set
		{
			_003COnActivated_003Ek__BackingField = value;
		}
	}

	public Action OnDefeat
	{
		get
		{
			return _003COnDefeat_003Ek__BackingField;
		}
		set
		{
			_003COnDefeat_003Ek__BackingField = value;
		}
	}

	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		GameManager core = GM.Core;
		_diContainer = core._diContainer;
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0024: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_02a7: Expected O, but got I4
		//IL_036d: Expected O, but got I4
		//IL_036d: Expected I4, but got O
		//IL_0402: Expected O, but got I4
		//IL_0402: Expected I4, but got O
		//IL_0430: Expected O, but got I4
		//IL_0430: Expected I4, but got O
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		Vector2 pos = default(Vector2);
		if (_currentEnemyData != null)
		{
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
			PhaserSprite ringSprite = _ringSprite;
			base._003CIsTeleportOnCull_003Ek__BackingField = false;
			base._003CIsCullable_003Ek__BackingField = false;
			_totalTime = 0f;
			_scitheTime = 5000f;
			if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
			{
				goto IL_0138;
			}
			float2 float5 = base.position;
			GameObject gameObject = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "sPFX_ring_64");
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
				if ((object)phaserSprite2 != null)
				{
					PhaserSprite ringSprite2 = phaserSprite2.setBlendMode(BlendMode.Add);
					_ringSprite = ringSprite2;
					goto IL_0138;
				}
			}
		}
		goto IL_046e;
		IL_0138:
		if (_damagingZonePool == null)
		{
			DamagingZonePool_Ophion damagingZonePool = new DamagingZonePool_Ophion();
			_damagingZonePool = damagingZonePool;
		}
		_shieldDamage = 0f;
		_hasShield = true;
		if (_shieldTimer != null)
		{
			_shieldTimer.Cancel();
		}
		Action onComplete = delegate
		{
			float hp = _hp - _shieldDamage;
			_hasShield = false;
			_hp = hp;
		};
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num = default(int);
		TimerType timerType = default(TimerType);
		Timer shieldTimer = Timers.Register(45.000004f, onComplete, null, isLooped: false, flag, monoBehaviour, num, timerType, isOnlineTimer: false, canPause: false);
		_shieldTimer = shieldTimer;
		float2 float6 = base.position;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "foscariEnemies", "stJeneviv_0");
		if ((object)phaserSprite3 != null)
		{
			PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
			if ((object)phaserSprite4 != null)
			{
				PhaserSprite breakFreeSprite = phaserSprite4.setOrigin(0.5f, (float?)(object)1);
				_breakFreeSprite = breakFreeSprite;
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("stJeneviv_", 0, 27, "foscariEnemies", flag ? 1 : 0);
				PhaserSprite breakFreeSprite2 = _breakFreeSprite;
				if ((object)_breakFreeSprite != null)
				{
					Action action = delegate
					{
						PhaserSprite phaserSprite5 = _breakFreeSprite.setVisible(visible: false);
					};
					if ((object)breakFreeSprite2._spriteAnimation != null)
					{
						breakFreeSprite2._spriteAnimation.AddAnimation("BreakAnim", animationFrames, 16, flag, (byte)(int)monoBehaviour != 0, (Action)num, (byte)timerType != 0);
						PhaserSprite breakFreeSprite3 = _breakFreeSprite;
						if ((object)_breakFreeSprite != null && (object)breakFreeSprite3._spriteRenderer != null)
						{
							Transform transform = breakFreeSprite3._spriteRenderer.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ rax_v40 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ rax_v40 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("uJeneviv_i0", 1, 5, "foscariEnemies", flag ? 1 : 0);
							List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("noJeneviv_i0", 1, 5, "foscariEnemies", flag ? 1 : 0);
							_SpriteAnimation.AddAnimation("NoEle", animationFrames3, 8, flag, (byte)(int)monoBehaviour != 0, (Action)num, (byte)timerType != 0);
							_SpriteAnimation.AddAnimation("NoColor", animationFrames2, 4, flag, (byte)(int)monoBehaviour != 0, (Action)num, (byte)timerType != 0);
							_SpriteAnimation.SetAnimation("idle");
							BaseBody baseBody = body;
							baseBody._immovable = true;
							_isInvul = false;
							return;
						}
					}
				}
			}
		}
		goto IL_046e;
		IL_046e:
		throw new NullReferenceException();
	}

	public void RestoreShield()
	{
		_shieldDamage = 0f;
		_hasShield = true;
		if (_shieldTimer != null)
		{
			_shieldTimer.Cancel();
		}
		Action onComplete = delegate
		{
			float hp = _hp - _shieldDamage;
			_hasShield = false;
			_hp = hp;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer shieldTimer = Timers.Register(45.000004f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_shieldTimer = shieldTimer;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0356: Invalid comparison between F4 and I4
		//IL_02fb: Invalid comparison between I4 and F4
		//IL_0227: Expected O, but got I4
		//IL_031b: Expected O, but got F4
		//IL_00fe: Expected O, but got F4
		//IL_0298: Expected O, but got F4
		if (!_isActivated || _isInvul)
		{
			return;
		}
		object obj = default(object);
		float num;
		if ((nint)obj != 133)
		{
			bool flag = (nint)obj != 44;
			num = value;
			if (flag)
			{
				goto IL_02d0;
			}
		}
		num = value * 5f;
		goto IL_02d0;
		IL_02d0:
		if ((nint)obj == 134)
		{
			num *= 50f;
		}
		float num2 = default(float);
		float num3 = default(float);
		if (num > 0f)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CDamageNumbersEnabled_003Ek__BackingField)
			{
				float2 float5 = base.position;
				GM.Core.ShowDamageAt((Vector2)num2, num);
				num3 = num2;
			}
		}
		if (!_hasShield)
		{
			num3 = (_hp -= num);
		}
		else
		{
			float shieldDamage = num + _shieldDamage;
			_shieldDamage = shieldDamage;
		}
		if (0f < _hp)
		{
			_damageKb = damageKb;
		}
		else
		{
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				Die();
			}
			else if (_coherenceSync.HasStateAuthority)
			{
				Action action = OnlineDeath;
				bool flag2 = _coherenceSync.SendCommand(action, MessageTarget.All);
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float num4 = num3 - 0.5f;
		float detune = num4 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, time);
		if (showHitVfx != HitVfxType.None)
		{
			float2 float6 = base.position;
			GM.Core.ShowHitVfxAt((Vector2)num2, showHitVfx);
		}
		bool hasKb2 = default(bool);
		base.OnGetDamaged(showHitVfx, hasKb2);
	}

	public void OnlineDeath()
	{
		Die();
	}

	protected override void OnUpdate()
	{
		//IL_0504: Expected O, but got I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected I4, but got Unknown
		//IL_066e: Invalid comparison between I4 and F4
		//IL_0680: Expected F4, but got I4
		//IL_011f: Expected I, but got O
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02ef: Invalid comparison between F4 and O
		//IL_01d0: Expected I4, but got O
		//IL_05a8: Expected O, but got I
		//IL_0210: Expected I4, but got F4
		//IL_0210: Expected O, but got I
		//IL_03f6: Expected O, but got I4
		//IL_051e->IL0482: Incompatible stack heights: 1 vs 0
		//IL_025e->IL0482: Incompatible stack heights: 1 vs 0
		//IL_0545->IL0482: Incompatible stack heights: 1 vs 0
		//IL_0617->IL0482: Incompatible stack heights: 1 vs 0
		//IL_010c->IL0482: Incompatible stack heights: 1 vs 0
		//IL_0292->IL0482: Incompatible stack heights: 1 vs 0
		//IL_056c->IL0482: Incompatible stack heights: 1 vs 0
		//IL_014e->IL0482: Incompatible stack heights: 1 vs 0
		//IL_035f->IL0482: Incompatible stack heights: 1 vs 0
		//IL_0593->IL0482: Incompatible stack heights: 1 vs 0
		//IL_01bd->IL0482: Incompatible stack heights: 1 vs 0
		//IL_063f->IL0482: Incompatible stack heights: 1 vs 0
		//IL_05c8->IL0482: Incompatible stack heights: 1 vs 0
		//IL_03af->IL0482: Incompatible stack heights: 1 vs 0
		//IL_03de->IL0482: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					ArcadeSprite arcadeSprite = setDepth(renderer.pixelHeight);
					object enemyRenderer = _EnemyRenderer;
					if ((object)_EnemyRenderer != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdi_v4 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdi_v4 (System.Object)+10]");
						object obj = Renderer.get_sortingOrder_Injected((IntPtr)0);
						if ((object)_breakFreeSprite != null)
						{
							int num = obj + 1;
							PhaserSprite phaserSprite = _breakFreeSprite.setDepth(num);
							bool flag2 = !_painInTheAss;
							PhaserScene phaserScene = null;
							if (flag2)
							{
								goto IL_0219;
							}
							float2 float5 = base.position;
							float2 float6 = base.position;
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene2._renderer;
								if (s_scene2._renderer != null)
								{
									nint num2 = (nint)typeof(ArcadePhysics);
									phaserScene = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer3 = phaserScene._renderer;
										if (phaserScene._renderer != null)
										{
											float num3 = renderer2.width * 0.5f;
											float x = (float)float5 - num3;
											float num4 = renderer3.height * 0.5f;
											object obj2 = default(object);
											float y = (float)obj2 - num4;
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && (object)s_scene3.physics != null)
											{
												num = (int)typeof(ArcadePhysics);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v20 (Il2CppClass<ArcadePhysics>)+B8]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v51+18]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v51+18]");
													float height = default(float);
													bool? checkLeft = default(bool?);
													bool checkRight = default(bool);
													bool checkUp = default(bool);
													World world = ((World)0).setBounds(x, y, renderer2.width, height, checkLeft, checkRight, checkUp, (byte)(int)renderer3.height != 0);
													goto IL_0219;
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
		goto IL_0482;
		IL_0482:
		throw new NullReferenceException();
		IL_0219:
		if (!_isActivated)
		{
			float2 float7 = base.position;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer4 = s_scene4._renderer;
					if (s_scene4._renderer != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v23 (PhaserScene+Renderer)+38]");
						object obj5 = default(object);
						object obj4 = obj5 - 0;
						object obj6 = float7 - renderer4.screenCenter;
						object obj7 = obj4 * obj4;
						object obj8 = obj6 * obj6;
						object obj9 = obj8 + obj7;
						float activationDistance = _activationDistance;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)activationDistance) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
						{
							return;
						}
						_isActivated = true;
						if (_003COnActivated_003Ek__BackingField == null)
						{
							goto IL_05cd;
						}
						Action action = _003COnActivated_003Ek__BackingField;
						base._003CIsTeleportOnCull_003Ek__BackingField = true;
						if (_003COnActivated_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v155.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							OnActivated = null;
							StartVerySmartAI();
							GameManager core = GM.Core;
							if ((object)GM.Core != null)
							{
								GameSessionData gameSessionData = core._gameSessionData;
								if (core._gameSessionData != null)
								{
									CharacterController activeCharacter = gameSessionData._activeCharacter;
									if ((object)gameSessionData._activeCharacter != null)
									{
										object obj10 = activeCharacter._level * 300;
										_hp = (_maxHp = (float)obj10 + 1000f);
										goto IL_05cd;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0482;
		}
		goto IL_05cd;
		IL_05cd:
		base.OnUpdate();
		if (!base._003CIsDead_003Ek__BackingField)
		{
			float num5 = ((!_hasShield) ? _hp : (_maxHp - _shieldDamage));
			float num6 = num5 / _maxHp;
			float num7 = num6 * 4000f;
			bool flag3 = !(0f < num7);
			float num8 = 0f;
			if (!flag3)
			{
				num8 = num7;
			}
			float scitheTime = num8 + 500f;
			_scitheTime = scitheTime;
			float deltaTime = PauseSystem.DeltaTime;
			if ((_totalTime = deltaTime + _totalTime) > _scitheTime)
			{
				_totalTime = 0f;
			}
		}
	}

	public override void Disappear()
	{
	}

	public void SealInStone()
	{
		//IL_0043: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_0146: Expected O, but got F4
		//IL_0179: Expected O, but got I4
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_032c: Expected O, but got I4
		//IL_03da: Expected O, but got I4
		//IL_040d: Expected O, but got I4
		_activationDistance = 0f;
		base._003CSpeed_003Ek__BackingField = 0f;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		_specialDeath = true;
		_isInvul = true;
		_SpriteAnimation.SetAnimation("NoColor");
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_hp = (_maxHp += 1000f);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		List<PhaserSprite> rays = _rays;
		float num = renderer.width * 0.5f;
		int version = rays._version + 1;
		rays._version = version;
		rays._size = 0;
		if (rays._size > 0)
		{
			Array.Clear(rays._items, 0, rays._size);
		}
		float? num2 = (float?)(object)0;
		do
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)num, "vfx", "RayRay");
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
			PhaserSprite component = phaserSprite2.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = RenderingExtensions.SetScrollFactor(component, 0f);
			PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite5 = phaserSprite4.setDepth(9998);
			GameObject gameObject = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject).SetName("RayRay (EnemyJeneviv)");
			List<object> rays2 = (List<object>)(object)_rays;
			int version2 = rays2._version + 1;
			rays2._version = version2;
			object[] items = rays2._items;
			if (rays2._size >= items.Length)
			{
				rays2.AddWithResize((object)phaserSprite5);
			}
			else
			{
				int num3 = rays2._size + 1;
				rays2._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num2 = (float?)(object)((_003F?)num2 + 1);
		}
		while ((nint)num2 < 13);
		PhaserWorld instance2 = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite worldEaterImage = instance2.AddPhaserSprite(pos, "vfx", "2Skull1");
		_worldEaterImage = worldEaterImage;
		PhaserSprite phaserSprite6 = RenderingExtensions.SetScrollFactor(_worldEaterImage, 0f);
		PhaserSprite phaserSprite7 = _worldEaterImage.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite8 = _worldEaterImage.setAlpha(0f);
		PhaserSprite phaserSprite9 = _worldEaterImage.setDepth(10000f);
		PhaserWorld instance3 = PhaserWorld.Instance;
		PhaserSprite component2 = instance3.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite10 = RenderingExtensions.SetScrollFactor(component2, 0f);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		PhaserSprite phaserSprite11 = phaserSprite10.setScale(renderer2.width, (float?)(object)1);
		PhaserSprite phaserSprite12 = phaserSprite11.setAlpha(0f);
		PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0f, (float?)(object)0);
		PhaserSprite phaserSprite14 = phaserSprite13.setDepth(9999);
		GameObject gameObject2 = phaserSprite14.gameObject;
		((UnityEngine.Object)gameObject2).SetName("FaderImage EnemyJeneviv");
		_faderImage = phaserSprite14;
	}

	public void BreakFree1()
	{
		//IL_008f: Expected O, but got I4
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = _breakFreeSprite.setVisible(visible: true);
		PhaserSprite breakFreeSprite = _breakFreeSprite;
		breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		object obj = activeCharacter._level * 300;
		_hp = (_maxHp = (float)obj + 1000f);
	}

	public void StartMoving()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6283]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = _breakFreeSprite.setVisible(visible: true);
		PhaserSprite breakFreeSprite = _breakFreeSprite;
		breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
		float num = _defaultSpeed * 0.1f;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		_painInTheAss = true;
		base._003CSpeed_003Ek__BackingField = num;
		_SpriteAnimation.SetAnimation("NoColor");
	}

	public void BreakFree2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6284]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = _breakFreeSprite.setVisible(visible: true);
		PhaserSprite breakFreeSprite = _breakFreeSprite;
		breakFreeSprite._spriteAnimation.SetAnimation("BreakAnim");
		_SpriteAnimation.SetAnimation("NoEle");
		base._003CSpeed_003Ek__BackingField = _defaultSpeed;
	}

	public unsafe void ChargeWorldEater()
	{
		//IL_0038: Expected F4, but got I4
		//IL_0041: Expected F4, but got I4
		//IL_03ce: Invalid comparison between F4 and I4
		//IL_006b: Invalid comparison between F4 and I4
		//IL_033c: Expected O, but got F4
		//IL_00d4: Expected O, but got Ref
		//IL_0120: Expected I, but got O
		//IL_017f: Expected O, but got I4
		//IL_024d: Expected O, but got I4
		//IL_034e: Expected I, but got O
		//IL_0364: Expected O, but got I
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_02df: Expected I, but got O
		//IL_0398: Expected O, but got I4
		//IL_03af: Expected I, but got I8
		//IL_02c8: Expected I, but got I8
		//IL_0143->IL0143: Incompatible stack heights: 2 vs 1
		//IL_0332->IL03c1: Incompatible stack heights: 1 vs 0
		_SpriteAnimation.SetAnimation("NoEle");
		List<PhaserSprite> rays = _rays;
		base._003CSpeed_003Ek__BackingField = 0f;
		float num = 0f;
		object obj7;
		TweenCallback tweenCallback;
		TweenConfig tweenConfig;
		MultiTargetTween multiTargetTween;
		object obj3 = default(object);
		object obj8 = default(object);
		object obj4 = default(object);
		for (float num2 = 0f; num2 < (float)rays._size; obj7 = 24, ((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L), tweenConfig.onStart = tweenCallback, multiTargetTween = Tweens.Add(tweenConfig), rays = _rays, num++, obj3 = obj8, num2 = num)
		{
			_003C_003Ec__DisplayClass43_0 obj = new _003C_003Ec__DisplayClass43_0();
			List<PhaserSprite> rays2 = _rays;
			bool flag = !(num < (float)rays2._size);
			PhaserSprite[] items = rays2._items;
			obj.ray = items[num];
			object obj2 = UnityEngine.Random.value;
			Transform transform = obj.ray.transform;
			transform.localEulerAngles = (Vector3)(&obj3);
			tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)obj.ray != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag2 = obj4 == null;
			}
			array[0] = obj.ray;
			tweenConfig.targets = array;
			tweenConfig.alpha = (float?)(object)1;
			Func<int, float> staggerScale = Tweens.Stagger(0.5f, new StaggerConfig
			{
				ease = Ease.Linear,
				start = 2f
			});
			tweenConfig.staggerScale = staggerScale;
			Func<int, float> staggerDuration = Tweens.Stagger(20f, new StaggerConfig
			{
				ease = Ease.Linear,
				start = 4000f
			});
			tweenConfig.staggerDuration = staggerDuration;
			Transform transform2 = obj.ray.transform;
			Vector3 localEulerAngles = transform2.localEulerAngles;
			tweenConfig.angle = (float?)(object)1;
			tweenCallback = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v7 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass43_0._003CChargeWorldEater_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v7 (Il2CppMethodInfo)+4C]");
			object obj5 = (nint)0 >> 4;
			object obj6 = obj5 & 1;
			nint num5;
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v7 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					continue;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num5 = ((Delegate)tweenCallback).method_ptr;
		}
	}

	public void CastWorldEater()
	{
		//IL_01af: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_0149: Expected I4, but got F4
		float num = _defaultSpeed * 0.5f;
		base._003CSpeed_003Ek__BackingField = num;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.WorldEater, soundConfig, 0f, 10, num2);
		DOGetter<float> getter = _003C_003Ec._003C_003E9__44_0;
		if (_003C_003Ec._003C_003E9__44_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__44_0 = dOGetter;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__44_1;
		float x = default(float);
		if (_003C_003Ec._003C_003E9__44_1 == null)
		{
			DOSetter<float> dOSetter = null;
			((_003C_003Ec)(object)dOSetter)._003CCastWorldEater_003Eb__44_1(x);
			_003C_003Ec._003C_003E9__44_1 = dOSetter;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 1f, 0.5f);
		PlayWorldEater();
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		((_003C_003Ec)(object)this)._003CCastWorldEater_003Eb__44_1(x);
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = targets;
			tweenConfig.duration = 15000f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			Action onComplete = StealHearts;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			DevourEleanor();
			_SpriteAnimation.SetAnimation("idle");
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void StartVerySmartAI()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float num = ((!config._003CSelectedHyper_003Ek__BackingField) ? 1.2f : 1f);
		float num2 = num * _defaultSpeed;
		_isInvul = false;
		base._003CSpeed_003Ek__BackingField = num2;
		SummonSnakes(12, 24);
		FireOphion(50f, 400f, 13);
		if (_summonSnakesEvent != null)
		{
			_summonSnakesEvent.Cancel();
		}
		Action onComplete = delegate
		{
			SummonSnakes(6, 6);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer summonSnakesEvent = Timers.Register(6.701f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_summonSnakesEvent = summonSnakesEvent;
		if (_damagingZonesEvent != null)
		{
			_damagingZonesEvent.Cancel();
		}
		Action onComplete2 = delegate
		{
			//IL_000e: Expected O, but got F4
			//IL_0062: Expected O, but got F4
			//IL_003c: Expected O, but got F4
			object obj = UnityEngine.Random.value;
			object obj2 = default(object);
			float num3 = (float)obj2 * 60f;
			float delay = num3 + 60f;
			object obj3 = UnityEngine.Random.value;
			float num4 = (float)obj2 * 200f;
			float radius = num4 + 100f;
			object obj4 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm0\"");
			int times = default(int);
			FireOphion(delay, radius, times);
		};
		Timer damagingZonesEvent = Timers.Register(8.353001f, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_damagingZonesEvent = damagingZonesEvent;
	}

	public void ScreenShake(int repeats = 6)
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
		TweenCallback onStart = _003C_003Ec._003C_003E9__46_0;
		if (_003C_003Ec._003C_003E9__46_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__46_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -2f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__46_1;
		if (_003C_003Ec._003C_003E9__46_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__46_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void TestSpecialDeath()
	{
		_specialDeath = true;
		Die();
	}

	private void ActivatedByDistance()
	{
		//IL_003c: Expected O, but got I4
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		object obj = activeCharacter._level * 300;
		_hp = (_maxHp = (float)obj + 1000f);
	}

	protected unsafe override void Die()
	{
		//IL_00d9: Expected O, but got I4
		//IL_01b9: Expected I, but got O
		//IL_01ea: Expected O, but got I
		//IL_0229: Expected O, but got I
		//IL_0276: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_05aa: Expected O, but got I4
		//IL_05b3: Expected O, but got I4
		//IL_05c5: Expected I, but got O
		//IL_05db: Expected O, but got I
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_03ce: Expected O, but got I
		//IL_0652: Expected I, but got O
		//IL_08ae: Expected I, but got I8
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Expected O, but got Unknown
		//IL_063b: Expected I, but got I8
		//IL_06af: Expected I, but got O
		//IL_06c5: Expected O, but got I
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected O, but got Unknown
		//IL_0490: Expected I, but got O
		//IL_0741: Expected I, but got O
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_0876: Expected O, but got Unknown
		//IL_0881: Expected O, but got I4
		//IL_097f: Expected I, but got I8
		//IL_0714: Expected I, but got I8
		//IL_0454: Expected O, but got I
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.Die();
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (_summonSnakesEvent != null)
		{
			_summonSnakesEvent.Cancel();
		}
		Timer damagingZonesEvent = _damagingZonesEvent;
		if (_damagingZonesEvent != null)
		{
			_damagingZonesEvent.Cancel();
		}
		BaseBody baseBody = body;
		bool flag7 = default(bool);
		if (body != null)
		{
			baseBody._velocity = (float2)0;
			if (body != null)
			{
				_ = 0;
				DamagingZonePool_Ophion damagingZonePool = _damagingZonePool;
				if (_damagingZonePool != null && ((Group)damagingZonePool).children != null)
				{
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					if (enumerator.MoveNext())
					{
						Component component = null;
						throw new NullReferenceException();
					}
					if (!_specialDeath)
					{
						return;
					}
					nint num = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v876 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num2 = 0;
					GameManager core = GM.Core;
					bool flag = (object)GM.Core == null;
					damagingZonesEvent = (Timer)num2;
					if (!flag)
					{
						core._canRunTickerTimer = false;
						GameManager gameManager = _gameManager;
						bool flag2 = (object)_gameManager == null;
						damagingZonesEvent = (Timer)num2;
						if (!flag2)
						{
							damagingZonesEvent = (Timer)(object)gameManager._stage;
							if ((object)gameManager._stage != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v18 (VampireSurvivors.Framework.TimerSystem.Timer)+190]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v18 (VampireSurvivors.Framework.TimerSystem.Timer)+190]");
								bool flag3 = (nint)0 < (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v18 (VampireSurvivors.Framework.TimerSystem.Timer)+190]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdi_v8+18]");
									object obj2 = -1;
									if (flag3)
									{
										goto IL_04a7;
									}
									while (true)
									{
										GameManager gameManager2 = _gameManager;
										if ((object)_gameManager == null)
										{
											break;
										}
										Stage stage = gameManager2._stage;
										if ((object)gameManager2._stage == null)
										{
											break;
										}
										List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
										if (stage._spawnedEnemies == null)
										{
											break;
										}
										bool flag6;
										if ((nint)obj2 < spawnedEnemies._size)
										{
											EnemyController[] items = spawnedEnemies._items;
											if (spawnedEnemies._items == null)
											{
												break;
											}
											Timer timer = (Timer)(object)items[obj2];
											if ((object)items[obj2] == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rsi_v9 (VampireSurvivors.Framework.TimerSystem.Timer)+C8]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rsi_v9 (VampireSurvivors.Framework.TimerSystem.Timer)+C8]");
											bool flag4 = (nint)0 < (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rsi_v9 (VampireSurvivors.Framework.TimerSystem.Timer)+C8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r14_v8+10]");
												flag4 = (nint)0 < (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r14_v8+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rsi_v9 (VampireSurvivors.Framework.TimerSystem.Timer)+C8]");
													if ((nint)0 == 0)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rsi_v9 (VampireSurvivors.Framework.TimerSystem.Timer)+C8]");
													bool hasStateAuthority = ((CoherenceSync)0).HasStateAuthority;
													flag4 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
													bool flag5 = !hasStateAuthority;
													flag6 = flag4;
													if (flag5)
													{
														goto IL_0868;
													}
												}
											}
											nint num3 = (nint)timer;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1197 @ rax_v39 (Il2CppClass<VampireSurvivors.Framework.TimerSystem.Timer>)+388] (should have been resolved before IL gen)");
											flag6 = flag4;
											goto IL_0868;
										}
										System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
										return;
										IL_0868:
										obj2--;
										object obj4 = !flag6;
										flag7 = flag7;
										if (obj4 != null)
										{
											continue;
										}
										goto IL_04a7;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0747;
		IL_04a7:
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Action action3;
		if ((object)GM.Core != null)
		{
			GM.Core.TogglePlayerHealthBar(visible: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0f, 500f);
			float2 float5 = base.position;
			if ((object)GM.Core != null)
			{
				Vector2 center = default(Vector2);
				GM.Core.StopCamera(center);
				if ((object)GM.Core != null)
				{
					GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
					SpriteAnimation spriteAnimation = _SpriteAnimation;
					if ((object)_SpriteAnimation != null)
					{
						((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
						DeathScream();
						object obj5 = 24;
						object obj6 = 1;
						do
						{
							Action action2 = null;
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ r10_v3 (Il2CppMethodInfo)+8]");
							((Delegate)action2).method_ptr = (IntPtr)0;
							((Delegate)action2).method = (nint)__ldftn(EnemyJeneviv.DeathScream);
							((Delegate)action2).m_target = this;
							((Delegate)action2).method_code = (IntPtr)action2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ r10_v3 (Il2CppMethodInfo)+4C]");
							object obj7 = (nint)0 >> 4;
							object obj8 = obj7 & 1;
							nint num5;
							if (obj8 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ r10_v3 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num5 = unchecked((nint)6447293664L);
									goto IL_0897;
								}
							}
							((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
							num5 = ((Delegate)action2).method_ptr;
							goto IL_0897;
							IL_0897:
							((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
							float num6 = (float)obj6 * 1000f;
							float duration = num6 * 0.001f;
							Timer timer2 = Timers.Register(duration, action2, null, isLooped: false, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							obj6++;
						}
						while ((nint)obj6 < 5);
						action3 = null;
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v4 (Il2CppMethodInfo)+8]");
						((Delegate)action3).method_ptr = (IntPtr)0;
						((Delegate)action3).method = (nint)__ldftn(EnemyJeneviv._003CDie_003Eb__49_0);
						((Delegate)action3).m_target = this;
						((Delegate)action3).method_code = (IntPtr)action3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v4 (Il2CppMethodInfo)+4C]");
						object obj9 = (nint)0 >> 4;
						object obj10 = obj9 & 1;
						nint num8;
						if (obj10 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v4 (Il2CppMethodInfo)+52]");
							bool flag8 = (nint)0 == 0;
							num8 = unchecked((nint)6447293664L);
							if (flag8)
							{
								goto IL_0968;
							}
						}
						num8 = ((Delegate)action3).method_ptr;
						((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
						goto IL_0968;
					}
				}
			}
		}
		goto IL_0747;
		IL_0968:
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		Timer timer3 = Timers.Register(5f, action3, null, isLooped: false, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0747:
		throw new NullReferenceException();
	}

	private void RemovePlayerWeapons()
	{
		List<EquipmentInfo> playerEquipment = GM.Core.RemoveAllEquipmentFromPlayers();
		_playerEquipment = playerEquipment;
	}

	protected void DeathScream()
	{
		//IL_0193: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_ringSprite, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
		{
			PhaserSprite phaserSprite2 = RenderingExtensions.SetScale((PhaserSprite)(object)transform, 0f);
			if ((object)phaserSprite2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = targets;
		tweenConfig.duration = 300f;
		tweenConfig.repeat = 1;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			if ((object)_ringSprite != null)
			{
				Transform transform2 = _ringSprite.transform;
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag4 = (object)_ringSprite == null;
					PhaserSprite phaserSprite3 = _ringSprite.setVisible(visible: true);
					return;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite3 = _ringSprite.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void SpecialDeathAnimation()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A628D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_SpriteAnimation.SetAnimation("die");
	}

	private void PlayWorldEater()
	{
		//IL_001a: Expected O, but got I4
		//IL_00d2: Expected I, but got O
		//IL_0128: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		//IL_0205: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_0338: Expected I, but got O
		//IL_03aa: Expected O, but got I4
		PhaserSprite phaserSprite = _worldEaterImage.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _worldEaterImage.setAlpha(0f);
		PhaserSprite phaserSprite3 = _worldEaterImage.setFrame("2Skull1", "vfx");
		if (_worldEaterTween1 != null)
		{
			_worldEaterTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_worldEaterImage != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0066: Expected O, but got I4
			ScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.5f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 0f, 10, time);
			PhaserSprite phaserSprite4 = _worldEaterImage.setFrame("2Skull2", "vfx");
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween worldEaterTween = Tweens.Add(tweenConfig);
		_worldEaterTween1 = worldEaterTween;
		if (_worldEaterTween2 != null)
		{
			_worldEaterTween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_worldEaterImage != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 500f;
		tweenConfig2.delay = 500f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite4 = _worldEaterImage.setAlpha(1f);
		};
		tweenConfig2.onStart = onStart;
		MultiTargetTween worldEaterTween2 = Tweens.Add(tweenConfig2);
		_worldEaterTween2 = worldEaterTween2;
		if (_worldEaterTween3 != null)
		{
			_worldEaterTween3.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_faderImage != null)
		{
			nint num3 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.duration = 500f;
		tweenConfig3.yoyo = true;
		tweenConfig3.alpha = (float?)(object)1;
		MultiTargetTween worldEaterTween3 = Tweens.Add(tweenConfig3);
		_worldEaterTween3 = worldEaterTween3;
	}

	private void StealHearts()
	{
		//IL_013a: Expected I, but got O
		//IL_0190: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01d3: Expected O, but got I4
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass54_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		GameManager core = GM.Core;
		Predicate<CharacterController> match = _003C_003Ec._003C_003E9__54_0;
		if (_003C_003Ec._003C_003E9__54_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__54_0 = delegate(CharacterController x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				object obj2 = x._characterType - 75;
				return obj2 == null;
			});
		}
		CharacterController characterController = core._characters.Find(match);
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		PhaserWorld instance = PhaserWorld.Instance;
		float2 float5 = characterController.position;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "items", "HeartMini");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
		PhaserSprite img = phaserSprite2.setDepth(31765);
		CS_0024_003C_003E8__locals5.img2 = img;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals5.img2 != null)
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
		tweenConfig.duration = 500f;
		float2 float6 = base.position;
		tweenConfig.x = (float?)(object)1;
		float2 float7 = base.position;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0097: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.65f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 500f, 1, time);
			float2 float8 = CS_0024_003C_003E8__locals5._003C_003E4__this.position;
			Vector2 pos2 = default(Vector2);
			GM.Core.ShowDamageAt(pos2, -6f);
			GameObject obj2 = CS_0024_003C_003E8__locals5.img2.gameObject;
			UnityEngine.Object.Destroy(obj2, 0f);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void FakeRecover()
	{
		//IL_005f: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.65f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 500f, 1, time);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		GM.Core.ShowDamageAt(pos, -6f);
	}

	private unsafe void DevourEleanor()
	{
		//IL_0b7b: Expected O, but got I
		//IL_0bb0: Expected O, but got I
		//IL_0c3d: Expected O, but got I
		//IL_06b9: Expected O, but got I4
		//IL_0d25: Expected O, but got I4
		//IL_0d25: Expected I4, but got O
		//IL_084f: Expected I, but got O
		//IL_0ecb: Expected O, but got I
		//IL_10e1: Expected O, but got I4
		//IL_0f33: Expected O, but got I
		//IL_115e: Expected O, but got I4
		//IL_116c: Expected O, but got I4
		//IL_1175: Unknown result type (might be due to invalid IL or missing references)
		//IL_117a: Expected I4, but got Unknown
		//IL_1187: Expected F4, but got I4
		//IL_0f4e: Expected I, but got O
		//IL_0f64: Expected O, but got I
		//IL_0f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f72: Expected O, but got Unknown
		//IL_09c0: Expected I, but got O
		//IL_0f98: Expected O, but got I4
		//IL_0faf: Expected I, but got I8
		//IL_0fce: Expected I, but got O
		//IL_0fe4: Expected O, but got I
		//IL_0fed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff2: Expected O, but got Unknown
		//IL_09a9: Expected I, but got I8
		//IL_0a60: Expected I, but got O
		//IL_1018: Expected O, but got I4
		//IL_102f: Expected I, but got I8
		//IL_0a49: Expected I, but got I8
		//IL_0b9b->IL0d60: Incompatible stack heights: 1 vs 0
		//IL_0615->IL0d60: Incompatible stack heights: 2 vs 0
		//IL_05cf->IL0d60: Incompatible stack heights: 1 vs 0
		//IL_0bd0->IL0d60: Incompatible stack heights: 1 vs 0
		//IL_0632->IL0d60: Incompatible stack heights: 2 vs 0
		//IL_0bf8->IL0d5f: Incompatible stack heights: 1 vs 0
		//IL_0672->IL0d60: Incompatible stack heights: 2 vs 0
		//IL_0c1d->IL0d60: Incompatible stack heights: 1 vs 0
		//IL_06a1->IL0d60: Incompatible stack heights: 2 vs 0
		//IL_06d5->IL0d60: Incompatible stack heights: 2 vs 0
		//IL_0736->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_1083->IL0d60: Incompatible stack heights: 1 vs 0
		//IL_0cec->IL1066: Incompatible stack heights: 2 vs 1
		//IL_0773->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_0d42->IL0d60: Incompatible stack heights: 1 vs 0
		//IL_079d->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_0d5f->IL0d5f: Incompatible stack heights: 1 vs 0
		//IL_07c7->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_0820->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_0e75->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_0872->IL0872: Incompatible stack heights: 4 vs 3
		//IL_08c5->IL0d60: Incompatible stack heights: 3 vs 0
		//IL_1106->IL0d60: Incompatible stack heights: 4 vs 0
		//IL_090b->IL0d60: Incompatible stack heights: 4 vs 0
		//IL_0960->IL0d60: Incompatible stack heights: 5 vs 0
		//IL_0aa0->IL1042: Incompatible stack heights: 5 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Predicate<CharacterController> match = _003C_003Ec._003C_003E9__56_0;
			if (_003C_003Ec._003C_003E9__56_0 == null)
			{
				match = (_003C_003Ec._003C_003E9__56_0 = delegate(CharacterController x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj14 = x._characterType - 75;
					return obj14 == null;
				});
			}
			if (core._characters != null)
			{
				CharacterController characterController = core._characters.Find(match);
				if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._weaponsFacade != null)
				{
					Weapon weapon = core2._weaponsFacade.RemoveWeapon(WeaponType.SPELL_STRING, characterController);
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null && core3._weaponsFacade != null)
					{
						Weapon weapon2 = core3._weaponsFacade.RemoveWeapon(WeaponType.SPELL_STREAM, characterController);
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null && core4._weaponsFacade != null)
						{
							Weapon weapon3 = core4._weaponsFacade.RemoveWeapon(WeaponType.SPELL_STRIKE, characterController);
							GameManager core5 = GM.Core;
							if ((object)GM.Core != null && core5._weaponsFacade != null)
							{
								Weapon weapon4 = core5._weaponsFacade.RemoveWeapon(WeaponType.SPELL_STROM, characterController);
								List<string> list = new List<string>();
								if (list != null)
								{
									int version = list._version + 1;
									list._version = version;
									string[] items = list._items;
									if (list._items != null)
									{
										if (list._size >= items.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"2SpellString.png");
										}
										else
										{
											int num = list._size + 1;
											list._size = num;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version2 = list._version + 1;
										list._version = version2;
										string[] items2 = list._items;
										if (list._items != null)
										{
											if (list._size >= items2.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"2SpellStream.png");
											}
											else
											{
												int num2 = list._size + 1;
												list._size = num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version3 = list._version + 1;
											list._version = version3;
											string[] items3 = list._items;
											if (list._items != null)
											{
												if (list._size >= items3.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"2SpellStrike.png");
												}
												else
												{
													int num3 = list._size + 1;
													list._size = num3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version4 = list._version + 1;
												list._version = version4;
												string[] items4 = list._items;
												if (list._items != null)
												{
													if (list._size >= items4.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"2SpellStrom.png");
													}
													else
													{
														int num4 = list._size + 1;
														list._size = num4;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													float num5 = (float)Math.PI * 2f / (float)list._size;
													int num6 = 0;
													int num7 = 0;
													Vector2 vector = default(Vector2);
													object obj2 = default(object);
													string text3 = default(string);
													int num16 = default(int);
													bool flag10 = default(bool);
													bool autoSetAnimation = default(bool);
													while (true)
													{
														_003C_003Ec__DisplayClass56_0 obj;
														TweenConfig tweenConfig;
														TweenCallback tweenCallback;
														if (num7 < list._size)
														{
															obj = new _003C_003Ec__DisplayClass56_0();
															PhaserWorld instance = PhaserWorld.Instance;
															Transform cachedTrans = ((ArcadeSprite)characterController).CachedTrans;
															if ((object)cachedTrans == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v71 (UnityEngine.Transform)+10]");
															bool flag = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v71 (UnityEngine.Transform)+10]");
															float2 ret;
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
															if (characterController.body != null)
															{
																BaseBody baseBody = characterController.body;
																ArcadeTransform arcadeTransform = baseBody._transform;
																if (baseBody._transform == null)
																{
																	break;
																}
																arcadeTransform.position = ret;
															}
															bool flag2 = num6 >= list._size;
															string[] items5 = list._items;
															if (list._items == null || (object)instance == null)
															{
																break;
															}
															PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "items", items5[num6]);
															if ((object)phaserSprite == null)
															{
																break;
															}
															PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
															if ((object)phaserSprite2 == null)
															{
																break;
															}
															PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
															if ((object)phaserSprite3 == null)
															{
																break;
															}
															PhaserSprite phaserSprite4 = phaserSprite3.setDepth(9000);
															bool flag3 = num6 >= list._size;
															string[] items6 = list._items;
															if (list._items == null)
															{
																break;
															}
															string text = "Weapon (" + items6[num6] + ")";
															if ((object)phaserSprite4 == null)
															{
																break;
															}
															GameObject gameObject = phaserSprite4.gameObject;
															if ((object)gameObject == null)
															{
																break;
															}
															((UnityEngine.Object)gameObject).SetName(text);
															if (obj == null)
															{
																break;
															}
															obj.s = phaserSprite4;
															obj.index = num6;
															tweenConfig = new TweenConfig();
															object[] array = new object[1];
															if (array == null)
															{
																break;
															}
															if ((object)obj.s != null)
															{
																nint num8 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																bool flag4 = obj2 == null;
															}
															array[0] = obj.s;
															if (tweenConfig == null)
															{
																break;
															}
															tweenConfig.targets = array;
															Transform cachedTrans2 = ((ArcadeSprite)characterController).CachedTrans;
															if ((object)cachedTrans2 == null)
															{
																break;
															}
															bool flag5 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
															Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out Vector3 _);
															bool flag6 = characterController.body == null;
															Predicate<CharacterController> predicate = (Predicate<CharacterController>)(nint)((UnityEngine.Object)cachedTrans2).m_CachedPtr;
															if (!flag6)
															{
																BaseBody baseBody2 = characterController.body;
																predicate = (Predicate<CharacterController>)(object)baseBody2._transform;
																if (baseBody2._transform == null)
																{
																	break;
																}
															}
															float num9 = (float)num6 * num5;
															float num10 = num9 + 0.5f;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
															tweenConfig.x = (float?)(object)1;
															Transform cachedTrans3 = ((ArcadeSprite)characterController).CachedTrans;
															if ((object)cachedTrans3 == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v103 (UnityEngine.Transform)+10]");
															bool flag7 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v103 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out Vector3 _);
															bool flag8 = characterController.body == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v103 (UnityEngine.Transform)+10]");
															object obj3 = 0;
															if (!flag8)
															{
																BaseBody baseBody3 = characterController.body;
																obj3 = baseBody3._transform;
																if (baseBody3._transform == null)
																{
																	break;
																}
															}
															float num11 = (float)num6 * num5;
															float num12 = num11 + 0.5f;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
															tweenConfig.duration = 500f;
															tweenConfig.ease = Ease.InOutSine;
															tweenConfig.y = (float?)(object)1;
															object obj4 = num6 + 8;
															int num13 = obj4 * 100;
															tweenConfig.delay = num13;
															tweenCallback = null;
															nint num14 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2570 @ r10_v14 (Il2CppMethodInfo)+8]");
															((Delegate)tweenCallback).method_ptr = (IntPtr)0;
															((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass56_0._003CDevourEleanor_003Eb__1);
															((Delegate)tweenCallback).m_target = obj;
															((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2570 @ r10_v14 (Il2CppMethodInfo)+4C]");
															object obj5 = (nint)0 >> 4;
															object obj6 = obj5 & 1;
															nint num15;
															if (obj6 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2570 @ r10_v14 (Il2CppMethodInfo)+52]");
																if ((nint)0 == 0)
																{
																	num15 = unchecked((nint)6447293664L);
																	goto IL_0f8f;
																}
															}
															((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
															num15 = ((Delegate)tweenCallback).method_ptr;
															goto IL_0f8f;
														}
														GameManager core6 = GM.Core;
														if ((object)GM.Core == null || core6._dataManager == null)
														{
															break;
														}
														Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core6._dataManager.GetConvertedCharacterData();
														if (convertedCharacterData == null)
														{
															break;
														}
														object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)75);
														if (obj7 == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v61 (System.Object)+18]");
														bool flag9 = (nint)0 <= (nint)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v61 (System.Object)+10]");
														object obj8 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v61 (System.Object)+10]");
														if ((nint)0 == 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v16 (System.Object)+20]");
														object obj9 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v16 (System.Object)+20]");
														if ((nint)0 == 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+68]");
														if ((nint)0 > (nint)0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+48]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+48]");
															string text2 = ((string)0).Replace("01.png", "");
															string animName = "u" + text2;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+68]");
															List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 0, vector, text3, num16, flag10);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+80]");
															int fps;
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+80]");
																bool flag11 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v17 (System.Object)+80]");
																fps = (int)((nint)0 >> 32);
															}
															else
															{
																fps = 8;
															}
															if ((object)characterController._spriteAnimation == null)
															{
																break;
															}
															characterController._spriteAnimation.AddAnimation("uwalk", animationFrames, fps, (byte)(int)text3 != 0, (byte)num16 != 0, (Action)flag10, autoSetAnimation);
															if ((object)characterController._spriteAnimation == null)
															{
																break;
															}
															characterController._spriteAnimation.SetAnimation("uwalk");
														}
														return;
														IL_100f:
														object obj10 = 24;
														TweenCallback tweenCallback2;
														((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
														tweenConfig.onComplete = tweenCallback2;
														MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
														num6++;
														num7 = num6;
														continue;
														IL_0f8f:
														object obj11 = 24;
														((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
														tweenConfig.onStart = tweenCallback;
														tweenCallback2 = null;
														nint num17 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2033 @ r10_v15 (Il2CppMethodInfo)+8]");
														((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
														((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass56_0._003CDevourEleanor_003Eb__2);
														((Delegate)tweenCallback2).m_target = obj;
														((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2033 @ r10_v15 (Il2CppMethodInfo)+4C]");
														object obj12 = (nint)0 >> 4;
														object obj13 = obj12 & 1;
														nint num18;
														if (obj13 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2033 @ r10_v15 (Il2CppMethodInfo)+52]");
															if ((nint)0 == 0)
															{
																num18 = unchecked((nint)6447293664L);
																goto IL_100f;
															}
														}
														((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
														num18 = ((Delegate)tweenCallback2).method_ptr;
														goto IL_100f;
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

	private unsafe void SummonSnakes(int generic, int exploding)
	{
		//IL_0029: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		//IL_00d0: Expected O, but got Ref
		//IL_0101: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		VampireSurvivors.Data.Stage.Event obj = new VampireSurvivors.Data.Stage.Event();
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		obj._003CeventType_003Ek__BackingField = text;
		obj._003CmoreX_003Ek__BackingField = generic;
		string text2 = ((Enum)(&intPtr)).ToString();
		obj._003CmoreY_003Ek__BackingField = text2;
		obj._003CmoreZ_003Ek__BackingField = 1.5f;
		bool flag = stage._stageEventManager.TriggerEvent(obj);
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		VampireSurvivors.Data.Stage.Event obj2 = new VampireSurvivors.Data.Stage.Event();
		IntPtr intPtr2 = default(IntPtr);
		string text3 = ((Enum)(&intPtr2)).ToString();
		obj2._003CeventType_003Ek__BackingField = text3;
		obj2._003CmoreX_003Ek__BackingField = exploding;
		string text4 = ((Enum)(&intPtr2)).ToString();
		obj2._003CmoreY_003Ek__BackingField = text4;
		obj2._003CmoreZ_003Ek__BackingField = 1.5f;
		bool flag2 = stage2._stageEventManager.TriggerEvent(obj2);
	}

	private void FireOphion(float delay, float radius, int times)
	{
		_003C_003Ec__DisplayClass58_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass58_0();
		CS_0024_003C_003E8__locals8.radius = radius;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		if (!GM.Core.IsStageHost || times <= 0)
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
				onComplete = (CS_0024_003C_003E8__locals8._003C_003E9__0 = delegate
				{
					//IL_00eb: Expected O, but got F4
					//IL_014e: Expected O, but got F4
					PhaserScene s_scene = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer = s_scene._renderer;
					object obj = UnityEngine.Random.value;
					float num2 = CS_0024_003C_003E8__locals8.radius * 0.01f;
					object obj2 = default(object);
					float num3 = (float)obj2 - 0.5f;
					float num4 = num2 * num3;
					float num5 = num4 + (float)renderer.screenCenter;
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer2 = s_scene2._renderer;
					object obj3 = UnityEngine.Random.value;
					float num6 = num3 - 0.5f;
					float num7 = CS_0024_003C_003E8__locals8.radius * 0.01f;
					float num8 = num7 * num6;
					GameManager core = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v21 (PhaserScene+Renderer)+38]");
					float y = 0f - num8;
					bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
					EnemyJeneviv enemyJeneviv = CS_0024_003C_003E8__locals8._003C_003E4__this;
					float num9 = default(float);
					if (!isOnlineMultiplayer)
					{
						float duration2 = default(float);
						float hitboxDelay = default(float);
						DamagingZoneOphion damagingZoneOphion = enemyJeneviv._damagingZonePool.SpawnAt(num5, y, 64f, num9, duration2, hitboxDelay);
					}
					else
					{
						Action<float, float> action = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
						bool flag2 = enemyJeneviv._coherenceSync.SendCommand(action, MessageTarget.All, num5, num9);
					}
				});
			}
			float num = (float)(flag ? 1 : 0) * delay;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < times);
	}

	public void SpawnDamagingPool(float x, float y)
	{
		float damage = default(float);
		float duration = default(float);
		float hitboxDelay = default(float);
		DamagingZoneOphion damagingZoneOphion = _damagingZonePool.SpawnAt(x, y, 64f, damage, duration, hitboxDelay);
	}

	public EnemyJeneviv()
	{
		List<EquipmentInfo> playerEquipment = new List<EquipmentInfo>();
		_playerEquipment = playerEquipment;
		_rays = new List<PhaserSprite>();
		base._002Ector();
	}

	private void _003CInitEnemy_003Eb__33_0()
	{
		float hp = _hp - _shieldDamage;
		_hasShield = false;
		_hp = hp;
	}

	private void _003CInitEnemy_003Eb__33_1()
	{
		PhaserSprite phaserSprite = _breakFreeSprite.setVisible(visible: false);
	}

	private void _003CRestoreShield_003Eb__34_0()
	{
		float hp = _hp - _shieldDamage;
		_hasShield = false;
		_hp = hp;
	}

	private void _003CStartVerySmartAI_003Eb__45_0()
	{
		SummonSnakes(6, 6);
	}

	private void _003CStartVerySmartAI_003Eb__45_1()
	{
		//IL_000e: Expected O, but got F4
		//IL_0062: Expected O, but got F4
		//IL_003c: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * 60f;
		float delay = num + 60f;
		object obj3 = UnityEngine.Random.value;
		float num2 = (float)obj2 * 200f;
		float radius = num2 + 100f;
		object obj4 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm0\"");
		int times = default(int);
		FireOphion(delay, radius, times);
	}

	private unsafe void _003CDie_003Eb__49_0()
	{
		//IL_03b3: Expected O, but got I
		//IL_0416: Expected O, but got I
		//IL_07d9: Expected O, but got I
		//IL_0489: Expected O, but got I
		//IL_0808: Expected O, but got I
		//IL_04fd: Expected O, but got I
		//IL_0583: Expected O, but got I
		//IL_05dd: Expected O, but got I
		//IL_01fc: Expected O, but got Ref
		//IL_05c2: Expected O, but got I4
		//IL_0830: Expected O, but got I
		//IL_0647: Expected O, but got I
		//IL_062c: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A628D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_SpriteAnimation.SetAnimation("die");
		if (_specialDeath)
		{
			GameManager core = GM.Core;
			core._WhiteHandManager.SummonWhiteHand();
			GameManager core2 = GM.Core;
			Stage stage = core2._stage;
			StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
			bool flag = (object)stageModifiers._003CTimeLimit_003Ek__BackingField == null;
			float num = 1800f;
			if (!flag)
			{
				if ((object)stageModifiers._003CTimeLimit_003Ek__BackingField == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw new NullReferenceException();
				}
				float num2 = default(float);
				num = num2;
			}
			GameManager core3 = GM.Core;
			float num3 = num + 60f;
			if (num3 > core3._003CSurvivedSeconds_003Ek__BackingField)
			{
				float num4 = num + 60f;
				core3._003CSurvivedSeconds_003Ek__BackingField = num4;
			}
			ProCamera2D instance = ProCamera2D.Instance;
			instance.RemoveCameraTarget(_cachedTransform, 0.2f);
			_gameManager.AddAllPlayersAsCameraTargets(0.2f);
			_gameManager.SetPlayerWorldBoundCollision(on: false);
			Action onComplete = RemovePlayerWeapons;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			GameManager gameManager = _gameManager;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				ArrayTypeMismatchException ex = (ArrayTypeMismatchException)(&enumerator);
				throw new NullReferenceException();
			}
			return;
		}
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		list._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v20+18]");
		float item = default(float);
		if (num5 >= 0)
		{
			list.AddWithResize(10f);
			item = 10f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1092616192;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v21+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(30f);
			item = 30f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1106247680;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v22+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(100f);
			item = 100f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1120403456;
		}
		treasure._003Cchances_003Ek__BackingField = list;
		List<PrizeType?> list2 = new List<PrizeType?>();
		((List<float>)(object)list2).Add(item);
		((List<float>)(object)list2).Add(item);
		((List<float>)(object)list2).Add(item);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v28+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v30+18]");
		if (num9 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		GameManager core4 = GM.Core;
		int num10 = core4._stage.SetTreasureLevelFromChance(treasure);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
	}

	private void _003CDeathScream_003Eb__51_0()
	{
		if ((object)_ringSprite != null)
		{
			Transform transform = _ringSprite.transform;
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				bool flag4 = (object)_ringSprite == null;
				PhaserSprite phaserSprite = _ringSprite.setVisible(visible: true);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CDeathScream_003Eb__51_1()
	{
		PhaserSprite phaserSprite = _ringSprite.setVisible(visible: false);
	}

	private void _003CPlayWorldEater_003Eb__53_0()
	{
		//IL_0066: Expected O, but got I4
		ScreenShake();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 0f, 10, time);
		PhaserSprite phaserSprite = _worldEaterImage.setFrame("2Skull2", "vfx");
	}

	private void _003CPlayWorldEater_003Eb__53_1()
	{
		PhaserSprite phaserSprite = _worldEaterImage.setAlpha(1f);
	}
}
