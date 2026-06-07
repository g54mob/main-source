using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element txdZDWwBFdVCJDRfnCameDZKhaGW;

		private AxisRange lTjlxTTRPrurSvGysMQDhPQAhpEGA;

		public int elementIdentifierId
		{
			get
			{
				if (txdZDWwBFdVCJDRfnCameDZKhaGW == null)
				{
					return -1;
				}
				return txdZDWwBFdVCJDRfnCameDZKhaGW.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return lTjlxTTRPrurSvGysMQDhPQAhpEGA;
			}
			set
			{
				lTjlxTTRPrurSvGysMQDhPQAhpEGA = value;
			}
		}

		public bool hasTarget => txdZDWwBFdVCJDRfnCameDZKhaGW != null;

		public ControllerElementType elementType
		{
			get
			{
				if (txdZDWwBFdVCJDRfnCameDZKhaGW == null)
				{
					return ControllerElementType.Axis;
				}
				return txdZDWwBFdVCJDRfnCameDZKhaGW.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (txdZDWwBFdVCJDRfnCameDZKhaGW == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = txdZDWwBFdVCJDRfnCameDZKhaGW.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(txdZDWwBFdVCJDRfnCameDZKhaGW.type, lTjlxTTRPrurSvGysMQDhPQAhpEGA);
			}
		}

		public Controller controller
		{
			get
			{
				if (txdZDWwBFdVCJDRfnCameDZKhaGW == null)
				{
					return null;
				}
				return txdZDWwBFdVCJDRfnCameDZKhaGW.tHyTrlHkDtjZaDgMPCsGdVcGGXwD;
			}
		}

		public Controller.Element element
		{
			get
			{
				return txdZDWwBFdVCJDRfnCameDZKhaGW;
			}
			set
			{
				txdZDWwBFdVCJDRfnCameDZKhaGW = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.thsxfGHWjvteUtqDkOYNWOutmkzj != null)
			{
				Controller controller = ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.mIEmXinDLSYEQVEphxqMuRdgYjDG(P_0.thsxfGHWjvteUtqDkOYNWOutmkzj.controllerType, P_0.thsxfGHWjvteUtqDkOYNWOutmkzj.controllerId);
				txdZDWwBFdVCJDRfnCameDZKhaGW = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				txdZDWwBFdVCJDRfnCameDZKhaGW = null;
			}
			lTjlxTTRPrurSvGysMQDhPQAhpEGA = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			txdZDWwBFdVCJDRfnCameDZKhaGW = P_0.txdZDWwBFdVCJDRfnCameDZKhaGW;
			lTjlxTTRPrurSvGysMQDhPQAhpEGA = P_0.lTjlxTTRPrurSvGysMQDhPQAhpEGA;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			txdZDWwBFdVCJDRfnCameDZKhaGW = P_0.element;
			lTjlxTTRPrurSvGysMQDhPQAhpEGA = P_0.axisRange;
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
