using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PistolProjectile : Projectile
{
	private ParticleSystem pistolBasicVFX;

	private ParticleSystem pistolTargetingVFX;

	private ParticleEventCall pistolBasicParticleEventCall;

	private ParticleEventCall pistolTargetingParticleEventCall;

	protected EnemyController _targetEnemyController;

	private Timer _prefireTimer;

	private Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
		if ((object)pistolTargetingVFX != null)
		{
			Transform component = pistolTargetingVFX.transform;
			Transform transform = RenderingExtensions.SetScale(component, 0.33f);
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isCullable = false;
	}

	public void setEnemyTarget(EnemyController enemyTarget)
	{
		//IL_0281: Expected I, but got O
		//IL_00a2: Expected I, but got O
		//IL_0100: Expected O, but got I4
		//IL_012f: Expected F4, but got I4
		//IL_0237->IL033e: Incompatible stack heights: 1 vs 0
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if ((object)enemyTarget != null && ((UnityEngine.Object)enemyTarget).m_CachedPtr != (IntPtr)0 && enemyTarget.body != null)
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			Timer expireTimer = Timers.Register(1f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_aiming, soundConfig, 300f, 1, flag ? 1 : 0);
			_targetEnemyController = enemyTarget;
			EnemyController targetEnemyController = _targetEnemyController;
			Vector2 vector = targetEnemyController._EnemyRenderer.size;
			Transform transform = pistolTargetingVFX.transform;
			float2 float5 = _targetEnemyController.position;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if ((object)pistolTargetingVFX != null)
			{
				pistolTargetingVFX.Play(withChildren: true);
			}
			if (_prefireTimer != null)
			{
				_prefireTimer.Cancel();
			}
			Action onComplete2 = EnableProjectileLaunch;
			Timer prefireTimer = Timers.Register(0.3f, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_prefireTimer = prefireTimer;
		}
		else
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile>)+370]");
			Action onComplete3 = new Action(this, (IntPtr)0);
			nint num2 = (nint)this;
			Timer expireTimer2 = Timers.Register(0.001f, onComplete3, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer2;
		}
	}

	public void EnableProjectileLaunch()
	{
		//IL_012b: Expected O, but got F4
		//IL_0159: Expected O, but got I4
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController != null && ((UnityEngine.Object)targetEnemyController).m_CachedPtr != (IntPtr)0)
		{
			EnemyController targetEnemyController2 = _targetEnemyController;
			if (targetEnemyController2.body != null)
			{
				_weapon.DealDamage(_targetEnemyController);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				object obj = UnityEngine.Random.value;
				object obj2 = default(object);
				float num = (float)obj2 - 0.5f;
				float detune = num * 500f;
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_gunshot, soundConfig, 300f, 1, time);
				if ((object)pistolBasicVFX != null)
				{
					pistolBasicVFX.Play(withChildren: true);
				}
				return;
			}
		}
		Despawn();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if ((object)pistolBasicVFX != null)
		{
			pistolBasicVFX.Stop();
		}
		if ((object)pistolBasicVFX != null)
		{
			pistolBasicVFX.Clear(withChildren: true);
		}
		if ((object)pistolTargetingVFX != null)
		{
			pistolTargetingVFX.Stop();
		}
		if ((object)pistolTargetingVFX != null)
		{
			pistolTargetingVFX.Stop();
		}
		base.Despawn();
	}
}
