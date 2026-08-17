using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_LongswordProjectile_GaleSlash : Projectile
{
	private MeshRenderer galeSlashVFX;

	private const float RADIUS = 50f;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private MultiTargetTween _scaleTween;

	public override float ProjectileSpeed => GameManager.ProjectileSpeed * _speed;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0079: Expected O, but got F4
		//IL_00a7: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 4f;
		SetupMechanics();
		SetupVFX();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 500f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_gale, soundConfig, 100f, 5, time);
	}

	private unsafe void SetupMechanics()
	{
		//IL_02ec: Expected O, but got F4
		//IL_007e: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_0113: Expected I, but got O
		//IL_0173: Expected O, but got I4
		//IL_0287: Expected I, but got O
		//IL_02dd: Expected O, but got Ref
		object obj = UnityEngine.Random.value;
		float num = _weapon.PArea();
		_isCullable = false;
		object obj2 = default(object);
		float num2 = (float)obj2 - 1f;
		float num3 = num2 * (float)obj2;
		float num4 = num3 * 0.5f;
		float num5 = num4 + 1f;
		float num6 = num5 * 70f;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj3 = num6 ^ 0;
		BaseBody baseBody = body.setCircle(num6, (float?)(object)1, (float?)(object)1);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num7 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		bool flag = obj4 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 150f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v763 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_GaleSlash>)+370]");
		Action onComplete2 = new Action(this, (IntPtr)0);
		nint num8 = (nint)this;
		Timer expireTimer = Timers.Register(5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		object obj5 = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj5));
	}

	private void SetupVFX()
	{
		//IL_0136->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_00ad->IL00e5: Incompatible stack heights: 1 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			if ((object)galeSlashVFX != null)
			{
				Transform transform = galeSlashVFX.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)galeSlashVFX != null)
					{
						Transform transform2 = galeSlashVFX.transform;
						if ((object)_weapon != null)
						{
							float num2 = _weapon.PArea();
							bool flag2 = (object)transform2 == null;
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value2 = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CSetupMechanics_003Eb__8_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
