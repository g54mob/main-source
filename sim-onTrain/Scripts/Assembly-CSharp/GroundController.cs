using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform interactionParent;

	private bool isShowingInteraction;

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
		return false;
	}

	private void HideInteract()
	{
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	public void Remove(PlayerInventory player)
	{
		player.StartCoroutine(RemoveWithConnectedObjects(player));
	}

	private IEnumerator RemoveWithConnectedObjects(PlayerInventory player)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		List<GrabbableObject> list = new List<GrabbableObject>();
		if (coll != null)
		{
			Vector3 center = base.transform.position + coll.center;
			Vector3 halfExtents = coll.size * 0.5f;
			int num = Physics.OverlapBoxNonAlloc(center, halfExtents, overlapBuffer, base.transform.rotation);
			for (int i = 0; i < num; i++)
			{
				if (overlapBuffer[i].TryGetComponent<ObjectCenter>(out var component2) && !(component2.grabbableObject == component) && component2.IsRemoveValid(coll) && component2.grabbableObject != null && !list.Contains(component2.grabbableObject))
				{
					list.Add(component2.grabbableObject);
				}
			}
		}
		if (component != null)
		{
			component.Remove(player);
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
