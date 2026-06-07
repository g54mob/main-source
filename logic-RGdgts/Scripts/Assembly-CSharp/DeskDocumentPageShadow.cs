using UnityEngine;

public class DeskDocumentPageShadow : MonoBehaviour
{
	public Material material;

	private Sprite sprite;

	private Mesh mesh;

	private MeshRenderer meshRenderer;

	private MeshFilter meshFilter;

	private Vector3[] vertices;

	private Vector2[] uvs;

	private int[] indices4;

	private int[] indices3;

	private int[] indicesVoid;

	public int sortingLayerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string sortingLayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int sortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private bool SolveLineX(Vector2 point, Vector2 dir, float y, out float x)
	{
		x = default(float);
		return false;
	}

	private bool SolveLineY(Vector2 point, Vector2 dir, float x, out float y)
	{
		y = default(float);
		return false;
	}

	private void Awake()
	{
	}

	public void Setup(Sprite sprite)
	{
	}

	private Vector3 GetOffset(Vector2 p, float distance)
	{
		return default(Vector3);
	}

	private Vector3 OffsetPoint(Vector3 p, float distance)
	{
		return default(Vector3);
	}

	public void Refresh(float angle, float flip)
	{
	}

	private void OnDestroy()
	{
	}
}
