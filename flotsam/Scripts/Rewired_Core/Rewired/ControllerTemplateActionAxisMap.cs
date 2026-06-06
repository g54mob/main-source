using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange yeJtKklpbZxLLaehhdzrfeLqXoKy;

		private Pole BZCtwnuuXYMzXZzEnNAnJWjcbPbb;

		private bool aIFaGkiEnDyCcndgMIzFkIMlrOPMA;

		public AxisRange axisRange => yeJtKklpbZxLLaehhdzrfeLqXoKy;

		public Pole axisContribution => BZCtwnuuXYMzXZzEnNAnJWjcbPbb;

		public bool invert => aIFaGkiEnDyCcndgMIzFkIMlrOPMA;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			oHgPtbWlDmjEOmcsdWnjfXkvQqvp(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			yeJtKklpbZxLLaehhdzrfeLqXoKy = P_1;
			BZCtwnuuXYMzXZzEnNAnJWjcbPbb = P_2.axisContribution;
			aIFaGkiEnDyCcndgMIzFkIMlrOPMA = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			yeJtKklpbZxLLaehhdzrfeLqXoKy = P_2;
			BZCtwnuuXYMzXZzEnNAnJWjcbPbb = P_3;
			aIFaGkiEnDyCcndgMIzFkIMlrOPMA = P_4;
		}

		internal void kPwpUJAbzrbVBCgzZEkzHFHGdfE(SerializedObject P_0)
		{
			base.fNGIWqreoGiBuiZUttQfbZoioTh(P_0);
			P_0.Add("axisContribution", BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
			P_0.Add("axisRange", yeJtKklpbZxLLaehhdzrfeLqXoKy);
			P_0.Add("invert", aIFaGkiEnDyCcndgMIzFkIMlrOPMA);
		}

		internal void iUZsPJhsTueuUUoJAcDxdyKhLfzdA(SerializedObject P_0)
		{
			base.oHgPtbWlDmjEOmcsdWnjfXkvQqvp(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
			P_0.TryGetDeserializedValueByRef("axisRange", ref yeJtKklpbZxLLaehhdzrfeLqXoKy);
			P_0.TryGetDeserializedValueByRef("invert", ref aIFaGkiEnDyCcndgMIzFkIMlrOPMA);
		}

		internal void uUOtRucqPQzEsOTMhgPiXRSwjdjP()
		{
			yeJtKklpbZxLLaehhdzrfeLqXoKy = AxisRange.Full;
			BZCtwnuuXYMzXZzEnNAnJWjcbPbb = Pole.Positive;
			aIFaGkiEnDyCcndgMIzFkIMlrOPMA = false;
		}

		internal int ICsWczbJebgcYoqXrMFEKyjQrjoN(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (yeJtKklpbZxLLaehhdzrfeLqXoKy == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = DfbsbIxcFwFgaJqlvQJrOjPypWaZ(controllerTemplateAxisSource.positiveTarget, (!aIFaGkiEnDyCcndgMIzFkIMlrOPMA) ? AxisRange.Positive : AxisRange.Negative, BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = DfbsbIxcFwFgaJqlvQJrOjPypWaZ(controllerTemplateAxisSource.negativeTarget, aIFaGkiEnDyCcndgMIzFkIMlrOPMA ? AxisRange.Positive : AxisRange.Negative, BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = DfbsbIxcFwFgaJqlvQJrOjPypWaZ(controllerTemplateAxisSource.fullTarget, AxisRange.Full, BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (yeJtKklpbZxLLaehhdzrfeLqXoKy == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = GCsHAdJXUuDcCGHNoXWucfuWHthz(controllerTemplateAxisSource.positiveTarget, Pole.Positive, BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = GCsHAdJXUuDcCGHNoXWucfuWHthz(controllerTemplateAxisSource.negativeTarget, Pole.Negative, BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = GCsHAdJXUuDcCGHNoXWucfuWHthz(controllerTemplateAxisSource.fullTarget, (yeJtKklpbZxLLaehhdzrfeLqXoKy == AxisRange.Negative) ? Pole.Negative : Pole.Positive, BZCtwnuuXYMzXZzEnNAnJWjcbPbb);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap DfbsbIxcFwFgaJqlvQJrOjPypWaZ(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			try
			{
				ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
				ActionElementMap actionElementMap = new ActionElementMap();
				actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
				actionElementMap._elementType = controllerElementType;
				actionElementMap._axisRange = axisRange;
				if (axisRange == AxisRange.Full)
				{
					switch (controllerElementType)
					{
					case ControllerElementType.Axis:
						actionElementMap._invert = aIFaGkiEnDyCcndgMIzFkIMlrOPMA;
						break;
					case ControllerElementType.Button:
						actionElementMap._axisContribution = P_2;
						break;
					}
				}
				else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
				{
					Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
					actionElementMap._axisContribution = pole;
				}
				return actionElementMap;
			}
			finally
			{
				ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			}
		}

		private ActionElementMap GCsHAdJXUuDcCGHNoXWucfuWHthz(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			try
			{
				ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
				ActionElementMap actionElementMap = new ActionElementMap();
				actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
				actionElementMap._elementType = controllerElementType;
				actionElementMap._axisRange = axisRange;
				if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
				{
					actionElementMap._axisRange = ((P_1 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
					actionElementMap._axisContribution = P_2;
				}
				else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
				{
					actionElementMap._axisContribution = P_2;
				}
				return actionElementMap;
			}
			finally
			{
				ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			}
		}
	}
}
