using System.Collections;
using DV;
using DV.TerrainSystem;
using DV.Utils;
using UnityEngine;

[RequireComponent(typeof(CouplingScannerReferences))]
public class BufferStop : MonoBehaviour
{
	private const float BUFFER_STOP_MASS_AFTER_BREAK = 30000f;

	public static readonly Vector3 COUPLER_POINT = new Vector3(0f, 1f, 2.5f);

	[Header("Settings")]
	[Tooltip("The squared velocity in m/s a train must be travelling at in order to break the buffer.")]
	public float breakVelocitySqr = 49f;

	[Header("Colliders")]
	[Tooltip("The collider used to detect if a train spawned inside the buffer while loading the game.")]
	public BoxCollider spawnOverlapCollider;

	[Tooltip("The trigger used to enable physics when a train is oncoming.")]
	public Collider triggerCollider;

	private Rigidbody rb;

	private bool isBroken;

	private void Awake()
	{
		base.gameObject.SetActive(value: false);
		SingletonBehaviour<CoroutineManager>.Instance.Run(CheckForOverlappingTrain());
	}

	private IEnumerator CheckForOverlappingTrain()
	{
		if ((bool)SingletonBehaviour<SaveGameManager>.Instance)
		{
			while (!AStartGameData.carsAndJobsLoadingFinished)
			{
				yield return null;
			}
		}
		foreach (RaycastHitDV item in PhysicsQueryBuilder.OverlapBox(spawnOverlapCollider.transform.TransformPoint(spawnOverlapCollider.center), spawnOverlapCollider.size / 2f, spawnOverlapCollider.transform.rotation, Layers.DVLayerMask.Train_Big_Collider.ToLayerMask()))
		{
			if (item.rigidbody?.TryGetComponent<TrainCar>(out var _) ?? false)
			{
				yield break;
			}
		}
		base.gameObject.SetActive(value: true);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isBroken || TutorialHelper.InRestrictedMode)
		{
			return;
		}
		Rigidbody attachedRigidbody = other.attachedRigidbody;
		if ((object)attachedRigidbody != null && attachedRigidbody.TryGetComponent<TrainCar>(out var _) && !(attachedRigidbody.velocity.sqrMagnitude <= breakVelocitySqr))
		{
			Object.Destroy(triggerCollider);
			triggerCollider = null;
			isBroken = true;
			rb = base.gameObject.AddComponent<Rigidbody>();
			rb.mass = 30000f;
			TerrainGrid instance = SingletonBehaviour<TerrainGrid>.Instance;
			if ((bool)instance)
			{
				OnTerrainsMove();
				instance.TerrainsMoved += OnTerrainsMove;
			}
		}
	}

	private void OnTerrainsMove()
	{
		rb.isKinematic = !SingletonBehaviour<TerrainGrid>.Instance.IsInLoadedCell(base.transform.position);
	}

	private string ValidateTriggerCollider(Collider collider)
	{
		if (!collider.isTrigger)
		{
			return "triggerCollider must be a trigger";
		}
		if (!(collider.gameObject == base.gameObject))
		{
			return "triggerCollider must be on the same GameObject as the BufferStop";
		}
		return "";
	}
}
