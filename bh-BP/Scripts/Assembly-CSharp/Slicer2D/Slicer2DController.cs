using UnityEngine;

namespace Slicer2D
{
	public class Slicer2DController : MonoBehaviour
	{
		public enum SliceType
		{
			Linear = 0,
			LinearCut = 1,
			LinearTracked = 2,
			LinearTrail = 3,
			Complex = 4,
			ComplexCut = 5,
			ComplexClick = 6,
			ComplexTracked = 7,
			ComplexTrail = 8,
			Point = 9,
			Polygon = 10,
			Explode = 11,
			Create = 12,
			MergerComplex = 13,
			MergerPolygon = 14
		}

		public static Color[] slicerColors;

		public SliceType sliceType;

		private static Slicer2DController instance;

		public Slice2DLayer sliceLayer;

		public Slicer2DVisuals visuals;

		public Slicer2DInputController input;

		public Slicer2DControllerEventHandling eventHandler;

		public Slicer2DLinearControllerObject linearControllerObject;

		public Slicer2DComplexControllerObject complexControllerObject;

		public Slicer2DLinearCutControllerObject linearCutControlelrObject;

		public Slicer2DComplexCutControllerObject complexCutControllerObject;

		public Slicer2DLinearTrackerControllerObject linearTrackedControlelrObject;

		public Slicer2DComplexTrackerControllerObject complexTrackedControllerObject;

		public Slicer2DLinearTrailControllerObject linearTrailControllerObject;

		public Slicer2DComplexTrailControllerObject complexTrailControllerObject;

		public Slicer2DPolygonControllerObject polygonControllerObject;

		public Slicer2DCreateControllerObject createControllerObject;

		public Slicer2DComplexClickControllerObject complexClickControllerObject;

		public Slicer2DPointControllerObject pointControllerObject;

		public Slicer2DExplodeControllerObject explodeControllerObject;

		public Merger2DComplexControllerObject mergerComplexControllerObject;

		public Merger2DPolygonControllerObject mergerPolygonControllerObject;

		public bool UIBlocking;

		public void AddResultEvent(Slicer2DControllerEventHandling.ResultEvent e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public bool BlockedByUI()
		{
			return false;
		}

		public void LateUpdate()
		{
		}

		public void Draw()
		{
		}

		public void SetSliceType(int type)
		{
		}

		public void SetLayerType(int type)
		{
		}

		public void SetSlicerColor(int colorInt)
		{
		}

		public static Slicer2DController Get()
		{
			return null;
		}
	}
}
