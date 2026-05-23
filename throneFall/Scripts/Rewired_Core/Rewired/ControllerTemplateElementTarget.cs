using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement wuloCyTIFfCSteczABMqkgnSKHYK;

		private AxisRange ahZdAXhwDqhgOgCrisWLtObhWKYTA;

		public AxisRange axisRange
		{
			get
			{
				return ahZdAXhwDqhgOgCrisWLtObhWKYTA;
			}
			set
			{
				ahZdAXhwDqhgOgCrisWLtObhWKYTA = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (wuloCyTIFfCSteczABMqkgnSKHYK == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return wuloCyTIFfCSteczABMqkgnSKHYK.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (wuloCyTIFfCSteczABMqkgnSKHYK == null)
				{
					return string.Empty;
				}
				return wuloCyTIFfCSteczABMqkgnSKHYK.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)wuloCyTIFfCSteczABMqkgnSKHYK).GetDescriptiveName(ahZdAXhwDqhgOgCrisWLtObhWKYTA), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)wuloCyTIFfCSteczABMqkgnSKHYK).descriptiveName, 
					_ => wuloCyTIFfCSteczABMqkgnSKHYK.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return wuloCyTIFfCSteczABMqkgnSKHYK;
			}
			set
			{
				wuloCyTIFfCSteczABMqkgnSKHYK = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (wuloCyTIFfCSteczABMqkgnSKHYK == null)
				{
					return null;
				}
				return (wuloCyTIFfCSteczABMqkgnSKHYK as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => wuloCyTIFfCSteczABMqkgnSKHYK != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			wuloCyTIFfCSteczABMqkgnSKHYK = P_0;
			ahZdAXhwDqhgOgCrisWLtObhWKYTA = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			wuloCyTIFfCSteczABMqkgnSKHYK = P_0.wuloCyTIFfCSteczABMqkgnSKHYK;
			ahZdAXhwDqhgOgCrisWLtObhWKYTA = P_0.ahZdAXhwDqhgOgCrisWLtObhWKYTA;
		}
	}
}
