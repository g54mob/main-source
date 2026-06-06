using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Flotsam Settings")]
public class FlotsamSettings : ScriptableObject
{
	[Tooltip("Reference to the point of interest properties used in the game.")]
	public PointOfInterestProperties[] PointOfInterestProperties;
}
