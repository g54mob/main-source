using System;
using System.Collections.Generic;

namespace SimplySVG
{
	public class DocumentParser
	{
		private SVGDocument currentDocument;

		private Stack<SVGElement> buildStack;

		public SVGDocument BeginDocument()
		{
			currentDocument = new SVGDocument();
			buildStack = new Stack<SVGElement>();
			buildStack.Push(currentDocument.rootElement);
			return currentDocument;
		}

		public void EndDocument()
		{
		}

		public bool BeginElement(string type)
		{
			CheckStack();
			SVGElement sVGElement;
			switch (type)
			{
			case "g":
				sVGElement = new GroupElement();
				break;
			case "path":
				sVGElement = new PathElement();
				break;
			case "polygon":
				sVGElement = new PolygonElement();
				break;
			case "polyline":
				sVGElement = new PolylineElement();
				break;
			case "line":
				sVGElement = new LineElement();
				break;
			case "ellipse":
				sVGElement = new EllipseElement();
				break;
			case "circle":
				sVGElement = new CircleElement();
				break;
			case "rect":
				sVGElement = new RectElement();
				break;
			case "defs":
				sVGElement = new DefsElement();
				break;
			case "use":
				sVGElement = new UseElement();
				break;
			case "clipPath":
				sVGElement = new ClipPathElement();
				break;
			default:
				buildStack.Push(null);
				return false;
			}
			if (buildStack.Peek() == null)
			{
				buildStack.Push(null);
				return true;
			}
			buildStack.Peek().AddChild(sVGElement);
			buildStack.Push(sVGElement);
			return true;
		}

		public void EndElement()
		{
			buildStack.Pop();
		}

		public bool AddAttribute(string attrName, string attrValue)
		{
			CheckStack();
			return buildStack.Peek()?.AddAttribute(attrName, attrValue) ?? true;
		}

		private void CheckStack()
		{
			if (buildStack == null)
			{
				throw new Exception("Build stack is not initalized. Document may be malformed.");
			}
			if (buildStack.Count < 1)
			{
				throw new Exception("Build stack is empty. Document may be malformed.");
			}
		}
	}
}
