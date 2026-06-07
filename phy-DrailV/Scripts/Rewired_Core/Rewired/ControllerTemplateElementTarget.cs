using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement fFYLKxWHrrEZttAdLafzRcHcpirM;

		private AxisRange PpBKvDDuwSJgSbXdRraQGlHTKPPc;

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

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (fFYLKxWHrrEZttAdLafzRcHcpirM == null)
				{
					return ControllerTemplateElementType.Axis;
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
				switch (fFYLKxWHrrEZttAdLafzRcHcpirM.type)
				{
				case ControllerTemplateElementType.Axis:
					return ((IControllerTemplateAxis)fFYLKxWHrrEZttAdLafzRcHcpirM).GetDescriptiveName(PpBKvDDuwSJgSbXdRraQGlHTKPPc);
				case ControllerTemplateElementType.Button:
					return ((IControllerTemplateButton)fFYLKxWHrrEZttAdLafzRcHcpirM).descriptiveName;
				default:
					return fFYLKxWHrrEZttAdLafzRcHcpirM.descriptiveName;
				}
			}
		}

		public IControllerTemplateElement element
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

		public IControllerTemplate template
		{
			get
			{
				if (fFYLKxWHrrEZttAdLafzRcHcpirM == null)
				{
					return null;
				}
				return (fFYLKxWHrrEZttAdLafzRcHcpirM as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => fFYLKxWHrrEZttAdLafzRcHcpirM != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			fFYLKxWHrrEZttAdLafzRcHcpirM = P_0;
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			fFYLKxWHrrEZttAdLafzRcHcpirM = P_0.fFYLKxWHrrEZttAdLafzRcHcpirM;
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_0.PpBKvDDuwSJgSbXdRraQGlHTKPPc;
		}
	}
}
