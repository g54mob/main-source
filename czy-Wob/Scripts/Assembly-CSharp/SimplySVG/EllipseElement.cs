using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class EllipseElement : GraphicalElement
	{
		private float cx;

		private float cy;

		private float rx;

		private float ry;

		public override bool AddShapeAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			switch (attributeName)
			{
			case "cx":
				flag = float.TryParse(attributeValue, out cx);
				break;
			case "cy":
				flag = float.TryParse(attributeValue, out cy);
				break;
			case "rx":
				flag = float.TryParse(attributeValue, out rx);
				break;
			case "ry":
				flag = float.TryParse(attributeValue, out ry);
				break;
			default:
				return false;
			}
			if (!flag)
			{
				throw new Exception("Failed to parse Ellipse attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		protected override List<ContourPath> BuildShape(ImportSettings options)
		{
			List<ContourPath> list = new List<ContourPath>();
			ContourPath item = new ContourPath(closed: true, MakeEllipsoidContourPoints(options, cx, cy, rx, ry));
			list.Add(item);
			return list;
		}

		public static List<Vector2> MakeEllipsoidContourPoints(ImportSettings options, float cx, float cy, float rx, float ry, float angle = 0f)
		{
			List<Vector2> path = new List<Vector2>();
			PathElement.MakePathPointDelegate makePathPointDelegate = delegate(float t)
			{
				float f = (float)Math.PI * 2f * t + angle;
				return new Vector2(Mathf.Sin(f) * rx + cx, Mathf.Cos(f) * ry + cy);
			};
			Vector2 vector = makePathPointDelegate(0f);
			Vector2 vector2 = makePathPointDelegate(0.5f);
			PathElement.DynamicallySubdivide(options, makePathPointDelegate, 0, 0f, 0.5f, vector, vector2, ref path);
			path.Add(vector2);
			PathElement.DynamicallySubdivide(options, makePathPointDelegate, 0, 0.5f, 1f, vector2, vector, ref path);
			path.Add(vector);
			return path;
		}
	}
}
