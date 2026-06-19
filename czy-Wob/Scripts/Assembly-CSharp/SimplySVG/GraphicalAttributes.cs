using System;
using ClipperLib;
using UnityEngine;

namespace SimplySVG
{
	[Serializable]
	public class GraphicalAttributes
	{
		public float? opacity;

		public bool? useFill;

		public Color? fillColor;

		public float? fillOpacity;

		public bool? useStroke;

		public float? strokeWidth;

		public Color? strokeColor;

		public float? strokeOpacity;

		public float? strokeMiterLimit;

		public PolyFillType? fillRule;

		public string clipPath;

		public PolyFillType? clipRule;

		public void Gather(GraphicalAttributes other)
		{
			if (other.opacity.HasValue)
			{
				opacity *= other.opacity;
			}
			if (other.useFill.HasValue)
			{
				useFill = other.useFill;
			}
			if (other.fillColor.HasValue)
			{
				fillColor = other.fillColor;
			}
			if (other.fillOpacity.HasValue)
			{
				fillOpacity *= other.fillOpacity;
			}
			if (other.strokeWidth.HasValue)
			{
				strokeWidth = other.strokeWidth;
			}
			if (other.useStroke.HasValue)
			{
				useStroke = other.useStroke;
			}
			if (other.strokeColor.HasValue)
			{
				strokeColor = other.strokeColor;
			}
			if (other.strokeOpacity.HasValue)
			{
				strokeOpacity *= other.strokeOpacity;
			}
			if (other.strokeMiterLimit.HasValue)
			{
				strokeMiterLimit = other.strokeMiterLimit;
			}
			if (other.fillRule.HasValue)
			{
				fillRule = other.fillRule;
			}
			if (other.clipPath != null)
			{
				clipPath = other.clipPath;
			}
			if (other.clipRule.HasValue)
			{
				clipRule = other.clipRule;
			}
		}

		public bool AddAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			switch (attributeName)
			{
			case "opacity":
			{
				flag = float.TryParse(attributeValue, out var result3);
				if (flag)
				{
					opacity = result3;
				}
				break;
			}
			case "fill":
			{
				if (attributeValue == "none")
				{
					useFill = false;
					break;
				}
				Color? color2 = null;
				try
				{
					color2 = ImportUtilities.HexToColor(attributeValue);
				}
				catch (Exception)
				{
					flag = false;
				}
				if (flag)
				{
					fillColor = color2;
					useFill = true;
				}
				break;
			}
			case "fill-opacity":
			{
				flag = float.TryParse(attributeValue, out var result5);
				if (flag)
				{
					fillOpacity = result5;
				}
				break;
			}
			case "stroke-width":
			{
				if (attributeValue.Length > 2 && attributeValue.Substring(attributeValue.Length - 2, 2) == "px")
				{
					attributeValue = attributeValue.Substring(0, attributeValue.Length - 2);
				}
				flag = float.TryParse(attributeValue, out var result4);
				if (flag && result4 > 0f)
				{
					strokeWidth = result4;
				}
				break;
			}
			case "stroke":
			{
				if (attributeValue == "none")
				{
					useStroke = false;
					break;
				}
				Color? color = null;
				try
				{
					color = ImportUtilities.HexToColor(attributeValue);
				}
				catch (Exception)
				{
					flag = false;
				}
				if (flag)
				{
					strokeColor = color;
					useStroke = true;
				}
				break;
			}
			case "stroke-opacity":
			{
				flag = float.TryParse(attributeValue, out var result2);
				if (flag)
				{
					strokeOpacity = result2;
				}
				break;
			}
			case "stroke-miterlimit":
			{
				flag = float.TryParse(attributeValue, out var result);
				if (flag)
				{
					strokeMiterLimit = result;
				}
				break;
			}
			case "fill-rule":
				if (attributeValue == "nonzero")
				{
					fillRule = PolyFillType.pftNonZero;
				}
				else if (attributeValue == "evenodd")
				{
					fillRule = PolyFillType.pftEvenOdd;
				}
				else
				{
					flag = false;
				}
				break;
			case "clip-path":
			{
				if (!ImportUtilities.ParseIdFromURL(attributeValue, out var id))
				{
					flag = false;
				}
				if (flag)
				{
					clipPath = id;
				}
				break;
			}
			case "clip-rule":
				if (attributeValue == "nonzero")
				{
					clipRule = PolyFillType.pftNonZero;
				}
				else if (attributeValue == "evenodd")
				{
					clipRule = PolyFillType.pftEvenOdd;
				}
				else
				{
					flag = false;
				}
				break;
			case "style":
			{
				bool flag2 = true;
				char[] separator = new char[1] { ';' };
				string[] array = attributeValue.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					char[] separator2 = new char[1] { ':' };
					string[] array2 = array[i].Split(separator2, StringSplitOptions.None);
					flag2 &= AddAttribute(array2[0], array2[1]);
				}
				if (!flag2)
				{
					return false;
				}
				break;
			}
			default:
				return false;
			}
			if (!flag)
			{
				throw new Exception("Failed to parse Presentation Attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		public static GraphicalAttributes CreateDefault()
		{
			return new GraphicalAttributes
			{
				opacity = 1f,
				useFill = true,
				fillColor = Color.black,
				fillOpacity = 1f,
				useStroke = false,
				strokeWidth = 1f,
				strokeColor = Color.black,
				strokeOpacity = 1f,
				strokeMiterLimit = 4f,
				fillRule = PolyFillType.pftNonZero,
				clipPath = null,
				clipRule = PolyFillType.pftNonZero
			};
		}
	}
}
