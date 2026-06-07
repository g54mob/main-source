using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange emLkZqjpKMMiQMkdaETOTOIMfGJq;

		private Pole xBLbApMnHgwbIBXRhstMIevzfxtFA;

		private bool TuEulFuaNAxVEPsDuesLtgKLMgQw;

		public AxisRange axisRange => emLkZqjpKMMiQMkdaETOTOIMfGJq;

		public Pole axisContribution => xBLbApMnHgwbIBXRhstMIevzfxtFA;

		public bool invert => TuEulFuaNAxVEPsDuesLtgKLMgQw;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			xIgDRHQmTOVJkRVsknhXpBHuPygR(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_1;
			xBLbApMnHgwbIBXRhstMIevzfxtFA = P_2.axisContribution;
			TuEulFuaNAxVEPsDuesLtgKLMgQw = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_2;
			xBLbApMnHgwbIBXRhstMIevzfxtFA = P_3;
			TuEulFuaNAxVEPsDuesLtgKLMgQw = P_4;
		}

		internal override void OwZlvwNnIfDEsAMweyvGbtLoYQJtA(SerializedObject P_0)
		{
			base.OwZlvwNnIfDEsAMweyvGbtLoYQJtA(P_0);
			P_0.Add("axisContribution", xBLbApMnHgwbIBXRhstMIevzfxtFA);
			P_0.Add("axisRange", emLkZqjpKMMiQMkdaETOTOIMfGJq);
			P_0.Add("invert", TuEulFuaNAxVEPsDuesLtgKLMgQw);
		}

		internal override void xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
			base.xIgDRHQmTOVJkRVsknhXpBHuPygR(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref xBLbApMnHgwbIBXRhstMIevzfxtFA);
			P_0.TryGetDeserializedValueByRef("axisRange", ref emLkZqjpKMMiQMkdaETOTOIMfGJq);
			P_0.TryGetDeserializedValueByRef("invert", ref TuEulFuaNAxVEPsDuesLtgKLMgQw);
		}

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			emLkZqjpKMMiQMkdaETOTOIMfGJq = AxisRange.Full;
			xBLbApMnHgwbIBXRhstMIevzfxtFA = Pole.Positive;
			TuEulFuaNAxVEPsDuesLtgKLMgQw = false;
		}

		internal override int xeeUWXXmkCBeEkgKwamzOWDeUHkL(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (emLkZqjpKMMiQMkdaETOTOIMfGJq == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = AKUXNcLtPHPFSODNQrFdwqzqIGsX(controllerTemplateAxisSource.positiveTarget, (!TuEulFuaNAxVEPsDuesLtgKLMgQw) ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = AKUXNcLtPHPFSODNQrFdwqzqIGsX(controllerTemplateAxisSource.negativeTarget, TuEulFuaNAxVEPsDuesLtgKLMgQw ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = AKUXNcLtPHPFSODNQrFdwqzqIGsX(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (emLkZqjpKMMiQMkdaETOTOIMfGJq == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = nasBWjpxRUJnXpyKkmfCvcNZHcdv(controllerTemplateAxisSource.positiveTarget, Pole.Positive, xBLbApMnHgwbIBXRhstMIevzfxtFA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = nasBWjpxRUJnXpyKkmfCvcNZHcdv(controllerTemplateAxisSource.negativeTarget, Pole.Negative, xBLbApMnHgwbIBXRhstMIevzfxtFA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = nasBWjpxRUJnXpyKkmfCvcNZHcdv(controllerTemplateAxisSource.fullTarget, (emLkZqjpKMMiQMkdaETOTOIMfGJq == AxisRange.Negative) ? Pole.Negative : Pole.Positive, xBLbApMnHgwbIBXRhstMIevzfxtFA);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap AKUXNcLtPHPFSODNQrFdwqzqIGsX(IControllerElementTarget P_0, AxisRange P_1)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
			actionElementMap._elementType = controllerElementType;
			actionElementMap._axisRange = axisRange;
			if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
			{
				actionElementMap._invert = TuEulFuaNAxVEPsDuesLtgKLMgQw;
			}
			else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
			{
				Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
				actionElementMap._axisContribution = pole;
			}
			return actionElementMap;
		}

		private ActionElementMap nasBWjpxRUJnXpyKkmfCvcNZHcdv(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
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
	}
}
