using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using ClipperLib;
using Poly2Tri;
using UnityEngine;

namespace SimplySVG
{
	public static class ImportUtilities
	{
		public static char[] wps = new char[4] { ' ', '\t', '\r', '\n' };

		public static Color HexToColor(string hex)
		{
			if (hex.StartsWith("#"))
			{
				hex = hex.Replace("#", "");
			}
			switch (hex)
			{
			case "none":
				return Color.clear;
			case "black":
				hex = "000000";
				break;
			case "gray":
				hex = "808080";
				break;
			case "silver":
				hex = "C0C0C0";
				break;
			case "white":
				hex = "FFFFFF";
				break;
			case "maroon":
				hex = "800000";
				break;
			case "red":
				hex = "FF0000";
				break;
			case "olive":
				hex = "808000";
				break;
			case "yellow":
				hex = "FFFF00";
				break;
			case "green":
				hex = "008000";
				break;
			case "lime":
				hex = "00FF00";
				break;
			case "teal":
				hex = "008080";
				break;
			case "aqua":
				hex = "00FFFF";
				break;
			case "navy":
				hex = "000080";
				break;
			case "blue":
				hex = "0000FF";
				break;
			case "purple":
				hex = "800080";
				break;
			case "fuchsia":
				hex = "FF00FF";
				break;
			}
			if (hex.Length == 3)
			{
				hex = hex[0].ToString() + hex[0] + hex[1] + hex[1] + hex[2] + hex[2];
			}
			if (hex.Length != 6 && hex.Length != 8)
			{
				if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS)
				{
					Debug.LogError("Hex number must be 6 or 8 digit lenght for color. Input was: \"" + hex + "\"");
				}
				return Color.clear;
			}
			byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			if (hex.Length == 8)
			{
				byte a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
				return new Color32(r, g, b, a);
			}
			return new Color32(r, g, b, byte.MaxValue);
		}

		public static bool ParseFloat(string s, out float f)
		{
			Match match = new Regex("[-+]?(\\d*[.])?\\d+").Match(s);
			if (!match.Success)
			{
				f = 0f;
				return false;
			}
			if (!float.TryParse(match.Value, out f))
			{
				return false;
			}
			return true;
		}

		public static bool ParseIdFromURL(string s, out string id)
		{
			string text = "url(#";
			int num = s.IndexOf(text);
			int num2 = num + text.Length;
			int num3 = s.LastIndexOf(")");
			if (num < 0 || num3 < 0 || num3 < num2 || num3 - num2 < 1)
			{
				id = null;
				return false;
			}
			id = s.Substring(num2, num3 - num2);
			return true;
		}

		public static Vector3 ConvertToVector3(IntPoint point, bool useScaling = true)
		{
			return new Vector3(point.X, point.Y, 0f) / (useScaling ? ((float)GraphicalElement.clipperCoordinateScale) : 1f);
		}

		public static Vector3 ConvertToVector3(Point2D point)
		{
			return new Vector3(point.Xf, point.Yf, 0f);
		}

		public static List<Vector3> ConvertToVector3List(IList<IntPoint> points, bool useScaling = true)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (IntPoint point in points)
			{
				list.Add(ConvertToVector3(point, useScaling));
			}
			return list;
		}

		public static List<Vector3> ConvertToVector3List(IList<Point2D> points)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (Point2D point in points)
			{
				list.Add(ConvertToVector3(point));
			}
			return list;
		}

		public static IntPoint ConvertToScaledClipperPoint(Vector2 point)
		{
			return new IntPoint((double)point.x * GraphicalElement.clipperCoordinateScale, (double)point.y * GraphicalElement.clipperCoordinateScale);
		}

		public static PolygonPoint ConvertToTriangulationPoint(IntPoint scaledPoint)
		{
			return new PolygonPoint((double)scaledPoint.X / GraphicalElement.clipperCoordinateScale, (double)scaledPoint.Y / GraphicalElement.clipperCoordinateScale);
		}

		public static void DestroyChildren(Transform parent, bool destroyAssets = false)
		{
			while (parent.childCount != 0)
			{
				Object.Destroy(parent.GetChild(0).gameObject);
			}
		}
	}
}
