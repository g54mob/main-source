using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Examples;
using Jobberwocky.GeometryAlgorithms.Examples.Data;
using Jobberwocky.GeometryAlgorithms.Source.API;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

public class ExampleInteractiveVoronoi2D : ExampleGeometryAlgorithms
{
	public Mesh pointMesh;

	public Mesh lineMesh;

	public Color pointColor;

	public Color triangulationLineColor;

	public Color voronoiLineColor;

	public Color voronoiCellColor;

	public Material material;

	private Material pointMaterial;

	private Material triangulationLineMaterial;

	private Material voronoiLineMaterial;

	private Material voronoiCellMaterial;

	private Vector3[] data;

	private GameObject mousePosition;

	private GameObject voronoiLines;

	private GameObject triangulationLines;

	private GameObject voronoiCell;

	private VoronoiAPI voronoiAPI;

	private TriangulationAPI triangulationAPI;

	private List<GameObject> triLineObjects;

	private List<GameObject> voronoiLineObjects;

	private void Start()
	{
		pointMaterial = new Material(material);
		pointMaterial.SetColor("_Color", pointColor);
		triangulationLineMaterial = new Material(material);
		triangulationLineMaterial.SetColor("_Color", triangulationLineColor);
		voronoiLineMaterial = new Material(material);
		voronoiLineMaterial.SetColor("_Color", voronoiLineColor);
		voronoiCellMaterial = new Material(material);
		voronoiCellMaterial.SetColor("_Color", voronoiCellColor);
		triLineObjects = new List<GameObject>();
		voronoiLineObjects = new List<GameObject>();
		GameObject gameObject = new GameObject("Points");
		gameObject.transform.parent = base.gameObject.transform;
		ShapeGenerator shapeGenerator = new ShapeGenerator();
		float num = 0.08f;
		Vector3[] array = shapeGenerator.CreateRandomPoints2D(200, 35f, 20f);
		CreatePointSpheres(array, num, pointMesh, pointMaterial, gameObject);
		data = new Vector3[array.Length + 1];
		for (int i = 0; i < array.Length; i++)
		{
			data[i + 1] = array[i];
		}
		data[0] = new Vector3(0f, 0f);
		triangulationAPI = new TriangulationAPI();
		Mesh mesh = triangulationAPI.Triangulate2D(new Triangulation2DParameters
		{
			Points = data,
			Side = Side.Back
		});
		triangulationLines = new GameObject("Triangulation Lines");
		triangulationLines.transform.parent = base.gameObject.transform;
		CreateLineCylinders(CreateWireframe(mesh), triangulationLineMaterial, 0.03f, triangulationLines, triLineObjects);
		voronoiAPI = new VoronoiAPI();
		Geometry geometry = voronoiAPI.Voronoi2DRaw(new Voronoi2DParameters
		{
			Points = data
		});
		voronoiLines = new GameObject("Voronoi Lines");
		voronoiLines.transform.parent = base.gameObject.transform;
		CreateLineCylinders(geometry.ToUnityMesh(), voronoiLineMaterial, 0.05f, voronoiLines, voronoiLineObjects);
		Mesh mesh2 = triangulationAPI.Triangulate2D(new Triangulation2DParameters
		{
			Points = geometry.Cells[0].ToUnityMesh().vertices,
			Side = Side.Back
		});
		voronoiCell = new GameObject("Voronoi Cell");
		voronoiCell.transform.parent = base.gameObject.transform;
		voronoiCell.AddComponent<MeshFilter>().mesh = mesh2;
		voronoiCell.AddComponent<MeshRenderer>().material = voronoiCellMaterial;
		mousePosition = new GameObject("Mouse Position");
		mousePosition.transform.parent = base.gameObject.transform;
		mousePosition.transform.localScale = new Vector3(num, num, num);
		mousePosition.AddComponent<MeshFilter>().mesh = pointMesh;
		mousePosition.AddComponent<MeshRenderer>().material = pointMaterial;
	}

	private void Update()
	{
		double num = 0.01;
		float axis = Input.GetAxis("Mouse X");
		float axis2 = Input.GetAxis("Mouse Y");
		if ((double)axis - num > 0.0 || (double)axis + num < 0.0 || (double)axis2 - num > 0.0 || (double)axis2 + num < 0.0)
		{
			Vector3 position = Input.mousePosition;
			if (position.x > 0f && position.y > 0f && position.x < (float)Screen.width && position.y < (float)Screen.height)
			{
				Camera main = Camera.main;
				position.z = Mathf.Abs(main.transform.position.z);
				Vector3 vector = main.ScreenToWorldPoint(position);
				mousePosition.transform.localPosition = vector;
				data[0] = vector;
				Geometry geometry = voronoiAPI.Voronoi2DRaw(new Voronoi2DParameters
				{
					Points = data
				});
				CreateLineCylinders(geometry.ToUnityMesh(), voronoiLineMaterial, 0.05f, voronoiLines, voronoiLineObjects);
				CreateLineCylinders(CreateWireframe(triangulationAPI.Triangulate2D(new Triangulation2DParameters
				{
					Points = data,
					Side = Side.Back
				})), triangulationLineMaterial, 0.03f, triangulationLines, triLineObjects);
				voronoiCell.GetComponent<MeshFilter>().mesh = triangulationAPI.Triangulate2D(new Triangulation2DParameters
				{
					Points = geometry.Cells[0].ToUnityMesh().vertices,
					Side = Side.Back
				});
			}
		}
	}

	private void CreateLineCylinders(Mesh mesh, Material material, float scale, GameObject parent, List<GameObject> existingObjects)
	{
		Vector3[] vertices = mesh.vertices;
		int[] indices = mesh.GetIndices(0);
		for (int i = 0; i < indices.Length; i += 2)
		{
			Vector3 vector = vertices[indices[i]];
			Vector3 vector2 = vertices[indices[i + 1]];
			GameObject gameObject;
			if (i / 2 < existingObjects.Count)
			{
				gameObject = existingObjects[i / 2];
			}
			else
			{
				gameObject = new GameObject(parent.name + " Cylinder " + i);
				gameObject.transform.parent = parent.transform;
				gameObject.AddComponent<MeshFilter>();
				gameObject.AddComponent<MeshRenderer>().material = material;
				existingObjects.Add(gameObject);
			}
			gameObject.transform.localPosition = (vector2 - vector) / 2f + vector;
			gameObject.transform.localScale = new Vector3(scale, (vector2 - vector).magnitude / 2f, scale);
			gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, vector2 - vector);
			gameObject.SetActive(value: true);
			gameObject.GetComponent<MeshFilter>().mesh = lineMesh;
		}
		for (int j = indices.Length / 2; j < existingObjects.Count; j++)
		{
			existingObjects[j].SetActive(value: false);
		}
	}

	private Mesh CreateWireframe(Mesh mesh)
	{
		int[] indices = mesh.GetIndices(0);
		int[] array = new int[indices.Length * 2];
		for (int i = 0; i < indices.Length; i += 3)
		{
			array[i * 2] = indices[i];
			array[i * 2 + 1] = indices[i + 1];
			array[i * 2 + 2] = indices[i + 1];
			array[i * 2 + 3] = indices[i + 2];
			array[i * 2 + 4] = indices[i + 2];
			array[i * 2 + 5] = indices[i];
		}
		Mesh mesh2 = new Mesh();
		mesh2.vertices = mesh.vertices;
		mesh2.SetIndices(array, MeshTopology.Lines, 0);
		return mesh2;
	}
}
