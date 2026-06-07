using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	public class VisualMesh
	{
		private const float pi = (float)Math.PI;

		private const float pi2 = (float)Math.PI / 2f;

		public List<Mesh> meshes;

		public Vector3[] verticesArray;

		public Vector2[] uvArray;

		public int[] trianglesArray;

		public List<Vector3> vertices;

		public List<Vector2> uv;

		public List<int> triangles;

		public int triCount;

		public int uvCount;

		public int vertCount;

		public int tris;

		public Mesh GetMesh(int id = 0)
		{
			return null;
		}

		public Mesh Export(int id = 0)
		{
			return null;
		}

		public void Clear()
		{
		}

		public void AddVertice(Vector3 v)
		{
		}

		public void AddTriangle(int tri)
		{
		}

		public void AddUV(Vector2 uvVar)
		{
		}

		public void GeneratePoint(Pair2 linearPair, Transform transform, float lineWidth, float zPosition)
		{
		}

		public void GeneratePolygonMesh(Vector2 pos, Polygon2D.PolygonType polygonType, float polygonSize, float minVertexDistance, Transform transform, float lineWidth, float zPosition)
		{
		}

		public void GeneratePolygon2DMesh(Transform transform, Polygon2D polygon, float lineOffset, float lineWidth, bool connectedLine)
		{
		}

		public void Complex_GenerateMesh(Vector2List complexSlicerPointsList, Transform transform, float lineWidth, float minVertexDistance, float zPosition, float squareSize, float lineEndWidth, float vertexSpace, Slicer2DLineEndingType endingType, int edges)
		{
		}

		public void Complex_GenerateTrackerMesh(Dictionary<Slicer2D, SlicerTrackerObject> trackerList, Transform transform, float lineWidth, float zPosition)
		{
		}

		public void Complex_GenerateTrackerMesh(Vector2 pos, Dictionary<Slicer2D, SlicerTrackerObject> trackerList, Transform transform, float lineWidth, float zPosition, float squareSize, Slicer2DLineEndingType endingType, int edges)
		{
		}

		public void Complex_GenerateCutMesh(List<Vector2D> complexSlicerPointsList, float cutSize, Transform transform, float lineWidth, float zPosition)
		{
		}

		public void GenerateCreateMesh(Vector2 pos, Polygon2D.PolygonType polygonType, float polygonSize, Slicer2DCreateControllerObject.CreateType createType, List<Vector2D> complexSlicerPointsList, Pair2D linearPair, float minVertexDistance, Transform transform, float lineWidth, float zPosition, float squareSize, Slicer2DLineEndingType endingType, int edges)
		{
		}

		public void GenerateTrailMesh(Dictionary<Slicer2D, SlicerTrailObject> trailList, Transform transform, float lineWidth, float zPosition, float squareSize)
		{
		}

		public void Linear_GenerateMesh(Pair2 linearPair, Transform transform, float lineWidth, float zPosition, float size, float lineEndWidth, Slicer2DLineEndingType endingType, int edges)
		{
		}

		public void Linear_GenerateCutMesh(Pair2 linearPair, float cutSize, Transform transform, float lineWidth, float zPosition)
		{
		}

		public void Linear_GenerateTrackerMesh(Vector2 pos, Dictionary<Slicer2D, SlicerTrackerObject> trackerList, Transform transform, float lineWidth, float zPosition, float size, Slicer2DLineEndingType endingType, int edges)
		{
		}

		public void GenerateSquare(Vector2 point, float size, Transform transform, float width, float z, Slicer2DLineEndingType endingType, int edges)
		{
		}

		public void CreatePolygon(Transform transform, Polygon2D polygon, float lineOffset, float lineWidth, bool connectedLine)
		{
		}

		public void CreateBox(float size)
		{
		}

		public void CreateLine(Pair2 pair, Vector3 transformScale, float lineWidth, float z = 0f)
		{
		}

		public void Draw(Transform transform, Material material, int id = 0)
		{
		}

		public void Draw(Material material, int id = 0)
		{
		}
	}
}
