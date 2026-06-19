using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class PolylineElement : GraphicalElement
	{
		private List<Vector2> points;

		public PolylineElement()
		{
			points = new List<Vector2>();
		}

		public override bool AddShapeAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			if (!(attributeName == "points"))
			{
				return false;
			}
			if (!ParsePoints(attributeValue))
			{
				throw new Exception("Failed to parse Polyline attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		protected override List<ContourPath> BuildShape(ImportSettings options)
		{
			return new List<ContourPath>
			{
				new ContourPath(closed: false, points.GetRange(0, points.Count))
			};
		}

		private bool ParsePoints(string data)
		{
			data = data.Replace("-", ",-");
			List<char> list = new List<char>(ImportUtilities.wps);
			list.Add(',');
			string[] array = data.Split(list.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i += 2)
			{
				Vector2 item = new Vector2(float.Parse(array[i]), float.Parse(array[i + 1]));
				points.Add(item);
			}
			return true;
		}
	}
}
