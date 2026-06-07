using UnityEngine;

public class DeckArrow : MonoBehaviour
{
	public Material material;

	[Space]
	public int numPointsPerLink = 5;

	public float fadeDist = 40f;

	[Space]
	public Mesh mesh;

	public string srcId;

	public string dstId;

	private void OnEnable()
	{
		CanvasRenderer component = GetComponent<CanvasRenderer>();
		component.SetMaterial(material, null);
		component.SetMesh(mesh);
	}

	private void OnDisable()
	{
		CanvasRenderer component = GetComponent<CanvasRenderer>();
		component.Clear();
	}
}
