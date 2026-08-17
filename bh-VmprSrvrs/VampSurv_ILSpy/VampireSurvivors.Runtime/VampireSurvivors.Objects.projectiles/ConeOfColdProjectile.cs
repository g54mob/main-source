using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class ConeOfColdProjectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private ParticleEmitterManager _particleEmitterManager;

	private Sequence _scaleTween;

	private const float Radius = 16f;

	protected bool isPlayerFacing = true;

	protected override void Awake()
	{
		base.Awake();
		AssignRandomColorToGroundFx();
		GenerateParticleSystems();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004f: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_005d: Expected I4, but got O
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Expected O, but got Unknown
		//IL_0760: Expected I4, but got O
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		//IL_01b3: Expected O, but got I
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01e4: Expected F4, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_020a: Expected I4, but got O
		//IL_0108: Expected O, but got I
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0139: Expected F4, but got I4
		//IL_0142: Expected O, but got I4
		//IL_024a: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_0318: Expected O, but got I
		//IL_0823: Expected I, but got O
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ad: Expected O, but got Unknown
		//IL_08e0: Expected I4, but got O
		//IL_08f3: Expected I, but got O
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Expected O, but got Unknown
		//IL_09bb: Expected I, but got O
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Expected O, but got Unknown
		//IL_0624: Expected I, but got O
		//IL_016f->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_00c4->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_019e->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_00f3->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_0224->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_0294->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_02c3->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_038f->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_03be->IL06ce: Incompatible stack heights: 3 vs 0
		//IL_0999->IL06ce: Incompatible stack heights: 7 vs 0
		//IL_09e5->IL06ce: Incompatible stack heights: 7 vs 0
		//IL_0a04->IL06ce: Incompatible stack heights: 7 vs 0
		base.InitProjectile(pool, weapon, index);
		object obj2 = default(object);
		float num4;
		if ((object)_renderer != null)
		{
			_renderer.enabled = false;
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(1f, (float?)(object)0, (float?)(object)0);
				int num = (int)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v14 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					object obj = obj2 - 64;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v14 (System.Int32)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj);
					int num2 = (int)_cachedTransform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-3C]");
					float num3 = 0f + 0.24f;
					bool flag2 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdi_v15 (System.Int32)+10]");
					bool flag3 = (nint)0 == 0;
					object obj3 = obj2 - 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdi_v15 (System.Int32)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj3);
					Weapon weapon2 = _weapon;
					if (!isPlayerFacing)
					{
						if ((object)_weapon != null)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v95 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
								object obj4 = 0;
								Vector3 playerDirection = (Vector3)(obj2 - 48);
								_ = 0;
								ApplyInversePlayerFacingVelocity(playerDirection);
								num4 = 0f;
								object obj5 = 0;
								bool flag4 = true;
								Projectile projectile = this;
								goto IL_0200;
							}
						}
					}
					else if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v93 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
							object obj4 = 0;
							Vector3 playerDirection = (Vector3)(obj2 - 48);
							_ = 0;
							ApplyPlayerFacingVelocity(playerDirection);
							num4 = 0f;
							object obj5 = 0;
							bool flag4 = true;
							Projectile projectile = this;
							goto IL_0200;
						}
					}
				}
			}
		}
		goto IL_06ce;
		IL_0200:
		int num5 = (int)body;
		if (body != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			int indexInWeapon = _indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdi_v16 (System.Int32)+70]");
			float2 velocity = (float2)((nint)indexInWeapon + (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			ArcadeSprite sprite = _sprite;
			int indexInWeapon2 = _indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdi_v16 (System.Int32)+74]");
			object obj6 = (nint)indexInWeapon2 + (nint)0;
			if ((object)_sprite != null)
			{
				BaseBody baseBody2 = sprite.body;
				if (sprite.body != null)
				{
					baseBody2._velocity = velocity;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					_ = 0;
					_ = 1048576000;
					_ = 1;
					soundConfig.Rate = 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
					soundConfig.Volume = (float?)(object)0;
					float detune = (float)_indexInWeapon * -100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_crystal_quick, soundConfig, 100f, 1, time);
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 1f);
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = true;
						if ((object)_GroundFx != null)
						{
							Transform transform = _GroundFx.transform;
							nint num6 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rcx_v45 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num7 = 0;
							_ = Vector3.oneVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rdx_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
							float num8 = 0f * 2f;
							float num9 = num8 * 0.01f;
							bool flag5 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ rax_v56 (UnityEngine.Transform)+10]");
							bool flag6 = (nint)0 == 0;
							object obj7 = obj2 - 48;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ rax_v56 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj7);
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_renderer, 1f);
							int num10 = (int)_cachedTransform;
							nint num11 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1272 @ rax_v64 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num12 = 0;
							bool flag7 = (object)_cachedTransform == null;
							_ = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rax_v65 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ rdi_v20 (System.Int32)+10]");
							bool flag8 = (nint)0 == 0;
							object obj8 = obj2 - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ rdi_v20 (System.Int32)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj8);
							if (_scaleTween != null)
							{
								TweenExtensions.Kill(_scaleTween);
							}
							Sequence sequence = DOTween.Sequence();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (sequence != null)
							{
								_scaleTween = sequence;
								nint num13 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v79 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num14 = 0;
								if ((object)_weapon != null)
								{
									float num15 = _weapon.PArea();
									float num16 = (float)Vector3.zeroVector * 16f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdi_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									float num17 = 0f * num16;
									_ = Vector3.oneVector;
									Vector3 endValue = (Vector3)(obj2 - 48);
									TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.4f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_scaleTween, (Tween)t, false))
									{
										Sequence sequence2 = Sequence.DoInsert(_scaleTween, (Tween)t, num4);
									}
									TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_GroundFx, num4, 0.4f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_scaleTween, (Tween)t2, false))
									{
										Sequence sequence3 = Sequence.DoInsert(_scaleTween, (Tween)t2, num4);
									}
									Sequence scaleTween = _scaleTween;
									if (_scaleTween != null && ((Tween)scaleTween)._003Cactive_003Ek__BackingField)
									{
										((Tween)scaleTween).easeType = Ease.Linear;
										((Tween)scaleTween).customEase = null;
									}
									Sequence scaleTween2 = _scaleTween;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1643 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.ConeOfColdProjectile>)+370]");
									TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
									nint num18 = (nint)this;
									if (_scaleTween != null && ((Tween)scaleTween2)._003Cactive_003Ek__BackingField)
									{
										scaleTween2.onComplete = onComplete;
									}
									Sequence scaleTween3 = _scaleTween;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (_scaleTween != null)
									{
										scaleTween3.stringId = "DefaultGameTweenId";
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_06ce;
		IL_06ce:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_0068->IL009b: Incompatible stack heights: 1 vs 0
		ParticleEmitterManager particleEmitterManager = _particleEmitterManager;
		if ((object)_particleEmitterManager != null && ((UnityEngine.Object)particleEmitterManager).m_CachedPtr != (IntPtr)0)
		{
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v4 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Vector2 pos = default(Vector2);
			_particleEmitterManager.EmitParticleAt(pos);
		}
	}

	private unsafe void AssignRandomColorToGroundFx()
	{
		//IL_00a2: Expected I4, but got O
		//IL_00a6: Expected O, but got I4
		//IL_00e1->IL00ab: Incompatible stack heights: 1 vs 0
		string[] array = new string[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj = UnityEngine.Random.RandomRangeInt(0, (int)((SpriteRenderer)(object)array).m_SpriteChangeEvent);
		if (ColorUtility.DoTryParseHtmlColor(array[obj], out Color32 _))
		{
			SpriteRenderer groundFx = _GroundFx;
			bool flag = ((UnityEngine.Object)groundFx).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)groundFx).m_CachedPtr, ref *(Color*)(&value));
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_01f7: Expected O, but got Ref
		//IL_0211: Expected native int or pointer, but got O
		//IL_0a5b: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_025e: Expected O, but got I4
		//IL_0277: Expected O, but got Ref
		//IL_0291: Expected native int or pointer, but got O
		//IL_0a78: Expected O, but got I4
		//IL_02c3: Expected O, but got Ref
		//IL_02dd: Expected native int or pointer, but got O
		//IL_0ab2: Expected O, but got I
		//IL_0833: Expected O, but got Ref
		//IL_084d: Expected native int or pointer, but got O
		//IL_0aec: Expected O, but got I
		//IL_0885: Expected O, but got Ref
		//IL_089f: Expected native int or pointer, but got O
		//IL_08b9: Expected O, but got I
		//IL_08d9: Expected O, but got Ref
		//IL_08f3: Expected native int or pointer, but got O
		//IL_090d: Expected O, but got I
		//IL_0946: Expected O, but got I
		//IL_0962: Expected O, but got I4
		//IL_097b: Expected O, but got Ref
		//IL_0995: Expected native int or pointer, but got O
		//IL_0b26: Expected O, but got I
		//IL_09cd: Expected O, but got Ref
		//IL_09e7: Expected native int or pointer, but got O
		//IL_0b58: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
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
			((List<object>)(object)list).AddWithResize((object)"PfxBlue");
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
			((List<object>)(object)list).AddWithResize((object)"PfxHoly1");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _particleEmitterManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter1");
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini1");
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
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini2");
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
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini3");
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
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini4");
		}
		else
		{
			int num6 = list2._size + 1;
			list2._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list2._version + 1;
		list2._version = version7;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini5");
		}
		else
		{
			int num7 = list2._size + 1;
			list2._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list2._version + 1;
		list2._version = version8;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini6");
		}
		else
		{
			int num8 = list2._size + 1;
			list2._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list2._version + 1;
		list2._version = version9;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini7");
		}
		else
		{
			int num9 = list2._size + 1;
			list2._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list2._version + 1;
		list2._version = version10;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"IceCrystMini8");
		}
		else
		{
			int num10 = list2._size + 1;
			list2._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
		particleSystemConfig2._quantity = (int?)(object)0;
		minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._on = false;
		ParticleSystem particleSystem2 = _particleEmitterManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			bool flag = TryFreeze(other);
		}
	}
}
