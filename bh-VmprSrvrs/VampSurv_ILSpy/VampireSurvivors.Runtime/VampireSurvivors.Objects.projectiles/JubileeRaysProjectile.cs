using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class JubileeRaysProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _emitterCounter;

	private int _basePixelSize = 48;

	private Timer _expireTimer;

	private float _yOffset;

	protected override void Awake()
	{
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_speed = 8f;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0216: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0035: Expected F4, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00e0: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = base.body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(_basePixelSize, (float?)(object)0);
		float2 float5 = base.position;
		_yOffset = -0.5f;
		float2 float6 = base.position;
		float2 float7 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float8 = default(float2);
		base.position = float8;
		float projectileSpeed = base.ProjectileSpeed;
		int num = ~_indexInWeapon;
		int num2 = num & 1;
		object obj = num2 * 2;
		object obj2 = obj - 1;
		float xVel = (float)obj2 * (float)float8;
		setVelocity(xVel, (float?)(object)1);
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody2 = base.body;
		baseBody2._onWorldBounds = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num3 = weapon.PDuration();
		Action onComplete = delegate
		{
			base.Despawn();
		};
		float num4 = (float)float8 * 10f;
		float duration = num4 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float7 = default(float2);
		base.position = float7;
	}

	private void _003CInitProjectile_003Eb__6_0()
	{
		base.Despawn();
	}
}
