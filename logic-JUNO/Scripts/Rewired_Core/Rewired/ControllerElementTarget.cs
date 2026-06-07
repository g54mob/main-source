using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element WHRuiWiACOYDqOqsAyqwdoxpaSOp;

		private AxisRange KaXQATLvSErtvcNbNuVLanulNkYf;

		public int elementIdentifierId
		{
			get
			{
				if (WHRuiWiACOYDqOqsAyqwdoxpaSOp == null)
				{
					return -1;
				}
				return WHRuiWiACOYDqOqsAyqwdoxpaSOp.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return KaXQATLvSErtvcNbNuVLanulNkYf;
			}
			set
			{
				KaXQATLvSErtvcNbNuVLanulNkYf = value;
			}
		}

		public bool hasTarget => WHRuiWiACOYDqOqsAyqwdoxpaSOp != null;

		public ControllerElementType elementType
		{
			get
			{
				if (WHRuiWiACOYDqOqsAyqwdoxpaSOp == null)
				{
					return ControllerElementType.Axis;
				}
				return WHRuiWiACOYDqOqsAyqwdoxpaSOp.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (WHRuiWiACOYDqOqsAyqwdoxpaSOp == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = WHRuiWiACOYDqOqsAyqwdoxpaSOp.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(WHRuiWiACOYDqOqsAyqwdoxpaSOp.type, KaXQATLvSErtvcNbNuVLanulNkYf);
			}
		}

		public Controller controller
		{
			get
			{
				if (WHRuiWiACOYDqOqsAyqwdoxpaSOp == null)
				{
					return null;
				}
				return WHRuiWiACOYDqOqsAyqwdoxpaSOp.CsSUsnRKrAqtNSEfgAkMekrbRwsrA;
			}
		}

		public Controller.Element element
		{
			get
			{
				return WHRuiWiACOYDqOqsAyqwdoxpaSOp;
			}
			set
			{
				WHRuiWiACOYDqOqsAyqwdoxpaSOp = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.AtAOKIDhgGZdhsSWVmaBBeYEbKldA != null)
			{
				Controller controller = ReInput.WUBqcfcHLvbkdiiUnEhQlzYVACJm.RdwbZcApWxKMveONGCHALzbrDsZZb(P_0.AtAOKIDhgGZdhsSWVmaBBeYEbKldA.controllerType, P_0.AtAOKIDhgGZdhsSWVmaBBeYEbKldA.controllerId);
				WHRuiWiACOYDqOqsAyqwdoxpaSOp = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				WHRuiWiACOYDqOqsAyqwdoxpaSOp = null;
			}
			KaXQATLvSErtvcNbNuVLanulNkYf = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			WHRuiWiACOYDqOqsAyqwdoxpaSOp = P_0.WHRuiWiACOYDqOqsAyqwdoxpaSOp;
			KaXQATLvSErtvcNbNuVLanulNkYf = P_0.KaXQATLvSErtvcNbNuVLanulNkYf;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			WHRuiWiACOYDqOqsAyqwdoxpaSOp = P_0.element;
			KaXQATLvSErtvcNbNuVLanulNkYf = P_0.axisRange;
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
