using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;

public class Shovel : MonoBehaviour
{
	public delegate void CoalSpawnedEvent(Transform coal);

	public const int MAX_COAL_INSTANCES = 18;

	private readonly Vector3 chunkSpawnLocalPosition = new Vector3(0.015f, 0.03f, 0.38f);

	private readonly Quaternion chunkSpawnLocalRotation = Quaternion.Euler(new Vector3(-15f, 0f, 0f));

	public float SHOVELING_ANGLE_LIMIT = 0.7071f;

	public int shovelChunksCapacity = 4;

	public GameObject[] visualCoalChunksPrefabs;

	public Collider shovelTip;

	public float penetrationSpawnStart = 0.15f;

	public float penetrationSpawnEnd = 0.32f;

	public float jointSpring = 200f;

	public float jointBreakForce = 70f;

	[SerializeField]
	private bool spawnMoreCoal;

	[SerializeField]
	private Collider[] coalSpawnBlockers;

	private Transform[] spawnAnchors;

	private LimitNumberOfInstances coalLumpInstanceLimiter;

	private LimitNumberOfInstances coalChunkInstanceLimiter;

	private Rigidbody shovelRigidBody;

	private VRTK_InteractableObject_DV interactable;

	private bool noCoalPhysics;

	private ShovelCoalChunks coalChunks;

	private float unloadTime;

	[InspectorButton("DebugSpawn", true, true)]
	public bool debugSpawn;

	public event CoalSpawnedEvent CoalSpawned;

	public event CoalSpawnedEvent CoalUnloaded;

	private void Start()
	{
		coalLumpInstanceLimiter = base.gameObject.AddComponent<LimitNumberOfInstances>();
		coalLumpInstanceLimiter.maxInstances = 18;
		FindSpawnAnchors();
		SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedReferenceSet());
	}

	private IEnumerator DelayedReferenceSet()
	{
		while (shovelRigidBody == null)
		{
			yield return null;
			shovelRigidBody = GetComponent<Rigidbody>();
		}
		if (VRManager.IsVREnabled())
		{
			while (interactable == null)
			{
				yield return null;
				interactable = GetComponent<VRTK_InteractableObject_DV>();
			}
			interactable.ignoredColliders = coalSpawnBlockers;
		}
	}

	private void OnEnable()
	{
		if (VRManager.IsVREnabled())
		{
			noCoalPhysics = true;
			SetupCoalPhysics();
		}
		else
		{
			noCoalPhysics = true;
			SetupCoalPhysics();
		}
	}

	private void OnDisable()
	{
	}

	private void SetupCoalPhysics()
	{
		ShovelNonPhysicalCoal shovelNonPhysicalCoal = base.gameObject.GetComponent<ShovelNonPhysicalCoal>();
		if (noCoalPhysics)
		{
			if (shovelNonPhysicalCoal == null)
			{
				shovelNonPhysicalCoal = base.gameObject.AddComponent<ShovelNonPhysicalCoal>();
			}
			shovelNonPhysicalCoal.shovelChunksCapacity = shovelChunksCapacity;
			shovelNonPhysicalCoal.visualCoalPrefabs = visualCoalChunksPrefabs;
		}
		else if (shovelNonPhysicalCoal != null)
		{
			Object.Destroy(shovelNonPhysicalCoal);
		}
	}

	private void FindSpawnAnchors()
	{
		List<Transform> list = new List<Transform>();
		Transform transform = base.transform.Find("[spawn anchors]");
		for (int i = 0; i < transform.childCount; i++)
		{
			list.Add(transform.GetChild(i));
		}
		spawnAnchors = list.ToArray();
	}

	private void DebugSpawn()
	{
		Spawn();
	}

	private void Spawn()
	{
		DV_GameObjectPools.GameObjectCategory gameObjectCategory = ((!spawnMoreCoal) ? DV_GameObjectPools.GameObjectCategory.CoalChunksSmall : DV_GameObjectPools.GameObjectCategory.CoalChunksLarge);
		GameObject gameObject = SingletonBehaviour<DV_GameObjectPools>.Instance.RequestObjectFromPool(gameObjectCategory);
		gameObject.SetActive(value: true);
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localPosition = chunkSpawnLocalPosition;
		gameObject.transform.localRotation = chunkSpawnLocalRotation;
		coalChunks = gameObject.GetComponent<ShovelCoalChunks>();
		coalChunks.OnSpawned(shovelRigidBody, interactable, coalLumpInstanceLimiter);
		coalChunks.ChunksUnloaded += OnChunksUnloaded;
		this.CoalSpawned?.Invoke(gameObject.transform);
	}

	private void OnChunksUnloaded()
	{
		coalChunks.ChunksUnloaded -= OnChunksUnloaded;
		this.CoalUnloaded?.Invoke(coalChunks.transform);
		unloadTime = Time.timeSinceLevelLoad;
		coalChunks = null;
	}

	public void RequestSpawnCoal(ShovelCoalPile pile)
	{
		if (SpawnAllowed(pile))
		{
			Spawn();
		}
	}

	private bool SpawnAllowed(ShovelCoalPile pile)
	{
		if (coalChunks != null)
		{
			return false;
		}
		if (noCoalPhysics || pile == null)
		{
			return false;
		}
		if (Time.timeSinceLevelLoad - unloadTime < 0.5f)
		{
			return false;
		}
		float num = Vector3.Dot(Vector3.up, base.transform.up);
		if (num < 0f || Mathf.Abs(num) < SHOVELING_ANGLE_LIMIT)
		{
			return false;
		}
		return true;
	}
}
