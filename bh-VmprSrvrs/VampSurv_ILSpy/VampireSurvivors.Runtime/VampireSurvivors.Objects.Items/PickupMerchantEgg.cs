using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class PickupMerchantEgg : Pickup
{
	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _pfxEmitter;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		GenerateParticleSystem();
	}

	public override void SetData(ItemType itemType)
	{
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		base.SetData(itemType);
		base.GoToPlayer = true;
		base._003CIsStationary_003Ek__BackingField = true;
		SetFrame("Eggman");
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			base._003CResRosary_003Ek__BackingField = 1f;
			RenderingExtensions.Start(_pfxEmitter);
			if ((object)_pfxEmitter != null)
			{
				Transform transform = _pfxEmitter.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v23 (UnityEngine.Transform)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v23 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)0, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float2 float5 = SafeXY();
		base.position = float5;
	}

	public override void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (_ShowAboveAll)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
		int num2 = base.Depth;
		int num3 = num2 - 1;
		ParticleEmitterManager particleEmitterManager = _particleEmitterManager.SetDepth(num3);
	}

	public override void GetTaken()
	{
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			RenderingExtensions.StopEmitting(_pfxEmitter);
			_gameManager.QueueEnterShop(_targetPlayer, MerchantInventoryType.EGGSONLY, null);
			base.GetTaken();
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0208: Expected O, but got I4
		//IL_022e: Expected O, but got I4
		//IL_0255: Expected O, but got I4
		//IL_026e: Expected O, but got Ref
		//IL_0288: Expected native int or pointer, but got O
		//IL_02a2: Expected O, but got I
		//IL_02c2: Expected O, but got Ref
		//IL_02dc: Expected native int or pointer, but got O
		//IL_02f6: Expected O, but got I
		//IL_0316: Expected O, but got Ref
		//IL_0330: Expected native int or pointer, but got O
		//IL_04f5: Expected O, but got I4
		//IL_0348: Expected O, but got Ref
		//IL_036f: Expected O, but got I
		//IL_0389: Expected native int or pointer, but got O
		//IL_0527: Expected O, but got I
		//IL_03c1: Expected O, but got Ref
		//IL_03db: Expected native int or pointer, but got O
		//IL_0561: Expected O, but got I
		//IL_0432: Expected O, but got I
		//IL_0453: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			particleEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particleEmitterManager = particleEmitterManager;
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"goldenegg");
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
			((List<object>)(object)list).AddWithResize((object)"goldenegg");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float constant = default(float);
		minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-60f, 60f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(200f, 340f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 70f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.75f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
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
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		_ = 0;
		_ = 1140457472;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 16777215;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = true;
		ParticleSystem pfxEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
	}
}
