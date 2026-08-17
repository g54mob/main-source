using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyEye : EnemyController
{
	private Circle _explosionCircle;

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	private float _totalTime;

	private const float Radius = 16f;

	private const float EmitInterval = 0.030000001f;

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystems();
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00c3: Expected O, but got Ref
		//IL_00f9: Expected O, but got Ref
		base.InitEnemy(enemyType, asRemote);
		object cachedTransform = _cachedTransform;
		_totalTime = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (System.Object)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
		Circle circle = new Circle();
		float radius = (float)ret * 16f;
		circle._x = 0f;
		circle._radius = radius;
		_explosionCircle = circle;
		RenderingExtensions.SetEmitZone(emitZone: new EmitZone
		{
			_type = EmitZoneType.Random,
			_source = _explosionCircle
		}, pfx: _emitter1);
		RenderingExtensions.SetEmitZone(emitZone: new EmitZone
		{
			_type = EmitZoneType.Edge,
			_source = _explosionCircle
		}, pfx: _emitter2);
		float min = (float)ret * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
		object obj = default(object);
		RenderingExtensions.SetScale(_emitter1, (ParticleSystem.MinMaxCurve)(&obj));
		float min2 = (float)ret * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(min2, 0f);
		RenderingExtensions.SetScale(_emitter2, (ParticleSystem.MinMaxCurve)(&obj));
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0211: Invalid comparison between O and F4
		//IL_00cf: Expected O, but got I4
		//IL_02e0: Expected O, but got Ref
		//IL_023f->IL01a2: Incompatible stack heights: 1 vs 0
		//IL_0099->IL01a2: Incompatible stack heights: 1 vs 0
		//IL_016b->IL01a2: Incompatible stack heights: 1 vs 0
		//IL_035f->IL0225: Incompatible stack heights: 6 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.OnUpdate();
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
			{
				return;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num = (_totalTime = deltaTime + _totalTime);
			if (num > 0.030000001f)
			{
				object cachedTransform2 = _cachedTransform;
				float totalTime = num - 0.030000001f;
				_totalTime = totalTime;
				if ((object)_cachedTransform == null)
				{
					goto IL_01a2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v17 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v17 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				object emitter = _emitter1;
				_ = 0;
				_ = 1;
				_ = 1;
				bool flag3 = (object)_emitter1 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
				_ = 0;
				_ = 0;
				_ = 0;
				obj = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rdi_v18 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rdi_v18 (System.Object)+10]");
				ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj3, 1);
				object emitter2 = _emitter2;
				bool flag5 = (object)_emitter2 == null;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdi_v19 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdi_v19 (System.Object)+10]");
				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
				ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 1);
			}
			if ((object)_EnemyRenderer != null)
			{
				int sortingOrder = _EnemyRenderer.sortingOrder;
				int num2 = sortingOrder - 1;
				RenderingExtensions.SetDepth(_emitter1, num2);
				if ((object)_EnemyRenderer != null)
				{
					int sortingOrder2 = _EnemyRenderer.sortingOrder;
					int num3 = sortingOrder2 - 1;
					RenderingExtensions.SetDepth(_emitter2, num3);
					return;
				}
			}
		}
		goto IL_01a2;
		IL_01a2:
		throw new NullReferenceException();
	}

	protected override void Die()
	{
		base.Die();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a7: Expected O, but got I
		//IL_049a: Expected O, but got Ref
		//IL_04b4: Expected native int or pointer, but got O
		//IL_04ce: Expected O, but got I
		//IL_04ee: Expected O, but got Ref
		//IL_0508: Expected native int or pointer, but got O
		//IL_0c64: Expected O, but got I4
		//IL_0539: Expected O, but got I
		//IL_0555: Expected O, but got I4
		//IL_056e: Expected O, but got Ref
		//IL_0588: Expected native int or pointer, but got O
		//IL_0c81: Expected O, but got I4
		//IL_05ba: Expected O, but got Ref
		//IL_05d4: Expected native int or pointer, but got O
		//IL_0cbb: Expected O, but got I
		//IL_0a31: Expected O, but got Ref
		//IL_0a4b: Expected native int or pointer, but got O
		//IL_0a65: Expected O, but got I
		//IL_0a85: Expected O, but got Ref
		//IL_0a9f: Expected native int or pointer, but got O
		//IL_0d07: Expected O, but got I
		//IL_0af0: Expected O, but got I
		//IL_0b0c: Expected O, but got I4
		//IL_0b25: Expected O, but got Ref
		//IL_0b3f: Expected native int or pointer, but got O
		//IL_0d41: Expected O, but got I
		//IL_0b77: Expected O, but got Ref
		//IL_0b91: Expected native int or pointer, but got O
		//IL_0d73: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Circle circle = (_explosionCircle = new Circle());
		circle._x = 0f;
		circle._radius = 16f;
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
			particleEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particleEmitterManager = particleEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood1");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood2");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood3");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"h");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"a");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"s");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(15f, 30f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(550f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem emitter = _particleEmitterManager.CreateEmitter(particleSystemConfig, null, "Emitter1");
		_emitter1 = emitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version7 = list2._version + 1;
		list2._version = version7;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Blood1");
		}
		else
		{
			int num8 = list2._size + 1;
			list2._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list2._version + 1;
		list2._version = version8;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Blood2");
		}
		else
		{
			int num9 = list2._size + 1;
			list2._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list2._version + 1;
		list2._version = version9;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Blood3");
		}
		else
		{
			int num10 = list2._size + 1;
			list2._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list2._version + 1;
		list2._version = version10;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"t");
		}
		else
		{
			int num11 = list2._size + 1;
			list2._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list2._version + 1;
		list2._version = version11;
		string[] items11 = list2._items;
		if (list2._size >= items11.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"u");
		}
		else
		{
			int num12 = list2._size + 1;
			list2._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list2._version + 1;
		list2._version = version12;
		string[] items12 = list2._items;
		if (list2._size >= items12.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"r");
		}
		else
		{
			int num13 = list2._size + 1;
			list2._size = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(15f, 30f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
		particleSystemConfig2._quantity = (int?)(object)0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(550f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
		_ = 0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Edge;
		emitZone2._source = _explosionCircle;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem emitter2 = _particleEmitterManager.CreateEmitter(particleSystemConfig2, null, "Emitter2");
		_emitter2 = emitter2;
	}
}
