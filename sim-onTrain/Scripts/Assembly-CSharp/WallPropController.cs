using UnityEngine;

public class WallPropController : MonoBehaviour, IInteractable
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
	}

	private void HideInteract()
	{
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HidePanel(CanvasType.Overlay);
		}
	}
}
