using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class AdjustLayoutGroupSpacingBasedOnUIScale : MonoBehaviour
{
	public float minSpacing;

	public float maxSpacing;

	[Range(50f, 150f)]
	public float minScale = 100f;

	[Range(50f, 150f)]
	public float maxScale = 100f;

	private void OnEnable()
	{
		VerticalLayoutGroup component = GetComponent<VerticalLayoutGroup>();
		float value = Mathf.Lerp(50f, 150f, Mathf.InverseLerp(1.2f, 0.8f, SettingsManager.Instance.UiReferenceResolutionFactor));
		float spacing = Mathf.Lerp(minSpacing, maxSpacing, Mathf.InverseLerp(minScale, maxScale, value));
		component.spacing = spacing;
	}
}
