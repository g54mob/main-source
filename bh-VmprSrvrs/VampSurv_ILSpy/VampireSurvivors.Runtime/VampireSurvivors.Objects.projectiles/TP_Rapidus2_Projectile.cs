using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Rapidus2_Projectile : TP_Rapidus_Projectile
{
	private ArcadeSprite _ring1;

	private ArcadeSprite _ring2;

	private ArcadeSprite _ring3;

	private MultiTargetTween _tweenRing1;

	private MultiTargetTween _tweenRingAngle;

	protected unsafe override void Awake()
	{
		//IL_00e8: Expected O, but got I4
		//IL_0110: Expected O, but got Ref
		//IL_016e: Expected O, but got I4
		//IL_0196: Expected O, but got Ref
		//IL_01f4: Expected O, but got I4
		//IL_021c: Expected O, but got Ref
		//IL_0402: Expected O, but got I4
		//IL_0402: Expected O, but got I4
		//IL_0432: Expected O, but got I4
		//IL_0432: Expected O, but got I4
		//IL_0462: Expected O, but got I4
		//IL_0462: Expected O, but got I4
		((Projectile)this).Awake();
		Sprite sprite = SpriteManager.GetSprite("aeroBubble1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("aeroBubble", 1, 9, "vfx", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 30, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		ArcadeSprite arcadeSprite2 = RenderingExtensions.AddArcadeSprite(gameObject, pos, "vfx", "sPFX_crescent_ring_64");
		ArcadeSprite arcadeSprite3 = arcadeSprite2.setTint(65280u);
		ArcadeSprite arcadeSprite4 = arcadeSprite3.setScale(0f, (float?)(object)0);
		Transform transform = arcadeSprite4.transform;
		Vector2 vector = default(Vector2);
		transform.localEulerAngles = (Vector3)(&vector);
		_ring1 = arcadeSprite4;
		GameObject gameObject2 = base.gameObject;
		ArcadeSprite arcadeSprite5 = RenderingExtensions.AddArcadeSprite(gameObject2, pos, "vfx", "sPFX_crescent_ring_64");
		ArcadeSprite arcadeSprite6 = arcadeSprite5.setTint(65280u);
		ArcadeSprite arcadeSprite7 = arcadeSprite6.setScale(0f, (float?)(object)0);
		Transform transform2 = arcadeSprite7.transform;
		transform2.localEulerAngles = (Vector3)(&vector);
		_ring2 = arcadeSprite7;
		GameObject gameObject3 = base.gameObject;
		ArcadeSprite arcadeSprite8 = RenderingExtensions.AddArcadeSprite(gameObject3, pos, "vfx", "sPFX_crescent_ring_64");
		ArcadeSprite arcadeSprite9 = arcadeSprite8.setTint(65280u);
		ArcadeSprite arcadeSprite10 = arcadeSprite9.setScale(0f, (float?)(object)0);
		Transform transform3 = arcadeSprite10.transform;
		transform3.localEulerAngles = (Vector3)(&vector);
		_ring3 = arcadeSprite10;
		ArcadeSprite arcadeSprite11 = _ring1.setAlpha(0.333f);
		ArcadeSprite arcadeSprite12 = _ring2.setAlpha(0.333f);
		ArcadeSprite arcadeSprite13 = _ring3.setAlpha(0.333f);
		ArcadeSprite ring = _ring1;
		_ring1.CheckRenderer();
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)ring._spriteRenderer).SetMaterial(material);
		ArcadeSprite ring2 = _ring2;
		_ring2.CheckRenderer();
		Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)ring2._spriteRenderer).SetMaterial(material2);
		ArcadeSprite ring3 = _ring3;
		_ring3.CheckRenderer();
		Material material3 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)ring3._spriteRenderer).SetMaterial(material3);
		Transform transform4 = _ring1.transform;
		transform4.SetParent(_cachedTransform, worldPositionStays: true);
		Transform transform5 = _ring2.transform;
		transform5.SetParent(_cachedTransform, worldPositionStays: true);
		Transform transform6 = _ring3.transform;
		transform6.SetParent(_cachedTransform, worldPositionStays: true);
		ArcadeSprite ring4 = _ring1;
		float radius = currentBarrierScale * 16f;
		BaseBody baseBody = ring4.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		ArcadeSprite ring5 = _ring2;
		BaseBody baseBody2 = ring5.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		ArcadeSprite ring6 = _ring3;
		BaseBody baseBody3 = ring6.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		Transform transform7 = _ring1.transform;
		bool flag2 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value);
		Transform transform8 = _ring2.transform;
		bool flag3 = (object)transform8 == null;
		bool flag4 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref value2);
		bool flag5 = (object)_ring3 == null;
		Transform transform9 = _ring3.transform;
		bool flag6 = (object)transform9 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1977 @ rax_v113 (UnityEngine.Transform)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1977 @ rax_v113 (UnityEngine.Transform)+10]");
		Vector3 value3 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value3);
	}

	public override void OnRecycle()
	{
		//IL_003f: Expected I, but got O
		//IL_00b1: Expected O, but got I4
		//IL_0172: Expected I, but got O
		//IL_01ca: Expected I, but got O
		//IL_0222: Expected I, but got O
		//IL_0286: Expected O, but got I4
		if (_tween2 != null)
		{
			_tween2.Kill();
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
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				ArcadeSprite arcadeSprite = setAlpha(0f);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween2 = tween;
			if (_tweenRing1 != null)
			{
				_tweenRing1.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[3];
			if ((object)_ring1 != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_ring2 != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_ring3 != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 200f;
			tweenConfig2.scale = (float?)(object)1;
			StaggerConfig staggerConfig = new StaggerConfig();
			staggerConfig.ease = Ease.Linear;
			staggerConfig.start = 50f;
			Func<int, float> staggerDelay = Tweens.Stagger(100f, staggerConfig);
			tweenConfig2.staggerDelay = staggerDelay;
			tweenConfig2.ease = Ease.Linear;
			TweenCallback onStart2 = delegate
			{
				ArcadeSprite arcadeSprite = RenderingExtensions.SetScale(_ring1, 0f, 0.5f);
				ArcadeSprite arcadeSprite2 = RenderingExtensions.SetScale(_ring2, 0f, 0.5f);
			};
			tweenConfig2.onStart = onStart2;
			MultiTargetTween tweenRing = Tweens.Add(tweenConfig2);
			_tweenRing1 = tweenRing;
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	public override void OnDespawn()
	{
		//IL_006e: Expected I, but got O
		//IL_00e0: Expected O, but got I4
		//IL_01a1: Expected I, but got O
		//IL_01f9: Expected I, but got O
		//IL_0251: Expected I, but got O
		//IL_02b5: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
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
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				if (!isDespawning)
				{
					isDespawning = true;
					if (base._hitboxTimer != null)
					{
						base._hitboxTimer.Cancel();
					}
					OnDespawn();
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween2 = tween;
			if (_tweenRing1 != null)
			{
				_tweenRing1.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[3];
			if ((object)_ring1 != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_ring2 != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_ring3 != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 200f;
			tweenConfig2.scale = (float?)(object)1;
			StaggerConfig staggerConfig = new StaggerConfig();
			staggerConfig.ease = Ease.Linear;
			staggerConfig.start = 50f;
			Func<int, float> staggerDelay = Tweens.Stagger(50f, staggerConfig);
			tweenConfig2.staggerDelay = staggerDelay;
			tweenConfig2.ease = Ease.Linear;
			MultiTargetTween tweenRing = Tweens.Add(tweenConfig2);
			_tweenRing1 = tweenRing;
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	public override void Despawn()
	{
		if (_tweenRing1 != null)
		{
			_tweenRing1.Kill();
		}
		if (_tweenRingAngle != null)
		{
			_tweenRingAngle.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (!isDespawning)
		{
			isDespawning = true;
			if (base._hitboxTimer != null)
			{
				base._hitboxTimer.Cancel();
			}
			OnDespawn();
		}
	}

	public override void InternalUpdate()
	{
		//IL_00a3: Expected O, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Weapon weapon = _weapon;
		bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		ArcadeSprite arcadeSprite = _ring1.setFlipX(flag2);
		ArcadeSprite arcadeSprite2 = _ring2.setFlipX(flag2);
		ArcadeSprite arcadeSprite3 = _ring3.setFlipX(flag2);
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		object obj = (flag2 ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		float num2 = (float)obj3 * num;
		Transform cachedTrans = _ring1.CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		float num3 = num2 * 0.2f;
		float num4 = num3 + localEulerAngles.z;
		_ring1.angle = num4;
		Transform cachedTrans2 = _ring2.CachedTrans;
		Vector3 localEulerAngles2 = cachedTrans2.localEulerAngles;
		float num5 = num2 * 0.4f;
		float num6 = num5 + localEulerAngles2.z;
		_ring2.angle = num6;
		Transform cachedTrans3 = _ring3.CachedTrans;
		Vector3 localEulerAngles3 = cachedTrans3.localEulerAngles;
		float num7 = num2 * 0.6f;
		float num8 = num7 + localEulerAngles3.z;
		_ring3.angle = num8;
	}

	private void _003COnRecycle_003Eb__6_0()
	{
		ArcadeSprite arcadeSprite = setAlpha(0f);
	}

	private void _003COnRecycle_003Eb__6_1()
	{
		ArcadeSprite arcadeSprite = RenderingExtensions.SetScale(_ring1, 0f, 0.5f);
		ArcadeSprite arcadeSprite2 = RenderingExtensions.SetScale(_ring2, 0f, 0.5f);
	}

	private void _003COnDespawn_003Eb__7_0()
	{
		if (!isDespawning)
		{
			isDespawning = true;
			if (base._hitboxTimer != null)
			{
				base._hitboxTimer.Cancel();
			}
			OnDespawn();
		}
	}
}
