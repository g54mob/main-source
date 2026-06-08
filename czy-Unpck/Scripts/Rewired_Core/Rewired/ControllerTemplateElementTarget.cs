using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement qAVzPVElaeCeQPNTvafTQkFTETCd;

		private AxisRange ULUBoZXZbPaLHXiblpGEJyjatZk;

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

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (qAVzPVElaeCeQPNTvafTQkFTETCd == null)
				{
					return ControllerTemplateElementType.Axis;
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
				switch (qAVzPVElaeCeQPNTvafTQkFTETCd.type)
				{
				case ControllerTemplateElementType.Axis:
					return ((IControllerTemplateAxis)qAVzPVElaeCeQPNTvafTQkFTETCd).GetDescriptiveName(ULUBoZXZbPaLHXiblpGEJyjatZk);
				case ControllerTemplateElementType.Button:
					return ((IControllerTemplateButton)qAVzPVElaeCeQPNTvafTQkFTETCd).descriptiveName;
				default:
					return qAVzPVElaeCeQPNTvafTQkFTETCd.descriptiveName;
				}
			}
		}

		public IControllerTemplateElement element
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

		public IControllerTemplate template
		{
			get
			{
				if (qAVzPVElaeCeQPNTvafTQkFTETCd == null)
				{
					return null;
				}
				return (qAVzPVElaeCeQPNTvafTQkFTETCd as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => qAVzPVElaeCeQPNTvafTQkFTETCd != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement element, AxisRange axisRange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			qAVzPVElaeCeQPNTvafTQkFTETCd = element;
			ULUBoZXZbPaLHXiblpGEJyjatZk = axisRange;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget other)
		{
			qAVzPVElaeCeQPNTvafTQkFTETCd = other.qAVzPVElaeCeQPNTvafTQkFTETCd;
			ULUBoZXZbPaLHXiblpGEJyjatZk = other.ULUBoZXZbPaLHXiblpGEJyjatZk;
		}
	}
}
