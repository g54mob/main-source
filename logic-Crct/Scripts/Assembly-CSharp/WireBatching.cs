using UnityEngine;

public class WireBatching : MonoBehaviour
{
	private int children;

	private static WireBatching inst;

	public Mesh fillMesh;

	public MeshRenderer rend;

	private Material[] ogMats;

	private Vector3[] fillVerts;

	private int[] fillTris;

	private static Mesh combinedMesh;

	private void Awake()
	{
	}

	public static void Hide()
	{
	}

	public static void SetAnalysisMaterials()
	{
	}

	public static void Show()
	{
	}

	private void FillMesh()
	{
	}

	private void Update()
	{
	}

	public static void UnBatch()
	{
	}

	public static void Batch()
	{
	}
}
