using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement IMqDHRSAFttzPxdcVeAPDxNXdaiS;

		private AxisRange OMSpwoeVkuNgkTaHtTWgnRdmubiF;

		public AxisRange axisRange
		{
			get
			{
				return OMSpwoeVkuNgkTaHtTWgnRdmubiF;
			}
			set
			{
				OMSpwoeVkuNgkTaHtTWgnRdmubiF = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (IMqDHRSAFttzPxdcVeAPDxNXdaiS == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return IMqDHRSAFttzPxdcVeAPDxNXdaiS.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (IMqDHRSAFttzPxdcVeAPDxNXdaiS == null)
				{
					return string.Empty;
				}
				return IMqDHRSAFttzPxdcVeAPDxNXdaiS.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)IMqDHRSAFttzPxdcVeAPDxNXdaiS).GetDescriptiveName(OMSpwoeVkuNgkTaHtTWgnRdmubiF), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)IMqDHRSAFttzPxdcVeAPDxNXdaiS).descriptiveName, 
					_ => IMqDHRSAFttzPxdcVeAPDxNXdaiS.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return IMqDHRSAFttzPxdcVeAPDxNXdaiS;
			}
			set
			{
				IMqDHRSAFttzPxdcVeAPDxNXdaiS = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (IMqDHRSAFttzPxdcVeAPDxNXdaiS == null)
				{
					return null;
				}
				return (IMqDHRSAFttzPxdcVeAPDxNXdaiS as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => IMqDHRSAFttzPxdcVeAPDxNXdaiS != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			IMqDHRSAFttzPxdcVeAPDxNXdaiS = P_0;
			OMSpwoeVkuNgkTaHtTWgnRdmubiF = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			IMqDHRSAFttzPxdcVeAPDxNXdaiS = P_0.IMqDHRSAFttzPxdcVeAPDxNXdaiS;
			OMSpwoeVkuNgkTaHtTWgnRdmubiF = P_0.OMSpwoeVkuNgkTaHtTWgnRdmubiF;
		}
	}
}
