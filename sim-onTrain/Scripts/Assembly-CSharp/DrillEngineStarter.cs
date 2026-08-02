using UnityEngine;
using UnityEngine.Localization;

public class DrillEngineStarter : MonoBehaviour, IInteractable
{
	[SerializeField]
	private DrillController drillController;

	[Header("Interaction Settings")]
	[SerializeField]
	private Transform interactionParent;

	[SerializeField]
	private float customInteractionDistance = 2f;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString startEngineLocalized;

	[SerializeField]
	private LocalizedString stopEngineLocalized;

	public bool IsActive { get; set; } = true;

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

	public float CustomInteractionDistance => customInteractionDistance;

	private void Start()
	{
		if (drillController == null)
		{
			drillController = GetComponentInParent<DrillController>();
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (drillController == null)
		{
			Debug.LogWarning("[DrillEngineStarter] DrillController bulunamadı!");
			return;
		}
		bool flag = drillController.IsEngineRunning();
		string message = (flag ? GetLocalizedString(stopEngineLocalized, "Stop Engine") : GetLocalizedString(startEngineLocalized, "Start Engine"));
		InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, message, hasHoldAction: false, 1f, null, InteractionPanel.Instance.positiveColor);
		if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
		{
			if (flag)
			{
				drillController.StopEngineManual();
			}
			else
			{
				drillController.StartEngineManual();
			}
			InteractionPanel.Instance.HidePanels();
		}
	}

	public void StopInteract()
	{
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
}
