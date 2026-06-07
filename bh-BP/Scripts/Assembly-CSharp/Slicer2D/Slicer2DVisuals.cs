using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DVisuals
	{
		public class RendererObject
		{
			public MeshRenderer meshRenderer;

			public MeshFilter meshFilter;

			public Transform transform;

			public bool drawn;

			public RendererObject(GameObject gameObject)
			{
			}
		}

		public Slicer2DLineEndingType lineEndingType;

		public int lineEndingEdgeCount;

		public bool drawSlicer;

		public float visualScale;

		public float lineWidth;

		public float lineEndWidth;

		public float zPosition;

		public Color slicerColor;

		public bool lineBorder;

		public float lineEndSize;

		public float vertexSpace;

		public float borderScale;

		public float minVertexDistance;

		public bool customMaterial;

		public Material customFillMaterial;

		public Material customBoarderMaterial;

		public int sortingOrder;

		public string sortingLayerName;

		public bool customEndingsImage;

		public Material customEndingImageMaterial;

		public List<Pair2> customEndingsPosition;

		private List<Mesh> mesh;

		private List<Mesh> meshBorder;

		private SmartMaterial fillMaterial;

		private SmartMaterial boarderMaterial;

		public List<RendererObject> rendererObjects;

		private GameObject gameObject;

		private Transform transform;

		public VisualMesh visualMesh;

		public VisualMesh visualMeshBorder;

		public RendererObject GetFreeRenderObject()
		{
			return null;
		}

		public void SetGameObject(GameObject setGameObject)
		{
		}

		public void Draw()
		{
		}

		public void Clear()
		{
		}

		public void GeneratePointMesh(Pair2 pair)
		{
		}

		public void GenerateLinearMesh(Pair2 linearPair)
		{
		}

		public void GenerateComplexMesh(Vector2List points)
		{
		}

		public void GenerateLinearCutMesh(Pair2 linearPair, float cutSize)
		{
		}

		public void GenerateLinearTrackerMesh(Vector2 pos, Dictionary<Slicer2D, SlicerTrackerObject> trackerList)
		{
		}

		public void GenerateComplexCutMesh(List<Vector2D> pointsList, float cutSize)
		{
		}

		public void GenerateCreateMesh(Vector2 pos, Polygon2D.PolygonType polygonType, float polygonSize, Slicer2DCreateControllerObject.CreateType createType, List<Vector2D> pointsList, Pair2D linearPair)
		{
		}

		public void GenerateTrailMesh(Dictionary<Slicer2D, SlicerTrailObject> trailList)
		{
		}

		public void GeneratePolygonMesh(Vector2 pos, Polygon2D.PolygonType polygonType, float polygonSize)
		{
		}

		public void GenerateComplexTrackerMesh(Vector2 pos, Dictionary<Slicer2D, SlicerTrackerObject> trackerList)
		{
		}

		public void Initialize(GameObject gameObject)
		{
		}

		public Material GetBorderMaterial()
		{
			return null;
		}

		public Material GetFillMaterial()
		{
			return null;
		}
	}
}
