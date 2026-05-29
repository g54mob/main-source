using System;
using System.Collections.Generic;
using TinyGiantStudio.Text.FontCreation;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	[Serializable]
	public class Glyph
	{
		public int glyphIndex;

		[SerializeField]
		private bool _isVisible;

		[SerializeField]
		private int _resolution;

		[SerializeField]
		private float _scaleFactor;

		[SerializeField]
		private float _extrudeDepth;

		[SerializeField]
		private int _vertexCount;

		[SerializeField]
		private int _triCount;

		[SerializeField]
		private Vector3[] _baseVertices;

		[SerializeField]
		private Vector3[] _vertices;

		[SerializeField]
		private int[] _baseTriangles;

		[SerializeField]
		private int[] _triangles;

		[SerializeField]
		private int _frontTriIndex;

		[SerializeField]
		private int _frontVertIndex;

		[SerializeField]
		private int _xMin;

		[SerializeField]
		private int _yMin;

		[SerializeField]
		private int _xMax;

		[SerializeField]
		private int _yMax;

		[SerializeField]
		private int _unitsPerEm;

		[SerializeField]
		private bool pointsAreOutside;

		[SerializeField]
		private List<ContourData> _contourList;

		public int GlyphIndex => 0;

		public bool isVisible => false;

		public int resolution => 0;

		public float scaleFactor => 0f;

		public float extrudeDepth => 0f;

		public int vertexCount => 0;

		public int triCount => 0;

		public Vector3[] vertices => null;

		public int[] triangles => null;

		public int xMin => 0;

		public int yMin => 0;

		public int xMax => 0;

		public int yMax => 0;

		public Glyph(List<Vector2[]> pointsList, List<bool[]> onCurvesList, int xMin, int yMin, int xMax, int yMax, int unitsPerEm, int glyphIndex)
		{
		}

		private List<ContourData> SortPointsList(List<Vector2[]> pointsList, List<bool[]> onCurvesList)
		{
			return null;
		}

		private bool PolyContainsPoint(Vector2[] polyPoints, Vector2 p)
		{
			return false;
		}

		private int Area(ContourData a, ContourData b)
		{
			return 0;
		}

		private int XMax(InsideData a, InsideData b)
		{
			return 0;
		}

		private Vector2[] RenderContourPoints(ContourData contour, int resolution, bool initialTest)
		{
			return null;
		}

		public bool SetMeshData(char charToProcess, int resolution, bool keepFailedCharacters, float autoSmoothAngle, ref List<FailedCharacter> failedCharacters)
		{
			return false;
		}

		private void AddTriangle(int[] meshTriangles, ref int triAdd, ref int triIdx, ref int edgeTriCount, ref int vCount)
		{
		}

		public void ScaleVertices(float scaleFactor)
		{
		}

		private void CopyAndScale(float scaleFactor, int length)
		{
		}

		private void CopyAndScale(float scaleFactor, int source, int dest, int length)
		{
		}

		public void SetFrontData()
		{
		}

		public void SetData()
		{
		}

		public void SetDepth(float depth)
		{
		}

		private float LineToPointSqrDistance(ref Vector2 p1, ref Vector2 p2, ref Vector2 p)
		{
			return 0f;
		}

		private bool ArePointsOutside(Vector2[] points)
		{
			return false;
		}

		private bool Compute(char processingChar, List<ContourData> contourList, List<int[]> vertexList, int[] vertexCounts, int[] xMaxVertices, Vector2[] xMaxPoints, List<Vector2[]> pointsList, int[] meshTriangles, ref int triIdx, ref int triAdd, bool keepFailedCharacters, ref List<FailedCharacter> failedCharacters)
		{
			return false;
		}

		private bool IsReflex(ref Vector2 a, ref Vector2 b, ref Vector2 c)
		{
			return false;
		}

		private bool PointInsideTriangle(ref Vector2 p, ref Vector2 a, ref Vector2 b, ref Vector2 c)
		{
			return false;
		}
	}
}
