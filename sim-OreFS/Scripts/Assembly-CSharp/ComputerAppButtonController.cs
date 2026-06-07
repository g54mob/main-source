using I2.Loc;
using Mirror;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ComputerAppButtonController : MonoBehaviour
{
	[Header("Availability Settings")]
	[SerializeField]
	private bool isAvailableInTutorial = true;

	[SerializeField]
	private bool isAvailableInDemoAndPrologue = true;

	[Header("Tutorial SubStep Lock")]
	[Tooltip("Tutorial sırasında bu substep'e ulaşılana kadar buton kilitli. None = substep kilidi yok")]
	[SerializeField]
	private TutorialSubStepType unlockAtSubStep;

	[Header("Room Owner Lock")]
	[SerializeField]
	private bool isAvailableForOnlyOwner;

	[Header("Events")]
	[SerializeField]
	private UnityEvent onAppOpened;

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
	}

	private void Start()
	{
		if (button != null)
		{
			button.onClick.AddListener(OnButtonClicked);
		}
	}

	private void OnDestroy()
	{
		if (button != null)
		{
			button.onClick.RemoveListener(OnButtonClicked);
		}
	}

	public void OnButtonClicked()
	{
		if (!isAvailableInTutorial && TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
		{
			ShowNotification("Notification_NotAvailableDuringTutorial");
		}
		else if (unlockAtSubStep != TutorialSubStepType.None && TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && TutorialManager.Instance.CurrentSubStep < unlockAtSubStep)
		{
			ShowNotification("Notification_NotAvailableDuringTutorial");
		}
		else if (isAvailableForOnlyOwner && !NetworkServer.active)
		{
			ShowNotification("Notification_OnlyFactoryOwnerCanDoThis");
		}
		else if (!isAvailableInDemoAndPrologue && SteamAppChecker.Instance != null && (SteamAppChecker.Instance.IsDemo || SteamAppChecker.Instance.IsPrologue))
		{
			ShowNotification("NOT AVAILABLE IN DEMO");
		}
		else
		{
			onAppOpened?.Invoke();
		}
	}

	private void ShowNotification(string localizationKey)
	{
		if (NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation(localizationKey), isComputer: true);
		}
	}
}
