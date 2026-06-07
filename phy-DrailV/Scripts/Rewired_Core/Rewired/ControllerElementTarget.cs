using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element fFYLKxWHrrEZttAdLafzRcHcpirM;

		private AxisRange PpBKvDDuwSJgSbXdRraQGlHTKPPc;

		public int elementIdentifierId
		{
			get
			{
				if (fFYLKxWHrrEZttAdLafzRcHcpirM == null)
				{
					return -1;
				}
				return fFYLKxWHrrEZttAdLafzRcHcpirM.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return PpBKvDDuwSJgSbXdRraQGlHTKPPc;
			}
			set
			{
				PpBKvDDuwSJgSbXdRraQGlHTKPPc = value;
			}
		}

		public bool hasTarget => fFYLKxWHrrEZttAdLafzRcHcpirM != null;

		public ControllerElementType elementType
		{
			get
			{
				if (fFYLKxWHrrEZttAdLafzRcHcpirM == null)
				{
					return ControllerElementType.Axis;
				}
				return fFYLKxWHrrEZttAdLafzRcHcpirM.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (fFYLKxWHrrEZttAdLafzRcHcpirM == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = fFYLKxWHrrEZttAdLafzRcHcpirM.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(fFYLKxWHrrEZttAdLafzRcHcpirM.type, PpBKvDDuwSJgSbXdRraQGlHTKPPc);
			}
		}

		public Controller controller
		{
			get
			{
				if (fFYLKxWHrrEZttAdLafzRcHcpirM == null)
				{
					return null;
				}
				return fFYLKxWHrrEZttAdLafzRcHcpirM.SHugpoIFWkCnojYBXWjOaAoAAYCW;
			}
		}

		public Controller.Element element
		{
			get
			{
				return fFYLKxWHrrEZttAdLafzRcHcpirM;
			}
			set
			{
				fFYLKxWHrrEZttAdLafzRcHcpirM = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.KQrkQkAkhknsIKIpiSyrmaMcHTQc != null)
			{
				Controller controller = ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(P_0.KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType, P_0.KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerId);
				fFYLKxWHrrEZttAdLafzRcHcpirM = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				fFYLKxWHrrEZttAdLafzRcHcpirM = null;
			}
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			fFYLKxWHrrEZttAdLafzRcHcpirM = P_0.fFYLKxWHrrEZttAdLafzRcHcpirM;
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_0.PpBKvDDuwSJgSbXdRraQGlHTKPPc;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			fFYLKxWHrrEZttAdLafzRcHcpirM = P_0.element;
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_0.axisRange;
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
