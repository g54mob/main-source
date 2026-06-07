using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement MwCBVmeZjbozNOJFcXjTAjixqQbH;

		private AxisRange emLkZqjpKMMiQMkdaETOTOIMfGJq;

		public AxisRange axisRange
		{
			get
			{
				return emLkZqjpKMMiQMkdaETOTOIMfGJq;
			}
			set
			{
				emLkZqjpKMMiQMkdaETOTOIMfGJq = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return MwCBVmeZjbozNOJFcXjTAjixqQbH.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return string.Empty;
				}
				return MwCBVmeZjbozNOJFcXjTAjixqQbH.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)MwCBVmeZjbozNOJFcXjTAjixqQbH).GetDescriptiveName(emLkZqjpKMMiQMkdaETOTOIMfGJq), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)MwCBVmeZjbozNOJFcXjTAjixqQbH).descriptiveName, 
					_ => MwCBVmeZjbozNOJFcXjTAjixqQbH.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return MwCBVmeZjbozNOJFcXjTAjixqQbH;
			}
			set
			{
				MwCBVmeZjbozNOJFcXjTAjixqQbH = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return null;
				}
				return (MwCBVmeZjbozNOJFcXjTAjixqQbH as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => MwCBVmeZjbozNOJFcXjTAjixqQbH != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			MwCBVmeZjbozNOJFcXjTAjixqQbH = P_0;
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			MwCBVmeZjbozNOJFcXjTAjixqQbH = P_0.MwCBVmeZjbozNOJFcXjTAjixqQbH;
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_0.emLkZqjpKMMiQMkdaETOTOIMfGJq;
		}
	}
}
