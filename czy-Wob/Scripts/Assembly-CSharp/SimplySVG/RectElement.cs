using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class RectElement : GraphicalElement
	{
		private float x;

		private float y;

		private float width;

		private float height;

		public override bool AddShapeAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			switch (attributeName)
			{
			case "x":
				flag = float.TryParse(attributeValue, out x);
				break;
			case "y":
				flag = float.TryParse(attributeValue, out y);
				break;
			case "width":
				flag = float.TryParse(attributeValue, out width);
				break;
			case "height":
				flag = float.TryParse(attributeValue, out height);
				break;
			default:
				return false;
			}
			if (!flag)
			{
				throw new Exception("Failed to parse Rect attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		protected override List<ContourPath> BuildShape(ImportSettings options)
		{
			List<ContourPath> list = new List<ContourPath>();
			ContourPath contourPath = new ContourPath(closed: true);
			list.Add(contourPath);
			contourPath.path.Add(new Vector2(x, y));
			contourPath.path.Add(new Vector2(x + width, y));
			contourPath.path.Add(new Vector2(x + width, y + height));
			contourPath.path.Add(new Vector2(x, y + height));
			return list;
		}
	}
}
