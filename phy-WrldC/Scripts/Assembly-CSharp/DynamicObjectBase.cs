using UltimateReplay;
using UnityEngine;

public abstract class DynamicObjectBase : MonoBehaviour
{
	[SerializeField]
	private bool isReplayAutoConfig = true;

	[SerializeField]
	private float health = 100f;

	private float currentHealth;

	protected Rigidbody thisRigidbody;

	private bool isRigidbodyAlwaysKinematic;

	private MeshRenderer[] allMeshRenderers;

	private Collider[] allColliders;

	private Vector3 localPosition;

	private Quaternion localRotation;

	private bool isObjectDestroyed;

	public Rigidbody Rigidbody => thisRigidbody;

	public float Health
	{
		get
		{
			return currentHealth;
		}
		set
		{
			if (IsInAction)
			{
				currentHealth = Mathf.Clamp(value, 0f, float.PositiveInfinity);
				if (currentHealth <= 0f && !isObjectDestroyed)
				{
					isObjectDestroyed = true;
					OnDestroyedObject();
				}
			}
		}
	}

	public bool IsInAction { get; private set; }

	public bool RestoresPosition { get; protected set; }

	public bool IsExisting { get; private set; }

	protected virtual void Awake()
	{
		localPosition = base.transform.localPosition;
		localRotation = base.transform.localRotation;
		isObjectDestroyed = false;
		thisRigidbody = base.transform.GetComponent<Rigidbody>();
		allMeshRenderers = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		allColliders = GetComponentsInChildren<Collider>(includeInactive: true);
		if (thisRigidbody != null)
		{
			isRigidbodyAlwaysKinematic = thisRigidbody.isKinematic;
			thisRigidbody.isKinematic = true;
		}
		IsInAction = false;
		RestoresPosition = true;
		IsExisting = true;
		if (isReplayAutoConfig)
		{
			AddReplayComponentsInternal();
		}
	}

	private void AddReplayComponentsInternal()
	{
		ReplayTransform replayTransform = base.gameObject.AddComponent<ReplayTransform>();
		replayTransform.recordPosition = ReplayTransform.ReplayTransformRecordSpace.World;
		replayTransform.recordRotation = ReplayTransform.ReplayTransformRecordSpace.World;
		base.gameObject.AddComponent<DynamicObjectReplay>();
		AddReplayComponents();
		base.gameObject.AddComponent<ReplayObject>().RebuildComponentList();
	}

	protected virtual void AddReplayComponents()
	{
	}

	public virtual void SetExistence(bool isExisting)
	{
		if (isExisting == IsExisting)
		{
			return;
		}
		if (allMeshRenderers != null)
		{
			for (int i = 0; i < allMeshRenderers.Length; i++)
			{
				allMeshRenderers[i].enabled = isExisting;
			}
		}
		if (allColliders != null)
		{
			for (int j = 0; j < allColliders.Length; j++)
			{
				allColliders[j].enabled = isExisting;
			}
		}
		if (!isExisting && thisRigidbody != null)
		{
			thisRigidbody.isKinematic = true;
		}
		IsExisting = isExisting;
	}

	public virtual void Recycle()
	{
		base.gameObject.SetActive(value: true);
		SetExistence(isExisting: true);
		currentHealth = health;
		isObjectDestroyed = false;
		if (RestoresPosition)
		{
			base.transform.localPosition = localPosition;
			base.transform.localRotation = localRotation;
		}
		if (thisRigidbody != null)
		{
			thisRigidbody.velocity = Vector3.zero;
			thisRigidbody.angularVelocity = Vector3.zero;
			thisRigidbody.isKinematic = true;
		}
		IsInAction = false;
	}

	public virtual void SetupToAction()
	{
		if (thisRigidbody != null && !isRigidbodyAlwaysKinematic)
		{
			thisRigidbody.isKinematic = false;
		}
		IsInAction = true;
	}

	protected virtual void OnDestroyedObject()
	{
	}
}
