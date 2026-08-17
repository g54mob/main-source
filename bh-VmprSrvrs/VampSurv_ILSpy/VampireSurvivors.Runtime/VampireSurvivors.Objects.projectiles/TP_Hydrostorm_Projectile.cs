using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Hydrostorm_Projectile : Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0046: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0099: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		float num = _weapon.PArea();
		object obj = default(object);
		float radius = (float)obj * 10f;
		BaseBody baseBody = sprite.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_isCullable = false;
		_speed = 5f;
		ArcadeSprite sprite2 = _sprite;
		float projectileSpeed = GameManager.ProjectileSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = projectileSpeed ^ 0;
		object obj3 = obj2 * _speed;
		BaseBody baseBody2 = sprite2.body;
		baseBody2._velocity = (float2)0;
		Action onComplete = delegate
		{
			_isCullable = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void SetBodyRadius(float radius)
	{
		//IL_0022: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(radius, (float?)(object)1, (float?)(object)1);
	}

	private void _003CInitProjectile_003Eb__0_0()
	{
		_isCullable = true;
	}
}
