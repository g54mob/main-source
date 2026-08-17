using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_SpearProjectile : Projectile
{
	protected SpriteRenderer _SpearSprite;

	protected TrailRenderer _LineTrail;

	protected string _spearSpriteName;

	protected float _area;

	private Vector2 _velocity;

	private EME_Spear1Weapon _trueWeapon;

	private MultiTargetTween _fadeTween;

	private Timer _expireTimer;

	private PhaserSprite _portalSprite;

	private MultiTargetTween _portalTween;

	protected virtual float Radius => 90f;

	protected virtual float ScaleMultiplier => 0.25f;

	protected virtual float InitialSpeed => 6f;

	protected virtual float DecelRate => 10f;

	protected virtual bool UsesPortalVFX => false;

	protected virtual float PortalVFXScale => 1f;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_02dd: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_010e: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0184: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		float initialSpeed = InitialSpeed;
		Weapon weapon2 = _weapon;
		float num = default(float);
		_speed = num;
		_isCullable = false;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_02b6;
		}
		nint num2 = (nint)typeof(EME_Spear1Weapon);
		int num3 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Spear1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v10 (System.Int32)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Spear1Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v10 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v53+FFFFFFF8+v76 @ rax_v48*8]");
			if (0 == (nint)typeof(EME_Spear1Weapon))
			{
				obj3 = 1;
				goto IL_02c5;
			}
		}
		obj3 = 0;
		goto IL_02c5;
		IL_02c5:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_02b6;
		IL_02b6:
		_trueWeapon = (EME_Spear1Weapon)trueWeapon;
		float num5 = _weapon.PArea();
		float scaleMultiplier = ScaleMultiplier;
		float num6 = (_area = num * num);
		ArcadeSprite arcadeSprite = setScale(num6, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._enable = true;
		float radius = Radius;
		float radius2 = Radius;
		float radius3 = Radius;
		BaseBody baseBody2 = body.setCircle(num6, (float?)(object)1, (float?)(object)1);
		object obj4 = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj4));
		BaseBody baseBody3 = body;
		_velocity = baseBody3._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v25 (BaseBody)+74]");
		_ = 0;
		SetupSpearSprite();
		SetupTrail();
		DoSpearFadeIn();
		DoPortalVfx();
		PlaySfx();
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete = StartDespawn;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void InternalUpdate()
	{
		//IL_006e: Expected O, but got F4
		//IL_0097: Expected O, but got F4
		float decelRate = DecelRate;
		float deltaTime = PauseSystem.DeltaTime;
		object obj = default(object);
		float num = deltaTime * (float)obj;
		float num2 = 1f - num;
		float num3 = (float)_velocity * num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_SpearProjectile)+F0]");
		float num4 = 0f * num2;
		ArcadeSprite sprite = _sprite;
		_velocity = (Vector2)num3;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num3;
	}

	public unsafe void SetVelocityForTriumvirate(float rotation)
	{
		//IL_0164: Expected F4, but got O
		float projectileSpeed = base.ProjectileSpeed;
		float speed = default(float);
		Vector2 vector = SetVelocityFromRotation(rotation, speed);
		BaseBody baseBody = body;
		_velocity = baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v4 (BaseBody)+74]");
		_ = 0;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion ret);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _portalSprite.transform;
		Transform transform3 = base.transform;
		bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.get_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
		bool flag3 = (object)transform2 == null;
		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)(&axis));
	}

	private void UpdateVelocity()
	{
		//IL_006e: Expected O, but got F4
		//IL_0097: Expected O, but got F4
		float decelRate = DecelRate;
		float deltaTime = PauseSystem.DeltaTime;
		object obj = default(object);
		float num = deltaTime * (float)obj;
		float num2 = 1f - num;
		float num3 = (float)_velocity * num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_SpearProjectile)+F0]");
		float num4 = 0f * num2;
		ArcadeSprite sprite = _sprite;
		_velocity = (Vector2)num3;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num3;
	}

	protected virtual void SetupTrail()
	{
		TrailRenderer lineTrail = _LineTrail;
		if ((object)_LineTrail != null && ((UnityEngine.Object)lineTrail).m_CachedPtr != (IntPtr)0)
		{
			string text = _spearSpriteName + "_Trail2";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			float num = _area * 0.3f;
			_LineTrail.time = 0.6f;
			_LineTrail.startWidth = num;
			_LineTrail.endWidth = num;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_LineTrail, sprite, false);
			Material material = ((Renderer)_LineTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
			_LineTrail.Clear();
			_LineTrail.emitting = true;
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LineTrail);
		}
	}

	private void SetupSpearSprite()
	{
		SpriteRenderer spearSprite = _SpearSprite;
		if ((object)_SpearSprite != null && ((UnityEngine.Object)spearSprite).m_CachedPtr != (IntPtr)0)
		{
			Weapon weapon = _weapon;
			string spearSpriteName = GetSpearSpriteName(((Equipment)weapon)._equipmentType);
			_spearSpriteName = spearSpriteName;
			Sprite sprite = SpriteManager.GetSprite(_spearSpriteName, "Emeralds_VFX");
			_SpearSprite.sprite = sprite;
		}
	}

	protected virtual string GetSpearSpriteName(WeaponType weapon = WeaponType.VOID)
	{
		//IL_008f: Expected O, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4A72]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = weapon - 398;
		bool flag = weapon == WeaponType.EME_SPEAR1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				return "EME_Spear_Feather2";
			}
			if ((nint)obj2 == 1)
			{
				return "EME_Spear_Lohengrin2";
			}
		}
		return "EME_Spear_Glaive2";
	}

	private void DoSpearFadeIn()
	{
		//IL_00c7: Expected I, but got O
		//IL_012b: Expected O, but got I4
		SpriteRenderer spearSprite = _SpearSprite;
		if ((object)_SpearSprite == null || ((UnityEngine.Object)spearSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_SpearSprite, 0f);
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_SpearSprite != null)
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
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	private void DoPortalVfx()
	{
		//IL_00c4: Expected O, but got I4
		//IL_00c4: Expected F4, but got O
		//IL_0339: Expected F4, but got O
		//IL_01b9: Expected I, but got O
		//IL_023b: Expected O, but got I4
		//IL_02ce->IL025c: Incompatible stack heights: 1 vs 0
		//IL_0074->IL025c: Incompatible stack heights: 1 vs 0
		//IL_00ad->IL025c: Incompatible stack heights: 1 vs 0
		//IL_00e0->IL025c: Incompatible stack heights: 1 vs 0
		//IL_010a->IL025c: Incompatible stack heights: 1 vs 0
		//IL_0146->IL025c: Incompatible stack heights: 1 vs 0
		//IL_01dc->IL01dc: Incompatible stack heights: 5 vs 4
		//IL_025c->IL0325: Incompatible stack heights: 5 vs 0
		if (!UsesPortalVFX)
		{
			return;
		}
		PhaserWorld instance = PhaserWorld.Instance;
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			if ((object)instance != null)
			{
				Vector2 vector = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "Emeralds_VFX", "EME_DivineLancer");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
					float portalVFXScale = PortalVFXScale;
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setScale((float)vector, (float?)(object)0);
						if ((object)phaserSprite3 != null)
						{
							GameObject gameObject = phaserSprite3.gameObject;
							if ((object)gameObject != null)
							{
								((UnityEngine.Object)gameObject).SetName("EME_Spear_PortalSprite");
								_portalSprite = phaserSprite3;
								if ((object)_portalSprite != null)
								{
									Transform transform = _portalSprite.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
									Quaternion.AngleAxis_Injected((float)_portalSprite, ref ret, out Quaternion _);
									bool flag2 = (object)transform == null;
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Quaternion value = default(Quaternion);
									Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									bool flag4 = array == null;
									if ((object)_portalSprite != null)
									{
										nint num = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj = default(object);
										bool flag5 = obj == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									bool flag6 = tweenConfig == null;
									tweenConfig.targets = array;
									tweenConfig.duration = 500f;
									tweenConfig.yoyo = true;
									tweenConfig.alpha = (float?)(object)1;
									MultiTargetTween portalTween = Tweens.Add(tweenConfig);
									_portalTween = portalTween;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_spear, soundConfig, 200f, 5, time);
	}

	private void StartDespawn()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		//IL_010a: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_SpearSprite != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpearProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public override void Despawn()
	{
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_portalTween != null)
		{
			_portalTween.Kill();
		}
		PhaserSprite portalSprite = _portalSprite;
		if ((object)_portalSprite != null && ((UnityEngine.Object)portalSprite).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _portalSprite.gameObject;
			gameObject.SetActive(value: false);
		}
		base.Despawn();
	}
}
