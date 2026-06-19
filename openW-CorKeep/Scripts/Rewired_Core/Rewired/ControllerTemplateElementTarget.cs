using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement PxFDOXxmQpZUTwKAdoImxOMLVkBC;

		private AxisRange FrtebuLbucwfjIXKTcrZDzUaQJXo;

		public AxisRange axisRange
		{
			get
			{
				return FrtebuLbucwfjIXKTcrZDzUaQJXo;
			}
			set
			{
				FrtebuLbucwfjIXKTcrZDzUaQJXo = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (PxFDOXxmQpZUTwKAdoImxOMLVkBC == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return PxFDOXxmQpZUTwKAdoImxOMLVkBC.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (PxFDOXxmQpZUTwKAdoImxOMLVkBC == null)
				{
					return string.Empty;
				}
				return PxFDOXxmQpZUTwKAdoImxOMLVkBC.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)PxFDOXxmQpZUTwKAdoImxOMLVkBC).GetDescriptiveName(FrtebuLbucwfjIXKTcrZDzUaQJXo), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)PxFDOXxmQpZUTwKAdoImxOMLVkBC).descriptiveName, 
					_ => PxFDOXxmQpZUTwKAdoImxOMLVkBC.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return PxFDOXxmQpZUTwKAdoImxOMLVkBC;
			}
			set
			{
				PxFDOXxmQpZUTwKAdoImxOMLVkBC = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (PxFDOXxmQpZUTwKAdoImxOMLVkBC == null)
				{
					return null;
				}
				return (PxFDOXxmQpZUTwKAdoImxOMLVkBC as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => PxFDOXxmQpZUTwKAdoImxOMLVkBC != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			PxFDOXxmQpZUTwKAdoImxOMLVkBC = P_0;
			FrtebuLbucwfjIXKTcrZDzUaQJXo = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			PxFDOXxmQpZUTwKAdoImxOMLVkBC = P_0.PxFDOXxmQpZUTwKAdoImxOMLVkBC;
			FrtebuLbucwfjIXKTcrZDzUaQJXo = P_0.FrtebuLbucwfjIXKTcrZDzUaQJXo;
		}
	}
}
