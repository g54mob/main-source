using UnityEngine;

public class DecorObject : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform interactionParent;

	private bool isShowingInteraction;

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
		if (!isShowingInteraction)
		{
			ShowInteract(player.transform);
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

	private void ShowInteract(Transform player)
	{
		_ = InteractionPanel.Instance == null;
	}

	private void HideInteract()
	{
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HidePanels();
		}
	}

	private void Remove(PlayerInventory player)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		if (component != null)
		{
			component.Remove(player);
		}
	}

	private void Dismantle(Transform playerTransform)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		Grabber component2 = playerTransform.GetComponent<Grabber>();
		TSPlayerController component3 = playerTransform.GetComponent<TSPlayerController>();
		if (component != null && component2 != null && component3 != null)
		{
			component.Dismantle(component2, component3);
		}
	}
}
