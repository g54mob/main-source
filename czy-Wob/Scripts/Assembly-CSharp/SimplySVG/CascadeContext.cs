using ClipperLib;

namespace SimplySVG
{
	public class CascadeContext
	{
		public GraphicalAttributes graphicalAttributes;

		public TransformAttributes transformAttributes;

		public PolyTree clipStencil;

		public CascadeContext()
		{
			graphicalAttributes = GraphicalAttributes.CreateDefault();
			transformAttributes = TransformAttributes.CreateDefault();
		}

		public CascadeContext GatherElement(SVGElement element)
		{
			CascadeContext cascadeContext = new CascadeContext();
			if (element is SVGStylable)
			{
				cascadeContext.graphicalAttributes.Gather(graphicalAttributes);
				cascadeContext.graphicalAttributes.Gather(((SVGStylable)element).GetLocalAttributes());
			}
			if (element is SVGTransformable)
			{
				cascadeContext.transformAttributes.Gather(transformAttributes);
				cascadeContext.transformAttributes.Gather(((SVGTransformable)element).GetLocalTransformation());
			}
			GatherDerivedData(cascadeContext, element);
			return cascadeContext;
		}

		private void GatherDerivedData(CascadeContext combinedContext, SVGElement element)
		{
			GatherClipStencil(combinedContext, element);
		}

		private void GatherClipStencil(CascadeContext combinedContext, SVGElement element)
		{
			if (clipStencil != null)
			{
				combinedContext.clipStencil = clipStencil;
			}
			if (!(element is SVGStylable))
			{
				return;
			}
			GraphicalAttributes localAttributes = ((SVGStylable)element).GetLocalAttributes();
			if (localAttributes.clipPath == null)
			{
				return;
			}
			SVGElement elementById = element.ownerDocument.GetElementById(localAttributes.clipPath);
			if (elementById == null || !(elementById is ClipPathElement))
			{
				return;
			}
			PolyTree stencil = ((ClipPathElement)elementById).GetStencil(combinedContext);
			if (stencil != null)
			{
				if (combinedContext.clipStencil == null)
				{
					combinedContext.clipStencil = stencil;
					return;
				}
				TriangulationUtility.ClipStencil(combinedContext.clipStencil, stencil, out var result);
				combinedContext.clipStencil = result;
			}
		}
	}
}
