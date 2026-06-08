using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element qAVzPVElaeCeQPNTvafTQkFTETCd;

		private AxisRange ULUBoZXZbPaLHXiblpGEJyjatZk;

		public int elementIdentifierId
		{
			get
			{
				if (qAVzPVElaeCeQPNTvafTQkFTETCd == null)
				{
					return -1;
				}
				return qAVzPVElaeCeQPNTvafTQkFTETCd.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return ULUBoZXZbPaLHXiblpGEJyjatZk;
			}
			set
			{
				ULUBoZXZbPaLHXiblpGEJyjatZk = value;
			}
		}

		public bool hasTarget => qAVzPVElaeCeQPNTvafTQkFTETCd != null;

		public ControllerElementType elementType
		{
			get
			{
				if (qAVzPVElaeCeQPNTvafTQkFTETCd == null)
				{
					return ControllerElementType.Axis;
				}
				return qAVzPVElaeCeQPNTvafTQkFTETCd.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (qAVzPVElaeCeQPNTvafTQkFTETCd == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = qAVzPVElaeCeQPNTvafTQkFTETCd.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(qAVzPVElaeCeQPNTvafTQkFTETCd.type, ULUBoZXZbPaLHXiblpGEJyjatZk);
			}
		}

		public Controller controller
		{
			get
			{
				if (qAVzPVElaeCeQPNTvafTQkFTETCd == null)
				{
					return null;
				}
				return qAVzPVElaeCeQPNTvafTQkFTETCd.PQxjKAQNRjWZaZhctvIytmcdtVz;
			}
		}

		public Controller.Element element
		{
			get
			{
				return qAVzPVElaeCeQPNTvafTQkFTETCd;
			}
			set
			{
				qAVzPVElaeCeQPNTvafTQkFTETCd = value;
			}
		}

		public ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (actionElementMap.FcwxSEAqxlQQhiIiSEyJjkwZaAa != null)
			{
				Controller controller = ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(actionElementMap.FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType, actionElementMap.FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerId);
				qAVzPVElaeCeQPNTvafTQkFTETCd = controller.GetElementById(actionElementMap._elementIdentifierId);
			}
			else
			{
				qAVzPVElaeCeQPNTvafTQkFTETCd = null;
			}
			ULUBoZXZbPaLHXiblpGEJyjatZk = actionElementMap._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget other)
		{
			qAVzPVElaeCeQPNTvafTQkFTETCd = other.qAVzPVElaeCeQPNTvafTQkFTETCd;
			ULUBoZXZbPaLHXiblpGEJyjatZk = other.ULUBoZXZbPaLHXiblpGEJyjatZk;
		}

		public ControllerElementTarget(IControllerElementTarget other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			qAVzPVElaeCeQPNTvafTQkFTETCd = other.element;
			ULUBoZXZbPaLHXiblpGEJyjatZk = other.axisRange;
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
