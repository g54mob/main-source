using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PunchProjectile_Firefist : Projectile
{
	private ParticleSystem firefistVFX;

	private ParticleEventCall firefistVFXparticleEventCall;

	private const float VFXDuration = 2000f;

	private float height = 128f;

	private Vector3 _firefistPillarScale;

	private float2 _bodySize;

	private float2 _bodyOffset;

	private Timer _bodyTimer;

	private Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_renderer, 2f);
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				if ((object)firefistVFX != null)
				{
					Transform transform = firefistVFX.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						_firefistPillarScale = ret;
						_ = 0;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0069: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SetupMechanics();
		Transform transform = firefistVFX.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		firefistVFX.Play(withChildren: true);
		float num = _weapon.PArea();
		float xScale = (float)_firefistPillarScale - 0.5f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Rate = 1f,
			Volume = (float?)(object)1
		};
		float detune = (float)_indexInWeapon - 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_punch3, soundConfig, 100f, 2, time);
	}

	private void SetupMechanics()
	{
		//IL_01ae: Expected O, but got I4
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01e5: Expected O, but got F4
		//IL_00f8: Expected I, but got O
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		BaseBody baseBody = body;
		_bodySize = (float2)1115684864;
		float2 bodySize = _bodySize;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = bodySize ^ 0;
		float num = (float)obj * 0.5f;
		_ = 0;
		_bodyOffset = (float2)num;
		baseBody._enable = true;
		UpdateBody();
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		Action onComplete = delegate
		{
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Firefist>)+370]");
		Action onComplete2 = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		Timer expireTimer = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private void SetupVFX()
	{
		//IL_0064: Expected O, but got I4
		Transform transform = firefistVFX.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		firefistVFX.Play(withChildren: true);
		float num = _weapon.PArea();
		float xScale = (float)_firefistPillarScale - 0.5f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}

	public override void InternalUpdate()
	{
		UpdateBody();
	}

	private void UpdateBody()
	{
		//IL_0067: Invalid comparison between F4 and I
		//IL_00ad: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_008e: Expected F4, but got I
		//IL_00e9: Expected O, but got I4
		//IL_00e9: Expected F4, but got O
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 550f;
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Firefist)+F4]");
			float num3 = num2 + 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10EF0]");
			if (num4 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10EF0]");
				num3 = 0f;
			}
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			float num5 = 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Firefist)+F4]");
			float num6 = num5 - 0f;
			BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
		}
	}

	public override void Despawn()
	{
		if ((object)firefistVFX != null)
		{
			firefistVFX.Clear(withChildren: true);
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesStopped()
	{
		if ((object)firefistVFX != null)
		{
			firefistVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void FinishDespawn()
	{
		if ((object)firefistVFX != null)
		{
			firefistVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
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

	private void _003CSetupMechanics_003Eb__11_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
