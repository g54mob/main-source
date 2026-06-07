using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[ExecuteInEditMode]
	public class Slicer2D : MonoBehaviour
	{
		public enum ShapeType
		{
			Collider = 0,
			SpriteCustomShape = 1
		}

		public enum SliceType
		{
			Regular = 0,
			SliceHole = 1,
			FillSlicedHole = 2
		}

		public enum TextureType
		{
			Sprite = 0,
			Sprite3D = 1,
			Mesh2D = 2,
			Mesh3D = 3,
			SpriteAnimation = 4,
			ImageUI = 5,
			None = 6
		}

		public enum CenterOfSliceTransform
		{
			Origin = 0,
			ColliderCenter = 1
		}

		public enum AnchorType
		{
			AttachRigidbody = 0,
			RemoveConstraints = 1,
			CancelSlice = 2,
			Nothing = 3
		}

		public enum ColliderType
		{
			PolygonCollider2D = 0,
			EdgeCollider2D = 1
		}

		public enum InstantiationMethod
		{
			Quality = 0,
			Performance = 1
		}

		public class API
		{
			public static Slice2D LinearSlice(Polygon2D polygon, Pair2D slice)
			{
				return null;
			}

			public static Slice2D LinearCutSlice(Polygon2D polygon, LinearCut linearCut)
			{
				return null;
			}

			public static Slice2D ComplexSlice(Polygon2D polygon, List<Vector2D> slice)
			{
				return null;
			}

			public static Slice2D ComplexCutSlice(Polygon2D polygon, ComplexCut complexCut)
			{
				return null;
			}

			public static Slice2D PointSlice(Polygon2D polygon, Vector2D point, float rotation)
			{
				return null;
			}

			public static Slice2D PolygonSlice(Polygon2D polygon, Polygon2D polygonB)
			{
				return null;
			}

			public static Slice2D ExplodeByPoint(Polygon2D polygon, Vector2D point, int explosionSlices = 0)
			{
				return null;
			}

			public static Slice2D ExplodeInPoint(Polygon2D polygon, Vector2D point, int explosionSlices = 0)
			{
				return null;
			}

			public static Slice2D Explode(Polygon2D polygon, int explosionSlices = 0)
			{
				return null;
			}

			public static Polygon2D CreatorSlice(List<Vector2D> slice)
			{
				return null;
			}

			public static Merge2D ComplexMerge(Polygon2D polygon, List<Vector2D> slice)
			{
				return null;
			}

			public static Merge2D PolygonMerge(Polygon2D polygon, Polygon2D mergePolygon)
			{
				return null;
			}
		}

		public class Debug
		{
			public static bool enabled;
		}

		public static SliceType complexSliceType;

		public TextureType textureType;

		public Slicing2DLayer slicingLayer;

		public ColliderType colliderType;

		public MaterialSettings materialSettings;

		public ShapeType shapeType;

		public Slicer2DLimit limit;

		public Slicer2DEventHandling eventHandler;

		public InstantiationMethod instantiateMethod;

		public CenterOfSliceTransform centerOfSlice;

		public bool recalculateMass;

		public VirtualSpriteRenderer spriteRenderer;

		public bool supportJoints;

		private Rigidbody2D body;

		private List<Joint2D> joints;

		private static List<Slicer2D> slicer2DList;

		private static List<Slicer2D> getLayerList;

		public Slicer2DShape shape;

		protected MeshFilter meshFilter;

		protected MeshRenderer meshRenderer;

		protected SpriteRenderer spriteRendererComponent;

		public Slicer2DAnchor anchor;

		private bool reinitialize;

		public bool afterSliceRemoveOrigin;

		public void OnDestroy()
		{
		}

		private Polygon2D GetPolygonToSlice()
		{
			return null;
		}

		public Rigidbody2D GetRigibody()
		{
			return null;
		}

		public void AddAnchorEvent(Slicer2DEventHandling.Slice2DEvent slicerEvent)
		{
		}

		public void AddAnchorResultEvent(Slicer2DEventHandling.Slice2DResultEvent slicerEvent)
		{
		}

		public void AddEvent(Slicer2DEventHandling.Slice2DEvent slicerEvent)
		{
		}

		public void AddResultEvent(Slicer2DEventHandling.Slice2DResultEvent slicerEvent)
		{
		}

		public static void AddGlobalAnchorEvent(Slicer2DEventHandling.Slice2DEvent slicerEvent)
		{
		}

		public static void AddGlobalResultAnchorEvent(Slicer2DEventHandling.Slice2DResultEvent slicerEvent)
		{
		}

		public static void AddGlobalEvent(Slicer2DEventHandling.Slice2DEvent slicerEvent)
		{
		}

		public static void AddGlobalResultEvent(Slicer2DEventHandling.Slice2DResultEvent slicerEvent)
		{
		}

		public static int GetListCount()
		{
			return 0;
		}

		public static List<Slicer2D> GetList()
		{
			return null;
		}

		public static List<Slicer2D> GetListCopy()
		{
			return null;
		}

		public static List<Slicer2D> GetListLayer(Slice2DLayer layer)
		{
			return null;
		}

		public int GetLayerID()
		{
			return 0;
		}

		public bool MatchLayers(Slice2DLayer sliceLayer)
		{
			return false;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Initialize()
		{
		}

		public virtual List<GameObject> PerformResult(List<Polygon2D> result, Slice2D slice)
		{
			return null;
		}

		public Merge2D PolygonMerge(Polygon2D slice, bool perform = true)
		{
			return null;
		}

		public Merge2D ComplexMerge(List<Vector2D> slice, bool perform = true)
		{
			return null;
		}

		public static List<Merge2D> ComplexMergeAll(List<Vector2D> slice, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Merge2D> PolygonMergeAll(Polygon2D slicePolygon, Slice2DLayer layer = null)
		{
			return null;
		}

		public void PerformMergeResult(List<Polygon2D> polygons, Merge2D mergeResult)
		{
		}

		public Slice2D LinearSlice(Pair2D slice, bool perform = true)
		{
			return null;
		}

		public Slice2D LinearCutSlice(LinearCut slice)
		{
			return null;
		}

		public Slice2D ComplexSlice(List<Vector2D> slice)
		{
			return null;
		}

		public Slice2D ComplexCutSlice(ComplexCut slice)
		{
			return null;
		}

		public Slice2D PointSlice(Vector2D point, float rotation)
		{
			return null;
		}

		public Slice2D PolygonSlice(Polygon2D slice, Polygon2D slicePolygonDestroy)
		{
			return null;
		}

		public Slice2D ExplodeByPoint(Vector2D point, int explosionSlices = 0)
		{
			return null;
		}

		public Slice2D ExplodeInPoint(Vector2D point, int explosionSlices = 0)
		{
			return null;
		}

		public Slice2D Explode(int explosionSlices = 0)
		{
			return null;
		}

		public static List<Slice2D> LinearSliceAll(Pair2D slice, Slice2DLayer layer = null, bool perform = true)
		{
			return null;
		}

		public static List<Slice2D> LinearCutSliceAll(LinearCut linearCut, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> ComplexSliceAll(List<Vector2D> slice, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> ComplexCutSliceAll(ComplexCut complexCut, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> PointSliceAll(Vector2D slice, float rotation, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> PolygonSliceAll(Vector2D position, Polygon2D slicePolygon, bool destroy, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> ExplodeByPointAll(Vector2D point, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> ExplodeInPointAll(Vector2D point, Slice2DLayer layer = null)
		{
			return null;
		}

		public static List<Slice2D> ExplodeAll(Slice2DLayer layer = null, int explosionSlices = 0)
		{
			return null;
		}

		public void RecalculateJoints()
		{
		}

		protected void SliceJointEvent(Slice2D sliceResult)
		{
		}

		private void StartAnchor()
		{
		}

		private bool OnAnchorSlice(Slice2D sliceResult)
		{
			return false;
		}

		private void OnAnchorSliceResult(Slice2D sliceResult)
		{
		}

		public static Slicer2D PointInSlicerComponent(Vector2D point)
		{
			return null;
		}
	}
}
