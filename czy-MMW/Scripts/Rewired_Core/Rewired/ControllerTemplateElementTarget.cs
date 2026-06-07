using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement VKEGIaHWDiatFndfJLAnTTdeuEsNA;

		private AxisRange XRkuCHqyNhRxuJRvpDWCjjTXGbih;

		public AxisRange axisRange
		{
			get
			{
				return XRkuCHqyNhRxuJRvpDWCjjTXGbih;
			}
			set
			{
				XRkuCHqyNhRxuJRvpDWCjjTXGbih = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (VKEGIaHWDiatFndfJLAnTTdeuEsNA == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return VKEGIaHWDiatFndfJLAnTTdeuEsNA.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (VKEGIaHWDiatFndfJLAnTTdeuEsNA == null)
				{
					return string.Empty;
				}
				return VKEGIaHWDiatFndfJLAnTTdeuEsNA.type switch
				{
					ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)VKEGIaHWDiatFndfJLAnTTdeuEsNA).GetDescriptiveName(XRkuCHqyNhRxuJRvpDWCjjTXGbih), 
					ControllerTemplateElementType.Button => ((IControllerTemplateButton)VKEGIaHWDiatFndfJLAnTTdeuEsNA).descriptiveName, 
					_ => VKEGIaHWDiatFndfJLAnTTdeuEsNA.descriptiveName, 
				};
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return VKEGIaHWDiatFndfJLAnTTdeuEsNA;
			}
			set
			{
				VKEGIaHWDiatFndfJLAnTTdeuEsNA = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (VKEGIaHWDiatFndfJLAnTTdeuEsNA == null)
				{
					return null;
				}
				return (VKEGIaHWDiatFndfJLAnTTdeuEsNA as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget => VKEGIaHWDiatFndfJLAnTTdeuEsNA != null;

		internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			VKEGIaHWDiatFndfJLAnTTdeuEsNA = P_0;
			XRkuCHqyNhRxuJRvpDWCjjTXGbih = P_1;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
		{
			VKEGIaHWDiatFndfJLAnTTdeuEsNA = P_0.VKEGIaHWDiatFndfJLAnTTdeuEsNA;
			XRkuCHqyNhRxuJRvpDWCjjTXGbih = P_0.XRkuCHqyNhRxuJRvpDWCjjTXGbih;
		}
	}
}
