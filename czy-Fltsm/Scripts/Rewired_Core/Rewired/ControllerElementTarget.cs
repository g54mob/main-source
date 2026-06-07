using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element SXXyLqiGEvKLSeiyHkbXuyNowVJE;

		private AxisRange WwNQIdNGEtLyVUGvUboivdbuAzRdA;

		public int elementIdentifierId
		{
			get
			{
				if (SXXyLqiGEvKLSeiyHkbXuyNowVJE == null)
				{
					return -1;
				}
				return SXXyLqiGEvKLSeiyHkbXuyNowVJE.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return WwNQIdNGEtLyVUGvUboivdbuAzRdA;
			}
			set
			{
				WwNQIdNGEtLyVUGvUboivdbuAzRdA = value;
			}
		}

		public bool hasTarget => SXXyLqiGEvKLSeiyHkbXuyNowVJE != null;

		public ControllerElementType elementType
		{
			get
			{
				if (SXXyLqiGEvKLSeiyHkbXuyNowVJE == null)
				{
					return ControllerElementType.Axis;
				}
				return SXXyLqiGEvKLSeiyHkbXuyNowVJE.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (SXXyLqiGEvKLSeiyHkbXuyNowVJE == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = SXXyLqiGEvKLSeiyHkbXuyNowVJE.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(SXXyLqiGEvKLSeiyHkbXuyNowVJE.type, WwNQIdNGEtLyVUGvUboivdbuAzRdA);
			}
		}

		public Controller controller
		{
			get
			{
				if (SXXyLqiGEvKLSeiyHkbXuyNowVJE == null)
				{
					return null;
				}
				return SXXyLqiGEvKLSeiyHkbXuyNowVJE.WiYiRLTehfcPjuHpvomznsiiIAfK;
			}
		}

		public Controller.Element element
		{
			get
			{
				return SXXyLqiGEvKLSeiyHkbXuyNowVJE;
			}
			set
			{
				SXXyLqiGEvKLSeiyHkbXuyNowVJE = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.SJKUZyLtwpanDYOUUcKgIbLBAesr != null)
			{
				Controller controller = ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.DFkLoOraYKZxPsJxXLcjqacSAAGg(P_0.SJKUZyLtwpanDYOUUcKgIbLBAesr.controllerType, P_0.SJKUZyLtwpanDYOUUcKgIbLBAesr.controllerId);
				SXXyLqiGEvKLSeiyHkbXuyNowVJE = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				SXXyLqiGEvKLSeiyHkbXuyNowVJE = null;
			}
			WwNQIdNGEtLyVUGvUboivdbuAzRdA = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			SXXyLqiGEvKLSeiyHkbXuyNowVJE = P_0.SXXyLqiGEvKLSeiyHkbXuyNowVJE;
			WwNQIdNGEtLyVUGvUboivdbuAzRdA = P_0.WwNQIdNGEtLyVUGvUboivdbuAzRdA;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			SXXyLqiGEvKLSeiyHkbXuyNowVJE = P_0.element;
			WwNQIdNGEtLyVUGvUboivdbuAzRdA = P_0.axisRange;
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
