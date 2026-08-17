using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_BigFuzzyFistProjectile : Projectile
{
	private PhaserSprite _explosion;

	private PhaserSprite _crack;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_00c2: Expected F4, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_029b: Expected I4, but got I8
		//IL_0319: Expected O, but got I4
		//IL_0357: Expected I, but got O
		//IL_03ca: Expected O, but got I4
		//IL_0425: Expected I, but got O
		//IL_047b: Expected O, but got I4
		//IL_05e0: Expected I, but got O
		//IL_060f: Expected I4, but got F4
		//IL_060f: Expected O, but got F4
		//IL_060f: Expected I4, but got O
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		BaseBody baseBody = body;
		BaseBody baseBody2 = baseBody.setCircle(32f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		PhaserSprite explosion = _explosion;
		if ((object)_explosion == null || ((UnityEngine.Object)explosion).m_CachedPtr == (IntPtr)0)
		{
			SetupVisuals();
		}
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzHeadChop, 100f, 10, 0f, num, num2, num3, flag, 1f);
		PhaserSprite explosion2 = _explosion;
		SpriteAnimation spriteAnimation = explosion2._spriteAnimation;
		spriteAnimation._originalSpriteSize = (float2)1124073472;
		_ = 1124073472;
		float2 float5 = base.position;
		float num4 = _weapon.PArea();
		object obj = default(object);
		float num5 = (float)obj * 0.39999998f;
		float num6 = 1.0569646E+09f + num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = _explosion.setVisible(visible: true);
		float num7 = _weapon.PArea();
		PhaserSprite phaserSprite2 = _explosion.setScale(num5, (float?)(object)0);
		float num8 = _weapon.PArea();
		float num9 = num5 - 2f;
		float num10 = 1f - num9;
		bool flag2 = 0.2f > num10;
		float alpha = 0.2f;
		if (!flag2)
		{
			alpha = num10;
		}
		PhaserSprite phaserSprite3 = _explosion.setAlpha(alpha);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num11 = default(int);
		PhaserSprite phaserSprite4 = _explosion.setDepth(num11);
		PhaserSprite explosion3 = _explosion;
		explosion3._spriteAnimation.SetAnimation("bang");
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite5 = _crack.setVisible(visible: true);
		PhaserSprite phaserSprite6 = _crack.setDepth(-1000);
		PhaserSprite phaserSprite7 = _crack.setAlpha(1f);
		float num12 = _weapon.PArea();
		float num13 = _weapon.PArea();
		float num14 = num9 * 0.25f;
		float xScale = num9 * 0.5f;
		PhaserSprite phaserSprite8 = _crack.setScale(xScale, (float?)(object)1);
		SetScaleToArea(0.5f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num15 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num16 = _weapon.PArea();
			tweenConfig.duration = 500f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_crack != null)
			{
				nint num17 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.duration = 1000f;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			ParticleEmitterManager particlesManager = _particlesManager;
			if ((object)_particlesManager == null || ((UnityEngine.Object)particlesManager).m_CachedPtr == (IntPtr)0)
			{
				GenerateParticleSystem();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num18 = default(int);
			RenderingExtensions.SetDepth(_pfxEmitter, num18);
			float num19 = _weapon.PArea();
			float num20 = num14 * 0.125f;
			ParticleSystem particleSystem = RenderingExtensions.SetScale(_pfxEmitter, num20);
			float num21 = _weapon.PArea();
			Weapon weapon2 = _weapon;
			float num22 = weapon2.PArea();
			float max = num20 * 100f;
			float min = num20 * 100f;
			RenderingExtensions.SetSpeed(_pfxEmitter, min, max);
			float2 float7 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, 100);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1315 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_BigFuzzyFistProjectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num23 = (nint)this;
			Timer timer = Timers.Register(1.2f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_016e: Expected O, but got I4
		//IL_0187: Expected O, but got Ref
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01bb: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_020f: Expected O, but got I
		//IL_03b1: Expected O, but got I4
		//IL_0242: Expected O, but got Ref
		//IL_0269: Expected O, but got I
		//IL_0283: Expected native int or pointer, but got O
		//IL_03e3: Expected O, but got I
		//IL_02bb: Expected O, but got Ref
		//IL_02dc: Expected O, but got I
		//IL_02f6: Expected native int or pointer, but got O
		//IL_041d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitCloud1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
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
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(180f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.25f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		particleSystemConfig._on = false;
		particleSystemConfig._alphaEase = Easing.Linear;
		Transform parent = base.transform;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, parent, "BigFuzzyFistPfxEmitter");
		_pfxEmitter = pfxEmitter;
		Transform transform = _pfxEmitter.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _explosion.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _crack.setVisible(visible: false);
		base.Despawn();
	}

	private void SetupVisuals()
	{
		//IL_00e6->IL0283: Incompatible stack heights: 1 vs 0
		//IL_0144->IL0283: Incompatible stack heights: 1 vs 0
		//IL_01a5->IL0283: Incompatible stack heights: 1 vs 0
		//IL_01dd->IL0283: Incompatible stack heights: 1 vs 0
		//IL_020c->IL0283: Incompatible stack heights: 1 vs 0
		//IL_0236->IL0283: Incompatible stack heights: 1 vs 0
		float2 float5 = base.position;
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "Big Fuzzy Fist-Impact 2-F1", "firstBlood");
			if ((object)phaserSprite != null)
			{
				Transform transform = phaserSprite.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v21 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
					_explosion = phaserSprite;
					PhaserSprite explosion = _explosion;
					if ((object)_explosion != null)
					{
						int num2 = default(int);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Big Fuzzy Fist-Impact 2-F", 1, 4, "firstBlood", num2);
						Action action = OnAnimationComplete;
						if ((object)explosion._spriteAnimation != null)
						{
							bool startRandomFrame = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							explosion._spriteAnimation.AddAnimation("bang", animationFrames, 8, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
							PhaserWorld instance = PhaserWorld.Instance;
							float2 float6 = base.position;
							if ((object)instance != null)
							{
								PhaserSprite phaserSprite2 = instance.AddPhaserSprite(pos, "vfx", "ground");
								if ((object)phaserSprite2 != null)
								{
									PhaserSprite phaserSprite3 = phaserSprite2.setTint(0u);
									if ((object)phaserSprite3 != null)
									{
										Transform transform2 = phaserSprite3.transform;
										if ((object)transform2 != null)
										{
											bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rcx_v36 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
											_crack = phaserSprite3;
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
		throw new NullReferenceException();
	}

	private void OnAnimationComplete()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		PhaserSprite phaserSprite = _explosion.setVisible(visible: false);
	}
}
