using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects;

public class WorldEaterVFX
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__18_0;

		public static TweenCallback _003C_003E9__18_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__18_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__18_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public PhaserSprite r;

		internal void _003CCastSoulSteal_003Eb__0()
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite = r.setAlpha(1f);
			PhaserSprite phaserSprite2 = r.setScale(0f, (float?)(object)0);
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public WorldEaterVFX _003C_003E4__this;

		public bool isCursed;

		public Action callback;

		internal void _003CPlayWorldEater_003Eb__0()
		{
			//IL_0042: Expected O, but got I4
			_003C_003E4__this.DoSoulSteal(isCursed);
			_003C_003E4__this.ScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.5f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 0f, 10, time);
			WorldEaterVFX worldEaterVFX = _003C_003E4__this;
			PhaserSprite phaserSprite = worldEaterVFX._worldEaterImage.setFrame("2Skull2", "vfx");
			if (callback != null)
			{
				Action action = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v194.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CPlayWorldEater_003Eb__1()
		{
			WorldEaterVFX worldEaterVFX = _003C_003E4__this;
			PhaserSprite phaserSprite = worldEaterVFX._worldEaterImage.setAlpha(1f);
		}

		internal void _003CPlayWorldEater_003Eb__2()
		{
			WorldEaterVFX worldEaterVFX = _003C_003E4__this;
			worldEaterVFX._isPlayingWorldEaterVfx = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public WorldEaterVFX _003C_003E4__this;

		public bool isCursed;
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public float2 enemyPos;

		public ItemType pickupType;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CDoSoulSteal_003Eb__0()
		{
			//IL_0100: Expected F4, but got I4
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			Pickup pickup = GM.Core.MakePickup(pos, pickupType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			pickup.GoToPlayer = true;
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			WorldEaterVFX worldEaterVFX = obj._003C_003E4__this;
			pickup._targetPlayer = worldEaterVFX._Owner;
			pickup.Time = 1f;
			_003C_003Ec__DisplayClass17_0 obj2 = CS_0024_003C_003E8__locals1;
			int num;
			if (obj2.isCursed)
			{
				WorldEaterVFX worldEaterVFX2 = obj2._003C_003E4__this;
				num = worldEaterVFX2.TriggeredTimes;
			}
			else
			{
				num = 1;
			}
			pickup._003CValue_003Ek__BackingField = num;
		}
	}

	private PhaserSprite _sprite1;

	private MultiTargetTween _tween1;

	private PhaserSprite _faderImage;

	private MultiTargetTween _worldEaterTween1;

	private MultiTargetTween _worldEaterTween2;

	private MultiTargetTween _worldEaterTween3;

	private bool _isPlayingWorldEaterVfx;

	private PhaserSprite _worldEaterImage;

	private ParticleEmitterManager _pfxEmitter;

	private ParticleSystem _ppp;

	private List<PhaserSprite> _rays;

	private MultiTargetTween _raysTween;

	private VampireSurvivors.Objects.Characters.CharacterController _Owner;

	public int TriggeredTimes;

	public WorldEaterVFX(VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		//IL_00bb: Expected O, but got I4
		//IL_01a5: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_0234: Expected O, but got I4
		//IL_02ab: Expected O, but got I4
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		_Owner = owner;
		TriggeredTimes = 0;
		if ((object)GM.Core != null && (object)GM.Core != null)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite worldEaterImage = instance.AddPhaserSprite(pos, "vfx", "2Skull1");
			_worldEaterImage = worldEaterImage;
			PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(_worldEaterImage, 0f);
			PhaserSprite phaserSprite2 = _worldEaterImage.setOrigin(0.5f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _worldEaterImage.setAlpha(0f);
			PhaserSprite phaserSprite4 = _worldEaterImage.setDepth(10000);
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite component = instance2.AddPhaserSprite(pos, "vfx", "blackDot");
			PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component, 0f);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				if ((object)GM.Core != null)
				{
					PhaserSprite phaserSprite6 = phaserSprite5.setScale(renderer.width, (float?)(object)1);
					PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
					PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(0f, (float?)(object)0);
					PhaserSprite faderImage = phaserSprite8.setDepth(9999);
					_faderImage = faderImage;
					_isPlayingWorldEaterVfx = false;
					List<PhaserSprite> rays = new List<PhaserSprite>();
					_rays = rays;
					float? num = (float?)(object)0;
					while (true)
					{
						PhaserWorld instance3 = PhaserWorld.Instance;
						if ((object)GM.Core == null || (object)GM.Core == null)
						{
							break;
						}
						PhaserSprite phaserSprite9 = instance3.AddPhaserSprite(pos, "vfx", "RayRay");
						PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(1f);
						PhaserSprite component2 = phaserSprite10.setScale(0f, (float?)(object)0);
						PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor(component2, 0f);
						PhaserSprite phaserSprite12 = phaserSprite11.setBlendMode(BlendMode.Add);
						PhaserSprite item = phaserSprite12.setDepth(9998);
						List<object> rays2 = (List<object>)(object)_rays;
						int version = rays2._version + 1;
						rays2._version = version;
						object[] items = rays2._items;
						if (rays2._size >= items.Length)
						{
							rays2.AddWithResize((object)item);
						}
						else
						{
							int size = rays2._size + 1;
							rays2._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						num = (float?)(object)((_003F?)num + 1);
						if ((nint)num >= 13)
						{
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void CastSoulSteal(Action callback = null, bool isCursed = false)
	{
		//IL_002b: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0410: Expected O, but got F4
		//IL_00d0: Expected O, but got Ref
		//IL_0161: Expected I, but got O
		//IL_01c4: Expected O, but got I4
		//IL_02d7: Expected O, but got I4
		//IL_02f7: Expected O, but got I
		//IL_0422: Expected I, but got O
		//IL_0438: Expected O, but got I
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_0379: Expected I, but got O
		//IL_0483: Expected I, but got I8
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_0362: Expected I, but got I8
		//IL_0184->IL0184: Incompatible stack heights: 3 vs 2
		//IL_03d9->IL0495: Incompatible stack heights: 3 vs 0
		if (!_isPlayingWorldEaterVfx)
		{
			PlayWorldEater(callback, isCursed);
			List<PhaserSprite> rays = _rays;
			object obj = 0;
			object obj2 = 0;
			bool flag5;
			TweenCallback tweenCallback;
			TweenConfig tweenConfig;
			MultiTargetTween worldEaterTween;
			object obj6 = default(object);
			object obj10 = default(object);
			object obj7 = default(object);
			for (object obj3 = 0; (nint)obj3 < rays._size; flag5 = true, ((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L), tweenConfig.onStart = tweenCallback, worldEaterTween = Tweens.Add(tweenConfig), _worldEaterTween1 = worldEaterTween, rays = _rays, obj++, obj6 = obj10, obj3 = obj)
			{
				_003C_003Ec__DisplayClass15_0 obj4 = new _003C_003Ec__DisplayClass15_0();
				List<PhaserSprite> rays2 = _rays;
				bool flag = (nint)obj >= rays2._size;
				PhaserSprite[] items = rays2._items;
				obj4.r = items[obj];
				object obj5 = UnityEngine.Random.value;
				Transform transform = obj4.r.transform;
				transform.localEulerAngles = (Vector3)(&obj6);
				tweenConfig = new TweenConfig();
				object[] array = new object[1];
				List<PhaserSprite> rays3 = _rays;
				bool flag2 = (nint)obj >= rays3._size;
				PhaserSprite[] items2 = rays3._items;
				if ((object)items2[obj] != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag3 = obj7 == null;
				}
				array[0] = items2[obj];
				tweenConfig.targets = array;
				tweenConfig.alpha = (float?)(object)1;
				Func<int, float> staggerScale = Tweens.Stagger(0.2f, new StaggerConfig
				{
					ease = Ease.Linear,
					start = 2f
				});
				tweenConfig.staggerScale = staggerScale;
				Func<int, float> staggerDuration = Tweens.Stagger(20f, new StaggerConfig
				{
					ease = Ease.Linear,
					start = 300f
				});
				tweenConfig.staggerDuration = staggerDuration;
				List<PhaserSprite> rays4 = _rays;
				bool flag4 = (nint)obj >= rays4._size;
				PhaserSprite[] items3 = rays4._items;
				Transform transform2 = items3[obj].transform;
				Vector3 localEulerAngles = transform2.localEulerAngles;
				tweenConfig.angle = (float?)(object)1;
				tweenCallback = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r10_v7 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass15_0._003CCastSoulSteal_003Eb__0);
				((Delegate)tweenCallback).m_target = obj4;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r10_v7 (Il2CppMethodInfo)+4C]");
				object obj8 = (nint)0 >> 4;
				object obj9 = obj8 & 1;
				nint num3;
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r10_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num3 = unchecked((nint)6447293664L);
						continue;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num3 = ((Delegate)tweenCallback).method_ptr;
			}
		}
		else
		{
			DoSoulSteal(isCursed);
		}
	}

	public void PlayWorldEater(Action callback = null, bool isCursed = false)
	{
		//IL_0066: Expected O, but got I4
		//IL_00a5: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_01c0: Expected I, but got O
		//IL_0224: Expected O, but got I4
		//IL_0232: Expected O, but got I4
		//IL_02f6: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_0457: Expected I, but got O
		//IL_04c9: Expected O, but got I4
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		CS_0024_003C_003E8__locals11.isCursed = isCursed;
		CS_0024_003C_003E8__locals11.callback = callback;
		if (_isPlayingWorldEaterVfx)
		{
			return;
		}
		_isPlayingWorldEaterVfx = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.WorldEater, soundConfig, 0f, 10, time);
		PhaserSprite phaserSprite = _worldEaterImage.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _worldEaterImage.setAlpha(0f);
		PhaserSprite phaserSprite3 = _worldEaterImage.setFrame("2Skull1", "vfx");
		if ((object)GM.Core == null)
		{
			throw new NullReferenceException();
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = num + renderer.pixelHeight;
		object obj2 = obj >> 8;
		if (_worldEaterTween1 != null)
		{
			_worldEaterTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_worldEaterImage != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0042: Expected O, but got I4
			CS_0024_003C_003E8__locals11._003C_003E4__this.DoSoulSteal(CS_0024_003C_003E8__locals11.isCursed);
			CS_0024_003C_003E8__locals11._003C_003E4__this.ScreenShake();
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 0.5f;
			float time2 = default(float);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Attack2, soundConfig2, 0f, 10, time2);
			WorldEaterVFX worldEaterVFX = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite4 = worldEaterVFX._worldEaterImage.setFrame("2Skull2", "vfx");
			if (CS_0024_003C_003E8__locals11.callback != null)
			{
				Action callback2 = CS_0024_003C_003E8__locals11.callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v194.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
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
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
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
			WorldEaterVFX worldEaterVFX = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite4 = worldEaterVFX._worldEaterImage.setAlpha(1f);
		};
		tweenConfig2.onStart = onStart;
		TweenCallback onComplete2 = delegate
		{
			WorldEaterVFX worldEaterVFX = CS_0024_003C_003E8__locals11._003C_003E4__this;
			worldEaterVFX._isPlayingWorldEaterVfx = false;
		};
		tweenConfig2.onComplete = onComplete2;
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
			nint num4 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
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

	public unsafe void DoSoulSteal(bool isCursed = false)
	{
		//IL_006e: Expected O, but got I4
		//IL_0077: Expected F4, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0312: Expected O, but got F4
		//IL_0152: Invalid comparison between F4 and I4
		//IL_013f: Expected O, but got F4
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_01dc: Expected F4, but got I
		//IL_01fc: Expected O, but got I4
		//IL_034c: Expected I, but got O
		//IL_0213: Expected O, but got I4
		//IL_0241->IL02e1: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj._003C_003E4__this = this;
		obj.isCursed = isCursed;
		int triggeredTimes = TriggeredTimes + 1;
		TriggeredTimes = triggeredTimes;
		GameManager core = GM.Core;
		List<EnemyController> allEnemiesInScreenBounds = core._stage.GetAllEnemiesInScreenBounds(0f);
		object obj2 = 0;
		float num = 0f;
		float num3 = default(float);
		float num4 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		for (object obj3 = 0; (nint)obj3 < allEnemiesInScreenBounds._size; obj2++, obj3 = obj2)
		{
			_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass17_1();
			CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
			bool flag = (nint)obj2 >= allEnemiesInScreenBounds._size;
			EnemyController[] items = allEnemiesInScreenBounds._items;
			ArcadeSprite arcadeSprite = items[obj2];
			Transform cachedTrans = ((ArcadeSprite)items[obj2]).CachedTrans;
			bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite.body != null)
			{
				BaseBody body = arcadeSprite.body;
				ArcadeTransform transform = body._transform;
				transform.position = (float2)ret;
			}
			CS_0024_003C_003E8__locals8.enemyPos = (float2)ret;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rbx_v8 (ArcadeSprite)+20C]");
			bool flag3 = (nint)0 == 0;
			float num2 = num3;
			float num5;
			if (!flag3)
			{
				bool flag4 = num4 > 0f;
				num2 = num4;
				num5 = num4;
				num = ret;
				if (flag4)
				{
					continue;
				}
			}
			_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
			bool flag5 = obj4.isCursed;
			ItemType pickupType = ItemType.BONUS_CURSEDSOUL;
			if (!flag5)
			{
				pickupType = ItemType.LITTLEHEART;
			}
			CS_0024_003C_003E8__locals8.pickupType = pickupType;
			_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rbx_v8 (ArcadeSprite)+1EC]");
			num = 0f;
			bool flag6 = obj5.isCursed;
			object obj6 = 5;
			if (!flag6)
			{
				obj6 = 10;
			}
			if (66f > num)
			{
				num = 66f;
			}
			nint num6 = (nint)arcadeSprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v809 @ rdx_v12 (Il2CppClass<ArcadeSprite>)+3E8] (should have been resolved before IL gen)");
			Action onComplete = delegate
			{
				//IL_0100: Expected F4, but got I4
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool shouldCallValidatePickups = default(bool);
				bool isRemote = default(bool);
				Pickup pickup = GM.Core.MakePickup(pos, CS_0024_003C_003E8__locals8.pickupType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
				pickup.GoToPlayer = true;
				_003C_003Ec__DisplayClass17_0 obj8 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
				WorldEaterVFX worldEaterVFX = obj8._003C_003E4__this;
				pickup._targetPlayer = worldEaterVFX._Owner;
				pickup.Time = 1f;
				_003C_003Ec__DisplayClass17_0 obj9 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
				int num7;
				if (obj9.isCursed)
				{
					WorldEaterVFX worldEaterVFX2 = obj9._003C_003E4__this;
					num7 = worldEaterVFX2.TriggeredTimes;
				}
				else
				{
					num7 = 1;
				}
				pickup._003CValue_003Ek__BackingField = num7;
			};
			object obj7 = obj6 * obj2;
			num5 = (float)obj7 * 0.001f;
			Timer timer = Timers.Register(num5, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public void ScreenShake()
	{
		//IL_00b3: Expected I, but got O
		//IL_0133: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
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
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__18_0;
		if (_003C_003Ec._003C_003E9__18_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__18_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__18_1;
		if (_003C_003Ec._003C_003E9__18_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__18_1 = delegate
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
}
