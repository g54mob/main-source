using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		private Pole TdJcRpjgNZFTplnvRloFjqQVLfBE;

		public Pole axisContribution => TdJcRpjgNZFTplnvRloFjqQVLfBE;

		internal ControllerTemplateActionButtonMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Button)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			JYyEPkmZztzXfbEgKghAFieAytO(serializedObject);
		}

		internal ControllerTemplateActionButtonMap(int templateElementIdentifierId, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Button, templateElementIdentifierId, actionElementMap)
		{
			TdJcRpjgNZFTplnvRloFjqQVLfBE = actionElementMap.axisContribution;
		}

		internal ControllerTemplateActionButtonMap(int elementIdentifierId, int actionId, Pole axisContribution, bool enabled)
			: base(ControllerTemplateElementType.Button, elementIdentifierId, actionId, enabled)
		{
			TdJcRpjgNZFTplnvRloFjqQVLfBE = axisContribution;
		}

		internal override void qnRcKibdUQgUDehMYaMNRcmEEUp(SerializedObject P_0)
		{
			base.qnRcKibdUQgUDehMYaMNRcmEEUp(P_0);
			P_0.Add("axisContribution", TdJcRpjgNZFTplnvRloFjqQVLfBE);
		}

		internal override void JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
		{
			base.JYyEPkmZztzXfbEgKghAFieAytO(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref TdJcRpjgNZFTplnvRloFjqQVLfBE);
		}

		internal override void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			TdJcRpjgNZFTplnvRloFjqQVLfBE = Pole.Positive;
		}

		internal override int DWiXTBvSexeltdYwQLfeaasOKQSe(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateButtonSource controllerTemplateButtonSource))
			{
				return 0;
			}
			int num = 0;
			ActionElementMap actionElementMap = YkifEbgDniLvOpOnjDjWMsNJrvPF(controllerTemplateButtonSource.target, TdJcRpjgNZFTplnvRloFjqQVLfBE);
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num++;
			}
			return num;
		}

		private ActionElementMap YkifEbgDniLvOpOnjDjWMsNJrvPF(IControllerElementTarget P_0, Pole P_1)
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
			if ((controllerElementType != ControllerElementType.Axis || axisRange != AxisRange.Full) && (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button))
			{
				actionElementMap._axisContribution = P_1;
			}
			return actionElementMap;
		}
	}
}
