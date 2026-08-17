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
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Lapiste2_BigFistProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__14_0;

		public static TweenCallback _003C_003E9__14_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoScreenShake_003Eb__14_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -5f;
		}

		internal void _003CDoScreenShake_003Eb__14_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private const float Radius = 36f;

	private PhaserSprite _fistSprite;

	private PhaserSprite _slamSprite;

	private bool _isOnScreen;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _screenShakeTween;

	private Timer _timer;

	private float FistScale
	{
		get
		{
			//IL_0017: Expected I, but got O
			Weapon weapon = _weapon;
			nint num = (nint)weapon;
			float num2 = weapon.PArea();
			object obj = default(object);
			if (0 <= (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
				return (float)obj + (float)obj;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			return (float)obj + (float)obj;
		}
	}

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006c: Expected O, but got I
		//IL_006c: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_01e4: Expected O, but got I
		//IL_01e4: Expected O, but got I
		//IL_0200: Expected O, but got I4
		//IL_038c: Expected O, but got Ref
		//IL_03af: Expected native int or pointer, but got O
		//IL_03c2: Expected O, but got Ref
		//IL_02eb: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1658]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_ = 0;
			GameObject gameObject = base.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, (string)num2, (string)0);
			GameObject gameObject2 = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject2).SetName("BigFistSprite");
			_fistSprite = phaserSprite;
			SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
			if (spriteTexturesBase.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F615]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_ = 0;
				GameObject gameObject3 = base.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
				PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, (string)num3, (string)0);
				PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
				PhaserSprite phaserSprite4 = phaserSprite3.setDepth(10000f);
				PhaserSprite phaserSprite5 = phaserSprite4.setLocalPosition(vector);
				GameObject gameObject4 = phaserSprite5.gameObject;
				((UnityEngine.Object)gameObject4).SetName("SlamSprite");
				_slamSprite = phaserSprite5;
				SpriteAnimations.SpriteAnimationsBase spriteAnimationsBase = SpriteAnimations.Base;
				if (spriteAnimationsBase.Vfx != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6906]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					SpriteAnimationData spriteAnimationData = (SpriteAnimationData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = 0;
					_ = 0;
					string text = default(string);
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)spriteAnimationData, new SpriteAnimationData("Burst", 1, 6, text));
					SpriteAnimationData spriteAnimation = (SpriteAnimationData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
					_ = 0;
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(spriteAnimation, vector);
					PhaserSprite slamSprite = _slamSprite;
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					slamSprite._spriteAnimation.AddAnimation("slam", animationFrames, 30, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0058: Expected I, but got O
		//IL_00be: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_isOnScreen = false;
		PhaserSprite phaserSprite = _slamSprite.setVisible(visible: false);
		Weapon weapon2 = _weapon;
		nint num = (nint)weapon2;
		float num2 = weapon2.PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float xScale = (float)obj + (float)obj;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		if (_indexInWeapon != 1)
		{
			/*Error: End of method reached without returning.*/;
		}
		BaseBody baseBody = body.setCircle(36f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 142 Invalid \"Jump target not found in method: 0x18712B6B0\"");
		throw new NullReferenceException();
	}

	private void SetBody()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		if (_indexInWeapon != 1)
		{
			/*Error: End of method reached without returning.*/;
		}
		BaseBody baseBody = body.setCircle(36f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
	}

	private void MoveFistToCentre()
	{
		//IL_002e: Expected O, but got I4
		//IL_00af: Expected O, but got I4
		//IL_00d7: Expected I, but got O
		//IL_00ed: Invalid comparison between I4 and F4
		//IL_00ca: Expected O, but got I8
		PhaserSprite phaserSprite = _fistSprite.setAlpha(1f);
		object obj = _indexInWeapon - 1;
		bool flag = obj == null;
		PhaserSprite phaserSprite2 = _fistSprite.setFlipX(flag);
		float width = _fistSprite.Width;
		float num = width * 0.5f;
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		bool flag2 = _indexInWeapon == 1;
		object obj2 = 1;
		if (!flag2)
		{
			obj2 = 4294967295L;
		}
		Weapon weapon2 = _weapon;
		float num2 = (float)obj2 * num;
		float endValue = num2 + (float)float5;
		nint num3 = (nint)weapon2;
		float num4 = weapon2.PArea();
		if (!(0f > width))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float num5 = width + width;
		bool flag3 = 2f > num5;
		float num6 = 2f;
		if (!flag3)
		{
			num6 = num5;
		}
		float num7 = 1200f / num6;
		float duration = num7 * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveX(_cachedTransform, endValue, duration);
		TweenCallback tweenCallback = DoFistBump;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void DoFistBump()
	{
		if (_indexInWeapon == 0)
		{
			PhaserSprite phaserSprite = _slamSprite.setVisible(visible: true);
			PhaserSprite slamSprite = _slamSprite;
			slamSprite._spriteAnimation.SetAnimation("slam");
			DoScreenShake();
		}
		if (_timer != null)
		{
			_timer.Cancel();
		}
		Action onComplete = FadeOut;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timer = timer;
	}

	protected void DoScreenShake()
	{
		//IL_00e2: Expected I, but got O
		//IL_0162: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
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
		TweenCallback onStart = _003C_003Ec._003C_003E9__14_0;
		if (_003C_003Ec._003C_003E9__14_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__14_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -5f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__14_1;
		if (_003C_003Ec._003C_003E9__14_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_1 = delegate
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
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}

	public override void InternalUpdate()
	{
		//IL_00e9: Expected O, but got I4
		if (_indexInWeapon == 0 && !_isOnScreen)
		{
			PhaserSprite fistSprite = _fistSprite;
			if (CameraExtensions.IsObjectVisible(_mainCamera, fistSprite._spriteRenderer))
			{
				_isOnScreen = true;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_UnionLapiste, soundConfig, 100f, 1, time);
			}
		}
	}

	private void CheckForSfx()
	{
		//IL_00e9: Expected O, but got I4
		if (_indexInWeapon == 0 && !_isOnScreen)
		{
			PhaserSprite fistSprite = _fistSprite;
			if (CameraExtensions.IsObjectVisible(_mainCamera, fistSprite._spriteRenderer))
			{
				_isOnScreen = true;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_UnionLapiste, soundConfig, 100f, 1, time);
			}
		}
	}

	private void PlaySfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_UnionLapiste, soundConfig, 100f, 1, time);
	}

	private void FadeOut()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		//IL_010a: Expected I, but got O
		//IL_0157: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		//IL_02c3: Expected O, but got I8
		//IL_01c2: Expected I, but got O
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01f2: Expected O, but got I4
		//IL_01b5: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_fistSprite != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Lapiste2_BigFistProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Lapiste2_BigFistProjectile>)+370]");
		nint num3 = 0;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		object obj2 = 0;
		TweenConfig tweenConfig2 = tweenConfig;
		Weapon weapon = _weapon;
		if (!weapon._explodeOnExpire)
		{
			return;
		}
		float? num4 = (float?)(object)0;
		object obj3 = 0;
		bool flag2;
		object obj4 = default(object);
		do
		{
			float num5 = (float)obj3 * 60f;
			float num6 = num5 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			bool flag = _indexInWeapon == 1;
			float? num7 = (float?)(object)4294967295L;
			if (!flag)
			{
				num7 = (float?)(object)1;
			}
			float num8 = (float)num7 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			TweenConfig weapon2 = (TweenConfig)(object)_weapon;
			float num9 = num6 * 0.5f;
			float2 float5 = base.position;
			nint num10 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v618 @ r10_v5 (Il2CppClass<VampireSurvivors.Framework.PhaserTweens.TweenConfig>)+558] (should have been resolved before IL gen)");
			obj3++;
			flag2 = (nint)obj3 < 6;
			num4 = (float?)(object)1;
			num3 = 0;
			obj2 = obj4;
			tweenConfig2 = weapon2;
		}
		while (flag2);
	}

	private void DoTwilightExplosions()
	{
		//IL_006c: Expected O, but got I4
		//IL_015f: Expected O, but got I8
		//IL_0087: Expected I, but got O
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_007a: Expected O, but got I4
		Weapon weapon = _weapon;
		if (!weapon._explodeOnExpire)
		{
			return;
		}
		TP_Lapiste2_BigFistProjectile tP_Lapiste2_BigFistProjectile = this;
		object obj = 0;
		object obj3 = default(object);
		bool flag2;
		do
		{
			float num = (float)obj * 60f;
			float num2 = num * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			bool flag = _indexInWeapon == 1;
			object obj2 = 4294967295L;
			if (!flag)
			{
				obj2 = 1;
			}
			float num3 = (float)obj2 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			TP_Lapiste2_BigFistProjectile weapon2 = (TP_Lapiste2_BigFistProjectile)(object)_weapon;
			float num4 = num2 * 0.5f;
			float2 float5 = base.position;
			float num5 = (float)obj3 + num4;
			nint num6 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v145 @ r10_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Lapiste2_BigFistProjectile>)+558] (should have been resolved before IL gen)");
			obj++;
			flag2 = (nint)obj < 6;
			tP_Lapiste2_BigFistProjectile = weapon2;
		}
		while (flag2);
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		if (_timer != null)
		{
			_timer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_025a->IL01c1: Incompatible stack heights: 1 vs 0
		//IL_01c0->IL01c0: Incompatible stack heights: 1 vs 0
		if (other != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				return;
			}
			if ((object)_weapon != null)
			{
				if (_weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
				{
					bool flag = TryFreeze(other);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					Transform component = gameObject.GetComponent<Transform>();
					if ((object)component == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v14 (UnityEngine.Transform)+10]");
					if ((nint)0 == 0)
					{
						return;
					}
					if ((object)_weapon != null)
					{
						if (!_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
						{
							return;
						}
						Weapon weapon = _weapon;
						if ((object)_weapon != null)
						{
							GameManager gameMan = weapon._gameMan;
							if ((object)weapon._gameMan != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v14 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v14 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								if (gameMan._arcanaManager != null)
								{
									Vector2 pos = default(Vector2);
									gameMan._arcanaManager.TriggerFireExplosion(pos);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
