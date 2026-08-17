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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class NdujaProjectile : Projectile
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
		//IL_0081: Expected I, but got O
		//IL_0089: Expected I, but got O
		//IL_0099: Expected O, but got I
		//IL_0119: Expected O, but got I4
		//IL_0065: Expected I, but got O
		//IL_00d5: Expected O, but got I
		//IL_0126: Expected I4, but got O
		//IL_010b: Expected O, but got I4
		//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b2: Expected O, but got Unknown
		//IL_08ed: Expected O, but got I
		//IL_01ad: Expected O, but got I
		//IL_093d: Expected I4, but got O
		//IL_0187: Expected O, but got I
		//IL_0982: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected O, but got Unknown
		//IL_02d0: Expected O, but got I
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_0301: Expected F4, but got I4
		//IL_030a: Expected O, but got I4
		//IL_0327: Expected I4, but got O
		//IL_0225: Expected O, but got I
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0256: Expected F4, but got I4
		//IL_025f: Expected O, but got I4
		//IL_0367: Expected O, but got I
		//IL_0397: Expected O, but got I
		//IL_0435: Expected O, but got I
		//IL_09d6: Expected I, but got O
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5a: Expected O, but got Unknown
		//IL_0a8d: Expected I4, but got O
		//IL_0aa0: Expected I, but got O
		//IL_0af5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afa: Expected O, but got Unknown
		//IL_0b68: Expected I, but got O
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected O, but got Unknown
		//IL_0749: Expected I, but got O
		//IL_028c->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_01e1->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_02bb->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_0210->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_0341->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_03b1->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_03e0->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_04ba->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_04e9->IL07f3: Incompatible stack heights: 3 vs 0
		//IL_0b46->IL07f3: Incompatible stack heights: 7 vs 0
		//IL_0b92->IL07f3: Incompatible stack heights: 7 vs 0
		//IL_0bb1->IL07f3: Incompatible stack heights: 7 vs 0
		base.InitProjectile(pool, weapon, index);
		int num2;
		object obj3;
		if ((object)_renderer != null)
		{
			_renderer.enabled = false;
			if (body != null)
			{
				((NdujaWeapon)(object)body).CheckArcanas();
				nint num;
				if ((object)weapon == null)
				{
					num = unchecked((nint)null);
					num2 = 0;
					goto IL_082b;
				}
				nint num3 = (nint)typeof(NdujaWeapon);
				num = (nint)weapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rdx_v65 (Il2CppClass<VampireSurvivors.Objects.Weapons.NdujaWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rdx_v65 (Il2CppClass<VampireSurvivors.Objects.Weapons.NdujaWeapon>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v153+FFFFFFF8+v451 @ rax_v149*8]");
					if (0 == (nint)typeof(NdujaWeapon))
					{
						obj3 = 1;
						goto IL_0854;
					}
				}
				obj3 = 0;
				goto IL_0854;
			}
		}
		goto IL_07f3;
		IL_07f3:
		throw new NullReferenceException();
		IL_0854:
		bool flag = obj3 == null;
		num2 = 0;
		if (!flag)
		{
			num2 = (int)weapon;
		}
		goto IL_082b;
		IL_0933:
		int num5 = (int)_cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rdi_v15 (System.Int32)+10]");
		bool flag3 = (nint)0 == 0;
		object obj5 = default(object);
		object obj4 = obj5 - 64;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rdi_v15 (System.Int32)+10]");
		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj4);
		Weapon weapon2 = _weapon;
		float num6;
		if (!isPlayerFacing)
		{
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v101 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
					object obj6 = 0;
					Vector3 playerDirection = (Vector3)(obj5 - 64);
					_ = 0;
					ApplyInversePlayerFacingVelocity(playerDirection);
					num6 = 0f;
					object obj7 = 0;
					bool flag4 = true;
					Projectile projectile = this;
					goto IL_031d;
				}
			}
		}
		else if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v99 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
				object obj6 = 0;
				Vector3 playerDirection = (Vector3)(obj5 - 64);
				_ = 0;
				ApplyPlayerFacingVelocity(playerDirection);
				num6 = 0f;
				object obj7 = 0;
				bool flag4 = true;
				Projectile projectile = this;
				goto IL_031d;
			}
		}
		goto IL_07f3;
		IL_031d:
		int num7 = (int)body;
		if (body != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			int indexInWeapon = _indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdi_v16 (System.Int32)+70]");
			float2 velocity = (float2)((nint)indexInWeapon + (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			ArcadeSprite sprite = _sprite;
			int indexInWeapon2 = _indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdi_v16 (System.Int32)+74]");
			object obj8 = (nint)indexInWeapon2 + (nint)0;
			if ((object)_sprite != null)
			{
				BaseBody baseBody = sprite.body;
				if (sprite.body != null)
				{
					baseBody._velocity = velocity;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					_ = 0;
					_ = 1065353216;
					_ = 1;
					soundConfig.Rate = 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
					soundConfig.Volume = (float?)(object)0;
					soundConfig.Rate = 2f;
					float detune = (float)_indexInWeapon * -100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Fireloop, soundConfig, 200f, 1, time);
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 1f);
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = true;
						if ((object)_GroundFx != null)
						{
							Transform transform = _GroundFx.transform;
							nint num8 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1348 @ rcx_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ rdx_v31 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
							float num10 = 0f * 2f;
							float num11 = num10 * 0.01f;
							bool flag5 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1444 @ rax_v61 (UnityEngine.Transform)+10]");
							bool flag6 = (nint)0 == 0;
							object obj9 = obj5 - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1444 @ rax_v61 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj9);
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_renderer, 1f);
							int num12 = (int)_cachedTransform;
							nint num13 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1522 @ rax_v69 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num14 = 0;
							bool flag7 = (object)_cachedTransform == null;
							_ = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ rax_v70 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rdi_v20 (System.Int32)+10]");
							bool flag8 = (nint)0 == 0;
							object obj10 = obj5 - 80;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rdi_v20 (System.Int32)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj10);
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
								nint num15 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v84 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num16 = 0;
								if ((object)_weapon != null)
								{
									float num17 = _weapon.PArea();
									float num18 = (float)Vector3.zeroVector * 16f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdi_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									float num19 = 0f * num18;
									Vector3 endValue = (Vector3)(obj5 - 64);
									TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.4f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_scaleTween, (Tween)t, false))
									{
										Sequence sequence2 = Sequence.DoInsert(_scaleTween, (Tween)t, num6);
									}
									TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_GroundFx, num6, 0.4f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_scaleTween, (Tween)t2, false))
									{
										Sequence sequence3 = Sequence.DoInsert(_scaleTween, (Tween)t2, num6);
									}
									Sequence scaleTween = _scaleTween;
									if (_scaleTween != null && ((Tween)scaleTween)._003Cactive_003Ek__BackingField)
									{
										((Tween)scaleTween).easeType = Ease.Linear;
										((Tween)scaleTween).customEase = null;
									}
									Sequence scaleTween2 = _scaleTween;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1891 @ r8_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.NdujaProjectile>)+370]");
									TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
									nint num20 = (nint)this;
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
		goto IL_07f3;
		IL_082b:
		Weapon cachedTransform = (Weapon)(object)_cachedTransform;
		if ((object)_cachedTransform == null)
		{
			goto IL_07f3;
		}
		_ = 0;
		_ = 0;
		bool flag9 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		object obj11 = obj5 - 80;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj11);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-4C]");
		float num21 = 0f + 0.24f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
		Weapon weapon3 = (Weapon)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-48]");
		_ = 0;
		object obj12;
		if (num2 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rdi_v14 (System.Int32)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rdi_v14 (System.Int32)+160]");
				Weapon weapon4 = (Weapon)(num22 + 0);
				object obj13 = default(object);
				obj12 = obj13;
				weapon3 = weapon4;
				goto IL_0933;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
		obj12 = 0;
		goto IL_0933;
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
		//IL_06d1: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_025e: Expected O, but got I4
		//IL_0277: Expected O, but got Ref
		//IL_0291: Expected native int or pointer, but got O
		//IL_06ee: Expected O, but got I4
		//IL_02c3: Expected O, but got Ref
		//IL_02dd: Expected native int or pointer, but got O
		//IL_0728: Expected O, but got I
		//IL_04a9: Expected O, but got Ref
		//IL_04c3: Expected native int or pointer, but got O
		//IL_0762: Expected O, but got I
		//IL_04fb: Expected O, but got Ref
		//IL_0515: Expected native int or pointer, but got O
		//IL_052f: Expected O, but got I
		//IL_054f: Expected O, but got Ref
		//IL_0569: Expected native int or pointer, but got O
		//IL_0583: Expected O, but got I
		//IL_05bc: Expected O, but got I
		//IL_05d8: Expected O, but got I4
		//IL_05f1: Expected O, but got Ref
		//IL_060b: Expected native int or pointer, but got O
		//IL_079c: Expected O, but got I
		//IL_0643: Expected O, but got Ref
		//IL_065d: Expected native int or pointer, but got O
		//IL_07ce: Expected O, but got I
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
			((List<object>)(object)list).AddWithResize((object)"PfxRed");
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
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
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
			((List<object>)(object)list2).AddWithResize((object)"Flame2");
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
			((List<object>)(object)list2).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
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
}
