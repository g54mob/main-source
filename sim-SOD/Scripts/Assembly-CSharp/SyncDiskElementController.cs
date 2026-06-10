using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SyncDiskElementController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	[Space(7f)]
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI numberText;

	public TextMeshProUGUI descriptionText;

	[Space(7f)]
	public ButtonController option1Button;

	public ButtonController option2Button;

	public ButtonController option3Button;

	public ButtonController upgradeButton;

	public ButtonController sideEffectButton;

	public ButtonController uninstallButton;

	public Image option1Icon;

	public Image option2Icon;

	public Image option3Icon;

	[Space(7f)]
	public ButtonController upgradePip1;

	public ButtonController upgradePip2;

	public ButtonController upgradePip3;

	[Space(7f)]
	public Image manufacturerLogo;

	[Header("Settings")]
	public Sprite upgradeEmptySprite;

	public Sprite upgradeEnabledSprite;

	[Header("State")]
	public UpgradesController.Upgrades upgrade;

	public SyncDiskPreset preset;

	public int selectedOption;

	public bool installAllowed;

	public void Setup(UpgradesController.Upgrades newUpgrade)
	{
	}

	public void SetInstallAllowed(bool val)
	{
	}

	public void VisualUpdate()
	{
	}

	public void SelectOptionButton(int val)
	{
	}

	public void InstallButton()
	{
	}

	public void PopupCancel()
	{
	}

	public void InstallPromptSuccess()
	{
	}

	public void UninstallPromptSuccess()
	{
	}

	public void UpgradeButton()
	{
	}

	public void UpgradePromptSuccess()
	{
	}
}
