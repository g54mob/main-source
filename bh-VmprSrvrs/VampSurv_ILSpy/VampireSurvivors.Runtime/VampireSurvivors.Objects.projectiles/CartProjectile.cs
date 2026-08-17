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

public class CartProjectile : Projectile
{
	private ParticleSystem _pfxEmitter;

	private float _defaultSpeed;

	protected override void Awake()
	{
		base.Awake();
		_defaultSpeed = _speed;
		GeneratePfx();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_005b: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_0107: Expected I, but got O
		//IL_010f: Expected I, but got O
		//IL_011f: Expected O, but got I
		//IL_019f: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		//IL_04ca: Expected O, but got I
		//IL_04d3: Expected O, but got I4
		//IL_015b: Expected O, but got I
		//IL_01ac: Expected O, but got I
		//IL_0191: Expected O, but got I4
		//IL_01fd: Expected F4, but got I
		//IL_0266: Expected F4, but got I
		//IL_0538: Expected I, but got O
		//IL_02fa: Expected I4, but got O
		//IL_059c: Expected O, but got I4
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Expected I4, but got Unknown
		//IL_0363: Expected O, but got I
		//IL_03d3: Expected O, but got I
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03bd: Expected F4, but got I4
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_0613: Expected O, but got I4
		//IL_062f: Expected O, but got F4
		//IL_042d: Expected F4, but got I4
		//IL_047c: Expected O, but got I4
		//IL_066a: Expected O, but got F4
		//IL_0545->IL0503: Incompatible stack heights: 3 vs 0
		//IL_05db->IL0490: Incompatible stack heights: 1 vs 0
		//IL_034d->IL0490: Incompatible stack heights: 1 vs 0
		//IL_037f->IL0490: Incompatible stack heights: 1 vs 0
		//IL_03ef->IL0490: Incompatible stack heights: 1 vs 0
		//IL_06ac->IL048f: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Sprite sprite = SpriteManager.GetSprite("Cart1", "items");
		float? num2;
		nint num4;
		object obj3;
		float? num;
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(48f, (float?)(object)0, (float?)(object)0);
				_speed = _defaultSpeed;
				if ((object)weapon == null)
				{
					num = (float?)(object)0;
					num2 = (float?)(object)0;
					goto IL_04e6;
				}
				nint num3 = (nint)typeof(CartWeapon);
				num4 = (nint)weapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.CartWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.CartWeapon>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v98+FFFFFFF8+v406 @ rax_v94*8]");
					if (0 == (nint)typeof(CartWeapon))
					{
						obj3 = 1;
						goto IL_04b3;
					}
				}
				obj3 = 0;
				goto IL_04b3;
			}
		}
		goto IL_0490;
		IL_04e6:
		if ((object)num2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rsi_v12 (System.Nullable`1<System.Single>)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rsi_v12 (System.Nullable`1<System.Single>)+158]");
		float num6 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rsi_v12 (System.Nullable`1<System.Single>)+158]");
		bool flag = (nint)0 == 0;
		float num7 = 48f;
		if (!flag)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rsi_v12 (System.Nullable`1<System.Single>)+158]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rsi_v12 (System.Nullable`1<System.Single>)+160]");
			num7 = 0f;
			bool flag3 = (object)transform == null;
			bool flag4 = ((EventEmitter)(object)transform).callbacks == null;
			float value = default(float);
			Transform.set_position_Injected((IntPtr)((EventEmitter)(object)transform).callbacks, ref *(Vector3*)(&value));
			float num8 = default(float);
			num6 = num8;
		}
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
					if ((object)_renderer != null)
					{
						BulletPool bulletPool = default(BulletPool);
						_renderer.sortingOrder = (int)bulletPool;
						SpriteRenderer renderer2 = _renderer;
						if ((object)_renderer != null)
						{
							bool flag5 = ((UnityEngine.Object)renderer2).m_CachedPtr == (IntPtr)0;
							object obj4 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)renderer2).m_CachedPtr);
							int num9 = obj4 - 1;
							RenderingExtensions.SetDepth(_pfxEmitter, num9);
							SpriteRenderer core = (SpriteRenderer)(object)GM.Core;
							if ((object)GM.Core != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rsi_v18 (UnityEngine.SpriteRenderer)+90]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rsi_v18 (UnityEngine.SpriteRenderer)+90]");
									PlayerOptionsData config = ((PlayerOptions)0).Config;
									if (config != null)
									{
										float rotation;
										if (!config._003CSelectedInverse_003Ek__BackingField)
										{
											object obj5 = this + 728;
											rotation = 0f;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rsi_v18 (UnityEngine.SpriteRenderer)+90]");
											PlayerOptionsData config2 = ((PlayerOptions)0).Config;
											if (config2 == null)
											{
												goto IL_0490;
											}
											object obj5 = this + 728;
											rotation = (config2._003CVisuallyInvertStages_003Ek__BackingField ? ((float)Math.PI) : 0f);
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1236 @ rdx_v28] (should have been resolved before IL gen)");
										Vector2 vector = SetVelocityFromRotation(rotation, num6);
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Volume = (float?)(object)1,
											Rate = 1f
										};
										object obj6 = UnityEngine.Random.value;
										float num10 = -1f - num6;
										float detune = num10 * 500f;
										soundConfig.Detune = detune;
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 2, time);
										SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
										{
											Volume = (float?)(object)1,
											Rate = 1f
										};
										object obj7 = UnityEngine.Random.value;
										float detune2 = num6 * 200f;
										soundConfig2.Detune = detune2;
										PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Brakes, soundConfig2, 150f, 2, time);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0490;
		IL_0490:
		throw new NullReferenceException();
		IL_04b3:
		bool flag6 = obj3 == null;
		num = (float?)(object)num4;
		num2 = (float?)(object)0;
		if (!flag6)
		{
			num = (float?)(object)num4;
			num2 = (float?)weapon;
		}
		goto IL_04e6;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0087: Expected O, but got I4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 280;
		float deltaTime = PauseSystem.DeltaTime;
		float speed = deltaTime + _speed;
		_speed = speed;
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		Transform pfxEmitter = (Transform)(object)_pfxEmitter;
		_ = 0;
		_ = 1;
		_ = 1;
		bool flag2 = (object)_pfxEmitter == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		obj = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag3 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
		object obj3 = obj - 64;
		ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj3, 1);
		CartProjectile pfxEmitter2 = (CartProjectile)(object)_pfxEmitter;
		_ = 0;
		_ = 1;
		_ = 1;
		bool flag4 = (object)_pfxEmitter == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag5 = ((UnityEngine.Object)pfxEmitter2).m_CachedPtr == (IntPtr)0;
		object obj4 = obj + 80;
		ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter2).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj4, 1);
	}

	private void SetDepths()
	{
		//IL_0125: Expected O, but got I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected I4, but got Unknown
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
					if ((object)_renderer != null)
					{
						int sortingOrder = default(int);
						_renderer.sortingOrder = sortingOrder;
						CartProjectile renderer2 = (CartProjectile)(object)_renderer;
						if ((object)_renderer != null)
						{
							bool flag = ((UnityEngine.Object)renderer2).m_CachedPtr == (IntPtr)0;
							object obj = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)renderer2).m_CachedPtr);
							int num = obj - 1;
							RenderingExtensions.SetDepth(_pfxEmitter, num);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GeneratePfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00ec: Expected native int or pointer, but got O
		//IL_0106: Expected O, but got I
		//IL_0126: Expected O, but got Ref
		//IL_0140: Expected native int or pointer, but got O
		//IL_0281: Expected O, but got I4
		//IL_0165: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01bb: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_02bb: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-61]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}
}
