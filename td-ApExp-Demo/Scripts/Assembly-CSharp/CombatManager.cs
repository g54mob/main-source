using System;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
	public static CombatManager Instance { get; private set; }

	public List<Projectile> Projectiles { get; private set; }

	public List<Explosion> Explosions { get; private set; }

	public event Action<Explosion> ExplosionSpawned;

	public event Action<Explosion> ExplosionDestroyed;

	public event Action<HealthChangeInfo> HealthChanged;

	public event Action<HealthChangeInfo> DamageHealed;

	public event Action<EnemyBase, Unit, HealthChangeInfo> EnemyKilled;

	private void Awake()
	{
		Instance = this;
		Projectiles = new List<Projectile>();
		Explosions = new List<Explosion>();
	}

	public void OnHealthChanged(HealthChangeInfo info)
	{
		if ((!(info.Target.GetComponent<EnemyBase>() != null) || !info.Target.IsDead) && info.HealthChange != 0f)
		{
			this.HealthChanged?.Invoke(info);
		}
	}

	public void OnDamageHealed(HealthChangeInfo info)
	{
		this.DamageHealed?.Invoke(info);
	}

	public void OnEnemyKilled(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		this.EnemyKilled?.Invoke(enemy, killer, info);
	}

	public void RegisterProjectile(Projectile projectile)
	{
		if (!Projectiles.Contains(projectile))
		{
			Projectiles.Add(projectile);
		}
	}

	public void DeregisterProjectile(Projectile projectile)
	{
		if (Projectiles.Contains(projectile))
		{
			Projectiles.Remove(projectile);
		}
	}

	public void RegisterExplosion(Explosion explosion)
	{
		if (!Explosions.Contains(explosion))
		{
			Explosions.Add(explosion);
		}
	}

	private void DeregisterExplosion(Explosion explosion)
	{
		if (Explosions.Contains(explosion))
		{
			Explosions.Remove(explosion);
		}
	}

	public void OnExplosionSpawned(Explosion explosion)
	{
		this.ExplosionSpawned?.Invoke(explosion);
		RegisterExplosion(explosion);
	}

	public void OnExplosionDestroyed(Explosion explosion)
	{
		this.ExplosionDestroyed?.Invoke(explosion);
		DeregisterExplosion(explosion);
	}

	public void DestroyProjectiles()
	{
		List<Projectile> projectiles = Projectiles;
		for (int i = 0; i < projectiles.Count; i++)
		{
			if (!(projectiles[i] == null))
			{
				projectiles[i].DestroyProjectile();
			}
		}
	}
}
