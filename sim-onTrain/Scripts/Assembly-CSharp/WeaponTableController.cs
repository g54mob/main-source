using UnityEngine;
using UnityEngine.Localization;

public class WeaponTableController : MonoBehaviour, IInteractable
{
	[SerializeField]
	private bool isActive;

	private InGameUIManager inGameUIManager;

	private CraftPanelUIManager craftPanel;

	[SerializeField]
	private Transform interactionParent;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString gunCraftLocalized;

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
		craftPanel = Object.FindObjectOfType<CraftPanelUIManager>();
		isActive = true;
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (IsActive)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(gunCraftLocalized, "Gun Craft"));
			if (Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && !Singleton<MainUIManager>.Instance.isInGamePanelOpened)
			{
				Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(craftPanel);
				craftPanel.ChangePanelActive(CraftMode.GunCraft);
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
}
