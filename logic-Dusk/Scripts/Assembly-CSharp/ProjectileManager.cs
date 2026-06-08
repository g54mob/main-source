using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
	public GameObject SmallProjectilePrefab;

	public GameObject MediumProjectilePrefab;

	public GameObject LargeProjectilePrefab;

	private List<Projectile> _projectiles = new List<Projectile>();

	private int _nextUniqueProjectileId = 1;

	private readonly float DEFAULT_PROJECTILE_SPEED = 2f;

	public static ProjectileManager Instance()
	{
		return (ProjectileManager)Object.FindObjectOfType(typeof(ProjectileManager));
	}

	private void OnDestroy()
	{
		SmallProjectilePrefab = null;
		MediumProjectilePrefab = null;
		LargeProjectilePrefab = null;
	}

	private void Update()
	{
		if (GlobalSettings.IsGamePaused || _projectiles.Count <= 0)
		{
			return;
		}
		List<Projectile> list = _projectiles.ToList();
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			Projectile projectile = list[i];
			if (projectile.State == ProjectileStateEnum.Sploded || projectile.State == ProjectileStateEnum.Discard)
			{
				_projectiles.Remove(projectile);
				GameObjectPool.Instance.PushObject(projectile.gameObject);
			}
		}
	}

	public Projectile LaunchProjectile(ProjectileTypeEnum type, ICombatTarget source, ICombatTarget destination, float damage, DamageType damageType)
	{
		return LaunchProjectile(type, source, destination, damage, damageType, 0);
	}

	public Projectile LaunchProjectile(ProjectileTypeEnum type, ICombatTarget source, ICombatTarget destination, float damage, DamageType damageType, bool instantDamage)
	{
		return LaunchProjectile(type, source, destination, damage, damageType, DEFAULT_PROJECTILE_SPEED, 0, instantDamage);
	}

	public Projectile LaunchProjectile(ProjectileTypeEnum type, ICombatTarget source, ICombatTarget destination, float damage, DamageType damageType, int accuracy)
	{
		return LaunchProjectile(type, source, destination, damage, damageType, DEFAULT_PROJECTILE_SPEED, accuracy, false);
	}

	public Projectile LaunchProjectile(ProjectileTypeEnum type, ICombatTarget source, ICombatTarget destination, float damage, DamageType damageType, float speed, int accuracy, bool instantDamage)
	{
		string text = string.Empty;
		switch (type)
		{
		case ProjectileTypeEnum.Small:
			text = "SmallProjectilePrefab";
			break;
		case ProjectileTypeEnum.Medium:
			text = "MediumProjectilePrefab";
			break;
		case ProjectileTypeEnum.Large:
			text = "LargeProjectilePrefab";
			break;
		}
		GameObject gameObject = GameObjectPool.Instance.PopObject(text);
		Projectile projectile = (Projectile)gameObject.GetComponent(typeof(Projectile));
		projectile.SetId(_nextUniqueProjectileId++);
		projectile.StartProjectile(source, destination, speed, damage, damageType, accuracy, instantDamage);
		_projectiles.Add(projectile);
		return projectile;
	}
}
