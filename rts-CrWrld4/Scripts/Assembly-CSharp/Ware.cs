using UnityEngine;

public class Ware : MonoBehaviour
{
	public const int atlas_cols = 28;

	public const int atlas_pad = 8;

	public const int atlas_isize = 128;

	public const int atlas_width = 1024;

	public const int atlas_height = 1024;

	public float size;

	public int wareType;

	public int creationTime;

	private Mesh lmesh;

	private bool destroyed;

	private UnitManager holder;

	private UnitManager pendingHolder;

	public int padPos;

	private void Awake()
	{
	}

	public void SetHolder(UnitManager um)
	{
	}

	public UnitManager GetHolder()
	{
		return null;
	}

	public void RemoveHolder()
	{
	}

	public void SetPendingHolder(UnitManager um)
	{
	}

	public UnitManager GetPendingHolder()
	{
		return null;
	}

	public void RemovePendingHolder()
	{
	}

	public void SetTexture(int num)
	{
	}

	public void SetFace(Vector3[] vertices, Vector3[] n, int[] t, int face, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
	}

	public static Vector2 GetUVUnscaled(int t)
	{
		return default(Vector2);
	}

	public void DestroyWare()
	{
	}
}
