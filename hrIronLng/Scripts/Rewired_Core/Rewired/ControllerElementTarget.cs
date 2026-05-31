using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element CcuFlIfdiJcjsaxXDhATDqqihwvQ;

		private AxisRange iKpdeCcvrahntrCdBHCMvDYKvQZ;

		public int elementIdentifierId
		{
			get
			{
				if (CcuFlIfdiJcjsaxXDhATDqqihwvQ == null)
				{
					return -1;
				}
				return CcuFlIfdiJcjsaxXDhATDqqihwvQ.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return iKpdeCcvrahntrCdBHCMvDYKvQZ;
			}
			set
			{
				iKpdeCcvrahntrCdBHCMvDYKvQZ = value;
			}
		}

		public bool hasTarget => CcuFlIfdiJcjsaxXDhATDqqihwvQ != null;

		public ControllerElementType elementType
		{
			get
			{
				if (CcuFlIfdiJcjsaxXDhATDqqihwvQ == null)
				{
					return ControllerElementType.Axis;
				}
				return CcuFlIfdiJcjsaxXDhATDqqihwvQ.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (CcuFlIfdiJcjsaxXDhATDqqihwvQ == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = CcuFlIfdiJcjsaxXDhATDqqihwvQ.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(CcuFlIfdiJcjsaxXDhATDqqihwvQ.type, iKpdeCcvrahntrCdBHCMvDYKvQZ);
			}
		}

		public Controller controller
		{
			get
			{
				if (CcuFlIfdiJcjsaxXDhATDqqihwvQ == null)
				{
					return null;
				}
				return CcuFlIfdiJcjsaxXDhATDqqihwvQ.frSJxBhFNALntnzeNKOcTHuHKsS;
			}
		}

		public Controller.Element element
		{
			get
			{
				return CcuFlIfdiJcjsaxXDhATDqqihwvQ;
			}
			set
			{
				CcuFlIfdiJcjsaxXDhATDqqihwvQ = value;
			}
		}

		public ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (actionElementMap.fcPcTXdclCfFXHGkwVhNNBHdQNBk != null)
			{
				Controller controller = ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(actionElementMap.fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType, actionElementMap.fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerId);
				CcuFlIfdiJcjsaxXDhATDqqihwvQ = controller.GetElementById(actionElementMap._elementIdentifierId);
			}
			else
			{
				CcuFlIfdiJcjsaxXDhATDqqihwvQ = null;
			}
			iKpdeCcvrahntrCdBHCMvDYKvQZ = actionElementMap._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget other)
		{
			CcuFlIfdiJcjsaxXDhATDqqihwvQ = other.CcuFlIfdiJcjsaxXDhATDqqihwvQ;
			iKpdeCcvrahntrCdBHCMvDYKvQZ = other.iKpdeCcvrahntrCdBHCMvDYKvQZ;
		}

		public ControllerElementTarget(IControllerElementTarget other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			CcuFlIfdiJcjsaxXDhATDqqihwvQ = other.element;
			iKpdeCcvrahntrCdBHCMvDYKvQZ = other.axisRange;
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
