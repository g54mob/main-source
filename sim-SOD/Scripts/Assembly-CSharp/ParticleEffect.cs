using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "particleeffect_data", menuName = "Database/Particle Effect")]
public class ParticleEffect : SoCustomComparison
{
	public enum SpatterTrigger
	{
		off = 0,
		onBreak = 1,
		onAnyImpact = 2,
		whileInAirOrAnyImpact = 3
	}

	[Tooltip("The relative velocity this has to be travelling at on collision to break")]
	[Header("Breakage")]
	public float damageBreakPoint;

	[Tooltip("Deletes the object completely")]
	public bool deleteObject;

	[Header("VFX")]
	public GameObject effectPrefab;

	[EnableIf("deleteObject")]
	[Header("Shatter")]
	public bool shatter;

	[Tooltip("The size of the shards created")]
	public Vector3 shardSize;

	[Tooltip("Create a shard every this amount of pixels on the texture")]
	public int shardEveryXPixels;

	public float shatterForceMultiplier;

	[Tooltip("Use a glass shard material")]
	public bool isGlass;

	[Header("Spatter")]
	public SpatterTrigger spatterTrigger;

	public SpatterPatternPreset spatter;

	public float countMultiplier;

	public bool stickToActors;

	public bool spatterIsVandalism;

	[EnableIf("spatterIsVandalism")]
	public int vandalismFine;

	[Header("Object Creation")]
	public SpatterTrigger creationTrigger;

	public List<GameObject> objectPool;

	public int instances;

	public bool useRandomRotation;

	public Vector3 localEuler;

	[Header("Audio")]
	public List<AudioEvent> impactEvents;

	public List<AudioEvent> breakEvents;
}
