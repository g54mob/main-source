using Unity.Entities;
using UnityEngine;

public struct WorldExplorerDebugTrackerCD : IComponentData, IQueryTypeParameter
{
	public WorldExplorerDebugMarkerType MarkerType;

	public Color Color;

	public int Radius;

	public bool ShowEntityName;

	public bool ShowWhenDisabled;

	public Color ColorWhenDisabled;
}
