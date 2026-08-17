using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KnifeProjectile_MoonfallSlash : EME_KnifeProjectile
{
	public override bool DoExplosions => true;

	public override float DurationMultiplier => 2f;

	protected override void Awake()
	{
		base.Awake();
		_speed = 2f;
	}

	public override Color[][] GetTints()
	{
		return _tints2;
	}

	public override void FireSpecialBullets()
	{
		EME_Knife1Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			float2 float5 = base.position;
			float2 pos = default(float2);
			Projectile projectile = trueWeapon._moonfallPool.SpawnAt(pos, _trueWeapon);
		}
	}
}
