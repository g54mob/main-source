using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class WaterSourceAuthoring : MonoBehaviour
{
	public Tileset watertileset;

	public float3 splashPosition;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(base.transform.TransformPoint(splashPosition), 0.05f);
	}
}
