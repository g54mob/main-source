using System;
using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Examples.Data;
using Jobberwocky.GeometryAlgorithms.Source.API;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;
using UnityEngine.UI;

namespace Jobberwocky.GeometryAlgorithms.Examples
{
	public class ExampleGeometry2DAsync : ExampleGeometryAlgorithms
	{
		private sealed class _003C_003Ec__DisplayClass21_0
		{
			public ExampleGeometry2DAsync _003C_003E4__this;

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

		private sealed class _003C_003Ec__DisplayClass23_0
		{
			public ExampleGeometry2DAsync _003C_003E4__this;

			public Shape shape;

			public Action<Geometry> _003C_003E9__1;

			internal void _003CCreateTriangulation_003Eb__0(Geometry geometryHull)
			{
				Mesh mesh = geometryHull.ToUnityMesh();
				_003C_003E4__this.triangulationAPI.Triangulate2DAsync(delegate(Geometry geometry)
				{
					Mesh mesh2 = geometry.ToUnityMesh();
					Mesh mesh3 = _003C_003E4__this.CreateWireframe(mesh2);
					_003C_003E4__this.Triangles.GetComponent<MeshFilter>().mesh = mesh2;
					_003C_003E4__this.Lines.GetComponent<MeshFilter>().mesh = mesh3;
				}, new Triangulation2DParameters
				{
					Points = shape.Points,
					Boundary = mesh.vertices,
					Side = Side.Back
				});
			}

			internal void _003CCreateTriangulation_003Eb__1(Geometry geometry)
			{
				Mesh mesh = geometry.ToUnityMesh();
				Mesh mesh2 = _003C_003E4__this.CreateWireframe(mesh);
				_003C_003E4__this.Triangles.GetComponent<MeshFilter>().mesh = mesh;
				_003C_003E4__this.Lines.GetComponent<MeshFilter>().mesh = mesh2;
			}
		}

		private sealed class _003C_003Ec__DisplayClass24_0
		{
			public ExampleGeometry2DAsync _003C_003E4__this;

			public Vector3[] points;

			internal void _003CCreateHull_003Eb__0(Geometry geometryHull)
			{
				_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass24_1();
				CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1 = this;
				CS_0024_003C_003E8__locals10.hull = geometryHull.ToUnityMesh();
				_003C_003E4__this.triangulationAPI.Triangulate2DAsync(delegate(Geometry geometryMesh)
				{
					Mesh mesh = geometryMesh.ToUnityMesh();
					int[] array = new int[CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1.points.Length];
					for (int i = 0; i < CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1.points.Length; i++)
					{
						array[i] = i;
					}
					Mesh mesh2 = new Mesh();
					mesh2.vertices = CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1.points;
					mesh2.SetIndices(array, MeshTopology.Points, 0);
					CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1._003C_003E4__this.Points.GetComponent<MeshFilter>().mesh = mesh2;
					CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1._003C_003E4__this.Triangles.GetComponent<MeshFilter>().mesh = mesh;
					CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1._003C_003E4__this.Lines.GetComponent<MeshFilter>().mesh = CS_0024_003C_003E8__locals10.hull;
				}, new Triangulation2DParameters
				{
					Boundary = CS_0024_003C_003E8__locals10.hull.vertices,
					Side = Side.Back
				});
			}
		}

		private sealed class _003C_003Ec__DisplayClass24_1
		{
			public Mesh hull;

			public _003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals1;

			internal void _003CCreateHull_003Eb__1(Geometry geometryMesh)
			{
				Mesh mesh = geometryMesh.ToUnityMesh();
				int[] array = new int[CS_0024_003C_003E8__locals1.points.Length];
				for (int i = 0; i < CS_0024_003C_003E8__locals1.points.Length; i++)
				{
					array[i] = i;
				}
				Mesh mesh2 = new Mesh();
				mesh2.vertices = CS_0024_003C_003E8__locals1.points;
				mesh2.SetIndices(array, MeshTopology.Points, 0);
				CS_0024_003C_003E8__locals1._003C_003E4__this.Points.GetComponent<MeshFilter>().mesh = mesh2;
				CS_0024_003C_003E8__locals1._003C_003E4__this.Triangles.GetComponent<MeshFilter>().mesh = mesh;
				CS_0024_003C_003E8__locals1._003C_003E4__this.Lines.GetComponent<MeshFilter>().mesh = hull;
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
			new Dropdown.OptionData("Horse"),
			new Dropdown.OptionData("Owl")
		};

