using UnityEngine;

[ExecuteInEditMode]
public class PhaserTilemapBoundingBoxes : MonoBehaviour
{
	public static readonly string GuideUrl;

	[SerializeField]
	public PhaserTilemapBoundingBoxesAsset _asset;

	[SerializeField]
	public PhaserTilemap tilemap;

	[SerializeField]
	protected float gizmosAlpha;

	[SerializeField]
	protected int gizmosSeed;

	[ContextMenu("Clear (Rebuild)")]
	public void Clear()
	{
	}

	[ContextMenu("Clear (Single Bound)")]
	public void MakeSingle()
	{
	}
}
