using System.Collections.Generic;
using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class SVGAttribParser
	{
		private enum AttribPath
		{
			Path = 0
		}

		private enum AttribTransform
		{
			Transform = 0
		}

		private enum AttribStroke
		{
			Stroke = 0
		}

		private LinkedList<BezierSegment> currentContour;

		private List<BezierContour> contours;

		private Vector2 penPos;

		private string attribString;

		private char pathCommand;

		private Matrix2D transform;

		private IFill fill;

		private string attribName;

		private int stringPos;

		private static NamedWebColorDictionary namedColors;

		public static List<BezierContour> ParsePath(XmlReaderIterator.Node node)
		{
			return null;
		}

		public static Matrix2D ParseTransform(XmlReaderIterator.Node node)
		{
			return default(Matrix2D);
		}

		public static Matrix2D ParseTransform(XmlReaderIterator.Node node, string attribName)
		{
			return default(Matrix2D);
		}

		public static IFill ParseFill(XmlReaderIterator.Node node, SVGDictionary dict, SVGPostponedFills postponedFills, SVGStyleResolver styles, Inheritance inheritance = Inheritance.Inherited)
		{
			return null;
		}

		public static IFill ParseFill(XmlReaderIterator.Node node, SVGDictionary dict, SVGPostponedFills postponedFills, SVGStyleResolver styles, Inheritance inheritance, out bool isDefaultFill)
		{
			isDefaultFill = default(bool);
			return null;
		}

		public static Stroke ParseStrokeAndOpacity(XmlReaderIterator.Node node, SVGDictionary dict, SVGStyleResolver styles, Inheritance inheritance = Inheritance.Inherited)
		{
			return null;
		}

		public static Color ParseColor(string colorString)
		{
			return default(Color);
		}

		public static string ParseURLRef(string url)
		{
			return null;
		}

		public static object ParseRelativeRef(string iri, SVGDictionary dict)
		{
			return null;
		}

		public static string CleanIri(string iri)
		{
			return null;
		}

		private SVGAttribParser(string attrib, AttribPath attribPath)
		{
		}

		private SVGAttribParser(string attrib, string attribNameVal, AttribTransform attribTransform)
		{
		}

		private SVGAttribParser(string attrib, string attribName, float opacity, FillMode mode, SVGDictionary dict, SVGPostponedFills postponedFills, bool allowReference = true)
		{
		}

		private void ConcludePath(bool joinEnds)
		{
		}

		private Vector2 NextVector2(bool relative = false)
		{
			return default(Vector2);
		}

		private float NextFloat()
		{
			return 0f;
		}

		internal static float ParseFloat(string s)
		{
			return 0f;
		}

		private bool NextBool()
		{
			return false;
		}

		private char NextPathCommand(bool noCommandInheritance = false)
		{
			return '\0';
		}

		private string NextStringCommand()
		{
			return null;
		}

		private void SkipSymbol(char s)
		{
		}

		private bool PeekSymbol(char s)
		{
			return false;
		}

		private void SkipWhitespaces()
		{
		}
	}
}
