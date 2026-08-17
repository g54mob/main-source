using System;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPile3 : EnemyPile1
{
	protected override float FireDelay()
	{
		return 1f;
	}

	protected override void Fire()
	{
		//IL_0081->IL003b: Incompatible stack heights: 1 vs 0
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			Transform cachedTransform = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			base.FireEnemyAsBullet(spawnPos, _bulletType);
		}
	}

	public EnemyPile3()
	{
		_bulletType = EnemyType.BULLET_1;
		((EnemyController)this)._002Ector();
	}
}
