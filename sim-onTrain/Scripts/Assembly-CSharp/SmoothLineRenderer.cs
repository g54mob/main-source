using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SmoothLineRenderer : MonoBehaviour
{
	public float lineSegmentSize = 0.15f;

	public float lineWidth = 0.1f;

	[Header("Gizmos")]
	public bool showGizmos = true;

	public float gizmoSize = 0.1f;

	public Color gizmoColor = new Color(1f, 0f, 0f, 0.5f);

	private CurvedLinePointer[] linePoints = new CurvedLinePointer[0];

	private Vector3[] linePositions = new Vector3[0];

	private Vector3[] linePositionsOld = new Vector3[0];

	public void Update()
	{
		GetPoints();
		SetPointsToLine();
	}

	private void GetPoints()
	{
		linePoints = GetComponentsInChildren<CurvedLinePointer>();
		linePositions = new Vector3[linePoints.Length];
		for (int i = 0; i < linePoints.Length; i++)
		{
			linePositions[i] = linePoints[i].transform.position;
		}
	}

	private void SetPointsToLine()
	{
		if (linePositionsOld.Length != linePositions.Length)
		{
			linePositionsOld = new Vector3[linePositions.Length];
		}
		bool flag = false;
		for (int i = 0; i < linePositions.Length; i++)
		{
			if (linePositions[i] != linePositionsOld[i])
			{
				flag = true;
			}
		}
		if (flag)
		{
			LineRenderer component = GetComponent<LineRenderer>();
			Vector3[] array = CurvedLineSmoother.SmoothLine(linePositions, lineSegmentSize);
			component.SetVertexCount(array.Length);
			component.SetPositions(array);
			component.SetWidth(lineWidth, lineWidth);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Update();
	}

	private void OnDrawGizmos()
	{
		if (linePoints.Length == 0)
		{
			GetPoints();
		}
		CurvedLinePointer[] array = linePoints;
		foreach (CurvedLinePointer obj in array)
		{
			obj.showGizmo = showGizmos;
			obj.gizmoSize = gizmoSize;
			obj.gizmoColor = gizmoColor;
		}
	}
}
