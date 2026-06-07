using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange PpBKvDDuwSJgSbXdRraQGlHTKPPc;

		private Pole IYTFZmytpwZEumqfEMDkFoEwUfno;

		private bool alMuiGYujWanyqnrVCGdmGfWAcGR;

		public AxisRange axisRange => PpBKvDDuwSJgSbXdRraQGlHTKPPc;

		public Pole axisContribution => IYTFZmytpwZEumqfEMDkFoEwUfno;

		public bool invert => alMuiGYujWanyqnrVCGdmGfWAcGR;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			IqWUQdetEUgWKmOIFRihysPfqZgC(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_1;
			IYTFZmytpwZEumqfEMDkFoEwUfno = P_2.axisContribution;
			alMuiGYujWanyqnrVCGdmGfWAcGR = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_2;
			IYTFZmytpwZEumqfEMDkFoEwUfno = P_3;
			alMuiGYujWanyqnrVCGdmGfWAcGR = P_4;
		}

		internal override void pMFmgpdCytjWAfCkBRuiiiznUeVd(SerializedObject P_0)
		{
			base.pMFmgpdCytjWAfCkBRuiiiznUeVd(P_0);
			P_0.Add("axisContribution", IYTFZmytpwZEumqfEMDkFoEwUfno);
			P_0.Add("axisRange", PpBKvDDuwSJgSbXdRraQGlHTKPPc);
			P_0.Add("invert", alMuiGYujWanyqnrVCGdmGfWAcGR);
		}

		internal override void IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
		{
			base.IqWUQdetEUgWKmOIFRihysPfqZgC(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref IYTFZmytpwZEumqfEMDkFoEwUfno);
			P_0.TryGetDeserializedValueByRef("axisRange", ref PpBKvDDuwSJgSbXdRraQGlHTKPPc);
			P_0.TryGetDeserializedValueByRef("invert", ref alMuiGYujWanyqnrVCGdmGfWAcGR);
		}

		internal override void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = AxisRange.Full;
			IYTFZmytpwZEumqfEMDkFoEwUfno = Pole.Positive;
			alMuiGYujWanyqnrVCGdmGfWAcGR = false;
		}

		internal override int EbwwBWdfCAxikZkwZdUTTIgnVIcY(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (PpBKvDDuwSJgSbXdRraQGlHTKPPc == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = jbEIqbvXbTiKmxadlArBlgUpyCcS(controllerTemplateAxisSource.positiveTarget, (!alMuiGYujWanyqnrVCGdmGfWAcGR) ? AxisRange.Positive : AxisRange.Negative, IYTFZmytpwZEumqfEMDkFoEwUfno);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = jbEIqbvXbTiKmxadlArBlgUpyCcS(controllerTemplateAxisSource.negativeTarget, alMuiGYujWanyqnrVCGdmGfWAcGR ? AxisRange.Positive : AxisRange.Negative, IYTFZmytpwZEumqfEMDkFoEwUfno);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = jbEIqbvXbTiKmxadlArBlgUpyCcS(controllerTemplateAxisSource.fullTarget, AxisRange.Full, IYTFZmytpwZEumqfEMDkFoEwUfno);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (PpBKvDDuwSJgSbXdRraQGlHTKPPc == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = EJqZWiBRhSDkdYduDoAgaikWdwtaA(controllerTemplateAxisSource.positiveTarget, Pole.Positive, IYTFZmytpwZEumqfEMDkFoEwUfno);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = EJqZWiBRhSDkdYduDoAgaikWdwtaA(controllerTemplateAxisSource.negativeTarget, Pole.Negative, IYTFZmytpwZEumqfEMDkFoEwUfno);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = EJqZWiBRhSDkdYduDoAgaikWdwtaA(controllerTemplateAxisSource.fullTarget, (PpBKvDDuwSJgSbXdRraQGlHTKPPc == AxisRange.Negative) ? Pole.Negative : Pole.Positive, IYTFZmytpwZEumqfEMDkFoEwUfno);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap jbEIqbvXbTiKmxadlArBlgUpyCcS(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
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
			if (axisRange == AxisRange.Full)
			{
				switch (controllerElementType)
				{
				case ControllerElementType.Axis:
					actionElementMap._invert = alMuiGYujWanyqnrVCGdmGfWAcGR;
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

		private ActionElementMap EJqZWiBRhSDkdYduDoAgaikWdwtaA(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
