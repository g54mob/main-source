using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element yFGsCuUeJQiEmCujMlQAhmJVmoJb;

		private AxisRange INqAuPUOdfKjEyVKDGDlvfaJUlc;

		public int elementIdentifierId
		{
			get
			{
				if (yFGsCuUeJQiEmCujMlQAhmJVmoJb == null)
				{
					return -1;
				}
				return yFGsCuUeJQiEmCujMlQAhmJVmoJb.id;
			}
		}

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

		public bool hasTarget => yFGsCuUeJQiEmCujMlQAhmJVmoJb != null;

		public ControllerElementType elementType
		{
			get
			{
				if (yFGsCuUeJQiEmCujMlQAhmJVmoJb == null)
				{
					return ControllerElementType.Axis;
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
				ControllerElementIdentifier elementIdentifier = yFGsCuUeJQiEmCujMlQAhmJVmoJb.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(yFGsCuUeJQiEmCujMlQAhmJVmoJb.type, INqAuPUOdfKjEyVKDGDlvfaJUlc);
			}
		}

		public Controller controller
		{
			get
			{
				if (yFGsCuUeJQiEmCujMlQAhmJVmoJb == null)
				{
					return null;
				}
				return yFGsCuUeJQiEmCujMlQAhmJVmoJb.BheccrWcwXwuvsNLWjWrFwcrgAqE;
			}
		}

		public Controller.Element element
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

		public ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (actionElementMap.BwdkYrCIFNiRPDEpxxAUFyIFLij != null)
			{
				Controller controller = ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(actionElementMap.BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerType, actionElementMap.BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerId);
				yFGsCuUeJQiEmCujMlQAhmJVmoJb = controller.GetElementById(actionElementMap._elementIdentifierId);
			}
			else
			{
				yFGsCuUeJQiEmCujMlQAhmJVmoJb = null;
			}
			INqAuPUOdfKjEyVKDGDlvfaJUlc = actionElementMap._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget other)
		{
			yFGsCuUeJQiEmCujMlQAhmJVmoJb = other.yFGsCuUeJQiEmCujMlQAhmJVmoJb;
			INqAuPUOdfKjEyVKDGDlvfaJUlc = other.INqAuPUOdfKjEyVKDGDlvfaJUlc;
		}

		public ControllerElementTarget(IControllerElementTarget other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			yFGsCuUeJQiEmCujMlQAhmJVmoJb = other.element;
			INqAuPUOdfKjEyVKDGDlvfaJUlc = other.axisRange;
		}

		public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				return default(ControllerElementTarget);
			}
			return new ControllerElementTarget(actionElementMap);
		}
	}
}
