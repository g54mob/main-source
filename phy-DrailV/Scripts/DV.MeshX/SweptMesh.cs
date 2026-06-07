using System.Linq;
using DV.PointSet;
using MeshXtensions;
using UnityEngine;

public class SweptMesh : MonoBehaviour
{
	private EquiPointSet pointSet;

	public int interpolation = 10;

	public BezierCurve pathCurve;

	public BezierCurve shapeCurve;

	public Shape shape;

	public Material material;

	public GameObject endPrefab;

	public UVType pathUVType;

	public float pathUVScale = 1f;

	public UVType shapeUVType;

	public float shapeUVScale = 1f;

	[ContextMenu("Generate")]
	public void Generate()
	{
		if (!pathCurve)
		{
			Debug.LogError("No path curve assigned");
			return;
		}
		Vector2[] shapePoints = null;
		if ((bool)shape)
		{
			shapePoints = shape.GetPoints2D();
		}
		else if ((bool)shapeCurve)
		{
			shapePoints = EquiPointSet.FromBezierEquidistant(shapeCurve, shapeCurve.resolution).points.Select((EquiPointSet.Point p) => new Vector2((float)p.position.x, (float)p.position.y)).ToArray();
		}
		else
		{
			Debug.LogError("Neither shape nor shapeCurve is assigned");
		}
		pointSet = EquiPointSet.FromBezierEquidistant(pathCurve, pathCurve.resolution);
		if (pointSet == null)
		{
			Debug.Log("PointSet is null");
			return;
		}
		if (pointSet.points == null || pointSet.points.Length == 0)
		{
			Debug.Log("PointSet invalid");
			return;
		}
		Vector3[] array = pointSet.points.Select((EquiPointSet.Point p) => (Vector3)p.position).ToArray();
		Vector3[] array2 = new Vector3[array.Length];
		for (int num = 0; num < pointSet.points.Length; num++)
		{
			array2[num] = Vector3.up;
		}
		Mesh mesh = MeshX.Sweep(shapePoints, array, pathUVScale, pathUVType, shapeUVType, shapeUVScale);
		mesh.RecalculateTangents();
		base.gameObject.InitializeMesh(mesh, material);
		if ((bool)endPrefab)
		{
			PlaceAtPoint(endPrefab, "START", pointSet.points[0]);
			PlaceAtPoint(endPrefab, "END", pointSet.points[pointSet.points.Length - 1]);
		}
	}

	private void PlaceAtPoint(GameObject prefab, string name, EquiPointSet.Point point)
	{
		GameObject gameObject = null;
		Transform transform = base.transform.Find(name);
		if ((bool)transform)
		{
			gameObject = transform.gameObject;
		}
		if (!gameObject)
		{
			gameObject = Object.Instantiate(endPrefab);
			gameObject.transform.parent = base.transform;
			gameObject.name = name;
		}
		gameObject.transform.position = (Vector3)point.position;
		gameObject.transform.rotation = Quaternion.LookRotation(point.forward);
	}

	private void Place(GameObject prefab, string name, Transform atT)
	{
		GameObject gameObject = null;
		Transform transform = base.transform.Find(name);
		if ((bool)transform)
		{
			gameObject = transform.gameObject;
		}
		if (!gameObject)
		{
			gameObject = Object.Instantiate(endPrefab);
			gameObject.transform.parent = base.transform;
			gameObject.name = name;
		}
		gameObject.transform.position = atT.position;
		gameObject.transform.rotation = atT.rotation;
	}
}
