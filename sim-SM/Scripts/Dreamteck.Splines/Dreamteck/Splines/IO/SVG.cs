using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

namespace Dreamteck.Splines.IO
{
	public class SVG : SplineParser
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		internal class PathSegment
		{
			internal enum Type
			{
				Cubic = 0,
				CubicShort = 1,
				Quadratic = 2,
				QuadraticShort = 3
			}

			internal Vector3 startTangent;

			internal Vector3 endTangent;

			internal Vector3 endPoint;

			internal PathSegment(Vector2 s, Vector2 e, Vector2 c)
			{
			}

			internal PathSegment()
			{
			}
		}

		public enum Element
		{
			All = 0,
			Path = 1,
			Polygon = 2,
			Ellipse = 3,
			Rectangle = 4,
			Line = 5
		}

		private CultureInfo culture;

		private NumberStyles style;

		private List<SplineDefinition> paths;

		private List<SplineDefinition> polygons;

		private List<SplineDefinition> ellipses;

		private List<SplineDefinition> rectangles;

		private List<SplineDefinition> lines;

		private List<Transformation> transformBuffer;

		public SVG(string filePath)
		{
		}

		public SVG(List<SplineComputer> computers)
		{
		}

		public void Write(string filePath, Axis ax = Axis.Z)
		{
		}

		private Vector2 MapPoint(Vector3 original, Axis ax)
		{
			return default(Vector2);
		}

		private void Read(XmlDocument doc)
		{
		}

		private void Traverse(XmlNodeList nodes)
		{
		}

		public List<SplineComputer> CreateSplineComputers(Vector3 position, Quaternion rotation, Element elements = Element.All)
		{
			return null;
		}

		public List<Spline> CreateSplines(Element elements = Element.All)
		{
			return null;
		}

		private int ReadRectangle(XmlNode rectNode)
		{
			return 0;
		}

		private int ReadLine(XmlNode lineNode)
		{
			return 0;
		}

		private int ReadEllipse(XmlNode ellipseNode)
		{
			return 0;
		}

		private int ReadPolygon(XmlNode polyNode, bool closed)
		{
			return 0;
		}

		private int ParseTransformation(XmlNode node)
		{
			return 0;
		}

		private List<Transformation> ParseTransformations(string transformContent)
		{
			return null;
		}

		private int ReadPath(XmlNode pathNode)
		{
			return 0;
		}

		private void PathStart(string name, string coords, bool relative)
		{
		}

		private void PathClose()
		{
		}

		private void PathLineTo(string coords, bool relative)
		{
		}

		private void PathHorizontalLineTo(string coords, bool relative)
		{
		}

		private void PathVerticalLineTo(string coords, bool relative)
		{
		}

		private void PathCurveTo(string coords, PathSegment.Type type, bool relative)
		{
		}

		private void PathArcTo(string coords, bool relative)
		{
		}

		private void FlipTangents(ref SplinePoint point)
		{
		}

		private void CalculateEllipseParams(Vector2 p0, Vector2 p1, float phi, float rx, float ry, bool fa, bool fs, out Vector2 c, out float theta1, out float sweepTheta, out float adjustedRx, out float adjustedRy)
		{
			c = default(Vector2);
			theta1 = default(float);
			sweepTheta = default(float);
			adjustedRx = default(float);
			adjustedRy = default(float);
		}

		private double[] GetArcSegmentPercentages(double start, double end)
		{
			return null;
		}

		private double[] ReturnPercentage(bool swap, List<double> percentages)
		{
			return null;
		}

		private float VectorAngle(Vector2 u, Vector2 v)
		{
			return 0f;
		}

		private float ModP(float f, float div)
		{
			return 0f;
		}

		private double ModP(double d, double div)
		{
			return 0.0;
		}

		private void WriteBufferTo(List<SplineDefinition> list)
		{
		}

		private PathSegment[] ParsePathSegment(string coord, PathSegment.Type type)
		{
			return null;
		}

		private string EncodePath(SplineDefinition definition, Axis ax)
		{
			return null;
		}

		private string EncodePolygon(SplineDefinition definition, Axis ax)
		{
			return null;
		}

		private string GetAttributeContent(XmlNode node, string attributeName)
		{
			return null;
		}
	}
}
