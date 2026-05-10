using System;
using System.Xml;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class SVGFormatException : Exception
	{
		public static SVGFormatException StackError => null;

		public SVGFormatException()
		{
		}

		public SVGFormatException(string message)
		{
		}

		public SVGFormatException(XmlReader reader, string message)
		{
		}

		private static string ComposeMessage(XmlReader reader, string message)
		{
			return null;
		}
	}
}
