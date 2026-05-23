using UnityEngine;
using UnityEngine.UI;

public class UIScaleHandler : MonoBehaviour
{
	private CanvasScaler scaler;

	private void Start()
	{
		scaler = GetComponent<CanvasScaler>();
		Refresh();
		SettingsManager.Instance.onUIScaleChange.AddListener(Refresh);
	}

	public void Refresh()
	{
		float uiReferenceResolutionFactor = SettingsManager.Instance.UiReferenceResolutionFactor;
		scaler.referenceResolution = new Vector2(1920f * uiReferenceResolutionFactor, 1080f * uiReferenceResolutionFactor);
	}
}
