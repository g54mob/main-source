using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkFeatureEntry : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Image displaying the sprite for the feature icon.")]
	private Image _featureIcon;

	[SerializeField]
	[Tooltip("Text that will display the feature name.")]
	private TextMeshProUGUI _featureText;

	[SerializeField]
	[Tooltip("Reference to the entry's tooltip.")]
	private Tooltip _tooltip;

	public void Initialize(LandmarkFeatureProperties featureProperties)
	{
		_featureIcon.sprite = featureProperties.Icon;
		_featureText.text = featureProperties.Title;
		_tooltip.LocalizedText = featureProperties.TooltipText;
	}
}
