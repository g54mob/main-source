using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement NeVqFkBQKKbECgbwnqnubpVtUiCJA;

		private AxisRange JLpjXrbOIBqChJwQDaWNHJgQmXEe;

		public AxisRange axisRange
		{
			get
			{
				return JLpjXrbOIBqChJwQDaWNHJgQmXEe;
			}
			set
			{
				JLpjXrbOIBqChJwQDaWNHJgQmXEe = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (NeVqFkBQKKbECgbwnqnubpVtUiCJA == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return NeVqFkBQKKbECgbwnqnubpVtUiCJA.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (NeVqFkBQKKbECgbwnqnubpVtUiCJA == null)
				{
					return string.Empty;
				}
				return NeVqFkBQKKbECgbwnqnubpVtUiCJA.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)NeVqFkBQKKbECgbwnqnubpVtUiCJA).GetDescriptiveName(JLpjXrbOIBqChJwQDaWNHJgQmXEe), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)NeVqFkBQKKbECgbwnqnubpVtUiCJA).descriptiveName, 
					_ => NeVqFkBQKKbECgbwnqnubpVtUiCJA.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return NeVqFkBQKKbECgbwnqnubpVtUiCJA;
			}
			set
			{
				NeVqFkBQKKbECgbwnqnubpVtUiCJA = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (NeVqFkBQKKbECgbwnqnubpVtUiCJA == null)
				{
					return null;
				}
				return (NeVqFkBQKKbECgbwnqnubpVtUiCJA as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => NeVqFkBQKKbECgbwnqnubpVtUiCJA != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			NeVqFkBQKKbECgbwnqnubpVtUiCJA = P_0;
			JLpjXrbOIBqChJwQDaWNHJgQmXEe = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			NeVqFkBQKKbECgbwnqnubpVtUiCJA = P_0.NeVqFkBQKKbECgbwnqnubpVtUiCJA;
			JLpjXrbOIBqChJwQDaWNHJgQmXEe = P_0.JLpjXrbOIBqChJwQDaWNHJgQmXEe;
		}
	}
}
