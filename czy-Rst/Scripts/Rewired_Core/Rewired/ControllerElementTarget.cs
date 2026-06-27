using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element TmyGqzahJpSaxQSauhFRoVlFlWgGb;

		private AxisRange PHcQLyKBFfDQkoUhhFTiEjyTaVgiA;

		public int elementIdentifierId
		{
			get
			{
				if (TmyGqzahJpSaxQSauhFRoVlFlWgGb == null)
				{
					return -1;
				}
				return TmyGqzahJpSaxQSauhFRoVlFlWgGb.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return PHcQLyKBFfDQkoUhhFTiEjyTaVgiA;
			}
			set
			{
				PHcQLyKBFfDQkoUhhFTiEjyTaVgiA = value;
			}
		}

		public bool hasTarget => TmyGqzahJpSaxQSauhFRoVlFlWgGb != null;

		public ControllerElementType elementType
		{
			get
			{
				if (TmyGqzahJpSaxQSauhFRoVlFlWgGb == null)
				{
					return ControllerElementType.Axis;
				}
				return TmyGqzahJpSaxQSauhFRoVlFlWgGb.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (TmyGqzahJpSaxQSauhFRoVlFlWgGb == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = TmyGqzahJpSaxQSauhFRoVlFlWgGb.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(TmyGqzahJpSaxQSauhFRoVlFlWgGb.type, PHcQLyKBFfDQkoUhhFTiEjyTaVgiA);
			}
		}

		public Controller controller
		{
			get
			{
				if (TmyGqzahJpSaxQSauhFRoVlFlWgGb == null)
				{
					return null;
				}
				return TmyGqzahJpSaxQSauhFRoVlFlWgGb.PVhaaUSScreMCCMfGAFzHCnhBcGVB;
			}
		}

		public Controller.Element element
		{
			get
			{
				return TmyGqzahJpSaxQSauhFRoVlFlWgGb;
			}
			set
			{
				TmyGqzahJpSaxQSauhFRoVlFlWgGb = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.DsreCtQkntUEiqlCniVgHvGuWWTSA != null)
			{
				Controller controller = ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.QCDDZTfeTGMbmcEJicshLRdxImzvA(P_0.DsreCtQkntUEiqlCniVgHvGuWWTSA.controllerType, P_0.DsreCtQkntUEiqlCniVgHvGuWWTSA.controllerId);
				TmyGqzahJpSaxQSauhFRoVlFlWgGb = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				TmyGqzahJpSaxQSauhFRoVlFlWgGb = null;
			}
			PHcQLyKBFfDQkoUhhFTiEjyTaVgiA = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			TmyGqzahJpSaxQSauhFRoVlFlWgGb = P_0.TmyGqzahJpSaxQSauhFRoVlFlWgGb;
			PHcQLyKBFfDQkoUhhFTiEjyTaVgiA = P_0.PHcQLyKBFfDQkoUhhFTiEjyTaVgiA;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			TmyGqzahJpSaxQSauhFRoVlFlWgGb = P_0.element;
			PHcQLyKBFfDQkoUhhFTiEjyTaVgiA = P_0.axisRange;
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
