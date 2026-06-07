using UnityEngine;

public class MeshColorSetter : MonoBehaviour
{
	private MeshFilter meshFilter;

	private Mesh mesh;

	private Color32[] colors;

	private Color _color;

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}
}
