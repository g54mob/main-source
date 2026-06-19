using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	[Serializable]
	public abstract class SVGElement : Triangulatable
	{
		public string id;

		public SVGDocument ownerDocument;

		public SVGElement parent;

		public List<SVGElement> children;

		public SVGElement()
		{
			children = new List<SVGElement>();
		}

		public virtual bool AddAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			if (attributeName == "id")
			{
				id = attributeValue;
				if (!ownerDocument.AddElementToIdIndex(this))
				{
					throw new Exception("Failed to parse Core attribute " + attributeName + " with value " + attributeValue);
				}
				return true;
			}
			return false;
		}

		public void AddChild(SVGElement element)
		{
			element.ownerDocument = ownerDocument;
			element.parent = this;
			children.Add(element);
		}

		public virtual bool Triangulate(CascadeContext parentCascadeContext, ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			CascadeContext parentCascadeContext2 = parentCascadeContext.GatherElement(this);
			for (int i = 0; i < children.Count; i++)
			{
				children[i].Triangulate(parentCascadeContext2, options, ref meshVertices, ref meshTriangles, ref meshVertexColors);
			}
			return true;
		}
	}
}
