using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange aAJhGpXOJDjMpVaJkCqSuhDLlrMx;

		private Pole FeOlIjYECYDORyAFBTGrWHAOUePO;

		private bool wCJkUzeDNDAYCBSEVhisAPQAQJHjB;

		public AxisRange axisRange => aAJhGpXOJDjMpVaJkCqSuhDLlrMx;

		public Pole axisContribution => FeOlIjYECYDORyAFBTGrWHAOUePO;

		public bool invert => wCJkUzeDNDAYCBSEVhisAPQAQJHjB;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			uMqyncwXliJAiRiUiWiUyLiSfrpdA(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			aAJhGpXOJDjMpVaJkCqSuhDLlrMx = P_1;
			FeOlIjYECYDORyAFBTGrWHAOUePO = P_2.axisContribution;
			wCJkUzeDNDAYCBSEVhisAPQAQJHjB = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			aAJhGpXOJDjMpVaJkCqSuhDLlrMx = P_2;
			FeOlIjYECYDORyAFBTGrWHAOUePO = P_3;
			wCJkUzeDNDAYCBSEVhisAPQAQJHjB = P_4;
		}

		internal void wZXauehRklgzZwhqkEAzaKNkAXjhA(SerializedObject P_0)
		{
			base.vABcCNWeRmzGbFnvLaadmaTXvjBx(P_0);
			P_0.Add("axisContribution", FeOlIjYECYDORyAFBTGrWHAOUePO);
			P_0.Add("axisRange", aAJhGpXOJDjMpVaJkCqSuhDLlrMx);
			P_0.Add("invert", wCJkUzeDNDAYCBSEVhisAPQAQJHjB);
		}

		internal void iyLORKJezyQkofhjNOMIfKKAbejP(SerializedObject P_0)
		{
			base.uMqyncwXliJAiRiUiWiUyLiSfrpdA(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref FeOlIjYECYDORyAFBTGrWHAOUePO);
			P_0.TryGetDeserializedValueByRef("axisRange", ref aAJhGpXOJDjMpVaJkCqSuhDLlrMx);
			P_0.TryGetDeserializedValueByRef("invert", ref wCJkUzeDNDAYCBSEVhisAPQAQJHjB);
		}

		internal void eyQPRvGRjOnCYpEiutIVIgQZSajr()
		{
			aAJhGpXOJDjMpVaJkCqSuhDLlrMx = AxisRange.Full;
			FeOlIjYECYDORyAFBTGrWHAOUePO = Pole.Positive;
			wCJkUzeDNDAYCBSEVhisAPQAQJHjB = false;
		}

		internal int GYyqcyTHUpqesZIbsCQbRNdvgekz(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (aAJhGpXOJDjMpVaJkCqSuhDLlrMx == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = BjztdDZohmDuOEBNmtCOqTBRfVabA(controllerTemplateAxisSource.positiveTarget, (!wCJkUzeDNDAYCBSEVhisAPQAQJHjB) ? AxisRange.Positive : AxisRange.Negative, FeOlIjYECYDORyAFBTGrWHAOUePO);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = BjztdDZohmDuOEBNmtCOqTBRfVabA(controllerTemplateAxisSource.negativeTarget, wCJkUzeDNDAYCBSEVhisAPQAQJHjB ? AxisRange.Positive : AxisRange.Negative, FeOlIjYECYDORyAFBTGrWHAOUePO);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = BjztdDZohmDuOEBNmtCOqTBRfVabA(controllerTemplateAxisSource.fullTarget, AxisRange.Full, FeOlIjYECYDORyAFBTGrWHAOUePO);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (aAJhGpXOJDjMpVaJkCqSuhDLlrMx == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = EDwHCmzmoqrakgqtzYZJqMancslN(controllerTemplateAxisSource.positiveTarget, Pole.Positive, FeOlIjYECYDORyAFBTGrWHAOUePO);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = EDwHCmzmoqrakgqtzYZJqMancslN(controllerTemplateAxisSource.negativeTarget, Pole.Negative, FeOlIjYECYDORyAFBTGrWHAOUePO);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = EDwHCmzmoqrakgqtzYZJqMancslN(controllerTemplateAxisSource.fullTarget, (aAJhGpXOJDjMpVaJkCqSuhDLlrMx == AxisRange.Negative) ? Pole.Negative : Pole.Positive, FeOlIjYECYDORyAFBTGrWHAOUePO);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap BjztdDZohmDuOEBNmtCOqTBRfVabA(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				ActionElementMap actionElementMap = new ActionElementMap();
				actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
				actionElementMap._elementType = controllerElementType;
				actionElementMap._axisRange = axisRange;
				if (axisRange == AxisRange.Full)
				{
					switch (controllerElementType)
					{
					case ControllerElementType.Axis:
						actionElementMap._invert = wCJkUzeDNDAYCBSEVhisAPQAQJHjB;
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
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		private ActionElementMap EDwHCmzmoqrakgqtzYZJqMancslN(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
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
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}
	}
}
