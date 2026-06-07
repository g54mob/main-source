using System;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class ShovelCoalChunks : CabItemRigidbody
{
	public float VELOCITY_UNLOAD_THRESHOLD = 35f;

	public float UNLOAD_VELOCITY_MODIFIER = 0.05f;

	private const float PREMATURE_UNLOAD_SAFETY = 0.75f;

	[SerializeField]
	private bool velocityChangeForUnload;

	[SerializeField]
	private DV_GameObjectPools.GameObjectCategory itemPoolCategory;

	[SerializeField]
	private VRTK_InteractableObject_DV shovelInteractable;

	private Rigidbody shovelRb;

	private LimitNumberOfInstances instanceLimiter;

	private Vector3d previousPosition = Vector3d.zero;

	private Vector3d previousVelocity = Vector3d.zero;

	private bool initialized;

	private bool onShovel;

	private bool coalDetached;

	private bool filtersInitialized;

	private Transform playArea;

	private Vector3 localSpawnPosition = new Vector3(0.015f, 0.03f, 0.38f);

	private Quaternion localSpawnRotation = Quaternion.Euler(new Vector3(-15f, 0f, 0f));

	private float startTime;

	private float releaseTime;

	[InspectorButton("ChangeUnloadMethodGlobal", true, true)]
	public bool changeUnloadMethodGlobal;

	[InspectorButton("ChangeThresholdsGlobal", true, true)]
	public bool changeThresholdsGlobal;

	public event Action ChunksUnloaded;

	public void OnSpawned(Rigidbody shovelRb, VRTK_InteractableObject_DV shovelInteractable, LimitNumberOfInstances instanceLimiter)
	{
		base.gameObject.layer = LayerMask.NameToLayer("Inventory");
		this.shovelRb = shovelRb;
		this.shovelInteractable = shovelInteractable;
		this.instanceLimiter = instanceLimiter;
		onShovel = true;
		coalDetached = false;
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		rb.isKinematic = true;
		if (playArea == null)
		{
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
		}
		previousPosition = Vector3ToVector3d(playArea.InverseTransformPoint(base.transform.position));
		previousVelocity = Vector3d.zero;
		startTime = Time.timeSinceLevelLoad;
		SetupGrabListeners(on: true);
		initialized = true;
	}

	private Vector3d Vector3ToVector3d(Vector3 v)
	{
		return new Vector3d(v.x, v.y, v.z);
	}

	private Vector3 Vector3dToVector3(Vector3d v)
	{
		return new Vector3((float)v.x, (float)v.y, (float)v.z);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!UnloadWatcher.isUnloading)
		{
			SetupGrabListeners(on: false);
		}
	}

	private void SetupGrabListeners(bool on)
	{
		if (!(shovelInteractable == null))
		{
			if (on)
			{
				shovelInteractable.InteractableObjectGrabbed += OnShovelGrabbed;
			}
			else
			{
				shovelInteractable.InteractableObjectGrabbed -= OnShovelGrabbed;
			}
		}
	}

	private void OnShovelGrabbed(object sender, InteractableObjectEventArgs e)
	{
		if (!(shovelInteractable.GetSecondaryGrabbingObject() != null))
		{
			previousPosition = Vector3ToVector3d(playArea.InverseTransformPoint(base.transform.position));
		}
	}

	private void Update()
	{
		if (onShovel && initialized)
		{
			Vector3 up = shovelRb.transform.up;
			Vector3d vector3d = Vector3ToVector3d(playArea.InverseTransformPoint(base.transform.position));
			Vector3d vector3d2 = (vector3d - previousPosition) / Time.deltaTime;
			Vector3d vector3d3 = vector3d2 - previousVelocity;
			Vector3 vector = playArea.TransformVector(Vector3dToVector3(velocityChangeForUnload ? vector3d3 : vector3d2));
			previousPosition = vector3d;
			previousVelocity = vector3d2;
			float num;
			if (vector.sqrMagnitude < 0.01f)
			{
				vector = Vector3.zero;
				num = 0f;
			}
			else
			{
				num = Vector3.Dot(up, vector.normalized);
			}
			if (Time.timeSinceLevelLoad - startTime > 0.75f && num < 0f && vector.sqrMagnitude > VELOCITY_UNLOAD_THRESHOLD)
			{
				UnloadCoal(-vector * UNLOAD_VELOCITY_MODIFIER);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!onShovel && !coalDetached && (!(collision.rigidbody == shovelRb) || !(Time.timeSinceLevelLoad - releaseTime < 0.2f)))
		{
			DetachCoalObjects();
		}
	}

	private void DetachCoalObjects()
	{
		coalDetached = true;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			GameObject gameObject = SingletonBehaviour<DV_GameObjectPools>.Instance.RequestObjectFromPool(DV_GameObjectPools.GameObjectCategory.Coal);
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			Transform child = base.transform.GetChild(i);
			gameObject.transform.position = child.position;
			gameObject.transform.rotation = child.rotation;
			component.velocity = rb.velocity;
			component.angularVelocity = rb.angularVelocity;
			TrainCar trainCar = TrainCar.Resolve(base.transform.root);
			if ((bool)trainCar)
			{
				Rigidbody component2 = trainCar.GetComponent<Rigidbody>();
				component.AddForce(component2.velocity, ForceMode.VelocityChange);
				gameObject.transform.SetParent(trainCar.interior, worldPositionStays: true);
				gameObject.GetComponent<CabItemRigidbody>().SetupTrainReceivingForces(component2);
			}
			gameObject.SetActive(value: true);
			instanceLimiter.Add(gameObject);
		}
		SetupGrabListeners(on: false);
		base.gameObject.layer = LayerMask.NameToLayer("Inventory");
		shovelRb = null;
		shovelInteractable = null;
		instanceLimiter = null;
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		rb.isKinematic = true;
		initialized = false;
		DV_GameObjectDestructionHandler.RemoveGameObject(base.gameObject);
	}

	protected override bool ShouldAddRespawnOnDrop()
	{
		return false;
	}

	public void UnloadCoal(Vector3 unloadVelocity)
	{
		base.gameObject.layer = LayerMask.NameToLayer("World_Item");
		base.transform.SetParent(playArea.root);
		rb.isKinematic = false;
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
		onShovel = false;
		previousVelocity = Vector3d.zero;
		rb.AddForce(unloadVelocity, ForceMode.VelocityChange);
		releaseTime = Time.timeSinceLevelLoad;
		this.ChunksUnloaded?.Invoke();
	}

	private void ChangeUnloadMethodGlobal()
	{
		foreach (GameObject item in SingletonBehaviour<DV_GameObjectPools>.Instance.GetEntirePool(DV_GameObjectPools.GameObjectCategory.CoalChunksLarge))
		{
			ShovelCoalChunks component = item.GetComponent<ShovelCoalChunks>();
			if (component != null)
			{
				component.velocityChangeForUnload = !component.velocityChangeForUnload;
			}
		}
		foreach (GameObject item2 in SingletonBehaviour<DV_GameObjectPools>.Instance.GetEntirePool(DV_GameObjectPools.GameObjectCategory.CoalChunksSmall))
		{
			ShovelCoalChunks component2 = item2.GetComponent<ShovelCoalChunks>();
			if (component2 != null)
			{
				component2.velocityChangeForUnload = !component2.velocityChangeForUnload;
			}
		}
	}

	private void ChangeThresholdsGlobal()
	{
		foreach (GameObject item in SingletonBehaviour<DV_GameObjectPools>.Instance.GetEntirePool(DV_GameObjectPools.GameObjectCategory.CoalChunksLarge))
		{
			ShovelCoalChunks component = item.GetComponent<ShovelCoalChunks>();
			if (component != null)
			{
				component.UNLOAD_VELOCITY_MODIFIER = UNLOAD_VELOCITY_MODIFIER;
				component.VELOCITY_UNLOAD_THRESHOLD = VELOCITY_UNLOAD_THRESHOLD;
			}
		}
		foreach (GameObject item2 in SingletonBehaviour<DV_GameObjectPools>.Instance.GetEntirePool(DV_GameObjectPools.GameObjectCategory.CoalChunksSmall))
		{
			ShovelCoalChunks component2 = item2.GetComponent<ShovelCoalChunks>();
			if (component2 != null)
			{
				component2.UNLOAD_VELOCITY_MODIFIER = UNLOAD_VELOCITY_MODIFIER;
				component2.VELOCITY_UNLOAD_THRESHOLD = VELOCITY_UNLOAD_THRESHOLD;
			}
		}
	}
}
