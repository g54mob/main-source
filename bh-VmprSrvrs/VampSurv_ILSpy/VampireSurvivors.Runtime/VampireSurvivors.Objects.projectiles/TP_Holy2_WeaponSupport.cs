using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Holy2_WeaponSupport : MonoBehaviour
{
	private Transform _pivotTransform;

	private Transform _meshTransform;

	private MeshRenderer _mesh;

	private static readonly int _InputColor;

	private static readonly int _AlphaMul;

	private Tween rotTween;

	private Sequence _windSequence;

	private Timer sanct1Timer;

	private Timer sanct2Timer;

	private bool canTrigger;

	private Timer retriggerTimer;

	private ParticleSystem _glitchEmitter;

	private Timer sanct3Timer;

	private TP_Holy2_Weapon _trueWeapon;

	public unsafe void Initialize()
	{
		//IL_0303: Expected O, but got F4
		//IL_03ea: Expected O, but got Ref
		//IL_01cc: Expected O, but got Ref
		Camera main = Camera.main;
		Transform transform = base.transform;
		Camera main2 = Camera.main;
		if ((object)main2 != null)
		{
			Transform parent = main2.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = base.transform;
				if ((object)main != null)
				{
					if (((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(main);
					}
					else
					{
						object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
						if ((object)transform2 != null)
						{
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
							if (rotTween != null)
							{
								TweenExtensions.Kill(rotTween);
							}
							Camera meshTransform = (Camera)(object)_meshTransform;
							Vector3 fromDirection = default(Vector3);
							Vector3 toDirection = default(Vector3);
							Quaternion.FromToRotation_Injected(ref fromDirection, ref toDirection, out Quaternion ret);
							bool flag2 = (object)_meshTransform == null;
							bool flag3 = ((UnityEngine.Object)meshTransform).m_CachedPtr == (IntPtr)0;
							Quaternion value2 = default(Quaternion);
							Transform.set_rotation_Injected(((UnityEngine.Object)meshTransform).m_CachedPtr, ref value2);
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(_meshTransform, (Vector3)(&fromDirection), 1f, RotateMode.FastBeyond360);
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 4294967295L;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
										if ((nint)0 == 0)
										{
											_ = 2139095040;
										}
									}
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							bool flag4 = tweenerCore == null;
							rotTween = tweenerCore;
							Camera pivotTransform = (Camera)(object)_pivotTransform;
							canTrigger = true;
							bool flag5 = (object)_pivotTransform == null;
							bool flag6 = ((UnityEngine.Object)pivotTransform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)pivotTransform).m_CachedPtr, ref value);
							bool flag7 = (object)_mesh == null;
							Material material = ((Renderer)_mesh).GetMaterial();
							bool flag8 = (object)material == null;
							material.SetVector(_InputColor, (Vector4)(&ret));
							bool flag9 = (object)_mesh == null;
							Material material2 = ((Renderer)_mesh).GetMaterial();
							bool flag10 = (object)material2 == null;
							material2.SetFloatImpl(_AlphaMul, 0.35f);
							MakeEmitters();
							bool flag11 = (object)_glitchEmitter == null;
							_glitchEmitter.Stop();
							GameObject gameObject = base.gameObject;
							bool flag12 = (object)gameObject == null;
							TP_Holy2_Weapon component = gameObject.GetComponent<TP_Holy2_Weapon>();
							_trueWeapon = component;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void Trigger()
	{
		//IL_0908: Expected O, but got Ref
		//IL_094b: Expected O, but got Ref
		if (!canTrigger)
		{
			return;
		}
		if (retriggerTimer != null)
		{
			retriggerTimer.Cancel();
		}
		Action onComplete = delegate
		{
			canTrigger = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		retriggerTimer = timer;
		Tween windSequence = _windSequence;
		canTrigger = false;
		if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_windSequence);
		}
		Sequence sequence = DOTween.Sequence();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
		_windSequence = sequence;
		Sequence windSequence2 = _windSequence;
		Material material = ((Renderer)_mesh).GetMaterial();
		TweenerCore<float, float, FloatOptions> t = ShortcutExtensions.DOFloat(material, 1f, _AlphaMul, 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(_windSequence, (Tween)t, ((Tween)windSequence2).duration);
		}
		Sequence windSequence3 = _windSequence;
		Material material2 = ((Renderer)_mesh).GetMaterial();
		Vector4 vector = default(Vector4);
		TweenerCore<Vector4, Vector4, VectorOptions> t2 = ShortcutExtensions.DOVector(material2, (Vector4)(&vector), _InputColor, 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(_windSequence, (Tween)t2, windSequence3.lastTweenInsertTime);
		}
		Sequence windSequence4 = _windSequence;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleY(_pivotTransform, 200f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = CastComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)tweenerCore, false))
		{
			Sequence sequence4 = Sequence.DoInsert(_windSequence, (Tween)tweenerCore, windSequence4.lastTweenInsertTime);
		}
		Sequence windSequence5 = _windSequence;
		Material material3 = ((Renderer)_mesh).GetMaterial();
		TweenerCore<float, float, FloatOptions> t3 = ShortcutExtensions.DOFloat(material3, 0.65f, _AlphaMul, 0.3f);
		TweenerCore<float, float, FloatOptions> t4 = TweenSettingsExtensions.SetDelay(t3, 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t4, false))
		{
			Sequence sequence5 = Sequence.DoInsert(_windSequence, (Tween)t4, ((Tween)windSequence5).duration);
		}
		Sequence windSequence6 = _windSequence;
		Material material4 = ((Renderer)_mesh).GetMaterial();
		TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore2 = ShortcutExtensions.DOVector(material4, (Vector4)(&vector), _InputColor, 0.2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1597 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)tweenerCore2, false))
		{
			Sequence sequence6 = Sequence.DoInsert(_windSequence, (Tween)tweenerCore2, windSequence6.lastTweenInsertTime);
		}
		Sequence windSequence7 = _windSequence;
		Material material5 = ((Renderer)_mesh).GetMaterial();
		TweenerCore<float, float, FloatOptions> t5 = ShortcutExtensions.DOFloat(material5, 0.05f, _AlphaMul, 2f);
		TweenerCore<float, float, FloatOptions> t6 = TweenSettingsExtensions.SetDelay(t5, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t6, false))
		{
			Sequence sequence7 = Sequence.DoInsert(_windSequence, (Tween)t6, ((Tween)windSequence7).duration);
		}
		Sequence windSequence8 = _windSequence;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScaleY(_pivotTransform, 20f, 2f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1900 @ rax_v66 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)tweenerCore3, false))
		{
			Sequence sequence8 = Sequence.DoInsert(_windSequence, (Tween)tweenerCore3, windSequence8.lastTweenInsertTime);
		}
		Sequence windSequence9 = _windSequence;
		Material material6 = ((Renderer)_mesh).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore4 = ShortcutExtensions.DOFloat(material6, 0.35f, _AlphaMul, 2f);
		if (tweenerCore4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2092 @ rax_v74 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)tweenerCore4, false))
		{
			Sequence sequence9 = Sequence.DoInsert(_windSequence, (Tween)tweenerCore4, ((Tween)windSequence9).duration);
		}
	}

	private void CastComplete()
	{
		RenderingExtensions.Start(_glitchEmitter);
		DoSanctuaryEffect();
		if (sanct1Timer != null)
		{
			sanct1Timer.Cancel();
		}
		Action onComplete = DoSanctuaryEffect;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		sanct1Timer = timer;
		if (sanct2Timer != null)
		{
			sanct2Timer.Cancel();
		}
		Action onComplete2 = delegate
		{
			DoSanctuaryEffect();
		};
		Timer timer2 = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		sanct2Timer = timer2;
		if (sanct3Timer != null)
		{
			sanct3Timer.Cancel();
		}
		Action onComplete3 = delegate
		{
			_glitchEmitter.Stop();
		};
		Timer timer3 = Timers.Register(1.5000001f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		sanct3Timer = timer3;
	}

	private unsafe void DoSanctuaryEffect()
	{
		//IL_00f3: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0078: Expected O, but got Ref
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Recovery, soundConfig, 500f, 1, time);
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator2.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator4 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator2);
			throw new NullReferenceException();
		}
		RosaryDamage();
	}

	private void RosaryDamage()
	{
		//IL_0081: Expected O, but got I4
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03ca: Expected O, but got I4
		//IL_0140: Expected F4, but got I4
		//IL_01b4: Invalid comparison between F4 and O
		//IL_0169: Expected F4, but got I4
		//IL_03f2: Expected I, but got O
		//IL_01e7: Invalid comparison between O and F4
		//IL_027c: Expected O, but got I4
		//IL_02a9: Expected F4, but got I
		//IL_02ba: Invalid comparison between F4 and I
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (flag)
		{
			return;
		}
		Rect rect = default(Rect);
		Rect rect3 = default(Rect);
		object obj2 = default(object);
		while (true)
		{
			List<EnemyController> spawnedEnemies2 = stage._spawnedEnemies;
			if ((nint)obj >= spawnedEnemies2._size)
			{
				break;
			}
			EnemyController[] items = spawnedEnemies2._items;
			Component component = items[obj];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v8 (UnityEngine.Component)+260]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v8 (UnityEngine.Component)+260]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v8 (UnityEngine.Component)+20C]");
				bool flag3 = (nint)0 == 0;
				float num = 0f;
				if (!flag3)
				{
					bool flag4 = (nint)rect <= 0;
					num = 0f;
					Rect rect2 = rect;
					if (!flag4)
					{
						num = 66f;
						rect2 = rect;
					}
				}
				Transform transform = component.transform;
				Vector3 position = transform.position;
				float x = position.x;
				Rect containmentScreenRect = stage._containmentScreenRect;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect))
				{
					Rect rect2 = (Rect)((object)rect3 + (object)stage._containmentScreenRect);
					if (System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)position.x))
					{
						bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect3);
						rect2 = rect3;
						if (!flag5)
						{
							rect2 = (Rect)((object)rect3 + (object)rect3);
							bool flag6 = System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
							object obj3 = (object)rect2 - obj2;
							bool flag7 = obj3 == null;
							bool flag8 = !flag6;
							bool flag9 = !flag7;
							object obj4 = flag9 & flag8;
							if (obj4 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v8 (UnityEngine.Component)+1EC]");
								num = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v8 (UnityEngine.Component)+1EC]");
								if (66f > 0f)
								{
									num = 66f;
								}
							}
						}
					}
				}
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v436 @ rdx_v6 (Il2CppMethodInfo)+3E8] (should have been resolved before IL gen)");
				TP_Holy2_Weapon trueWeapon = _trueWeapon;
				flag2 = (nint)_trueWeapon < 0;
				if ((object)_trueWeapon != null)
				{
					flag2 = (nint)((UnityEngine.Object)trueWeapon).m_CachedPtr < 0;
					if (((UnityEngine.Object)trueWeapon).m_CachedPtr != (IntPtr)0)
					{
						TP_Holy2_Weapon trueWeapon2 = _trueWeapon;
						flag2 = (nint)_trueWeapon < 0;
						float num3 = num + ((Weapon)trueWeapon2)._003CStatsInflictedDamage_003Ek__BackingField;
						((Weapon)trueWeapon2)._003CStatsInflictedDamage_003Ek__BackingField = num3;
					}
				}
			}
			obj--;
			object obj5 = !flag2;
			if (obj5 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e7: Expected O, but got I4
		//IL_020e: Expected O, but got I4
		//IL_0235: Expected O, but got I4
		//IL_024e: Expected O, but got Ref
		//IL_0275: Expected O, but got I
		//IL_028f: Expected native int or pointer, but got O
		//IL_02a9: Expected O, but got I
		//IL_02c9: Expected O, but got Ref
		//IL_02f0: Expected O, but got I
		//IL_030a: Expected native int or pointer, but got O
		//IL_052b: Expected O, but got I4
		//IL_0322: Expected O, but got Ref
		//IL_033c: Expected native int or pointer, but got O
		//IL_055d: Expected O, but got I
		//IL_0374: Expected O, but got Ref
		//IL_038e: Expected native int or pointer, but got O
		//IL_0597: Expected O, but got I
		//IL_0408: Expected O, but got I
		//IL_0614: Expected O, but got I
		//IL_064a: Expected O, but got Ref
		//IL_04d1->IL063c: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Rectangle rectangle = new Rectangle();
					float num = renderer.screenWidth * 0.5f;
					rectangle._width = renderer.screenWidth;
					float x = num ^ -0f;
					rectangle._y = 0f;
					rectangle._x = x;
					rectangle._height = -4f;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
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
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_HolyGradient");
							}
							else
							{
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
								particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
								particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
								_ = 0;
								_ = 1;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
								particleSystemConfig._blendMode = (BlendMode?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f, 500f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
								_ = 0;
								_ = 8;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.33f, 0f));
								particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(2f, 4f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
								particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.65f, 0.15f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
								_ = 0;
								EmitZone emitZone = new EmitZone();
								emitZone._type = EmitZoneType.Random;
								emitZone._source = rectangle;
								particleSystemConfig._emitZone = emitZone;
								_ = 0;
								_ = 1120403456;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
								particleSystemConfig._frequency = (float?)(object)0;
								particleSystemConfig._on = true;
								Camera main = Camera.main;
								Transform parent = main.transform;
								ParticleSystem glitchEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "sanctuaryEmitter");
								_glitchEmitter = glitchEmitter;
								Transform transform = _glitchEmitter.transform;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								RenderingExtensions.SetDepth(_glitchEmitter, 3000);
								_ = _glitchEmitter;
								_ = _glitchEmitter;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									bool flag2 = obj3 == null;
								}
								object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1769 @ rax_v66 (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetVisible(bool visible)
	{
		_mesh.enabled = visible;
	}

	public TP_Holy2_WeaponSupport()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static TP_Holy2_WeaponSupport()
	{
		int inputColor = Shader.PropertyToID("_InputColor");
		_InputColor = inputColor;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003CTrigger_003Eb__15_0()
	{
		canTrigger = true;
	}

	private void _003CCastComplete_003Eb__16_0()
	{
		DoSanctuaryEffect();
	}

	private void _003CCastComplete_003Eb__16_1()
	{
		_glitchEmitter.Stop();
	}
}
