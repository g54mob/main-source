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
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_GrandCross_Weapon : Weapon
{
	public float defaultWidth = 50f;

	private float _crossTime;

	private float _nextInterval = 30000f;

	private float _projectileStock;

	private float _projectileTime;

	private float _projectileInterval = 500f;

	private PhaserSprite _lightSprite;

	private bool _hasSprites;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private ParticleSystem _pfx;

	private Rectangle _pfxRecta;

	public bool ManualFire;

	private unsafe float Intensity()
	{
		PhaserSprite lightSprite = _lightSprite;
		if ((object)_lightSprite != null)
		{
			PhaserSprite spriteRenderer = (PhaserSprite)(object)lightSprite._spriteRenderer;
			if ((object)lightSprite._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				float ret;
				SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)(&ret));
				float result = default(float);
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0093: Expected O, but got I4
		//IL_03ca: Expected O, but got Ref
		//IL_03e4: Expected native int or pointer, but got O
		//IL_0626: Expected O, but got I4
		//IL_03fc: Expected O, but got Ref
		//IL_0423: Expected O, but got I
		//IL_043d: Expected native int or pointer, but got O
		//IL_0457: Expected O, but got I
		//IL_0477: Expected O, but got Ref
		//IL_048c: Expected native int or pointer, but got O
		//IL_04a6: Expected O, but got I
		//IL_04c6: Expected O, but got Ref
		//IL_04e0: Expected native int or pointer, but got O
		//IL_0643: Expected O, but got I4
		//IL_04f8: Expected O, but got Ref
		//IL_0512: Expected native int or pointer, but got O
		//IL_066d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		float num2 = default(float);
		_nextInterval = num2;
		_crossTime = num2;
		if (!_hasSprites)
		{
			_hasSprites = true;
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite lightSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "HolyBeamGradient");
			_lightSprite = lightSprite;
			PhaserSprite phaserSprite = _lightSprite.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite2 = _lightSprite.setAlpha(0.15f);
			PhaserSprite phaserSprite3 = _lightSprite.setScale(0f, (float?)(object)0);
			Transform parent = base.transform;
			Transform transform = _lightSprite.transform;
			transform.SetParent(parent, worldPositionStays: true);
			PhaserSprite phaserSprite4 = _lightSprite.setVisible(visible: false);
			PhaserSprite phaserSprite5 = _lightSprite.setDepth(1);
			GameObject gameObject2 = _lightSprite.gameObject;
			((UnityEngine.Object)gameObject2).SetName("HolyBeamGradient");
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			Rectangle rectangle = new Rectangle();
			float y = renderer.screenHeight * 0.5f;
			rectangle._height = renderer.screenHeight;
			rectangle._y = y;
			rectangle._x = -0.32f;
			rectangle._width = 0.64f;
			_pfxRecta = rectangle;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxYellow");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
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
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxLine");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(500f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
			_ = 0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = _pfxRecta;
			particleSystemConfig._emitZone = emitZone;
			Transform parent2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent2, "GrandCross emitter");
			_pfx = pfx;
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0338: Invalid comparison between I4 and F4
		//IL_0447: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_03a8: Expected O, but got F4
		//IL_0127: Expected F4, but got I4
		//IL_03b6: Expected O, but got F4
		//IL_0405: Expected F4, but got I4
		//IL_0264: Expected I, but got O
		//IL_01b2->IL0326: Incompatible stack heights: 1 vs 0
		//IL_01de->IL0326: Incompatible stack heights: 1 vs 0
		//IL_0252->IL0326: Incompatible stack heights: 1 vs 0
		//IL_0230->IL0230: Incompatible stack heights: 2 vs 1
		//IL_0417->IL0130: Incompatible stack heights: 7 vs 0
		//IL_0310->IL0326: Incompatible stack heights: 1 vs 0
		bool flag = 0f < _projectileStock;
		IntPtr intPtr = default(IntPtr);
		int num = (int)(nint)intPtr;
		if (!flag)
		{
			bool flag2 = (object)_pfx == null;
			Transform transform = _pfx.transform;
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag5 = (object)_lightSprite == null;
			PhaserSprite phaserSprite = _lightSprite.setVisible(visible: true);
			bool flag6 = (object)_lightSprite == null;
			PhaserSprite phaserSprite2 = _lightSprite.setAlpha(0.15f);
			bool flag7 = (object)_lightSprite == null;
			PhaserSprite phaserSprite3 = _lightSprite.setScale(0f, (float?)(object)0);
			bool flag8 = (object)_pfx == null;
			_pfx.Play(withChildren: true);
			object obj = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Hellfire1, 500f, 1, 0f, volume, rate, detune, loop, 1f);
			object obj2 = UnityEngine.Random.value;
			float num2 = 1.5f - 0.5f;
			float num3 = num2 * 200f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_StarFlail, 500f, 1, 0f, volume, rate, detune, loop, 1f);
			num = 1;
		}
		float num4 = base.PArea();
		Camera main = Camera.main;
		if ((object)main != null)
		{
			bool flag9 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			object obj3 = Camera.get_pixelHeight_Injected(((UnityEngine.Object)main).m_CachedPtr);
			float num5 = (float)obj3 + (float)obj3;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_lightSprite != null)
			{
				Transform transform2 = _lightSprite.transform;
				if (array != null)
				{
					if ((object)transform2 != null)
					{
						void* value2 = ((IntPtr*)(&array))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						bool flag10 = obj4 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
						_ = 1;
						((Camera)(object)tweenConfig).m_NonSerializedVersion = 1140457472u;
						_ = 1;
						MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
						_scaleTween = scaleTween;
						float num6 = base.PInterval();
						_nextInterval = num5;
						_crossTime = 0f;
						float num7 = base.PAmount();
						float projectileStock = num5 + _projectileStock;
						_projectileStock = projectileStock;
						if (skipTriggers)
						{
							return;
						}
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void InternalUpdate()
	{
		//IL_0079: Invalid comparison between F4 and I4
		//IL_005d: Expected I, but got O
		//IL_019b: Expected I, but got O
		//IL_0381: Expected O, but got I4
		//IL_027e->IL0305: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		if (!ManualFire)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			if (!((_crossTime = num + _crossTime) < _nextInterval))
			{
				nint num2 = (nint)this;
				Fire(false);
			}
		}
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = deltaTime2 * 1000f;
		if ((_projectileTime = num3 + _projectileTime) < _projectileInterval || !(_projectileStock > 0f))
		{
			return;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross_Weapon>)+4D0]");
			Vector2 pos = default(Vector2);
			Projectile projectile = base.FireOneProjectile(pos, 0);
			float projectileStock = _projectileStock - 1f;
			_projectileTime = 0f;
			_projectileStock = projectileStock;
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_lightSprite != null)
				{
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					PhaserSprite lightSprite = _lightSprite;
					if ((object)_lightSprite != null)
					{
						object spriteRenderer = lightSprite._spriteRenderer;
						if ((object)lightSprite._spriteRenderer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v8 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v8 (System.Object)+10]");
							SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
							object obj2 = default(object);
							float num5 = (float)obj2 + 0.05f;
							if (!(num5 > 0.5f))
							{
							}
							tweenConfig.alpha = (float?)(object)1;
							tweenConfig.duration = _projectileInterval;
							TweenCallback onComplete = CheckForVFXTweenOut;
							tweenConfig.onComplete = onComplete;
							MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
							_alphaTween = alphaTween;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CheckForVFXTweenOut()
	{
		//IL_0244: Invalid comparison between I4 and F4
		//IL_00a7: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_01b5: Expected I, but got O
		//IL_0218: Expected O, but got I4
		if (0f < _projectileStock)
		{
			return;
		}
		_pfx.Stop();
		float num = _nextInterval - _crossTime;
		if (!(2000f > num))
		{
			num = 2000f;
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_lightSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = num;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		Transform transform = _lightSprite.transform;
		if ((object)transform != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = num;
		tweenConfig2.scaleX = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
		_scaleTween = scaleTween;
	}

	private void LateUpdate()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserSprite phaserSprite = _lightSprite.setPosition(position);
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _lightSprite.setVisible(visible);
		_pfx.Stop();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if ((object)_lightSprite != null)
		{
			PhaserSprite phaserSprite = _lightSprite.setVisible(visible: false);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if ((object)_pfx != null)
		{
			_pfx.Stop();
		}
	}
}
