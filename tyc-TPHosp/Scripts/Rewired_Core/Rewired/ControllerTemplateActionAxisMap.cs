using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange INqAuPUOdfKjEyVKDGDlvfaJUlc;

		private Pole TdJcRpjgNZFTplnvRloFjqQVLfBE;

		private bool rqWybVSDLptxnnIdEIbMBmnbSae;

		public AxisRange axisRange => INqAuPUOdfKjEyVKDGDlvfaJUlc;

		public Pole axisContribution => TdJcRpjgNZFTplnvRloFjqQVLfBE;

		public bool invert => rqWybVSDLptxnnIdEIbMBmnbSae;

		internal ControllerTemplateActionAxisMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Axis)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			JYyEPkmZztzXfbEgKghAFieAytO(serializedObject);
		}

		internal ControllerTemplateActionAxisMap(int templateElementIdentifierId, AxisRange axisRange, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Axis, templateElementIdentifierId, actionElementMap)
		{
			INqAuPUOdfKjEyVKDGDlvfaJUlc = axisRange;
			TdJcRpjgNZFTplnvRloFjqQVLfBE = actionElementMap.axisContribution;
			rqWybVSDLptxnnIdEIbMBmnbSae = actionElementMap._invert;
		}

		internal ControllerTemplateActionAxisMap(int elementIdentifierId, int actionId, AxisRange axisRange, Pole axisContribution, bool invert, bool enabled)
			: base(ControllerTemplateElementType.Axis, elementIdentifierId, actionId, enabled)
		{
			INqAuPUOdfKjEyVKDGDlvfaJUlc = axisRange;
			TdJcRpjgNZFTplnvRloFjqQVLfBE = axisContribution;
			rqWybVSDLptxnnIdEIbMBmnbSae = invert;
		}

		internal override void qnRcKibdUQgUDehMYaMNRcmEEUp(SerializedObject P_0)
		{
			base.qnRcKibdUQgUDehMYaMNRcmEEUp(P_0);
			P_0.Add("axisContribution", TdJcRpjgNZFTplnvRloFjqQVLfBE);
			P_0.Add("axisRange", INqAuPUOdfKjEyVKDGDlvfaJUlc);
			P_0.Add("invert", rqWybVSDLptxnnIdEIbMBmnbSae);
		}

		internal override void JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
		{
			base.JYyEPkmZztzXfbEgKghAFieAytO(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref TdJcRpjgNZFTplnvRloFjqQVLfBE);
			P_0.TryGetDeserializedValueByRef("axisRange", ref INqAuPUOdfKjEyVKDGDlvfaJUlc);
			P_0.TryGetDeserializedValueByRef("invert", ref rqWybVSDLptxnnIdEIbMBmnbSae);
		}

		internal override void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			INqAuPUOdfKjEyVKDGDlvfaJUlc = AxisRange.Full;
			TdJcRpjgNZFTplnvRloFjqQVLfBE = Pole.Positive;
			rqWybVSDLptxnnIdEIbMBmnbSae = false;
		}

		internal override int DWiXTBvSexeltdYwQLfeaasOKQSe(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (INqAuPUOdfKjEyVKDGDlvfaJUlc == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = acWQiwjILsxYteqroERqWOXIKcO(controllerTemplateAxisSource.positiveTarget, (!rqWybVSDLptxnnIdEIbMBmnbSae) ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = acWQiwjILsxYteqroERqWOXIKcO(controllerTemplateAxisSource.negativeTarget, rqWybVSDLptxnnIdEIbMBmnbSae ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = acWQiwjILsxYteqroERqWOXIKcO(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (INqAuPUOdfKjEyVKDGDlvfaJUlc == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = DfyFMbKBBbIziJLuGWlRdXetXaHN(controllerTemplateAxisSource.positiveTarget, Pole.Positive, TdJcRpjgNZFTplnvRloFjqQVLfBE);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = DfyFMbKBBbIziJLuGWlRdXetXaHN(controllerTemplateAxisSource.negativeTarget, Pole.Negative, TdJcRpjgNZFTplnvRloFjqQVLfBE);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = DfyFMbKBBbIziJLuGWlRdXetXaHN(controllerTemplateAxisSource.fullTarget, (INqAuPUOdfKjEyVKDGDlvfaJUlc == AxisRange.Negative) ? Pole.Negative : Pole.Positive, TdJcRpjgNZFTplnvRloFjqQVLfBE);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap acWQiwjILsxYteqroERqWOXIKcO(IControllerElementTarget P_0, AxisRange P_1)
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
				actionElementMap._invert = rqWybVSDLptxnnIdEIbMBmnbSae;
			}
			else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
			{
				Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
				actionElementMap._axisContribution = pole;
			}
			return actionElementMap;
		}

		private ActionElementMap DfyFMbKBBbIziJLuGWlRdXetXaHN(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
