using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Feature")]
public class LandmarkFeatureProperties : ScriptableObject
{
	[Tooltip("The feature enum of the landmark feature.")]
	public LandmarkFeature Feature;

	[Tooltip("Title of the landmark feature.")]
	public LocalizedString Title;

	[Tooltip("Text for the features tooltip.")]
	public LocalizedString TooltipText;

	[Tooltip("Sprite for the feature icon.")]
	public Sprite Icon;
}
