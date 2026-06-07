using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange iKpdeCcvrahntrCdBHCMvDYKvQZ;

		private Pole dqvocVVDwCzopurHObiMuAnppvn;

		private bool HTcNJhfsJaGkhcFqZdFJZCbLyyS;

		public AxisRange axisRange => iKpdeCcvrahntrCdBHCMvDYKvQZ;

		public Pole axisContribution => dqvocVVDwCzopurHObiMuAnppvn;

		public bool invert => HTcNJhfsJaGkhcFqZdFJZCbLyyS;

		internal ControllerTemplateActionAxisMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Axis)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			tlMbXbDwaaKJTudkJIuTPdZmwuo(serializedObject);
		}

		internal ControllerTemplateActionAxisMap(int templateElementIdentifierId, AxisRange axisRange, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Axis, templateElementIdentifierId, actionElementMap)
		{
			iKpdeCcvrahntrCdBHCMvDYKvQZ = axisRange;
			dqvocVVDwCzopurHObiMuAnppvn = actionElementMap.axisContribution;
			HTcNJhfsJaGkhcFqZdFJZCbLyyS = actionElementMap._invert;
		}

		internal ControllerTemplateActionAxisMap(int elementIdentifierId, int actionId, AxisRange axisRange, Pole axisContribution, bool invert, bool enabled)
			: base(ControllerTemplateElementType.Axis, elementIdentifierId, actionId, enabled)
		{
			iKpdeCcvrahntrCdBHCMvDYKvQZ = axisRange;
			dqvocVVDwCzopurHObiMuAnppvn = axisContribution;
			HTcNJhfsJaGkhcFqZdFJZCbLyyS = invert;
		}

		internal override void MtzBZMSurJCTTdjsBqkSRhDyHCFi(SerializedObject P_0)
		{
			base.MtzBZMSurJCTTdjsBqkSRhDyHCFi(P_0);
			P_0.Add("axisContribution", dqvocVVDwCzopurHObiMuAnppvn);
			P_0.Add("axisRange", iKpdeCcvrahntrCdBHCMvDYKvQZ);
			P_0.Add("invert", HTcNJhfsJaGkhcFqZdFJZCbLyyS);
		}

		internal override void tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			base.tlMbXbDwaaKJTudkJIuTPdZmwuo(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref dqvocVVDwCzopurHObiMuAnppvn);
			P_0.TryGetDeserializedValueByRef("axisRange", ref iKpdeCcvrahntrCdBHCMvDYKvQZ);
			P_0.TryGetDeserializedValueByRef("invert", ref HTcNJhfsJaGkhcFqZdFJZCbLyyS);
		}

		internal override void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			iKpdeCcvrahntrCdBHCMvDYKvQZ = AxisRange.Full;
			dqvocVVDwCzopurHObiMuAnppvn = Pole.Positive;
			HTcNJhfsJaGkhcFqZdFJZCbLyyS = false;
		}

		internal override int tPGjctEvLctErHTWNnUziXPyYAa(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (iKpdeCcvrahntrCdBHCMvDYKvQZ == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = WFodMNKqhdAnptByvIbiWhrmWux(controllerTemplateAxisSource.positiveTarget, (!HTcNJhfsJaGkhcFqZdFJZCbLyyS) ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = WFodMNKqhdAnptByvIbiWhrmWux(controllerTemplateAxisSource.negativeTarget, HTcNJhfsJaGkhcFqZdFJZCbLyyS ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = WFodMNKqhdAnptByvIbiWhrmWux(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (iKpdeCcvrahntrCdBHCMvDYKvQZ == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = dyEPhJoYkkmKmUpWDbnGZIRBysr(controllerTemplateAxisSource.positiveTarget, Pole.Positive, dqvocVVDwCzopurHObiMuAnppvn);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = dyEPhJoYkkmKmUpWDbnGZIRBysr(controllerTemplateAxisSource.negativeTarget, Pole.Negative, dqvocVVDwCzopurHObiMuAnppvn);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = dyEPhJoYkkmKmUpWDbnGZIRBysr(controllerTemplateAxisSource.fullTarget, (iKpdeCcvrahntrCdBHCMvDYKvQZ == AxisRange.Negative) ? Pole.Negative : Pole.Positive, dqvocVVDwCzopurHObiMuAnppvn);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap WFodMNKqhdAnptByvIbiWhrmWux(IControllerElementTarget P_0, AxisRange P_1)
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
				actionElementMap._invert = HTcNJhfsJaGkhcFqZdFJZCbLyyS;
			}
			else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
			{
				Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
				actionElementMap._axisContribution = pole;
			}
			return actionElementMap;
		}

		private ActionElementMap dyEPhJoYkkmKmUpWDbnGZIRBysr(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
