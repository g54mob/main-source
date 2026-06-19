using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement yFGsCuUeJQiEmCujMlQAhmJVmoJb;

		private AxisRange INqAuPUOdfKjEyVKDGDlvfaJUlc;

		public AxisRange axisRange
		{
			get
			{
				return INqAuPUOdfKjEyVKDGDlvfaJUlc;
			}
			set
			{
				INqAuPUOdfKjEyVKDGDlvfaJUlc = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (yFGsCuUeJQiEmCujMlQAhmJVmoJb == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return yFGsCuUeJQiEmCujMlQAhmJVmoJb.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (yFGsCuUeJQiEmCujMlQAhmJVmoJb == null)
				{
					return string.Empty;
				}
				return yFGsCuUeJQiEmCujMlQAhmJVmoJb.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)yFGsCuUeJQiEmCujMlQAhmJVmoJb).GetDescriptiveName(INqAuPUOdfKjEyVKDGDlvfaJUlc), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)yFGsCuUeJQiEmCujMlQAhmJVmoJb).descriptiveName, 
					_ => yFGsCuUeJQiEmCujMlQAhmJVmoJb.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return yFGsCuUeJQiEmCujMlQAhmJVmoJb;
			}
			set
			{
				yFGsCuUeJQiEmCujMlQAhmJVmoJb = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (yFGsCuUeJQiEmCujMlQAhmJVmoJb == null)
				{
					return null;
				}
				return (yFGsCuUeJQiEmCujMlQAhmJVmoJb as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => yFGsCuUeJQiEmCujMlQAhmJVmoJb != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement element, AxisRange axisRange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			yFGsCuUeJQiEmCujMlQAhmJVmoJb = element;
			INqAuPUOdfKjEyVKDGDlvfaJUlc = axisRange;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget other)
		{
			yFGsCuUeJQiEmCujMlQAhmJVmoJb = other.yFGsCuUeJQiEmCujMlQAhmJVmoJb;
			INqAuPUOdfKjEyVKDGDlvfaJUlc = other.INqAuPUOdfKjEyVKDGDlvfaJUlc;
		}
	}
}
