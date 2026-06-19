using NaughtyAttributes;
using UnityEngine;

public class WorldExplorerDebugTrackerAuthoring : MonoBehaviour
{
	public WorldExplorerDebugMarkerType markerType = WorldExplorerDebugMarkerType.Circle;

	public Color color = Color.red;

	public int radius = 2;

	public bool showEntityName;

	public bool showWhenDisabled;

	[ShowIf("showWhenDisabled")]
	[AllowNesting]
	public Color colorWhenDisabled = Color.gray;
}
