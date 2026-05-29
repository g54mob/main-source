using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[ExecuteAlways]
	[HelpURL("https://curvyeditor.com/doclink/curvyshape")]
	[RequireComponent(typeof(CurvySpline))]
	public class CurvyShape : DTVersionedMonoBehaviour
	{
		[SerializeField]
		[Label("Plane", null)]
		private CurvyPlane m_Plane;

		private static Dictionary<CurvyShapeInfo, Type> mShapeDefs;

		private CurvySpline mSpline;

		[NonSerialized]
		public bool Dirty;

		public CurvyPlane Plane
		{
			get
			{
				return default(CurvyPlane);
			}
			set
			{
			}
		}

		public CurvySpline Spline => null;

		[Obsolete("Method will be removed in the next major release. If you need it, please copy its implementation")]
		[UsedImplicitly]
		public static Dictionary<CurvyShapeInfo, Type> ShapeDefinitions => null;

		[UsedImplicitly]
		private void Update()
		{
		}

		protected override void OnValidate()
		{
		}

		protected override void Reset()
		{
		}

		public void Delete()
		{
		}

		public void Refresh()
		{
		}

		[Obsolete("This method will become an Editor only method")]
		[UsedImplicitly]
		public CurvyShape Replace(string menuName)
		{
			return null;
		}

		protected void PrepareSpline(CurvyInterpolation interpolation, CurvyOrientation orientation = CurvyOrientation.Dynamic, int cachedensity = 50, bool closed = true)
		{
		}

		protected void SetPosition(int no, Vector3 position)
		{
		}

		protected void SetRotation(int no, Quaternion rotation)
		{
		}

		protected void SetBezierHandles(int no, float distanceFrag)
		{
		}

		protected void SetBezierHandles(int no, float inDistanceFrag, float outDistanceFrag)
		{
		}

		protected void SetBezierHandles(int no, Vector3 i, Vector3 o, Space space = Space.World)
		{
		}

		public static void SetBezierHandles(float distanceFrag, bool setIn, bool setOut, params CurvySplineSegment[] controlPoints)
		{
		}

		protected void SetCGHardEdges(params int[] controlPoints)
		{
		}

		protected virtual void ApplyShape()
		{
		}

		protected void PrepareControlPoints(int count)
		{
		}

		[Obsolete("Method will be removed in the next major release. If you need it, please copy its implementation")]
		[UsedImplicitly]
		public static List<string> GetShapesMenuNames(bool only2D = false)
		{
			return null;
		}

		[UsedImplicitly]
		[Obsolete("This method will become an Editor only method")]
		public static List<string> GetShapesMenuNames(Type currentShapeType, out int currentIndex, bool only2D = false)
		{
			currentIndex = default(int);
			return null;
		}

		[UsedImplicitly]
		[Obsolete("Method will be removed in the next major release. If you need it, please copy its implementation")]
		public static string GetShapeName(Type shapeType)
		{
			return null;
		}

		[UsedImplicitly]
		[Obsolete("This method will become an Editor only method")]
		public static Type GetShapeType(string menuName)
		{
			return null;
		}

		private void ApplyPlane()
		{
		}

		private void applyRotation(Quaternion q)
		{
		}
	}
}
