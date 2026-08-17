using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Custos3Bite_Projectile : TP_Custos_Projectile
{
	protected override void Awake()
	{
		_startFrame = 25;
		((Projectile)this).Awake();
		InitAnimation(_startFrame);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		InitLightningTrails();
	}

	public override void Bite()
	{
		float2 explosionPoint = base.ExplosionPoint;
		Vector2 pos = default(Vector2);
		Projectile projectile = _custosWeapon.AddLightningExplosionAt(pos);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4377]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base._anim.SetAnimation("bite");
		int biteCounter = base._biteCounter + 1;
		base._biteCounter = biteCounter;
	}

	public override void Despawn()
	{
		base.Despawn();
	}
}
