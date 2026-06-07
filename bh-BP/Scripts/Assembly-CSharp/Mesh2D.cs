using UnityEngine;

[ExecuteInEditMode]
public class Mesh2D : MonoBehaviour
{
	public PolygonTriangulator2D.Triangulation triangulation;

	public Material material;

	public Vector2 materialScale;

	public Vector2 materialOffset;

	public string sortingLayerName;

	public int sortingOrder;

	private MeshFilter meshFilter;

	private MeshRenderer meshRenderer;

	public void Initialize()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OnDestroy()
	{
	}
}
