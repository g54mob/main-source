using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Dreamteck.Splines.IO
{
	public class SplineParser
	{
		internal class Transformation
		{
			protected static Matrix4x4 matrix;

			internal static void ResetMatrix()
			{
			}

			internal virtual void Push()
			{
			}

			internal static void Apply(SplinePoint[] points)
			{
			}
		}

		internal class Translate : Transformation
		{
			private Vector2 offset;

			public Translate(Vector2 o)
			{
			}

			internal override void Push()
			{
			}
		}

		internal class Rotate : Transformation
		{
			private float angle;

			public Rotate(float a)
			{
			}

			internal override void Push()
			{
			}
		}

		internal class Scale : Transformation
		{
			private Vector2 multiplier;

			public Scale(Vector2 s)
			{
			}

			internal override void Push()
			{
			}
		}

		internal class SkewX : Transformation
		{
			private float amount;

			public SkewX(float a)
			{
			}

			internal override void Push()
			{
			}
		}

		internal class SkewY : Transformation
		{
			private float amount;

			public SkewY(float a)
			{
			}

			internal override void Push()
			{
			}
		}

		internal class MatrixTransform : Transformation
		{
			private Matrix4x4 transformMatrix;

			public MatrixTransform(float a, float b, float c, float d, float e, float f)
			{
			}

			internal override void Push()
			{
			}
		}

		internal class SplineDefinition
		{
			internal string name;

			internal Spline.Type type;

			internal List<SplinePoint> points;

			internal bool closed;

			internal Vector3 position;

			internal Vector3 tangent;

			internal Vector3 tangent2;

			internal Vector3 normal;

			internal float size;

			internal Color color;

			internal int pointCount => 0;

			internal SplineDefinition(string n, Spline.Type t)
			{
			}

			internal SplineDefinition(string n, Spline spline)
			{
			}

			internal SplinePoint GetLastPoint()
			{
				return default(SplinePoint);
			}

			internal void SetLastPoint(SplinePoint point)
			{
			}

			internal void CreateClosingPoint()
			{
			}

			internal void CreateSmooth()
			{
			}

			internal void CreateBroken()
			{
			}

			internal void CreateLinear()
			{
			}

			internal SplineComputer CreateSplineComputer(Vector3 position, Quaternion rotation)
			{
				return null;
			}

			internal Spline CreateSpline()
			{
				return null;
			}

			internal void Transform(List<Transformation> trs)
			{
			}
		}

		protected string fileName;

		private CultureInfo culture;

		private NumberStyles style;

		internal SplineDefinition buffer;

		public string name => null;

		internal Vector2[] ParseVector2(string coord)
		{
			return null;
		}

		internal float[] ParseFloat(string coord)
		{
			return null;
		}

		internal List<float> ParseFloatArray(string content)
		{
			return null;
		}

		public bool IsWHiteSpace(string s)
		{
			return false;
		}
	}
}
