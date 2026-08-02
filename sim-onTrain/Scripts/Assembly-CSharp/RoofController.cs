using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform interactionParent;

	private bool isShowingInteraction;

	private bool lastDoorState;

	private IDoor door;

	[SerializeField]
	private BoxCollider coll;

	private static readonly Collider[] overlapBuffer = new Collider[64];

	public bool IsActive { get; set; }

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	private void Start()
	{
		if (coll == null)
		{
			coll = GetComponent<BoxCollider>();
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (!isShowingInteraction && ShowInteract(player.transform))
		{
			isShowingInteraction = true;
		}
	}

	public void StopInteract()
	{
		HideInteract();
		isShowingInteraction = false;
	}

	private void OnDestroy()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void OnDisable()
	{
		if (isShowingInteraction)
		{
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
			isShowingInteraction = false;
		}
	}

	private bool ShowInteract(Transform player)
	{
		if (InteractionPanel.Instance == null)
		{
			return false;
		}
		IDoor door = GetComponent<IDoor>();
		if (door != null)
		{
			List<InteractionData> list = new List<InteractionData>();
			KeyCode interactKey = Singleton<UserPrefencesManager>.Instance.keyData.InteractKey;
			string message = (door.IsOpened ? "Close Door" : "Open Door");
			list.Add(new InteractionData(interactKey, message, hasHoldAction: false, 0f, delegate
			{
				door.Interact();
				lastDoorState = door.IsOpened;
				ShowInteract(player);
			}));
			InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(interactionParent, player, list);
			return true;
		}
		return false;
	}

	private void HideInteract()
	{
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HidePanels();
		}
	}

	public void Remove(PlayerInventory player)
	{
		player.StartCoroutine(RemoveWithAboveObjects(player));
	}

	private IEnumerator RemoveWithAboveObjects(PlayerInventory player)
	{
		GrabbableObject componentInParent = GetComponentInParent<GrabbableObject>();
		List<GrabbableObject> list = new List<GrabbableObject>();
		if (coll != null)
		{
			Vector3 center = base.transform.position + coll.center;
			Vector3 halfExtents = coll.size * 0.5f;
			int num = Physics.OverlapBoxNonAlloc(center, halfExtents, overlapBuffer, base.transform.rotation);
			for (int i = 0; i < num; i++)
			{
				if (overlapBuffer[i].TryGetComponent<ObjectCenter>(out var component) && !(component.grabbableObject == componentInParent) && component.IsRemoveValid(coll) && component.grabbableObject != null && !list.Contains(component.grabbableObject))
				{
					list.Add(component.grabbableObject);
				}
			}
		}
		if (componentInParent != null)
		{
			componentInParent.Remove(player);
		}
		foreach (GrabbableObject item in list)
		{
			if (item != null && item.gameObject != null)
			{
				WallController componentInChildren = item.GetComponentInChildren<WallController>();
				RoofController componentInChildren2 = item.GetComponentInChildren<RoofController>();
				GroundController componentInChildren3 = item.GetComponentInChildren<GroundController>();
				if (componentInChildren != null)
				{
					player.StartCoroutine(TriggerWallRemoval(componentInChildren, player));
				}
				else if (componentInChildren2 != null)
				{
					player.StartCoroutine(TriggerRoofRemoval(componentInChildren2, player));
				}
				else if (componentInChildren3 != null)
				{
					player.StartCoroutine(TriggerGroundRemoval(componentInChildren3, player));
				}
				else
				{
					item.Remove(player);
				}
			}
		}
		yield break;
	}

	private static IEnumerator TriggerWallRemoval(WallController wall, PlayerInventory player)
	{
		yield return new WaitForSeconds(0.15f);
		if (wall != null)
		{
			wall.Remove(player);
		}
	}

	private static IEnumerator TriggerRoofRemoval(RoofController roof, PlayerInventory player)
	{
		yield return new WaitForSeconds(0.15f);
		if (roof != null)
		{
			roof.Remove(player);
		}
	}

	private static IEnumerator TriggerGroundRemoval(GroundController ground, PlayerInventory player)
	{
		yield return new WaitForSeconds(0.15f);
		if (ground != null)
		{
			ground.Remove(player);
		}
	}
}