		private Dictionary<string, ShapeType> shapeTypes = new Dictionary<string, ShapeType>
		{
			{
				"Horse",
				ShapeType.Horse13k
			},
			{
				"Owl",
				ShapeType.Owl15k
			}
		};

		private TriangulationAPI triangulationAPI;

		private HullAPI hullAPI;

		private void Start()
		{
			_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass21_0();
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			triangulationAPI = new TriangulationAPI();
			hullAPI = new HullAPI();
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
			Lines = new GameObject("Lines");
			Lines.transform.parent = GeometryObject.transform;
			Lines.AddComponent<MeshFilter>().mesh = new Mesh();
			Lines.AddComponent<MeshRenderer>().material = wireframeMaterial;
			Points = new GameObject("Points");
			Points.transform.parent = GeometryObject.transform;
			Points.AddComponent<MeshFilter>().mesh = new Mesh();
			Points.AddComponent<MeshRenderer>().material = pointMaterial;
			UpdateGeometry("Horse", "Triangulation");
		}

		private void Update()
		{
			triangulationAPI.ActivateCallbacks();
			hullAPI.ActivateCallbacks();
		}

		private void CreateTriangulation(Shape shape)
		{
			_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass23_0();
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			CS_0024_003C_003E8__locals8.shape = shape;
			hullAPI.Hull2DAsync(delegate(Geometry geometryHull)
			{
				Mesh mesh = geometryHull.ToUnityMesh();
				CS_0024_003C_003E8__locals8._003C_003E4__this.triangulationAPI.Triangulate2DAsync(delegate(Geometry geometry)
				{
					Mesh mesh2 = geometry.ToUnityMesh();
					Mesh mesh3 = CS_0024_003C_003E8__locals8._003C_003E4__this.CreateWireframe(mesh2);
					CS_0024_003C_003E8__locals8._003C_003E4__this.Triangles.GetComponent<MeshFilter>().mesh = mesh2;
					CS_0024_003C_003E8__locals8._003C_003E4__this.Lines.GetComponent<MeshFilter>().mesh = mesh3;
				}, new Triangulation2DParameters
				{
					Points = CS_0024_003C_003E8__locals8.shape.Points,
					Boundary = mesh.vertices,
					Side = Side.Back
				});
			}, new Hull2DParameters
			{
				Points = CS_0024_003C_003E8__locals8.shape.Points,
				Concavity = 30.0
			});
			Camera.main.backgroundColor = new Color(14f / 15f, 0.34901962f, 36f / 85f);
		}

		private void CreateHull(Shape shape)
		{
			_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass24_0();
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			CS_0024_003C_003E8__locals8.points = shape.GetAllPoints();
			hullAPI.Hull2DAsync(delegate(Geometry geometryHull)
			{
				_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass24_1();
				CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals8;
				CS_0024_003C_003E8__locals16.hull = geometryHull.ToUnityMesh();
				CS_0024_003C_003E8__locals8._003C_003E4__this.triangulationAPI.Triangulate2DAsync(delegate(Geometry geometryMesh)
				{
					Mesh mesh = geometryMesh.ToUnityMesh();
					int[] array = new int[CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1.points.Length];
					for (int i = 0; i < CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1.points.Length; i++)
					{
						array[i] = i;
					}
					Mesh mesh2 = new Mesh();
					mesh2.vertices = CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1.points;
					mesh2.SetIndices(array, MeshTopology.Points, 0);
					CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1._003C_003E4__this.Points.GetComponent<MeshFilter>().mesh = mesh2;
					CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1._003C_003E4__this.Triangles.GetComponent<MeshFilter>().mesh = mesh;
					CS_0024_003C_003E8__locals16.CS_0024_003C_003E8__locals1._003C_003E4__this.Lines.GetComponent<MeshFilter>().mesh = CS_0024_003C_003E8__locals16.hull;
				}, new Triangulation2DParameters
				{
					Boundary = CS_0024_003C_003E8__locals16.hull.vertices,
					Side = Side.Back
				});
			}, new Hull2DParameters
			{
				Points = CS_0024_003C_003E8__locals8.points,
				Concavity = 30.0
			});
			Camera.main.backgroundColor = new Color(11f / 51f, 63f / 85f, 35f / 51f);
		}

		private void UpdateGeometry(string dataName, string algorithmName)
		{
			Triangles.GetComponent<MeshFilter>().mesh = new Mesh();
			Lines.GetComponent<MeshFilter>().mesh = new Mesh();
			Points.GetComponent<MeshFilter>().mesh = new Mesh();
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
}
