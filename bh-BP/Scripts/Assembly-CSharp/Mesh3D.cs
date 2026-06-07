using UnityEngine;

public class Mesh3D : MonoBehaviour
{
	public float size;

	public PolygonTriangulator2D.Triangulation triangulation;

	public Material material;

	public string sortingLayerName;

	public int sortingLayerID;

	public int sortingOrder;

	private float zSize;

	private void Start()
	{
	}
}
