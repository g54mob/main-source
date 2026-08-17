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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_RapierProjectile_Shocking : Projectile
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public Projectile slowingBullet;

		internal void _003CSetTarget_003Eb__0()
		{
			slowingBullet.Despawn();
		}
	}

	private MeshRenderer _Quad1;

	private MeshRenderer _Quad2;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_RapierWeapon _trueWeapon;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private PhaserSprite crystalSprite;

	private bool isInitialised;

	private PhaserSprite impactSprite;

	private MultiTargetTween _tween3;

	protected bool hasHit;

	private static readonly int _AlphaMul;

	protected uint _pfxTint => 16776960u;

	public virtual void makeSprites()
	{
		//IL_0086: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4A65]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "blurredSharpStar");
		GameObject gameObject = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject).SetName("_blurredSharpStar");
		PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.65f);
		PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
		PhaserSprite phaserSprite6 = phaserSprite5.setBlendMode(BlendMode.Add);
		impactSprite = phaserSprite6;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001d: Expected O, but got I4
		//IL_007a: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_0112: Expected O, but got I4
		//IL_0067: Expected O, but got I4
		//IL_05aa: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0104: Expected O, but got I4
		//IL_02bb: Expected O, but got I
		//IL_02d7: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		//IL_01bf: Expected O, but got I
		//IL_02f0: Expected O, but got Ref
		//IL_030a: Expected native int or pointer, but got O
		//IL_05c6: Expected O, but got I4
		//IL_0322: Expected O, but got Ref
		//IL_033c: Expected native int or pointer, but got O
		//IL_0356: Expected O, but got I
		//IL_0376: Expected O, but got Ref
		//IL_039d: Expected O, but got I
		//IL_03b7: Expected native int or pointer, but got O
		//IL_05e3: Expected O, but got I4
		//IL_03e9: Expected O, but got Ref
		//IL_0403: Expected native int or pointer, but got O
		//IL_061d: Expected O, but got I
		//IL_0449: Expected O, but got I4
		//IL_047b: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		hasHit = false;
		if (isInitialised)
		{
			goto IL_0561;
		}
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		makeSprites();
		float? weapon2 = (float?)_weapon;
		isInitialised = true;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0583;
		}
		nint num = (nint)typeof(EME_RapierWeapon);
		object obj3 = weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v64 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r8_v81+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v64 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj6;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r8_v81+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v118+FFFFFFF8+v230 @ rax_v113*8]");
			if (0 == (nint)typeof(EME_RapierWeapon))
			{
				obj6 = 1;
				goto IL_0592;
			}
		}
		obj6 = 0;
		goto IL_0592;
		IL_0561:
		if (!_initialisedParticles)
		{
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 200;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 250f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(-400f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 0;
			_ = 16776960;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
			particleSystemConfig._tint = (uint?)(object)0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			_pfxEmitter = pfxEmitter;
			_initialisedParticles = true;
		}
		Material material = ((Renderer)_Quad1).GetMaterial();
		material.SetFloatImpl(_AlphaMul, 0f);
		Material material2 = ((Renderer)_Quad2).GetMaterial();
		material2.SetFloatImpl(_AlphaMul, 0f);
		return;
		IL_0592:
		bool flag = obj6 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0583;
		IL_0583:
		_trueWeapon = (EME_RapierWeapon)trueWeapon;
		Sprite sprite = SpriteManager.GetSprite("CrystalBig_0", "vfx");
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
		ArcadeSprite arcadeSprite3 = setVisible(visible: false);
		_ = 0;
		_ = 0;
		_ = 3253731328L;
		_ = 1;
		_ = 3253731328L;
		_ = 1;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+88]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		BaseBody baseBody2 = baseBody.setCircle(30f, (float?)(object)num4, (float?)(object)0);
		goto IL_0561;
	}

	public override void SetTarget(Transform target)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0178: Expected O, but got F4
		//IL_0265: Expected O, but got I4
		//IL_028b: Expected F4, but got I4
		//IL_05ba: Expected O, but got I4
		//IL_0609: Expected O, but got I4
		//IL_06d0: Expected I, but got O
		//IL_0736: Expected O, but got I4
		//IL_0760: Expected O, but got I4
		//IL_044e: Expected O, but got F4
		//IL_0885: Expected I, but got O
		//IL_08eb: Expected O, but got I4
		//IL_0915: Expected O, but got I4
		//IL_0530: Expected O, but got I4
		//IL_057b: Expected I4, but got F4
		//IL_0a3a: Expected I, but got O
		//IL_0aca: Expected O, but got I4
		//IL_06f3->IL06f3: Incompatible stack heights: 13 vs 12
		//IL_0c50->IL05a3: Incompatible stack heights: 20 vs 11
		//IL_08a8->IL08a8: Incompatible stack heights: 16 vs 15
		//IL_04e6->IL05a3: Incompatible stack heights: 20 vs 11
		//IL_05a3->IL05a3: Incompatible stack heights: 21 vs 11
		//IL_0a5d->IL0a5d: Incompatible stack heights: 18 vs 17
		Transform transform = default(Transform);
		object obj6;
		while (true)
		{
			_targetTransform = transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
			object obj = (object)transform >> 31;
			object obj2 = (object)transform + obj;
			object obj3 = obj2 * 2;
			object obj4 = obj2 + obj3;
			object obj5 = obj4 + obj4;
			obj6 = _indexInWeapon - obj5;
			if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1917 Invalid \"Jump target not found in method: 0x18723E560\"");
		}
		hasHit = true;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		EME_RapierWeapon trueWeapon = _trueWeapon;
		bool flag2 = (object)_trueWeapon == null;
		int[] fireX = trueWeapon._FireX;
		bool flag3 = trueWeapon._FireX == null;
		bool flag4 = (nint)obj6 >= fireX.Length;
		EME_RapierWeapon trueWeapon2 = _trueWeapon;
		int[] fireY = trueWeapon2._FireY;
		bool flag5 = trueWeapon2._FireY == null;
		bool flag6 = (nint)obj6 >= fireY.Length;
		float num = (float)fireY[obj6] * 0.01f;
		object obj7 = default(object);
		float num2 = num + (float)obj7;
		float num3 = default(float);
		base.position = (float2)num3;
		BaseBody baseBody = body;
		bool flag7 = body == null;
		baseBody._enable = true;
		bool flag8 = (object)_trueWeapon == null;
		float num4 = _trueWeapon.PArea();
		float2 float5 = base.position;
		bool flag9 = (object)impactSprite == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		bool flag10 = (object)impactSprite == null;
		PhaserSprite phaserSprite = impactSprite.setVisible(visible: true);
		bool flag11 = (object)impactSprite == null;
		PhaserSprite phaserSprite2 = impactSprite.setScale(0f, (float?)(object)0);
		bool flag12 = !hasHit;
		float num6 = default(float);
		float num5 = num6;
		float num7 = 0f;
		Action<float> action = null;
		float num10 = default(float);
		if (!flag12)
		{
			_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass18_0();
			bool flag13 = (object)_Quad1 == null;
			Material material = ((Renderer)_Quad1).GetMaterial();
			bool flag14 = (object)material == null;
			material.SetFloatImpl(_AlphaMul, 1f);
			bool flag15 = (object)_Quad2 == null;
			Material material2 = ((Renderer)_Quad2).GetMaterial();
			bool flag16 = (object)material2 == null;
			material2.SetFloatImpl(_AlphaMul, 1f);
			bool flag17 = (object)_Quad1 == null;
			Material material3 = ((Renderer)_Quad1).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material3, 0f, _AlphaMul, 0.75f);
			bool flag18 = (object)_Quad2 == null;
			Material material4 = ((Renderer)_Quad2).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material4, 0f, _AlphaMul, 0.75f);
			EME_RapierWeapon trueWeapon3 = _trueWeapon;
			bool flag19 = (object)_trueWeapon == null;
			float2 float6 = base.position;
			float2 float7 = base.position;
			bool flag20 = trueWeapon3._slowOnlyPool == null;
			Projectile slowingBullet = trueWeapon3._slowOnlyPool.SpawnAt((float2)num3, _trueWeapon);
			bool flag21 = CS_0024_003C_003E8__locals7 == null;
			CS_0024_003C_003E8__locals7.slowingBullet = slowingBullet;
			action = (Action<float>)(object)_trueWeapon;
			Projectile slowingBullet2 = CS_0024_003C_003E8__locals7.slowingBullet;
			bool flag22 = (object)CS_0024_003C_003E8__locals7.slowingBullet == null;
			num5 = num3;
			float num8 = 0.75f;
			float num9 = default(float);
			num7 = num9;
			num10 = num10;
			if (!flag22)
			{
				bool flag23 = ((UnityEngine.Object)slowingBullet2).m_CachedPtr == (IntPtr)0;
				num5 = num3;
				num8 = 0.75f;
				num7 = num9;
				num10 = num10;
				if (!flag23)
				{
					bool flag24 = (object)CS_0024_003C_003E8__locals7.slowingBullet == null;
					num7 = num6 * 3f;
					ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals7.slowingBullet.setScale(num7, (float?)(object)0);
					Action onComplete = delegate
					{
						CS_0024_003C_003E8__locals7.slowingBullet.Despawn();
					};
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num10 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					num5 = 0.1f;
					num8 = 0.75f;
					action = null;
					num10 = num10;
				}
			}
		}
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1.2f
		}, 200f, 4, num10);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_mlightning1, new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1.2f
		}, 200f, 4, num10);
		if (_tween != null)
		{
			_tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform2 = base.transform;
		bool flag25 = array == null;
		if ((object)transform2 != null)
		{
			nint num11 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			bool flag26 = obj8 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag27 = tweenConfig == null;
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 300f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_002a: Expected O, but got I4
			ArcadeSprite arcadeSprite2 = setScale(0.5f, (float?)(object)1);
			float2 float8 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, 90);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete2 = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		bool flag28 = (object)impactSprite == null;
		Transform transform3 = impactSprite.transform;
		bool flag29 = array2 == null;
		if ((object)transform3 != null)
		{
			nint num12 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			bool flag30 = obj9 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag31 = tweenConfig2 == null;
		tweenConfig2.targets = array2;
		tweenConfig2.scaleX = (float?)(object)1;
		tweenConfig2.duration = 200f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.scaleY = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite3 = impactSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = impactSprite.setVisible(visible: true);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onComplete3 = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite3 = impactSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = impactSprite.setVisible(visible: false);
		};
		tweenConfig2.onComplete = onComplete3;
		TweenCallback onStop = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite3 = impactSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = impactSprite.setVisible(visible: false);
		};
		tweenConfig2.onStop = onStop;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween2 = tween2;
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		bool flag32 = array3 == null;
		if ((object)impactSprite != null)
		{
			nint num13 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag33 = obj10 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag34 = tweenConfig3 == null;
		tweenConfig3.targets = array3;
		tweenConfig3.delay = 100f;
		tweenConfig3.duration = 100f;
		tweenConfig3.ease = Ease.Linear;
		tweenConfig3.alpha = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			PhaserSprite phaserSprite3 = impactSprite.setAlpha(0.65f);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onComplete4 = delegate
		{
			PhaserSprite phaserSprite3 = impactSprite.setAlpha(0f);
		};
		tweenConfig3.onComplete = onComplete4;
		TweenCallback onStop2 = delegate
		{
			PhaserSprite phaserSprite3 = impactSprite.setAlpha(0f);
		};
		tweenConfig3.onStop = onStop2;
		MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
		_tween3 = tween3;
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		Action onComplete = delegate
		{
			PhaserSprite phaserSprite = impactSprite.setVisible(visible: false);
			Material material = ((Renderer)_Quad1).GetMaterial();
			material.SetFloatImpl(_AlphaMul, 0f);
			Material material2 = ((Renderer)_Quad2).GetMaterial();
			material2.SetFloatImpl(_AlphaMul, 0f);
			base.Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void DespawnNow()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		PhaserSprite phaserSprite = impactSprite.setVisible(visible: false);
		Material material = ((Renderer)_Quad1).GetMaterial();
		material.SetFloatImpl(_AlphaMul, 0f);
		Material material2 = ((Renderer)_Quad2).GetMaterial();
		material2.SetFloatImpl(_AlphaMul, 0f);
		base.Despawn();
	}

	public override void SetNullTarget()
	{
		DespawnNow();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	static EME_RapierProjectile_Shocking()
	{
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003CSetTarget_003Eb__18_1()
	{
		//IL_002a: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)1);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, 90);
	}

	private void _003CSetTarget_003Eb__18_2()
	{
		Despawn();
	}

	private void _003CSetTarget_003Eb__18_3()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = impactSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = impactSprite.setVisible(visible: true);
	}

	private void _003CSetTarget_003Eb__18_4()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = impactSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = impactSprite.setVisible(visible: false);
	}

	private void _003CSetTarget_003Eb__18_5()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = impactSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = impactSprite.setVisible(visible: false);
	}

	private void _003CSetTarget_003Eb__18_6()
	{
		PhaserSprite phaserSprite = impactSprite.setAlpha(0.65f);
	}

	private void _003CSetTarget_003Eb__18_7()
	{
		PhaserSprite phaserSprite = impactSprite.setAlpha(0f);
	}

	private void _003CSetTarget_003Eb__18_8()
	{
		PhaserSprite phaserSprite = impactSprite.setAlpha(0f);
	}

	private void _003CDespawn_003Eb__19_0()
	{
		PhaserSprite phaserSprite = impactSprite.setVisible(visible: false);
		Material material = ((Renderer)_Quad1).GetMaterial();
		material.SetFloatImpl(_AlphaMul, 0f);
		Material material2 = ((Renderer)_Quad2).GetMaterial();
		material2.SetFloatImpl(_AlphaMul, 0f);
		base.Despawn();
	}
}
