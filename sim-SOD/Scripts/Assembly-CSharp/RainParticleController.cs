using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class RainParticleController : MonoBehaviour
{
	public class RainParticle
	{
		public Transform trans;

		public float speed;
	}

	[Tooltip("Rain speed")]
	[Header("Rain Settings")]
	public Vector2 speed;

	[Tooltip("Spawn particles this high (local position)")]
	public float spawnHeight;

	[Tooltip("The world Y position upon which the particles are set to the top of the simulation.")]
	public float rainFloorWorldYPos;

	[Tooltip("Minimum time between spawning particles (seconds)")]
	public Vector2 spawnInterval;

	public GameObject particlePrefab;

	public Vector3 rotationEuler;

	[Header("Snow Settings")]
	[Tooltip("Rain speed")]
	public Vector2 speedSnow;

	[Tooltip("Spawn particles this high (local position)")]
	public float spawnHeightSnow;

	[Tooltip("The world Y position upon which the particles are set to the top of the simulation.")]
	public float snowFloorWorldYPos;

	[Tooltip("Minimum time between spawning particles (seconds)")]
	public Vector2 spawnIntervalSnow;

	public GameObject particlePrefabSnow;

	public Vector3 rotationEulerSnow;

	public bool billboard;

	[Header("State")]
	[ReadOnly]
	public int desiredParticleCount;

	[ReadOnly]
	public int actualParticleCount;

	[ReadOnly]
	public List<RainParticle> particles;

	private float spawnIntervalTimer;

	public bool snowMode;

	[ReadOnly]
	public List<NewNode> validSpawnNodes;

	private static RainParticleController _instance;

	public static RainParticleController Instance => null;

	private void Awake()
	{
	}

	public void SetSnowMode(bool val, bool forceUpdate = false)
	{
	}

	public void UpdateValidSpawnNodes()
	{
	}

	private void Update()
	{
	}

	private bool GetSpawnPosition(out Vector3 spawn)
	{
		spawn = default(Vector3);
		return false;
	}
}
