using UnityEngine;

public class UIScaleHandlerWorld : MonoBehaviour
{
	private float originScale = 1f;

	private void Start()
	{
		originScale = base.transform.localScale.x;
		Refresh();
		SettingsManager.Instance.onUIScaleChange.AddListener(Refresh);
	}

	public void Refresh()
	{
		float uiReferenceResolutionFactor = SettingsManager.Instance.UiReferenceResolutionFactor;
		base.transform.localScale = Vector3.one * originScale * (1f - (uiReferenceResolutionFactor - 1f));
	}
}
