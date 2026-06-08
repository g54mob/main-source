using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Examples.Data;
using Jobberwocky.GeometryAlgorithms.Source.API;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Jobberwocky.GeometryAlgorithms.Examples
{
	public class ExampleGeometry2D : ExampleGeometryAlgorithms
	{
		private sealed class _003C_003Ec__DisplayClass19_0
		{
			public ExampleGeometry2D _003C_003E4__this;

			public Dropdown dropdownData;

			public Dropdown dropdownAlgorithm;

			internal void _003CStart_003Eb__0(int _003Cp0_003E)
			{
				_003C_003E4__this.UpdateGeometry(dropdownData.captionText.text, dropdownAlgorithm.captionText.text);
			}

			internal void _003CStart_003Eb__1(int _003Cp0_003E)
			{
				_003C_003E4__this.UpdateGeometry(dropdownData.captionText.text, dropdownAlgorithm.captionText.text);
			}
		}

		public Color pointColor;

		public Color wireframeColor;

		public Color boundaryColor;

		public Color polygonColor;

		public Mesh cylinderMesh;

		public Mesh sphereMesh;

		public Material material;

		private GameObject GeometryObject;

		private GameObject Points;

		private GameObject Lines;

		private GameObject Boundary;

		private GameObject Triangles;

		private Material pointMaterial;

		private Material wireframeMaterial;

		private Material boundaryMaterial;

		private Material polygonMaterial;

		private List<Dropdown.OptionData> optionsAlgorithms = new List<Dropdown.OptionData>
		{
			new Dropdown.OptionData("Triangulation"),
			new Dropdown.OptionData("Hull")
		};

		private List<Dropdown.OptionData> optionsData = new List<Dropdown.OptionData>
		{
			new Dropdown.OptionData("Dude"),
			new Dropdown.OptionData("Bird"),
			new Dropdown.OptionData("Tank"),
			new Dropdown.OptionData("Random"),
			new Dropdown.OptionData("Circle"),
			new Dropdown.OptionData("CircleWithHole"),
			new Dropdown.OptionData("Square"),
			new Dropdown.OptionData("SquareWithHole")
		};

		private Dictionary<string, ShapeType> shapeTypes = new Dictionary<string, ShapeType>
		{
			{
				"Dude",
				ShapeType.Dude
			},
			{
				"Bird",
				ShapeType.Bird
			},
			{
				"Tank",
				ShapeType.Tank
			},
			{
				"Random",
				ShapeType.Random2D
			},
			{
				"Circle",
				ShapeType.Circle
			},
			{
				"CircleWithHole",
				ShapeType.CircleWithHole
			},
			{
				"Square",
				ShapeType.Square
			},
			{
				"SquareWithHole",
				ShapeType.SquareWithHole
			}
		};

		private void Start()
		{
			_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass19_0();
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			CS_0024_003C_003E8__locals13.dropdownData = GetDropdown("DropdownData");
			CS_0024_003C_003E8__locals13.dropdownAlgorithm = GetDropdown("DropdownAlgorithm");
			CS_0024_003C_003E8__locals13.dropdownData.AddOptions(optionsData);
			CS_0024_003C_003E8__locals13.dropdownAlgorithm.AddOptions(optionsAlgorithms);
			CS_0024_003C_003E8__locals13.dropdownData.onValueChanged.AddListener(delegate
			{
				CS_0024_003C_003E8__locals13._003C_003E4__this.UpdateGeometry(CS_0024_003C_003E8__locals13.dropdownData.captionText.text, CS_0024_003C_003E8__locals13.dropdownAlgorithm.captionText.text);
			});
			CS_0024_003C_003E8__locals13.dropdownAlgorithm.onValueChanged.AddListener(delegate
			{
				CS_0024_003C_003E8__locals13._003C_003E4__this.UpdateGeometry(CS_0024_003C_003E8__locals13.dropdownData.captionText.text, CS_0024_003C_003E8__locals13.dropdownAlgorithm.captionText.text);
			});
			pointMaterial = new Material(material);
			pointMaterial.SetColor("_Color", pointColor);
			wireframeMaterial = new Material(material);
			wireframeMaterial.SetColor("_Color", wireframeColor);
			boundaryMaterial = new Material(material);
			boundaryMaterial.SetColor("_Color", boundaryColor);
			polygonMaterial = new Material(material);
			polygonMaterial.SetColor("_Color", polygonColor);
			GeometryObject = new GameObject("Geometry Object");
			GeometryObject.transform.parent = base.gameObject.transform;
			Triangles = new GameObject("Triangles");
			Triangles.transform.parent = GeometryObject.transform;
			Triangles.AddComponent<MeshFilter>().mesh = new Mesh();
			Triangles.AddComponent<MeshRenderer>().material = polygonMaterial;
			UpdateGeometry("Dude", "Triangulation");
		}

		private void CreateTriangulation(Shape shape)
		{
			Triangulation2DParameters triangulation2DParameters = new Triangulation2DParameters();
			triangulation2DParameters.Points = shape.Points;
			triangulation2DParameters.Boundary = shape.Boundary;
			triangulation2DParameters.Holes = shape.Holes;
			triangulation2DParameters.Side = Side.Back;
			triangulation2DParameters.Delaunay = true;
			Mesh mesh = new TriangulationAPI().Triangulate2D(triangulation2DParameters);
			Triangles.GetComponent<MeshFilter>().mesh = mesh;
			float scale = Mathf.Abs(shape.CameraPoint.z / 350f);
			float scale2 = Mathf.Abs(shape.CameraPoint.z / 250f);
			CreateWireframe(mesh, scale, cylinderMesh, wireframeMaterial, Lines);
			CreateBoundaries(shape, scale2, cylinderMesh, boundaryMaterial, Boundary);
			Camera.main.backgroundColor = new Color(14f / 15f, 0.34901962f, 36f / 85f);
		}

		private void CreateHull(Shape shape)
		{
			Vector3[] allPoints = shape.GetAllPoints();
			Mesh mesh = new HullAPI().Hull2D(new Hull2DParameters
			{
				Points = allPoints,
				Concavity = 30.0
			});
			Mesh mesh2 = new TriangulationAPI().Triangulate2D(new Triangulation2DParameters
			{
				Boundary = mesh.vertices,
				Side = Side.Back
			});
			Triangles.GetComponent<MeshFilter>().mesh = mesh2;
			float scale = Mathf.Abs(shape.CameraPoint.z / 100f);
			float scale2 = Mathf.Abs(shape.CameraPoint.z / 100f);
			CreatePointSpheres(allPoints, scale, sphereMesh, pointMaterial, Points);
			CreateLineCylinders(mesh.vertices, scale2, cylinderMesh, boundaryMaterial, Boundary);
			Camera.main.backgroundColor = new Color(11f / 51f, 63f / 85f, 35f / 51f);
		}

		private void UpdateGeometry(string dataName, string algorithmName)
		{
			Triangles.GetComponent<MeshFilter>().mesh = new Mesh();
			Object.Destroy(Points);
			Object.Destroy(Lines);
			Object.Destroy(Boundary);
			Points = new GameObject("Points");
			Lines = new GameObject("Lines");
			Boundary = new GameObject("Boundary");
			Points.transform.parent = GeometryObject.transform;
			Lines.transform.parent = GeometryObject.transform;
			Boundary.transform.parent = GeometryObject.transform;
			Shape shape = Jobberwocky.GeometryAlgorithms.Examples.Data.Data.Get(shapeTypes[dataName]);
			switch (algorithmName)
			{
			case "Triangulation":
				CreateTriangulation(shape);
				break;
			case "Hull":
				CreateHull(shape);
				break;
			}
			Camera.main.transform.position = shape.CameraPoint;
			Camera.main.transform.rotation = shape.CameraRotation;
		}

		private Dropdown GetDropdown(string name)
		{
			return GameObject.Find(name).GetComponent<Dropdown>();
		}
	}
}
