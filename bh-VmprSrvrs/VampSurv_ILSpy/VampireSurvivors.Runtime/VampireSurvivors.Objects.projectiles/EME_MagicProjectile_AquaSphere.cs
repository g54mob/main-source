using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MagicProjectile_AquaSphere : Projectile
{
	protected ParticleSystem _particleSystem;

	protected ParticleEventCall _particleEventCall;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private Tween _angleTween;

	private Tween _scaleTween;

	private float _saveVelX;

	private float _saveVelY;

	private Timer _bounceTimer;

	private bool _canBounce;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0030: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		//IL_0219: Expected I4, but got F4
		//IL_028a: Expected I, but got O
		//IL_02ee: Expected O, but got I4
		//IL_0368: Expected I, but got O
		//IL_03be: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		_particleSystem.Play(withChildren: true);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody = base.body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite3 = setScale(0.2f, (float?)(object)0);
		BaseBody baseBody2 = base.body;
		_speed = 1f;
		_canBounce = true;
		baseBody2._bounce = (float2)1065353216;
		_ = 1065353216;
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody3 = base.body;
		baseBody3._onWorldBounds = true;
		Transform transform = base.AimForRandomEnemy(rotate: false);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_aquasphere, soundConfig, 300f, 5, num);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num2 = hitBoxDelay * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num2, onComplete, null, isLooped: true, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			if (_despawnTween != null)
			{
				_despawnTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.scaleY = (float?)(object)1;
				tweenConfig2.duration = 300f;
				float num5 = weapon.PDuration();
				float delay = num2 * 3f;
				tweenConfig2.delay = delay;
				TweenCallback onStart = delegate
				{
					if (_hitboxTimer != null)
					{
						_hitboxTimer.Cancel();
					}
					_particleSystem.Stop();
				};
				tweenConfig2.onStart = onStart;
				TweenCallback onComplete2 = delegate
				{
					Despawn();
				};
				tweenConfig2.onComplete = onComplete2;
				MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
				_despawnTween = despawnTween;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public override void InternalUpdate()
	{
		//IL_001c: Expected F4, but got O
		//IL_006a: Expected F4, but got I
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018721CCD4h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018721CCF5h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_015d: Expected I, but got O
		//IL_01b3: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
		if (_canBounce)
		{
			_canBounce = false;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canBounce = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			object obj2 = default(object);
			float num = (float)obj2 * -1f;
			object obj3 = default(object);
			float num2 = (float)obj3 * -1f;
			nint num3 = (nint)this;
			float projectileSpeed = base.ProjectileSpeed;
			object obj4 = default(object);
			float num4 = num * (float)obj4;
			float num5 = num2 * (float)obj4;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0209: Expected O, but got I4
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01a3;
			}
		}
		obj5 = 4294967295L;
		goto IL_01a3;
		IL_0224:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_01a3:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_0224;
			}
		}
		obj6 = 4294967295L;
		goto IL_0224;
	}

	private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
	{
		if (bdy == body)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void Despawn()
	{
		if ((object)_particleSystem != null)
		{
			_particleSystem.Stop();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesToFinish()
	{
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__13_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__13_1()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_particleSystem.Stop();
	}

	private void _003CInitProjectile_003Eb__13_2()
	{
		Despawn();
	}

	private void _003COnHasHitAnObject_003Eb__15_0()
	{
		_canBounce = true;
	}
}
