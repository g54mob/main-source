using UnityEngine;

public class GalaxyNavGrid : MonoBehaviour
{
	public GameObject galaxyNavGridLinePrefab;

	public Color lineColor;

	public Color sectionLineColor;

	public bool showSectionColors;

	private float TAU;

	private int circleCount;

	private int circlePointCount;

	private LineRenderer[] circleLineRenderers;

	private float circleDist;

	private int maxLines;

	private LineRenderer[] lineRenderers;

	private Mesh mesh;

	private MeshFilter meshFilter;

	private int SECTION_COUNT;

	private Color startColor;

	private Color endColor;

	private float sectionYOffset;

	public void Awake()
	{
	}

	private void CreateLine(int index)
	{
	}

	private void CreateCircle(int index, float range)
	{
	}

	public void RefreshCircle(int index, float range)
	{
	}

	private void UpdateMesh()
	{
	}

	private void OnDestroy()
	{
	}
}
