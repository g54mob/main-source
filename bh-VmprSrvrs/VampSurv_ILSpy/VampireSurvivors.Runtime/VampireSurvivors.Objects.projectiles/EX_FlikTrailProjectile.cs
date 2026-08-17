using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using VampireSurvivors.App.Scripts.Framework.Curves;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_FlikTrailProjectile : Projectile
{
	private TrailRenderer _trail;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxEmitter;

	private bool _expired;

	private float _updateLoops;

	private MultiTargetTween _fadeTrailTween;

	private MultiTargetTween _angleTween;

	private Vector2 _startingPoint;

	public float angleLerp;

	private float _trailTime;

	private EX_FlikTrailWeapon _trueWeapon;

	private EnemyController _enemy;

	private List<Vector3> _trailPositions;

	public void SetEnemy(EnemyController enemy)
	{
		_enemy = enemy;
	}

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a8: Expected O, but got I
		//IL_0254: Expected O, but got Ref
		//IL_0269: Expected native int or pointer, but got O
		//IL_03ed: Expected O, but got I
		//IL_02a1: Expected O, but got Ref
		//IL_02c8: Expected O, but got I
		//IL_02dd: Expected native int or pointer, but got O
		//IL_02f7: Expected O, but got I
		//IL_0317: Expected O, but got Ref
		//IL_0331: Expected native int or pointer, but got O
		//IL_0427: Expected O, but got I
		//IL_03a3: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileGreen1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		_ = 0;
		ParticleEmitterManager pfxManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
			pfxManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxManager = pfxManager;
		((UnityEngine.Object)_pfxManager).SetName("PfxManager (Spellstring)");
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxLightGreen");
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
			((List<object>)(object)list).AddWithResize((object)"PfxGreen");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(120f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+27]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-11]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-1]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _pfxManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
		InitTrail();
		_startingPoint = (Vector2)0;
		List<Vector3> trailPositions = new List<Vector3>();
		_trailPositions = trailPositions;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_02dc: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_03f9;
		}
		nint num = (nint)typeof(EX_FlikTrailWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_FlikTrailWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_FlikTrailWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v81+FFFFFFF8+v69 @ rax_v76*8]");
			if (0 == (nint)typeof(EX_FlikTrailWeapon))
			{
				obj3 = 1;
				goto IL_0408;
			}
		}
		obj3 = 0;
		goto IL_0408;
		IL_0408:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_03f9;
		IL_03f9:
		_trueWeapon = (EX_FlikTrailWeapon)trueWeapon;
		List<Vector3> trailPositions = _trailPositions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		Sprite sprite = SpriteManager.GetSprite("vfx_dragonHead03", "vfx");
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
		ArcadeSprite arcadeSprite3 = setAlpha(0.65f);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_renderer).SetMaterial(material);
		BaseBody baseBody = body;
		_expired = false;
		_updateLoops = 0f;
		baseBody._enable = false;
		_trail.enabled = true;
		float2 startingPoint = base.position;
		_startingPoint = startingPoint;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SpellString, soundConfig, 200f, 4, time);
		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 1f);
		Material material2 = ((Renderer)_trail).GetMaterial();
		RenderingExtensions.SetAlpha(material2, 1f);
		_trail.emitting = true;
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"angleLerp", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 120f;
			TweenCallback onStart = delegate
			{
				//IL_000e: Expected O, but got F4
				object obj5 = UnityEngine.Random.value;
				object obj6 = default(object);
				float num5 = (float)obj6 - 0.5f;
				float num6 = num5 + num5;
				angleLerp = num6;
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween angleTween = Tweens.Add(tweenConfig);
			_angleTween = angleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00f1: Expected I4, but got O
		//IL_0e78: Expected O, but got Ref
		//IL_024d: Expected O, but got I
		//IL_02e4: Expected O, but got I
		//IL_032a: Expected O, but got I
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_02a8: Expected O, but got Ref
		//IL_03b8: Expected O, but got I
		//IL_03d5: Expected O, but got I
		//IL_03ec: Expected O, but got I
		//IL_03fa: Invalid comparison between O and F4
		//IL_120b: Expected O, but got I
		//IL_0f38: Expected O, but got F4
		//IL_0f09: Expected I, but got O
		//IL_0f2a: Expected O, but got I
		//IL_06b5: Expected F4, but got I
		//IL_06c5: Expected F4, but got I
		//IL_06d5: Expected O, but got I
		//IL_0458: Expected O, but got I
		//IL_0465: Expected O, but got I
		//IL_0926: Expected O, but got I
		//IL_0732: Expected O, but got I
		//IL_058e: Expected O, but got I
		//IL_0a81: Expected O, but got Ref
		//IL_09b4: Expected O, but got I
		//IL_09fa: Expected O, but got I
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_0981: Expected O, but got Ref
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_07b5: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0ba4: Expected O, but got F4
		//IL_0673: Expected O, but got I
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_06a0: Expected O, but got F4
		//IL_05ea: Expected O, but got Ref
		//IL_0611: Expected O, but got F4
		//IL_0853: Expected O, but got I
		//IL_0899: Expected O, but got I
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ae: Expected O, but got Unknown
		//IL_0810: Expected O, but got Ref
		//IL_0fd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd5: Expected O, but got Unknown
		//IL_11df: Expected O, but got I
		//IL_0d32: Expected O, but got I
		//IL_0d93: Expected I4, but got I8
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da1: Expected O, but got Unknown
		//IL_00c7->IL0df5: Incompatible stack heights: 1 vs 0
		//IL_0107->IL0df5: Incompatible stack heights: 2 vs 0
		//IL_02ce->IL0ed6: Incompatible stack heights: 11 vs 12
		//IL_0a1f->IL1017: Incompatible stack heights: 17 vs 15
		//IL_099e->IL1017: Incompatible stack heights: 16 vs 15
		//IL_06a5->IL0f86: Incompatible stack heights: 20 vs 14
		//IL_0617->IL0f86: Incompatible stack heights: 19 vs 14
		//IL_083d->IL0fbd: Incompatible stack heights: 20 vs 21
		//IL_08e0->IL0ff0: Incompatible stack heights: 22 vs 15
		//IL_0dae->IL11c9: Incompatible stack heights: 32 vs 29
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float num = ++_updateLoops;
		bool flag = _expired;
		IntPtr intPtr = default(IntPtr);
		int sortingOrder = (int)(nint)intPtr;
		if (!flag)
		{
			bool flag2 = num < 3f;
			sortingOrder = (int)(nint)intPtr;
			if (!flag2)
			{
				_expired = true;
				FadeOut();
				bool flag3 = _enemy;
				bool flag4 = !flag3;
				sortingOrder = 0;
				if (!flag4)
				{
					EnemyController enemy = _enemy;
					bool flag5 = (object)_enemy == null;
					bool flag6 = enemy._003CIsDead_003Ek__BackingField;
					sortingOrder = 0;
					if (!flag6)
					{
						bool flag7 = (object)_trueWeapon == null;
						sortingOrder = (int)_enemy;
						_trueWeapon.DealDamage(_enemy);
					}
				}
			}
		}
		Weapon weapon = _weapon;
		bool flag8 = (object)_weapon == null;
		bool flag9 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = base.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag10 = ArcadePhysics.s_scene == null;
		bool flag11 = s_scene._renderer == null;
		bool flag12 = (object)_trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
		_trail.sortingOrder = sortingOrder;
		List<Vector3> targetTransform = (List<Vector3>)(object)_targetTransform;
		bool flag13 = (object)_targetTransform == null;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdi_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		bool flag14 = (nint)0 == 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdi_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-71]");
		_ = 0;
		List<Vector3> list = new List<Vector3>();
		Weapon weapon2 = _weapon;
		bool flag15 = (object)_weapon == null;
		bool flag16 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
		float2 float7 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		bool flag17 = list == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		Vector3 item = (Vector3)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		bool flag18 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v24 (UnityEngine.Vector3)+18]");
		float2 float8;
		float2 float9 = default(float2);
		if (num2 >= 0)
		{
			item = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = 0;
			list.AddWithResize(item);
			float8 = float9;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v24 (UnityEngine.Vector3)+18]");
			bool flag19 = num3 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj5 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj6 = 0 + obj5;
			_ = 0;
			float8 = float9;
		}
		Weapon weapon3 = _weapon;
		bool flag20 = (object)_weapon == null;
		bool flag21 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
		float2 float10 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
		nint num4 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		object obj7 = num5 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+6B]");
		object obj8 = num6 - 0;
		((List<Vector3>)num4).Add(item);
		object obj9;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
		{
			obj9 = obj8 / (object)float8;
		}
		else
		{
			nint num7 = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1633 @ rax_v135 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v45 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			obj9 = 0;
		}
		((List<Vector3>)num4).Add(item);
		object obj10 = UnityEngine.Random.value;
		float num8 = (float)obj9 - 0.5f;
		float num9 = num8 * ((float)Math.PI / 2f);
		float num10 = num9 + (float)obj9;
		float num19;
		nint num21 = default(nint);
		Vector2 vector;
		if (!(2f < _updateLoops))
		{
			EX_FlikTrailWeapon trueWeapon = _trueWeapon;
			bool flag22 = (object)_trueWeapon == null;
			((List<Vector3>)num4).Add(item);
			((List<Vector3>)num4).Add(item);
			float num11 = trueWeapon._range * 0.35f;
			float num12 = num11 * _updateLoops;
			float num13 = num12 * num10;
			float num14 = num12 * num10;
			float num15 = num12 * 0f;
			Weapon weapon4 = _weapon;
			bool flag23 = (object)_weapon == null;
			bool flag24 = (object)((Equipment)weapon4)._003COwner_003Ek__BackingField == null;
			float2 float11 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
			float num16 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
			float num17 = num16 + 0f;
			float num18 = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+6B]");
			num19 = num18 + 0f;
			List<Vector3> trailPositions = _trailPositions;
			bool flag25 = _trailPositions == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			bool flag26 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rdx_v54+18]");
			if (num20 >= 0)
			{
				Vector3 item2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				_trailPositions.AddWithResize(item2);
				num21 = 0;
				vector = (Vector2)num17;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj12 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rdx_v54+18]");
				bool flag27 = num22 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj13 = (nint)0 * (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v107 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj14 = 0 + obj13;
				num21 = 0;
				vector = (Vector2)num17;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
			float num15 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
			num19 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
			vector = (Vector2)0;
		}
		List<Vector3> trailPositions2 = _trailPositions;
		bool flag28 = _trailPositions == null;
		object obj15 = null;
		nint num23 = num21;
		object obj16 = null;
		while (true)
		{
			object obj17 = obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v58 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			if ((nint)obj17 >= 0)
			{
				break;
			}
			List<Vector3> trailPositions3 = _trailPositions;
			bool flag29 = _trailPositions == null;
			object obj18 = obj15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v49 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag30 = (nint)obj18 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v49 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v49 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			bool flag31 = (nint)0 == 0;
			object obj20 = obj15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v50+18]");
			bool flag32 = (nint)obj20 >= 0;
			object obj21 = obj15 * 2;
			object obj22 = obj15 + obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			bool flag33 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			nint num24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdx_v51+18]");
			if (num24 >= 0)
			{
				Vector3 item3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v50+28+v1825 @ rcx_v99*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v50+20+v1825 @ rcx_v99*4]");
				_ = 0;
				list.AddWithResize(item3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj24 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				nint num25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdx_v51+18]");
				bool flag34 = num25 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj25 = (nint)0 * (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj26 = 0 + obj25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v50+20+v1825 @ rcx_v99*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v50+28+v1825 @ rcx_v99*4]");
				_ = 0;
			}
			trailPositions2 = _trailPositions;
			obj15++;
			bool flag35 = _trailPositions == null;
			num23 = 0;
			obj16 = obj15;
		}
		if (_updateLoops > 3f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			bool flag36 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			nint num26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v47+18]");
			if (num26 >= 0)
			{
				Vector3 item4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				list.AddWithResize(item4);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj28 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v47+18]");
				bool flag37 = num27 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj29 = (nint)0 * (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj30 = 0 + obj29;
			}
		}
		base.position = float9;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		bool flag38 = (object)cachedTrans == null;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		float num28 = num10 * 57.29578f;
		_ = localEulerAngles.z;
		Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
		bool flag39 = (object)cachedTrans2 == null;
		Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = localEulerAngles.x;
		cachedTrans2.localEulerAngles = localEulerAngles2;
		float num29 = angleLerp * 0.5f;
		float num30 = num29 * -4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		object obj31 = vector - _startingPoint;
		float num31 = num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile)+104]");
		float num32 = num31 - 0f;
		float num33 = (float)obj31 * num30;
		float num34 = (float)obj31 * num30;
		float num35 = num32 * num30;
		float num36 = num32 * num30;
		float num37 = num33 - num35;
		float num38 = num36 + num34;
		float num39 = num37 + (float)_startingPoint;
		float num40 = num38;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile)+104]");
		float num41 = num40 + 0f;
		QuadraticBezierCurve quadraticBezierCurve = null;
		quadraticBezierCurve._p0 = vector;
		quadraticBezierCurve._p1 = (Vector2)num39;
		quadraticBezierCurve._p2 = _startingPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile)+104]");
		_ = 0;
		bool flag40 = quadraticBezierCurve == null;
		Vector3[] points = quadraticBezierCurve.GetPoints(9);
		object trail = _trail;
		bool flag41 = (object)_trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r14_v13 (System.Object)+10]");
		bool flag42 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r14_v13 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049EA70");
		bool flag43 = (object)_trail == null;
		Vector3[] positions = default(Vector3[]);
		_trail.AddPositions(positions);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
		object trail2 = _trail;
		bool flag44 = (object)_trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r14_v15 (System.Object)+10]");
		bool flag45 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r14_v15 (System.Object)+10]");
		IntPtr material_Injected = Renderer.GetMaterial_Injected((IntPtr)0);
		Material material = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
		object trail3 = _trail;
		bool flag46 = (object)_trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r14_v16 (System.Object)+10]");
		bool flag47 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r14_v16 (System.Object)+10]");
		IntPtr material_Injected2 = Renderer.GetMaterial_Injected((IntPtr)0);
		Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected2);
		bool flag48 = (object)material2 == null;
		int num42 = material2.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
		if (num42 < 0)
		{
			num42 = Material.k_MainTexId;
		}
		Texture textureImpl = material2.GetTextureImpl(num42);
		bool flag49 = (object)textureImpl == null;
		int width = textureImpl.width;
		bool flag50 = (object)material == null;
		int num43 = Shader.PropertyToID("_MainTex");
		material.SetTextureScaleImpl(num43, (Vector2)float9);
		List<Vector3> evenlySpacedPoints = CurveUtils.GetEvenlySpacedPoints(list, 7);
		bool flag51 = evenlySpacedPoints == null;
		object obj32 = null;
		object obj33 = null;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v94 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj34 = -1;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj33) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj34))
			{
				object obj35 = obj32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v94 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				bool flag52 = (nint)obj35 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v94 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v94 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				bool flag53 = (nint)0 == 0;
				object obj37 = obj32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rcx_v82+18]");
				bool flag54 = (nint)obj37 >= 0;
				RenderingExtensions.EmitParticleAt(_pfxEmitter, float9, -1);
				obj32++;
				obj33 = obj32;
				continue;
			}
			break;
		}
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		_trail.enabled = false;
		base.Despawn();
	}

	private void InitTrail()
	{
		//IL_0163->IL0111: Incompatible stack heights: 1 vs 0
		//IL_00a2->IL0111: Incompatible stack heights: 1 vs 0
		//IL_01df->IL0111: Incompatible stack heights: 2 vs 0
		//IL_00da->IL0111: Incompatible stack heights: 2 vs 0
		Sprite sprite = SpriteManager.GetSprite("vfx_dragon_trail", "vfx");
		TrailRenderer trail = _trail;
		if ((object)_trail != null)
		{
			bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
			if ((object)_trail != null)
			{
				_trail.emitting = true;
				RenderingExtensions.SetMaterialToPackedSprite(_trail, sprite, autoSetTrailWidth: true, additive: true);
				TrailRenderer trail2 = _trail;
				if ((object)_trail != null)
				{
					bool flag2 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
					TrailRenderer.set_textureMode_Injected(((UnityEngine.Object)trail2).m_CachedPtr, LineTextureMode.Stretch);
					float num = _speed * 0.5f;
					float time = (_trailTime = num * 0.01f);
					if ((object)_trail != null)
					{
						_trail.time = time;
						if ((object)_trail != null)
						{
							Material material = ((Renderer)_trail).GetMaterial();
							RenderingExtensions.SetAlpha(material, 1f);
							TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		_expired = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x187268E20\"");
	}

	private void FadeOut()
	{
		//IL_00a9: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_0112: Expected O, but got I4
		if (_fadeTrailTween != null)
		{
			_fadeTrailTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Material material = ((Renderer)_trail).GetMaterial();
		if ((object)material != null)
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
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				Material material2 = ((Renderer)_trail).GetMaterial();
				RenderingExtensions.SetAlpha(material2, 1f);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween fadeTrailTween = Tweens.Add(tweenConfig);
			_fadeTrailTween = fadeTrailTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private Vector2 Rotate_point(float targetX, float targetY, float angle, Vector2 origin)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Vector2 result = default(Vector2);
		return result;
	}

	public EX_FlikTrailProjectile()
	{
		List<Vector3> trailPositions = new List<Vector3>();
		_trailPositions = trailPositions;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__15_0()
	{
		//IL_000e: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float num2 = num + num;
		angleLerp = num2;
	}

	private void _003CFadeOut_003Eb__20_0()
	{
		Material material = ((Renderer)_trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 1f);
	}

	private void _003CFadeOut_003Eb__20_1()
	{
		Despawn();
	}
}
