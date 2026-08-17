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
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class CherryStarExplosionProjectile : Projectile
{
	private SpriteRenderer _ringRenderer;

	private SpriteRenderer _rainbowRenderer;

	private SpriteRenderer _raysRenderer;

	private ParticleEmitterManager _particles;

	private ParticleSystem _fwEmitter;

	private GravityWell _well;

	private bool _isDespawning;

	private Vector2 _aimVec;

	private MultiTargetTween _ttween6;

	private MultiTargetTween _ttween5;

	private MultiTargetTween _ttween3;

	private MultiTargetTween _ttween4;

	private MultiTargetTween _ttween4Alpha;

	private MultiTargetTween _ttween2;

	private MultiTargetTween _ttween1;

	private CherryWeapon _trueWeapon;

	private bool _alreadyRecycled;

	private uint[] _onEmitcustomTint2 = new uint[4] { 4474111u, 16729343u, 16729343u, 16729156u };

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_029c: Expected O, but got I4
		//IL_02c3: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_0303: Expected O, but got Ref
		//IL_031d: Expected native int or pointer, but got O
		//IL_0337: Expected O, but got I
		//IL_0357: Expected O, but got Ref
		//IL_0371: Expected native int or pointer, but got O
		//IL_0580: Expected O, but got I4
		//IL_0389: Expected O, but got Ref
		//IL_03b1: Expected native int or pointer, but got O
		//IL_03cb: Expected O, but got I
		//IL_03eb: Expected O, but got Ref
		//IL_0413: Expected native int or pointer, but got O
		//IL_05b2: Expected O, but got I
		//IL_044b: Expected O, but got Ref
		//IL_0472: Expected O, but got I
		//IL_048c: Expected native int or pointer, but got O
		//IL_05ec: Expected O, but got I
		//IL_04e3: Expected O, but got I
		//IL_0504: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particles;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			particles = (ParticleEmitterManager)0;
		}
		else
		{
			particles = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particles = particles;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur");
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
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur2");
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
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur3");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
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
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 1f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		particleSystemConfig._alphaEase = Easing.OutExpo;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		particleSystemConfig._angleSteps = 16;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(50f, 100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 64;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		_ = 0;
		_ = 1115684864;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._on = false;
		ParticleSystem fwEmitter = _particles.CreateEmitter(particleSystemConfig, null, "_fwEmitter");
		_fwEmitter = fwEmitter;
		Transform transform = _fwEmitter.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0069: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_0101: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_0383: Expected O, but got I4
		//IL_00bd: Expected O, but got I
		//IL_012e: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_02c0: Expected O, but got I4
		if (_alreadyRecycled)
		{
			return;
		}
		_alreadyRecycled = true;
		_isDespawning = false;
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_035c;
		}
		nint num = (nint)typeof(CherryWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v48+FFFFFFF8+v218 @ rax_v43*8]");
			if (0 == (nint)typeof(CherryWeapon))
			{
				obj3 = 1;
				goto IL_036b;
			}
		}
		obj3 = 0;
		goto IL_036b;
		IL_028e:
		ArcadeSprite arcadeSprite = setAlpha(1f);
		float num4 = _trueWeapon.PArea();
		float num5 = default(float);
		ArcadeSprite arcadeSprite2 = setScale(num5, (float?)(object)0);
		float num6 = _weapon.PArea();
		float num7 = _weapon.PArea();
		float max = num5 * 100f;
		float min = num5 * 50f;
		RenderingExtensions.SetSpeed(_fwEmitter, min, max);
		_isCullable = false;
		Detonate();
		return;
		IL_036b:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_035c;
		IL_035c:
		_trueWeapon = (CherryWeapon)trueWeapon;
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		ArcadeSprite arcadeSprite3 = setVisible(visible: false);
		bool flag2 = _indexInWeapon == 0;
		ParticleSystem fwEmitter;
		string item;
		List<string> list2;
		if (!flag2)
		{
			object obj4 = _indexInWeapon - 1;
			if (!flag2)
			{
				if ((nint)obj4 != 1)
				{
					goto IL_028e;
				}
				fwEmitter = _fwEmitter;
				List<string> list = new List<string>();
				list.Add("2Spell3Red");
				item = "2Spell4Red";
				list2 = list;
			}
			else
			{
				fwEmitter = _fwEmitter;
				List<string> list3 = new List<string>();
				list3.Add("2Spell3Purple");
				item = "2Spell4Purple";
				list2 = list3;
			}
		}
		else
		{
			fwEmitter = _fwEmitter;
			List<string> list4 = new List<string>();
			list4.Add("2Spell3Blue");
			item = "2Spell4Blue";
			list2 = list4;
		}
		list2.Add(item);
		int cycleCount = default(int);
		RenderingExtensions.SetFrames(fwEmitter, list2, null, clearExistingFrames: false, cycleCount);
		goto IL_028e;
	}

	private unsafe void Detonate()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_0e7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e82: Expected O, but got Unknown
		//IL_01a6: Expected O, but got I4
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_0512: Expected I, but got O
		//IL_0eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef0: Expected O, but got Unknown
		//IL_0692: Expected I, but got O
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_0418: Expected F4, but got I
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f49: Expected O, but got Unknown
		//IL_0f6c: Expected O, but got I4
		//IL_07c7: Expected I, but got O
		//IL_08ca: Expected I, but got O
		//IL_099d: Expected I, but got O
		//IL_0a26: Expected O, but got I
		//IL_0a55: Expected O, but got I
		//IL_0ac9: Expected O, but got I
		//IL_0ae7: Expected O, but got I4
		//IL_0b5e: Expected O, but got I
		//IL_0c00: Expected I, but got O
		//IL_0c89: Expected O, but got I
		//IL_0cb8: Expected O, but got I
		//IL_0d3e: Expected I, but got O
		//IL_0ddd: Expected O, but got I
		//IL_01ca->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0222->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0460->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_024c->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_048c->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0500->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_04de->IL04de: Incompatible stack heights: 2 vs 1
		//IL_02b6->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_05b1->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0680->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0605->IL0605: Incompatible stack heights: 2 vs 1
		//IL_065e->IL065e: Incompatible stack heights: 2 vs 1
		//IL_0715->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0741->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0f71->IL0ea2: Incompatible stack heights: 9 vs 1
		//IL_07b5->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0793->IL0793: Incompatible stack heights: 2 vs 1
		//IL_0842->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_08b8->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0896->IL0896: Incompatible stack heights: 2 vs 1
		//IL_0947->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0973->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_09e2->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_09c0->IL09c0: Incompatible stack heights: 2 vs 1
		//IL_0bf3->IL0e4a: Incompatible stack heights: 1 vs 0
		//IL_0c45->IL0e4a: Incompatible stack heights: 2 vs 0
		//IL_0d31->IL0e4a: Incompatible stack heights: 2 vs 0
		//IL_0d83->IL0e4a: Incompatible stack heights: 3 vs 0
		if ((object)_ringRenderer != null)
		{
			_ringRenderer.enabled = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 1f);
			if ((object)spriteRenderer2 != null)
			{
				Transform transform = spriteRenderer2.transform;
				if ((object)transform != null)
				{
					_ = -0f;
					object obj = default(object);
					Vector3 localEulerAngles = (Vector3)(obj - 80);
					transform.localEulerAngles = localEulerAngles;
					if ((object)_ringRenderer != null)
					{
						Transform transform2 = _ringRenderer.transform;
						float2 float5 = base.position;
						float2 float6 = base.position;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj2 = obj - 80;
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj2);
						GameManager core = GM.Core;
						PlayerOptionsData config = core._playerOptions.Config;
						object obj4 = default(object);
						if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
						{
							SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_raysRenderer, 0.5f);
							object obj3 = obj4;
							float num = 0.5f;
							object obj5 = 0;
							goto IL_0ea2;
						}
						if ((object)_rainbowRenderer != null)
						{
							_rainbowRenderer.enabled = true;
							SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
							SpriteRenderer spriteRenderer5 = RenderingExtensions.SetAlpha(spriteRenderer4, 0.75f);
							if ((object)spriteRenderer5 != null)
							{
								Transform transform3 = spriteRenderer5.transform;
								if ((object)transform3 != null)
								{
									_ = -0f;
									Vector3 localEulerAngles2 = (Vector3)(obj - 80);
									transform3.localEulerAngles = localEulerAngles2;
									Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
									((Renderer)spriteRenderer5).SetMaterial(material);
									if ((object)_rainbowRenderer != null)
									{
										Transform transform4 = _rainbowRenderer.transform;
										float2 float7 = base.position;
										float2 float8 = base.position;
										bool flag2 = (object)transform4 == null;
										_ = 0;
										bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										object obj6 = obj - 80;
										Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj6);
										bool flag4 = (object)_raysRenderer == null;
										_raysRenderer.enabled = true;
										SpriteRenderer spriteRenderer6 = RenderingExtensions.SetScale(_raysRenderer, 0f);
										SpriteRenderer spriteRenderer7 = RenderingExtensions.SetAlpha(spriteRenderer6, 1f);
										bool flag5 = (object)spriteRenderer7 == null;
										Transform transform5 = spriteRenderer7.transform;
										bool flag6 = (object)transform5 == null;
										_ = -0f;
										Vector3 localEulerAngles3 = (Vector3)(obj - 64);
										transform5.localEulerAngles = localEulerAngles3;
										bool flag7 = (object)_raysRenderer == null;
										Transform transform6 = _raysRenderer.transform;
										float2 float9 = base.position;
										float2 float10 = base.position;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+24]");
										float num = 0f;
										bool flag8 = (object)transform6 == null;
										_ = 0;
										bool flag9 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
										object obj7 = obj - 64;
										Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj7);
										object obj3 = obj4;
										object obj5 = 0;
										goto IL_0ea2;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0e4a;
		IL_0ea2:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringRenderer != null)
		{
			Transform transform7 = _ringRenderer.transform;
			if (array != null)
			{
				if ((object)transform7 != null)
				{
					void* value = ((IntPtr*)(&array))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					bool flag10 = obj8 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
					_ = 1120403456;
					_ = 0;
					_ = 1082130432;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
					_ = 0;
					_ = 1135869952;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
					_ = 0;
					MultiTargetTween ttween = Tweens.Add(tweenConfig);
					_ttween1 = ttween;
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[2];
					if (array2 != null)
					{
						if ((object)_ringRenderer != null)
						{
							void* value2 = ((IntPtr*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj9 = default(object);
							bool flag11 = obj9 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if ((object)_raysRenderer != null)
						{
							void* value3 = ((IntPtr*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj10 = default(object);
							bool flag12 = obj10 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
							_ = 0;
							_ = 1120403456;
							_ = 1120403456;
							MultiTargetTween ttween2 = Tweens.Add(tweenConfig2);
							_ttween2 = ttween2;
							TweenConfig tweenConfig3 = new TweenConfig();
							object[] array3 = new object[1];
							if ((object)_raysRenderer != null)
							{
								Transform transform8 = _raysRenderer.transform;
								if (array3 != null)
								{
									if ((object)transform8 != null)
									{
										void* value4 = ((IntPtr*)(&array3))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj11 = default(object);
										bool flag13 = obj11 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig3 != null)
									{
										((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
										_ = 0;
										_ = 1077936128;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
										_ = 0;
										_ = 1120403456;
										MultiTargetTween ttween3 = Tweens.Add(tweenConfig3);
										_ttween3 = ttween3;
										TweenConfig tweenConfig4 = new TweenConfig();
										object[] array4 = new object[1];
										if (array4 != null)
										{
											if ((object)_rainbowRenderer != null)
											{
												void* value5 = ((IntPtr*)(&array4))->m_value;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj12 = default(object);
												bool flag14 = obj12 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig4 != null)
											{
												((UnityEngine.Object)(object)tweenConfig4).m_CachedPtr = (IntPtr)array4;
												_ = 0;
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
												_ = 0;
												_ = 1140457472;
												MultiTargetTween ttween4Alpha = Tweens.Add(tweenConfig4);
												_ttween4Alpha = ttween4Alpha;
												TweenConfig tweenConfig5 = new TweenConfig();
												object[] array5 = new object[1];
												if ((object)_rainbowRenderer != null)
												{
													Transform transform9 = _rainbowRenderer.transform;
													if (array5 != null)
													{
														if ((object)transform9 != null)
														{
															nint num2 = (nint)array5;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj13 = default(object);
															bool flag15 = obj13 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig5 != null)
														{
															tweenConfig5.targets = array5;
															_ = 0;
															_ = 1084227584;
															_ = 1;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
															tweenConfig5.scale = (float?)(object)0;
															tweenConfig5.duration = 500f;
															_ = 1135869952;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
															tweenConfig5.angle = (float?)(object)0;
															TweenCallback onComplete = delegate
															{
																Despawn();
															};
															tweenConfig5.onComplete = onComplete;
															MultiTargetTween ttween4 = Tweens.Add(tweenConfig5);
															_ttween4 = ttween4;
															SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
															_ = 0;
															_ = 1056964608;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
															soundConfig.Volume = (float?)(object)0;
															soundConfig.Rate = 1f;
															object obj14 = _indexInWeapon - 5;
															float detune = (float)obj14 * 100f;
															soundConfig.Detune = detune;
															float time = default(float);
															PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion2, soundConfig, 150f, 3, time);
															SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
															_ = 0;
															_ = 1036831949;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
															soundConfig2.Volume = (float?)(object)0;
															soundConfig2.Rate = 1f;
															float detune2 = (float)_indexInWeapon * 100f;
															soundConfig2.Rate = 1.5f;
															soundConfig2.Detune = detune2;
															PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Whistle, soundConfig2, 150f, 3, time);
															TweenConfig tweenConfig6 = new TweenConfig();
															object[] array6 = new object[1];
															if (array6 != null)
															{
																nint num3 = (nint)array6;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj15 = default(object);
																bool flag16 = obj15 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig6 != null)
																{
																	tweenConfig6.targets = array6;
																	_ = 0;
																	_ = 1065353216;
																	_ = 1;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
																	tweenConfig6.scale = (float?)(object)0;
																	tweenConfig6.duration = 120f;
																	_ = 1036831949;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
																	tweenConfig6.alpha = (float?)(object)0;
																	TweenCallback onComplete2 = delegate
																	{
																		_fwEmitter.Stop();
																		BaseBody baseBody = body;
																		baseBody._enable = false;
																	};
																	tweenConfig6.onComplete = onComplete2;
																	MultiTargetTween ttween5 = Tweens.Add(tweenConfig6);
																	_ttween5 = ttween5;
																	TweenConfig tweenConfig7 = new TweenConfig();
																	object[] array7 = new object[1];
																	if (array7 != null)
																	{
																		nint num4 = (nint)array7;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj16 = default(object);
																		bool flag17 = obj16 == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig7 != null)
																		{
																			tweenConfig7.targets = array7;
																			_ = 0;
																			tweenConfig7.duration = 100f;
																			tweenConfig7.delay = 200f;
																			_ = 1036831949;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
																			tweenConfig7.alpha = (float?)(object)0;
																			TweenCallback onStart = delegate
																			{
																				//IL_0085->IL0093: Incompatible stack heights: 1 vs 0
																				GameManager core2 = GM.Core;
																				PlayerOptionsData config2 = core2._playerOptions.Config;
																				if (config2._003CFlashingVFXEnabled_003Ek__BackingField)
																				{
																					Transform transform10 = _fwEmitter.transform;
																					float2 float11 = base.position;
																					float2 float12 = base.position;
																					bool flag18 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
																					Vector3 value6 = default(Vector3);
																					Transform.set_position_Injected(((UnityEngine.Object)transform10).m_CachedPtr, ref value6);
																					RenderingExtensions.Start(_fwEmitter);
																				}
																			};
																			tweenConfig7.onStart = onStart;
																			TweenCallback onComplete3 = delegate
																			{
																				_fwEmitter.Stop();
																			};
																			tweenConfig7.onComplete = onComplete3;
																			MultiTargetTween ttween6 = Tweens.Add(tweenConfig7);
																			_ttween6 = ttween6;
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
						}
					}
				}
			}
		}
		goto IL_0e4a;
		IL_0e4a:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (!_isDespawning)
		{
			_isDespawning = true;
			Action onComplete = delegate
			{
				_isDespawning = false;
				_alreadyRecycled = false;
				_isCullable = true;
				_fwEmitter.Stop();
				base.Despawn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(2.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void _003CDetonate_003Eb__20_0()
	{
		Despawn();
	}

	private void _003CDetonate_003Eb__20_1()
	{
		_fwEmitter.Stop();
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CDetonate_003Eb__20_2()
	{
		//IL_0085->IL0093: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			Transform transform = _fwEmitter.transform;
			float2 float5 = base.position;
			float2 float6 = base.position;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			RenderingExtensions.Start(_fwEmitter);
		}
	}

	private void _003CDetonate_003Eb__20_3()
	{
		_fwEmitter.Stop();
	}

	private void _003CDespawn_003Eb__21_0()
	{
		_isDespawning = false;
		_alreadyRecycled = false;
		_isCullable = true;
		_fwEmitter.Stop();
		base.Despawn();
	}
}
