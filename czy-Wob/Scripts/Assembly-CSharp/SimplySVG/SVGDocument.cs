using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class SVGDocument
	{
		public SVGElement rootElement;

		public ImportSettings importSettings;

		private Dictionary<string, SVGElement> elementsById;

		public SVGDocument()
		{
			rootElement = new GroupElement();
			rootElement.ownerDocument = this;
			elementsById = new Dictionary<string, SVGElement>();
		}

		public bool AddElementToIdIndex(SVGElement element)
		{
			if (element == null || element.id == null || element.id == "" || element.ownerDocument != this)
			{
				return false;
			}
			if (elementsById.ContainsKey(element.id))
			{
				return false;
			}
			elementsById.Add(element.id, element);
			return true;
		}

		public SVGElement GetElementById(string id)
		{
			if (!elementsById.TryGetValue(id, out var value))
			{
				return null;
			}
			return value;
		}

		public bool Triangulate(ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			importSettings = options;
			return rootElement.Triangulate(new CascadeContext(), options, ref meshVertices, ref meshTriangles, ref meshVertexColors);
		}

		public string GetRootID()
		{
			if (rootElement.children.Count > 0)
			{
				return rootElement.children[0].id;
			}
			return rootElement.id;
		}
	}
}
