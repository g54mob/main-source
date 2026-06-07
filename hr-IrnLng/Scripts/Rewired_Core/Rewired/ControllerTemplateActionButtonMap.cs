using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		private Pole dqvocVVDwCzopurHObiMuAnppvn;

		public Pole axisContribution => dqvocVVDwCzopurHObiMuAnppvn;

		internal ControllerTemplateActionButtonMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Button)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			tlMbXbDwaaKJTudkJIuTPdZmwuo(serializedObject);
		}

		internal ControllerTemplateActionButtonMap(int templateElementIdentifierId, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Button, templateElementIdentifierId, actionElementMap)
		{
			dqvocVVDwCzopurHObiMuAnppvn = actionElementMap.axisContribution;
		}

		internal ControllerTemplateActionButtonMap(int elementIdentifierId, int actionId, Pole axisContribution, bool enabled)
			: base(ControllerTemplateElementType.Button, elementIdentifierId, actionId, enabled)
		{
			dqvocVVDwCzopurHObiMuAnppvn = axisContribution;
		}

		internal override void MtzBZMSurJCTTdjsBqkSRhDyHCFi(SerializedObject P_0)
		{
			base.MtzBZMSurJCTTdjsBqkSRhDyHCFi(P_0);
			P_0.Add("axisContribution", dqvocVVDwCzopurHObiMuAnppvn);
		}

		internal override void tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			base.tlMbXbDwaaKJTudkJIuTPdZmwuo(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref dqvocVVDwCzopurHObiMuAnppvn);
		}

		internal override void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			dqvocVVDwCzopurHObiMuAnppvn = Pole.Positive;
		}

		internal override int tPGjctEvLctErHTWNnUziXPyYAa(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateButtonSource controllerTemplateButtonSource))
			{
				return 0;
			}
			int num = 0;
			ActionElementMap actionElementMap = oTIopTqNIjBEYDHBoQxXPywdCldb(controllerTemplateButtonSource.target, dqvocVVDwCzopurHObiMuAnppvn);
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num++;
			}
			return num;
		}

		private ActionElementMap oTIopTqNIjBEYDHBoQxXPywdCldb(IControllerElementTarget P_0, Pole P_1)
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
