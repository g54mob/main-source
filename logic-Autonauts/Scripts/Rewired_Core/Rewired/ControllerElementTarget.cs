using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element HTLcYvoTlavFYycJeESdEzsACfS;

		private AxisRange jlEnqYlFCTxpQiXKkRUPTZLnjeL;

		public int elementIdentifierId
		{
			get
			{
				if (HTLcYvoTlavFYycJeESdEzsACfS == null)
				{
					return -1;
				}
				return HTLcYvoTlavFYycJeESdEzsACfS.id;
			}
		}

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

		public bool hasTarget
		{
			get
			{
				return HTLcYvoTlavFYycJeESdEzsACfS != null;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				if (HTLcYvoTlavFYycJeESdEzsACfS == null)
				{
					return ControllerElementType.Axis;
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
					goto IL_0008;
				}
				ControllerElementIdentifier elementIdentifier = HTLcYvoTlavFYycJeESdEzsACfS.elementIdentifier;
				int num = 703696624;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x29F18EF0)
				{
				case 2:
					break;
				case 1:
					return string.Empty;
				default:
					if (elementIdentifier == null)
					{
						return string.Empty;
					}
					return elementIdentifier.GetDisplayName(HTLcYvoTlavFYycJeESdEzsACfS.type, jlEnqYlFCTxpQiXKkRUPTZLnjeL);
				}
				goto IL_0008;
				IL_0008:
				num = 703696625;
				goto IL_000d;
			}
		}

		public Controller controller
		{
			get
			{
				if (HTLcYvoTlavFYycJeESdEzsACfS == null)
				{
					return null;
				}
				return HTLcYvoTlavFYycJeESdEzsACfS.ktnvQXcbwjTTWobUkcIrbxSoyaKH;
			}
		}

		public Controller.Element element
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

		public ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (actionElementMap.yAkjWJqxMpaNcNJFRMpKjoUYObX != null)
			{
				Controller controller = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(actionElementMap.yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType, actionElementMap.yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerId);
				HTLcYvoTlavFYycJeESdEzsACfS = controller.GetElementById(actionElementMap._elementIdentifierId);
			}
			else
			{
				HTLcYvoTlavFYycJeESdEzsACfS = null;
			}
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = actionElementMap._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget other)
		{
			HTLcYvoTlavFYycJeESdEzsACfS = other.HTLcYvoTlavFYycJeESdEzsACfS;
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = other.jlEnqYlFCTxpQiXKkRUPTZLnjeL;
		}

		public ControllerElementTarget(IControllerElementTarget other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			HTLcYvoTlavFYycJeESdEzsACfS = other.element;
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = other.axisRange;
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
