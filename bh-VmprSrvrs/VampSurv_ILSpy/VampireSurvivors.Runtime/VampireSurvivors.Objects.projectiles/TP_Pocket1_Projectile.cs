using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Pocket1_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private const float Radius = 8f;

	private Timer _expireTimer;

	private Tween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1710]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_PocketKnife01");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("KnifeSprite");
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_007d: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		_speed = 2.5f;
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		SetScaleToArea();
		SetupTrail();
		Weapon weapon2 = _weapon;
		if (!weapon2.IsHoming)
		{
			object obj = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj));
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete = StartDespawn;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private unsafe void InitAiming()
	{
		//IL_0043: Expected O, but got Ref
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			object obj = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj));
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
	}

	private void StartTimers()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete = StartDespawn;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private unsafe void SetupTrail()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA19]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string value = "PfxLine";
		Sprite sprite = SpriteManager.GetSprite("PfxLine", "vfx");
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.01f;
		_Trail.time = 0.25f;
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.set_startColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref *(Color*)(&value));
		TrailRenderer trail2 = _Trail;
		bool flag2 = (object)_Trail == null;
		bool flag3 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
		Color value2 = default(Color);
		TrailRenderer.set_endColor_Injected(((UnityEngine.Object)trail2).m_CachedPtr, ref value2);
		bool flag4 = (object)_Trail == null;
		_Trail.endWidth = num2;
		_Trail.startWidth = num2;
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
		bool flag5 = (object)_Trail == null;
		Material material = ((Renderer)_Trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0.6f);
		object trail3 = _Trail;
		bool flag6 = (object)_Trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdi_v13 (System.Object)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdi_v13 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		bool flag8 = (object)_Trail == null;
		_Trail.emitting = true;
		TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			Despawn();
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && triggerHit && --_penetrating <= 0)
		{
			Despawn();
		}
	}

	private void StartDespawn()
	{
		//IL_0053: Expected I, but got O
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket1_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		base.Despawn();
	}
}
