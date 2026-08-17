using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class InvisibleProjectile_1Frame : Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0086: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_isCullable = false;
		float num = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile_1Frame>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}
}
