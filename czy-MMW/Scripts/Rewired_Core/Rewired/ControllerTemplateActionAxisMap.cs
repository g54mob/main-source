using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange gkUAeQiaeMLByMIyCYYXCkcafcleA;

		private Pole DBLuaYrjtXHcYfTibFousjdjCpaGA;

		private bool gDMLiADOgYmLHDElxAEzbqbzbEoGA;

		public AxisRange axisRange => gkUAeQiaeMLByMIyCYYXCkcafcleA;

		public Pole axisContribution => DBLuaYrjtXHcYfTibFousjdjCpaGA;

		public bool invert => gDMLiADOgYmLHDElxAEzbqbzbEoGA;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			qnVwNfJEznmnhAlEVWZNSXzfyGGb(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			gkUAeQiaeMLByMIyCYYXCkcafcleA = P_1;
			DBLuaYrjtXHcYfTibFousjdjCpaGA = P_2.axisContribution;
			gDMLiADOgYmLHDElxAEzbqbzbEoGA = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			gkUAeQiaeMLByMIyCYYXCkcafcleA = P_2;
			DBLuaYrjtXHcYfTibFousjdjCpaGA = P_3;
			gDMLiADOgYmLHDElxAEzbqbzbEoGA = P_4;
		}

		internal void mdWNhTEFVexTShbXORsoQusTjMAP(SerializedObject P_0)
		{
			base.rEEPJurqodegiEtUjISsUIygEwqP(P_0);
			P_0.Add("axisContribution", DBLuaYrjtXHcYfTibFousjdjCpaGA);
			P_0.Add("axisRange", gkUAeQiaeMLByMIyCYYXCkcafcleA);
			P_0.Add("invert", gDMLiADOgYmLHDElxAEzbqbzbEoGA);
		}

		internal void yhMCsrsbIbaKtenOpasLfPdbRnQtA(SerializedObject P_0)
		{
			base.qnVwNfJEznmnhAlEVWZNSXzfyGGb(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref DBLuaYrjtXHcYfTibFousjdjCpaGA);
			P_0.TryGetDeserializedValueByRef("axisRange", ref gkUAeQiaeMLByMIyCYYXCkcafcleA);
			P_0.TryGetDeserializedValueByRef("invert", ref gDMLiADOgYmLHDElxAEzbqbzbEoGA);
		}

		internal void cHPIwEvZATqSJwOPEuRSuRzsfaSj()
		{
			gkUAeQiaeMLByMIyCYYXCkcafcleA = AxisRange.Full;
			DBLuaYrjtXHcYfTibFousjdjCpaGA = Pole.Positive;
			gDMLiADOgYmLHDElxAEzbqbzbEoGA = false;
		}

		internal int WLdzPFcfncAWzICAAliongCOmtRr(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (gkUAeQiaeMLByMIyCYYXCkcafcleA == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = hjPaRjbMvCXDurmzBQwuWVFLMgGO(controllerTemplateAxisSource.positiveTarget, (!gDMLiADOgYmLHDElxAEzbqbzbEoGA) ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = hjPaRjbMvCXDurmzBQwuWVFLMgGO(controllerTemplateAxisSource.negativeTarget, gDMLiADOgYmLHDElxAEzbqbzbEoGA ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = hjPaRjbMvCXDurmzBQwuWVFLMgGO(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (gkUAeQiaeMLByMIyCYYXCkcafcleA == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = EAxPwPWsVbOqtddATvIWKHZYpJYI(controllerTemplateAxisSource.positiveTarget, Pole.Positive, DBLuaYrjtXHcYfTibFousjdjCpaGA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = EAxPwPWsVbOqtddATvIWKHZYpJYI(controllerTemplateAxisSource.negativeTarget, Pole.Negative, DBLuaYrjtXHcYfTibFousjdjCpaGA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = EAxPwPWsVbOqtddATvIWKHZYpJYI(controllerTemplateAxisSource.fullTarget, (gkUAeQiaeMLByMIyCYYXCkcafcleA == AxisRange.Negative) ? Pole.Negative : Pole.Positive, DBLuaYrjtXHcYfTibFousjdjCpaGA);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap hjPaRjbMvCXDurmzBQwuWVFLMgGO(IControllerElementTarget P_0, AxisRange P_1)
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
				actionElementMap._invert = gDMLiADOgYmLHDElxAEzbqbzbEoGA;
			}
			else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
			{
				Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
				actionElementMap._axisContribution = pole;
			}
			return actionElementMap;
		}

		private ActionElementMap EAxPwPWsVbOqtddATvIWKHZYpJYI(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
