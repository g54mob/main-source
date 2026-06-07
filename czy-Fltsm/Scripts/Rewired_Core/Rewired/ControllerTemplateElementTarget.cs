using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement BwLTBUZYEnJEgBhygCjLyPSspWNv;

		private AxisRange XxhebnkbKewzRMzgUowseMSDoCFmA;

		public AxisRange axisRange
		{
			get
			{
				return XxhebnkbKewzRMzgUowseMSDoCFmA;
			}
			set
			{
				XxhebnkbKewzRMzgUowseMSDoCFmA = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (BwLTBUZYEnJEgBhygCjLyPSspWNv == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return BwLTBUZYEnJEgBhygCjLyPSspWNv.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (BwLTBUZYEnJEgBhygCjLyPSspWNv == null)
				{
					return string.Empty;
				}
				return BwLTBUZYEnJEgBhygCjLyPSspWNv.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)BwLTBUZYEnJEgBhygCjLyPSspWNv).GetDescriptiveName(XxhebnkbKewzRMzgUowseMSDoCFmA), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)BwLTBUZYEnJEgBhygCjLyPSspWNv).descriptiveName, 
					_ => BwLTBUZYEnJEgBhygCjLyPSspWNv.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return BwLTBUZYEnJEgBhygCjLyPSspWNv;
			}
			set
			{
				BwLTBUZYEnJEgBhygCjLyPSspWNv = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (BwLTBUZYEnJEgBhygCjLyPSspWNv == null)
				{
					return null;
				}
				return (BwLTBUZYEnJEgBhygCjLyPSspWNv as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => BwLTBUZYEnJEgBhygCjLyPSspWNv != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			BwLTBUZYEnJEgBhygCjLyPSspWNv = P_0;
			XxhebnkbKewzRMzgUowseMSDoCFmA = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			BwLTBUZYEnJEgBhygCjLyPSspWNv = P_0.BwLTBUZYEnJEgBhygCjLyPSspWNv;
			XxhebnkbKewzRMzgUowseMSDoCFmA = P_0.XxhebnkbKewzRMzgUowseMSDoCFmA;
		}
	}
}
