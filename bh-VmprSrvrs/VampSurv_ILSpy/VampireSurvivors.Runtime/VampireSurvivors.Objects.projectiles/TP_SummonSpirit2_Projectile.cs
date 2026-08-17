using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SummonSpirit2_Projectile : TP_SummonSpirit_Projectile
{
	private ParticleSystem _pfxHoly;

	protected override uint[] Tints => new uint[17]
	{
		16777215u, 15728639u, 14680063u, 13631487u, 12582911u, 11534335u, 10485759u, 9437183u, 8388607u, 7340031u,
		6291455u, 5242879u, 4194303u, 3145727u, 2097151u, 1048575u, 65535u
	};

	protected override void Awake()
	{
		((Projectile)this).Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GenerateParticleSystem();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 107 Invalid \"Jump target not found in method: 0x18718B470\"");
		throw new NullReferenceException();
	}

	private unsafe void GenerateHolyParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01dc: Expected O, but got Ref
		//IL_01f6: Expected native int or pointer, but got O
		//IL_03c3: Expected O, but got I4
		//IL_020e: Expected O, but got Ref
		//IL_0235: Expected O, but got I
		//IL_024a: Expected native int or pointer, but got O
		//IL_0264: Expected O, but got I
		//IL_0284: Expected O, but got Ref
		//IL_029e: Expected native int or pointer, but got O
		//IL_03e0: Expected O, but got I4
		//IL_02b6: Expected O, but got Ref
		//IL_02d0: Expected native int or pointer, but got O
		//IL_040a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfxHoly = _pfxHoly;
		if ((object)_pfxHoly == null || ((UnityEngine.Object)pfxHoly).m_CachedPtr == (IntPtr)0)
		{
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
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
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
				((List<object>)(object)list).AddWithResize((object)"PfxHoly2.png");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.7f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			particleSystemConfig._on = false;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			Transform parent = base.transform;
			ParticleSystem pfxHoly2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfxHoly = pfxHoly2;
			RenderingExtensions.SetDepth(_pfxHoly, 1);
		}
	}

	protected unsafe override void UpdatePfx()
	{
		//IL_00aa: Expected O, but got Ref
		//IL_0186->IL0101: Incompatible stack heights: 1 vs 0
		//IL_00f6->IL00f6: Incompatible stack heights: 1 vs 0
		ParticleSystem pfxHoly = _pfxHoly;
		if ((object)_pfxHoly == null || ((UnityEngine.Object)pfxHoly).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (_emitParticles)
		{
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, 0f);
				ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
				RenderingExtensions.SetScale(_pfxHoly, (ParticleSystem.MinMaxCurve)(&minMaxCurve2));
				ParticleSystem cachedTransform = (ParticleSystem)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					if ((object)_pfxManager != null)
					{
						Vector2 pos = default(Vector2);
						_pfxManager.EmitParticleAt(pos);
						goto IL_00f6;
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_00f6;
		IL_00f6:
		base.UpdatePfx();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00db: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if (_bounces <= 0)
			{
				if (--_penetrating <= 0)
				{
					StartDespawn();
				}
			}
			else
			{
				int bounces = _bounces - 1;
				_bounces = bounces;
				BaseBody baseBody = body;
				float num = (float)baseBody._velocity * -1f;
				baseBody._velocity = (float2)num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	public TP_SummonSpirit2_Projectile()
	{
		base._radius = 10f;
		base._IndexOffsetScaleFactor = 0.1f;
		((Projectile)this)._002Ector();
	}
}
