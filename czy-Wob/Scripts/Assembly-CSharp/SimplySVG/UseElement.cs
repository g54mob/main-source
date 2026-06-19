using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class UseElement : SVGElement, SVGStylable, SVGTransformable
	{
		protected GraphicalAttributes localGraphicalAttributes;

		protected TransformAttributes localTransformAttributes;

		public SVGElement surrogateForElement;

		public UseElement()
		{
			localGraphicalAttributes = new GraphicalAttributes();
			localTransformAttributes = new TransformAttributes();
		}

		public override bool AddAttribute(string attributeName, string attributeValue)
		{
			if (!base.AddAttribute(attributeName, attributeValue) && !AddUseAttribute(attributeName, attributeValue) && !AddStyleAttribute(attributeName, attributeValue))
			{
				return AddTransformAttribute(attributeName, attributeValue);
			}
			return true;
		}

		public bool AddUseAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			if (attributeName == "xlink:href")
			{
				int num = attributeValue.IndexOf("#") + 1;
				flag = num >= 0;
				if (flag)
				{
					string text = attributeValue.Substring(num);
					SVGElement elementById = ownerDocument.GetElementById(text);
					flag = elementById != null;
					if (flag)
					{
						surrogateForElement = elementById;
					}
				}
				if (!flag)
				{
					throw new Exception("Failed to process Use attribute " + attributeName + " with value " + attributeValue);
				}
				return true;
			}
			return false;
		}

		public bool AddStyleAttribute(string attributeName, string attributeValue)
		{
			return localGraphicalAttributes.AddAttribute(attributeName, attributeValue);
		}

		public bool AddTransformAttribute(string attributeName, string attributeValue)
		{
			return localTransformAttributes.AddAttribute(attributeName, attributeValue);
		}

		public GraphicalAttributes GetLocalAttributes()
		{
			return localGraphicalAttributes;
		}

		public TransformAttributes GetLocalTransformation()
		{
			return localTransformAttributes;
		}

		public override bool Triangulate(CascadeContext parentCascadeContext, ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			CascadeContext parentCascadeContext2 = parentCascadeContext.GatherElement(this);
			return surrogateForElement.Triangulate(parentCascadeContext2, options, ref meshVertices, ref meshTriangles, ref meshVertexColors);
		}
	}
}
