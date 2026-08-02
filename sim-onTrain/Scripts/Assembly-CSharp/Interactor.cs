using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	public float raycastDistance = 3f;

	[Header("Sphere Cast Ayarları")]
	public float sphereRadius = 0.5f;

	private Grabber grabber;

	private Transform lastCheckedInteractable;

	public IInteractable lastInteractable;

	private PlayerInventory playerInventory;

	[HideInInspector]
	public PropBase detectedPropBase;

	[Header("Raycast Camera")]
	public Camera raycastCamera;

	[Header("Layer Mask Ayarları")]
	[SerializeField]
	private LayerMask ignoreLayerForRaycast;

	[SerializeField]
	private LayerMask ignoreLayerForSphereCast;

	[SerializeField]
	private LayerMask environmentWallLayers;

	[SerializeField]
	private TSPlayerController tSPlayerController;

	public List<Transform> visibleTargets = new List<Transform>();

	private InGameUIManager inGameUIManager;

	[Header("Outline Ayarları")]
	[SerializeField]
	private float outlineDetectionRadius = 10f;

	[SerializeField]
	private float outlineUpdateInterval = 0.2f;

	private readonly HashSet<Outlinable> activeOutlinables = new HashSet<Outlinable>();

	private readonly Collider[] outlineCheckBuffer = new Collider[50];

	public TSPlayerController TSPlayerController
	{
		get
		{
			if (!(tSPlayerController == null))
			{
				return tSPlayerController;
			}
			return GetComponent<TSPlayerController>();
		}
	}

	private void Start()
	{
		inGameUIManager = Object.FindObjectOfType<InGameUIManager>();
		playerInventory = GetComponent<PlayerInventory>();
		grabber = GetComponent<Grabber>();
		StartCoroutine(OutlineDetectionRoutine());
		if (tSPlayerController != null && tSPlayerController.isLocalPlayer && raycastCamera != null && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.SetCamera(raycastCamera);
		}
	}

	private void Update()
	{
		if (tSPlayerController != null && !tSPlayerController.isLocalPlayer)
		{
			return;
		}
		if (raycastCamera != null && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.SetCamera(raycastCamera);
		}
		if (!TrainGameManager.isInputActive)
		{
			ClearInteractable();
			return;
		}
		if (grabber.selectedGrabbleObject != null)
		{
			ClearInteractable();
			return;
		}
		if (WrenchController.isWrenchActive)
		{
			ClearInteractable();
			WrenchDetection();
			return;
		}
		detectedPropBase = null;
		if (lastInteractable != null && IsInteractableDestroyed())
		{
			ClearInteractable();
		}
		else
		{
			SphereCastDetection();
		}
	}

	private bool IsInteractableDestroyed()
	{
		if (lastInteractable is MonoBehaviour monoBehaviour)
		{
			if (!(monoBehaviour == null))
			{
				return monoBehaviour.gameObject == null;
			}
			return true;
		}
		return false;
	}

	private void ClearInteractable()
	{
		if (lastInteractable != null)
		{
			if (!IsInteractableDestroyed())
			{
				try
				{
					lastInteractable.StopInteract();
				}
				catch
				{
				}
			}
			lastInteractable = null;
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
		}
		if (inGameUIManager != null)
		{
			inGameUIManager.CloseUserInteractPanel();
		}
	}

	private void SphereCastDetection()
	{
		if (tSPlayerController.isDeath)
		{
			return;
		}
		if (InteractionPanel.Instance != null && InteractionPanel.Instance.IsAnyHoldActive)
		{
			if (lastInteractable == null || IsInteractableDestroyed())
			{
				ClearInteractable();
			}
			else
			{
				if (!(lastInteractable is MonoBehaviour monoBehaviour) || !(monoBehaviour != null))
				{
					return;
				}
				Vector3 vector = monoBehaviour.transform.position;
				Collider component = monoBehaviour.GetComponent<Collider>();
				if (component != null)
				{
					vector = component.bounds.center;
				}
				float num = ((lastInteractable.CustomInteractionDistance >= 0f) ? lastInteractable.CustomInteractionDistance : raycastDistance);
				if (Vector3.Distance(raycastCamera.transform.position, vector) > num + 1f)
				{
					ClearInteractable();
					return;
				}
				Vector3 normalized = (vector - raycastCamera.transform.position).normalized;
				if (Vector3.Angle(raycastCamera.transform.forward, normalized) > 70f)
				{
					ClearInteractable();
				}
			}
			return;
		}
		if (Singleton<MainUIManager>.Instance != null && Singleton<MainUIManager>.Instance.isInGamePanelOpened)
		{
			ClearInteractable();
			return;
		}
		Ray ray = raycastCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		Vector3 origin = ray.origin;
		Vector3 direction = ray.direction;
		IInteractable interactable = null;
		Vector3 hitPoint = Vector3.zero;
		if (Physics.Raycast(ray, out var hitInfo, raycastDistance, ~(int)ignoreLayerForRaycast))
		{
			IInteractable component2 = hitInfo.collider.GetComponent<IInteractable>();
			if (((1 << hitInfo.collider.gameObject.layer) & (int)environmentWallLayers) != 0 && component2 == null)
			{
				ClearInteractable();
				return;
			}
			if (component2 != null)
			{
				float num2 = ((component2.CustomInteractionDistance >= 0f) ? component2.CustomInteractionDistance : raycastDistance);
				if (hitInfo.distance > num2)
				{
					if (lastInteractable == component2 && !IsInteractableDestroyed())
					{
						try
						{
							lastInteractable.StopInteract();
						}
						catch
						{
						}
						lastInteractable = null;
					}
					return;
				}
				if (lastInteractable != null && lastInteractable != component2 && !IsInteractableDestroyed())
				{
					try
					{
						lastInteractable.StopInteract();
					}
					catch
					{
					}
				}
				lastInteractable = component2;
				component2.Interact(playerInventory, hitInfo.point);
				return;
			}
		}
		RaycastHit[] array = Physics.SphereCastAll(origin, sphereRadius, direction, raycastDistance, ~(int)ignoreLayerForSphereCast);
		float num3 = float.MaxValue;
		float num4 = float.MaxValue;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (((1 << raycastHit.collider.gameObject.layer) & (int)environmentWallLayers) != 0 && raycastHit.collider.GetComponent<IInteractable>() == null && raycastHit.distance < num4)
			{
				num4 = raycastHit.distance;
			}
		}
		array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit2 = array2[i];
			if (raycastHit2.distance > num4)
			{
				continue;
			}
			IInteractable component3 = raycastHit2.collider.GetComponent<IInteractable>();
			StoryBoardController component4 = raycastHit2.collider.GetComponent<StoryBoardController>();
			if (component3 != null && component4 == null && component3.UseSphereCast)
			{
				float num5 = ((component3.CustomInteractionDistance >= 0f) ? component3.CustomInteractionDistance : raycastDistance);
				if (raycastHit2.distance <= num5 && raycastHit2.distance < num3)
				{
					interactable = component3;
					num3 = raycastHit2.distance;
					hitPoint = raycastHit2.point;
				}
			}
		}
		if (lastInteractable != null && lastInteractable != interactable && !IsInteractableDestroyed())
		{
			try
			{
				lastInteractable.StopInteract();
			}
			catch
			{
			}
		}
		if (interactable != null)
		{
			lastInteractable = interactable;
			interactable.Interact(playerInventory, hitPoint);
		}
		else
		{
			ClearInteractable();
		}
	}

	private void WrenchDetection()
	{
		RaycastHit hitInfo;
		if (tSPlayerController.isDeath)
		{
			detectedPropBase = null;
		}
		else if (Singleton<MainUIManager>.Instance != null && Singleton<MainUIManager>.Instance.isInGamePanelOpened)
		{
			detectedPropBase = null;
		}
		else if (Physics.Raycast(raycastCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), layerMask: ~((int)ignoreLayerForRaycast | (1 << LayerMask.NameToLayer("BuildingSnapCollider"))), hitInfo: out hitInfo, maxDistance: raycastDistance))
		{
			PropBase componentInParent = hitInfo.collider.GetComponentInParent<PropBase>();
			if (componentInParent != null && componentInParent.GetComponent<GrabbableObject>() != null)
			{
				detectedPropBase = componentInParent;
			}
			else
			{
				detectedPropBase = null;
			}
		}
		else
		{
			detectedPropBase = null;
		}
	}

	private IEnumerator OutlineDetectionRoutine()
	{
		WaitForSeconds wait = new WaitForSeconds(outlineUpdateInterval);
		while (true)
		{
			yield return wait;
			if (!(tSPlayerController == null) && tSPlayerController.isLocalPlayer && !tSPlayerController.isDeath)
			{
				UpdateOutlineVisibility();
			}
		}
	}

	private void UpdateOutlineVisibility()
	{
		int num = Physics.OverlapSphereNonAlloc(base.transform.position, outlineDetectionRadius, outlineCheckBuffer);
		HashSet<Outlinable> hashSet = new HashSet<Outlinable>();
		for (int i = 0; i < num; i++)
		{
			Collider collider = outlineCheckBuffer[i];
			Outlinable component = collider.GetComponent<Outlinable>();
			if (component != null && !IsBlockedByWall(collider))
			{
				hashSet.Add(component);
				if (!activeOutlinables.Contains(component))
				{
					component.enabled = true;
				}
			}
		}
		foreach (Outlinable activeOutlinable in activeOutlinables)
		{
			if (activeOutlinable != null && !hashSet.Contains(activeOutlinable))
			{
				activeOutlinable.enabled = false;
			}
		}
		activeOutlinables.Clear();
		foreach (Outlinable item in hashSet)
		{
			activeOutlinables.Add(item);
		}
	}

	private bool IsBlockedByWall(Collider targetCollider)
	{
		Vector3 vector = ((raycastCamera != null) ? raycastCamera.transform.position : (base.transform.position + Vector3.up));
		Vector3 vector2 = targetCollider.bounds.center - vector;
		float magnitude = vector2.magnitude;
		if (magnitude < 0.01f)
		{
			return false;
		}
		if (Physics.Raycast(vector, vector2 / magnitude, out var hitInfo, magnitude, environmentWallLayers) && hitInfo.collider != targetCollider)
		{
			return true;
		}
		return false;
	}

	public void SetLastInteractable(IInteractable interactable)
	{
		lastInteractable = interactable;
	}

	private void OnDisable()
	{
		foreach (Outlinable activeOutlinable in activeOutlinables)
		{
			if (activeOutlinable != null)
			{
				activeOutlinable.enabled = false;
			}
		}
		activeOutlinables.Clear();
	}
}
