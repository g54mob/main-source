using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Gun2_Projectile : TP_Gun1_Projectile
{
	private TrailRenderer _trail;

	private List<Color> colors;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private List<List<string>> sparkFrames;

	protected override void Awake()
	{
		//IL_0124->IL00b3: Incompatible stack heights: 1 vs 0
		//IL_016a->IL00b3: Incompatible stack heights: 2 vs 0
		((Projectile)this).Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileBullet3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		if ((object)_trail != null)
		{
			Material material = ((Renderer)_trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			object trail = _trail;
			if ((object)_trail != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v7 (System.Object)+10]");
				Renderer.set_sortingOrder_Injected((IntPtr)0, 999);
				TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
				object trail2 = _trail;
				if ((object)_trail != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v8 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v8 (System.Object)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 252 Invalid \"Jump target not found in method: 0x18710A370\"");
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b4: Expected O, but got Ref
		//IL_00ce: Expected native int or pointer, but got O
		//IL_027f: Expected O, but got I4
		//IL_00e6: Expected O, but got Ref
		//IL_0113: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_0149: Expected native int or pointer, but got O
		//IL_0163: Expected O, but got I
		//IL_0183: Expected O, but got Ref
		//IL_019d: Expected native int or pointer, but got O
		//IL_029c: Expected O, but got I4
		//IL_01b5: Expected O, but got Ref
		//IL_01cf: Expected native int or pointer, but got O
		//IL_02c6: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
			List<string> list = Extensions.PickRnd(sparkFrames);
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
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 1098907648;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			particleSystemConfig._frequency = (float?)(object)0;
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
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0.5f));
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
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001e: Expected I4, but got O
		//IL_0432: Expected O, but got F4
		//IL_029a: Expected O, but got F4
		//IL_02a4: Expected I4, but got O
		//IL_0138: Expected I4, but got O
		//IL_03df: Expected O, but got Ref
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_03f8: Expected O, but got F4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		Vector3 ret;
		float num10;
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			int num2 = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v14 (System.Int32)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v14 (System.Int32)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				object obj = UnityEngine.Random.value;
				object obj2 = UnityEngine.Random.value;
				int num3 = (int)_cachedTransform;
				float num4 = (float)ret - 0.5f;
				float num5 = num4 * 0.16f;
				float num7 = default(float);
				float num6 = num5 * num7;
				object obj3 = default(object);
				float num8 = num6 + (float)obj3;
				bool flag2 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rbx_v15 (System.Int32)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rbx_v15 (System.Int32)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				int penetrating = _penetrating + _indexInWeapon;
				_penetrating = penetrating;
				_speed = 7f;
				bool flag4 = (object)_trail == null;
				float startWidth = num7 * 0.04f;
				_trail.startWidth = startWidth;
				bool flag5 = (object)_trail == null;
				_trail.endWidth = 0f;
				bool flag6 = (object)_trail == null;
				_trail.time = 0.2f;
				bool flag7 = (object)_trail == null;
				Material material = ((Renderer)_trail).GetMaterial();
				RenderingExtensions.SetAlpha(material, 0.65f);
				bool flag8 = (object)_trail == null;
				_trail.emitting = true;
				int num9 = (int)_trail;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BD30");
				bool flag9 = (object)_trail == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rbx_v17 (System.Int32)+10]");
				bool flag10 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rbx_v17 (System.Int32)+10]");
				Color value2 = default(Color);
				TrailRenderer.set_startColor_Injected((IntPtr)0, ref value2);
				if (!(num7 > 2.5f))
				{
					object obj4 = 2.5f & -2147483649L;
					bool flag11 = (nint)obj4 <= 2139095040;
					num10 = num7;
					if (flag11)
					{
						goto IL_03af;
					}
				}
				num10 = 2.5f;
				goto IL_03af;
			}
		}
		throw new NullReferenceException();
		IL_03af:
		float max = num10 * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(num10, max);
		RenderingExtensions.SetScale(_pfx, (ParticleSystem.MinMaxCurve)(&ret));
		RenderingExtensions.Start(_pfx);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Rate = 2f
		};
		object obj5 = UnityEngine.Random.value;
		float num11 = 0f - 0.5f;
		_ = 1;
		float num12 = num11 * 200f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_paradoxMist, soundConfig, 200f, 1, time);
	}

	public override void Despawn()
	{
		//IL_0104->IL00b7: Incompatible stack heights: 1 vs 0
		if ((object)_pfx != null)
		{
			_pfx.Stop();
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			TrailRenderer trail = _trail;
			if ((object)_trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if ((object)_trail != null)
				{
					_trail.emitting = false;
					if (_despawnTimer != null)
					{
						_despawnTimer.Cancel();
					}
					((Projectile)this).Despawn();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe TP_Gun2_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_0066: Expected O, but got Ref
		//IL_0076: Expected O, but got I
		//IL_1050: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_0154: Expected O, but got I
		//IL_0109: Expected O, but got Ref
		//IL_0119: Expected O, but got I
		//IL_1078: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_01ac: Expected O, but got Ref
		//IL_01bc: Expected O, but got I
		//IL_10a0: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_029a: Expected O, but got I
		//IL_024f: Expected O, but got Ref
		//IL_025f: Expected O, but got I
		//IL_10c8: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_032d: Expected O, but got I
		//IL_02f2: Expected O, but got Ref
		//IL_0598: Expected O, but got I
		//IL_0821: Expected O, but got I
		//IL_0aaa: Expected O, but got I
		//IL_0d33: Expected O, but got I
		//IL_0fbc: Expected O, but got I
		List<Color> list = new List<Color>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v4+18]");
		object obj2 = default(object);
		if (num >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A122C0]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj4 = (nint)0 + (nint)2;
			object obj5 = obj4 + obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A122C0]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A123E0]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj7 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj8 = (nint)0 + (nint)2;
			object obj9 = obj8 + obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A123E0]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12120]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj11 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj12 = (nint)0 + (nint)2;
			object obj13 = obj12 + obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12120]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FA0]");
			obj2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj15 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj16 = (nint)0 + (nint)2;
			object obj17 = obj16 + obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FA0]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize((Color)(&obj2));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj19 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			object obj20 = (nint)0 + (nint)2;
			object obj21 = obj20 + obj20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12110]");
			_ = 0;
		}
		colors = list;
		List<List<string>> list2 = new List<List<string>>();
		List<string> list3 = new List<string>();
		list3._version++;
		string[] items = list3._items;
		if (list3._size >= items.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_Sparks00");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items2 = list3._items;
		if (list3._size >= items2.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_Sparks01");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items3 = list3._items;
		if (list3._size >= items3.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_Sparks02");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items4 = list3._items;
		if (list3._size >= items4.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_Sparks03");
			object obj22 = 0;
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj22 = "TP_VFX_Sparks03";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
		List<string> list4 = new List<string>();
		list4._version++;
		string[] items5 = list4._items;
		if (list4._size >= items5.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"TP_VFX_Sparks04");
		}
		else
		{
			list4._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list4._version++;
		string[] items6 = list4._items;
		if (list4._size >= items6.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"TP_VFX_Sparks05");
		}
		else
		{
			list4._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list4._version++;
		string[] items7 = list4._items;
		if (list4._size >= items7.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"TP_VFX_Sparks08");
		}
		else
		{
			list4._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list4._version++;
		string[] items8 = list4._items;
		if (list4._size >= items8.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"TP_VFX_Sparks07");
			object obj23 = 0;
		}
		else
		{
			list4._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj23 = "TP_VFX_Sparks07";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
		List<string> list5 = new List<string>();
		list5._version++;
		string[] items9 = list5._items;
		if (list5._size >= items9.Length)
		{
			((List<object>)(object)list5).AddWithResize((object)"TP_VFX_Sparks08");
		}
		else
		{
			list5._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list5._version++;
		string[] items10 = list5._items;
		if (list5._size >= items10.Length)
		{
			((List<object>)(object)list5).AddWithResize((object)"TP_VFX_Sparks09");
		}
		else
		{
			list5._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list5._version++;
		string[] items11 = list5._items;
		if (list5._size >= items11.Length)
		{
			((List<object>)(object)list5).AddWithResize((object)"TP_VFX_Sparks10");
		}
		else
		{
			list5._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list5._version++;
		string[] items12 = list5._items;
		if (list5._size >= items12.Length)
		{
			((List<object>)(object)list5).AddWithResize((object)"TP_VFX_Sparks11");
			object obj24 = 0;
		}
		else
		{
			list5._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj24 = "TP_VFX_Sparks11";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
		List<string> list6 = new List<string>();
		list6._version++;
		string[] items13 = list6._items;
		if (list6._size >= items13.Length)
		{
			((List<object>)(object)list6).AddWithResize((object)"TP_VFX_Sparks12");
		}
		else
		{
			list6._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list6._version++;
		string[] items14 = list6._items;
		if (list6._size >= items14.Length)
		{
			((List<object>)(object)list6).AddWithResize((object)"TP_VFX_Sparks13");
		}
		else
		{
			list6._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list6._version++;
		string[] items15 = list6._items;
		if (list6._size >= items15.Length)
		{
			((List<object>)(object)list6).AddWithResize((object)"TP_VFX_Sparks14");
		}
		else
		{
			list6._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list6._version++;
		string[] items16 = list6._items;
		if (list6._size >= items16.Length)
		{
			((List<object>)(object)list6).AddWithResize((object)"TP_VFX_Sparks15");
			object obj25 = 0;
		}
		else
		{
			list6._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj25 = "TP_VFX_Sparks15";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
		List<string> list7 = new List<string>();
		list7._version++;
		string[] items17 = list7._items;
		if (list7._size >= items17.Length)
		{
			((List<object>)(object)list7).AddWithResize((object)"TP_VFX_Sparks16");
		}
		else
		{
			list7._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list7._version++;
		string[] items18 = list7._items;
		if (list7._size >= items18.Length)
		{
			((List<object>)(object)list7).AddWithResize((object)"TP_VFX_Sparks17");
		}
		else
		{
			list7._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list7._version++;
		string[] items19 = list7._items;
		if (list7._size >= items19.Length)
		{
			((List<object>)(object)list7).AddWithResize((object)"TP_VFX_Sparks18");
		}
		else
		{
			list7._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list7._version++;
		string[] items20 = list7._items;
		if (list7._size >= items20.Length)
		{
			((List<object>)(object)list7).AddWithResize((object)"TP_VFX_Sparks19");
			object obj26 = 0;
		}
		else
		{
			list7._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj26 = "TP_VFX_Sparks19";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
		sparkFrames = list2;
		((Projectile)this)._002Ector();
	}
}
