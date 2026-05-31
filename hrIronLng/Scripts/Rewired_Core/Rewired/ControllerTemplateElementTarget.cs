using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement CcuFlIfdiJcjsaxXDhATDqqihwvQ;

		private AxisRange iKpdeCcvrahntrCdBHCMvDYKvQZ;

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

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (CcuFlIfdiJcjsaxXDhATDqqihwvQ == null)
				{
					return ControllerTemplateElementType.Axis;
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
				return CcuFlIfdiJcjsaxXDhATDqqihwvQ.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)CcuFlIfdiJcjsaxXDhATDqqihwvQ).GetDescriptiveName(iKpdeCcvrahntrCdBHCMvDYKvQZ), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)CcuFlIfdiJcjsaxXDhATDqqihwvQ).descriptiveName, 
					_ => CcuFlIfdiJcjsaxXDhATDqqihwvQ.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
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

		public IControllerTemplate template
		{
			get
			{
				if (CcuFlIfdiJcjsaxXDhATDqqihwvQ == null)
				{
					return null;
				}
				return (CcuFlIfdiJcjsaxXDhATDqqihwvQ as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => CcuFlIfdiJcjsaxXDhATDqqihwvQ != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement element, AxisRange axisRange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			CcuFlIfdiJcjsaxXDhATDqqihwvQ = element;
			iKpdeCcvrahntrCdBHCMvDYKvQZ = axisRange;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget other)
		{
			CcuFlIfdiJcjsaxXDhATDqqihwvQ = other.CcuFlIfdiJcjsaxXDhATDqqihwvQ;
			iKpdeCcvrahntrCdBHCMvDYKvQZ = other.iKpdeCcvrahntrCdBHCMvDYKvQZ;
		}
	}
}
