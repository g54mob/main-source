using System;
using UnityEngine;

[Serializable]
public class EnemySpawn
{
	[NonSerialized]
	public bool isArmored;

	[field: SerializeField]
	[field: Tooltip("The time after the wave begins at which this enemy spawns. This overrides wave time between spawns. Set this to -1 if you want to ignore it.")]
	public float SpawnTime { get; private set; } = -1f;

	[field: SerializeField]
	public EnemyTypes EnemyType { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Decides the position at which the enemy spawns, 0 starting from the top of the screen and going clockwise.")]
	public float SpawnAngle { get; private set; }

	[field: SerializeField]
	[field: Tooltip("How much the angle randomly deviates from the spawn angle, e.g. spawn angle 0 with 90 variance will spawn between 315 and 45.")]
	public float AngleVariance { get; private set; }
}
