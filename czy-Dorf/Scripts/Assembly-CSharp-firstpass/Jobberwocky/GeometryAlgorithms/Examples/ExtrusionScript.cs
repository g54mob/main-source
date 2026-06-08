using Jobberwocky.GeometryAlgorithms.Examples.Data;
using Jobberwocky.GeometryAlgorithms.Extrusion;
using Jobberwocky.GeometryAlgorithms.GeometryAlgorithms.Source.Algorithms;
using Jobberwocky.GeometryAlgorithms.Source.API;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples
{
	public class ExtrusionScript : MonoBehaviour
	{
		private ShapeType _shapeType;

		public ShapeType shapeType;

		private float _height;

		public float height;

		public bool autoHeight;

		private float _stepSize = 0.05f;

		private float _minBound = -8f;

		private float _maxBound = 8f;

		private MeshFilter _meshFilter;

		private Mesh _triangulatedMesh;

		private ExtrusionAlgorithm _extrusionAlgorithm;

		private TriangulationAPI _triangulationApi;

		private void Start()
		{
			_triangulationApi = new TriangulationAPI();
			_extrusionAlgorithm = Algorithm<ExtrusionAlgorithm>.Instance;
			_meshFilter = base.gameObject.AddComponent<MeshFilter>();
			CreateExtrudedMesh();
		}

		private void Update()
		{
			if (autoHeight)
			{
				if (height < _minBound || height > _maxBound)
				{
					_stepSize *= -1f;
				}
				height += _stepSize;
			}
			if (!Mathf.Approximately(_height, height))
			{
				_height = height;
				_meshFilter.mesh = _extrusionAlgorithm.Extrude(_triangulatedMesh, _height);
			}
			if (_shapeType != shapeType)
			{
				_shapeType = shapeType;
				CreateExtrudedMesh();
			}
		}

		private void CreateExtrudedMesh()
		{
			Shape shape = Jobberwocky.GeometryAlgorithms.Examples.Data.Data.Get(shapeType);
			Triangulation2DParameters triangulation2DParameters = new Triangulation2DParameters();
			triangulation2DParameters.Points = shape.Points;
			triangulation2DParameters.Boundary = shape.Boundary;
			triangulation2DParameters.Holes = shape.Holes;
			triangulation2DParameters.Delaunay = true;
			_triangulatedMesh = _triangulationApi.Triangulate2D(triangulation2DParameters);
			_meshFilter.mesh = _extrusionAlgorithm.Extrude(_triangulatedMesh, _height);
		}
	}
}
