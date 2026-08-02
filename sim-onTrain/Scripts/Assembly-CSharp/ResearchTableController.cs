using UnityEngine;
using UnityEngine.Localization;

public class ResearchTableController : MonoBehaviour, IInteractable
{
	[SerializeField]
	private bool isActive;

	private InGameUIManager inGameUIManager;

	private ResearchUIManager researchUIManager;

	[SerializeField]
	private Transform interactionParent;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString researchLocalized;

	private bool isShowingInteraction;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

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

	private void Awake()
	{
		researchUIManager = Object.FindObjectOfType<ResearchUIManager>();
		isActive = true;
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (IsActive)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(researchLocalized, "Research"));
			if (Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && !Singleton<MainUIManager>.Instance.isInGamePanelOpened)
			{
				Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(researchUIManager);
				researchUIManager.ShowPanel();
			}
			if (!isShowingInteraction)
			{
				ShowRemoveInteraction(player.transform);
				isShowingInteraction = true;
			}
		}
	}

	public void StopInteract()
	{
		isShowingInteraction = false;
		InteractionPanel.Instance.HidePanels();
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
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

	private void ShowRemoveInteraction(Transform player)
	{
		_ = InteractionPanel.Instance == null;
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
