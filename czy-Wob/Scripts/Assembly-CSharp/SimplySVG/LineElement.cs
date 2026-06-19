using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class LineElement : GraphicalElement
	{
		private float x1;

		private float y1;

		private float x2;

		private float y2;

		public override bool AddShapeAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			switch (attributeName)
			{
			case "x1":
				flag = float.TryParse(attributeValue, out x1);
				break;
			case "y1":
				flag = float.TryParse(attributeValue, out y1);
				break;
			case "x2":
				flag = float.TryParse(attributeValue, out x2);
				break;
			case "y2":
				flag = float.TryParse(attributeValue, out y2);
				break;
			default:
				return false;
			}
			if (!flag)
			{
				throw new Exception("Failed to parse Line attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		protected override List<ContourPath> BuildShape(ImportSettings options)
		{
			return new List<ContourPath>
			{
				new ContourPath
				{
					path = 
					{
						new Vector2(x1, y1),
						new Vector2(x2, y2)
					}
				}
			};
		}
	}
}
