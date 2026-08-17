using System;
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
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PunchProjectile_Raksha : Projectile
{
	private ParticleSystem rakshaSparksVFX;

	private ParticleSystem rakshaImpactBigVFX;

	private ParticleSystem rakshaImpactSmallVFX;

	private ParticleSystem rakshaPunchVFX;

	private ParticleSystem rakshaExplosionVFX;

	private ParticleEventCall rakshaExplosionVFXparticleEventCall;

	private float radius = 32f;

	private bool _isDespawning;

	private Tween _radiusTween;

	private TweenerCore<Vector3, Vector3, VectorOptions> _moveTween;

	private Vector3 _targetPosition;

	private bool _showVfx;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00be: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		SetupVisuals();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_showVfx = config._003CFlashingVFXEnabled_003Ek__BackingField;
	}

	private void SetupMechanics()
	{
		//IL_006d: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
	}

	private void SetupVisuals()
	{
		//IL_0102->IL00a7: Incompatible stack heights: 1 vs 0
		//IL_005b->IL00a7: Incompatible stack heights: 1 vs 0
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					if (!characterController._isFlipped)
					{
					}
					Transform transform2 = base.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
					bool flag4 = (object)rakshaPunchVFX == null;
					rakshaPunchVFX.Play(withChildren: true);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Strike()
	{
		//IL_0034: Expected O, but got Ref
		//IL_011b: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(target, (Vector3)(&obj), 0.15f);
		TweenCallback tweenCallback = Explode;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		_moveTween = tweenerCore;
		TweenerCore<Vector3, Vector3, VectorOptions> moveTween = _moveTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_Punch2, soundConfig, 100f, 2, time);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void Explode()
	{
		//IL_013a: Expected O, but got I4
		//IL_01c4: Expected F4, but got I4
		if (!_isDespawning)
		{
			Tween moveTween = _moveTween;
			if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(_moveTween);
			}
			if ((object)rakshaPunchVFX != null)
			{
				rakshaPunchVFX.Stop();
			}
			if ((object)rakshaPunchVFX != null)
			{
				rakshaPunchVFX.Clear(withChildren: true);
			}
			ParticleEventCall component = rakshaExplosionVFX.GetComponent<ParticleEventCall>();
			if ((object)component != null)
			{
				component._eventCalled = false;
			}
			rakshaExplosionVFX.Play(withChildren: true);
			float num = _weapon.PArea();
			float num2 = default(float);
			ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
			float num3 = num2 * 0.5f;
			ParticleSystem particleSystem = RenderingExtensions.SetScale(rakshaSparksVFX, num3);
			ParticleSystem particleSystem2 = RenderingExtensions.SetScale(rakshaImpactBigVFX, num2);
			ParticleSystem particleSystem3 = RenderingExtensions.SetScale(rakshaImpactSmallVFX, num2);
			bool flag = _showVfx;
			float num4 = num2;
			if (!flag)
			{
				num4 = 0f;
			}
			ParticleSystem particleSystem4 = RenderingExtensions.SetScale(rakshaExplosionVFX, num4);
		}
	}

	public void SetTargetPosition(Vector3 target)
	{
		//IL_009e: Expected O, but got F4
		Tween moveTween = _moveTween;
		_targetPosition = (Vector3)target.x;
		_ = target.z;
		if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_moveTween);
		}
		Action onComplete = Strike;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void StartDespawn()
	{
		BaseBody baseBody = body;
		_isDespawning = true;
		baseBody._enable = false;
		Tween moveTween = _moveTween;
		if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_moveTween);
		}
		if ((object)rakshaExplosionVFX != null)
		{
			rakshaExplosionVFX.Stop();
		}
		if ((object)rakshaExplosionVFX != null)
		{
			rakshaExplosionVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void DespawnAfterParticlesStopped()
	{
		if ((object)rakshaExplosionVFX != null)
		{
			rakshaExplosionVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void FinishDespawn()
	{
		if ((object)rakshaExplosionVFX != null)
		{
			rakshaExplosionVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}
}
