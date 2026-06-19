using System;
using System.Collections.Generic;

namespace SimplySVG
{
	public class CircleElement : GraphicalElement
	{
		private float cx;

		private float cy;

		private float r;

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
			case "r":
				flag = float.TryParse(attributeValue, out r);
				break;
			default:
				return false;
			}
			if (!flag)
			{
				throw new Exception("Failed to parse Circle attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		protected override List<ContourPath> BuildShape(ImportSettings options)
		{
			List<ContourPath> list = new List<ContourPath>();
			ContourPath item = new ContourPath(closed: true, EllipseElement.MakeEllipsoidContourPoints(options, cx, cy, r, r));
			list.Add(item);
			return list;
		}
	}
}
