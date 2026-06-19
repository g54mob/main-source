using System;
using UnityEngine;

[CreateAssetMenu]
public class MobType : ScriptableObject
{
	public enum MobBehaviour
	{
		Neutral = 0,
		Enemy = 1,
		EnemyMeleeAndRanged = 2,
		Dragon = 3
	}

	[Serializable]
	public enum Weakness
	{
		Sharp = 0,
		Blunt = 1,
		Water = 2,
		Fire = 3,
		Lightning = 4
	}

	public new string name;

	public GameObject mobPrefab;

	public MobBehaviour behaviour;

	public bool ranged;

	public float rangedCooldown = 6f;

	public float startAttackDistance = 1f;

	public float startRangedAttackDistance = 5f;

	public float maxAttackDistance = 1f;

	public float speed;

	public float spawnTime = 1f;

	public float minAttackAngle = 20f;

	public float sharpDefense;

	public float defense;

	public float knockbackThreshold = 0.2f;

	public bool ignoreBuilds;

	public float followPlayerDistance = 1f;

	public float followPlayerAccuracy = 0.15f;

	public bool onlyRangedInRangedPattern;

	public Weakness[] weaknesses;

	public bool boss;

	public int id { get; set; }
}
