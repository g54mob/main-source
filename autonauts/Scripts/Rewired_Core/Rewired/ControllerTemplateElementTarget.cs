using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement HTLcYvoTlavFYycJeESdEzsACfS;

		private AxisRange jlEnqYlFCTxpQiXKkRUPTZLnjeL;

		public AxisRange axisRange
		{
			get
			{
				return jlEnqYlFCTxpQiXKkRUPTZLnjeL;
			}
			set
			{
				jlEnqYlFCTxpQiXKkRUPTZLnjeL = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (HTLcYvoTlavFYycJeESdEzsACfS == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return HTLcYvoTlavFYycJeESdEzsACfS.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (HTLcYvoTlavFYycJeESdEzsACfS == null)
				{
					return string.Empty;
				}
				switch (HTLcYvoTlavFYycJeESdEzsACfS.type)
				{
				case ControllerTemplateElementType.Axis:
					return ((IControllerTemplateAxis)HTLcYvoTlavFYycJeESdEzsACfS).GetDescriptiveName(jlEnqYlFCTxpQiXKkRUPTZLnjeL);
				case ControllerTemplateElementType.Button:
					return ((IControllerTemplateButton)HTLcYvoTlavFYycJeESdEzsACfS).descriptiveName;
				default:
					return HTLcYvoTlavFYycJeESdEzsACfS.descriptiveName;
				}
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return HTLcYvoTlavFYycJeESdEzsACfS;
			}
			set
			{
				HTLcYvoTlavFYycJeESdEzsACfS = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (HTLcYvoTlavFYycJeESdEzsACfS == null)
				{
					return null;
				}
				return (HTLcYvoTlavFYycJeESdEzsACfS as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget
		{
			get
			{
				return HTLcYvoTlavFYycJeESdEzsACfS != null;
			}
		}

		internal ControllerTemplateElementTarget(IControllerTemplateElement element, AxisRange axisRange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			HTLcYvoTlavFYycJeESdEzsACfS = element;
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = axisRange;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget other)
		{
			HTLcYvoTlavFYycJeESdEzsACfS = other.HTLcYvoTlavFYycJeESdEzsACfS;
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = other.jlEnqYlFCTxpQiXKkRUPTZLnjeL;
		}
	}
}
