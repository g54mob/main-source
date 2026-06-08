using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Examples.Data;
using Jobberwocky.GeometryAlgorithms.Source.API;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Jobberwocky.GeometryAlgorithms.Examples
{
	public class ExampleGeometry3D : ExampleGeometryAlgorithms
	{
		private sealed class _003C_003Ec__DisplayClass16_0
		{
			public ExampleGeometry3D _003C_003E4__this;

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

		public Color polygonColor;

		public Mesh cylinderMesh;

		public Mesh sphereMesh;

		public Material material;

		private GameObject GeometryObject;

		private GameObject Triangles;

		private GameObject Lines;

		private GameObject Points;

		private Material pointMaterial;

		private Material wireframeMaterial;

		private Material polygonMaterial;

		private List<Dropdown.OptionData> optionsAlgorithms = new List<Dropdown.OptionData>
		{
			new Dropdown.OptionData("Triangulation"),
			new Dropdown.OptionData("Convex hull"),
			new Dropdown.OptionData("Voronoi diagram")
		};

		private List<Dropdown.OptionData> optionsData = new List<Dropdown.OptionData>
		{
			new Dropdown.OptionData("Cube"),
			new Dropdown.OptionData("Random"),
			new Dropdown.OptionData("Sphere")
		};

		private Dictionary<string, ShapeType> shapeTypes = new Dictionary<string, ShapeType>
		{
			{
				"Cube",
				ShapeType.Cube
			},
			{
				"Random",
				ShapeType.Random3D
			},
			{
				"Sphere",
				ShapeType.Sphere
			}
		};

		private void Start()
		{
			_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass16_0();
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
			polygonMaterial = new Material(material);
			polygonMaterial.SetColor("_Color", polygonColor);
			GeometryObject = new GameObject("Geometry Object");
			GeometryObject.transform.parent = base.gameObject.transform;
			Triangles = new GameObject("Triangles");
			Triangles.transform.parent = GeometryObject.transform;
			Triangles.AddComponent<MeshFilter>().mesh = new Mesh();
			Triangles.AddComponent<MeshRenderer>().material = polygonMaterial;
			UpdateGeometry("Cube", "Triangulation");
		}

		private void CreateTriangulation(Shape shape)
		{
			Triangulation3DParameters parameters = new Triangulation3DParameters
			{
				Points = shape.GetAllPoints(),
				BoundaryOnly = true
			};
			Mesh mesh = new TriangulationAPI().Triangulate3D(parameters);
			Triangles.GetComponent<MeshFilter>().mesh = mesh;
			float scale = Mathf.Abs(shape.CameraPoint.z / 45f);
			float scale2 = Mathf.Abs(shape.CameraPoint.z / 150f);
			CreatePointSpheres(mesh.vertices, scale, sphereMesh, pointMaterial, Points);
			CreateWireframe(mesh, scale2, cylinderMesh, wireframeMaterial, Lines);
		}

		private void CreateHull(Shape shape)
		{
			Vector3[] allPoints = shape.GetAllPoints();
			Hull3DParameters parameters = new Hull3DParameters
			{
				Points = allPoints
			};
			Mesh mesh = new HullAPI().ConvexHull3D(parameters);
			Triangles.GetComponent<MeshFilter>().mesh = mesh;
			float scale = Mathf.Abs(shape.CameraPoint.z / 45f);
			float scale2 = Mathf.Abs(shape.CameraPoint.z / 150f);
			CreatePointSpheres(allPoints, scale, sphereMesh, pointMaterial, Points);
			CreateWireframe(mesh, scale2, cylinderMesh, wireframeMaterial, Lines);
		}

		private void CreateVoronoi(Shape shape)
		{
			Triangles.GetComponent<MeshFilter>().mesh = new Mesh();
			Vector3[] allPoints = shape.GetAllPoints();
			Voronoi3DParameters parameters = new Voronoi3DParameters
			{
				Points = allPoints
			};
			Mesh mesh = new VoronoiAPI().Voronoi3D(parameters);
			float scale = Mathf.Abs(shape.CameraPoint.z / 45f);
			Mathf.Abs(shape.CameraPoint.z / 150f);
			CreatePointSpheres(allPoints, scale, sphereMesh, pointMaterial, Points);
			Lines.AddComponent<MeshFilter>().mesh = mesh;
			Lines.AddComponent<MeshRenderer>().material = wireframeMaterial;
		}

		private void UpdateGeometry(string dataName, string algorithmName)
		{
			Object.Destroy(Points);
			Object.Destroy(Lines);
			Points = new GameObject("Points");
			Lines = new GameObject("Lines");
			Points.transform.parent = GeometryObject.transform;
			Lines.transform.parent = GeometryObject.transform;
			Shape shape = Jobberwocky.GeometryAlgorithms.Examples.Data.Data.Get(shapeTypes[dataName]);
			switch (algorithmName)
			{
			case "Triangulation":
				CreateTriangulation(shape);
				break;
			case "Convex hull":
				CreateHull(shape);
				break;
			case "Voronoi diagram":
				CreateVoronoi(shape);
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
