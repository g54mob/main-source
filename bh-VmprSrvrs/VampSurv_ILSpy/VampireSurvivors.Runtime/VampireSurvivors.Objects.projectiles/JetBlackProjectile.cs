using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class JetBlackProjectile : Projectile
{
	private SpriteAnimation _animation;

	private SpriteRenderer _starSprite;

	private SpriteRenderer _bubbleSprite;

	private bool _initialisedParticles;

	private GravityWell _gravityWell;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private float _radiusX = 1f;

	private float _radiusY = 1f;

	private float _offsetX;

	private float _offsetY;

	private MultiTargetTween _tween4;

	private Tween _dTween1;

	private Tween _dTween2;

	private float renderingAngle;

	private float renderingAngle2;

	private float _radiusY2 = 0.08f;

	private float accelDuration;

	private float accelTime;

	private bool isActive;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private ParticleSystem _pfx2;

	private float emissionTime;

	private JetBlackWeapon _trueWeapon;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		//IL_0097: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_00af: Expected O, but got I
		//IL_012f: Expected O, but got I4
		//IL_00eb: Expected O, but got I
		//IL_013e: Expected I4, but got O
		//IL_0121: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		Weapon weapon2 = _weapon;
		_isCullable = false;
		emissionTime = 0f;
		bool flag = (object)_weapon == null;
		bool flag2 = false;
		if (flag)
		{
			goto IL_018b;
		}
		nint num = (nint)typeof(JetBlackWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.JetBlackWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.JetBlackWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v20+FFFFFFF8+v155 @ rax_v16*8]");
			if (0 == (nint)typeof(JetBlackWeapon))
			{
				obj3 = 1;
				goto IL_019a;
			}
		}
		obj3 = 0;
		goto IL_019a;
		IL_018b:
		_trueWeapon = (JetBlackWeapon)flag2;
		_animation.SetAnimation("idle");
		GenerateParticleSystem();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 215 Invalid \"Jump target not found in method: 0x1872A5430\"");
		throw new NullReferenceException();
		IL_019a:
		bool flag3 = obj3 == null;
		flag2 = false;
		if (!flag3)
		{
			flag2 = (byte)(int)_weapon != 0;
		}
		goto IL_018b;
	}

	private void OnRecycle()
	{
		//IL_03e0: Expected O, but got F4
		//IL_00e3: Expected I, but got O
		//IL_0135: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_03ee: Expected O, but got F4
		//IL_0106->IL0106: Incompatible stack heights: 1 vs 0
		isActive = false;
		renderingAngle = (float)Math.PI / 2f;
		renderingAngle2 = (float)Math.PI / 2f;
		object obj = UnityEngine.Random.value;
		float num = _weapon.PDuration();
		object obj3 = default(object);
		object obj2 = obj3 * obj3;
		accelTime = 0f;
		float num2 = (accelDuration = (float)obj2 + 1000f);
		float duration = num2 / 5f;
		_gravityWell.enabled = false;
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_starSprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 5;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_starSprite, 1f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite, 0.35f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			_gravityWell.enabled = false;
			float2 pos = base.position;
			_trueWeapon.SpawnExplosionsAt(pos);
			base.Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween4 = tween;
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		EggFloat eggFloat = playerStats._003CMagnet_003Ek__BackingField;
		float num4 = eggFloat._val;
		Weapon weapon2 = _weapon;
		if (!(eggFloat._val > 1f))
		{
			num4 = 1f;
		}
		float num5 = weapon2.PArea();
		float num6 = num2 * num4;
		float num7 = num6 * 0.5f;
		object obj5 = UnityEngine.Random.value;
		float num8 = num2 * num7;
		float num9 = num7 + num8;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num10 = renderer.width * 0.45f;
		if (num10 > num9)
		{
			num10 = num9;
		}
		_radiusX = num10;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num11 = num9 * 0.5f;
		float num12 = renderer2.height * 0.45f;
		if (!(num12 > num11))
		{
			num11 = num12;
		}
		_radiusY = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 679 Invalid \"Jump target not found in method: 0x1872A5A40\"");
		throw new NullReferenceException();
	}

	private void FadeIn()
	{
		//IL_0066: Expected I, but got O
		//IL_00d8: Expected O, but got I4
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
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
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_0050: Expected O, but got I4
			//IL_0072: Expected O, but got I8
			if (_indexInWeapon < 12)
			{
				_gravityWell.enabled = true;
			}
			if (_indexInWeapon <= 4)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				object obj2 = 4294967286L - _indexInWeapon;
				float detune = (float)obj2 * 100f;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ophion2, soundConfig, 2000f, 2, time);
			}
			isActive = true;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0253: Expected O, but got I
		//IL_026f: Expected O, but got I4
		//IL_0288: Expected O, but got Ref
		//IL_02a2: Expected native int or pointer, but got O
		//IL_0898: Expected O, but got I4
		//IL_02ba: Expected O, but got Ref
		//IL_02d4: Expected native int or pointer, but got O
		//IL_02ee: Expected O, but got I
		//IL_08b5: Expected O, but got I4
		//IL_0346: Expected O, but got I
		//IL_0702: Expected O, but got I
		//IL_071e: Expected O, but got I4
		//IL_0737: Expected O, but got Ref
		//IL_0751: Expected native int or pointer, but got O
		//IL_0901: Expected O, but got I
		//IL_0789: Expected O, but got Ref
		//IL_07a3: Expected native int or pointer, but got O
		//IL_07bd: Expected O, but got I
		//IL_07f6: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			((Renderer)_starSprite).SetMaterial(material);
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			gravityWellConfig._power = 1f;
			gravityWellConfig._epsilon = 50f;
			gravityWellConfig._gravity = 20f;
			gravityWellConfig.preCacheParticles = false;
			GravityWell gravityWell = ParticleSystemGenerator.GenerateGravityWell(gravityWellConfig);
			_gravityWell = gravityWell;
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			_gravityWell.AddParticleSystem(characterController._damageVfx);
			JetBlackWeapon trueWeapon = _trueWeapon;
			_gravityWell.AddParticleSystem(trueWeapon.DamageVfx);
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 8f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"blurredSharpStar.png");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0.65f);
			_ = 0;
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			_ = 0;
			_ = 16711680;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			particleSystemConfig._tint = (uint?)(object)0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			List<string> list2 = new List<string>();
			int version2 = list2._version + 1;
			list2._version = version2;
			string[] items2 = list2._items;
			if (list2._size >= items2.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"rock0000");
			}
			else
			{
				int num2 = list2._size + 1;
				list2._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list2._version + 1;
			list2._version = version3;
			string[] items3 = list2._items;
			if (list2._size >= items3.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"rock0010");
			}
			else
			{
				int num3 = list2._size + 1;
				list2._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list2._version + 1;
			list2._version = version4;
			string[] items4 = list2._items;
			if (list2._size >= items4.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"rock0020");
			}
			else
			{
				int num4 = list2._size + 1;
				list2._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list2._version + 1;
			list2._version = version5;
			string[] items5 = list2._items;
			if (list2._size >= items5.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"rock0030");
			}
			else
			{
				int num5 = list2._size + 1;
				list2._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list2._version + 1;
			list2._version = version6;
			string[] items6 = list2._items;
			if (list2._size >= items6.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"rock0040");
			}
			else
			{
				int num6 = list2._size + 1;
				list2._size = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			particleSystemConfig2._quantity = (int?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			_ = 0;
			_ = 0;
			_ = 4473924;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			particleSystemConfig2._tint = (uint?)(object)0;
			EmitZone emitZone2 = new EmitZone();
			emitZone2._type = EmitZoneType.Random;
			emitZone2._source = circle;
			particleSystemConfig2._emitZone = emitZone2;
			particleSystemConfig2._on = false;
			Transform parent2 = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig2, parent2);
			_pfx2 = pfx2;
		}
	}

	public override void InternalUpdate()
	{
		//IL_03ff: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_024b: Expected O, but got I4
		//IL_0301: Expected I4, but got O
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected I4, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected I4, but got Unknown
		//IL_049c->IL0383: Incompatible stack heights: 6 vs 0
		//IL_01d9->IL0383: Incompatible stack heights: 6 vs 0
		//IL_0324->IL0383: Incompatible stack heights: 6 vs 0
		//IL_02c5->IL0383: Incompatible stack heights: 6 vs 0
		//IL_0360->IL0383: Incompatible stack heights: 6 vs 0
		//IL_04eb->IL0383: Incompatible stack heights: 7 vs 0
		//IL_02ed->IL02ed: Incompatible stack heights: 7 vs 6
		Transform transform3;
		if ((object)_gravityWell != null)
		{
			Transform transform = _gravityWell.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				bool flag2 = (object)transform == null;
				transform3 = (Transform)(nint)((UnityEngine.Object)transform).m_CachedPtr;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime * 1000f;
				bool flag4 = (object)_weapon == null;
				float num2 = _weapon.PSpeed();
				float num3 = num + accelTime;
				Weapon weapon = _weapon;
				accelTime = num3;
				float num4 = num3 / accelDuration;
				float num5 = num4 + 1f;
				float num6 = num5 * deltaTime;
				float num7 = num6 * num;
				bool flag5 = (object)_weapon == null;
				bool flag6 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
				bool flag7 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
				float num8 = renderingAngle;
				float num9 = num7 * 0.002f;
				float num10 = num7 * 0.007f;
				object obj = 316;
				object obj2 = 312;
				float num11 = renderingAngle2;
				if (!flag7)
				{
					float num12 = num10 + num11;
					float num13 = num9 + num8;
				}
				else
				{
					num11 -= num10;
					num8 -= num9;
					float num12 = num11;
					float num13 = num8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num14 = 1f - renderingAngle;
					float num15 = num14 * 0.25f;
					float xScale = num15 + 0.5f;
					ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
					float2 pos = default(float2);
					base.position = pos;
					if ((emissionTime = num + emissionTime) < 60f)
					{
						goto IL_02ed;
					}
					transform3 = _cachedTransform;
					emissionTime = 0f;
					if ((object)_cachedTransform != null)
					{
						bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
						if ((object)_pfxManager != null)
						{
							_pfxManager.EmitParticleAt(pos);
							goto IL_02ed;
						}
					}
				}
			}
		}
		goto IL_0383;
		IL_02ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm8\"");
		ArcadeSprite arcadeSprite2 = setDepth((int)transform3);
		if ((object)_bubbleSprite != null)
		{
			int sortingOrder = transform3 + 1;
			_bubbleSprite.sortingOrder = sortingOrder;
			if ((object)_starSprite != null)
			{
				int sortingOrder2 = transform3 + 2;
				_starSprite.sortingOrder = sortingOrder2;
				return;
			}
		}
		goto IL_0383;
		IL_0383:
		throw new NullReferenceException();
	}

	private void _003COnRecycle_003Eb__27_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_starSprite, 1f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_starSprite, 0.35f);
	}

	private void _003COnRecycle_003Eb__27_1()
	{
		_gravityWell.enabled = false;
		float2 pos = base.position;
		_trueWeapon.SpawnExplosionsAt(pos);
		base.Despawn();
	}

	private void _003CFadeIn_003Eb__28_0()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CFadeIn_003Eb__28_1()
	{
		//IL_0050: Expected O, but got I4
		//IL_0072: Expected O, but got I8
		if (_indexInWeapon < 12)
		{
			_gravityWell.enabled = true;
		}
		if (_indexInWeapon <= 4)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			object obj = 4294967286L - _indexInWeapon;
			float detune = (float)obj * 100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ophion2, soundConfig, 2000f, 2, time);
		}
		isActive = true;
	}
}
