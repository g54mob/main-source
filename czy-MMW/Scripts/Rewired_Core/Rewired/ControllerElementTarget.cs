using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element KlUDdErQHiZgrAvrohDbRoPuGseJA;

		private AxisRange UdCBDJELEaASqkuljPVUAIkuhPgD;

		public int elementIdentifierId
		{
			get
			{
				if (KlUDdErQHiZgrAvrohDbRoPuGseJA == null)
				{
					return -1;
				}
				return KlUDdErQHiZgrAvrohDbRoPuGseJA.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return UdCBDJELEaASqkuljPVUAIkuhPgD;
			}
			set
			{
				UdCBDJELEaASqkuljPVUAIkuhPgD = value;
			}
		}

		public bool hasTarget => KlUDdErQHiZgrAvrohDbRoPuGseJA != null;

		public ControllerElementType elementType
		{
			get
			{
				if (KlUDdErQHiZgrAvrohDbRoPuGseJA == null)
				{
					return ControllerElementType.Axis;
				}
				return KlUDdErQHiZgrAvrohDbRoPuGseJA.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (KlUDdErQHiZgrAvrohDbRoPuGseJA == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = KlUDdErQHiZgrAvrohDbRoPuGseJA.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(KlUDdErQHiZgrAvrohDbRoPuGseJA.type, UdCBDJELEaASqkuljPVUAIkuhPgD);
			}
		}

		public Controller controller
		{
			get
			{
				if (KlUDdErQHiZgrAvrohDbRoPuGseJA == null)
				{
					return null;
				}
				return KlUDdErQHiZgrAvrohDbRoPuGseJA.CVXitzEFsuCUSdKeYEDPsGHkxWOy;
			}
		}

		public Controller.Element element
		{
			get
			{
				return KlUDdErQHiZgrAvrohDbRoPuGseJA;
			}
			set
			{
				KlUDdErQHiZgrAvrohDbRoPuGseJA = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null)
			{
				Controller controller = ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.DxfjMakBNHsfwQIMeHaXPCHSdWpiA(P_0.SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType, P_0.SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerId);
				KlUDdErQHiZgrAvrohDbRoPuGseJA = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				KlUDdErQHiZgrAvrohDbRoPuGseJA = null;
			}
			UdCBDJELEaASqkuljPVUAIkuhPgD = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			KlUDdErQHiZgrAvrohDbRoPuGseJA = P_0.KlUDdErQHiZgrAvrohDbRoPuGseJA;
			UdCBDJELEaASqkuljPVUAIkuhPgD = P_0.UdCBDJELEaASqkuljPVUAIkuhPgD;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			KlUDdErQHiZgrAvrohDbRoPuGseJA = P_0.element;
			UdCBDJELEaASqkuljPVUAIkuhPgD = P_0.axisRange;
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
