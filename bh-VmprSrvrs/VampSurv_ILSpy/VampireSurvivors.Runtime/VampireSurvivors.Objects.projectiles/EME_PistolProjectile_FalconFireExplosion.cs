using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PistolProjectile_FalconFireExplosion : Projectile
{
	private ParticleSystem explosionVFX;

	private Timer _expireTimer;

	private Timer _damageTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0075: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		//IL_0190: Expected I, but got O
		//IL_0249: Expected O, but got F4
		//IL_0275: Expected O, but got I4
		//IL_020f: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		_isCullable = false;
		baseBody._enable = true;
		float num = _weapon.PArea();
		float num2 = default(float);
		bool flag = num2 > 3f;
		float xScale = 3f;
		if (!flag)
		{
			xScale = num2;
		}
		BaseBody baseBody2 = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		if ((object)explosionVFX != null)
		{
			explosionVFX.Play(withChildren: true);
		}
		if (_damageTimer != null)
		{
			_damageTimer.Cancel();
		}
		Action onComplete = StopDamage;
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer damageTimer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_damageTimer = damageTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile_FalconFireExplosion>)+370]");
		Action onComplete2 = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		Timer expireTimer = Timers.Register(1.2f, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float detune = 1.2f * 400f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_boundshot, soundConfig, 200f, 2, flag2 ? 1 : 0);
	}

	public void StopDamage()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isCullable = true;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_damageTimer != null)
		{
			_damageTimer.Cancel();
		}
		if ((object)explosionVFX != null)
		{
			explosionVFX.Stop();
		}
		if ((object)explosionVFX != null)
		{
			explosionVFX.Clear(withChildren: true);
		}
		base.Despawn();
	}
}
