using UnityEngine;

public class AlwaysUi : MonoBehaviour
{
	public UiTextPopup UiTextPopup;

	public SelectionArrow selectionArrow;

	public GameObject resolutionWindow;

	public GameObject languageWindow;

	public DynamicWindows dynamicWindows;

	public ConfigWarning configWarning;

	public TooltipNew tooltipNew;

	public static AlwaysUi Instance;

	private void Awake()
	{
		if (!(Instance != null))
		{
			Instance = this;
			return;
		}
		GameObject obj = base.gameObject;
		Object.Destroy(obj);
	}

	public void OpenLanguageWindow()
	{
		languageWindow.SetActive(value: true);
	}

	private void OnGUI()
	{
	}

	private void OnApplicationFocus(bool hasFocus)
	{
	}

	private void OnApplicationPause()
	{
	}
}
