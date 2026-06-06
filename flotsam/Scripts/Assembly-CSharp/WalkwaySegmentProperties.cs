using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Walkway Segment Properties")]
public class WalkwaySegmentProperties : BuildableProperties
{
	[Header("Walkway")]
	public float WalkwayLength;

	public BuildableProperties walkwayPontonProperties;
}
