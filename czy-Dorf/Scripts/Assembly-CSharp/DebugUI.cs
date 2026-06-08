using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private TextMeshProUGUI osDisplay;

	[SerializeField]
	private TextMeshProUGUI processorDisplay;

	[SerializeField]
	private TextMeshProUGUI graphicsCardDisplay;

	[SerializeField]
	private TextMeshProUGUI ramDisplay;

	private void Start()
	{
		osDisplay.text = SystemInfo.operatingSystem ?? "";
		processorDisplay.text = $"{SystemInfo.processorType} ( {SystemInfo.processorCount} x {SystemInfo.processorFrequency} MB )";
		graphicsCardDisplay.text = $"{SystemInfo.graphicsDeviceName}, {SystemInfo.graphicsMemorySize} MB - {SystemInfo.graphicsDeviceType}";
		ramDisplay.text = $"{SystemInfo.systemMemorySize} MB RAM";
		EnableDebugUi(settingsRouter.DebugUiVisible);
		settingsRouter.OnShowDebugUi += EnableDebugUi;
	}

	private void EnableDebugUi(bool newEnabled)
	{
		base.gameObject.SetActive(newEnabled);
	}

	private void OnDestroy()
	{
		settingsRouter.OnShowDebugUi -= EnableDebugUi;
	}
}
