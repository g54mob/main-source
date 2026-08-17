using System;
using System.Collections.Generic;
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
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Frog_Projectile : Projectile
{
	private SpriteTrail _SpriteTrail;

	private const float Radius = 10f;

	private readonly Vector2 SquashedScale;

	private TP_Frog_Weapon _trueWeapon;

	protected PhaserSprite _frogSprite;

	private List<Vector3> _frogSpritePositions;

	private Vector2 _nextJumpPos;

	private float _cachedWeaponArea;

	private Timer _moveTimer;

	private Timer _expireTimer;

	private Tween _posTween;

	private MultiTargetTween _posTween2;

	protected MultiTargetTween _scaleTween;

	protected override void Awake()
	{
		//IL_0194: Expected O, but got I4
		//IL_0194: Expected I4, but got O
		//IL_01fc: Expected O, but got I4
		//IL_01fc: Expected I4, but got O
		//IL_0264: Expected O, but got I4
		//IL_0264: Expected I4, but got O
		//IL_02cc: Expected O, but got I4
		//IL_02cc: Expected I4, but got O
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A159D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Frog_Green01");
			GameObject gameObject2 = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_frogSprite");
			_frogSprite = phaserSprite;
			string text = default(string);
			int num = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Frog_Green", 1, 14, vector, text, num, flag);
			PhaserSprite frogSprite = _frogSprite;
			bool autoSetAnimation = default(bool);
			frogSprite._spriteAnimation.AddAnimation("idle", animationFrames, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Frog_Green_Jump", 1, 3, vector, text, num, flag);
			PhaserSprite frogSprite2 = _frogSprite;
			frogSprite2._spriteAnimation.AddAnimation("jump", animationFrames2, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_Frog_Purple", 1, 14, vector, text, num, flag);
			PhaserSprite frogSprite3 = _frogSprite;
			frogSprite3._spriteAnimation.AddAnimation("idle_counter", animationFrames3, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_Frog_Purple_Jump", 1, 3, vector, text, num, flag);
			PhaserSprite frogSprite4 = _frogSprite;
			frogSprite4._spriteAnimation.AddAnimation("jump_counter", animationFrames4, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			SpriteTrail spriteTrail = _SpriteTrail;
			if ((object)_SpriteTrail != null && ((UnityEngine.Object)spriteTrail).m_CachedPtr != (IntPtr)0)
			{
				Transform transform = _SpriteTrail.transform;
				Transform parent = _frogSprite.transform;
				transform.SetParent(parent, worldPositionStays: true);
			}
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002b: Expected I, but got O
		//IL_0033: Expected I4, but got O
		//IL_0043: Expected O, but got I
		//IL_00c3: Expected O, but got I4
		//IL_007f: Expected O, but got I
		//IL_023b: Expected O, but got I4
		//IL_00d2: Expected I4, but got O
		//IL_00b5: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag;
		if ((object)_weapon == null)
		{
			flag = false;
			goto IL_0231;
		}
		nint num = (nint)typeof(TP_Frog_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v7 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v7 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v37+FFFFFFF8+v68 @ rax_v32*8]");
			if (0 == (nint)typeof(TP_Frog_Weapon))
			{
				obj3 = 1;
				goto IL_0240;
			}
		}
		obj3 = 0;
		goto IL_0240;
		IL_0240:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)_weapon != 0;
		}
		goto IL_0231;
		IL_0231:
		_trueWeapon = (TP_Frog_Weapon)flag;
		float num4 = _weapon.PArea();
		float num5 = default(float);
		_cachedWeaponArea = num5;
		_isCullable = false;
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		InitSpriteTrail();
		PlaySfx();
		ScaleIn();
		float num6 = _weapon.PDuration();
		float num7 = num5 + num5;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float duration = num7 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private unsafe void InitSpriteTrail()
	{
		//IL_009c: Expected O, but got I4
		//IL_00a5: Expected O, but got I4
		//IL_01fe: Expected O, but got I
		//IL_0244: Expected O, but got I
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_01d0: Expected O, but got Ref
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_03e5->IL0383: Incompatible stack heights: 1 vs 0
		//IL_0434->IL0383: Incompatible stack heights: 2 vs 0
		//IL_0190->IL0383: Incompatible stack heights: 2 vs 0
		//IL_01e8->IL0439: Incompatible stack heights: 2 vs 3
		//IL_046b->IL0383: Incompatible stack heights: 3 vs 0
		//IL_0278->IL00b3: Incompatible stack heights: 3 vs 0
		SpriteTrail spriteTrail = _SpriteTrail;
		if ((object)_SpriteTrail == null || ((UnityEngine.Object)spriteTrail).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<Vector3> frogSpritePositions = _frogSpritePositions;
		if (_frogSpritePositions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			SpriteTrail spriteTrail2 = _SpriteTrail;
			bool flag = (object)_SpriteTrail == null;
			object obj = 0;
			object obj2 = 0;
			if (!flag)
			{
				object obj3 = default(object);
				while (true)
				{
					if ((nint)obj2 < spriteTrail2._MaxHistory)
					{
						PhaserSprite frogSprite = _frogSprite;
						List<Vector3> frogSpritePositions2 = _frogSpritePositions;
						if ((object)_frogSprite == null)
						{
							break;
						}
						object spriteRenderer = frogSprite._spriteRenderer;
						if ((object)frogSprite._spriteRenderer == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rsi_v12 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rsi_v12 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform == null)
						{
							break;
						}
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						if (_frogSpritePositions == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v14 (Il2CppMethodInfo)+18]");
						if (num2 >= 0)
						{
							_frogSpritePositions.AddWithResize((Vector3)(&obj3));
							obj3 = ret;
							num = (nint)(&obj3);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj4 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v14 (Il2CppMethodInfo)+18]");
							bool flag4 = num3 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj5 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj6 = 0 + obj5;
							_ = 0;
						}
						spriteTrail2 = _SpriteTrail;
						obj++;
						if ((object)_SpriteTrail == null)
						{
							break;
						}
						obj2 = obj;
						continue;
					}
					if ((object)_SpriteTrail == null)
					{
						break;
					}
					_SpriteTrail.Reset();
					PhaserSprite frogSprite2 = _frogSprite;
					SpriteTrail spriteTrail3 = _SpriteTrail;
					if ((object)_frogSprite == null || (object)_SpriteTrail == null)
					{
						break;
					}
					spriteTrail3._MainSprite = frogSprite2._spriteRenderer;
					object spriteTrail4 = _SpriteTrail;
					if ((object)_SpriteTrail == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v12 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_SpriteTrail);
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v12 (System.Object)+10]");
					Behaviour.set_enabled_Injected((IntPtr)0, true);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartTimers()
	{
		float num = _weapon.PDuration();
		object obj2 = default(object);
		object obj = obj2 + obj2;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0087: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * -400f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Frog, soundConfig, 100f, 2, time);
	}

	protected virtual void ScaleIn()
	{
		//IL_013b: Expected O, but got I4
		//IL_001a: Expected O, but got I4
		//IL_0096: Expected I, but got O
		//IL_0109: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite = _frogSprite.setScale(1f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		float num2 = _weapon.PArea();
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void ScaleOut()
	{
		//IL_0033: Expected O, but got I4
		//IL_00af: Expected I, but got O
		//IL_0105: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_013c: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		DisableSpriteTrail();
		PhaserSprite phaserSprite = _frogSprite.setScale(1f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_frogSprite != null)
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
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.scaleY = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	public override void InternalUpdate()
	{
		//IL_0043: Expected I, but got O
		//IL_0058: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_0189->IL00ef: Incompatible stack heights: 1 vs 0
		//IL_01b0->IL00ef: Incompatible stack heights: 1 vs 0
		//IL_008b->IL00ef: Incompatible stack heights: 1 vs 0
		//IL_00cb->IL00ef: Incompatible stack heights: 1 vs 0
		if ((object)_frogSprite != null)
		{
			Transform transform = _frogSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj = default(object);
				float num = (float)obj * 100f;
				BaseBody baseBody = body;
				float num2 = -10f - num;
				if (body != null)
				{
					nint num3 = (nint)baseBody;
					BaseBody baseBody2 = body.setOffset(-10f, (float?)(object)1);
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							object obj2 = renderer.pixelHeight + renderer.pixelHeight;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
							if ((object)_frogSprite != null)
							{
								int num4 = default(int);
								PhaserSprite phaserSprite = _frogSprite.setDepth(num4);
								UpdateSpriteTrailPositions();
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateBody()
	{
		//IL_0050: Expected O, but got I4
		//IL_00c5->IL0055: Incompatible stack heights: 1 vs 0
		if ((object)_frogSprite != null)
		{
			Transform transform = _frogSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (body != null)
				{
					BaseBody baseBody = body.setOffset(-10f, (float?)(object)1);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateDepth()
	{
		//IL_002e: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj = renderer.pixelHeight + renderer.pixelHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		PhaserSprite phaserSprite = _frogSprite.setDepth(num);
	}

	private void UpdateSpriteTrailPositions()
	{
		//IL_0018: Expected O, but got I4
		//IL_0216: Expected O, but got I
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0083: Expected O, but got I
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_027f: Expected O, but got I
		//IL_0311: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0381: Expected O, but got I
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_0609: Expected O, but got I
		//IL_0433: Expected O, but got I
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		//IL_01d2->IL052d: Incompatible stack heights: 7 vs 1
		//IL_01d7->IL01d7: Incompatible stack heights: 7 vs 1
		//IL_0507->IL062a: Incompatible stack heights: 21 vs 11
		SpriteTrail spriteTrail = _SpriteTrail;
		bool flag = (object)_SpriteTrail == null;
		object obj = spriteTrail._MaxHistory - 1;
		if ((nint)obj >= 1)
		{
			object obj2 = obj - 1;
			object obj3 = obj;
			bool flag8;
			do
			{
				List<Vector3> frogSpritePositions = _frogSpritePositions;
				bool flag2 = _frogSpritePositions == null;
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag3 = (nint)obj4 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				bool flag4 = (nint)0 == 0;
				object obj6 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r8_v6+18]");
				bool flag5 = (nint)obj6 >= 0;
				object obj7 = obj3 * 2;
				object obj8 = obj3 + obj7;
				object obj9 = obj8 * 4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj10 = 0 + obj9;
				object obj11 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag6 = (nint)obj11 >= 0;
				object obj12 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r8_v6+18]");
				bool flag7 = (nint)obj12 >= 0;
				obj2--;
				obj = obj3 - 1;
				object obj13 = obj3 * 2;
				object obj14 = obj3 + obj13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ r11_v8+14]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ r11_v8+1C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
				_ = (nint)0 + (nint)1;
				flag8 = (nint)obj >= 1;
				obj3 = obj;
			}
			while (flag8);
		}
		object frogSprite = _frogSprite;
		List<Vector3> frogSpritePositions2 = _frogSpritePositions;
		bool flag9 = (object)_frogSprite == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rsi_v6 (System.Object)+28]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rsi_v6 (System.Object)+28]");
		bool flag10 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rsi_v7 (System.Object)+10]");
		bool flag11 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rsi_v7 (System.Object)+10]");
		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
		Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		bool flag12 = (object)transform == null;
		bool flag13 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag14 = _frogSpritePositions == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		bool flag15 = (nint)0 <= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		bool flag16 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v21+18]");
		bool flag17 = (nint)0 <= (nint)0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		SpriteTrail spriteTrail2 = _SpriteTrail;
		bool flag18 = (object)_SpriteTrail == null;
		object obj17 = 0;
		object obj18 = 0;
		while ((nint)obj18 < spriteTrail2._MaxHistory)
		{
			List<Vector3> frogSpritePositions3 = _frogSpritePositions;
			object spriteTrail3 = _SpriteTrail;
			bool flag19 = _frogSpritePositions == null;
			object obj19 = obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v29 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag20 = (nint)obj19 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v29 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v29 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			bool flag21 = (nint)0 == 0;
			object obj21 = obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v17+18]");
			bool flag22 = (nint)obj21 >= 0;
			object obj22 = obj17 * 2;
			object obj23 = obj17 + obj22;
			bool flag23 = (object)_SpriteTrail == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v12 (System.Object)+60]");
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v12 (System.Object)+60]");
			bool flag24 = (nint)0 == 0;
			object obj25 = obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v18+18]");
			bool flag25 = (nint)obj25 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v18+10]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v18+10]");
			bool flag26 = (nint)0 == 0;
			object obj27 = obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v8+18]");
			bool flag27 = (nint)obj27 >= 0;
			object obj28 = obj17 + 1;
			object obj29 = obj17 * 2;
			object obj30 = obj17 + obj29;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v17+20+v152 @ rcx_v24*4]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v17+28+v152 @ rcx_v24*4]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v18+1C]");
			_ = (nint)0 + (nint)1;
			spriteTrail2 = _SpriteTrail;
			bool flag28 = (object)_SpriteTrail == null;
			obj17 = obj28;
			obj18 = obj28;
		}
	}

	private void CalculateNextJump(bool firstJump = false)
	{
		//IL_01de: Expected O, but got I
		//IL_027d: Invalid comparison between I4 and F4
		//IL_0056: Expected F4, but got I4
		//IL_003e: Expected O, but got I8
		//IL_00fd: Expected O, but got I
		//IL_0130: Expected O, but got I
		//IL_0172: Expected O, but got I
		//IL_01a9: Expected O, but got I
		//IL_01a9: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TP_Frog_Projectile tP_Frog_Projectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_Frog_Projectile = (TP_Frog_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v50 @ rax_v3 (should have been resolved before IL gen)");
		float num;
		if (!(0f > _cachedWeaponArea))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm2\"");
			num = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = _cachedWeaponArea;
		}
		float radius = num * 0.75f;
		List<Vector2> pointsOnCircle = MathTools.GetPointsOnCircle(90, radius);
		bool flag3 = default(bool);
		bool flag2 = !flag3;
		Array array = null;
		if (!flag2)
		{
			bool flag4 = _frogSprite.flipX;
			int num2 = 0;
			if (!flag4)
			{
				num2 = 44;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj2 = -num2;
			if ((nint)obj2 < 45)
			{
				System.ThrowHelper.ThrowArgumentException(System.ExceptionResource.Argument_InvalidOffLen);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj3 = -45;
			bool flag5 = num2 >= (nint)obj3;
			flag3 = false;
			array = null;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				array = (Array)0;
				int num3 = num2 + 45;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				int length = default(int);
				Array.Copy((Array)num4, num3, (Array)0, num2, length);
				flag3 = (byte)num3 != 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
		}
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
		object obj4 = default(object);
		Vector2 nextJumpPos = (Vector2)(obj4 + (object)float5);
		object obj6 = default(object);
		object obj7 = default(object);
		object obj5 = obj6 + obj7;
		_nextJumpPos = nextJumpPos;
	}

	public unsafe void Jump(Vector2 destintion)
	{
		//IL_00e1: Expected O, but got Ref
		//IL_00f2: Expected O, but got I8
		//IL_0222: Expected O, but got I4
		//IL_0231: Expected O, but got I4
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_0447: Expected O, but got I4
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0359: Expected I, but got O
		//IL_01e1: Expected O, but got I4
		//IL_03d9: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		PlaySfx();
		PlayFrogAnim("jump");
		float2 float5 = base.position;
		bool flag = (byte)(float5 < destintion) != 0;
		object obj = (object)float5 - (object)destintion;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		PhaserSprite phaserSprite = _frogSprite.setFlipX(flag5);
		if (_posTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_posTween);
		}
		object obj2 = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&obj2), 0.3f);
		object obj3 = 6603577472L;
		object obj11;
		nint num3;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag6 = (nint)0 == 0;
				_ = 0;
				if (!flag6)
				{
					object obj4 = tweenerCore + 184;
					object obj5 = obj4 >> 12;
					object obj6 = obj5 & 0x1FFFFF;
					object obj7 = obj6 >> 6;
					object obj8 = obj6 & 0x3F;
					nint num2;
					do
					{
						object obj9 = 1 << (int)obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r14_v3+462E0+v403 @ rdx_v36*8]");
						object obj10 = 0 | obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r14_v3+462E0+v403 @ rdx_v36*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r14_v3+462E0+v403 @ rdx_v36*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r14_v3+462E0+v403 @ rdx_v36*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r14_v3+462E0+v403 @ rdx_v36*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = Idle;
					tweenCallback2 = tweenCallback;
					obj11 = 0;
					num3 = 0;
					goto IL_0245;
				}
			}
		}
		TweenCallback tweenCallback3 = Idle;
		bool flag7 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		obj11 = 0;
		num3 = 0;
		object obj12 = 0;
		nint num4 = 0;
		if (!flag7)
		{
			goto IL_0245;
		}
		goto IL_0294;
		IL_0245:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		bool flag8 = (nint)0 == 0;
		obj12 = obj11;
		num4 = num3;
		if (!flag8)
		{
			obj12 = obj11;
			num4 = num3;
		}
		goto IL_0294;
		IL_0294:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_posTween = tweenerCore;
		if (_posTween2 != null)
		{
			_posTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_frogSprite != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj13 = default(object);
			if (obj13 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 150f;
		tweenConfig.yoyo = true;
		tweenConfig.ease = Ease.OutSine;
		tweenConfig.localY = (float?)(object)1;
		MultiTargetTween posTween = Tweens.Add(tweenConfig);
		_posTween2 = posTween;
	}

	public void IdleOnSpawn()
	{
		//IL_002e: Expected O, but got I
		//IL_0094: Expected O, but got I8
		BaseBody baseBody = body;
		baseBody._enable = true;
		PlayFrogAnim("idle");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TP_Frog_Projectile tP_Frog_Projectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_Frog_Projectile = (TP_Frog_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v65 @ rax_v9 (should have been resolved before IL gen)");
		if (_moveTimer != null)
		{
			_moveTimer.Cancel();
		}
		Action onComplete = delegate
		{
			CalculateNextJump(firstJump: true);
			Vector2 destintion = default(Vector2);
			Jump(destintion);
		};
		float duration = 200f * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer moveTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_moveTimer = moveTimer;
	}

	private void Idle()
	{
		//IL_003a: Expected O, but got I
		//IL_00a0: Expected O, but got I8
		PlayFrogAnim("idle");
		Timer expireTimer = _expireTimer;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!expireTimer._003CIsCompleted_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			TP_Frog_Projectile tP_Frog_Projectile = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				tP_Frog_Projectile = (TP_Frog_Projectile)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v83 @ rax_v18 (should have been resolved before IL gen)");
			if (_moveTimer != null)
			{
				_moveTimer.Cancel();
			}
			Action onComplete = delegate
			{
				CalculateNextJump();
				Vector2 destintion = default(Vector2);
				Jump(destintion);
			};
			float duration = 500f * 0.001f;
			Timer moveTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_moveTimer = moveTimer;
		}
		else
		{
			Action onComplete2 = ScaleOut;
			Timer expireTimer2 = Timers.Register(0.25f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer2;
		}
	}

	private void PlayFrogAnim(string animName)
	{
		PhaserSprite frogSprite = _frogSprite;
		SpriteAnimation spriteAnimation = frogSprite._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		TP_Frog_Weapon trueWeapon = _trueWeapon;
		bool flag = (object)_trueWeapon == null;
		string animation = animName;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)trueWeapon).m_CachedPtr == (IntPtr)0;
			animation = animName;
			if (!flag2)
			{
				bool isPrimaryWeapon = _trueWeapon.IsPrimaryWeapon;
				bool flag3 = !isPrimaryWeapon;
				string text = "_counter";
				if (!flag3)
				{
					text = "";
				}
				string text2 = animName + text;
				animation = text2;
			}
		}
		PhaserSprite frogSprite2 = _frogSprite;
		frogSprite2._spriteAnimation.SetAnimation(animation);
	}

	public void SetFlipX(bool flipX)
	{
		PhaserSprite phaserSprite = _frogSprite.setFlipX(flipX);
	}

	private void DisableSpriteTrail()
	{
		SpriteTrail spriteTrail = _SpriteTrail;
		if ((object)_SpriteTrail != null && ((UnityEngine.Object)spriteTrail).m_CachedPtr != (IntPtr)0)
		{
			_SpriteTrail.Reset();
			_SpriteTrail.enabled = false;
		}
	}

	public override void Despawn()
	{
		DisableSpriteTrail();
		List<Vector3> frogSpritePositions = _frogSpritePositions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if (_moveTimer != null)
		{
			_moveTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_posTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_posTween);
		}
		if (_posTween2 != null)
		{
			_posTween2.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	public TP_Frog_Projectile()
	{
		//IL_001c: Expected O, but got I4
		SquashedScale = (Vector2)0;
		_ = 1092616192;
		List<Vector3> frogSpritePositions = new List<Vector3>();
		_frogSpritePositions = frogSpritePositions;
		base._002Ector();
	}

	private void _003CIdleOnSpawn_003Eb__26_0()
	{
		CalculateNextJump(firstJump: true);
		Vector2 destintion = default(Vector2);
		Jump(destintion);
	}

	private void _003CIdle_003Eb__27_0()
	{
		CalculateNextJump();
		Vector2 destintion = default(Vector2);
		Jump(destintion);
	}
}
