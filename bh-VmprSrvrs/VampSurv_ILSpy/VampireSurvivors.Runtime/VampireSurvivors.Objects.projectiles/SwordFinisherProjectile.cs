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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SwordFinisherProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _tween2;

	private PhaserSprite _highlightSprite;

	private MultiTargetTween _posTween;

	private MultiTargetTween _alphaTween;

	private PhaserSprite _crackSprite;

	private MultiTargetTween _damageTween;

	private MultiTargetTween _fadeOutTween;

	private MultiTargetTween _alphaCrackTween;

	private float spriteRatio = 57f / 128f;

	private SwordWeapon _trueWeapon;

	private ParticleSystem _pfxEmitter;

	private PhaserSprite _impactSprite;

	private MultiTargetTween _impactTween;

	public float sfxVolume = 1f;

	protected override void Awake()
	{
		//IL_02d7->IL027d: Incompatible stack heights: 1 vs 0
		//IL_009f->IL027d: Incompatible stack heights: 1 vs 0
		//IL_00ce->IL027d: Incompatible stack heights: 1 vs 0
		//IL_0121->IL027d: Incompatible stack heights: 1 vs 0
		//IL_032a->IL027d: Incompatible stack heights: 2 vs 0
		//IL_0163->IL027d: Incompatible stack heights: 2 vs 0
		//IL_0192->IL027d: Incompatible stack heights: 2 vs 0
		//IL_01c1->IL027d: Incompatible stack heights: 2 vs 0
		//IL_0214->IL027d: Incompatible stack heights: 2 vs 0
		//IL_0377->IL027d: Incompatible stack heights: 3 vs 0
		//IL_0256->IL027d: Incompatible stack heights: 3 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("slash_sword", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		PhaserWorld instance = PhaserWorld.Instance;
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "ground");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite crackSprite = phaserSprite2.setTint(0u);
						_crackSprite = crackSprite;
						PhaserWorld instance2 = PhaserWorld.Instance;
						object cachedTransform2 = _cachedTransform;
						if ((object)_cachedTransform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v9 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v9 (System.Object)+10]");
							Transform.get_position_Injected((IntPtr)0, out ret);
							if ((object)instance2 != null)
							{
								PhaserSprite phaserSprite3 = instance2.AddPhaserSprite(pos, "vfx", "ground2");
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
									if ((object)phaserSprite4 != null)
									{
										PhaserSprite phaserSprite5 = phaserSprite4.setTint(16737792u);
										if ((object)phaserSprite5 != null)
										{
											PhaserSprite highlightSprite = phaserSprite5.setBlendMode(BlendMode.Add);
											_highlightSprite = highlightSprite;
											PhaserWorld instance3 = PhaserWorld.Instance;
											Transform cachedTransform3 = _cachedTransform;
											if ((object)_cachedTransform != null)
											{
												bool flag3 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, out ret);
												if ((object)instance3 != null)
												{
													PhaserSprite phaserSprite6 = instance3.AddPhaserSprite(pos, "vfx", "Hit1");
													if ((object)phaserSprite6 != null)
													{
														PhaserSprite impactSprite = phaserSprite6.setVisible(visible: false);
														_impactSprite = impactSprite;
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

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_14c6: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_0409: Expected O, but got Ref
		//IL_0430: Expected O, but got I
		//IL_044a: Expected native int or pointer, but got O
		//IL_0464: Expected O, but got I
		//IL_0484: Expected O, but got Ref
		//IL_049e: Expected native int or pointer, but got O
		//IL_04b8: Expected O, but got I
		//IL_04d8: Expected O, but got Ref
		//IL_04f2: Expected native int or pointer, but got O
		//IL_050c: Expected O, but got I
		//IL_052c: Expected O, but got Ref
		//IL_0546: Expected native int or pointer, but got O
		//IL_14e2: Expected O, but got I4
		//IL_0592: Expected O, but got Ref
		//IL_05ab: Expected native int or pointer, but got O
		//IL_151c: Expected O, but got I
		//IL_05f1: Expected O, but got I4
		//IL_0623: Expected O, but got I
		//IL_1556: Expected O, but got I
		//IL_0698: Expected O, but got I4
		//IL_06f4: Expected I4, but got I8
		//IL_0783: Expected O, but got I4
		//IL_0727: Expected O, but got I4
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Expected O, but got Unknown
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected I4, but got Unknown
		//IL_0756: Expected O, but got I4
		//IL_15cd: Expected I, but got O
		//IL_164b: Expected I, but got O
		//IL_0869: Expected O, but got F4
		//IL_08b6: Expected O, but got F4
		//IL_08f3: Expected O, but got I4
		//IL_0911: Expected O, but got I4
		//IL_0961: Expected O, but got I4
		//IL_16a6: Expected I, but got O
		//IL_0a54: Expected I, but got O
		//IL_0b9d: Expected I, but got O
		//IL_0cc1: Expected I, but got O
		//IL_0e1a: Expected I, but got O
		//IL_0f0d: Expected O, but got I4
		//IL_0e6e: Expected I, but got O
		//IL_0fbe: Expected I, but got O
		//IL_104b: Expected O, but got I4
		//IL_116b: Expected O, but got I4
		//IL_110a: Expected I, but got O
		//IL_1292: Expected O, but got I4
		//IL_1231: Expected I, but got O
		//IL_1352: Expected I, but got O
		//IL_1447: Expected O, but got I
		//IL_0bc0->IL0bc0: Incompatible stack heights: 7 vs 6
		//IL_0e3d->IL0e3d: Incompatible stack heights: 8 vs 7
		//IL_0e91->IL0e91: Incompatible stack heights: 8 vs 7
		//IL_0fe1->IL0fe1: Incompatible stack heights: 8 vs 7
		//IL_112d->IL112d: Incompatible stack heights: 8 vs 7
		//IL_1254->IL1254: Incompatible stack heights: 8 vs 7
		//IL_1375->IL1375: Incompatible stack heights: 8 vs 7
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_149f;
		}
		nint num = (nint)typeof(SwordWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v208 (Il2CppClass<VampireSurvivors.Objects.Weapons.SwordWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r8_v168 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v208 (Il2CppClass<VampireSurvivors.Objects.Weapons.SwordWeapon>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r8_v168 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v386+FFFFFFF8+v75 @ rax_v381*8]");
			if (0 == (nint)typeof(SwordWeapon))
			{
				obj5 = 1;
				goto IL_14ae;
			}
		}
		obj5 = 0;
		goto IL_14ae;
		IL_14ae:
		bool flag = obj5 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_149f;
		IL_149f:
		_trueWeapon = (SwordWeapon)trueWeapon;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0000");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0010");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0020");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0030");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0040");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 5;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(600f, 1100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-18]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+8]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+28]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 400f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+58]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-70]");
		_ = 0;
		float num9 = _trueWeapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-70]");
		float min = 0f * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+78]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-68]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = new ParticleSystem.MinMaxCurve(400f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 2891542;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		particleSystemConfig._tint = (uint?)(object)0;
		minMaxCurve6 = new ParticleSystem.MinMaxCurve(0.1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-40]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-20]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body;
		_indexInWeapon = 0;
		baseBody._enable = true;
		bool flag2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		int num10 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)((Equipment)weapon)._003COwner_003Ek__BackingField < 0)
		{
			object obj6 = num10 - 1;
			object obj7 = obj6 | -2;
			num10 = obj7 + 1;
		}
		bool flag4;
		if (flag2)
		{
			object obj8 = num10 - 1;
			bool flag3 = obj8 == null;
			flag4 = !flag3;
		}
		else
		{
			object obj9 = num10 - 1;
			bool flag5 = obj9 == null;
			flag4 = flag5;
		}
		ParticleSystemConfig cachedTransform = (ParticleSystemConfig)(object)_cachedTransform;
		bool flag6 = (object)cachedTransform._x == null;
		Transform.get_position_Injected((IntPtr)cachedTransform._x, out Vector3 _);
		if (flag4)
		{
		}
		List<string> cachedTransform2 = (List<string>)(object)_cachedTransform;
		object obj10 = default(object);
		float num11 = (float)obj10 + 0.16f;
		bool flag7 = (object)_cachedTransform == null;
		bool flag8 = cachedTransform2._items == null;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected((IntPtr)cachedTransform2._items, ref value);
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite = _highlightSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _crackSprite.setAlpha(1f);
		PhaserSprite phaserSprite3 = _highlightSprite.setVisible(visible: true);
		PhaserSprite phaserSprite4 = _crackSprite.setVisible(visible: true);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj11 = renderer.height ^ -0f;
		float num12 = (float)obj11 - 1001f;
		PhaserSprite phaserSprite5 = _highlightSprite.setDepth(num12);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		object obj12 = renderer2.height ^ -0f;
		float num13 = (float)obj12 - 1000f;
		PhaserSprite phaserSprite6 = _crackSprite.setDepth(num13);
		PhaserSprite phaserSprite7 = _highlightSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite8 = _crackSprite.setScale(0f, (float?)(object)0);
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite9 = _impactSprite.setDepth(0);
		PhaserSprite phaserSprite10 = _impactSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite11 = _impactSprite.setVisible(visible: true);
		Transform transform = _pfxEmitter.transform;
		float2 float8 = base.position;
		float2 float9 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E4]");
		float num14 = 0f + 0.08f;
		bool flag9 = (object)transform == null;
		bool flag10 = ((List<string>)(object)transform)._items == null;
		Transform.set_position_Injected((IntPtr)((List<string>)(object)transform)._items, ref value);
		RenderingExtensions.Start(_pfxEmitter);
		if (_damageTween != null)
		{
			_damageTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num15 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj13 = default(object);
		bool flag11 = obj13 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((ParticleSystemConfig)(object)tweenConfig)._x = (ParticleSystem.MinMaxCurve)array;
		_ = 0;
		float num16 = _weapon.PArea();
		object obj14 = default(object);
		float num17 = (float)obj14 * 3f;
		_ = 1120403456;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		((ParticleSystemConfig)(object)tweenConfig)._angleSteps = 0;
		TweenCallback tweenCallback = delegate
		{
			_trueWeapon.ScreenShake();
		};
		MultiTargetTween damageTween = Tweens.Add(tweenConfig);
		_damageTween = damageTween;
		if (_impactTween != null)
		{
			_impactTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_impactSprite != null)
		{
			nint num18 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj15 = default(object);
			bool flag12 = obj15 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((ParticleSystemConfig)(object)tweenConfig2)._x = (ParticleSystem.MinMaxCurve)array2;
		_ = 0;
		float num19 = _weapon.PArea();
		float num20 = num17 * 6f;
		_ = 1120403456;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		((ParticleSystemConfig)(object)tweenConfig2)._angleSteps = 0;
		TweenCallback tweenCallback2 = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite12 = _impactSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite13 = _impactSprite.setVisible(visible: false);
		};
		MultiTargetTween impactTween = Tweens.Add(tweenConfig2);
		_impactTween = impactTween;
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		nint num21 = (nint)array3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj16 = default(object);
		bool flag13 = obj16 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((ParticleSystemConfig)(object)tweenConfig3)._x = (ParticleSystem.MinMaxCurve)array3;
		_ = 0;
		_ = 1120403456;
		_ = 1;
		_ = 1120403456;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		TweenCallback tweenCallback3 = delegate
		{
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
			_pfxEmitter.Stop();
		};
		MultiTargetTween tween = Tweens.Add(tweenConfig3);
		_tween2 = tween;
		float num22 = _weapon.PArea();
		float num23 = num20 * 3f;
		float num24 = num23 * spriteRatio;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[2];
		if ((object)_highlightSprite != null)
		{
			nint num25 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			bool flag14 = obj17 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_crackSprite != null)
		{
			nint num26 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj18 = default(object);
			bool flag15 = obj18 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((List<string>)(object)tweenConfig4)._items = (string[])array4;
		_ = 0;
		float num27 = num24 * 1.05f;
		_ = 1;
		float num28 = num24 * 0.95f;
		((List<string>)(object)tweenConfig4)._size = 1123024896;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		((List<string>)(object)tweenConfig4)._syncRoot = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig4);
		_scaleTween = scaleTween;
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		TweenConfig tweenConfig5 = new TweenConfig();
		object[] array5 = new object[1];
		if ((object)_highlightSprite != null)
		{
			nint num29 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj19 = default(object);
			bool flag16 = obj19 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((List<string>)(object)tweenConfig5)._items = (string[])array5;
		float2 float10 = base.position;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+EC]");
		float num30 = 0f - 0.04f;
		((List<string>)(object)tweenConfig5)._size = 1147207680;
		((List<string>)(object)tweenConfig5)._syncRoot = 1;
		((List<string>)(object)tweenConfig5)._version = 1120403456;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		MultiTargetTween posTween = Tweens.Add(tweenConfig5);
		_posTween = posTween;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig6 = new TweenConfig();
		object[] array6 = new object[1];
		if ((object)_highlightSprite != null)
		{
			nint num31 = (nint)array6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj20 = default(object);
			bool flag17 = obj20 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((List<string>)(object)tweenConfig6)._items = (string[])array6;
		_ = 0;
		((List<string>)(object)tweenConfig6)._size = 1138819072;
		((List<string>)(object)tweenConfig6)._syncRoot = 1;
		((List<string>)(object)tweenConfig6)._version = 1120403456;
		_ = 1;
		_ = 1059481190;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig6);
		_alphaTween = alphaTween;
		if (_alphaCrackTween != null)
		{
			_alphaCrackTween.Kill();
		}
		TweenConfig tweenConfig7 = new TweenConfig();
		object[] array7 = new object[1];
		if ((object)_crackSprite != null)
		{
			nint num32 = (nint)array7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj21 = default(object);
			bool flag18 = obj21 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((List<string>)(object)tweenConfig7)._items = (string[])array7;
		_ = 0;
		((List<string>)(object)tweenConfig7)._size = 1140457472;
		((List<string>)(object)tweenConfig7)._syncRoot = 1;
		((List<string>)(object)tweenConfig7)._version = 1140457472;
		_ = 1059481190;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		MultiTargetTween alphaCrackTween = Tweens.Add(tweenConfig7);
		_alphaCrackTween = alphaCrackTween;
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig8 = new TweenConfig();
		object[] array8 = new object[1];
		if ((object)_crackSprite != null)
		{
			nint num33 = (nint)array8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj22 = default(object);
			bool flag19 = obj22 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		((ParticleSystemConfig)(object)tweenConfig8)._x = (ParticleSystem.MinMaxCurve)array8;
		_ = 0;
		_ = 1148846080;
		_ = 1;
		_ = 1161527296;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		_ = 0;
		TweenCallback tweenCallback4 = delegate
		{
			base.Despawn();
		};
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig8);
		_fadeOutTween = fadeOutTween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1;
		soundConfig.Rate = 1f;
		_ = sfxVolume;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		soundConfig.Volume = (float?)(object)0;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 0f, 10, time);
	}

	private void _003CInitProjectile_003Eb__16_0()
	{
		_trueWeapon.ScreenShake();
	}

	private void _003CInitProjectile_003Eb__16_1()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _impactSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _impactSprite.setVisible(visible: false);
	}

	private void _003CInitProjectile_003Eb__16_2()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		_pfxEmitter.Stop();
	}

	private void _003CInitProjectile_003Eb__16_3()
	{
		base.Despawn();
	}
}
