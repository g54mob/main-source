using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class StarryHeavensWeapon : Weapon
{
	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private MultiTargetTween _tween1;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00dc: Expected O, but got I
		//IL_01dc: Expected O, but got Ref
		//IL_01f6: Expected native int or pointer, but got O
		//IL_05e6: Expected O, but got I4
		//IL_0214: Expected O, but got Ref
		//IL_0235: Expected O, but got I
		//IL_0244: Expected O, but got I4
		//IL_024d: Expected native int or pointer, but got O
		//IL_0267: Expected O, but got I
		//IL_027f: Expected O, but got Ref
		//IL_0299: Expected native int or pointer, but got O
		//IL_02b3: Expected O, but got I
		//IL_02d3: Expected O, but got Ref
		//IL_02ed: Expected native int or pointer, but got O
		//IL_0603: Expected O, but got I4
		//IL_0305: Expected O, but got Ref
		//IL_031f: Expected native int or pointer, but got O
		//IL_062d: Expected O, but got I
		//IL_0357: Expected O, but got Ref
		//IL_0371: Expected native int or pointer, but got O
		//IL_0667: Expected O, but got I
		//IL_03d0: Expected O, but got I
		//IL_0431: Expected I4, but got I8
		//IL_04ad: Expected I, but got O
		//IL_0512: Expected O, but got Ref
		//IL_0574: Expected I4, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		base._003CTotalTime_003Ek__BackingField = 0f;
		if (_initialisedParticles)
		{
			return;
		}
		_initialisedParticles = true;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 120f;
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager pfxEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
			pfxEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxEmitterManager = pfxEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blur3");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(-100f, 100f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 20;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(300f, 600f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1.5f, 2.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1.5f, 10.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = true;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = circle;
		particleSystemConfig._emitZone = emitZone;
		ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
		ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(-1);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_pfxEmitter != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 1135869952;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_overrideRotation", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 1000f;
		tweenConfig.repeat = -1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
	}

	public override void InternalUpdate()
	{
		//IL_00c1->IL0070: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_pfxEmitterManager != null)
				{
					Vector2 pos = default(Vector2);
					_pfxEmitterManager.EmitParticleAt(pos);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
