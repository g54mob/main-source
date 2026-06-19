using System;
using System.Collections.Generic;
using ClipperLib;
using UnityEngine;

namespace SimplySVG
{
	public class ClipPathElement : SVGElement, SVGStylable, SVGTransformable
	{
		private delegate void RecurseSVGElements(SVGElement node, CascadeContext parentCascadeContext);

		private GraphicalAttributes localGraphicalAttributes;

		private TransformAttributes localTransformAttributes;

		protected PolyTree stencil;

		public ClipPathElement()
		{
			localGraphicalAttributes = new GraphicalAttributes();
			localTransformAttributes = new TransformAttributes();
		}

		public PolyTree GetStencil(CascadeContext userCascadeContext)
		{
			Clipper stencilClipper = new Clipper();
			stencilClipper.StrictlySimple = true;
			RecurseSVGElements recurse = null;
			recurse = delegate(SVGElement node, CascadeContext parentCascadeContext)
			{
				CascadeContext cascadeContext = parentCascadeContext.GatherElement(node);
				if (node is GraphicalElement)
				{
					GraphicalElement graphicalElement = (GraphicalElement)node;
					if (!graphicalElement.BuildStencil(cascadeContext, ownerDocument.importSettings))
					{
						throw new Exception("Building shape stencil failed");
					}
					if (graphicalElement.stencilTree != null)
					{
						stencilClipper.AddPaths(Clipper.PolyTreeToPaths(graphicalElement.stencilTree), PolyType.ptSubject, closed: true);
					}
				}
				if (node is UseElement)
				{
					UseElement useElement = (UseElement)node;
					recurse(useElement.surrogateForElement, cascadeContext);
				}
				else
				{
					for (int i = 0; i < node.children.Count; i++)
					{
						recurse(node.children[i], cascadeContext);
					}
				}
			};
			recurse(this, userCascadeContext);
			stencil = new PolyTree();
			if (!stencilClipper.Execute(ClipType.ctUnion, stencil))
			{
				stencil = null;
			}
			return stencil;
		}

		public override bool Triangulate(CascadeContext parentCascadeContext, ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			return true;
		}

		public override bool AddAttribute(string attributeName, string attributeValue)
		{
			if (!base.AddAttribute(attributeName, attributeValue) && !AddStyleAttribute(attributeName, attributeValue))
			{
				return AddTransformAttribute(attributeName, attributeValue);
			}
			return true;
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
	}
}
