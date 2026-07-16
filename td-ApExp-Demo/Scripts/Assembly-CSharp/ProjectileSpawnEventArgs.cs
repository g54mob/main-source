using System;
using UnityEngine;

public class ProjectileSpawnEventArgs : EventArgs
{
	public object Source { get; private set; }

	public Projectile Projectile { get; private set; }

	public Vector2 Direction { get; private set; }

	public ProjectileSpawnEventArgs(object sourceObject, Projectile projectile, Vector2 direction)
	{
		Source = sourceObject;
		Projectile = projectile;
		Direction = direction;
	}
}
