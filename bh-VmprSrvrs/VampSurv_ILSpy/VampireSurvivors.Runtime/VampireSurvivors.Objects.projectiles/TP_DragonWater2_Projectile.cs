using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DragonWater2_Projectile : Projectile
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

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				Debug.Log("Try freeze!");
				bool flag = TryFreeze(other);
			}
		}
	}

	private void _003CInitProjectile_003Eb__0_0()
	{
		_isCullable = true;
	}
}
