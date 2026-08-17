using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Curves;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SpellstringProjectile : Projectile
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

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a8: Expected O, but got I
		//IL_0254: Expected O, but got Ref
		//IL_0269: Expected native int or pointer, but got O
		//IL_03cf: Expected O, but got I
		//IL_02a1: Expected O, but got Ref
		//IL_02c8: Expected O, but got I
		//IL_02dd: Expected native int or pointer, but got O
		//IL_02f7: Expected O, but got I
		//IL_0317: Expected O, but got Ref
		//IL_0331: Expected native int or pointer, but got O
		//IL_0409: Expected O, but got I
		//IL_03a3: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileHoly1", "vfx");
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
			((List<object>)(object)list).AddWithResize((object)"PfxHoly1");
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
			((List<object>)(object)list).AddWithResize((object)"PfxHoly2");
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
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
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
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_007d: Expected O, but got I4
		//IL_0153: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
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
		Material material = ((Renderer)_trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 1f);
		_trail.emitting = true;
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"angleLerp", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 120f;
			TweenCallback onStart = delegate
			{
				//IL_000e: Expected O, but got F4
				object obj2 = UnityEngine.Random.value;
				object obj3 = default(object);
				float num2 = (float)obj3 - 0.5f;
				float num3 = num2 + num2;
				angleLerp = num3;
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
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_00c6: Expected O, but got F4
		//IL_03b9: Expected O, but got I4
		//IL_0200: Expected I4, but got I8
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_021b->IL03a9: Incompatible stack heights: 3 vs 2
		float num = ++_updateLoops;
		bool flag = _expired;
		IntPtr intPtr = default(IntPtr);
		int sortingOrder = (int)(nint)intPtr;
		if (!flag)
		{
			bool flag2 = !(num > 1f);
			sortingOrder = (int)(nint)intPtr;
			if (!flag2)
			{
				_expired = true;
				FadeOut();
				sortingOrder = 0;
			}
		}
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
		_trail.sortingOrder = sortingOrder;
		Transform targetTransform = _targetTransform;
		bool flag3 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
		Vector2 ret;
		Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out *(Vector3*)(&ret));
		float num2 = angleLerp * 0.5f;
		float num3 = num2 * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		object obj = ret - _startingPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstringProjectile)+104]");
		object obj3 = default(object);
		object obj2 = obj3 - 0;
		float num4 = num3 * (float)obj;
		float num5 = num3 * (float)obj2;
		float num6 = num3 * (float)obj2;
		float num7 = num4 - num5;
		float num8 = num3 * (float)obj;
		float num9 = num6 + num8;
		float num10 = num7 + (float)_startingPoint;
		float num11 = num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstringProjectile)+104]");
		float num12 = num11 + 0f;
		QuadraticBezierCurve quadraticBezierCurve = null;
		quadraticBezierCurve._p1 = (Vector2)num10;
		quadraticBezierCurve._p0 = ret;
		quadraticBezierCurve._p2 = _startingPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.SpellstringProjectile)+104]");
		_ = 0;
		Vector3[] points = quadraticBezierCurve.GetPoints(9);
		TrailRenderer trail = _trail;
		bool flag4 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_trail.AddPositions(points);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
		Material material = ((Renderer)_trail).GetMaterial();
		Material material2 = ((Renderer)_trail).GetMaterial();
		Texture mainTexture = material2.mainTexture;
		int width = mainTexture.width;
		int num13 = Shader.PropertyToID("_MainTex");
		Vector2 pos = default(Vector2);
		material.SetTextureScaleImpl(num13, pos);
		Transform transform = null;
		Transform transform2 = null;
		while (true)
		{
			object obj4 = points.Length - 1;
			if (System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				bool flag5 = (nint)transform >= points.Length;
				RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, -1);
				transform = (Transform)(transform + 1);
				transform2 = transform;
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
		//IL_020b: Expected O, but got F4
		//IL_0214: Invalid comparison between O and F4
		//IL_017b->IL011e: Incompatible stack heights: 1 vs 0
		//IL_00af->IL011e: Incompatible stack heights: 1 vs 0
		//IL_01fd->IL011e: Incompatible stack heights: 2 vs 0
		//IL_00e7->IL011e: Incompatible stack heights: 2 vs 0
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		string spriteName = "spellstring2";
		if (!flag)
		{
			spriteName = "spellstring1";
		}
		Sprite sprite = SpriteManager.GetSprite(spriteName, "vfx");
		object trail = _trail;
		if ((object)_trail != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v5 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v5 (System.Object)+10]");
			TrailRenderer.Clear_Injected((IntPtr)0);
			if ((object)_trail != null)
			{
				_trail.emitting = true;
				RenderingExtensions.SetMaterialToPackedSprite(_trail, sprite, autoSetTrailWidth: true, additive: true);
				object trail2 = _trail;
				if ((object)_trail != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdi_v8 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdi_v8 (System.Object)+10]");
					TrailRenderer.set_textureMode_Injected((IntPtr)0, LineTextureMode.Stretch);
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
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x18703E490\"");
	}

	private void FadeOut()
	{
		//IL_0070: Expected I, but got O
		//IL_00d4: Expected O, but got I4
		if (_fadeTrailTween != null)
		{
			_fadeTrailTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
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
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
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
	}

	private Vector2 Rotate_point(float targetX, float targetY, float angle, Vector2 origin)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		//IL_000e: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float num2 = num + num;
		angleLerp = num2;
	}

	private void _003CFadeOut_003Eb__16_0()
	{
		Material material = ((Renderer)_trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 1f);
	}

	private void _003CFadeOut_003Eb__16_1()
	{
		Despawn();
	}
}
